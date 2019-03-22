using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PrimeTube.Helper;
using PrimeTube.YouTube;
using PrimeTube.YouTubeHelper;
using System.Linq;
using Windows.Storage;
using Google.Apis.YouTube.v3.Data;
using System.Threading;
using Jint;
using Jint.Native;
using PrimeTube.Common;
using PrimeTube.Util;
using PrimeTube.APIs;
using PrimeTube.Buffer;
using PrimeTube.YouTube.Json;
using YouTubeStreamAPI;

namespace PrimeTube.ViewModel
{
    public class VideoViewModel : BindableBase
    {
        private string _videoId = "";
        public VideoViewModel()
        {
        }

        public string VideoId
        {
            get { return _videoId; }
            set { this._videoId = value; }
        }

        // //////////////////////////////////// Video general info
        #region General
        private Google.Apis.YouTube.v3.Data.Video _video;
        public Google.Apis.YouTube.v3.Data.Video video
        {
            get { return _video; }
            set { this.SetProperty(ref this._video, value); }
        }

        private bool IsLoadingSearchTerm = false;
        public async void SearchSingleVideo(string videoid)
        {
            if (IsLoadingSearchTerm)
                return;
            IsLoadingSearchTerm = true;

            var videoInfoRequest = YoutubeService.service.Videos.List("snippet,statistics,id,status,recordingDetails,topicDetails");
            videoInfoRequest.Id = videoid;

            try
            {
                var videoResultResponse = await videoInfoRequest.ExecuteAsync();

                if (videoResultResponse.Items.Count >= 0)
                {
                    Google.Apis.YouTube.v3.Data.Video videoNew = videoResultResponse.Items[0];

                    video = videoNew;
                }
            }
            catch { }
            IsLoadingSearchTerm = false;
        }
        #endregion

        #region RelatedVideos
        private IncrementalLoadingCollection<SearchResult> _relatedVideoSearchCollection;
        public IncrementalLoadingCollection<SearchResult> relatedVideoSearchCollection
        {
            get { return _relatedVideoSearchCollection; }
            set { this.SetProperty(ref this._relatedVideoSearchCollection, value); }
        }

        public void LoadRelatedVideo(string related_videoid, string videotitle)
        {
            if (_relatedVideoSearchCollection != null)
            {
                _relatedVideoSearchCollection.Clear();
            }

            // Static global variable data to be referenced by the LoadMoreItems function
            string pagination = null;
            string firstpagination = null;

            bool isLoadComplete = false;

            // Function
            relatedVideoSearchCollection = new IncrementalLoadingCollection<SearchResult>((CancellationToken cts, uint count) =>
            {
                return Task.Run<ObservableCollection<SearchResult>>(async () =>
                {
                    ObservableCollection<SearchResult> newcollection = new ObservableCollection<SearchResult>();

                    if (!isLoadComplete)
                    {
                        var videoInfoRequest = YoutubeService.service.Search.List("snippet");
                        //       videoInfoRequest.Q = videotitle;
                        videoInfoRequest.Type = "video";
                        videoInfoRequest.RelatedToVideoId = related_videoid;

                        if (pagination != null)
                        {
                            videoInfoRequest.PageToken = pagination;
                        }

                        try
                        {
                            var videoResultResponse = await videoInfoRequest.ExecuteAsync();

                            // Set new pagination
                            pagination = videoResultResponse.NextPageToken;
                            if (firstpagination == null)
                            {
                                firstpagination = pagination; // no choice, we might load the first at the end again.. there's no pagination information for the first page
                            }
                            else if (firstpagination == pagination)
                            {
                                isLoadComplete = true;
                                return newcollection;
                            }

                            foreach (SearchResult t in videoResultResponse.Items)
                            {
                                newcollection.Add(t);
                            }
                        }
                        catch (Exception exp)
                        {
                            Debug.WriteLine(exp.ToString());
                        }
                    }
                    return newcollection;
                });
            });
        }
        #endregion

        #region Comments
        private CommentThreadListResponse _commentThreadListResponse;
        public CommentThreadListResponse commentThreadListResponse
        {
            get { return _commentThreadListResponse; }
            set { this.SetProperty(ref this._commentThreadListResponse, value); }
        }

        private IncrementalLoadingCollection<CommentThread> _commentThreadCollection;
        public IncrementalLoadingCollection<CommentThread> commentCollection
        {
            get { return _commentThreadCollection; }
            set { this.SetProperty(ref this._commentThreadCollection, value); }
        }

        public void LoadComments(string videoid)
        {
            if (_commentThreadCollection != null)
            {
                _commentThreadCollection.Clear();
            }

            // Static global variable data to be referenced by the LoadMoreItems function
            string pagination = null;
            string firstpagination = null;

            bool isLoadComplete = false;

            // Function
            commentCollection = new IncrementalLoadingCollection<CommentThread>((CancellationToken cts, uint count) =>
            {
                return Task.Run<ObservableCollection<CommentThread>>(async () =>
                {
                    ObservableCollection<CommentThread> newcollection = new ObservableCollection<CommentThread>();

                    if (!isLoadComplete)
                    {
                        var videoInfoRequest = YoutubeService.service.CommentThreads.List("snippet,replies");
                        videoInfoRequest.VideoId = videoid;
                        videoInfoRequest.TextFormat = Google.Apis.YouTube.v3.CommentThreadsResource.ListRequest.TextFormatEnum.PlainText;
                        videoInfoRequest.MaxResults = 50;
                        if (pagination != null)
                        {
                            videoInfoRequest.PageToken = pagination;
                        }

                        try
                        {
                            var videoResultResponse = await videoInfoRequest.ExecuteAsync();

                            // Set new pagination
                            pagination = videoResultResponse.NextPageToken;
                            if (firstpagination == null)
                            {
                                firstpagination = pagination; // no choice, we might load the first at the end again.. there's no pagination information for the first page
                            }
                            else if (firstpagination == pagination)
                            {
                                isLoadComplete = true;
                                return newcollection;
                            }

                            foreach (CommentThread t in videoResultResponse.Items)
                            {
                                newcollection.Add(t);
                            }
                        }
                        catch (Exception exp)
                        {
                            Debug.WriteLine(exp.ToString());
                        }
                    }
                    return newcollection;
                });
            });
        }
        #endregion

        #region VideoPlaylist
        private bool _IsPlaylist = false;
        public bool IsPlaylist
        {
            get { return _IsPlaylist; }
            set { this.SetProperty(ref this._IsPlaylist, value); }
        }

        private PlaylistItemListResponse _PlaylistItemResponse = null;
        public PlaylistItemListResponse PlaylistItemResponse
        {
            get { return _PlaylistItemResponse; }
            set { this.SetProperty(ref this._PlaylistItemResponse, value); }
        }

        public SearchResult _PlaylistSearchResult = null;
        public SearchResult PlaylistSearchResult
        {
            get { return _PlaylistSearchResult; }
            set { this.SetProperty(ref this._PlaylistSearchResult, value); }
        }
        public ObservableCollection<PlaylistItem> _PlaylistItems = new ObservableCollection<PlaylistItem>();
        public ObservableCollection<PlaylistItem> PlaylistItems
        {
            get { return _PlaylistItems; }
            set
            {
                this.SetProperty(ref this._PlaylistItems, value);
            }
        }
        private int _PlaylistItemsCount = 0;
        public int PlaylistItemsCount
        {
            get { return _PlaylistItems.Count; }
            set { this.SetProperty(ref this._PlaylistItemsCount, value); }
        }
        private int _PlaylistIndex = 0;
        public int PlaylistIndex
        {
            get { return _PlaylistIndex; }
            set { this.SetProperty(ref this._PlaylistIndex, value); }
        }

        public async Task LoadPlaylist(SearchResult playlistid)
        {
            if (playlistid == null)
            {
                IsPlaylist = false;
                PlaylistItemResponse = null;
                PlaylistSearchResult = null;
            }
            else
            {
                IsPlaylist = true;
                PlaylistSearchResult = playlistid;

                await LoadPlaylistInfoInternal(playlistid.Id.PlaylistId);
            }
        }

        private async Task LoadPlaylistInfoInternal(string playlistid)
        {
            PlaylistItems.Clear();

            string pagination = null;
            string firstpagination = null;

            // Loop through 4 times to load this completely at least
            // due to YouTube's 50 result restriction
            // Max playlist restriction = 200 video anyway
            for (int i = 0; i < 4; i++)
            {
                IList<Google.Apis.YouTube.v3.Data.PlaylistItem> collection = null;

                // Load playlist
                var videoInfoRequest = YoutubeService.service.PlaylistItems.List("contentDetails,id,status,snippet");
                videoInfoRequest.PlaylistId = playlistid;
                videoInfoRequest.MaxResults = 50;
                if (pagination != null)
                {
                    videoInfoRequest.PageToken = pagination;
                }
                try
                {
                    var videoResultResponse = await videoInfoRequest.ExecuteAsync();

                    // Set new pagination
                    pagination = videoResultResponse.NextPageToken;
                    if (firstpagination == null)
                    {
                        firstpagination = pagination; // no choice, we might load the first at the end again.. there's no pagination information for the first page
                    }
                    else if (firstpagination == pagination)
                    {
                        break;
                    }

                    collection = videoResultResponse.Items;
                }
                catch { }

                // Add it to new collection
                if (collection != null)
                {
                    foreach (Google.Apis.YouTube.v3.Data.PlaylistItem item in collection)
                    {
                        //  item.Snippet.ur
                        PlaylistItems.Add(item);
                    }

                }
            }
            // Update playlist item count
            PlaylistItemsCount = _PlaylistItems.Count;
        }
        #endregion

        #region LikeVideo
        public async Task<bool> LikeVideo(bool like)
        {
            string uri = string.Format("https://www.googleapis.com/youtube/v3/subscriptions?part={0}&mine={1}&maxResults={2}",
                "contentDetails%2CsubscriberSnippet%2Csnippet",
                "true");

            object obj = await YouTubeAuthenticatedAPI.RequestedAuthenticatedAPICall(uri, typeof(SubscriptionResultObject));
            if (obj != null)
            {
                SubscriptionResultObject deserialize = (SubscriptionResultObject)obj;

            }
            return false;
        }
        #endregion

        #region StreamPTubeAPI
        private bool IsLoadingVideoStream_RemoteServer = false;
        public async Task<bool> LoadVideoStreamFromRemoteServer()
        {
            if (IsLoadingVideoStream_RemoteServer)
                return true;
            IsLoadingVideoStream_RemoteServer = true;

            try
            {
                // clear etc
                Stream.VideoInfo.Clear();
                Stream.VideoInfo_adaptive_fmts.Clear();

                long nonce = DateTimeUtility.CurrentTimeMillis();
                byte[] ret = await PrimeTubeAPIs.GetVideoList(string.Format("https://www.youtube.com/watch?v={0}", _videoId), nonce);
                if (ret != null)
                {
                    char[] encryptionKey = CustomXorEncryption.GenerateKey(nonce);

                    PacketReader reader = new PacketReader(ret);
                    bool haveVideoInfo = reader.ReadBool();

                    if (!haveVideoInfo)
                        return false;
                    string videoTitle = CustomXorEncryption.EncryptContent(reader.ReadString(), encryptionKey);
                    int numVideoURLs = reader.ReadInt();

                    for (int i = 0; i < numVideoURLs; i++)
                    {
                        string fullURL = CustomXorEncryption.EncryptContent(reader.ReadString(), encryptionKey); // full url

                        VideoType videotype = VideoType.NULL;
                        switch (CustomXorEncryption.EncryptContent(reader.ReadString(), encryptionKey)) // container
                        {
                            case "FLV":
                                videotype = VideoType.video_x_flv;
                                break;
                            case "GP3":
                                videotype = VideoType.video_3gpp;
                                break;
                            case "MP4":
                                videotype = VideoType.video_mp4;
                                break;
                            case "WEBM":
                                videotype = VideoType.video_webm;
                                break;
                        }

                        int type = reader.ReadByte() & 0xFF;

                        switch (type)
                        {
                            case 1: // Audio
                                {
                                    string audio = CustomXorEncryption.EncryptContent(reader.ReadString(), encryptionKey);
                                    string aq = CustomXorEncryption.EncryptContent(reader.ReadString(), encryptionKey);

                                    Stream.VideoInfo.Add(new VideoInformation(fullURL, VideoType.audio_mp4, "", "", "", VideoQuality.NULL));
                                    break;
                                }
                            case 2: // Video
                                {
                                    string video = CustomXorEncryption.EncryptContent(reader.ReadString(), encryptionKey);
                                    string vq = CustomXorEncryption.EncryptContent(reader.ReadString(), encryptionKey);

                                    Stream.VideoInfo.Add(new VideoInformation(fullURL, videotype, "", "", "", VideoQuality.hd720));
                                    break;
                                }
                            case 3: // Combined
                                {
                                    string video = CustomXorEncryption.EncryptContent(reader.ReadString(), encryptionKey);
                                    string vq = CustomXorEncryption.EncryptContent(reader.ReadString(), encryptionKey);
                                    string audio = CustomXorEncryption.EncryptContent(reader.ReadString(), encryptionKey);
                                    string aq = CustomXorEncryption.EncryptContent(reader.ReadString(), encryptionKey);

                                    Stream.VideoInfo.Add(new VideoInformation(fullURL, videotype, "", "", "", VideoQuality.hd720));
                                    break;
                                }
                            default:
                                break;
                        }
                    }

                    return true;
                }
            }
            catch (Exception exp)
            {
                return false;
            }
            finally
            {
                IsLoadingVideoStream_RemoteServer = false;
            }
            return false;
        }

        private VideoQuality GetVideoQualityFromString(string str)
        {
            VideoQuality quality = VideoQuality.NULL;

            switch (str)
            {
                case "p3072":
                case "p2304":
                case "p2160":
                case "p1440":
                case "p1080":
                case "p720":
                case "p520":
                case "p480":
                case "p360":
                case "p270":
                case "p240":
                case "p224":
                case "p144":
                    break;
            }
            return quality;
        }
        #endregion

        #region Streams
        private YouTubeStream _Stream = new YouTubeStream("");

        public YouTubeStream Stream
        {
            get { return _Stream; }
            private set { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="videoid"></param>
        /// <returns>string empty if everything's fine. Otherwise the error code</returns>
        public async Task<string> LoadVideoStreamData(string videoid)
        {
            YouTubeStream stream = new YouTubeStream(videoid);
            _Stream = stream;

            return await stream.LoadVideoStreamData();
        }
        #endregion

        #region Channels
        private Google.Apis.YouTube.v3.Data.Channel _channel;
        public Google.Apis.YouTube.v3.Data.Channel channel
        {
            get { return _channel; }
            set { this.SetProperty(ref this._channel, value); }
        }


        private bool IsLoadingChannelDetail = false;
        public async void LoadVideoChannelDetail(string channelid)
        {
            if (IsLoadingChannelDetail)
            {
                return;
            }
            IsLoadingChannelDetail = true;

            var videoInfoRequest = YoutubeService.service.Channels.List("id,snippet,contentDetails,statistics,topicDetails,invideoPromotion");
            videoInfoRequest.Id = channelid;

            try
            {
                var videoResultResponse = await videoInfoRequest.ExecuteAsync();

                if (videoResultResponse.Items.Count >= 0)
                {
                    Google.Apis.YouTube.v3.Data.Channel videoNew = videoResultResponse.Items[0];

                    channel = videoNew;
                }
            }
            catch { }
            IsLoadingChannelDetail = false;
        }
        #endregion

        #region NextVideoUI
        private bool _NextVideoUIVisible = false;
        public bool NextVideoUIVisible
        {
            get { return _NextVideoUIVisible; }
            set { this.SetProperty(ref this._NextVideoUIVisible, value); }
        }

        private string _NextVideoName = string.Empty;
        public string NextVideoName
        {
            get { return _NextVideoName; }
            set { this.SetProperty(ref this._NextVideoName, value); }
        }

        private SearchResult _NextVideoResult = null;
        public SearchResult NextVideoResult
        {
            get { return _NextVideoResult; }
            set { this.SetProperty(ref this._NextVideoResult, value); }
        }
        #endregion
    }
}
