using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Media.MediaProperties;
using Windows.Media.Transcoding;
using Windows.Storage;

namespace PrimeTube.Helper
{
    public class VideoMP3Transcoder
    {
        public string destination;
        public IStorageFile file;

        private bool isM4A;
        public MediaTranscoder mediatranscoder;
        public CancellationToken canceltoken;
        private AudioEncodingQuality quality;

        public VideoMP3Transcoder(string _destination, IStorageFile _file, AudioEncodingQuality _quality, bool _isM4A)
        {
            destination = _destination;
            file = _file;
            quality = _quality;
            isM4A = _isM4A;
        }

        public async Task<StorageFile> ConvertToMP3()
        {
            bool SuccessFlag = true;
            try
            {
                StorageFolder folder = await ApplicationData.Current.TemporaryFolder.CreateFolderAsync("Conversion", CreationCollisionOption.OpenIfExists);
                StorageFile destinationFile = await folder.CreateFileAsync(destination, CreationCollisionOption.GenerateUniqueName);

                if (SuccessFlag)
                {
                    mediatranscoder = new MediaTranscoder();
                    PrepareTranscodeResult transcoderesult = await mediatranscoder.PrepareFileTranscodeAsync(file, destinationFile, isM4A ? MediaEncodingProfile.CreateM4a(quality) : MediaEncodingProfile.CreateMp3(quality));
                    if (transcoderesult.CanTranscode)
                    {
                        canceltoken = new CancellationToken();
                        await transcoderesult.TranscodeAsync();

                        SuccessFlag = true;
                    }
                    else
                        SuccessFlag = false;
                }

                if (SuccessFlag)
                    return destinationFile;
                else
                    return null;
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee.ToString());
            }
            return null;
        }
    }
}
