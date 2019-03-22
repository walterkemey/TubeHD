using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_Music_Video_Downloader__W10_
{
    public class APIConstants
    {
        public static string HockeyAppAPIKey
        {
            get {
              //  throw new Exception("Please get the HockeyApp API key from https://hockeyapp.net/#s!!!"); // comment out this line for the one below.
                return "a545335c-c848-44d9-a411-fc65439c1340";//wonderappsptd
            }
            set { }
        }


        public static string[] YouTubeAPIKeys
        {
            get {
                return new string[] { "AIzaSyBmwoHjQ620TdWivT6kKJgRKgJORNO4fcs" }; // official api key}; 
            }
            set { }
        }
        public static string[] YouTubeClientSecrets
        {
            get
            {
                return new string[] { "WzU50iUe9GXyPNlXzN8BuBw2" }; // official api key}; 
            }
            set { }
        }

        public static string[] YouTubeClientIds
        {
            get
            {
                return new string[] { "151097959076-4uqo83afhh7t61qlolgco8oa7pui9ntr.apps.googleusercontent.com" }; // official api key}; 
            }
            set { }
        }
    }
}
