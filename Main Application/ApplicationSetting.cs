using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.DataProtection;
using Windows.Storage;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;

namespace PrimeTube
{
    public class ApplicationSetting
    {
        // Rating
        public static string Key_LaunchCount = "Key_LaunchCount";
        public static int Default_LaunchCount = 0;

        // Login Feature
        public static string Key_LoginRefreshToken = "Login_RefreshToken2";
        public static string Default_LoginRefreshToken = null;
        public static string Key_LoginAccessToken = "Login_AccessToken2";
        public static string Default_LoginAccessToken = null;

        public static string Key_LoginExpiryDate = "Login_AuthExpiryDate2";
        public static string Default_LoginExpiryDate = null; // DateTime in string

        // decoder
        public static string Key_FilterUnsupportedFiles = "FilterUnsupportedFiles";
        public static bool Default_FilterUnsupportedFiles = false;


        // Video playback selection
        public static string Key_VideoIsEnableReplay = "Key_VideoIsEnableReplay";
        public static bool Default_VideoIsEnableReplay = false;

        public static string Key_VideoIsAutoplaySuggested = "Key_VideoIsAutoplaySuggested";
        public static bool Default_VideoIsAutoplaySuggested = true;

        public static void SetRoamingSetting(string key, bool value)
        {
            ApplicationData.Current.RoamingSettings.Values[key] = value;
        }

        public static bool GetRoamingSetting(string key, bool fallback)
        {
            var obj = ApplicationData.Current.RoamingSettings.Values[key];
            if (obj == null)
            {
                return fallback;
            }
            return (bool)obj;
        }

        public static string GetRoamingSetting(string key, string fallback)
        {
            var obj = ApplicationData.Current.RoamingSettings.Values[key];
            if (obj == null)
            {
                return fallback;
            }
            return (string)obj;
        }

        public static int GetRoamingSetting(string key, int fallback)
        {
            var obj = ApplicationData.Current.RoamingSettings.Values[key];
            if (obj == null)
            {
                return fallback;
            }
            return (int)obj;
        }

        public static long GetRoamingSetting_Long(string key, long fallback)
        {
            var obj = ApplicationData.Current.RoamingSettings.Values[key];
            if (obj == null)
            {
                return fallback;
            }
            return (long)obj;
        }

        // Local
        public static bool GetLocalSetting(string key, bool fallback)
        {
            var obj = ApplicationData.Current.LocalSettings.Values[key];
            if (obj == null)
            {
                return fallback;
            }
            return (bool)obj;
        }
        public static string GetLocalSetting(string key, string fallback)
        {
            var obj = ApplicationData.Current.LocalSettings.Values[key];
            if (obj == null)
            {
                return fallback;
            }
            return (string)obj;
        }
        public static int GetLocalSetting(string key, int fallback)
        {
            var obj = ApplicationData.Current.LocalSettings.Values[key];
            if (obj == null)
            {
                return fallback;
            }
            return (int)obj;
        }
        public static long GetLocalSetting_Long(string key, long fallback)
        {
            var obj = ApplicationData.Current.LocalSettings.Values[key];
            if (obj == null)
            {
                return fallback;
            }
            return (long)obj;
        }

        public static void SetLocalSetting(string key, int value)
        {
            ApplicationData.Current.LocalSettings.Values[key] = value;
        }
        public static void SetLocalSetting(string key, bool value)
        {
            ApplicationData.Current.LocalSettings.Values[key] = value;
        }
        public static void SetLocalSetting(string key, long value)
        {
            ApplicationData.Current.LocalSettings.Values[key] = value;
        }

        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async static Task<bool> SetUpdateLocalValueEncrypted(string Key, string value)
        {
            bool valueChanged = false;

            string Final_EncryptedString = null;
            if (value != null)
            {
                var provider = new DataProtectionProvider("LOCAL=user");

                IBuffer unprotectedData = CryptographicBuffer.ConvertStringToBinary(value, BinaryStringEncoding.Utf8);
                IBuffer protectedData = await provider.ProtectAsync(unprotectedData);

                Final_EncryptedString = Convert.ToBase64String(protectedData.ToArray());
            }

            // If the key exists
            var obj = ApplicationData.Current.LocalSettings.Values[Key];
            if (obj != null)
            {
                // If the value has changed
                if ((string) ApplicationData.Current.LocalSettings.Values[Key] != Final_EncryptedString)
                {
                    // Store the new value
                    ApplicationData.Current.LocalSettings.Values[Key] = Final_EncryptedString;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                ApplicationData.Current.LocalSettings.Values.Add(Key, Final_EncryptedString);
                valueChanged = true;
            }
            return valueChanged;
        }

        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public async static Task<string> GetEncryptedLocalStringValueOrDefault(string Key, string defaultValue)
        {
            string value;

            // If the key exists, retrieve the value.
            var obj = ApplicationData.Current.LocalSettings.Values[Key];
            if (obj != null)
            {
                value = (string)ApplicationData.Current.LocalSettings.Values[Key];
                if (value != null)
                {
                    IBuffer EncryptedBytes = Convert.FromBase64String(value).AsBuffer();

                    var provider = new DataProtectionProvider();
                    IBuffer UnencryptedBytes = await provider.UnprotectAsync(EncryptedBytes);
                    string Final_UnEncryptedString = CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, UnencryptedBytes);

                    return Final_UnEncryptedString;
                }
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }
            return value;
        }
    }
}
