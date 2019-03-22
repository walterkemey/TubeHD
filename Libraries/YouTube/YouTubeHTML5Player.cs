using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YouTubeStreamAPI
{
    public class YouTubeHTML5Player
    {
        /// <summary>
        /// Gets the underlying decoding function from within the HTML5 player source code [javascript]
        /// </summary>
        /// <param name="PlayerScript"></param>
        /// <returns></returns>
        public static string GetDecodeFunction(string PlayerScript)
        {
            Match decodeFunctionName = Regex.Match(PlayerScript, "\\.sig\\|\\|([a-zA-Z0-9$]+)\\(");
            if (decodeFunctionName.Success)
            {
                return decodeFunctionName.Groups[1].Value;
            }
            return null;
        }

        public static string ExtractDecodeFunction(string PlayerScript, string DecodeFunction)
        {
            StringBuilder decodeScript = new StringBuilder();

            Match decodeFunction = Regex.Match(PlayerScript, "(" + DecodeFunction + "=function\\([a-zA-Z0-9$]+\\)\\{.*?\\})[,;]", RegexOptions.Singleline | RegexOptions.Compiled);
            if (decodeFunction.Success)
            {
                decodeScript.Append(decodeFunction.Groups[1].Value).Append(';');
            }
            else
            {
                throw new Exception("Unable to extract the main decode function!");
            }

            Match decodeFunctionHelperName = Regex.Match(decodeScript.ToString(), "\\);([a-zA-Z0-9]+)\\.", RegexOptions.Singleline | RegexOptions.Compiled);
            if (decodeFunctionHelperName.Success)
            {
                string decodeFuncHelperName = decodeFunctionHelperName.Groups[1].Value;

                //Match decodeFunctionHelper = Regex.Match(PlayerScript, "(var "+ decodeFuncHelperName + "=\\{[a-zA-Z]*:function\\(.*?\\};)");
                //Match decodeFunctionHelper = Regex.Match(PlayerScript, "(var "+ decodeFuncHelperName + "=\\{[a-zA-Z]*:function\\(.*?\\};)", RegexOptions.Multiline);
                Match decodeFunctionHelper = Regex.Match(PlayerScript, "(var " + decodeFuncHelperName + "\\=\\{[a-zA-Z0-9]*\\:function(.*?\\}\\};))", RegexOptions.Singleline | RegexOptions.Compiled);

                if (decodeFunctionHelper.Success)
                {
                    decodeScript.Append(decodeFunctionHelper.Groups[1]);
                }
                else
                {
                    throw new Exception("Unable to extract the helper decode functions!");
                }
            }
            else
            {
                throw new Exception("Unable to extract the helper decode functions!");
            }

            return decodeScript.ToString();
        }

        /// <summary>
        /// Gets the HTML5 source code of the underlying youtube page.
        /// </summary>
        /// <param name="SourceCode"></param>
        /// <returns></returns>
        public static async Task<string> GetHTML5PlayerJSFromYouTubePageSource(string SourceCode)
        {
            string HTML5JavascriptURL = null;

            const string StringSearch = "\"js\":\"\\";
            int IndexOf = SourceCode.IndexOf(StringSearch);
            if (IndexOf != -1)
            {
                int EndJSIndex = SourceCode.IndexOf(@"""", IndexOf + StringSearch.Length);

                HTML5JavascriptURL = SourceCode.Substring(IndexOf + StringSearch.Length, EndJSIndex - (IndexOf + StringSearch.Length));
                HTML5JavascriptURL = HTML5JavascriptURL.Replace("\\/", "/");

                if (!HTML5JavascriptURL.StartsWith("http:"))
                {
                    HTML5JavascriptURL = "http:" + HTML5JavascriptURL;
                }
                //Debug.WriteLine(HTML5JavascriptURL);

                /////// Load HTML5 player item
                HttpClientHandler handler = new HttpClientHandler();
                var req2 = new HttpClient(handler);
                var message2 = new HttpRequestMessage(HttpMethod.Get, HTML5JavascriptURL);

                message2.Headers.Add("User-Agent", YoutubeStreamAPIConstants.RandomHTTPUserAgent());
                message2.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                message2.Headers.Add("Accept-Language", "en-US,en;q=0.5");
                //message.Headers.Add("Accept-Encoding", "gzip, deflate");
                message2.Headers.Add("Connection", "keep-alive");

                try
                {
                    HttpResponseMessage data = await req2.SendAsync(message2);
                    HttpContent content = data.Content;
                    data.EnsureSuccessStatusCode();

                    string HTML5SrcPlayer = await content.ReadAsStringAsync();

                    return HTML5SrcPlayer;
                }
                catch (Exception exp)
                {
                    Debug.WriteLine(exp.ToString());
                }
            }
            return null;
        }
    }
}


/*// Start parsing
                    //  string functionName = regMatcher(HTML5SrcPlayer, @"/\.set\s*\(""signature""\s*,\s*([a-zA-Z0-9_$][\w$]*)\(/"); // c&&a.set(\"signature\",er(c));return a}\nfunc
                    // string functionName2 = regMatcher(HTML5SrcPlayer, @"/\.sig\s*\|\|\s*([a-zA-Z0-9_$][\w$]*)\(/");
                    //   string functionName3 = regMatcher(HTML5SrcPlayer, @"/\.signature\s*=\s*([a-zA-Z_$][\w$]*)\([a-zA-Z_$][\w$]*\)/");

                    Match functionNameMatches = Regex.Match(HTML5SrcPlayer, @".signature=(\w+)\("); // @"/b\.signature=(\w+)\(/"
                    string functionName = (functionNameMatches.Success) ? functionNameMatches.Groups[1].Value : null;
                    if (functionName == null)
                    {
                        //localStorage[STORAGE_CODE] = "error";
                        return;
                    }

                    // function lj(a) { a = a.split(""); a = a.slice(2); a = mj(a, 53); a = a.reverse(); a = mj(a, 59); a = a.reverse(); a = a.slice(2); a = mj(a, 41); a = a.slice(3); return a.join("") 
                    Regex regCode = new Regex("function " + functionName + @"\s*\(\w+\)\s*{\w+=\w+\.split\(""""\);(.+);return \w+\.join"); // "function " + functionName + @"\\s*\\(\\w+\\)\\s*{\\w+=\\w+\\.split\\(""\\);(.+);return \\w+\\.join"
                    Match functionCodeMatches = regCode.Match(HTML5SrcPlayer);
                    string functionCode = (functionCodeMatches.Success) ? functionCodeMatches.Groups[1].Value : null;
                    if (functionCode == null)
                    {
                        //localStorage[STORAGE_CODE] = "error";
                        return;
                    }
                    Regex regSlice = new Regex("slice\\s*\\(\\s*(.+)\\s*\\)");
                    Regex regSwap = new Regex("\\w+\\s*\\(\\s*\\w+\\s*,\\s*([0-9]+)\\s*\\)");
                    Regex regInline = new Regex("\\w+\\[0\\]\\s*=\\s*\\w+\\[([0-9]+)\\s*%\\s*\\w+\\.length\\]");
                    string[] functionCodePieces = functionCode.Split(';');
                    for (var i = 0; i < functionCodePieces.Length; i++)
                    {
                        functionCodePieces[i] = functionCodePieces[i].Trim();

                        if (functionCodePieces[i].Length == 0)
                        {
                        }
                        else if (functionCodePieces[i].IndexOf("slice") >= 0)
                        { // slice
                            Match sliceMatches = regSlice.Match(functionCodePieces[i]);
                            string slice = (sliceMatches.Success) ? sliceMatches.Groups[1].Value : null;

                            int out_val = 0;
                            if (int.TryParse(slice, out out_val))
                            {
                                SignatureArrays.Add(-out_val);
                            }
                            else
                            {
                                ErrorDetected = true;
                                break;
                            }
                        }
                        else if (functionCodePieces[i].IndexOf("reverse") >= 0)
                        {
                            SignatureArrays.Add(0);
                            //decodeArray.push(0);
                        }
                        else if (functionCodePieces[i].IndexOf("[0]") >= 0)
                        {
                            if (i + 2 < functionCodePieces.Length &&
                                functionCodePieces[i + 1].IndexOf(".length") >= 0 &&
                                functionCodePieces[i + 1].IndexOf("[0]") >= 0)
                            {

                                Match inlineMatches = regInline.Match(functionCodePieces[i + 1]);
                                string inline = (inlineMatches.Success) ? inlineMatches.Groups[1].Value : null;

                                SignatureArrays.Add(int.Parse(inline));

                                i = i + 2;
                            }
                            else
                            {
                                //localStorage[STORAGE_CODE] = "error";
                                ErrorDetected = true;
                                break;
                            }
                        }
                        else if (functionCodePieces[i].IndexOf(",") >= 0)
                        {
                            Match swapMatches = regSwap.Match(functionCodePieces[i]);
                            string swap = (swapMatches.Success) ? swapMatches.Groups[1].Value : null;

                            int out_val = 0;
                            if (int.TryParse(swap, out out_val))
                            {
                                SignatureArrays.Add(out_val);
                            }
                            else
                            {
                                ErrorDetected = true;
                                break;
                            }
                        }
                        else
                        {
                            //localStorage[STORAGE_CODE] = "error";
                            ErrorDetected = true;
                            break;
                        }
                    }



            if (!ErrorDetected && HTML5JavascriptURL != null)
            {
                ApplicationData.Current.LocalSettings.Values[ApplicationSetting.Key_Signature_LastPlayerArray] = string.Join("_", SignatureArrays);
                ApplicationData.Current.LocalSettings.Values[ApplicationSetting.Key_Signature_LastPlayerType] = HTML5JavascriptURL;
            }
            else
            {
                ApplicationData.Current.LocalSettings.Values[ApplicationSetting.Key_Signature_LastPlayerArray] = null;
                ApplicationData.Current.LocalSettings.Values[ApplicationSetting.Key_Signature_LastPlayerType] = null;
            }
*/
