using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace PrimeTube.Converter
{
    public class IntegerCommasSeperatorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            return string.Format("{0:###,###,###,###,###}", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotSupportedException();
        }
    }
}
