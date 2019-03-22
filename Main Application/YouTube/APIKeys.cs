using System;
using System.Collections.Generic;
using System.Text;
using Youtube_Music_Video_Downloader__W10_;

namespace PrimeTube.YouTubeHelper
{
    public class APIKeys
    {
        #region YouTubeAPIKeys

        public const string YouTubeBaseURL = "https://www.googleapis.com/youtube/v3";

        public const string UserAgent_Chrome = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.2 Safari/537.36 Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.2 Safari/537.36";
        public const string ConnectingUserAgent = "com.google.android.youtube/10.11.55(Linux; U; Android 4.4.4; en_US; X89 (E7ED) Build/KTU84P) gzip";
        #endregion

        #region GeneralFunction
        public const string ApplicationName = "YouTube";
        private static int randomizedpos = -1;
        public static string GetRandomizedAPIKey()
        {
            if (randomizedpos == -1)
            {
                randomizedpos = new Random().Next(APIConstants.YouTubeAPIKeys.Length);
            }
            return APIConstants.YouTubeAPIKeys[randomizedpos];
        }
        public static string GetLoginAPIKey()
        {
            return APIConstants.YouTubeAPIKeys[1];
        }

        public static Tuple<string, string> GetRandomizedClientSecretAndIDPair()
        {
            int randomizedpos = new Random().Next(APIConstants.YouTubeClientSecrets.Length);

            return new Tuple<string, string>(APIConstants.YouTubeClientIds[randomizedpos], APIConstants.YouTubeClientSecrets[randomizedpos]);
        }

        public static string GetRandomizedYouTubeClientId()
        {
            return APIConstants.YouTubeClientIds[0];
        }
        #endregion

        #region WensusKeys
        public const string
            Wensus_AppId = "ef1ffba7-4a9d-437c-aa54-33149595b414",
            Wensus_PrivateId = "dca027ef-1917-44db-a639-2c89910dcb61";
        #endregion
    }
}
