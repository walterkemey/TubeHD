using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using System.IO;

namespace PrimeTube.Helper
{
    public class SecondaryTileHelper
    {
        /// <summary>
        /// Copies an image from the internet (http protocol) locally to the AppData LocalFolder.  This is used by some methods 
        /// (like the SecondaryTile constructor) that do not support referencing images over http but can reference them using 
        /// the ms-appdata protocol.  
        /// </summary>
        /// <param name="internetUri">The path (URI) to the image on the internet</param>
        /// <param name="uniqueName">A unique name for the local file</param>
        /// <returns>Path to the image that has been copied locally</returns>
        public static async Task<Uri> GetLocalImageAsync(string internetUri, string uniqueName)
        {
            if (string.IsNullOrEmpty(internetUri))
            {
                return new Uri("ms-appx:///Assets/Square150x150Logo.scale-200.png", UriKind.Absolute);
            }

            using (var response = await HttpWebRequest.CreateHttp(internetUri).GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    var desiredName = string.Format("{0}.jpg", uniqueName);
                    StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(desiredName, CreationCollisionOption.ReplaceExisting);

                    using (IRandomAccessStream filestream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        await stream.CopyToAsync(filestream.AsStream());
                        return new Uri(string.Format("ms-appdata:///local/{0}.jpg", uniqueName), UriKind.Absolute);
                    }
                }
            }
        }
    }
}
