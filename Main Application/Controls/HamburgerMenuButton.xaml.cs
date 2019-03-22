using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using Windows.UI.Xaml.Controls;

namespace YouTube_Universal.Controls
{
    public partial class HamburgerMenuButton : UserControl
    {
        // A delegate type for hooking up change notifications.
        public delegate void TappedEventHandler(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e);

        public event TappedEventHandler MenuTapped;

        public HamburgerMenuButton()
        {
            InitializeComponent();

        }

        private void button1_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (MenuTapped != null)
                MenuTapped(sender, e);
        }
    }
}
