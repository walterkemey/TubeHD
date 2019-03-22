using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PrimeTube.Converter
{

    public class MaxLikesDislikesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            VideoStatistics stats = (VideoStatistics)value;

            return stats.LikeCount + stats.DislikeCount;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotSupportedException();
        }
    }
}
