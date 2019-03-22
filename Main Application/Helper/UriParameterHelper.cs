using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTube.Helper
{
    public class UriParameterHelper
    {
        public static Dictionary<string, string> DecodeUriParameter(string parameter)
        {
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();

            string[] querySegments = parameter.Split('&');
            foreach (string segment in querySegments)
            {
                string[] parts = segment.Split('=');
                if (parts.Length > 1)
                {
                    string key = parts[0].Trim(new char[] { '?', ' ' });
                    string val = parts[1].Trim();

                    queryParameters.Add(key, val);
                }
            }
            return queryParameters;
        }
    }
}
