using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Popups;
using PrimeTube.YouTube;
using PrimeTube.Common;

namespace PrimeTube.ViewModel
{
    public class SearchViewModel : BindableBase
    {
        public ObservableCollection<SearchResult> _videos = new ObservableCollection<SearchResult>();
        public ObservableCollection<SearchResult> videos
        {
            get { return _videos; }
            set { this.SetProperty(ref this._videos, value); }
        }

        public ObservableCollection<SearchResult> _channels = new ObservableCollection<SearchResult>();
        public ObservableCollection<SearchResult> channels
        {
            get { return _channels; }
            set { this.SetProperty(ref this._channels, value); }
        }

        public ObservableCollection<SearchResult> _playlists = new ObservableCollection<SearchResult>();
        public ObservableCollection<SearchResult> playlists
        {
            get { return _playlists; }
            set { this.SetProperty(ref this._playlists, value); }
        }

        private bool IsLoadingSearchTerm = false;


        /// <summary>
        /// Loads youtube video/playlist & channels with the given search query
        /// </summary>
        /// <param name="keyterm"></param>
        /// <param name="paginationToken"></param>
        /// <returns>false if no network is available.</returns>
        public async Task<bool> SearchItems(string keyterm, string paginationToken)
        {
            if (IsLoadingSearchTerm)
            {
                return true;
            }
            IsLoadingSearchTerm = true;

            try
            {
                // Clear existing
                videos.Clear();
                channels.Clear();
                playlists.Clear();

                ObservableCollection<SearchResult> newcollection_videos = new ObservableCollection<SearchResult>();
                ObservableCollection<SearchResult> newcollection_playlists = new ObservableCollection<SearchResult>();
                ObservableCollection<SearchResult> newcollection_channels = new ObservableCollection<SearchResult>();

                string pagination = paginationToken;
                string firstpagination = null;

                // Optimizing, by having less results on mobile
                bool isMobile = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile";


                // Loop through 10 times to load this completely at least
                // due to YouTube's 50 result restriction
                for (int i = 0; i < 10; i++)
                {
                    var searchListRequest = YoutubeService.service.Search.List("snippet");
                    searchListRequest.Q = keyterm; // Replace with your search term.
                    searchListRequest.MaxResults = 50;
                    if (pagination != null)
                    {
                        searchListRequest.PageToken = pagination;
                    }
                    try
                    {
                        var searchListResponse = await searchListRequest.ExecuteAsync();

                        // Set new pagination
                        pagination = searchListResponse.NextPageToken;
                        if (firstpagination == null)
                        {
                            firstpagination = pagination; // no choice, we might load the first at the end again.. there's no pagination information for the first page
                        }
                        else if (firstpagination == pagination)
                        {
                            break;
                        }

                        // Add each result to the appropriate list, and then display the lists of
                        // matching videos, channels, and playlists.

                        foreach (SearchResult searchResult in searchListResponse.Items)
                        {
                            switch (searchResult.Id.Kind)
                            {
                                case "youtube#video":
                                    {
                                        if ((isMobile && newcollection_videos.Count < 50) || (!isMobile && newcollection_videos.Count < 100))
                                        {
                                            newcollection_videos.Add(searchResult);
                                        }
                                        break;
                                    }
                                case "youtube#channel":
                                    newcollection_channels.Add(searchResult);
                                    break;
                                case "youtube#playlist":
                                    newcollection_playlists.Add(searchResult);
                                    break;
                                default:
                                    Debug.WriteLine(searchResult.Id.Kind);
                                    break;
                            }
                        }
                        Debug.WriteLine("Loaded new items " + new Random().Next(999));
                    }
                    catch (Exception exp)
                    {
                        Debug.WriteLine(exp.ToString());

                        if (exp.ToString().Contains("System.Net.Http.HttpRequestException"))
                        {
                            return false;
                        }
                    }
                }
                newcollection_videos.AddTo(videos);
                newcollection_channels.AddTo(channels);
                newcollection_playlists.AddTo(playlists);
            }
            finally
            {
                IsLoadingSearchTerm = false;
            }
            return true;
        }

        /* public void SearchItems(string keyterm, string paginationToken)
         {
             // Clear existing
             videos.Clear();
             channels.Clear();
             playlists.Clear();
             _Search_Videos = null;

             // Static global variable data to be referenced by the LoadMoreItems function
             string pagination = paginationToken;
             string firstpagination = null;

             bool isLoadComplete = false;

             // Function
             IncrementalLoadingCollection<SearchResult> currentSearchObj = new IncrementalLoadingCollection<SearchResult>((CancellationToken cts, uint count) =>
             {
                 return Task.Run<ObservableCollection<SearchResult>>(async () =>
                 {
                     ObservableCollection<SearchResult> newcollection = new ObservableCollection<SearchResult>();

                     if (!isLoadComplete)
                     {
                         var searchListRequest = YoutubeService.service.Search.List("snippet");
                         searchListRequest.Q = keyterm; // Replace with your search term.
                         searchListRequest.MaxResults = 50;
                         if (pagination != null)
                         {
                             searchListRequest.PageToken = pagination;
                         }
                         try
                         {
                             var searchListResponse = await searchListRequest.ExecuteAsync();

                             // Set new pagination
                             pagination = searchListResponse.NextPageToken;
                             if (firstpagination == null)
                             {
                                 firstpagination = pagination; // no choice, we might load the first at the end again.. there's no pagination information for the first page
                             }
                             else if (firstpagination == pagination)
                             {
                                 isLoadComplete = true;
                                 return newcollection;
                             }

                             // Add each result to the appropriate list, and then display the lists of
                             // matching videos, channels, and playlists.
                             await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                                    () =>
                                    {
                                        foreach (SearchResult searchResult in searchListResponse.Items)
                                        {
                                            switch (searchResult.Id.Kind)
                                            {
                                                case "youtube#video":
                                                    videos.Add(searchResult);
                                                    newcollection.Add(searchResult);
                                                    break;
                                                case "youtube#channel":
                                                    channels.Add(searchResult);
                                                    break;
                                                case "youtube#playlist":
                                                    playlists.Add(searchResult);
                                                    break;
                                                default:
                                                    Debug.WriteLine(searchResult.Id.Kind);
                                                    break;
                                            }
                                        }
                                    });
                             Debug.WriteLine("Loaded new items " + new Random().Next(999));
                         }
                         catch (Exception exp)
                         {
                             Debug.WriteLine(exp.ToString());
                         }
                     }
                     return newcollection;
                 });
             });

             _Search_Videos = currentSearchObj;
             OnPropertyChanged("Search_Videos");
         }*/
    }
}