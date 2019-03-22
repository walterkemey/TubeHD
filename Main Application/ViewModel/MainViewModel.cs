using Google.Apis.Discovery;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
using PrimeTube.ViewModel;
using PrimeTube.YouTube;
using PrimeTube.Common;
using PrimeTube.YouTube.Json;
using Youtube_Music_Video_Downloader__W10_;

namespace PrimeTube.ViewModel
{
    public class MainViewModel : BindableBase
    {
        #region Subscription
        private IncrementalLoadingCollection<Subscription> _selfSubscriptionVideoCollection;
        public IncrementalLoadingCollection<Subscription> selfSubscriptionVideoCollection
        {
            get
            {
                return _selfSubscriptionVideoCollection;
            }
            set
            {
                this.SetProperty(ref this._selfSubscriptionVideoCollection, value);
            }
        }

        public async void LoadSubscriptions()
        {
            if (!ApplicationSetting.GetLocalSetting("google_is_loggedin", false))
            {
                return;
            }

            if (_selfSubscriptionVideoCollection != null)
            {
                _selfSubscriptionVideoCollection.Clear();
            }

            // Static global variable data to be referenced by the LoadMoreItems function
            string pagination = null;
            string firstpagination = null;

            bool isLoadComplete = false;

            // Function
            selfSubscriptionVideoCollection = new IncrementalLoadingCollection<Subscription>((CancellationToken cts, uint count) =>
            {
                return Task.Run<ObservableCollection<Subscription>>(async () =>
                {
                    ObservableCollection<Subscription> newcollection = new ObservableCollection<Subscription>();

                    if (!isLoadComplete)
                    {

                        string uri = string.Format("https://www.googleapis.com/youtube/v3/subscriptions?part={0}&mine={1}&maxResults={2}",
                            "contentDetails%2CsubscriberSnippet%2Csnippet",
                            "true",
                            50);
                        if (pagination != null)
                        {
                            uri += "&pageToken=" + pagination;
                        }

                        object obj = await YouTubeAuthenticatedAPI.RequestedAuthenticatedAPICall(uri, typeof(SubscriptionResultObject));
                        if (obj != null)
                        {
                            SubscriptionResultObject deserialize = (SubscriptionResultObject)obj;

                            if (pagination != null && firstpagination == pagination) // Is this the end? 
                            {
                                isLoadComplete = true;
                                return newcollection;
                            }
                            else
                            {
                                // Set pagination
                                pagination = deserialize.nextPageToken;

                                if (firstpagination == null)
                                {
                                    firstpagination = pagination; // no choice, we might load the first at the end again.. there's no pagination information for the first page
                                }

                                // Add to list of subscription videos
                                foreach (Subscription s in deserialize.items)
                                {
                                    newcollection.Add(s);
                                }
                            }
                        }

                        //var videoInfoRequest = YoutubeService.service.Subscriptions.List("contentDetails,id,snippet,subscriberSnippet");
                        /*    videoInfoRequest.RequestParameters.Add("access_token", 
                                new Parameter()
                                {
                                     Name = "access_token",
                                      DefaultValue = await ApplicationSetting.GetEncryptedLocalStringValueOrDefault("google_access_token", ""),
                                       IsRequired = true,
                                });*/
                        //videoInfoRequest.Mine = true;
                        //videoInfoRequest.OauthToken = await ApplicationSetting.GetEncryptedLocalStringValueOrDefault("google_authorization_token", "");

                        /*if (pagination != null)
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

                            foreach (Subscription t in videoResultResponse.Items)
                            {
                                newcollection.Add(t);
                            }
                        }
                        catch (Exception exp)
                        {
                            Debug.WriteLine(exp.ToString());
                        }*/
                    }
                    return newcollection;
                });
            });
            await selfSubscriptionVideoCollection.LoadMoreItemsAsync(10);
        }
        #endregion

        #region PopularVideos
        private ObservableCollection<Google.Apis.YouTube.v3.Data.Video> _popularVideos = new ObservableCollection<Google.Apis.YouTube.v3.Data.Video>();
        public ObservableCollection<Google.Apis.YouTube.v3.Data.Video> popularVideos
        {
            get { return _popularVideos; }
            set { this.SetProperty(ref this._popularVideos, value); }
        }

        private bool IsLoadingPopularVideo = false;
        /// <summary>
        /// Loads youtube popular video list 
        /// </summary>
        /// <param name="allowOverride"></param>
        /// <returns>false if no network is available</returns>
        public async Task<bool> LoadPopularVideos(bool allowOverride)
        {
            if (IsLoadingPopularVideo || (!allowOverride && _popularVideos.Count > 0))
                return true;

            IsLoadingPopularVideo = true;

            var videoInfoRequest = YoutubeService.service.Videos.List("snippet,statistics,id,status,recordingDetails,topicDetails");
            videoInfoRequest.Chart = Google.Apis.YouTube.v3.VideosResource.ListRequest.ChartEnum.MostPopular;
            videoInfoRequest.RegionCode = RegionInfo.CurrentRegion.TwoLetterISORegionName;
            videoInfoRequest.MaxResults = 50;

            try
            {
                var videoResultResponse = await videoInfoRequest.ExecuteAsync();

                if (videoResultResponse.Items.Count >= 0)
                {
                    IList<Google.Apis.YouTube.v3.Data.Video> videoNew = videoResultResponse.Items;

                    _popularVideos.Clear();
                    foreach (Google.Apis.YouTube.v3.Data.Video v in videoNew)
                    {
                        _popularVideos.Add(v);
                    }
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());

                if (exp.ToString().Contains("System.Net.Http.HttpRequestException"))
                {
                    return false;
                }
            }
            finally
            {
                IsLoadingPopularVideo = false;
            }
            return true;
        }
        #endregion
    }
}
