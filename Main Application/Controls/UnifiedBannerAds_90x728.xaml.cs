using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//using com.vmax.windows.ads.wp10;
//using com.vmax.windows.ads;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PrimeTube.Controls
{
    public sealed partial class UnifiedBannerAds_90x728 : UserControl
    {
        // ///// Constants
        private const int AdHeight = 90;
        private const int AdWidth = 728;
        private const int RefreshInterval_Pubcenter = 20;
        private const int RefreshInterval_Adduplex = 15;


        // ///// Ad Constants
        // Pubcenter
        private const string PubCenterAppId = "9p67k5d1j9nx";
        private string[] PubCenterAdUnitId = new string[] { "1100042013", "1100042013", "1100042013" };

        // Adduplex
        private const string AdduplexAdId = "214203";//banner
        private const string AdduplexAppKey = "f64c6c77-b641-426f-ba9c-e8c5b258d8d0";


        // //// References
        private Dictionary<AdNetworkEnum, long> DisabledNetwork = new Dictionary<AdNetworkEnum, long>();
 
        public UnifiedBannerAds_90x728()
        {
            this.InitializeComponent();

            RefreshNewAdSet();
        }

        private void RefreshNewAdSet()
        {
            /*   if (leadbolt_controller != null)
               {
                   try
                   {
                       leadbolt_controller.DestroyAd();
                   }
                   catch { }
                   leadbolt_controller = null;
               }*/

            UIElementCollection collection = Grid_Ads.Children;
            foreach (UIElement ui in collection)
            {
                Type type = ui.GetType();
                if (type != typeof(Grid))
                {
                    Grid_Ads.Children.Remove(ui);
                }
            }

            AdNetworkEnum network = AdNetworkEnum.None;
            bool Selected = false;
            while (!Selected)
            {
                int rand = new Random().Next(100);

                if (rand < 80)//60)
                {
                    network = AdNetworkEnum.Microsoft_Pubcenter;
                }
                /*   else if (rand < 80)
                   {
                       network = AdNetworkEnum.LeadBolt;
                       if (network == AdNetworkEnum.LeadBolt)
                       {
                           Grid_Ads.Width = 300;
                           Grid_Ads.Height = 500;
                       }
                       else
                       {
                           Grid_Ads.Width = 160;
                           Grid_Ads.Height = 600;
                       }
                   }*/
                else if (rand < 200)
                {
                    network = AdNetworkEnum.AdDuplex;
                }
                // else
                // {
                //     network = AdNetworkEnum.InMobi;
                //  }

                if (DisabledNetwork.ContainsKey(network))
                {
                    if (DateTime.Now.Ticks - DisabledNetwork[network] < 5 * TimeSpan.TicksPerSecond)
                    {
                        continue;
                    }
                    else
                    {
                        DisabledNetwork[network] = DateTime.Now.Ticks;
                        Selected = true;
                    }
                }
                else
                {
                    DisabledNetwork.Add(network, DateTime.Now.Ticks);
                    Selected = true;
                }
            }
            Debug.WriteLine("Refreshing ad to: " + network.ToString());


            switch (network)
            { 
                case AdNetworkEnum.AdDuplex:
                    {
                        AdDuplex.AdControl adDuplexAd = LoadNewAdduplexAds();
                        Grid_Ads.Children.Add(adDuplexAd);
                        break;
                    }
                case AdNetworkEnum.InMobi:
                    {
                        /*IMAdView inMobiAd = InitializeInmobi();
                        Grid_Ads.Children.Add(inMobiAd);

                        inMobiAd.LoadNewAd();*/
                        break;
                    }
            /*    case AdNetworkEnum.Vmax:
                    {
                        VMAXAdView adView = new VMAXAdView();
                        adView.AdspotId = "2b31e0a3";
                        adView.UX = AdUX.Banner;
                        Grid_Ads.Children.Add(adView);
                        break;
                    }*/
                case AdNetworkEnum.Microsoft_Pubcenter:
                    {
                        Microsoft.Advertising.WinRT.UI.AdControl pubcenterAd = LoadNewPubCenterAds();
                        Grid_Ads.Children.Add(pubcenterAd);

                        pubcenterAd.Refresh();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }


        }

        private void ScheduleRefresh(int interval)
        {
            // until this fails
            Task.Run(async () =>
            {
                // await 30 seconds
                await Task.Delay(TimeSpan.FromSeconds(interval));

                // try refreshing a new ad
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, (() =>
                {
                    RefreshNewAdSet();
                }));
            });
        }

        #region PubCenter
        private Microsoft.Advertising.WinRT.UI.AdControl LoadNewPubCenterAds()
        {
            Microsoft.Advertising.WinRT.UI.AdControl PubCenterAds = new Microsoft.Advertising.WinRT.UI.AdControl();

            PubCenterAds.Height = AdHeight;
            PubCenterAds.Width = AdWidth;

            PubCenterAds.ApplicationId = PubCenterAppId;
            PubCenterAds.AdUnitId = PubCenterAdUnitId[new Random().Next(PubCenterAdUnitId.Length)];
            PubCenterAds.ErrorOccurred += ad_PubCenter_ErrorOccurred;
            PubCenterAds.AdRefreshed += ad_PubCenter_AdRefreshed;
            PubCenterAds.IsAutoRefreshEnabled = false;


            return PubCenterAds;
        }

        private void ad_PubCenter_ErrorOccurred(object sender, Microsoft.Advertising.WinRT.UI.AdErrorEventArgs e)
        {
            Debug.WriteLine("Pubcenter: " + e.ErrorMessage);

            RefreshNewAdSet();
        }

        private void ad_PubCenter_AdRefreshed(object sender, RoutedEventArgs e)
        {
            ScheduleRefresh(RefreshInterval_Pubcenter);
        }
        #endregion

        #region Adduplex
        private AdDuplex.AdControl LoadNewAdduplexAds()
        {
            AdDuplex.AdControl AdduplexAds = new AdDuplex.AdControl();

            AdduplexAds.Width = AdWidth;
            AdduplexAds.Height = AdHeight;
            AdduplexAds.AdUnitId = AdduplexAdId;
            AdduplexAds.AppKey = AdduplexAppKey;
            AdduplexAds.RefreshInterval = RefreshInterval_Adduplex;
            AdduplexAds.AutoSize = true;
           // AdduplexAds.size = string.Format("{0}x{1}", AdWidth, AdHeight);
            //AdduplexAds.IsTest = true;
            AdduplexAds.RefreshInterval = 999;

            AdduplexAds.NoAd += AdduplexAds_NoAd;
            AdduplexAds.AdLoaded += AdduplexAds_AdLoaded;
            AdduplexAds.AdLoadingError += AdduplexAds_AdLoadingError;
  
            return AdduplexAds;
        }

        private void AdduplexAds_NoAd(object sender, AdDuplex.Common.Models.NoAdEventArgs e)
        {
            Debug.WriteLine("Adduplex no ad: ");

            RefreshNewAdSet();
        }

        private void AdduplexAds_AdLoadingError(object sender, AdDuplex.Common.Models.AdLoadingErrorEventArgs e)
        {
            Debug.WriteLine("Adduplex: " + e.Error.ToString());

            RefreshNewAdSet();
        }

        private void AdduplexAds_AdLoaded(object sender, AdDuplex.Banners.Models.BannerAdLoadedEventArgs e)
        {
            ScheduleRefresh(RefreshInterval_Adduplex);
        }
        #endregion

     
        #region InMobi
        /*private IMAdView InitializeInmobi()
        {
            // Logging
            SDKUtility.LogLevel = LogLevels.IMLogLevelNone;

            IMAdView Ad_Inmobi = new IMAdView(InMobiAdId, IMAdView.INMOBI_AD_UNIT_120x600);

            Ad_Inmobi.RefreshInterval = 0;
            Ad_Inmobi.Height = AdHeight;
            Ad_Inmobi.Width = AdWidth;
            Ad_Inmobi.AnimationType = IMAdAnimationType.SLIDE_IN_LEFT;
            Ad_Inmobi.AdBackgroundColor = "Black";
            Ad_Inmobi.AdTextColor = "White";

            Ad_Inmobi.OnAdRequestFailed += InMobi_OnAdRequestFailed;
            Ad_Inmobi.OnAdRequestLoaded += InMobi_OnAdRequestLoaded;
            Ad_Inmobi.OnDismissAdScreen += InMobi_OnDismissAdScreen;
            Ad_Inmobi.OnLeaveApplication += InMobi_OnLeaveApplication;
            Ad_Inmobi.OnShowAdScreen += InMobi_OnShowAdScreen;

            IMAdRequest imAdRequest = new IMAdRequest();
            imAdRequest.Age = 20;
            imAdRequest.Gender = GenderType.None;


            //Set UserLatLong
            //UserLatLong userLatLong = new UserLatLong { Lat = 12.77, Long = 77.12 };

            //Set User location
            //UserLocation userLocation = new UserLocation
            // {
            //     City = "Seattle",
            //      State = "WA",
            //      Country = "USA"
            //  };
            //  imAdRequest.Location = userLocation;

            //Create user interests            
            List<string> interests = new List<string>();
            interests.AddRange(new string[] { "finance", "bitcoin", "litecoin", "currency", "cryptocurrency", "crypto" });

            //Set Interests
            imAdRequest.Interests = interests;

            //Set UserInfo
            List<string> keywords = new List<string>();
            keywords.AddRange(new string[] { 
                "bitbot", "bitcoin", "litecoin", "ripple", "doge",
                "crypto", "currency", "market", "coin", "dollars",
                "btce", "mtgox", "btcchina", "coinbase", "campbx", "santoshi",
                "huobi", "okcoin", "kraken", "bitstamp", "coindesk", "itbit",
                "bitfinex", "cexio", "cryptsy", "42",
                "nxt", "btc", "ltc", "ftc", "rur", "usd", "gbp", "eur", "cny", "yuan", "JPY"
            });

            //Set the keywords
            imAdRequest.Keywords = keywords;

            //Set the status for LocationInquiryAllowed
            imAdRequest.LocationInquiryAllowed = false;

            //AdView1.AdSize = IMAdView.INMOBI_AD_UNIT_120x600;

            Ad_Inmobi.IMAdRequest = imAdRequest;

            return Ad_Inmobi;
        }

        private void InMobi_OnAdRequestFailed(object sender, InMobi.W8.AdSDK.IMAdViewErrorEventArgs e)
        {
            Debug.WriteLine("InMobi: " + e.ErrorDescription);

            RefreshNewAdSet();

            ScheduleRefresh();
        }

        private void InMobi_OnAdRequestLoaded(object sender, EventArgs e)
        {
        }

        private void InMobi_OnDismissAdScreen(object sender, EventArgs e)
        {

        }

        private void InMobi_OnLeaveApplication(object sender, EventArgs e)
        {

        }

        private void InMobi_OnShowAdScreen(object sender, EventArgs e)
        {

        }*/
        #endregion
    }
}
