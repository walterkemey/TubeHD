using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeStreamAPI
{
    public class VideoInformation
    {
        /*    public static bool HasQuality(ObservableCollection<VideoInformation> data, VideoType type)
            {
                foreach (VideoInformation )
            }*/

        private string codes = null, url = null, signature = null, fallbackhost = null;
        private VideoType type = VideoType.NULL;
        private VideoQuality quality = VideoQuality.NULL;

        private bool ErrorHost = false;

        public VideoInformation(string _url, VideoType _type, string _codes, string _fallbackhost, string _signature, VideoQuality _quality)
        {
            this.url = _url;
            this.type = _type;
            this.codes = _codes;
            this.fallbackhost = _fallbackhost;
            this.signature = _signature;
            this.quality = _quality;

            // Safety check
            /*     if (url == null || type == VideoType.NULL || codes == null || fallbackhost == null || signature == null || quality == VideoQuality.NULL)
                 {
                     ErrorHost = true;
                 }*/
        }

        public string GetFullURLforVideo()
        {
            string finalSig = string.Empty;
            if (signature == null || signature == string.Empty)
                finalSig = string.Empty;
            else
                finalSig = ("&signature=" + signature);

            //  "&access_token=" + token + "&key=" + Constants.YouTubeAPIKey;
            string URL_ = string.Format("{0}{1}{2}{3}",
                url,
                finalSig,
                "",//AuthCode != null ? ("&access_token=" + AuthCode) : "",
                "");//AuthCode != null ? ("&key=" + Constants.YouTubeAPIKey) : "");

            return URL_;
        }

        public bool IsErrorHost
        {
            get { return ErrorHost; }
            set { this.ErrorHost = value; }
        }
        public string URL
        {
            get { return url; }
            set { this.url = value; }
        }
        public string Codes
        {
            get { return codes; }
            set { this.codes = value; }
        }
        public string Signature
        {
            get { return signature; }
            set { this.signature = value; }
        }
        public string FallbackHost
        {
            get { return fallbackhost; }
            set { this.fallbackhost = value; }
        }


        public string StrType
        {
            get { return type.ToString(); }
            set { }
        }
        public string StrQuality
        {
            get { return quality.ToString(); }
            set { }
        }
        public VideoType Type
        {
            get { return type; }
            set { this.type = value; }
        }
        public VideoQuality Quality
        {
            get { return quality; }
            set { this.quality = value; }
        }
    }
}
