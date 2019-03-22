using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeStreamAPI
{
    public enum VideoType
    {
        video_webm = 0x1,
        video_mp4 = 0x2,

        audio_mp4 = 0x4,
        audio_webm = 0x8,

        video_x_flv = 0x10,

        video_3gpp = 0x20,
        NULL = 0x20,
    }

    public static class VideoTypeExtensions
    {
        /// <summary>
        /// Gets the file type extension by the enum
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFileExtentionByType(this VideoType type)
        {
            switch (type)
            {
                case VideoType.video_3gpp:
                    return "3gpp";
                case VideoType.video_mp4:
                    return "mp4";
                case VideoType.video_webm:
                    return "webm";
                case VideoType.video_x_flv:
                    return "flv";
                case VideoType.audio_mp4:
                    return "mp3";
            }
            return "";
        }
    }
}
