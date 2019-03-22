using PrimeTube.Helper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace PrimeTube.Controls
{
    public class RichTextDisplay : ContentControl
    {
        public static Regex emailid = new Regex(@"^[A-Za-z0-9_\-\.]+@(([A-Za-z0-9\-])+\.)+([A-Za-z\-])+$");
        public static Regex phonenumber = new Regex(@"^(?:\(?([0-9]{3})\)?[-. ]?)?([0-9]{3})[-. ]?([0-9]{4})$");

        public static readonly DependencyProperty XamlProperty =
            DependencyProperty.Register("Xaml", typeof(string), typeof(RichTextDisplay), new PropertyMetadata(null, XamlChanged));
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(RichTextDisplay), new PropertyMetadata(null, TextChanged));
        public static readonly DependencyProperty FontProperty =
    DependencyProperty.Register("FontSize", typeof(int), typeof(RichTextDisplay), new PropertyMetadata(null, FontSizeChanged));

        public string Xaml
        {
            get { return (string)GetValue(XamlProperty); }
            set { SetValue(XamlProperty, value); }
        }

        private static void XamlChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var ctl = (RichTextDisplay)sender;
            var xaml = new System.Text.StringBuilder();
            xaml.Append(@" 
<UserControl 
  xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" 
  xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" 
  xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""> 
  <Grid> 
    <RichTextBlock>");
            xaml.Append(ctl.Xaml);
            xaml.Append(@" 
    </RichTextBlock> 
  </Grid> 
</UserControl> 
");
            var text = xaml.ToString();
            var xr = (Control)XamlReader.Load(text);

            ctl.Content = xr;
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static void TextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var ctl = (RichTextDisplay)sender;

            // create a new richtextblokc
            RichTextBlock block = new RichTextBlock();
            block.TextWrapping = TextWrapping.Wrap;
            block.IsTextSelectionEnabled = true;
            block.Foreground = new SolidColorBrush(Colors.Black);
            block.FontSize = ctl.FontSize;

            var paragraph = new Paragraph();
            var runs = new List<Inline>();

            const string newlineSeperator = " a_X_X_X_X_XS ";
            string newlineSeperator_Trimmed = newlineSeperator.Trim();

            // parse links, phone, emails
            if (ctl.Text != null)
            {
                var message = Regex.Replace((string)ctl.Text, "\n", newlineSeperator);
                string[] wordArray = message.Split(' ', '\r');

                foreach (string word in wordArray)
                {
                    Uri uri;
                    if (emailid.IsMatch(word))
                    {
                        var link = new Hyperlink();
                        link.Inlines.Add(new Run() { Text = word });
                        link.Click += link_Click;

                        runs.Add(link);

                    }
                    else if (word.Length > 5 && (Uri.TryCreate(word, UriKind.Absolute, out uri) ||
                     (word.StartsWith("www.") || word.EndsWith(".com")) && Uri.TryCreate("http://" + word, UriKind.Absolute, out uri)))
                    {
                        int colmnPosition = word.IndexOf(':');
                        if (colmnPosition != -1 && colmnPosition + 1 >= word.Length) // there's nothing inside this semicolmn.. so inteprete it as a normal text instead. [facebook:    / twitter:  ]
                        {
                            runs.Add(new Run()
                            {
                                Text = Regex.Replace(word, newlineSeperator_Trimmed, Environment.NewLine)
                            });
                        }
                        else
                        {

                            var link = new Hyperlink();
                            //         link.NavigateUri = uri;
                            link.Inlines.Add(new Run() { Text = word });
                            link.Click += linkhyper_Click;

                            runs.Add(link);
                        }
                    }
                    //string number; 
                    //number = Regex.Replace(word, "[^+0-9]", ""); 
                    else if (phonenumber.IsMatch(word))
                    {
                        int colmnPosition = word.IndexOf(':');
                        if (colmnPosition >= word.Length) // there's nothing inside this semicolmn.. so inteprete it as a normal text instead. [facebook:    / twitter:  ]
                        {
                            runs.Add(new Run()
                            {
                                Text = Regex.Replace(word, newlineSeperator_Trimmed, Environment.NewLine)
                            });
                        }
                        else
                        {
                            var link = new Hyperlink();
                            link.Inlines.Add(new Run() { Text = word });
                            link.Click += linkphone_Click;

                            runs.Add(link);
                        }
                    }
                    else
                    {
                        runs.Add(new Run()
                        {
                            Text = Regex.Replace(word, newlineSeperator_Trimmed, Environment.NewLine)
                        });
                    }

                    runs.Add(new Run() { Text = " " });
                }

                foreach (var run in runs)
                    paragraph.Inlines.Add(run);

                block.Blocks.Add(paragraph);
            }
            ctl.Content = block;

        }

        static void linkphone_Click(Hyperlink sender, HyperlinkClickEventArgs args)
        {
            var hyperLink = (sender as Hyperlink);
            //   new PhoneCallTask() { PhoneNumber = word }.Show();
        }

        private async static void linkhyper_Click(Hyperlink sender, HyperlinkClickEventArgs args)
        {
            var hyperLink = (sender as Hyperlink);

            string strUri = ((Run)hyperLink.Inlines[0]).Text;
            string videoId = null;

            if (strUri.ToLower().Contains("youtube"))
            {
                Dictionary<string, string> queryParameters = UriParameterHelper.DecodeUriParameter(strUri);

                if (queryParameters["v"] != null) // navigate within the app
                    videoId = queryParameters["v"];
            }
            else if (strUri.ToLower().Contains("://youtu.be"))
            {
                int index = strUri.IndexOf('/', strUri.IndexOf("youtu.be"));
                videoId = strUri.Substring(index + 1, strUri.Length - index - 1);
            }

            if (videoId != null)
            {
                Frame rootFrame = ((App)App.Current)?.GetRootFrame();
                if (rootFrame?.CurrentSourcePageType == typeof(MainPage))
                    ((MainPage)rootFrame.Content).LoadVideo(videoId, null, false, MainPage.NavigatingToVideoPageFrom.UrlText);
            }
            else
            {
                await Launcher.LaunchUriAsync(new Uri(strUri, UriKind.Absolute));
            }

        }

        static void link_Click(Hyperlink sender, HyperlinkClickEventArgs args)
        {
            var hyperLink = (sender as Hyperlink);
            //  new EmailComposeTask() { To = word }.Show();
        }


        private static void FontSizeChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
