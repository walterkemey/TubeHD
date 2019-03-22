using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;


namespace PrimeTube.APIs
{
    public class PrimeTubeAPIs
    {
        public static async Task<byte[]> GetVideoList(string URL, long nonce)
        {
            string encodedURL = WebUtility.UrlEncode(URL);
            const string videoType = "YouTube";
            const int APIVersion = 1;


            MacAlgorithmProvider obj_mac_prov = MacAlgorithmProvider.OpenAlgorithm(MacAlgorithmNames.HmacSha1);
            IBuffer buff_msg = CryptographicBuffer.CreateFromByteArray(Encoding.UTF8.GetBytes(videoType + (nonce ^ APIVersion) + URL));
            IBuffer buff_key_material = CryptographicBuffer.CreateFromByteArray(Encoding.UTF8.GetBytes(nonce.ToString()));
            CryptographicKey hmac_key = obj_mac_prov.CreateKey(buff_key_material);
            IBuffer hmac = CryptographicEngine.Sign(hmac_key, buff_msg);
  
          //  IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(videoType + (nonce ^ APIVersion) + URL, BinaryStringEncoding.Utf8);
          //  HashAlgorithmProvider hashAlgorithm = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha1);
         //   IBuffer hashBuffer = hashAlgorithm.HashData(buffer);

            var strHashBase64 = CryptographicBuffer.EncodeToBase64String(hmac);

            string FetchURL = string.Format("http://127.0.0.1/video?nonce={0}&video_url={1}&api_version={2}&serverAuthorization={3}&type={4}",
                nonce,
                encodedURL,
                APIVersion, // API Version
                strHashBase64,
                videoType
                );
            Debug.WriteLine(FetchURL);
            var handler = new HttpClientHandler();
            var req = new HttpClient(handler);

            try
            {
                HttpResponseMessage data = await req.GetAsync(FetchURL);
                HttpContent content = data.Content;
                data.EnsureSuccessStatusCode();

                byte[] ReturnData = await content.ReadAsByteArrayAsync();

                return ReturnData;
            }
            catch (Exception eex)
            {
                Debug.WriteLine(eex.ToString());
            }
            return null;
        }
    }
}
