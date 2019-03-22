using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeTube.YouTube;
using YouTubeStreamAPI;

namespace PrimeTube.Helper
{
    public class FileNameHelper
    {
        /// <summary>
        /// Returns the file extension and file name
        /// </summary>
        /// <param name="destination">The destination file name</param>
        /// <param name="type"></param>
        /// <param name="quality"></param>
        /// <param name="Audioquality"></param>
        /// <returns></returns>
        public static string GetDownloadingFileName(string destination, VideoType type, VideoQuality quality, bool isMP3Conversion, bool isM4A)
        {
            if (string.IsNullOrWhiteSpace(destination) || type == VideoType.NULL)
                return null;

            destination = destination.Replace(" - YouTube", "");
            char[] escape = @"\/:*?""<>|.'".ToCharArray();
            for (int i = 0; i < escape.Length; i++)
            {
                destination = destination.Replace(escape[i], (char)32);
            }

            string FileExtension = isMP3Conversion ? (isM4A ? ".m4a" : ".mp3") : ("." + type.GetFileExtentionByType());
            if (FileExtension == null || FileExtension == string.Empty)
                return null;

            destination = destination.Substring(0, Math.Min(destination.Length, 50));
            destination += "_" + quality.ToString() + FileExtension;

            return destination;
        }
    }
}
