using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Media;
using Windows.Media.Casting;
using Windows.Media.MediaProperties;
using Windows.Media.PlayTo;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using PrimeTube.Helper;
using PrimeTube.ViewModel;
using PrimeTube.YouTube;
using PrimeTube.YouTubeHelper;
using Microsoft.Advertising.WinRT.UI;
using Windows.System.Profile;
using Youtube_Music_Video_Downloader__W10_;
using Windows.UI.StartScreen;
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;
using YouTubeStreamAPI;
using Microsoft.HockeyApp;
using System.Threading;
using Youtube_Music_Video_Downloader__W10_.Controls;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PrimeTube
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const int ResetVideoControlPanelTime = 7;
        private const int EffectivePixelForSmallViewState = 600;

        private bool isLoaded = false, LoadingSettings = false;

        // viewmodels
        public SearchViewModel model_search = new SearchViewModel();
        public VideoViewModel model_video = new VideoViewModel();
        public ChannelViewModel model_channel = new ChannelViewModel();
        public UserViewModel model_user = new UserViewModel();
        public MainViewModel model_main = new MainViewModel();

        // Background Audio transport control
        private SystemMediaTransportControls smtc = null;
        // Cast
        private CastingDevicePicker castingPicker;

        // Menus

        // Advertising
        private UnifiedInterstitialAds interstitialAd1;
        private UnifiedInterstitialAds interstitialMain;

        public MainPage()
        {
            this.InitializeComponent();

            Window.Current.SizeChanged += Current_SizeChanged;
            Loaded += MainPage_Loaded;

            // Keep this page in memory even when the user navigates away
            NavigationCacheMode = NavigationCacheMode.Required;

            SystemNavigationManager currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += CurrentView_BackRequested;

            // Set title text and color
            ApplicationView.GetForCurrentView().Title = "What to watch";
            ApplicationView.GetForCurrentView().TitleBar.BackgroundColor = Colors.White;
            ApplicationView.GetForCurrentView().TitleBar.ButtonBackgroundColor = Colors.White;
            ApplicationView.GetForCurrentView().TitleBar.ForegroundColor = Colors.Gray;

            //CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            //coreTitleBar.ExtendViewIntoTitleBar = true;

            // Update current application setting

            LoadingSettings = true;
            try
            {
                bool isAutoplayEnabled = ApplicationSetting.GetRoamingSetting(ApplicationSetting.Key_VideoIsAutoplaySuggested, ApplicationSetting.Default_VideoIsAutoplaySuggested);
                ToggleSwitch_Auto.IsOn = isAutoplayEnabled;
            }
            finally
            {
                LoadingSettings = false;
            }

            SetupAndRequestInterstitialAdvertisementMain("");
        }

        #region Navigation

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                isLoaded = true;

                // Remove Status Bar
                if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
                {
                    await Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync();
                }

                // Events
                HockeyClient.Current.TrackEvent("Page MainPage.xaml");

                // Rating
                int launchCount = ApplicationSetting.GetRoamingSetting(ApplicationSetting.Key_LaunchCount, ApplicationSetting.Default_LaunchCount);
                launchCount++;
                if (launchCount > 5)
                {
                    Storyboard_Rating_Fadein.Begin();

                    ApplicationData.Current.RoamingSettings.Values[ApplicationSetting.Key_LaunchCount] = -100;
                }
                else
                {
                    ApplicationData.Current.RoamingSettings.Values[ApplicationSetting.Key_LaunchCount] = launchCount;
                }
            }
        }

        void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            UpdateLayoutState();

            UpdatePictureInPictureWindowSize();
        }

        private bool isInFullScrenMode = false;
        private void UpdateLayoutState()
        {
            if (isInFullScrenMode)
            {
                ResizeMediaToFullScreen();
            }

            double EffectiveWidth = Window.Current.Bounds.Width;
            ApplicationView view = ApplicationView.GetForCurrentView();

            if (view.Orientation == ApplicationViewOrientation.Portrait &&
                view.IsFullScreen && view.AdjacentToLeftDisplayEdge && view.AdjacentToRightDisplayEdge)
            {
                VisualStateManager.GoToState(this, "SmallFullscreen", false);
                listview_gallery_popular.ItemTemplate = this.Resources["DataTemplate_VideoSmall"] as DataTemplate;
                listview_gallery_popular.ItemsPanel = this.Resources["ItemsPanelTemplate_VideoSmall"] as ItemsPanelTemplate;

                Pivot_RelatedNComment.SelectedIndex = 2;
            }
            else
            {
                if (/*view.IsFullScreen || */IsPictureInPictureVideoActive)
                {
                    VisualStateManager.GoToState(this, "Fullscreen", false);
                    listview_gallery_popular.ItemTemplate = this.Resources["DataTemplate_Video"] as DataTemplate;
                    listview_gallery_popular.ItemsPanel = this.Resources["ItemsPanelTemplate_Video"] as ItemsPanelTemplate;

                    Pivot_RelatedNComment.SelectedIndex = 0;
                }
                else
                {
                    if (EffectiveWidth < EffectivePixelForSmallViewState)
                    {
                        VisualStateManager.GoToState(this, "SmallFullscreen", false);
                        listview_gallery_popular.ItemTemplate = this.Resources["DataTemplate_VideoSmall"] as DataTemplate;
                        listview_gallery_popular.ItemsPanel = this.Resources["ItemsPanelTemplate_VideoSmall"] as ItemsPanelTemplate;

                        Pivot_RelatedNComment.SelectedIndex = 2;
                    }
                    else
                    {
                        VisualStateManager.GoToState(this, "Normal", false);
                        listview_gallery_popular.ItemTemplate = this.Resources["DataTemplate_Video"] as DataTemplate;
                        listview_gallery_popular.ItemsPanel = this.Resources["ItemsPanelTemplate_Video"] as ItemsPanelTemplate;

                        Pivot_RelatedNComment.SelectedIndex = 0;
                    }
                }
            }
        }


        private void ResizeMediaToFullScreen()
        {
            var view = ApplicationView.GetForCurrentView();

            if (isInFullScrenMode && !IsPictureInPictureVideoActive)
            {
                //ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
                double EffectiveWidth = Window.Current.Bounds.Width;
                if (EffectiveWidth < EffectivePixelForSmallViewState)
                {
                    VisualStateManager.GoToState(this, "SmallFullscreen", true);

                    isInFullScrenMode = true;
                }
                else
                {
                    VisualStateManager.GoToState(this, "Normal", true);
                    //
                    isInFullScrenMode = false;
                }

                /*       if (view.IsFullScreenMode)
                       {
                           view.ExitFullScreenMode();
                       }*/
            }
            else
            {
                //ApplicationView.GetForCurrentView().ExitFullScreenMode();
                VisualStateManager.GoToState(this, "Fullscreen", true);

                /*           if (!view.IsFullScreenMode)
                           {
                               view.TryEnterFullScreenMode();
                           }*/

                isInFullScrenMode = true;
            }
        }

        private void CurrentView_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Grid_LoginPage.Visibility == Visibility.Visible)
            {
                Grid_LoginPage.Visibility = Visibility.Collapsed;
                try
                {
                    WebView1.Navigate(new Uri("about:blank"));
                }
                catch (Exception exp)
                {
                    Debug.WriteLine(exp.ToString());
                }
                e.Handled = true;
            }
            else if (isInFullScrenMode && !IsPictureInPictureVideoActive) // exit full screen if any.
            {
                ResizeMediaToFullScreen();

                e.Handled = true;
            }
            else if (Grid_VideoContent.Visibility == Visibility.Visible && !IsPictureInPictureVideoActive) // if the user is currently viewing a video
            {
                ExitVideoPage();

                if (Grid_MainYouTubeGallery.Visibility == Visibility.Collapsed)
                {
                    Grid_MainYouTubeGallery.Visibility = Visibility.Visible;
                }

                e.Handled = true;
            }
            else if (Grid_ChannelPage.Visibility == Visibility.Visible)
            {
                Storyboard_Channel_SlideOut.Begin();

                if (!IsPictureInPictureVideoActive)
                {
                    Storyboard_Search_ScrollIn.Begin();
                }
                e.Handled = true;
            }
            else if (Grid_Search.Visibility == Visibility.Visible)
            {
                Storyboard_Search_ScrollOut.Begin();

                if (Grid_MainYouTubeGallery.Visibility == Visibility.Collapsed)
                {
                    Grid_MainYouTubeGallery.Visibility = Visibility.Visible;
                }

                e.Handled = true;
            }
        }

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Background Audio
            smtc = SystemMediaTransportControls.GetForCurrentView();
            smtc.DisplayUpdater.Type = MediaPlaybackType.Video;
            //smtc.PlaybackStatus = Windows.Media.MediaPlaybackStatus.Closed;
            smtc.ButtonPressed += systemControls_ButtonPressed;
            smtc.IsRewindEnabled = true;
            smtc.IsPlayEnabled = true;
            smtc.IsPauseEnabled = true;

            // Cast
            castingPicker = new CastingDevicePicker();
            castingPicker.Filter.SupportsVideo = true;
            castingPicker.Filter.SupportsAudio = true;
            /* castingPicker.Appearance.BackgroundColor = Colors.White;
             castingPicker.Appearance.ForegroundColor = Colors.Gray;
             castingPicker.Appearance.SelectedBackgroundColor = Colors.White;
             castingPicker.Appearance.SelectedForegroundColor = Colors.Black;
             castingPicker.Appearance.SelectedAccentColor = Colors.Black;*/
            castingPicker.CastingDeviceSelected += CastingPicker_CastingDeviceSelected;

            // Media playback timer
            timer_mediaplayback = new DispatcherTimer();
            timer_mediaplayback.Interval = TimeSpan.FromSeconds(0.5);
            timer_mediaplayback.Tick += timer_mediaplayback_Tick;
            timer_mediaplayback.Start();

            // Download Progress
            ((App)App.Current).GetBackgroundDownloader().DownloadProgressChanged += MainPage_DownloadProgressChanged;
            ((App)App.Current).GetBackgroundDownloader().DownloadStatusMessageChanged += MainPage_DownloadStatusMessageChanged;

            // Sharing
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;


            // Attempt to load if it was launched from a tile
            string parameter = (string)e.Parameter;
            if (parameter != null && parameter != string.Empty)
            {
                Dictionary<string, string> queryParameters = UriParameterHelper.DecodeUriParameter(parameter);
                string videoID = queryParameters["VideoID"];
                string channelID = queryParameters["ChannelID"];

                if (videoID != null && channelID != null)
                {
                    LoadVideo(WebUtility.UrlDecode(videoID), WebUtility.UrlDecode(channelID), false, NavigatingToVideoPageFrom.LiveTiles);

                    // Events
                    HockeyClient.Current.TrackEvent("Launch from Secondary Tile");
                }
            }
            // Load subscription video
            model_main.LoadSubscriptions();

            // Load popular videos
            bool noNetwork = await model_main.LoadPopularVideos(false); // This does not get called again if its already loaded.
            if (!noNetwork)
            {
                // Navigate to 404 page, to present a better user interface to user lol
                this.Frame.Navigate(typeof(NoNetworkPage), "");
            }

            UpdateLayoutState();

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Background audio 
            if (smtc != null)
            {
                smtc.ButtonPressed -= systemControls_ButtonPressed;
                smtc = null;
            }
            //      MediaControl.ArtistName = null;
            //        MediaControl.TrackName = null;

            // Cast
            castingPicker.CastingDeviceSelected -= CastingPicker_CastingDeviceSelected;
            castingPicker = null;


            // media disposal
            MediaElement1.Source = null;

            // Lock screen disable
            LockScreen.Re_EnableLockScreenTimeOut();

            if (timer_mediaplayback != null)
            {
                timer_mediaplayback.Stop();
                timer_mediaplayback = null;
            }

            // Sharing
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested -= DataTransferManager_DataRequested;

            // Ads
            DestroyInterstitialAdvertisement();
            DestroyMainInterstitialAdvertisement();

            // Download Progress
            ((App)App.Current).GetBackgroundDownloader().DownloadProgressChanged -= MainPage_DownloadProgressChanged;
            ((App)App.Current).GetBackgroundDownloader().DownloadStatusMessageChanged -= MainPage_DownloadStatusMessageChanged;

            base.OnNavigatedFrom(e);
        }
        #endregion

        #region ShareUI 
        private void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (model_video != null && model_video.VideoId != null) {
                args.Request.Data.SetWebLink(new Uri("https://www.youtube.com/watch?v=" + model_video.VideoId, UriKind.Absolute));

                args.Request.Data.Properties.Title = model_video.video.Snippet.Title;
                args.Request.Data.Properties.Description = model_video.video.Snippet.Description;
            }
        }

        #endregion

        #region UI Menu
        private void Button_Share_Tapped(object sender, TappedRoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();

            e.Handled = true; 
        }


        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            Grid_MainYouTubeGallery.Visibility = Visibility.Collapsed;
            Storyboard_Search_ScrollIn.Begin();


            //     ShowUserProfilePanel(true);

            // Search for something
            TextBox box = (TextBox)sender;
            SearchInternal(box.Text);
        }

        private void TextBox_Search2_GotFocus(object sender, RoutedEventArgs e)
        {
            // show the search layout, if should the user focus on the searchbox again.

            if (Grid_Search.Visibility == Visibility.Collapsed &&
                _lastSearchQuery != "" && _lastSearchQuery != "_")
            {
                SearchInternal(_lastSearchQuery);
            }
        }

        private void TextBox_Search_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void TextBox_Search_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            TextBox box = sender as TextBox;

            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                SearchInternal(((TextBox)sender).Text);
            }
        }
        #endregion

        #region MainYouTubeGallery
        private void Grid_MainYouTubePopular_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Pause existing video
            if (MediaElement1.CurrentState == MediaElementState.Playing)
            {
                MediaElement1.Pause();
            }

            // UI
            Grid g = sender as Grid;
            Google.Apis.YouTube.v3.Data.Video result = g.DataContext as Google.Apis.YouTube.v3.Data.Video;
            if (result != null && result.Snippet != null)
            {
                LoadVideo(result.Id, result.Snippet.ChannelId, false, NavigatingToVideoPageFrom.MainGallery);

                // Collapse the search content UI to optimize for performance.
                Grid_Search.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region TopSearchPanel
        private void Grid_Search_Tapped(object sender, TappedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private string _lastSearchQuery = "_";
        private async void SearchInternal(string query)
        {
            if (query == string.Empty)
                return;

            // Update 
            ApplicationView.GetForCurrentView().Title = "Search";

            Grid_MainYouTubeGallery.Visibility = Visibility.Collapsed;
            Storyboard_Search_ScrollIn.Begin();

            // progress bar
            ProgressRing_search.IsActive = true;

            // desc search
            Textblock_SearchContent_DescChannel.Visibility = Visibility.Collapsed;
            Textblock_SearchContent_DescPlaylist.Visibility = Visibility.Collapsed;
            Textblock_SearchContent_DescVideo.Visibility = Visibility.Collapsed;

            if (_lastSearchQuery != query)
            {
                bool noNetwork = !await model_search.SearchItems(query, null);

                if (noNetwork)
                {
                    // Navigate to 404 page, to present a better user interface to user lol
                    this.Frame.Navigate(typeof(NoNetworkPage), "");
                }
                else
                {
                    _lastSearchQuery = query;
                }

                // Events
                HockeyClient.Current.TrackEvent("Query Search");

            }

            // progress bar
            ProgressRing_search.IsActive = false;

            // desc search
            Textblock_SearchContent_DescChannel.Visibility = Visibility.Visible;
            Textblock_SearchContent_DescPlaylist.Visibility = Visibility.Visible;
            Textblock_SearchContent_DescVideo.Visibility = Visibility.Visible;
        }

        private void Grid_videosearch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Pause existing video
            if (MediaElement1.CurrentState == MediaElementState.Playing)
            {
                MediaElement1.Pause();
            }

            // UI
            Grid g = sender as Grid;
            SearchResult result = g.DataContext as SearchResult;
            if (result.Id.VideoId != null)
            {
                LoadVideo(result.Id.VideoId, result.Snippet.ChannelId, false, NavigatingToVideoPageFrom.Search);

                // Collapse the search content UI to optimize for performance.
                Grid_Search.Visibility = Visibility.Collapsed;
            }
        }

        private void Grid_playlistsearch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Grid g = sender as Grid;
            SearchResult result = g.DataContext as SearchResult;

            if (result.Id.PlaylistId != null)
            {
                LoadPlaylist(result);

                // Set playlist UI list on the right visible
                if (listview_VideoContent_Playlist.Visibility == Visibility.Collapsed)
                {
                    listview_VideoContent_Playlist.Visibility = Visibility.Visible;
                }

                // Collapse the search content UI to optimize for performance.
                Grid_Search.Visibility = Visibility.Collapsed;
            }
        }

        private void Grid_channelsearch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Grid g = sender as Grid;
            SearchResult result = g.DataContext as SearchResult;

            if (result.Id.ChannelId != null)
            {
                LoadChannel(result.Id.ChannelId);

                // Collapse the search content UI to optimize for performance.
                Grid_Search.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// When the button at the top right corner is tapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Settings_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SettingsPage), "");
        }

        /// <summary>
        /// When the button at the top right corner is tapped -- download page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_DownloadCount_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DownloadPage), "");
        }
        #endregion

        #region Video
        private NavigatingToVideoPageFrom _NavigatingToVideoPageFrom = NavigatingToVideoPageFrom.None;
        public enum NavigatingToVideoPageFrom
        {
            MainGallery,
            Search,
            Playlist,
            LiveTiles,
            UrlText,
            None
        }

        private int autoVideoControlPanelClose = 0; // if -1, ignore. if 0. Close panel
        private DispatcherTimer timer_mediaplayback;
        private bool isUpdatingMediaSliderValueByDispatcherTimer = false;
        /// <summary>
        /// Dispatcher timer event used for updating media slider position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_mediaplayback_Tick(object sender, object e)
        {
            if (Grid_VideoCtlPanel.Visibility == Visibility.Visible)
            {
                if (MediaElement1.Source != null && MediaElement1.NaturalDuration.HasTimeSpan)
                {
                    UpdateVideoControlSliderPosition();
                }
                if (autoVideoControlPanelClose > 0)
                {
                    autoVideoControlPanelClose--;

                    if (autoVideoControlPanelClose == 0)
                    {
                        autoVideoControlPanelClose = -1;
                        Storyboard_VideoCtlPanel_FadeOut.Begin();
                    }
                }
            }
        }

        /// <summary>
        /// Updates the position of the video control slider 
        /// </summary>
        private void UpdateVideoControlSliderPosition()
        {
            double totalseconds = MediaElement1.NaturalDuration.TimeSpan.TotalSeconds;
            if (totalseconds != 0)
            {
                isUpdatingMediaSliderValueByDispatcherTimer = true;

                // Update slider value
                Slider_video.Value = MediaElement1.Position.TotalSeconds / totalseconds * 100;
                // Text
                TextBlock_VideoTime.Text = MediaElement1.NaturalDuration.TimeSpan.ToString(@"hh\.mm\:ss");
                TextBlock_VideoEclipTime.Text = MediaElement1.Position.ToString(@"hh\.mm\:ss");


                isUpdatingMediaSliderValueByDispatcherTimer = false;
            }
        }

        /// <summary>
        /// When the user changes the slider position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Slider_video_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (isUpdatingMediaSliderValueByDispatcherTimer || IsPictureInPictureVideoActive)
            {
                return;
            }
            if (MediaElement1.Source != null && MediaElement1.NaturalDuration.HasTimeSpan)
            {
                double totalseconds = MediaElement1.NaturalDuration.TimeSpan.TotalSeconds;
                if (totalseconds != 0)
                {
                    MediaElement1.Position = new TimeSpan(0, 0, (int)(Slider_video.Value / 100 * totalseconds));
                    autoVideoControlPanelClose = ResetVideoControlPanelTime;
                }
            }
        }

        /// <summary>
        /// The entire grid holding media controls... when tapped, it disappears/appears
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_mediacontrols_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (IsPictureInPictureVideoActive)
            {
                //     Storyboard_Video_ScrollIn.Begin();
                //    Grid_VideoContent.Margin = new Thickness(0, 0, 0, 0);
                //    IsPictureInPictureVideoActive = false;
                RestoreVideoUI();
                UpdateVideoControlSliderPosition();

                // Collapse the search content UI to optimize for performance.
                Grid_Search.Visibility = Visibility.Collapsed;
                Grid_MainYouTubeGallery.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (Grid_VideoCtlPanel.Visibility == Visibility.Visible)
                {
                    Storyboard_VideoCtlPanel_FadeOut.Begin();
                }
                else
                {
                    Storyboard_VideoCtlPanel_FadeIn.Begin();
                    UpdateVideoControlSliderPosition();

                    autoVideoControlPanelClose = ResetVideoControlPanelTime;
                }
            }
        }

        /// <summary>
        /// When the grid holding media controls is double tapped [Set it to full screen/small]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_mediacontrols_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ResizeMediaToFullScreen();

            e.Handled = true;
        }

        /// <summary>
        /// When the video content UI is being moved around by touch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_VideoContent_ManipulationDelta_1(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (IsPictureInPictureVideoActive)
            {
                bool havePaused = false;
                if (MediaElement1.CanPause)
                {
                    MediaElement1.Pause();
                    havePaused = true;
                }

                Grid g = sender as Grid;

                g.Margin = new Thickness(g.Margin.Left + e.Delta.Translation.X, g.Margin.Top + e.Delta.Translation.Y, 0, 0);

                if (havePaused)
                {
                    MediaElement1.Play();
                }

                e.Handled = true;
            }
        }



        /// <summary>
        /// The video play pause button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_PlayPaue_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (IsPictureInPictureVideoActive)
                return;

            e.Handled = true;

            if (MediaElement1.CurrentState == MediaElementState.Playing)
            {
                MediaElement1.Pause();
                if (MediaElement_Audio.CanPause)
                    MediaElement_Audio.Pause();
            }
            else if (MediaElement1.CurrentState == MediaElementState.Paused || MediaElement1.CurrentState == MediaElementState.Stopped)
            {
                MediaElement1.Play();
                if (MediaElement_Audio.Source != null)
                    MediaElement_Audio.Play();
            }
            autoVideoControlPanelClose = ResetVideoControlPanelTime;
        }

        private void RestoreVideoUI()
        {
            IsPictureInPictureVideoActive = false;
            isVideoMenuActive = true;
            Grid_VideoContent.Visibility = Visibility.Visible;
            autoVideoControlPanelClose = ResetVideoControlPanelTime;
            UpdateLayoutState();// Update layout UI

            Storyboard_Video_ScrollIn.Begin();
            Grid_VideoContent.Margin = new Thickness(0, 0, 0, 0);
        }

        private bool isVideoMenuActive = false;
        private bool IsPictureInPictureVideoActive = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RestoreVideoUI();
        }

        /// <summary>
        /// When the storyboard for scrolling out video content is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Storyboard_Video_ScrollOut_Completed(object sender, object e)
        {
            Grid_VideoContent.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// When the storyboard for scrolling out video content to small PIP mode is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Storyboard_Video_ScrollOut_Small_Completed(object sender, object e)
        {
            UpdatePictureInPictureWindowSize();
        }

        private void UpdatePictureInPictureWindowSize()
        {
            if (IsPictureInPictureVideoActive)
            {
                Rect bounds = Window.Current.Bounds;

                Grid g = Grid_VideoContent;
                CompositeTransform transform = ((CompositeTransform)g.RenderTransform);
                double height = bounds.Height / 3d;
                double width = bounds.Width / 3d;

                transform.TranslateX = width;
                transform.TranslateY = height;
            }
        }

        private void Storyboard_Video_ScrollIn_Completed(object sender, object e)
        {
        }


        private void MediaElement1_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            switch (MediaElement1.CurrentState)
            {
                case MediaElementState.Buffering:
                case MediaElementState.Opening:
                    {
                        Button_PlayPause.Style = this.Resources["ButtonStyle_PlayTemplate"] as Style;

                        ProgressRing_VideoBuff.Visibility = Visibility.Visible;
                        ProgressRing_VideoBuff.IsActive = true;
                        break;
                    }
                case MediaElementState.Playing:
                    {
                        Button_PlayPause.Style = this.Resources["ButtonStyle_PauseTemplate"] as Style;

                        ProgressRing_VideoBuff.Visibility = Visibility.Collapsed;
                        ProgressRing_VideoBuff.IsActive = false;
                        break;
                    }
                default:
                    {
                        Button_PlayPause.Style = this.Resources["ButtonStyle_PlayTemplate"] as Style;

                        ProgressRing_VideoBuff.Visibility = Visibility.Collapsed;
                        ProgressRing_VideoBuff.IsActive = false;
                        break;
                    }
            }

            // Auto replay of media, and setting allows auto play
            if (MediaElement1.CurrentState == MediaElementState.Paused)
            {
                // Has the media ended?
                if (MediaElement1.Position.TotalSeconds == MediaElement1.NaturalDuration.TimeSpan.TotalSeconds)
                {
                    // Is it a playlist?
                    if (model_video.IsPlaylist)
                    {
                        SkipNextPlaylistVideo();
                    }
                    else if (ApplicationSetting.GetRoamingSetting(ApplicationSetting.Key_VideoIsEnableReplay, ApplicationSetting.Default_VideoIsEnableReplay)) // If its not a playlist, does it allow replay?
                    {
                        // Autoplay the next video
                        bool isAutoPlayNextSuggested = ApplicationSetting.GetRoamingSetting(ApplicationSetting.Key_VideoIsAutoplaySuggested, ApplicationSetting.Default_VideoIsAutoplaySuggested);
                        if (!isAutoPlayNextSuggested)
                            MediaElement1.Play(); // replay
                    }
                }
            }

            // Playback state for background media control... 
            // using a new switch to avoid a mess

            switch (MediaElement1.CurrentState)
            {
                case MediaElementState.Playing:
                    smtc.PlaybackStatus = MediaPlaybackStatus.Playing;
                    break;
                case MediaElementState.Paused:
                    smtc.PlaybackStatus = MediaPlaybackStatus.Paused;
                    break;
                case MediaElementState.Stopped:
                    smtc.PlaybackStatus = MediaPlaybackStatus.Stopped;
                    break;
                case MediaElementState.Closed:
                    smtc.PlaybackStatus = MediaPlaybackStatus.Closed;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MediaElement1_MediaEnded(object sender, RoutedEventArgs e)
        {
            // Autoplay the next video
            bool isAutoPlayNextSuggested = ApplicationSetting.GetRoamingSetting(ApplicationSetting.Key_VideoIsAutoplaySuggested, ApplicationSetting.Default_VideoIsAutoplaySuggested);

            if (isAutoPlayNextSuggested && model_video.relatedVideoSearchCollection.Count() > 0)
            {
                SearchResult result = model_video.relatedVideoSearchCollection[0];

                // set next video playback warning
                model_video.NextVideoName = result.Snippet.Title;
                model_video.NextVideoUIVisible = true;
                model_video.NextVideoResult = result;

                this.nextVideoCancelled = false;

                // schedule 3 seconds to go to next video
                t_nextVideoPlayback = new DispatcherTimer();
                t_nextVideoPlayback.Interval = new TimeSpan(0, 0, 4);
                t_nextVideoPlayback.Tick += t_nextVideoPlayback_Tick;

                t_nextVideoPlayback.Start();
            }
        }

        private async void MediaElement1_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            // MF_MEDIA_ENGINE_ERR_SRC_NOT_SUPPORTED: HRESULT - 0xC00D2EE7"
            if (e.ErrorMessage.Contains("MF_MEDIA_ENGINE_ERR_SRC_NOT_SUPPORTED") && e.ErrorMessage.Contains("0xC00D2EE7"))
            {
                bool success = await model_video.LoadVideoStreamFromRemoteServer();

                if (success)
                {
                    PlayVideo();
                    return;
                }
            }

            if (model_video.IsPlaylist)
            {
                SkipNextPlaylistVideo();
            }
        }

        private void MediaElement1_BufferingProgressChanged(object sender, RoutedEventArgs e)
        {
            Progressbar_VideoBuffer.Value = MediaElement1.BufferingProgress * 100;
        }

        void MediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Natural video height: " + MediaElement1.NaturalVideoHeight);
            Debug.WriteLine("Natural video width: " + MediaElement1.NaturalVideoWidth);


            // Disable lock screen
            LockScreen.DisableLockScreenTimeOut();
        }

        /// <summary>
        /// Cast to device button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_CastToDevice_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Button b = sender as Button;

            //Retrieve the location of the casting button
            GeneralTransform transform = b.TransformToVisual(Window.Current.Content as UIElement);
            Point pt = transform.TransformPoint(new Point(0, 0));

            //Show the picker above our casting button
            castingPicker.Show(((FrameworkElement)b).GetElementRect(), Windows.UI.Popups.Placement.Above);


            autoVideoControlPanelClose = ResetVideoControlPanelTime;
            e.Handled = true;
        }


        /// <summary>
        /// Requesting to pin this video to start screen tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_PinVideoToStart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (model_video == null || model_video.video == null || model_video.channel == null)
                return;

            // Prompt the user for additional confirmation if its activated from Windows Mobile
            bool isMobile = AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile";
            if (isMobile)
            {
                MessageDialog dlag = new MessageDialog("Would you like to pin a shortcut of this video to your start screen?", "Information");
                dlag.Commands.Add(new UICommand("Yes", null, 0));
                dlag.Commands.Add(new UICommand("Cancel", null, 1));
                dlag.CancelCommandIndex = 0;

                IUICommand selected = await dlag.ShowAsync();
                if ((int)selected.Id != 0)
                    return;
            }

            Uri localImage = await SecondaryTileHelper.GetLocalImageAsync(model_video.video.Snippet.Thumbnails.Standard.Url, model_video.VideoId);
            if (localImage == null)
                return;

            SecondaryTile tile = new SecondaryTile(
                model_video.VideoId,
                model_video.video.Snippet.Title,
                string.Format("VideoID={0}&ChannelID={1}", WebUtility.UrlEncode(model_video.VideoId), WebUtility.UrlEncode(model_video.video.Snippet.ChannelId)),
                localImage,
                TileSize.Default);

            Color background = Colors.Transparent;
            tile.VisualElements.BackgroundColor = background;
            tile.VisualElements.ForegroundText = ForegroundText.Light;
            tile.VisualElements.ShowNameOnSquare150x150Logo = true;
            tile.VisualElements.ShowNameOnSquare310x310Logo = true;
            tile.VisualElements.ShowNameOnWide310x150Logo = true;

            tile.VisualElements.Wide310x150Logo = localImage;

            Button b = sender as Button;
            await tile.RequestCreateForSelectionAsync(((FrameworkElement)b).GetElementRect());

            // Events
            HockeyClient.Current.TrackEvent("Secondary Tile");

            // Etc
            autoVideoControlPanelClose = ResetVideoControlPanelTime;
            e.Handled = true;
        }


        /// <summary>
        /// When request to download the current video. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_SettingDownload_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Flyout items
            MenuFlyout Menu1 = new MenuFlyout();
            Menu1.Placement = FlyoutPlacementMode.Bottom;

            int pos = 0;
            foreach (VideoInformation info in model_video.Stream.VideoInfo)
            {
                MenuFlyoutItem men = new MenuFlyoutItem();
                men.Text = info.Quality.ToString() + " - " + info.Type.ToString().Replace("video_", "");
                men.Tapped += Men_Tapped;
                men.Tag = pos;

                pos++;

                Menu1.Items.Add(men);
            }

            pos = 0;
            foreach (VideoInformation info in model_video.Stream.VideoInfo)
            {
                if (info.Type == VideoType.video_mp4)
                {
                    MenuFlyoutItem men;
                    ////////////////////// M4A Items
                    MenuFlyoutItem menM4A = new MenuFlyoutItem();
                    menM4A.Click += MenM4A_Click;
                    menM4A.Text = "96Kbps .M4A/ MUSIC";
                    menM4A.Tag = pos + "_" + 0 + "_1";

                    Menu1.Items.Add(menM4A);

                    // 128
                    men = new MenuFlyoutItem();
                    men.Click += MenM4A_Click;
                    men.Text = "128Kbps .M4A/ MUSIC";
                    men.Tag = pos + "_" + 1 + "_1";

                    Menu1.Items.Add(men);

                    // 192
                    men = new MenuFlyoutItem();
                    men.Click += MenM4A_Click;
                    men.Text = "192s Kbps .M4A/ MUSIC";
                    men.Tag = pos + "_" + 2 + "_1";

                    Menu1.Items.Add(men);
                    break;
                }
                pos++;
            }

            Menu1.ShowAt(sender as FrameworkElement);

            autoVideoControlPanelClose = ResetVideoControlPanelTime;
            e.Handled = true;
        }

        private async void Men_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Exception _ee = null;
            try
            {
                MenuFlyoutItem item = (MenuFlyoutItem)sender;
                string qualityText = item.Text;
                int pos = (int)item.Tag;

                Debug.WriteLine("Selected video of pos " + pos.ToString());

                if (model_video.Stream.VideoInfo != null && pos >= 0 && pos <= model_video.Stream.VideoInfo.Count - 1)
                {
                    VideoInformation info = model_video.Stream.VideoInfo[pos];

                    string url = info.GetFullURLforVideo();

                    string VideoTitle = model_video.video.Snippet.Title;
                    string destinationName = FileNameHelper.GetDownloadingFileName(VideoTitle, info.Type, info.Quality, false, false);

                    if (destinationName != null)
                    {
                        FileSavePicker picker = new FileSavePicker();
                        picker.SuggestedStartLocation = PickerLocationId.VideosLibrary;
                        picker.DefaultFileExtension = "." + info.Type.GetFileExtentionByType();
                        picker.SuggestedFileName = destinationName;
                        picker.FileTypeChoices.Add(info.Type.ToString(), new List<string>() { picker.DefaultFileExtension });


                        StorageFile file = await picker.PickSaveFileAsync();

                        if (file != null) // uiser might have cancelled the download
                        {
                            ((App)Application.Current).GetBackgroundDownloader().Download(url, destinationName, file, AudioEncodingQuality.Auto, true, false);

                            // Ads
                            await PlayAdsIfReady();

                            // Events
                            HockeyClient.Current.TrackEvent("Downloaded " + qualityText);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                _ee = ee;
            }
            if (_ee != null)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, (async () =>
                {
                    MessageDialog dlg = new MessageDialog(_ee.ToString(), "Error");

                    try
                    {
                        await dlg.ShowAsync();
                    }
                    catch { }
                }));
            }
        }

        private async void MenM4A_Click(object sender, RoutedEventArgs e)
        {
            Exception _ee = null;
            try
            {
                MenuFlyoutItem item = (MenuFlyoutItem)sender;

                string qualityText = item.Text;
                string[] tagSplit = (item.Tag as string).Split('_');
                int pos = int.Parse(tagSplit[0]);
                bool isM4A = tagSplit[2] == "1";

                AudioEncodingQuality audioQuality = AudioEncodingQuality.Medium;
                switch (int.Parse(tagSplit[1]))
                {
                    case 0:
                        audioQuality = AudioEncodingQuality.Low;
                        break;
                    case 1:
                        audioQuality = AudioEncodingQuality.Medium;
                        break;
                    case 2:
                        audioQuality = AudioEncodingQuality.High;
                        break;
                    case 3:
                        audioQuality = AudioEncodingQuality.Auto;
                        break;
                }

                Debug.WriteLine("Selected Music of pos " + pos.ToString());

                if (model_video.Stream.VideoInfo != null && pos >= 0 && pos <= model_video.Stream.VideoInfo.Count - 1)
                {
                    VideoInformation info = model_video.Stream.VideoInfo[pos];

                    string url = info.GetFullURLforVideo();

                    string VideoTitle = model_video.video.Snippet.Title;
                    string destinationName = FileNameHelper.GetDownloadingFileName(VideoTitle, info.Type, info.Quality, true, isM4A);

                    if (destinationName != null)
                    {
                        FileSavePicker picker = new FileSavePicker();
                        picker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
                        picker.DefaultFileExtension = "." + (isM4A ? "m4a" : "mp3");// VideoInformation.GetFileExtentionByType(info.Type);
                        picker.SuggestedFileName = destinationName;
                        picker.FileTypeChoices.Add(info.Type.ToString(), new List<string>() { picker.DefaultFileExtension });

                        StorageFile file = await picker.PickSaveFileAsync();

                        if (file != null) // uiser might have cancelled the download
                        {
                            ((App)Application.Current).GetBackgroundDownloader().Download(url, destinationName, file, audioQuality, false, isM4A);

                            // Ads
                            await PlayAdsIfReady();

                            // Events
                            HockeyClient.Current.TrackEvent("Downloaded " + qualityText);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                _ee = ee;
            }
            if (_ee != null)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, (async () =>
                {
                    MessageDialog dlg = new MessageDialog(_ee.ToString(), "Error");

                    try
                    {
                        await dlg.ShowAsync();
                    }
                    catch { }
                }));
            }
        }

        /// <summary>
        /// When the request for different video quality is tapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_SettingToggle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (IsPictureInPictureVideoActive)
                return;

            // Flyout items
            MenuFlyout Menu1 = new MenuFlyout();
            Menu1.Placement = FlyoutPlacementMode.Bottom;

            foreach (VideoInformation info in model_video.Stream.VideoInfo)
            {
                if (info.Type == VideoType.video_mp4 || info.Type == VideoType.video_3gpp || info.Type == VideoType.audio_mp4)
                {
                    MenuFlyoutItem men = new MenuFlyoutItem();
                    men.Text = info.Quality.ToString().ToUpper();
                    men.Tag = info;
                    men.Tapped += Men_Tapped1;

                    Menu1.Items.Add(men);
                }
            }

            Menu1.ShowAt(sender as FrameworkElement);

            autoVideoControlPanelClose = ResetVideoControlPanelTime;
            e.Handled = true;
        }

        /// <summary>
        /// Menu item for selecting video quality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Men_Tapped1(object sender, TappedRoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            if (item != null)
            {
                PlayVideo(item.Tag as VideoInformation);
            }
            else
            {
                PlayVideo();
            }
        }

        /// <summary>
        /// When the request to full screen the video is tapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_FullScreen_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (IsPictureInPictureVideoActive)
                return;

            ResizeMediaToFullScreen();

            autoVideoControlPanelClose = ResetVideoControlPanelTime;
            e.Handled = true;
        }

        /// <summary>
        /// When the replay button is tapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Replay_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (IsPictureInPictureVideoActive)
                return;

            bool currentReplaySetting = ApplicationSetting.GetRoamingSetting(ApplicationSetting.Key_VideoIsEnableReplay, ApplicationSetting.Default_VideoIsEnableReplay);

            ApplicationSetting.SetRoamingSetting(ApplicationSetting.Key_VideoIsEnableReplay, !currentReplaySetting);

            // UI for telling user that its enabled or not
            Textblock_VideoMsg.Visibility = Visibility.Visible;
            Textblock_VideoMsg.Foreground = new SolidColorBrush(!currentReplaySetting == true ? Colors.Green : Colors.Red);
            Textblock_VideoMsg.Text = (!currentReplaySetting == true ? "Enabled" : "Disabled") + " auto replay.";
            Storyboard_VideoMessage_Play.Begin();

            // Events
            HockeyClient.Current.TrackEvent("Replay active: " + !currentReplaySetting);

            autoVideoControlPanelClose = ResetVideoControlPanelTime;
            e.Handled = true;
        }

        private void Storyboard_VideoMessage_Play_Completed(object sender, object e)
        {
            Textblock_VideoMsg.Visibility = Visibility.Collapsed;
            Textblock_VideoMsg.Text = string.Empty;
        }

        /// <summary>
        /// When tapped on the channel information
        /// opens the channel page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_ChannelProfile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (model_video.channel != null)
            {
                LoadChannel(model_video.channel.Id);
            }
        }

        private void Button_Video_Subscribe_Tapped(object sender, TappedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void Button_PlaylistExpand_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Set playlist UI list visible
            listview_VideoContent_Playlist.Visibility = listview_VideoContent_Playlist.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

            e.Handled = true;
        }

        private bool IsCodeUpdatingPlaylistItem = false;
        private void listview_VideoContent_Playlist_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (IsCodeUpdatingPlaylistItem)
            {
                return;
            }

            PlaylistItem plItem = e.ClickedItem as PlaylistItem; // this array starts from 0... 
            int clickedIndex = model_video.PlaylistItems.IndexOf(plItem);
            if (clickedIndex == model_video.PlaylistIndex)
            {
                return;
            }
            model_video.PlaylistIndex = clickedIndex;

            LoadVideoInternal(plItem.ContentDetails.VideoId, plItem.Snippet.ChannelId, plItem);
        }


        /// <summary>
        /// Playlist shuffle button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Playlist_Shuffle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!model_video.IsPlaylist || model_video.PlaylistItems.Count == 0)
            {
                return;
            }
            ObservableCollection<PlaylistItem> NewPlaylists = new ObservableCollection<PlaylistItem>();

            var r = new Random(DateTime.Now.Millisecond);
            foreach (PlaylistItem video in model_video.PlaylistItems.OrderBy(x => r.NextDouble()).Take(model_video.PlaylistItems.Count))
            {
                NewPlaylists.Add(video);
            }
            if (NewPlaylists.Count > 0) // another check, for safety
            {
                model_video.PlaylistItems.Clear();
                NewPlaylists.AddTo(model_video.PlaylistItems);

                PlaylistItem firstItem = model_video.PlaylistItems[0];
                model_video.PlaylistIndex = 0;
                LoadVideoInternal(firstItem.ContentDetails.VideoId, firstItem.Snippet.ChannelId, firstItem);
            }
        }

        /// <summary>
        ///  When the comment author name is tapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Image_CommentAuthor_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Image tblock = sender as Image;
            CommentThread comment = tblock.DataContext as CommentThread;

            if (comment != null && comment.Snippet.TopLevelComment.Snippet.AuthorChannelId != null && comment.Snippet.TopLevelComment.Snippet.AuthorChannelId != null)
            {
                JObject authorChannelId = comment.Snippet.TopLevelComment.Snippet.AuthorChannelId as JObject;

                LoadChannel((string)authorChannelId["value"]);
            }
            else
            {
                var messageDialog = new MessageDialog(comment.Snippet.TopLevelComment.Snippet.AuthorDisplayName + "'s user profile is private. :(", "Error");
                messageDialog.Commands.Add(new UICommand("Ok", delegate (IUICommand command)
                {
                }));
                // call the ShowAsync() method to display the message dialog
                await messageDialog.ShowAsync();
            }
        }

        /// <summary>
        /// When a related video is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listview_videorelated_ItemClick(object sender, ItemClickEventArgs e)
        {
            SearchResult result = e.ClickedItem as SearchResult;

            LoadVideoInternal(result.Id.VideoId, result.Snippet.ChannelId);
        }

        /// <summary>
        /// When autoplay preference is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleSwitch_Auto_Toggled(object sender, RoutedEventArgs e)
        {
            if (LoadingSettings)
                return;

            ToggleSwitch toggle = sender as ToggleSwitch;

            ApplicationSetting.SetRoamingSetting(ApplicationSetting.Key_VideoIsAutoplaySuggested, toggle.IsOn);
        }

        /// <summary>
        /// When tapped on the dislike button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Dislike_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /*  if (!NavigateLoginPageIfNecessary()) // already logged in
              {
                  await model_video.LikeVideo(false);
              }*/
        }

        private async void Button_Like_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /*      if (!NavigateLoginPageIfNecessary()) // already logged in
                  {
                      await model_video.LikeVideo(true);
                  }*/
        }

        private void ExitVideoPage()
        {
            if (MediaElement1.CurrentState != MediaElementState.Playing)
            {
                Storyboard_Video_ScrollOut.Begin();
            }
            else // make the video minimize
            {
                Storyboard_Video_ScrollOut_Small.Begin();

                double EffectiveWidth = Window.Current.Bounds.Width;
                if (EffectiveWidth < EffectivePixelForSmallViewState)
                {
                    VisualStateManager.GoToState(this, "FullscreenPIP", true);
                }
                else
                {
                    VisualStateManager.GoToState(this, "Fullscreen", true);
                }

                IsPictureInPictureVideoActive = true;

                if (Grid_VideoCtlPanel.Visibility == Visibility.Visible)
                {
                    Storyboard_VideoCtlPanel_FadeOut.Begin();
                }
            }
            // If channel page is not visible, set the search content back to visible
            switch (_NavigatingToVideoPageFrom)
            {
                case NavigatingToVideoPageFrom.Search:
                    {
                        if (Grid_ChannelPage.Visibility == Visibility.Collapsed)
                        {
                            Storyboard_Search_ScrollIn.Begin();
                        }
                        break;
                    }
            }
            _NavigatingToVideoPageFrom = NavigatingToVideoPageFrom.None;
        }
        #endregion

        #region Channel
        /// <summary>
        /// When the storyboard for sliding out channel UI is completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Storyboard_Channel_SlideOut_Completed(object sender, object e)
        {
            Grid_ChannelPage.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// When tapped on a playlist item video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_playlistVideoItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Grid g = sender as Grid;
            PlaylistItem result = g.DataContext as PlaylistItem;

            if (result != null)
            {
                LoadVideo(result.ContentDetails.VideoId, result.Snippet.ChannelId, false, NavigatingToVideoPageFrom.Playlist);
            }
        }

        private void Pivot_Channel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0 || model_channel == null || model_channel.channel == null)
                return;

            PivotItem item = e.AddedItems[0] as PivotItem;

            string playlistid = null;
            ChannelViewModel.PlaylistType type = ChannelViewModel.PlaylistType.Custom;

            if (item == Pivot_Channel_uploads)
            {
                playlistid = model_channel.channel.ContentDetails.RelatedPlaylists.Uploads;
                type = ChannelViewModel.PlaylistType.Uploads;
            }
            else if (item == Pivot_Channel_fav)
            {
                playlistid = model_channel.channel.ContentDetails.RelatedPlaylists.Favorites;
                type = ChannelViewModel.PlaylistType.Favourites;
            }
            else if (item == Pivot_Channel_likes)
            {
                playlistid = model_channel.channel.ContentDetails.RelatedPlaylists.Likes;
                type = ChannelViewModel.PlaylistType.Likes;
            }

            if (playlistid != null)
            {
                model_channel.LoadPlaylist(
                       model_channel.channel.Id,
                       playlistid,
                       type,
                       null);
            }
        }
        #endregion

        #region CommonYouTubeOperation
        private void SkipNextPlaylistVideo()
        {
            if (model_video.PlaylistItemsCount > 0)
            {
                // play the next item
                model_video.PlaylistIndex++;

                // Is it the end of playlist?
                if (model_video.PlaylistIndex >= model_video.PlaylistItemsCount)
                {
                    model_video.PlaylistIndex = 0;

                    // Does it allow replay?
                    if (!ApplicationSetting.GetRoamingSetting(ApplicationSetting.Key_VideoIsEnableReplay, ApplicationSetting.Default_VideoIsEnableReplay))
                        return;
                }
                PlaylistItem plItem = model_video.PlaylistItems[model_video.PlaylistIndex]; // this array starts from 0... 
                LoadVideoInternal(plItem.ContentDetails.VideoId, plItem.Snippet.ChannelId, plItem);
            }
        }

        private async void LoadPlaylist(SearchResult playlistid)
        {
            RestoreVideoUI();

            // Load playlist information
            await model_video.LoadPlaylist(playlistid);

            PlaylistItem plItem = model_video.PlaylistItems[0];
            LoadVideoInternal(plItem.ContentDetails.VideoId, plItem.Snippet.ChannelId, plItem);

            // Events
            HockeyClient.Current.TrackEvent("Loaded playlist");
        }

        private void LoadChannel(string channelid)
        {
            if (MediaElement1.CurrentState != MediaElementState.Playing)
            {
                Storyboard_Video_ScrollOut.Begin();
            }
            else // make the video minimize
            {
                ExitVideoPage();

                //    Storyboard_Video_ScrollOut_Small.Begin();
                //   UpdateLayoutState();// Update layout UI
                //   IsPictureInPictureVideoActive = true;

                if (Grid_VideoCtlPanel.Visibility == Visibility.Visible)
                {
                    Storyboard_VideoCtlPanel_FadeOut.Begin();
                }
            }
            LoadChannelInternal(channelid);
        }

        private async void LoadChannelInternal(string channelid)
        {
            Grid_ChannelPage.Visibility = Visibility.Visible;
            Storyboard_Channel_SlideIn.Begin();

            // Load channel information
            await model_channel.LoadChannel(channelid, false);
            if (model_channel.channel != null)
            {
                listview_channelPage_uploads.ItemsSource = null;

                model_channel.LoadPlaylist(
                     model_channel.channel.Id,
                    model_channel.channel.ContentDetails.RelatedPlaylists.Uploads,
                    PrimeTube.ViewModel.ChannelViewModel.PlaylistType.Uploads,
                    null);

                listview_channelPage_uploads.ItemsSource = model_channel.Playlist_Uploads;

                // Update window name
                ApplicationView.GetForCurrentView().Title = model_channel.channel.Snippet.Title;

                // Events
                HockeyClient.Current.TrackEvent("Loaded user channel");
            }
        }
        public async void LoadVideo(string videoid, string channelid, bool isPlaylist, NavigatingToVideoPageFrom _NavigatingToVideoPageFrom)
        {
            if (!isPlaylist)
            {
                await model_video.LoadPlaylist(null); // remove bindings and etc
            }
            this._NavigatingToVideoPageFrom = _NavigatingToVideoPageFrom;
            RestoreVideoUI();

            LoadVideoInternal(videoid, channelid);
        }

        private bool isLoadingVideoInternal = false;
        private async void LoadVideoInternal(string videoid, string channelid, PlaylistItem playlistitem = null)
        {
            if (isLoadingVideoInternal)
            {
                return;
            }
            isLoadingVideoInternal = true;

            try
            {
                Grid_VideoLoading.Visibility = Visibility.Visible;

                // Set videoid value
                model_video.VideoId = videoid;


                // Update selection if this is a playlist.
                if (model_video.IsPlaylist && playlistitem != null)
                {
                    IsCodeUpdatingPlaylistItem = true;

                    listview_VideoContent_Playlist.SelectedItem = playlistitem;
                    listview_VideoContent_Playlist.ScrollIntoView(playlistitem);

                    IsCodeUpdatingPlaylistItem = false;
                }

                // Load video information
                model_video.SearchSingleVideo(videoid);
                if (channelid != null)
                {
                    model_video.LoadVideoChannelDetail(channelid);
                }
                string loadResult = await model_video.LoadVideoStreamData(videoid);
                if (loadResult != string.Empty)
                {
                    await model_video.LoadVideoStreamFromRemoteServer(); // load from remote server if fails.
                }
                UpdateSongInfoManually();

                PlayVideo();

                if (model_video.video != null)
                {
                    model_video.LoadComments(videoid);
                    model_video.LoadRelatedVideo(videoid, model_video.video.Snippet.Title);

                    // Load ads
                    SetupAndRequestInterstitialAdvertisement(model_video.video.Snippet.Title);

                    ApplicationView.GetForCurrentView().Title = model_video.video.Snippet.Title;
                }

                // Events
                HockeyClient.Current.TrackEvent("Loaded Video");
            }
            finally
            {

                isLoadingVideoInternal = false;
                Grid_VideoLoading.Visibility = Visibility.Collapsed;
            }
        }


        /// <summary>
        /// When the video quality UI button is tapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Button b = (Button)sender;
            VideoInformation info = (VideoInformation)b.Tag;

            if (info != null)
            {
                PlayVideo(info);
            }
        }

        private void PlayVideo(VideoInformation information = null)
        {
            if (information == null)
            {
                // Play video
                if (model_video.Stream.VideoInfo.Count > 0)
                {
                    foreach (VideoInformation info in model_video.Stream.VideoInfo)
                    {
                        if (info.Type == VideoType.video_mp4 || info.Type == VideoType.video_3gpp)
                        {
                            Debug.WriteLine("Playing video: " + info.GetFullURLforVideo());

                            MediaElement1.Source = new Uri(info.GetFullURLforVideo(), UriKind.Absolute);
                            MediaElement1.Play();
                            break;
                        }
                    }
                }
            }
            else
            {
                // select from the one tapped by the user.
                if (information.Type == VideoType.video_mp4 || information.Type == VideoType.video_3gpp)
                {
                    Debug.WriteLine("Playing video: " + information.GetFullURLforVideo());

                    MediaElement1.Source = new Uri(information.GetFullURLforVideo(), UriKind.Absolute);
                    MediaElement1.Play();
                }
            }
        }

        /// <summary>
        /// When the loading progress bar overlay grid of video page is tapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_VideoLoading_Tapped(object sender, TappedRoutedEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region CastTo
        private async void CastingPicker_CastingDeviceSelected(CastingDevicePicker sender, CastingDeviceSelectedEventArgs args)
        {
            //Casting must occur from the UI thread.  This dispatches the casting calls to the UI thread.
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                //Create a casting conneciton from our selected casting device
                CastingConnection connection = args.SelectedCastingDevice.CreateCastingConnection();

                //Hook up the casting events
                connection.ErrorOccurred += Connection_ErrorOccurred;
                connection.StateChanged += Connection_StateChanged;

                //Cast the content loaded in the media element to the selected casting device
                await connection.RequestStartCastingAsync(MediaElement1.GetAsCastingSource());
            });
        }
        private async void Connection_StateChanged(CastingConnection sender, object args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                //      ShowMessageToUser("Casting Connection State Changed: " + sender.State);
                switch (sender.State)
                {
                    case CastingConnectionState.Connected:
                        // Events
                        HockeyClient.Current.TrackEvent("Casted to TV");
                        break;
                }
            });
        }

        private async void Connection_ErrorOccurred(CastingConnection sender, CastingConnectionErrorOccurredEventArgs args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                //       ShowMessageToUser("Casting Connection State Changed: " + sender.State);
                //Clear the selection in the listbox on an error
            });
        }
        #endregion

        #region MediaControl_Background
        /// <summary>
        /// Shows how to update the media metadata and thumbnail manually.
        /// Normally you would probably retreive this info from a source such as a database
        /// but for this simple sample we'll just set the metadata with strings.
        /// </summary>
        private void UpdateSongInfoManually()
        {
            if (smtc == null || smtc.DisplayUpdater == null || model_video == null || model_video.video == null)
                return;

            // Get the updater.
            SystemMediaTransportControlsDisplayUpdater updater = smtc.DisplayUpdater;

            // Define
            string Artist = model_video.video.Snippet.ChannelTitle;
            string Title = model_video.video.Snippet.Title;

            // Video metadata.
            updater.VideoProperties.Title = Title;
            updater.VideoProperties.Subtitle = Artist;

            // Music metadata.
            /*    updater.MusicProperties.AlbumArtist = Artist;
                updater.MusicProperties.Artist = Artist;
                updater.MusicProperties.Title = Title;*/

            // Set the album art thumbnail.
            // RandomAccessStreamReference is defined in Windows.Storage.Streams
            updater.Thumbnail =
               RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Img_Logo.png"));

            // Update the system media transport controls.
            updater.Update();
        }

        async void systemControls_ButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs args)
        {
            switch (args.Button)
            {
                /* case SystemMediaTransportControlsButton.Next:
                     currentIndex++;
                     await SetCurrentPlayingAsync(currentIndex);
                     break;
                 case SystemMediaTransportControlsButton.Previous:
                     currentIndex--;
                     await SetCurrentPlayingAsync(currentIndex);
                     break;*/
                case SystemMediaTransportControlsButton.Play:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        MediaElement1.Play();
                        if (MediaElement_Audio.Source != null)
                            MediaElement_Audio.Play();
                    });
                    break;
                case SystemMediaTransportControlsButton.Pause:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        MediaElement1.Pause();
                        if (MediaElement_Audio.CanPause)
                            MediaElement_Audio.Pause();
                    });
                    break;
                case SystemMediaTransportControlsButton.Stop:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        MediaElement1.Stop();
                        if (MediaElement_Audio.CanPause)
                            MediaElement_Audio.Stop();
                    });
                    break;
                case SystemMediaTransportControlsButton.Rewind:
                    {
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            MediaElement1.Position = new TimeSpan(0, 0, 0);
                            MediaElement1.Play();
                            if (MediaElement_Audio.Source != null)
                                MediaElement_Audio.Play();
                        });
                        break;
                    }

                    // Insert additional case statements for other buttons you want to handle in your app.
                    // Remember that you also need to first enable those buttons via the corresponding
                    // IsXXXXEnabled property on the SystemMediaTransportControls object.
            }
        }
        #endregion

        #region Storyboard
        private void Storyboard_Search_ScrollOut_Completed(object sender, object e)
        {
            Grid_Search.Visibility = Visibility.Collapsed;
        }

        private void Storyboard_Search_ScrollIn_Completed(object sender, object e)
        {
        }
        #endregion

        #region Login
        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            NavigateLoginPageIfNecessary();
        }

        private bool NavigateLoginPageIfNecessary()
        {
            bool isLoggedIn = ApplicationSetting.GetLocalSetting("google_is_loggedin", false);

            if (!isLoggedIn)
            {
                bool isMobile = AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile";

                if (isMobile) // move this to other page, optimize for limited memory
                {
                    this.Frame.Navigate(typeof(LoginPage), "");
                }
                else
                {
                    try
                    {

                        // https://accounts.google.com/o/oauth2/auth?client_id=519499300992-6d8h9ncnoft7ioldls8qf6vuvo04em4c.apps.googleusercontent.com&redirect_uri=http%3A%2F%2Flocalhost%2Foauth2callback&scope=https://www.googleapis.com/auth/youtube&response_type=code&access_type=offline
                        // https://developers.google.com/youtube/v3/guides/auth/installed-apps

                        string uri =
                            string.Format("https://accounts.google.com/o/oauth2/auth?client_id={0}&redirect_uri=urn:ietf:wg:oauth:2.0:oob&scope=https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube%20https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube.force-ssl%20https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube.readonly%20https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube.upload%20https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutubepartner&response_type=code&access_type=offline",
                            APIKeys.GetRandomizedYouTubeClientId());

                        // await Launcher.LaunchUriAsync(new Uri(uri, UriKind.Absolute));
                        this.WebView1.Navigate(new Uri(uri));
                    }
                    catch (Exception exp)
                    {
                        Debug.WriteLine(exp.ToString());
                    }

                    Grid_LoginPage.Visibility = Visibility.Visible;
                }
                return true;
            }
            return false;
        }

        private async void WebView1_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            if (args.Uri == null)
                return;

            Uri uri = args.Uri;
            //"https://accounts.google.com/o/oauth2/approval?as=42e3cc68d2e8ee44&hl=en&pageId=116799181908485949488&xsrfsign=APsBz4gAAAAAVfZ7BqYyX618a7CCGUbeL4zq9ZInja2m"

            try
            {
                string title = await WebView1.InvokeScriptAsync("eval", new string[] { "document.title;" });
                string src = await WebView1.InvokeScriptAsync("eval", new string[] { "document.documentElement.outerHTML;" });

                if (title.Contains("Success code="))
                {
                    string code = title.Replace("Success code=", "");

                    JObject objToken = await YoutubeService.ExchangeAuthorizationToken(code);
                    if (objToken != null)
                    {
                        string access_token = (string)objToken["access_token"];
                        string token_type = (string)objToken["token_type"];
                        int expires_in = (int)objToken["expires_in"];
                        string refresh_token = (string)objToken["refresh_token"];


                        await ApplicationSetting.SetUpdateLocalValueEncrypted("google_authorization_token", code);

                        await ApplicationSetting.SetUpdateLocalValueEncrypted("google_access_token", access_token);
                        await ApplicationSetting.SetUpdateLocalValueEncrypted("google_token_type", token_type);
                        await ApplicationSetting.SetUpdateLocalValueEncrypted("google_refresh_token", refresh_token);
                        ApplicationSetting.SetLocalSetting("google_token_expiresTime", (long)(DateTime.Now.Ticks / TimeSpan.TicksPerSecond) + ((expires_in - 5L) * 60L));
                        ApplicationSetting.SetLocalSetting("google_is_loggedin", true);

                        Grid_LoginPage.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        MessageDialog dlg = new MessageDialog("Login failed, please try again.", "Error");
                        await dlg.ShowAsync();
                    }
                }
            }
            catch { }
        }

        private void WebView1_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
        }

        private void WebView1_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {

        }

        private void WebView1_ScriptNotify(object sender, NotifyEventArgs e)
        {

        }

        private void WebView1_PermissionRequested(WebView sender, WebViewPermissionRequestedEventArgs args)
        {

        }

        private void WebView1_UnsafeContentWarningDisplaying(WebView sender, object args)
        {

        }

        private void WebView1_UnsupportedUriSchemeIdentified(WebView sender, WebViewUnsupportedUriSchemeIdentifiedEventArgs args)
        {

        }

        private void WebView1_UnviewableContentIdentified(WebView sender, WebViewUnviewableContentIdentifiedEventArgs args)
        {

        }
        #endregion

        #region Playlist
        private void BitmapImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            //BitmapImage bitmap = (BitmapImage)sender;
            //  bitmap.SetSourceAsync
        }
        #endregion

        #region NextVideoUI 
        private bool nextVideoCancelled = false;
        private void Button_NextCancel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            nextVideoCancelled = true;

            // Remove UI via binding.
            model_video.NextVideoUIVisible = false;
        }

        private DispatcherTimer t_nextVideoPlayback = null;
        /// <summary>
        /// Happens when the timer of 3 seconds is up. 
        /// Plays the next video 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_nextVideoPlayback_Tick(object sender, object e)
        {
            if (nextVideoCancelled)
                return;

            if (model_video.NextVideoResult != null)
            {
                LoadVideoInternal(model_video.NextVideoResult.Id.VideoId, model_video.NextVideoResult.Snippet.ChannelId);
            }
            // Reset binding
            model_video.NextVideoUIVisible = false;
            model_video.NextVideoName = string.Empty;
            model_video.NextVideoResult = null;

            if (t_nextVideoPlayback != null)
            {
                t_nextVideoPlayback.Stop();
                t_nextVideoPlayback = null;
            }
        }
        #endregion

        #region Ads

        private void InterstitialMain_Cancelled()
        {
            if (ads_videoPlayback_Paused)
            {
                ads_videoPlayback_Paused = false;

                MediaElement1.Play();
            }
        }

        private void InterstitialMain_Completed()
        {
            if (ads_videoPlayback_Paused)
            {
                ads_videoPlayback_Paused = false;

                MediaElement1.Play();
            }
        }


        private bool ads_videoPlayback_Paused = false;

        private void SetupAndRequestInterstitialAdvertisement(string videoTitle)
        {
            if (interstitialAd1 != null)
            {
                interstitialAd1.Destroy();
            }

            interstitialMain = new UnifiedInterstitialAds(false, videoTitle);
            interstitialMain.Completed += InterstitialMain_Completed;
            interstitialMain.Cancelled += InterstitialMain_Cancelled;
       interstitialMain.Initialize(
                  "214203", "f64c6c77-b641-426f-ba9c-e8c5b258d8d0",//banner
                "9p67k5d1j9nx", "1100042013",
                "9p67k5d1j9nx", "1100042013");
        }

        private void DestroyInterstitialAdvertisement()
        {
            interstitialAd1.Destroy();
        }

        /// <summary>
        /// Plays the Interstitial video ads if it is ready to be shown after loading.
        /// </summary>
        /// <returns></returns>
        private async Task<bool> PlayAdsIfReady()
        {
            if (interstitialAd1 != null)
            {
                if (await interstitialAd1.ShowAdsIfAvailable())
                {
                    if (MediaElement1.CanPause)
                    {
                        MediaElement1.Pause();

                        // Flag to re-play video later.
                        ads_videoPlayback_Paused = true;
                    }
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region AdsMain
        private void SetupAndRequestInterstitialAdvertisementMain(string videoTitle)
        {
            interstitialMain = new UnifiedInterstitialAds(true, string.Empty);

         interstitialMain.Initialize(
                "214207", "f64c6c77-b641-426f-ba9c-e8c5b258d8d0",//interstitial
                "9p67k5d1j9nx", "1100042013",
                "9p67k5d1j9nx", "1100042013");
        }

        private void DestroyMainInterstitialAdvertisement()
        {
            if (interstitialMain != null)
            {
                interstitialMain.Destroy();

                interstitialMain = null;
            }
        }
        #endregion

        #region DownloadProgress
        private void MainPage_DownloadStatusMessageChanged(string title, string msg)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            // audio
            XmlElement audioNode = toastXml.CreateElement("audio");
            audioNode.SetAttribute("src", "ms-winsoundevent:Notification.Looping.Alarm");

            // toast images
            XmlNodeList toastImages = toastXml.GetElementsByTagName("image");

            //   ((XmlElement)toastImages[0]).SetAttribute("src", trade.trade_type == Json_TradeEnum.Sell ? "ms-appx:///Assets/Images/image_bear.png" : "ms-appx:///Assets/Images/image_bull.png");
            //  ((XmlElement)toastImages[0]).SetAttribute("alt", "image");

            // text node
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(title));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(msg));

            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(20);

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private void AdControl1_topBanner_ErrorOccurred(object sender, AdErrorEventArgs e)
        {

        }

        private void MainPage_DownloadProgressChanged(string tag, double progress)
        {
            if (progress >= 100)
            {
                ProgressBar_Download.Value = 0;
            }
            else
            {
                ProgressBar_Download.Value = (int)progress;
            }
        }
        #endregion
    }
}
