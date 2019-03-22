using Jint;
using Jint.Native;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YouTubeStreamAPI.Helpers;

namespace YouTubeStreamAPI
{
    public class YouTubeStream
    {
        private ObservableCollection<VideoInformation> _VideoInfo = new ObservableCollection<VideoInformation>();
        public ObservableCollection<VideoInformation> VideoInfo
        {
            get { return _VideoInfo; }
            private set { }
        }
        private ObservableCollection<VideoInformation> _VideoInfo_adaptive_fmts = new ObservableCollection<VideoInformation>();
        public ObservableCollection<VideoInformation> VideoInfo_adaptive_fmts
        {
            get { return _VideoInfo_adaptive_fmts; }
            private set { }
        }

        // Javascript intepreter
        private static Engine JavascriptEngine = null;
        private static string DecodeFuncName = string.Empty, DecodeScript = string.Empty;

        public YouTubeStream(string _VideoID)
        {
            this.VideoID = _VideoID;
        }

        private string _VideoID;
        public string VideoID
        {
            get { return _VideoID; }
            set { this._VideoID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="videoid"></param>
        /// <returns>string empty if everything's fine. Otherwise the error code</returns>
        public async Task<string> LoadVideoStreamData()
        {
            if (VideoID == null)
            {
                throw new Exception("Video ID is not set.");
            }

            // clear etc
            VideoInfo.Clear();
            VideoInfo_adaptive_fmts.Clear();

            JavascriptEngine = null;
            DecodeFuncName = string.Empty;
            DecodeScript = string.Empty;

            // string requestUri = string.Format("https://www.youtube.com/watch?v={0}&nomobile=1&gl=US&hl=en&has_verified=1&bpctr=9999999999", this.VideoID);
            string requestUri = string.Format("https://www.youtube.com/watch?v={0}", this.VideoID);

            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                var req2 = new HttpClient(handler);
                var message2 = new HttpRequestMessage(HttpMethod.Get, requestUri);

                message2.Headers.Add("Host", "www.youtube.com");
                message2.Headers.Add("User-Agent",YoutubeStreamAPIConstants.RandomHTTPUserAgent());

                //bool TokenHeaderAdded2 = YouTubeUserHandler.AddAccessTokenIfAvailable(message2);

                try
                {
                    HttpResponseMessage data = await req2.SendAsync(message2);
                    HttpContent content = data.Content;
                    data.EnsureSuccessStatusCode();

                    string SourceCode = await content.ReadAsStringAsync();

                    string retResult = await ParseStreamsInternal(SourceCode);
                    return retResult;
                }
                catch (Exception eex)
                {
                    Debug.WriteLine(eex.ToString());
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
            }
            return "";
        }

        /// <summary>
        /// Parses the source code of the YouTube page eg: http://youtube.com?v=dsfds
        /// </summary>
        /// <param name="SourceCode"></param>
        /// <returns></returns>
        private async Task<string> ParseStreamsInternal(string SourceCode)
        {
            string response = null, response2 = string.Empty, response_adaptive_fmt = string.Empty;
            Exception eeeee = null;
            bool found = false;

            try
            {
                string start = "ytplayer.config = {";
                //Debug.WriteLine(SourceCode);
                int ytPlayerStartIndex = SourceCode.IndexOf(start, 0);
                if (ytPlayerStartIndex != -1)
                {
                    int VideoInfoStart = -1;

                    const string start_text = "url_encoded_fmt_stream_map\":\"";
                    VideoInfoStart = SourceCode.IndexOf(start_text, ytPlayerStartIndex);
                    if (VideoInfoStart != -1)
                    {
                        VideoInfoStart += start_text.Length;

                        int end = SourceCode.IndexOf((char)34, VideoInfoStart);
                        response2 = SourceCode.Substring(VideoInfoStart, end - VideoInfoStart);
                        response2 = response2.Replace("\\/", "/");
                        response2 = WebUtility.HtmlDecode(response2); // or WebUtility.HtmlDecode
                        response2 = Regex.Replace(response2, @"\\u(?<code>\d{4})", RegexHelper.CharMatch);

                        found = true;
                    }
                    VideoInfoStart = -1;


                    string[] start_text_adaptive = { @"""adaptive_fmts"": """ , "adaptive_fmts\":\"" };
                    foreach (string adaptive_str in start_text_adaptive)
                    {
                        VideoInfoStart = SourceCode.IndexOf(adaptive_str, ytPlayerStartIndex);
                        if (VideoInfoStart != -1)
                        {
                            VideoInfoStart += adaptive_str.Length;
                            int end = SourceCode.IndexOf((char)34, VideoInfoStart);
                            response_adaptive_fmt = SourceCode.Substring(VideoInfoStart, end - VideoInfoStart);
                            response_adaptive_fmt = response_adaptive_fmt.Replace("\\/", "/");
                            response_adaptive_fmt = WebUtility.HtmlDecode(response_adaptive_fmt); // or WebUtility.HtmlDecode
                            response_adaptive_fmt = Regex.Replace(response_adaptive_fmt, @"\\u(?<code>\d{4})", RegexHelper.CharMatch);
                            break;
                        }
                    }

                    // Here for updating the signature encryption key
                    string HTML5PlayerSourceCode = await YouTubeHTML5Player.GetHTML5PlayerJSFromYouTubePageSource(SourceCode);
                    if (HTML5PlayerSourceCode != null)
                    {
                        if (HTML5PlayerSourceCode != string.Empty)  // Not the same signature as the last
                        {
                            DecodeFuncName = YouTubeHTML5Player.GetDecodeFunction(HTML5PlayerSourceCode);
                            DecodeScript = YouTubeHTML5Player.ExtractDecodeFunction(HTML5PlayerSourceCode, DecodeFuncName);

                            if (DecodeFuncName != null && DecodeScript != null)
                            {
                                // Initialize javascript engine
                                JavascriptEngine = new Engine();
                                JavascriptEngine.Execute(DecodeScript);
                            }
                        }
                    }
                }
            }
            catch (Exception eeess)
            {
                eeeee = eeess;
            }
            if (eeeee != null || !found)
            {
                return "Error acquiring stream data " + eeeee.Message;
            }

            Exception eax1 = null;
            Exception eax2 = null;

            eax1 = ParseYouTubeStreamData(response2, true, VideoInfo, false);
            eax2 = ParseYouTubeStreamData(response_adaptive_fmt, true, VideoInfo_adaptive_fmts, false);
            return "";
        }

        private static Exception ParseYouTubeStreamData(string response, bool SourceFromWebSourceCode, ObservableCollection<VideoInformation> AllInfo, bool DesktopMode)
        {
            // Make sure the HTML5 player is loaded correctly.


            // url, type, fallback_host, sig, quality
            bool[] CheckingData = { false, false, false, false, false };

            Exception eax = null;
            try
            {
                string[] indi = response.Split('&');
                //            throw new Exception();
                // For the Source Code based

                string startType2 = null;
                string codes2 = null, url2 = null, signature2 = null, fallbackhost2 = null;
                VideoType type2 = VideoType.NULL;
                VideoQuality quality2 = VideoQuality.NULL;

                foreach (string x in indi)
                {
                    if (x.StartsWith("url_encoded_fmt_stream_map") || SourceFromWebSourceCode)
                    {
                        if (SourceFromWebSourceCode)
                        {
                            string esc1 = Uri.UnescapeDataString(x);
                            //Debug.WriteLine(esc1);
                            if (startType2 == null)
                            {
                                int equalIndex = esc1.IndexOf("=", 0);
                                if (equalIndex != -1)
                                {
                                    startType2 = esc1.Substring(0, equalIndex);
                                }
                            }

                            // Check for quality string, google is being sneaky..
                            int index = 0;
                            int tmpindex = 0;
                            while (tmpindex >= 0 && tmpindex < esc1.Length && (tmpindex = esc1.IndexOf(",", tmpindex + 1)) > 0)
                            {
                                index = tmpindex;

                                string after = Uri.UnescapeDataString(esc1.Substring(index + 1, esc1.Length - (index + 1)));

                                bool found = false;

                                if (after.StartsWith("url="))
                                {
                                    ParseYouTubeInfoURL(startType2, after, CheckingData, AllInfo, out url2, type2, codes2, fallbackhost2, signature2, quality2);
                                    found = true;
                                }
                                else if (after.StartsWith("type="))
                                {
                                    ParseYouTubeInfoType(startType2, after, CheckingData, AllInfo, url2, out type2, out codes2, fallbackhost2, signature2, quality2);
                                    found = true;
                                }
                                else if (after.StartsWith("fallback_host="))
                                {
                                    ParseYouTubeInfo_FallBackHost(startType2, after, CheckingData, AllInfo, url2, type2, codes2, out fallbackhost2, signature2, quality2);
                                    found = true;
                                }
                                else if (after.StartsWith("sig=") || after.StartsWith("s=") || after.StartsWith("signature="))
                                {
                                    ParseYouTubeInfo_Signature(startType2, after, CheckingData, AllInfo, url2, type2, codes2, fallbackhost2, out signature2, quality2);
                                    found = true;
                                }
                                else if (after.StartsWith("size="))
                                {
                                    ParseYouTubeInfo_Quality(startType2, after, CheckingData, AllInfo, url2, type2, codes2, fallbackhost2, signature2, out quality2);
                                    found = true;
                                }
                                else if (after.StartsWith("quality="))
                                {
                                    ParseYouTubeInfo_Quality(startType2, after, CheckingData, AllInfo, url2, type2, codes2, fallbackhost2, signature2, out quality2);
                                    found = true;
                                }
                                else if (after.StartsWith("itag="))
                                {
                                    found = true;
                                }

                                // remove if required
                                if (found)
                                    esc1 = esc1.Substring(0, index);
                            }
                            string decoded = Uri.UnescapeDataString(esc1);

                            //                Debug.WriteLine(decoded);
                            if (decoded.StartsWith("url="))
                            {
                                ParseYouTubeInfoURL(startType2, decoded, CheckingData, AllInfo, out url2, type2, codes2, fallbackhost2, signature2, quality2);
                            }
                            else if (decoded.StartsWith("type="))
                            {
                                ParseYouTubeInfoType(startType2, decoded, CheckingData, AllInfo, url2, out type2, out codes2, fallbackhost2, signature2, quality2);
                            }
                            else if (decoded.StartsWith("fallback_host="))
                            {
                                ParseYouTubeInfo_FallBackHost(startType2, decoded, CheckingData, AllInfo, url2, type2, codes2, out fallbackhost2, signature2, quality2);
                            }
                            else if (decoded.StartsWith("sig=") || decoded.StartsWith("s=") || decoded.StartsWith("signature="))
                            {
                                ParseYouTubeInfo_Signature(startType2, decoded, CheckingData, AllInfo, url2, type2, codes2, fallbackhost2, out signature2, quality2);
                            }
                            else if (decoded.StartsWith("quality="))
                            {
                                ParseYouTubeInfo_Quality(startType2, decoded, CheckingData, AllInfo, url2, type2, codes2, fallbackhost2, signature2, out quality2);
                            }
                            else if (decoded.StartsWith("size="))
                            {
                                ParseYouTubeInfo_Quality(startType2, decoded, CheckingData, AllInfo, url2, type2, codes2, fallbackhost2, signature2, out quality2);
                            }
                        }
                        else
                        {
                            string codes = null, url = null, signature = null, fallbackhost = null;
                            string startType = null;
                            VideoType type = VideoType.NULL;
                            VideoQuality quality = VideoQuality.NULL;

                            string header = "url_encoded_fmt_stream_map=";
                            string x3 = Uri.UnescapeDataString(WebUtility.HtmlDecode(x.Substring(header.Length, x.Length - header.Length)));
                            string[] indi2 = x3.Split('&');

                            //Debug.WriteLine(x3);

                            foreach (string x2 in indi2)
                            {
                                string esc1 = Uri.UnescapeDataString(x2);
                                //Debug.WriteLine(esc1);
                                if (startType == null)
                                {
                                    int equalIndex = esc1.IndexOf("=", 0);
                                    if (equalIndex != -1)
                                    {
                                        startType = esc1.Substring(0, equalIndex);
                                    }
                                }

                                // Check for quality string, google is being sneaky..
                                int index = 0;
                                int tmpindex = 0;
                                while (tmpindex >= 0 && tmpindex < esc1.Length && (tmpindex = esc1.IndexOf(",", tmpindex + 1)) > 0)
                                {
                                    index = tmpindex;

                                    string after = esc1.Substring(index + 1, esc1.Length - (index + 1));
                                    after = Uri.UnescapeDataString(after);

                                    bool found = false;

                                    if (after.StartsWith("url="))
                                    {
                                        ParseYouTubeInfoURL(startType, after, CheckingData, AllInfo, out url, type, codes, fallbackhost, signature, quality);
                                        found = true;
                                    }
                                    else if (after.StartsWith("type="))
                                    {
                                        ParseYouTubeInfoType(startType, after, CheckingData, AllInfo, url, out type, out codes, fallbackhost, signature, quality);
                                        found = true;
                                    }
                                    else if (after.StartsWith("fallback_host="))
                                    {
                                        ParseYouTubeInfo_FallBackHost(startType, after, CheckingData, AllInfo, url, type, codes, out fallbackhost, signature, quality);
                                        found = true;
                                    }
                                    else if (after.StartsWith("sig=") || after.StartsWith("s=") || after.StartsWith("signature="))
                                    {
                                        ParseYouTubeInfo_Signature(startType, after, CheckingData, AllInfo, url, type, codes, fallbackhost, out signature, quality);
                                        found = true;
                                    }
                                    else if (after.StartsWith("quality="))
                                    {
                                        ParseYouTubeInfo_Quality(startType, after, CheckingData, AllInfo, url, type, codes, fallbackhost, signature, out quality);
                                        found = true;
                                    }
                                    else if (after.StartsWith("itag="))
                                    {
                                        found = true;
                                    }

                                    // remove if required
                                    if (found)
                                        esc1 = esc1.Substring(0, index);
                                }
                                string esc2 = Uri.UnescapeDataString(esc1);
                                string decoded = esc2;

                                if (decoded.StartsWith("url="))
                                {
                                    ParseYouTubeInfoURL(startType, decoded, CheckingData, AllInfo, out url, type, codes, fallbackhost, signature, quality);
                                }
                                else if (decoded.StartsWith("type="))
                                {
                                    ParseYouTubeInfoType(startType, decoded, CheckingData, AllInfo, url, out type, out codes, fallbackhost, signature, quality);
                                }
                                else if (decoded.StartsWith("fallback_host="))
                                {
                                    ParseYouTubeInfo_FallBackHost(startType, decoded, CheckingData, AllInfo, url, type, codes, out fallbackhost, signature, quality);
                                }
                                else if (decoded.StartsWith("sig=") || decoded.StartsWith("s=") || decoded.StartsWith("signature="))
                                {
                                    ParseYouTubeInfo_Signature(startType, decoded, CheckingData, AllInfo, url, type, codes, fallbackhost, out signature, quality);
                                }
                                else if (decoded.StartsWith("quality="))
                                {
                                    ParseYouTubeInfo_Quality(startType, decoded, CheckingData, AllInfo, url, type, codes, fallbackhost, signature, out quality);
                                }
                                else if (decoded.StartsWith("itag="))
                                {
                                    // empty
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ecs)
            {
                //AzureOperation.InsertReportItem("APIs_VideoStream.ParseYouTubeStreamData", ecs.ToString());
                eax = ecs;
                Debug.WriteLine(ecs.ToString());
            }
            return eax;
        }

        private static void CheckAndAddWhenFull(string startType, string decoded, bool[] CheckingData, int pos, ObservableCollection<VideoInformation> AllInfo, string url2, VideoType type2, string codes2, string fallbackhost2, string signature2, VideoQuality quality2)
        {
            /*         if (decoded.Contains(startType))
                     {
                         // reset if already exist.
                         for (int i = 0; i < CheckingData.Length; i++)
                         {
                             CheckingData[i] = false;
                         }
                     }*/
            if (!CheckingData[pos])
            {
                CheckingData[pos] = true;

                foreach (bool x in CheckingData)
                {
                    if (!x)
                        return; // one not added yet
                }
                // All full
                AllInfo.Add(new VideoInformation(url2, type2, codes2, fallbackhost2, signature2, quality2));

                // reset required counter
                for (int i = 0; i < CheckingData.Length; i++)
                {
                    CheckingData[i] = false;
                }
            }
        }

        private static void ParseYouTubeInfoURL(string startType, string decoded, bool[] CheckingData, ObservableCollection<VideoInformation> AllInfo, out string url, VideoType type, string codes, string fallbackhost, string signature, VideoQuality quality)
        {
            //Debug.WriteLine(decoded);

            url = decoded.Substring(4, decoded.Length - 4);

            if (AllInfo.Count > 0)
            {
                foreach (VideoInformation info in AllInfo)
                {
                    if (info.URL == null)
                    {
                        info.URL = url;
                        return;
                    }
                }
            }
            AllInfo.Add(new VideoInformation(url, VideoType.NULL, null, null, null, VideoQuality.NULL));

            //         CheckAndAddWhenFull(startType, decoded, CheckingData, 0, AllInfo, url, type, codes, fallbackhost, signature, quality);
        }

        private static void ParseYouTubeInfoType(string startType, string decoded, bool[] CheckingData, ObservableCollection<VideoInformation> AllInfo, string url, out VideoType type, out string codes, string fallbackhost, string signature, VideoQuality quality)
        {
            //Debug.WriteLine(decoded);

            string[] t2 = decoded.Substring(5, decoded.Length - 5).Split(';');
            string tt2 = t2[0];
            if (t2.Length > 1)
            {
                codes = t2[1];
                codes = codes.Substring(0, codes.Length - 1);
                codes = codes.Substring(9, codes.Length - 9);
            }
            else
                codes = ""; // Mostly for FLV video

            tt2 = tt2.Replace('/', '_').Replace('-', '_');

            try
            {
                type = (VideoType)Enum.Parse(typeof(VideoType), tt2); // type=video/webm;+codecs="vp8.0,+vorbis"
            }
            catch (Exception eee)
            {
                type = VideoType.NULL;
                Debug.WriteLine("Unknown video type: " + tt2);
            }

            if (AllInfo.Count > 0)
            {
                foreach (VideoInformation info in AllInfo)
                {
                    if (info.Type == VideoType.NULL)
                    {
                        info.Codes = codes;
                        info.Type = type;
                        return;
                    }
                }
            }
            AllInfo.Add(new VideoInformation(null, type, codes, null, null, VideoQuality.NULL));

            //        CheckAndAddWhenFull(startType, decoded, CheckingData, 1, AllInfo, url, type, codes, fallbackhost, signature, quality);
        }

        private static void ParseYouTubeInfo_FallBackHost(string startType, string decoded, bool[] CheckingData, ObservableCollection<VideoInformation> AllInfo, string url, VideoType type, string codes, out string fallbackhost, string signature, VideoQuality quality)
        {
            //Debug.WriteLine(decoded);

            fallbackhost = decoded.Substring(14, decoded.Length - 14); // fallback_host=tc.v19.cache8.c.youtube.com

            if (AllInfo.Count > 0)
            {
                foreach (VideoInformation info in AllInfo)
                {
                    if (info.FallbackHost == null)
                    {
                        info.FallbackHost = fallbackhost;
                        return;
                    }
                }
            }
            AllInfo.Add(new VideoInformation(null, VideoType.NULL, null, fallbackhost, null, VideoQuality.NULL));

            //        CheckAndAddWhenFull(startType, decoded, CheckingData, 2, AllInfo, url, type, codes, fallbackhost, signature, quality);
        }

        /// <summary>
        /// https://github.com/rg3/youtube-dl/blob/master/youtube_dl/extractor/youtube.py
        /// </summary>
        /// <param name="startType"></param>
        /// <param name="decoded"></param>
        /// <param name="CheckingData"></param>
        /// <param name="AllInfo"></param>
        /// <param name="url"></param>
        /// <param name="type"></param>
        /// <param name="codes"></param>
        /// <param name="fallbackhost"></param>
        /// <param name="signature"></param>
        /// <param name="quality"></param>
        private static void ParseYouTubeInfo_Signature(string startType, string decoded, bool[] CheckingData, ObservableCollection<VideoInformation> AllInfo, string url, VideoType type, string codes, string fallbackhost, out string signature, VideoQuality quality)
        {
            //Debug.WriteLine(decoded);

            if (decoded.StartsWith("signature="))
            {
                signature = decoded.Substring(10, decoded.Length - 10);
            }
            if (decoded.StartsWith("sig="))
            {
                signature = decoded.Substring(4, decoded.Length - 4);
            }
            else if (decoded.StartsWith("s="))
            {
                signature = decoded.Substring(2, decoded.Length - 2);
            }
            else
            {
                int IndexOfEqual = decoded.IndexOf('=');
                signature = decoded.Substring(IndexOfEqual + 1, decoded.Length - (IndexOfEqual + 1));
            }
            if (JavascriptEngine != null)
            {
                JsValue retValue = JavascriptEngine.Invoke(DecodeFuncName, signature);

                signature = retValue.AsString();
            }
            else
            {
                signature = new DecryptSignature(signature).decrypt();
            }
            /*    if (SignatureDecodeArray.Count == 0)
                {
                    SignatureDecodeArray.Add(92, new short[] { -2, 0, -3, 9, -3, 43, -3, 0, 23 });
                    SignatureDecodeArray.Add(88, new short[] { -2, 1, 10, 0, -2, 23, -3, 15, 34 });
                    SignatureDecodeArray.Add(87, new short[] { -3, 0, 63, -2, 0, -1 });
                    SignatureDecodeArray.Add(85, new short[] { 0, -2, 17, 61, 0, -1, 7, -1 });
                    SignatureDecodeArray.Add(83, new short[] { 24, 53, -2, 31, 4 });
                    SignatureDecodeArray.Add(81, new short[] { 34, 29, 9, 0, 39, 24 });
                }
                if (SignatureDecodeArray.ContainsKey(signature.Length))
                {
                    signature = ParseYouTubeEncoding(signature, SignatureDecodeArray[signature.Length]);
                }*/

            if (AllInfo.Count > 0)
            {
                foreach (VideoInformation info in AllInfo)
                {
                    if (info.Signature == null)
                    {
                        info.Signature = signature;
                        return;
                    }
                }
            }
            AllInfo.Add(new VideoInformation(null, VideoType.NULL, null, null, signature, VideoQuality.NULL));

            //         CheckAndAddWhenFull(startType, decoded, CheckingData, 3, AllInfo, url, type, codes, fallbackhost, signature, quality);
        }

        private static void ParseYouTubeInfo_Quality(string startType, string decoded, bool[] CheckingData, ObservableCollection<VideoInformation> AllInfo, string url, VideoType type, string codes, string fallbackhost, string signature, out VideoQuality quality)
        {
            //Debug.WriteLine(decoded);
            int EqualIndex = decoded.IndexOf('=') + 1;
            string q2 = decoded.Substring(EqualIndex, decoded.Length - EqualIndex).Split(',')[0]; // hd1080,itag=37

            q2 = q2.Replace('/', '_').Replace('-', '_');

            try
            {
                quality = (VideoQuality)Enum.Parse(typeof(VideoQuality), q2);
            }
            catch (Exception eee)
            {
                switch (q2)
                {
                    case "1920x1080":
                        quality = VideoQuality.hd1080;
                        break;
                    case "1280x720":
                        quality = VideoQuality.hd720;
                        break;
                    case "854x480":
                    case "640x480":
                        quality = VideoQuality.large;
                        break;
                    case "640x360":
                    case "480x360":
                        quality = VideoQuality.medium;
                        break;
                    case "320x240":
                    case "426x240":
                    case "256x144":
                    case "192x144":
                        quality = VideoQuality.small;
                        break;
                    default:
                        quality = VideoQuality.NULL;
                        Debug.WriteLine("Unknown quality: " + q2);
                        break;
                }
            }

            // Quality is the last.
            // quality isn't the last anymore, after the recent youtube changes

            if (AllInfo.Count > 0)
            {
                foreach (VideoInformation info in AllInfo)
                {
                    if (info.Quality == VideoQuality.NULL)
                    {
                        info.Quality = quality;
                        return;
                    }
                }
            }
            AllInfo.Add(new VideoInformation(null, VideoType.NULL, null, null, null, quality));

            //         CheckAndAddWhenFull(startType, decoded, CheckingData, 4, AllInfo, url, type, codes, fallbackhost, signature, quality);
        }

        private static string ParseYouTubeEncoding(string sig, short[] arr)// encoded decryption
        {
            char[] sigA = sig.ToCharArray();

            for (var i = 0; i < arr.Length; i++)
            {
                short act = arr[i];

                if (act > 0)
                {
                    sigA = SwapStr(sigA, act);
                }
                else
                {
                    if (act == 0)
                        sigA = sigA.Reverse().ToArray();
                    else
                    {
                        int act2 = -act;

                        sigA = act2 > 0 ? sigA.Slice(act2, sigA.Length).ToArray() : sigA.Slice(0, act2).ToArray();
                    }
                }
            }
            string res = string.Concat(sigA);
            return (res.Length == 81) ? res : sig;
        }

        private static char[] SwapStr(char[] a, int b)
        {
            var c = a[0];
            a[0] = a[b % a.Length];
            a[b] = c;
            return a;
        }

        private class DecryptSignature
        {
            public String sig;

            public DecryptSignature(String signature)
            {
                this.sig = signature;
            }

            String s(int b, int e)
            {
                return sig.Substring(b, e - b);
            }

            String s(int b)
            {
                return sig.Substring(b, (b + 1) - b);
            }

            String se(int b)
            {
                return s(b, sig.Length);
            }

            String s(int b, int e, int step)
            {
                String str = "";

                while (b != e)
                {
                    str += sig[b];
                    b += step;
                }
                return str;
            }

            // https://github.com/rg3/youtube-dl/blob/master/youtube_dl/extractor/youtube.py
            public String decrypt()
            {
                switch (sig.Length)
                {
                    case 93:
                        return s(86, 29, -1) + s(88) + s(28, 5, -1);
                    case 92:
                        return s(25) + s(3, 25) + s(0) + s(26, 42) + s(79) + s(43, 79) + s(91) + s(80, 83);
                    case 91:
                        return s(84, 27, -1) + s(86) + s(26, 5, -1);
                    case 90:
                        return s(25) + s(3, 25) + s(2) + s(26, 40) + s(77) + s(41, 77) + s(89) + s(78, 81);
                    case 89:
                        return s(84, 78, -1) + s(87) + s(77, 60, -1) + s(0) + s(59, 3, -1);
                    case 88:
                        return s(7, 28) + s(87) + s(29, 45) + s(55) + s(46, 55) + s(2) + s(56, 87) + s(28);
                    case 87:
                        return s(6, 27) + s(4) + s(28, 39) + s(27) + s(40, 59) + s(2) + se(60);
                    case 86:
                        return s(80, 72, -1) + s(16) + s(71, 39, -1) + s(72) + s(38, 16, -1) + s(82) + s(15, 0, -1);
                    case 85:
                        return s(3, 11) + s(0) + s(12, 55) + s(84) + s(56, 84);
                    case 84:
                        return s(78, 70, -1) + s(14) + s(69, 37, -1) + s(70) + s(36, 14, -1) + s(80) + s(0, 14, -1);
                    case 83:
                        return s(80, 63, -1) + s(0) + s(62, 0, -1) + s(63);
                    case 82:
                        return s(80, 37, -1) + s(7) + s(36, 7, -1) + s(0) + s(6, 0, -1) + s(37);
                    case 81:
                        return s(56) + s(79, 56, -1) + s(41) + s(55, 41, -1) + s(80) + s(40, 34, -1) + s(0) + s(33, 29, -1)
                                + s(34) + s(28, 9, -1) + s(29) + s(8, 0, -1) + s(9);
                    case 80:
                        return s(1, 19) + s(0) + s(20, 68) + s(19) + s(69, 80);
                    case 79:
                        return s(54) + s(77, 54, -1) + s(39) + s(53, 39, -1) + s(78) + s(38, 34, -1) + s(0) + s(33, 29, -1)
                                + s(34) + s(28, 9, -1) + s(29) + s(8, 0, -1) + s(9);
                }

                throw new Exception(
                        "Unable to decrypt signature, key length " + sig.Length + " not supported; retrying might work");
            }
        }

        private static Dictionary<int, short[]> SignatureDecodeArray = new Dictionary<int, short[]>();
    }
}
