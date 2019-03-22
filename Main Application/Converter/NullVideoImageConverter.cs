using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace PrimeTube.Converter
{
    public class NullVideoImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            string imagesource = (string)value;

            if (imagesource == null)
            {
                return "ms-appx:///Assets/YouTube/api_btn_unavailable.png";
            }
            return imagesource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotSupportedException();
        }
    }
}