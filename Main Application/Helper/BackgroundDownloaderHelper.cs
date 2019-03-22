using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Media.MediaProperties;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Web;

namespace PrimeTube.Helper
{
    public class BackgroundDownloaderHelper
    {
        private List<DownloadOperation> activeDownloads;
        private CancellationTokenSource cts = new CancellationTokenSource();

        // Dictionary tracker
        private Dictionary<string, StorageFile> StorageFileDictionary = new Dictionary<string, StorageFile>();
        private Dictionary<string, AudioEncodingQuality> AudioQualityDictionary = new Dictionary<string, AudioEncodingQuality>();
        private Dictionary<string, bool> IsMusicDictionary = new Dictionary<string, bool>();
        private Dictionary<string, bool> IsisM4ADictionary = new Dictionary<string, bool>();

        // Events
        // A delegate type for hooking up change download status.
        public delegate void DownloadStatusMessageEventHandler(string title, string msg);
        public event DownloadStatusMessageEventHandler DownloadStatusMessageChanged;

        // A delegate type for hooking up change download progress.
        public delegate void DownloadProgressEventHandler(string tag, double progress);
        public event DownloadProgressEventHandler DownloadProgressChanged;


        public BackgroundDownloaderHelper()
        {

        }


        /// <summary>
        /// Clears the temporary folder used to hold downloads that are currently pending.
        /// </summary>
        public async void ClearTemporaryFolder()
        {
            IReadOnlyList<StorageFile> folder = await ApplicationData.Current.TemporaryFolder.GetFilesAsync();
            foreach (StorageFile file in folder)
            {
                try
                {
                    await file.DeleteAsync(StorageDeleteOption.Default);
                }
                catch { }
            }
        }

        /// <summary>
        /// Gets the amount of pending downloads active currently
        /// </summary>
        /// <returns></returns>
        public int GetPendingDownloadsCount()
        {
            return activeDownloads.Count;
        }

        /// <summary>
        /// Releases resources
        /// </summary>
        private void Dispose()
        {
            if (cts != null)
            {
                cts.Cancel();
                cts.Dispose();
                cts = null;
                try
                {
                    ClearTemporaryFolder();
                }
                catch { }
            }

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Cancels all pending downloads and releases active resources
        /// </summary>
        private void CancelAllDownload()
        {
            Debug.WriteLine("Canceling Downloads: " + activeDownloads.Count);

            Dispose();
            try
            {
                ClearTemporaryFolder();
            }
            catch { }

            // Re-create the CancellationTokenSource and activeDownloads for future downloads.
            cts = new CancellationTokenSource();
            activeDownloads = new List<DownloadOperation>();
        }


        /// <summary>
        /// Enumerate the downloads that were going on in the background while the app was closed.
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task DiscoverActiveDownloadsAsync(bool cancel)
        {
            activeDownloads = new List<DownloadOperation>();

            IReadOnlyList<DownloadOperation> downloads = null;
            try
            {
                downloads = await BackgroundDownloader.GetCurrentDownloadsAsync();
            }
            catch (Exception ex)
            {
                if (!IsExceptionHandled("Discovery error", ex))
                {
                    throw;
                }
                return;
            }

            Debug.WriteLine("Loading background downloads: " + downloads.Count);

            if (downloads.Count > 0)
            {
                List<Task> tasks = new List<Task>();
                foreach (DownloadOperation download in downloads)
                {
                    Debug.WriteLine(String.Format(CultureInfo.CurrentCulture,
                        "Discovered background download: {0}, Status: {1}", download.Guid,
                        download.Progress.Status));

                    if (cancel)
                    {
                        download.AttachAsync().Cancel();
                    }
                    else
                    {
                        // Attach progress and completion handlers.
                        tasks.Add(HandleDownloadAsync(download, false));
                    }
                }

                // Don't await HandleDownloadAsync() in the foreach loop since we would attach to the second
                // download only when the first one completed; attach to the third download when the second one
                // completes etc. We want to attach to all downloads immediately.
                // If there are actions that need to be taken once downloads complete, await tasks here, outside
                // the loop.
                await Task.WhenAll(tasks);
            }
        }

        private bool IsExceptionHandled(string title, Exception ex, DownloadOperation download = null)
        {
            WebErrorStatus error = BackgroundTransferError.GetStatus(ex.HResult);
            if (error == WebErrorStatus.Unknown)
            {
                return false;
            }

            string errorMsg = null;
            if (download == null)
            {
                Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, "Error: {0}: {1}", title, error));

                errorMsg = String.Format(CultureInfo.CurrentCulture, "{0}: {1}", title, error);
            }
            else
            {
                Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, "Error: {0} - {1}: {2}", download.Guid, title, error));
                errorMsg = String.Format(CultureInfo.CurrentCulture, "{0} - {1}: {2}", download.Guid, title, error);
            }

            // Event calling for status msg
            DownloadStatusMessageChanged?.Invoke("Error", download.ResultFile.Name);

            return true;
        }

        public async void Download(string DownloadURL, string DestinationFileName, StorageFile destinationFile, AudioEncodingQuality AudioQuality, bool IsVideo, bool IsM4A)
        {
           
            try
            {
                // Temporary destination folder
                StorageFile tempDestinationFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(DestinationFileName, CreationCollisionOption.GenerateUniqueName);


                // Add the place where the user wants to save to a dictionary first. Our file will first be saved to a temp folder
                if (StorageFileDictionary.ContainsKey(tempDestinationFile.Name))
                    StorageFileDictionary.Remove(tempDestinationFile.Name);
                StorageFileDictionary.Add(tempDestinationFile.Name, destinationFile);

                // Add to audio encoding quality
                if (!IsVideo)
                {
                    if (AudioQualityDictionary.ContainsKey(tempDestinationFile.Name))
                        AudioQualityDictionary.Remove(tempDestinationFile.Name);
                    AudioQualityDictionary.Add(tempDestinationFile.Name, AudioQuality);
                }
                // Add to isMusicDictionary
                if (IsMusicDictionary.ContainsKey(tempDestinationFile.Name))
                    IsMusicDictionary.Remove(tempDestinationFile.Name);
                IsMusicDictionary.Add(tempDestinationFile.Name, !IsVideo);

                // Add to M4A dictionary, since Windows Phone doesnt support mp3
                if (IsisM4ADictionary.ContainsKey(tempDestinationFile.Name))
                    IsisM4ADictionary.Remove(tempDestinationFile.Name);
                IsisM4ADictionary.Add(tempDestinationFile.Name, IsM4A);

                // Create a new instance of background downloader
                BackgroundDownloader downloader = new BackgroundDownloader();

                Uri fileDownloadUri = new Uri(DownloadURL, UriKind.Absolute);
                DownloadOperation download = downloader.CreateDownload(fileDownloadUri, tempDestinationFile);
                download.Priority = BackgroundTransferPriority.High;

                Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, "Downloading {0} to {1} with {2} priority, {3}", fileDownloadUri.AbsoluteUri, DestinationFileName, download.Priority, download.Guid));


                List<DownloadOperation> requestOperations = new List<DownloadOperation>();
                requestOperations.Add(download);

                // If the app isn't actively being used, at some point the system may slow down or pause long running
                // downloads. The purpose of this behavior is to increase the device's battery life.
                // By requesting unconstrained downloads, the app can request the system to not suspend any of the
                // downloads in the list for power saving reasons.
                // Use this API with caution since it not only may reduce battery life, but it may show a prompt to
                // the user.
                UnconstrainedTransferRequestResult result;
                try
                {
                    result = await BackgroundDownloader.RequestUnconstrainedDownloadsAsync(requestOperations);
                }
                catch (NotImplementedException)
                {
                    Debug.WriteLine("BackgroundDownloader.RequestUnconstrainedDownloadsAsync is not supported in Windows Phone.");
                    return;
                }

                Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, "Request for unconstrained downloads has been {0}",
                    (result.IsUnconstrained ? "granted" : "denied")));

                await HandleDownloadAsync(download, true);
            }
            catch (Exception ex)
            {
                IsExceptionHandled("Download Error", ex);
            }
        }

        private async Task HandleDownloadAsync(DownloadOperation download, bool start)
        {
            try
            {
                Debug.WriteLine("Running: " + download.Guid);

                // Store the download so we can pause/resume.
                activeDownloads.Add(download);

                Progress<DownloadOperation> progressCallback = new Progress<DownloadOperation>(DownloadProgress);
                if (start) // Start the download and attach a progress handler.
                {
                    await download.StartAsync().AsTask(cts.Token, progressCallback);
                }
                else // The download was already running when the application started, re-attach the progress handler.
                {
                    await download.AttachAsync().AsTask(cts.Token, progressCallback);
                }

                ResponseInformation response = download.GetResponseInformation();

                Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, "Completed: {0}, Status Code: {1}", download.Guid, response.StatusCode));

                // Move the downloaded file from Temporary folder to the selected folder
                if (StorageFileDictionary.ContainsKey(download.ResultFile.Name))
                {
                    StorageFile file_selectedLocation = StorageFileDictionary[download.ResultFile.Name];

                    // convert item to mp3 first
                    if (IsMusicDictionary[download.ResultFile.Name])
                    {
                        Debug.WriteLine("Converting video to mp3: " + download.Guid);

                        // Others in [File]
                        string OriginalFileName = download.ResultFile.Name;
                        AudioEncodingQuality audioQuality = AudioQualityDictionary[download.ResultFile.Name];
                        bool ism4a = IsisM4ADictionary[download.ResultFile.Name];

                        IStorageFile result = null;
                        VideoMP3Transcoder extractor = new VideoMP3Transcoder(OriginalFileName, download.ResultFile, audioQuality, ism4a);
                        result = await Task.Run(async () =>
                            await extractor.ConvertToMP3()
                        );

                        Debug.WriteLine("Result: " + result != null);

                        try
                        {
                            await result.MoveAndReplaceAsync(file_selectedLocation);
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message.ToString());
                        }

                        if (result != null)
                        {
                            Debug.WriteLine("Done converting to mp3: " + download.Guid);
                        }
                        else
                        {
                            Debug.WriteLine("Error converting to mp3: " + download.Guid);
                        }
                    }
                    else
                    {
                        await download.ResultFile.MoveAndReplaceAsync(StorageFileDictionary[download.ResultFile.Name]);
                    }
                }
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("Canceled: " + download.Guid);
            }
            catch (Exception ex)
            {
                if (!IsExceptionHandled("Execution error", ex, download))
                {
                    throw;
                }
            }
            finally
            {
                activeDownloads.Remove(download);

                // Event calling for status msg
                DownloadStatusMessageChanged?.Invoke("Download complete", download.ResultFile.Name);
            }
        }

        // Note that this event is invoked on a background thread, so we cannot access the UI directly.
        private void DownloadProgress(DownloadOperation download)
        {
            Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, "Progress: {0}, Status: {1}", download.Guid, download.Progress.Status));

            double percent = 100;
            if (download.Progress.TotalBytesToReceive > 0)
            {
                percent = download.Progress.BytesReceived * 100 / download.Progress.TotalBytesToReceive;
            }
            Debug.WriteLine(String.Format(CultureInfo.CurrentCulture, " - Transfered bytes: {0} of {1}, {2}%", download.Progress.BytesReceived, download.Progress.TotalBytesToReceive, percent));

            DownloadProgressChanged?.Invoke(download.Guid.ToString(), percent);


            if (download.Progress.HasRestarted)
            {
                Debug.WriteLine(" - Download restarted");
            }
            if (download.Progress.HasResponseChanged)
            {
                // We've received new response headers from the server.
                Debug.WriteLine(" - Response updated; Header count: " + download.GetResponseInformation().Headers.Count);

                // If you want to stream the response data this is a good time to start.
                // download.GetResultStreamAt(0);
            }
        }
    }
}
