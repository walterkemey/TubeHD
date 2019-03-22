using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PrimeTube.YouTube;
using PrimeTube.Common;

namespace PrimeTube.ViewModel
{
    public class ChannelViewModel : BindableBase
    {
        public ChannelViewModel()
        {
        }

        #region ChannelSections
        private Google.Apis.YouTube.v3.Data.ChannelSection _channelSection;
        public Google.Apis.YouTube.v3.Data.ChannelSection channelSection
        {
            get { return _channelSection; }
            set { this.SetProperty(ref this._channelSection, value); }
        }

        private bool IsLoadingChannelSections = false;
        public async Task LoadChannelSections(string channelid, bool isself)
        {
            if (IsLoadingChannelSections)
                return;
            IsLoadingChannelSections = true;

            //https://developers.google.com/youtube/v3/docs/channelSections/list#try-it
            var videoInfoRequest = YoutubeService.service.ChannelSections.List("contentDetails,id,snippet");
            videoInfoRequest.Id = channelid;

            try
            {
                var videoResultResponse = await videoInfoRequest.ExecuteAsync();

                if (videoResultResponse.Items.Count >= 0)
                {
                    Google.Apis.YouTube.v3.Data.ChannelSection videoNew = videoResultResponse.Items[0];

                    channelSection = videoNew;
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
            }
            IsLoadingChannelSections = false;
        }
        #endregion

        #region ChannelGeneral
        private Google.Apis.YouTube.v3.Data.Channel _channel;
        public Google.Apis.YouTube.v3.Data.Channel channel
        {
            get { return _channel; }
            set { this.SetProperty(ref this._channel, value); }
        }


        private bool IsLoadingChannel = false;
        public async Task LoadChannel(string channelid, bool isself)
        {
            if (IsLoadingChannel)
                return;
            IsLoadingChannel = true;

            try
            {
                var videoInfoRequest = YoutubeService.service.Channels.List("topicDetails,status,statistics,snippet,id,contentOwnerDetails,contentDetails,brandingSettings");
                videoInfoRequest.Id = channelid;
                // videoInfoRequest.Mine = isself;

                try
                {
                    var videoResultResponse = await videoInfoRequest.ExecuteAsync();

                    if (videoResultResponse.Items.Count >= 0)
                    {
                        Google.Apis.YouTube.v3.Data.Channel videoNew = videoResultResponse.Items[0];

                        channel = videoNew;
                    }
                }
                catch (Exception exp)
                {
                    Debug.WriteLine(exp.ToString());
                }
            }
            finally
            {
                IsLoadingChannel = false;
            }
        }
        #endregion

        #region ChannelVideos
        private string currentPlaylistChannelid = string.Empty;
        private Dictionary<PlaylistType, IncrementalLoadingCollection<Google.Apis.YouTube.v3.Data.PlaylistItem>> _Playlist = new Dictionary<PlaylistType, IncrementalLoadingCollection<Google.Apis.YouTube.v3.Data.PlaylistItem>>();


        public IncrementalLoadingCollection<Google.Apis.YouTube.v3.Data.PlaylistItem> Playlist_Uploads
        {
            get
            {
                if (!_Playlist.ContainsKey(PlaylistType.Uploads))
                {
                    return null;
                }
                return _Playlist[PlaylistType.Uploads];
            }
            set
            {
            }
        }
        public IncrementalLoadingCollection<Google.Apis.YouTube.v3.Data.PlaylistItem> Playlist_Likes
        {
            get
            {
                if (!_Playlist.ContainsKey(PlaylistType.Likes))
                {
                    return null;
                }
                return _Playlist[PlaylistType.Likes];
            }
            set
            {
            }
        }
        public IncrementalLoadingCollection<Google.Apis.YouTube.v3.Data.PlaylistItem> Playlist_Favourites
        {
            get
            {
                if (!_Playlist.ContainsKey(PlaylistType.Favourites))
                {
                    return null;
                }
                return _Playlist[PlaylistType.Favourites];
            }
            set { }
        }
        public IncrementalLoadingCollection<Google.Apis.YouTube.v3.Data.PlaylistItem> Playlist_Custom
        {
            get
            {
                if (!_Playlist.ContainsKey(PlaylistType.Custom))
                {
                    return null;
                }
                return _Playlist[PlaylistType.Custom];
            }
            set { }
        }

        public void LoadPlaylist(string channelid, string playlistid, PlaylistType type, string paginationToken)
        {
            if (currentPlaylistChannelid != channelid)
            {
                _Playlist.Clear();
            }

            if (!_Playlist.ContainsKey(type))
            {
                // Static global variable data to be referenced by the LoadMoreItems function
                string pagination = paginationToken;
                string firstpagination = null;

                bool isLoadComplete = false;

                // Function
                IncrementalLoadingCollection<Google.Apis.YouTube.v3.Data.PlaylistItem> currentPlaylistArrayObj = new IncrementalLoadingCollection<Google.Apis.YouTube.v3.Data.PlaylistItem>((CancellationToken cts, uint count) =>
                {
                    return Task.Run<ObservableCollection<Google.Apis.YouTube.v3.Data.PlaylistItem>>(async () =>
                    {
                        ObservableCollection<Google.Apis.YouTube.v3.Data.PlaylistItem> newcollection = new ObservableCollection<Google.Apis.YouTube.v3.Data.PlaylistItem>();

                        if (!isLoadComplete)
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
                                    isLoadComplete = true;
                                    return newcollection;
                                }

                                collection = videoResultResponse.Items;
                            }
                            catch { }

                            // Add it to new collection
                            if (collection != null)
                            {

                                foreach (Google.Apis.YouTube.v3.Data.PlaylistItem item in collection)
                                {
                                    newcollection.Add(item);
                                }

                            }
                        }
                        Debug.WriteLine("Loaded new items " + new Random().Next(999));

                        return newcollection;
                    });
                });

                _Playlist.Add(type, currentPlaylistArrayObj);
                this.OnPropertyChanged("Playlist_" + type.ToString());
            }
        }

        public enum PlaylistType
        {
            Uploads,
            Favourites,
            Likes,
            Custom
        }
        #endregion
    }
}
