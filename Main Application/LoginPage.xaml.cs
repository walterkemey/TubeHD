using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PrimeTube.YouTubeHelper;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PrimeTube
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private bool IsLoaded = false;

        public LoginPage()
        {
            this.InitializeComponent();

            SystemNavigationManager currentView = SystemNavigationManager.GetForCurrentView();
            currentView.BackRequested += CurrentView_BackRequested1;

            // Set title text and color
            ApplicationView.GetForCurrentView().Title = "Sign-in";
            ApplicationView.GetForCurrentView().TitleBar.BackgroundColor = Colors.Red;
            ApplicationView.GetForCurrentView().TitleBar.ButtonBackgroundColor = Colors.Red;
            ApplicationView.GetForCurrentView().TitleBar.ForegroundColor = Colors.White;

            Loaded += LoginPage_Loaded;
        }

        private void CurrentView_BackRequested1(object sender, BackRequestedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void backButton_Channel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void LoginPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                return;
            }
            IsLoaded = true;


            // https://accounts.google.com/o/oauth2/auth?client_id=519499300992-6d8h9ncnoft7ioldls8qf6vuvo04em4c.apps.googleusercontent.com&redirect_uri=http%3A%2F%2Flocalhost%2Foauth2callback&scope=https://www.googleapis.com/auth/youtube&response_type=code&access_type=offline
            // https://developers.google.com/youtube/v3/guides/auth/installed-apps

            string uri =
                string.Format("https://accounts.google.com/o/oauth2/auth?client_id={0}&redirect_uri=urn:ietf:wg:oauth:2.0:oob&scope=https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube%20https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube.force-ssl%20https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube.readonly%20https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube.upload%20https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutubepartner&response_type=code&access_type=offline",
                APIKeys.GetRandomizedYouTubeClientId());

            // await Launcher.LaunchUriAsync(new Uri(uri, UriKind.Absolute));
            this.WebView1.Navigate(new Uri(uri));
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

                    PrimeTube.YouTube.YoutubeService.ExchangeAuthorizationToken(code);
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
    }
}
