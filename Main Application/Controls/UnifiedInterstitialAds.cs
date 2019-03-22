
using AdDuplex.Interstitials.Models;
using Microsoft.Advertising.WinRT.UI;
using Microsoft.HockeyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;

namespace Youtube_Music_Video_Downloader__W10_.Controls
{
    public class UnifiedInterstitialAds
    {
        // Events
        public delegate void AdsEventHandler();
        public event AdsEventHandler Completed;
        public event AdsEventHandler Cancelled;


        // Etc
        private bool showAdsAutomatically = false;
        private string tags = string.Empty;
        

        /// <summary>
        /// Pubcenter interstitial ads
        /// </summary>
        private Microsoft.Advertising.WinRT.UI.InterstitialAd interstitialAd_pubcenter = new Microsoft.Advertising.WinRT.UI.InterstitialAd();

        /// <summary>
        /// Adduplex interstitial ads
        /// </summary>
        private AdDuplex.InterstitialAd interstitialAd_adduplex;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="showAdsAutomatically"></param>
        /// <param name="tags"></param>
        public UnifiedInterstitialAds(
            bool showAdsAutomatically,
            string tags)
        {
            this.showAdsAutomatically = showAdsAutomatically;
            this.tags = tags;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="AdduplexAdUnitId"></param>
        /// <param name="AdduplexSDKKey"></param>
        /// <param name="PubcenterApplicationId"></param>
        /// <param name="PubcenterSDKKey"></param>
        /// <param name="PubcenterMobileApplicationId"></param>
        /// <param name="PubcenterMobileSDKKey"></param>
        public async void Initialize(string AdduplexAdUnitId, string AdduplexSDKKey,
            string PubcenterApplicationId, string PubcenterSDKKey,
            string PubcenterMobileApplicationId, string PubcenterMobileSDKKey)
        {
            // Initialize pubcenter
            interstitialAd_pubcenter = new InterstitialAd();
            interstitialAd_pubcenter.AdReady += InterstitialAdMain_AdReady;
            interstitialAd_pubcenter.ErrorOccurred += InterstitialAdMain_ErrorOccurred;
            interstitialAd_pubcenter.Completed += InterstitialAdInterstitialAdMain_Completed;
            interstitialAd_pubcenter.Cancelled += InterstitialAdInterstitialAdMain_Cancelled;

            interstitialAd_pubcenter.Keywords = tags;
            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            {
                interstitialAd_pubcenter.RequestAd(Microsoft.Advertising.WinRT.UI.AdType.Video, PubcenterMobileApplicationId, PubcenterMobileSDKKey);
            }
            else
            {
                interstitialAd_pubcenter.RequestAd(Microsoft.Advertising.WinRT.UI.AdType.Video, PubcenterApplicationId, PubcenterSDKKey);
            }

            // Initialize Adduplex
            AdDuplex.AdDuplexClient.Initialize(AdduplexSDKKey);
            interstitialAd_adduplex = new AdDuplex.InterstitialAd(AdduplexAdUnitId);

            interstitialAd_adduplex.NoAd += InterstitialAd_adduplex_NoAd;
            interstitialAd_adduplex.AdClicked += InterstitialAd_adduplex_AdClicked;
            interstitialAd_adduplex.AdClosed += InterstitialAd_adduplex_AdClosed;
            interstitialAd_adduplex.AdLoadingError += InterstitialAd_adduplex_AdLoadingError;

            InterstitialAdInfo info = await interstitialAd_adduplex.LoadAdAsync();

            // Events
            HockeyClient.Current.TrackEvent("Ads requested");
        }

        #region Pubcenter
        private void InterstitialAdInterstitialAdMain_Cancelled(object sender, object e)
        {
            // Events
            HockeyClient.Current.TrackEvent("Ads cancelled");

            Cancelled?.Invoke();
        }

        private void InterstitialAdInterstitialAdMain_Completed(object sender, object e)
        {
            Completed?.Invoke();

            // Events
            HockeyClient.Current.TrackEvent("Ads completed");
        }

        private async void InterstitialAdMain_ErrorOccurred(object sender, AdErrorEventArgs e)
        {
            // Events
            HockeyClient.Current.TrackEvent("Ads error " + e.ErrorMessage);

            if (showAdsAutomatically) // try adduplex
            {
                if (AdDuplex.AdDuplexClient.Status == AdDuplex.AdDuplexInitializationStatus.INITIALIZED)
                {
                    InterstitialAdInfo info = await interstitialAd_adduplex.ShowAdAsync();
                }
               // info.
            }
        }

        private void InterstitialAdMain_AdReady(object sender, object e)
        {
            
            if (showAdsAutomatically)
            {
                interstitialAd_pubcenter.Show();
            }


            // Events
            HockeyClient.Current.TrackEvent("Ads ready");
        }
        #endregion

        #region Adduplex
        private void InterstitialAd_adduplex_AdLoadingError(object sender, AdDuplex.Common.Models.AdLoadingErrorEventArgs e)
        {
            HockeyClient.Current.TrackEvent("Adduplex ads error " + e.Error.Message);
        }

        private void InterstitialAd_adduplex_AdClosed(object sender, InterstitialAdLoadedEventArgs e)
        {
            HockeyClient.Current.TrackEvent("Adduplex Ads cancelled");

            Cancelled?.Invoke();
        }

        private void InterstitialAd_adduplex_AdClicked(object sender, InterstitialAdClickEventArgs e)
        {
            HockeyClient.Current.TrackEvent("Adduplex Ads clicked");

            Completed?.Invoke();
        }

        private void InterstitialAd_adduplex_NoAd(object sender, AdDuplex.Common.Models.NoAdEventArgs e)
        {
            HockeyClient.Current.TrackEvent("Adduplex Ads not available");
        }
        #endregion



        public async Task<bool> ShowAdsIfAvailable()
        {
            if (interstitialAd_pubcenter.State == InterstitialAdState.Ready)
            {
                interstitialAd_pubcenter.Show();
                return true;
            } else
            {
                if (AdDuplex.AdDuplexClient.Status == AdDuplex.AdDuplexInitializationStatus.INITIALIZED)
                {
                    InterstitialAdInfo info = await interstitialAd_adduplex.ShowAdAsync();
                    if (info != null && info.Hash != null && info.Hash != string.Empty)
                        return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Cleanup
        /// </summary>
        public void Destroy()
        {
            if (interstitialAd_pubcenter != null)
            {
                interstitialAd_pubcenter.AdReady -= InterstitialAdMain_AdReady;
                interstitialAd_pubcenter.ErrorOccurred -= InterstitialAdMain_ErrorOccurred;
                interstitialAd_pubcenter.Completed -= InterstitialAdInterstitialAdMain_Completed;
                interstitialAd_pubcenter.Cancelled -= InterstitialAdInterstitialAdMain_Cancelled;

                interstitialAd_pubcenter = null;
            }
            if (interstitialAd_adduplex != null)
            {
                interstitialAd_adduplex = null;
            }
        }
    }
}
