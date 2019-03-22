using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace PrimeTube.Converter
{
    public class ParallaxScaleConverter : IValueConverter
    {
        const double _factor = 0.001;

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double factor;
            if (!Double.TryParse(parameter as string, out factor))
            {
                factor = _factor;
            }

            if (value is double)
            {
                return Math.Min(1.3,  1 + (double)value * factor); // for every x, increase by specified factor
            }
            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return 1;
        }
    }

}
