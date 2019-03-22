using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PrimeTube.YouTube;
using PrimeTube.YouTubeHelper;

namespace PrimeTube.YouTube
{
    public class YouTubeAuthenticatedAPI
    {
        public static async Task<Object> RequestedAuthenticatedAPICall(string url, Type type)
        {
            // Authenticated parameters\
            string apiKey = APIKeys.GetLoginAPIKey();
            string accessToken = await ApplicationSetting.GetEncryptedLocalStringValueOrDefault("google_access_token", null);
            if (apiKey == null || accessToken == null)
            {
                return null;
            }
            // Refresh auth key if required
            if (!await YoutubeService.RefreshAuthorizationTokenIfRequired())
            {
                return null;
            }

            // HTTP
            var handler = new HttpClientHandler();
            var req = new HttpClient(handler);

            req.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            string FetchURL = string.Format("{0}&key={1}", url, apiKey);
            handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            try
            {
                HttpResponseMessage data = await req.GetAsync(FetchURL);
                HttpContent content = data.Content;
                data.EnsureSuccessStatusCode();

                string ReturnData = await content.ReadAsStringAsync();
                // Debug.WriteLine(ReturnData);

                if (ReturnData == null)
                    return null;

                Object obj = JsonConvert.DeserializeObject(ReturnData, type);

                return obj;
            }
            catch (Exception eex)
            {
                Debug.WriteLine(eex.ToString());
            }
            return null;
        }
    }
}
