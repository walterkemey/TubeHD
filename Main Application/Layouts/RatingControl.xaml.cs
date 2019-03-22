using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PrimeTube.Layouts
{
    public sealed partial class RatingControl : UserControl
    {
        public RatingControl()
        {
            this.InitializeComponent();
        }

        private async void Button_Rate1_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b == null)
                return;

            if (b == Button_Rate5)
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:REVIEW?PFN=5269FriedChicken.PrimeTube-DownloaderforYouTube_cd126g1y4ee3r"));
            }
            this.Visibility = Visibility.Collapsed;
        }
    }
}
