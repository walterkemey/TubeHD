using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PrimeTube.YouTubeHelper;

namespace PrimeTube.YouTube
{
    public class YoutubeService
    {
        // init youtube service
        public static Google.Apis.Services.BaseClientService.Initializer baseserv = new BaseClientService.Initializer()
        {
            ApiKey = APIKeys.GetRandomizedAPIKey(),
            ApplicationName = APIKeys.ApplicationName, 
        };

        private static YouTubeService _service;
        public static YouTubeService service
        {
            get {
                if (_service == null)
                {
                    _service = new YouTubeService(baseserv);
                }
                return _service;
            }

            set { }
        }

        public static async Task<bool> RefreshAuthorizationTokenIfRequired()
        {
            long lastSetTime = ApplicationSetting.GetLocalSetting_Long("google_token_expiresTime", 0);
            if (lastSetTime != 0)
            {
                long now = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
                if (now > lastSetTime)
                {
                    // expired
                    string FetchURL = "https://accounts.google.com/o/oauth2/token";

                    var handler = new HttpClientHandler();
                    var req = new HttpClient(handler);


                    Tuple<string, string> keypair = APIKeys.GetRandomizedClientSecretAndIDPair();
                    string pdata = string.Format("client_id={0}&client_secret={1}&refresh_token={2}&grant_type=refresh_token",
                        keypair.Item1,
                        keypair.Item2,
                        await ApplicationSetting.GetEncryptedLocalStringValueOrDefault("google_refresh_token", ""));
                    StringContent strc = new StringContent(pdata, Encoding.UTF8, "application/x-www-form-urlencoded");
                    try
                    {
                        HttpResponseMessage data = await req.PostAsync(FetchURL, strc);
                        HttpContent content = data.Content;
                        data.EnsureSuccessStatusCode();

                        // {"access_token":"1/fFAGRNJru1FTz70BzhT3Zg","expires_in":3920,"token_type":"Bearer"}
                        JObject token = JObject.Parse(await content.ReadAsStringAsync());

                        /*   string access_token = (string) token["access_token"];
                           string token_type = (string)token["token_type"];
                           int expires_in = (int)token["expires_in"];
                           string refresh_token = (string)token["refresh_token"];

                           Debug.WriteLine(ReturnData);*/
                        await ApplicationSetting.SetUpdateLocalValueEncrypted("google_access_token", (string)token["access_token"]);
                        ApplicationSetting.SetLocalSetting("google_token_expiresTime", (long)now + (((long)token["expires_in"] - 5L) * 60L));

                        return true;
                    }
                    catch (Exception eex)
                    {
                        Debug.WriteLine(eex.ToString());
                    }
                    return false;
                }
                else
                {
                    // not expired, do nothing.
                }
            }
            return true;
        }

        public static async Task<JObject> ExchangeAuthorizationToken(string authorizationToken)
        {
            string FetchURL = "https://accounts.google.com/o/oauth2/token"; 

            var handler = new HttpClientHandler();
            var req = new HttpClient(handler);


            Tuple<string, string> keypair = APIKeys.GetRandomizedClientSecretAndIDPair();
            string pdata = string.Format("code={0}&client_id={1}&client_secret={2}&redirect_uri=urn:ietf:wg:oauth:2.0:oob&grant_type=authorization_code",
                authorizationToken,
                keypair.Item1,
                keypair.Item2);
            StringContent strc = new StringContent(pdata, Encoding.UTF8, "application/x-www-form-urlencoded");
            try
            {
                HttpResponseMessage data = await req.PostAsync(FetchURL, strc);
                HttpContent content = data.Content;
                data.EnsureSuccessStatusCode();

                string ReturnData = await content.ReadAsStringAsync();
                // "{\n  \"access_token\" : \"ya29.7gEujvKt67YIpX4sWE_vJMAHwcvEU7ZYdYUPDo56iNhSgSZnGVUiohJU-imIoEHyzl5T\",\n  \"token_type\" : \"Bearer\",\n  \"expires_in\" : 3600,\n  \"refresh_token\" : \"1/nelJL_l2PzLMdr9E6-Kg3g7tHFlaXv6jVf1HxjwUOKM\"\n}"
                JObject token = JObject.Parse(ReturnData);
             /*   string access_token = (string) token["access_token"];
                string token_type = (string)token["token_type"];
                int expires_in = (int)token["expires_in"];
                string refresh_token = (string)token["refresh_token"];

                Debug.WriteLine(ReturnData);*/

                return token;
            }
            catch (Exception eex)
            {
                Debug.WriteLine(eex.ToString());
            }
            return null;
        }
    }
}
