using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace PrimeTube.Converter
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            var dateTime = (DateTime)value;


            return dateTime.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotSupportedException();
        }
    }
}
