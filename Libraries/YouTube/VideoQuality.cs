using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeStreamAPI
{
    public enum VideoQuality
    {
        hd1080 = 0x1,
        hd720 = 0x2,
        large = 0x4,
        medium = 0x8,

        small = 0x10,
        NULL = 0x20,
    }

    public static class VideoQualityExtensions
    {
        public static VideoQuality GetVideoQualityFromString(string str)
        {
            VideoQuality quality = VideoQuality.NULL;

            switch (str)
            {
                case "p3072":
                case "p2304":
                case "p2160":
                case "p1440":
                case "p1080":
                case "p720":
                case "p520":
                case "p480":
                case "p360":
                case "p270":
                case "p240":
                case "p224":
                case "p144":
                    break;
            }
            return quality;
        }
    }
}
