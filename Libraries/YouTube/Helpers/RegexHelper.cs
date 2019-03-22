using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YouTubeStreamAPI.Helpers
{
    public class RegexHelper
    {
        public static string CharMatch(Match match)
        {
            var code = match.Groups["code"].Value;
            int value = Convert.ToInt32(code, 16);
            return ((char)value).ToString();
        }

        public static string regMatcher(string input, string reg)
        {
            Match functionNameMatches = Regex.Match(input, reg);
            string itemname = (functionNameMatches.Success) ? functionNameMatches.Groups[1].Value : null;

            return itemname;
        }
    }
}
