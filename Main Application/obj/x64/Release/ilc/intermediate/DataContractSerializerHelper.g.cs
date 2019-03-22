using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Xml;

[assembly: global::System.Reflection.AssemblyVersion("4.0.0.0")]



namespace System.Runtime.Serialization.Generated
{
    [global::System.Runtime.CompilerServices.__BlockReflection]
    public static partial class DataContractSerializerHelper
    {
        public static void InitDataContracts()
        {
            global::System.Collections.Generic.Dictionary<global::System.Type, global::System.Runtime.Serialization.DataContract> dataContracts = global::System.Runtime.Serialization.DataContract.GetDataContracts();
            PopulateContractDictionary(dataContracts);
            global::System.Collections.Generic.Dictionary<global::System.Runtime.Serialization.DataContract, global::System.Runtime.Serialization.Json.JsonReadWriteDelegates> jsonDelegates = global::System.Runtime.Serialization.Json.JsonReadWriteDelegates.GetJsonDelegates();
            PopulateJsonDelegateDictionary(
                                dataContracts, 
                                jsonDelegates
                            );
        }
        static int[] s_knownContractsLists = new int[] {
              -1, }
        ;
        // Count = 558
        static int[] s_xmlDictionaryStrings = new int[] {
                0, // array length: 0
                14, // array length: 14
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                1, // array length: 1
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                14, // array length: 14
                1729, // index: 1729, string: "AdType"
                1736, // index: 1736, string: "BestBefore"
                1747, // index: 1747, string: "Campaign"
                1756, // index: 1756, string: "Id"
                1759, // index: 1759, string: "MraidContent"
                1772, // index: 1772, string: "PartsDate"
                1782, // index: 1782, string: "PartsMD5"
                1791, // index: 1791, string: "PartsReady"
                1802, // index: 1802, string: "PartsUrls"
                1812, // index: 1812, string: "ReadyIn"
                1820, // index: 1820, string: "ReceivedAt"
                1831, // index: 1831, string: "RequestAd"
                1841, // index: 1841, string: "Status"
                1848, // index: 1848, string: "TemplateSettingMap"
                14, // array length: 14
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                2, // array length: 2
                -1, // string: null
                482, // index: 482, string: "http://schemas.datacontract.org/2004/07/System"
                1, // array length: 1
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                2, // array length: 2
                457, // index: 457, string: "Key"
                461, // index: 461, string: "Value"
                2, // array length: 2
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                2, // array length: 2
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                482, // index: 482, string: "http://schemas.datacontract.org/2004/07/System"
                2, // array length: 2
                1867, // index: 1867, string: "DateTime"
                1876, // index: 1876, string: "OffsetMinutes"
                2, // array length: 2
                482, // index: 482, string: "http://schemas.datacontract.org/2004/07/System"
                482, // index: 482, string: "http://schemas.datacontract.org/2004/07/System"
                2, // array length: 2
                -1, // string: null
                482, // index: 482, string: "http://schemas.datacontract.org/2004/07/System"
                1, // array length: 1
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                2, // array length: 2
                1890, // index: 1890, string: "key"
                1894, // index: 1894, string: "value"
                2, // array length: 2
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                2, // array length: 2
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                2, // array length: 2
                457, // index: 457, string: "Key"
                461, // index: 461, string: "Value"
                2, // array length: 2
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                2, // array length: 2
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                2, // array length: 2
                1890, // index: 1890, string: "key"
                1894, // index: 1894, string: "value"
                2, // array length: 2
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                5, // array length: 5
                733, // index: 733, string: "1"
                735, // index: 735, string: "2"
                737, // index: 737, string: "3"
                739, // index: 739, string: "4"
                741, // index: 741, string: "5"
                22, // array length: 22
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                -1, // string: null
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                22, // array length: 22
                1900, // index: 1900, string: "AsFile"
                1736, // index: 1736, string: "BestBefore"
                1907, // index: 1907, string: "Cid"
                1911, // index: 1911, string: "Cid2"
                1916, // index: 1916, string: "Data"
                1921, // index: 1921, string: "ExpectedContentType"
                1941, // index: 1941, string: "Group"
                1947, // index: 1947, string: "Headers"
                1756, // index: 1756, string: "Id"
                1955, // index: 1955, string: "KeepFile"
                1964, // index: 1964, string: "LocalCacheFileFolderName"
                1989, // index: 1989, string: "MaxBackoffPeriod"
                2006, // index: 2006, string: "Method"
                2013, // index: 2013, string: "ProgressiveBackoffEnabled"
                2039, // index: 2039, string: "Query"
                2045, // index: 2045, string: "RetryCount"
                2056, // index: 2056, string: "RetryPass"
                2066, // index: 2066, string: "RetryPeriod"
                2078, // index: 2078, string: "State"
                2084, // index: 2084, string: "Url"
                2088, // index: 2088, string: "UseGzip"
                2096, // index: 2096, string: "When"
                22, // array length: 22
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                2, // array length: 2
                733, // index: 733, string: "1"
                735, // index: 735, string: "2"
                3, // array length: 3
                733, // index: 733, string: "1"
                735, // index: 735, string: "2"
                737, // index: 737, string: "3"
                3, // array length: 3
                733, // index: 733, string: "1"
                735, // index: 735, string: "2"
                737, // index: 737, string: "3"
                18, // array length: 18
                -1, // string: null
                -1, // string: null
                -1, // string: null
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                -1, // string: null
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                -1, // string: null
                -1, // string: null
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                -1, // string: null
                -1, // string: null
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                1, // array length: 1
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                18, // array length: 18
                2101, // index: 2101, string: "AdData"
                2108, // index: 2108, string: "AdDuration"
                1729, // index: 1729, string: "AdType"
                2119, // index: 2119, string: "Clicks"
                2126, // index: 2126, string: "DownloadClicked"
                2142, // index: 2142, string: "EndTime"
                2150, // index: 2150, string: "ErrorList"
                2160, // index: 2160, string: "ExtraInfo"
                1756, // index: 1756, string: "Id"
                2170, // index: 2170, string: "Incentivized"
                2183, // index: 2183, string: "Placement"
                2193, // index: 2193, string: "PlaysDuration"
                2207, // index: 2207, string: "PlaysStart"
                1812, // index: 1812, string: "ReadyIn"
                2218, // index: 2218, string: "StartTime"
                2228, // index: 2228, string: "User"
                2233, // index: 2233, string: "UserActions"
                2245, // index: 2245, string: "isCompletedView"
                18, // array length: 18
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                264, // index: 264, string: "http://schemas.datacontract.org/2004/07/VungleSDK"
                2, // array length: 2
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                2, // array length: 2
                457, // index: 457, string: "Key"
                461, // index: 461, string: "Value"
                2, // array length: 2
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                2, // array length: 2
                -1, // string: null
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                1, // array length: 1
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                2, // array length: 2
                457, // index: 457, string: "Key"
                461, // index: 461, string: "Value"
                2, // array length: 2
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                2, // array length: 2
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                2, // array length: 2
                1890, // index: 1890, string: "key"
                1894, // index: 1894, string: "value"
                2, // array length: 2
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                2, // array length: 2
                -1, // string: null
                360, // index: 360, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                1, // array length: 1
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                2, // array length: 2
                1890, // index: 1890, string: "key"
                1894, // index: 1894, string: "value"
                2, // array length: 2
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                572, // index: 572, string: "http://schemas.datacontract.org/2004/07/System.Collections.Generic"
                11, // array length: 11
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                11, // array length: 11
                2261, // index: 2261, string: "app_id"
                2268, // index: 2268, string: "appsize"
                2276, // index: 2276, string: "device_family"
                2290, // index: 2290, string: "id"
                2293, // index: 2293, string: "mandatory"
                2303, // index: 2303, string: "minimum_os_version"
                2322, // index: 2322, string: "notes"
                2328, // index: 2328, string: "shortversion"
                2341, // index: 2341, string: "timestamp"
                2351, // index: 2351, string: "title"
                2357, // index: 2357, string: "version"
                11, // array length: 11
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                3, // array length: 3
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                3, // array length: 3
                2365, // index: 2365, string: "auid"
                2370, // index: 2370, string: "iuid"
                2375, // index: 2375, string: "status"
                3, // array length: 3
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                6, // array length: 6
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                6, // array length: 6
                2382, // index: 2382, string: "contact"
                2390, // index: 2390, string: "description"
                2402, // index: 2402, string: "log"
                2406, // index: 2406, string: "sdk"
                2410, // index: 2410, string: "sdk_version"
                2422, // index: 2422, string: "userID"
                6, // array length: 6
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                3, // array length: 3
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                3, // array length: 3
                2429, // index: 2429, string: "feedback"
                2375, // index: 2375, string: "status"
                2438, // index: 2438, string: "token"
                3, // array length: 3
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                7, // array length: 7
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                7, // array length: 7
                2444, // index: 2444, string: "created_at"
                2455, // index: 2455, string: "email"
                2290, // index: 2290, string: "id"
                2461, // index: 2461, string: "messages"
                2470, // index: 2470, string: "name"
                2375, // index: 2375, string: "status"
                2438, // index: 2438, string: "token"
                7, // array length: 7
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                18, // array length: 18
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                18, // array length: 18
                2475, // index: 2475, string: "Model"
                2481, // index: 2481, string: "Text"
                2261, // index: 2261, string: "app_id"
                2486, // index: 2486, string: "app_verson_id"
                2500, // index: 2500, string: "attachments"
                2512, // index: 2512, string: "clean_text"
                2444, // index: 2444, string: "created_at"
                2455, // index: 2455, string: "email"
                2523, // index: 2523, string: "gravatar_hash"
                2290, // index: 2290, string: "id"
                2537, // index: 2537, string: "internal"
                2470, // index: 2470, string: "name"
                2546, // index: 2546, string: "oem"
                2550, // index: 2550, string: "os_version"
                2561, // index: 2561, string: "subject"
                2438, // index: 2438, string: "token"
                2569, // index: 2569, string: "user_string"
                2581, // index: 2581, string: "via"
                18, // array length: 18
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                4, // array length: 4
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                4, // array length: 4
                2444, // index: 2444, string: "created_at"
                2585, // index: 2585, string: "file_name"
                2290, // index: 2290, string: "id"
                2595, // index: 2595, string: "url"
                4, // array length: 4
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                1328, // index: 1328, string: "http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model"
                7, // array length: 7
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                1567, // index: 1567, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Interstitials.Models"
                7, // array length: 7
                2599, // index: 2599, string: "Hash"
                2604, // index: 2604, string: "ImageURL"
                2613, // index: 2613, string: "MarketplaceAppId"
                2630, // index: 2630, string: "SizedAdId"
                2640, // index: 2640, string: "Time"
                2645, // index: 2645, string: "UpdatedOn"
                2084, // index: 2084, string: "Url"
                7, // array length: 7
                1567, // index: 1567, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Interstitials.Models"
                1567, // index: 1567, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Interstitials.Models"
                1567, // index: 1567, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Interstitials.Models"
                1567, // index: 1567, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Interstitials.Models"
                1567, // index: 1567, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Interstitials.Models"
                1567, // index: 1567, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Interstitials.Models"
                1567, // index: 1567, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Interstitials.Models"
                14, // array length: 14
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                14, // array length: 14
                1729, // index: 1729, string: "AdType"
                2599, // index: 2599, string: "Hash"
                2604, // index: 2604, string: "ImageURL"
                2655, // index: 2655, string: "Line1"
                2661, // index: 2661, string: "Line2"
                2667, // index: 2667, string: "Line3"
                2673, // index: 2673, string: "Line4"
                2613, // index: 2613, string: "MarketplaceAppId"
                2679, // index: 2679, string: "PhoneNumber"
                2691, // index: 2691, string: "ShowLogo"
                2630, // index: 2630, string: "SizedAdId"
                1841, // index: 1841, string: "Status"
                2640, // index: 2640, string: "Time"
                2084, // index: 2084, string: "Url"
                14, // array length: 14
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650, // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
                1650  // index: 1650, string: "http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models"
        };
        // Count = 13
        static global::MemberEntry[] s_dataMemberLists = new global::MemberEntry[] {
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 733, // 1
                    Value = 1,
                }, 
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 735, // 2
                    Value = 2,
                }, 
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 737, // 3
                    Value = 3,
                }, 
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 739, // 4
                    Value = 4,
                }, 
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 741, // 5
                    Value = 5,
                }, 
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 733, // 1
                    Value = 1,
                }, 
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 735, // 2
                    Value = 2,
                }, 
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 733, // 1
                    Value = 1,
                }, 
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 735, // 2
                    Value = 2,
                }, 
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 737, // 3
                    Value = 3,
                }, 
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 733, // 1
                    Value = 1,
                }, 
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 735, // 2
                    Value = 2,
                }, 
                new global::MemberEntry() {
                    EmitDefaultValue = true,
                    NameIndex = 737, // 3
                    Value = 3,
                }
        };
        static readonly byte[] s_dataContractMap_Hashtable = null;
        // Count=86
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::DataContractMapEntry[] s_dataContractMap = new global::DataContractMapEntry[] {
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 0, // 0x0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]" +
                                ", mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 0, // 0x0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 16, // 0x10
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Char, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 32, // 0x20
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Char, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], m" +
                                "scorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 32, // 0x20
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 48, // 0x30
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]" +
                                "], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 48, // 0x30
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 64, // 0x40
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]" +
                                ", mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 64, // 0x40
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 80, // 0x50
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 80, // 0x50
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 96, // 0x60
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 96, // 0x60
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 112, // 0x70
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], m" +
                                "scorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 112, // 0x70
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 128, // 0x80
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], " +
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 128, // 0x80
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 144, // 0x90
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], " +
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 144, // 0x90
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 160, // 0xa0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Xml.XmlQualifiedName, System.Xml.ReaderWriter, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f1" +
                                "1d50a3a")),
                    TableIndex = 176, // 0xb0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 192, // 0xc0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], " +
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 192, // 0xc0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.SByte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 208, // 0xd0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.SByte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], " +
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 208, // 0xd0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 224, // 0xe0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 240, // 0xf0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]" +
                                "], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 240, // 0xf0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 256, // 0x100
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], m" +
                                "scorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 256, // 0x100
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 272, // 0x110
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.UInt32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 272, // 0x110
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 288, // 0x120
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 288, // 0x120
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 304, // 0x130
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.UInt16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 304, // 0x130
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Uri, System.Private.Uri, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 320, // 0x140
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.AdBundle, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    TableIndex = 1, // 0x1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.DateTimeOffset, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 2, // 0x2
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.DateTimeOffset, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 17, // 0x11
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Nullable`1[[System.Runtime.Serialization.KeyValue`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.DateTimeOffset, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 17, // 0x11
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Runtime.Serialization.DateTimeOffsetAdapter, System.Private.DataContractSerialization, Version=4.1.1.0, C" +
                                "ulture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 33, // 0x21
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Nullable`1[[System.Runtime.Serialization.DateTimeOffsetAdapter, System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 33, // 0x21
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.DateTimeOffset, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 49, // 0x31
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Nullable`1[[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.DateTimeOffset, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 49, // 0x31
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 18, // 0x12
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 65, // 0x41
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Nullable`1[[System.Runtime.Serialization.KeyValue`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 65, // 0x41
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 81, // 0x51
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Nullable`1[[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 81, // 0x51
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.AdBundleState, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    TableIndex = 3, // 0x3
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[VungleSDK.AdBundleState, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 3, // 0x3
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.NetworkRequest, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    TableIndex = 97, // 0x61
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.NetworkResultContentType, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    TableIndex = 19, // 0x13
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[VungleSDK.NetworkResultContentType, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyTo" +
                                "ken=null]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 19, // 0x13
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.NetworkRequestMethod, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    TableIndex = 35, // 0x23
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[VungleSDK.NetworkRequestMethod, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=" +
                                "null]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 35, // 0x23
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.NetworkRequestState, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    TableIndex = 51, // 0x33
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[VungleSDK.NetworkRequestState, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=n" +
                                "ull]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 51, // 0x33
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.AdSession, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    TableIndex = 113, // 0x71
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, Publ" +
                                "icKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11" +
                                "d50a3a")),
                    TableIndex = 34, // 0x22
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1[[System.TimeSpan, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKey" +
                                "Token=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3" +
                                "a")),
                    TableIndex = 50, // 0x32
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKey" +
                                "Token=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3" +
                                "a")),
                    TableIndex = 66, // 0x42
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.Dictionary`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 82, // 0x52
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 129, // 0x81
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Nullable`1[[System.Runtime.Serialization.KeyValue`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 129, // 0x81
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 98, // 0x62
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 145, // 0x91
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Nullable`1[[System.Runtime.Serialization.KeyValue`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 145, // 0x91
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.KeyValuePair`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 161, // 0xa1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Nullable`1[[System.Collections.Generic.KeyValuePair`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 161, // 0xa1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.KeyValuePair`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 177, // 0xb1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Nullable`1[[System.Collections.Generic.KeyValuePair`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 177, // 0xb1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.List`1[[Microsoft.HockeyApp.Model.AppVersion, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 114, // 0x72
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.AppVersion, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKey" +
                                "Token=b03f5f7f11d50a3a")),
                    TableIndex = 193, // 0xc1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.AuthStatus, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKey" +
                                "Token=b03f5f7f11d50a3a")),
                    TableIndex = 209, // 0xd1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.CrashData, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKeyT" +
                                "oken=b03f5f7f11d50a3a")),
                    TableIndex = 225, // 0xe1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackResponseSingle, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutra" +
                                "l, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 241, // 0xf1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackThread, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, Publi" +
                                "cKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 257, // 0x101
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.List`1[[Microsoft.HockeyApp.Model.FeedbackMessage, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 130, // 0x82
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackMessage, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, Publ" +
                                "icKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 273, // 0x111
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.List`1[[Microsoft.HockeyApp.Model.FeedbackAttachment, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 146, // 0x92
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackAttachment, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, P" +
                                "ublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 289, // 0x121
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("AdDuplex.Interstitials.Models.InterstitialAdInfo, AdDuplex, Version=10.1.0.1, Culture=neutral, PublicKeyToken=nu" +
                                "ll")),
                    TableIndex = 305, // 0x131
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("AdDuplex.Banners.Models.BannerAdInfo, AdDuplex, Version=10.1.0.1, Culture=neutral, PublicKeyToken=null")),
                    TableIndex = 321, // 0x141
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object[], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 162, // 0xa2
                }
        };
        static readonly byte[] s_dataContracts_Hashtable = null;
        // Count=21
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::DataContractEntry[] s_dataContracts = new global::DataContractEntry[] {
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 0, // boolean
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 0, // boolean
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 0, // boolean
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.BooleanDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 93, // base64Binary
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 93, // base64Binary
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 93, // base64Binary
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.ByteArrayDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 106, // char
                        NamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        StableNameIndex = 106, // char
                        StableNameNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        TopLevelElementNameIndex = 106, // char
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Char, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Char, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.CharDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 111, // dateTime
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 111, // dateTime
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 111, // dateTime
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.DateTimeDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 120, // decimal
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 120, // decimal
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 120, // decimal
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.DecimalDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 128, // double
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 128, // double
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 128, // double
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.DoubleDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 135, // float
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 135, // float
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 135, // float
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.FloatDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 141, // guid
                        NamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        StableNameIndex = 141, // guid
                        StableNameNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        TopLevelElementNameIndex = 141, // guid
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.GuidDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 146, // int
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 146, // int
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 146, // int
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.IntDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 150, // long
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 150, // long
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 150, // long
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.LongDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 155, // anyType
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 155, // anyType
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 155, // anyType
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    Kind = global::DataContractKind.ObjectDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 163, // QName
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 163, // QName
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 163, // QName
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Xml.XmlQualifiedName, System.Xml.ReaderWriter, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f1" +
                                    "1d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Xml.XmlQualifiedName, System.Xml.ReaderWriter, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f1" +
                                    "1d50a3a")),
                    },
                    Kind = global::DataContractKind.QNameDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 169, // short
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 169, // short
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 169, // short
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.ShortDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 175, // byte
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 175, // byte
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 175, // byte
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.SByte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.SByte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.SignedByteDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 180, // string
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 180, // string
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 180, // string
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.StringDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 187, // duration
                        NamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        StableNameIndex = 187, // duration
                        StableNameNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        TopLevelElementNameIndex = 187, // duration
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.TimeSpanDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 196, // unsignedByte
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 196, // unsignedByte
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 196, // unsignedByte
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.UnsignedByteDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 209, // unsignedInt
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 209, // unsignedInt
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 209, // unsignedInt
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.UnsignedIntDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 221, // unsignedLong
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 221, // unsignedLong
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 221, // unsignedLong
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.UnsignedLongDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 234, // unsignedShort
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 234, // unsignedShort
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 234, // unsignedShort
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.UnsignedShortDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 248, // anyURI
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 248, // anyURI
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 248, // anyURI
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Uri, System.Private.Uri, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Uri, System.Private.Uri, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    Kind = global::DataContractKind.UriDataContract,
                }
        };
        static readonly byte[] s_classDataContracts_Hashtable = null;
        // Count=21
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::ClassDataContractEntry[] s_classDataContracts = new global::ClassDataContractEntry[] {
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 255, // AdBundle
                        NamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        StableNameIndex = 255, // AdBundle
                        StableNameNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        TopLevelElementNameIndex = 255, // AdBundle
                        TopLevelElementNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.AdBundle, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.AdBundle, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    },
                    HasDataContract = true,
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassReaderDelegate>(global::Type0.ReadAdBundleFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassWriterDelegate>(global::Type1.WriteAdBundleToXml),
                    ChildElementNamespacesListIndex = 1,
                    ContractNamespacesListIndex = 16,
                    MemberNamesListIndex = 18,
                    MemberNamespacesListIndex = 33,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 418, // KeyValueOfstringDateTimeOffsetU6ho3Bhd
                        NamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 418, // KeyValueOfstringDateTimeOffsetU6ho3Bhd
                        StableNameNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 418, // KeyValueOfstringDateTimeOffsetU6ho3Bhd
                        TopLevelElementNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.DateTimeOffset, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.DateTimeOffset, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Runtime.Serialization.KeyValue`2, System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neut" +
                                    "ral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    HasDataContract = true,
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassReaderDelegate>(global::Type5.ReadKeyValueOfstringDateTimeOffsetU6ho3BhdFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassWriterDelegate>(global::Type6.WriteKeyValueOfstringDateTimeOffsetU6ho3BhdToXml),
                    ChildElementNamespacesListIndex = 48,
                    ContractNamespacesListIndex = 51,
                    MemberNamesListIndex = 53,
                    MemberNamespacesListIndex = 56,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 467, // DateTimeOffset
                        NamespaceIndex = 482, // http://schemas.datacontract.org/2004/07/System
                        StableNameIndex = 467, // DateTimeOffset
                        StableNameNamespaceIndex = 482, // http://schemas.datacontract.org/2004/07/System
                        TopLevelElementNameIndex = 467, // DateTimeOffset
                        TopLevelElementNamespaceIndex = 482, // http://schemas.datacontract.org/2004/07/System
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.DateTimeOffset, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" +
                                    "")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Runtime.Serialization.DateTimeOffsetAdapter, System.Private.DataContractSerialization, Version=4.1.1.0, C" +
                                    "ulture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    HasDataContract = true,
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassReaderDelegate>(global::Type7.ReadDateTimeOffsetFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassWriterDelegate>(global::Type8.WriteDateTimeOffsetToXml),
                    ChildElementNamespacesListIndex = 59,
                    ContractNamespacesListIndex = 62,
                    MemberNamesListIndex = 64,
                    MemberNamespacesListIndex = 67,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 529, // KeyValuePairOfstringDateTimeOffsetU6ho3Bhd
                        NamespaceIndex = 572, // http://schemas.datacontract.org/2004/07/System.Collections.Generic
                        StableNameIndex = 529, // KeyValuePairOfstringDateTimeOffsetU6ho3Bhd
                        StableNameNamespaceIndex = 572, // http://schemas.datacontract.org/2004/07/System.Collections.Generic
                        TopLevelElementNameIndex = 529, // KeyValuePairOfstringDateTimeOffsetU6ho3Bhd
                        TopLevelElementNamespaceIndex = 572, // http://schemas.datacontract.org/2004/07/System.Collections.Generic
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.DateTimeOffset, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.DateTimeOffset, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.KeyValuePair`2, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyTo" +
                                    "ken=b03f5f7f11d50a3a")),
                    },
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassReaderDelegate>(global::Type9.ReadKeyValuePairOfstringDateTimeOffsetU6ho3BhdFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassWriterDelegate>(global::Type10.WriteKeyValuePairOfstringDateTimeOffsetU6ho3BhdToXml),
                    ChildElementNamespacesListIndex = 70,
                    ContractNamespacesListIndex = 73,
                    MemberNamesListIndex = 75,
                    MemberNamespacesListIndex = 78,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 669, // KeyValueOfstringstring
                        NamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 669, // KeyValueOfstringstring
                        StableNameNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 669, // KeyValueOfstringstring
                        TopLevelElementNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Runtime.Serialization.KeyValue`2, System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neut" +
                                    "ral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    HasDataContract = true,
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassReaderDelegate>(global::Type14.ReadKeyValueOfstringstringFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassWriterDelegate>(global::Type15.WriteKeyValueOfstringstringToXml),
                    ChildElementNamespacesListIndex = 81,
                    ContractNamespacesListIndex = 84,
                    MemberNamesListIndex = 86,
                    MemberNamespacesListIndex = 89,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 692, // KeyValuePairOfstringstring
                        NamespaceIndex = 572, // http://schemas.datacontract.org/2004/07/System.Collections.Generic
                        StableNameIndex = 692, // KeyValuePairOfstringstring
                        StableNameNamespaceIndex = 572, // http://schemas.datacontract.org/2004/07/System.Collections.Generic
                        TopLevelElementNameIndex = 692, // KeyValuePairOfstringstring
                        TopLevelElementNamespaceIndex = 572, // http://schemas.datacontract.org/2004/07/System.Collections.Generic
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.KeyValuePair`2, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyTo" +
                                    "ken=b03f5f7f11d50a3a")),
                    },
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassReaderDelegate>(global::Type16.ReadKeyValuePairOfstringstringFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassWriterDelegate>(global::Type17.WriteKeyValuePairOfstringstringToXml),
                    ChildElementNamespacesListIndex = 92,
                    ContractNamespacesListIndex = 95,
                    MemberNamesListIndex = 97,
                    MemberNamespacesListIndex = 100,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 743, // NetworkRequest
                        NamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        StableNameIndex = 743, // NetworkRequest
                        StableNameNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        TopLevelElementNameIndex = 743, // NetworkRequest
                        TopLevelElementNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.NetworkRequest, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.NetworkRequest, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    },
                    HasDataContract = true,
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassReaderDelegate>(global::Type18.ReadNetworkRequestFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassWriterDelegate>(global::Type19.WriteNetworkRequestToXml),
                    ChildElementNamespacesListIndex = 109,
                    ContractNamespacesListIndex = 132,
                    MemberNamesListIndex = 134,
                    MemberNamespacesListIndex = 157,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 824, // AdSession
                        NamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        StableNameIndex = 824, // AdSession
                        StableNameNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        TopLevelElementNameIndex = 824, // AdSession
                        TopLevelElementNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.AdSession, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.AdSession, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    },
                    HasDataContract = true,
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassReaderDelegate>(global::Type20.ReadAdSessionFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassWriterDelegate>(global::Type21.WriteAdSessionToXml),
                    ChildElementNamespacesListIndex = 191,
                    ContractNamespacesListIndex = 210,
                    MemberNamesListIndex = 212,
                    MemberNamespacesListIndex = 231,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 969, // KeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1
                        NamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 969, // KeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1
                        StableNameNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 969, // KeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1
                        TopLevelElementNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Runtime.Serialization.KeyValue`2, System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neut" +
                                    "ral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    HasDataContract = true,
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassReaderDelegate>(global::Type34.ReadKeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1FromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassWriterDelegate>(global::Type35.WriteKeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1ToXml),
                    ChildElementNamespacesListIndex = 250,
                    ContractNamespacesListIndex = 253,
                    MemberNamesListIndex = 255,
                    MemberNamespacesListIndex = 258,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 1112, // KeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7
                        NamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 1112, // KeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7
                        StableNameNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 1112, // KeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7
                        TopLevelElementNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Runtime.Serialization.KeyValue`2, System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neut" +
                                    "ral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    HasDataContract = true,
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassReaderDelegate>(global::Type39.ReadKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7FromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassWriterDelegate>(global::Type40.WriteKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ToXml),
                    ChildElementNamespacesListIndex = 261,
                    ContractNamespacesListIndex = 264,
                    MemberNamesListIndex = 266,
                    MemberNamespacesListIndex = 269,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 1166, // KeyValuePairOfdateTimeKeyValuePairOfstringstringtwCi8m_S7
                        NamespaceIndex = 572, // http://schemas.datacontract.org/2004/07/System.Collections.Generic
                        StableNameIndex = 1166, // KeyValuePairOfdateTimeKeyValuePairOfstringstringtwCi8m_S7
                        StableNameNamespaceIndex = 572, // http://schemas.datacontract.org/2004/07/System.Collections.Generic
                        TopLevelElementNameIndex = 1166, // KeyValuePairOfdateTimeKeyValuePairOfstringstringtwCi8m_S7
                        TopLevelElementNamespaceIndex = 572, // http://schemas.datacontract.org/2004/07/System.Collections.Generic
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.KeyValuePair`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.KeyValuePair`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.KeyValuePair`2, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyTo" +
                                    "ken=b03f5f7f11d50a3a")),
                    },
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassReaderDelegate>(global::Type41.ReadKeyValuePairOfdateTimeKeyValuePairOfstringstringtwCi8m_S7FromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassWriterDelegate>(global::Type42.WriteKeyValuePairOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ToXml),
                    ChildElementNamespacesListIndex = 272,
                    ContractNamespacesListIndex = 275,
                    MemberNamesListIndex = 277,
                    MemberNamespacesListIndex = 280,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 1224, // KeyValuePairOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1
                        NamespaceIndex = 572, // http://schemas.datacontract.org/2004/07/System.Collections.Generic
                        StableNameIndex = 1224, // KeyValuePairOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1
                        StableNameNamespaceIndex = 572, // http://schemas.datacontract.org/2004/07/System.Collections.Generic
                        TopLevelElementNameIndex = 1224, // KeyValuePairOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1
                        TopLevelElementNamespaceIndex = 572, // http://schemas.datacontract.org/2004/07/System.Collections.Generic
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.KeyValuePair`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.KeyValuePair`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.KeyValuePair`2, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyTo" +
                                    "ken=b03f5f7f11d50a3a")),
                    },
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassReaderDelegate>(global::Type43.ReadKeyValuePairOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1FromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatClassWriterDelegate>(global::Type44.WriteKeyValuePairOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1ToXml),
                    ChildElementNamespacesListIndex = 283,
                    ContractNamespacesListIndex = 286,
                    MemberNamesListIndex = 288,
                    MemberNamespacesListIndex = 291,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1394, // AppVersion
                        NamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        StableNameIndex = 1394, // AppVersion
                        StableNameNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        TopLevelElementNameIndex = 1394, // AppVersion
                        TopLevelElementNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.AppVersion, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKey" +
                                    "Token=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.AppVersion, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKey" +
                                    "Token=b03f5f7f11d50a3a")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 294,
                    ContractNamespacesListIndex = 306,
                    MemberNamesListIndex = 308,
                    MemberNamespacesListIndex = 320,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1405, // AuthStatus
                        NamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        StableNameIndex = 1405, // AuthStatus
                        StableNameNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        TopLevelElementNameIndex = 1405, // AuthStatus
                        TopLevelElementNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.AuthStatus, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKey" +
                                    "Token=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.AuthStatus, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKey" +
                                    "Token=b03f5f7f11d50a3a")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 332,
                    ContractNamespacesListIndex = 336,
                    MemberNamesListIndex = 338,
                    MemberNamespacesListIndex = 342,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1416, // CrashData
                        NamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        StableNameIndex = 1416, // CrashData
                        StableNameNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        TopLevelElementNameIndex = 1416, // CrashData
                        TopLevelElementNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.CrashData, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKeyT" +
                                    "oken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.CrashData, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKeyT" +
                                    "oken=b03f5f7f11d50a3a")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 346,
                    ContractNamespacesListIndex = 353,
                    MemberNamesListIndex = 355,
                    MemberNamespacesListIndex = 362,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1426, // FeedbackResponseSingle
                        NamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        StableNameIndex = 1426, // FeedbackResponseSingle
                        StableNameNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        TopLevelElementNameIndex = 1426, // FeedbackResponseSingle
                        TopLevelElementNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackResponseSingle, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutra" +
                                    "l, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackResponseSingle, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutra" +
                                    "l, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 369,
                    ContractNamespacesListIndex = 373,
                    MemberNamesListIndex = 375,
                    MemberNamespacesListIndex = 379,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1449, // FeedbackThread
                        NamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        StableNameIndex = 1449, // FeedbackThread
                        StableNameNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        TopLevelElementNameIndex = 1449, // FeedbackThread
                        TopLevelElementNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackThread, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, Publi" +
                                    "cKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackThread, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, Publi" +
                                    "cKeyToken=b03f5f7f11d50a3a")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 383,
                    ContractNamespacesListIndex = 391,
                    MemberNamesListIndex = 393,
                    MemberNamespacesListIndex = 401,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1487, // FeedbackMessage
                        NamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        StableNameIndex = 1487, // FeedbackMessage
                        StableNameNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        TopLevelElementNameIndex = 1487, // FeedbackMessage
                        TopLevelElementNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackMessage, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, Publ" +
                                    "icKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackMessage, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, Publ" +
                                    "icKeyToken=b03f5f7f11d50a3a")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 409,
                    ContractNamespacesListIndex = 428,
                    MemberNamesListIndex = 430,
                    MemberNamespacesListIndex = 449,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1529, // FeedbackAttachment
                        NamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        StableNameIndex = 1529, // FeedbackAttachment
                        StableNameNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        TopLevelElementNameIndex = 1529, // FeedbackAttachment
                        TopLevelElementNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackAttachment, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, P" +
                                    "ublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackAttachment, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, P" +
                                    "ublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 468,
                    ContractNamespacesListIndex = 473,
                    MemberNamesListIndex = 475,
                    MemberNamespacesListIndex = 480,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1548, // InterstitialAdInfo
                        NamespaceIndex = 1567, // http://schemas.datacontract.org/2004/07/AdDuplex.Interstitials.Models
                        StableNameIndex = 1548, // InterstitialAdInfo
                        StableNameNamespaceIndex = 1567, // http://schemas.datacontract.org/2004/07/AdDuplex.Interstitials.Models
                        TopLevelElementNameIndex = 1548, // InterstitialAdInfo
                        TopLevelElementNamespaceIndex = 1567, // http://schemas.datacontract.org/2004/07/AdDuplex.Interstitials.Models
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("AdDuplex.Interstitials.Models.InterstitialAdInfo, AdDuplex, Version=10.1.0.1, Culture=neutral, PublicKeyToken=nu" +
                                    "ll")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("AdDuplex.Interstitials.Models.InterstitialAdInfo, AdDuplex, Version=10.1.0.1, Culture=neutral, PublicKeyToken=nu" +
                                    "ll")),
                    },
                    ChildElementNamespacesListIndex = 485,
                    ContractNamespacesListIndex = 493,
                    MemberNamesListIndex = 495,
                    MemberNamespacesListIndex = 503,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1637, // BannerAdInfo
                        NamespaceIndex = 1650, // http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models
                        StableNameIndex = 1637, // BannerAdInfo
                        StableNameNamespaceIndex = 1650, // http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models
                        TopLevelElementNameIndex = 1637, // BannerAdInfo
                        TopLevelElementNamespaceIndex = 1650, // http://schemas.datacontract.org/2004/07/AdDuplex.Banners.Models
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("AdDuplex.Banners.Models.BannerAdInfo, AdDuplex, Version=10.1.0.1, Culture=neutral, PublicKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("AdDuplex.Banners.Models.BannerAdInfo, AdDuplex, Version=10.1.0.1, Culture=neutral, PublicKeyToken=null")),
                    },
                    ChildElementNamespacesListIndex = 511,
                    ContractNamespacesListIndex = 526,
                    MemberNamesListIndex = 528,
                    MemberNamespacesListIndex = 543,
                }
        };
        static readonly byte[] s_collectionDataContracts_Hashtable = null;
        // Count=11
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::CollectionDataContractEntry[] s_collectionDataContracts = new global::CollectionDataContractEntry[] {
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 314, // ArrayOfKeyValueOfstringDateTimeOffsetU6ho3Bhd
                        NamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 314, // ArrayOfKeyValueOfstringDateTimeOffsetU6ho3Bhd
                        StableNameNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 314, // ArrayOfKeyValueOfstringDateTimeOffsetU6ho3Bhd
                        TopLevelElementNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.DateTimeOffset, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.DateTimeOffset, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.Dictionary`2, System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b" +
                                    "03f5f7f11d50a3a")),
                    },
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionReaderDelegate>(global::Type2.ReadArrayOfKeyValueOfstringDateTimeOffsetU6ho3BhdFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionWriterDelegate>(global::Type3.WriteArrayOfKeyValueOfstringDateTimeOffsetU6ho3BhdToXml),
                    XmlFormatGetOnlyCollectionReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatGetOnlyCollectionReaderDelegate>(global::Type4.ReadArrayOfKeyValueOfstringDateTimeOffsetU6ho3BhdFromXmlIsGetOnly),
                    CollectionItemNameIndex = 418, // KeyValueOfstringDateTimeOffsetU6ho3Bhd
                    KeyNameIndex = 457, // Key
                    ItemNameIndex = 418, // KeyValueOfstringDateTimeOffsetU6ho3Bhd
                    ValueNameIndex = 461, // Value
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.GenericDictionary,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.DateTimeOffset, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 639, // ArrayOfKeyValueOfstringstring
                        NamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 639, // ArrayOfKeyValueOfstringstring
                        StableNameNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 639, // ArrayOfKeyValueOfstringstring
                        TopLevelElementNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.Dictionary`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.Dictionary`2, System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b" +
                                    "03f5f7f11d50a3a")),
                    },
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionReaderDelegate>(global::Type11.ReadArrayOfKeyValueOfstringstringFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionWriterDelegate>(global::Type12.WriteArrayOfKeyValueOfstringstringToXml),
                    XmlFormatGetOnlyCollectionReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatGetOnlyCollectionReaderDelegate>(global::Type13.ReadArrayOfKeyValueOfstringstringFromXmlIsGetOnly),
                    CollectionItemNameIndex = 669, // KeyValueOfstringstring
                    KeyNameIndex = 457, // Key
                    ItemNameIndex = 669, // KeyValueOfstringstring
                    ValueNameIndex = 461, // Value
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.GenericDictionary,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 834, // ArrayOfstring
                        NamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 834, // ArrayOfstring
                        StableNameNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 834, // ArrayOfstring
                        TopLevelElementNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, Publ" +
                                    "icKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11" +
                                    "d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, Publ" +
                                    "icKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11" +
                                    "d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1, System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7" +
                                    "f11d50a3a")),
                    },
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionReaderDelegate>(global::Type22.ReadArrayOfstringFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionWriterDelegate>(global::Type23.WriteArrayOfstringToXml),
                    XmlFormatGetOnlyCollectionReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatGetOnlyCollectionReaderDelegate>(global::Type24.ReadArrayOfstringFromXmlIsGetOnly),
                    CollectionItemNameIndex = 180, // string
                    KeyNameIndex = -1,
                    ItemNameIndex = 180, // string
                    ValueNameIndex = -1,
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.GenericList,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 848, // ArrayOfduration
                        NamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 848, // ArrayOfduration
                        StableNameNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 848, // ArrayOfduration
                        TopLevelElementNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1[[System.TimeSpan, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKey" +
                                    "Token=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3" +
                                    "a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1[[System.TimeSpan, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKey" +
                                    "Token=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3" +
                                    "a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1, System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7" +
                                    "f11d50a3a")),
                    },
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionReaderDelegate>(global::Type25.ReadArrayOfdurationFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionWriterDelegate>(global::Type26.WriteArrayOfdurationToXml),
                    XmlFormatGetOnlyCollectionReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatGetOnlyCollectionReaderDelegate>(global::Type27.ReadArrayOfdurationFromXmlIsGetOnly),
                    CollectionItemNameIndex = 187, // duration
                    KeyNameIndex = -1,
                    ItemNameIndex = 187, // duration
                    ValueNameIndex = -1,
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.GenericList,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.TimeSpan, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 864, // ArrayOfdateTime
                        NamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 864, // ArrayOfdateTime
                        StableNameNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 864, // ArrayOfdateTime
                        TopLevelElementNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKey" +
                                    "Token=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3" +
                                    "a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKey" +
                                    "Token=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3" +
                                    "a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1, System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7" +
                                    "f11d50a3a")),
                    },
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionReaderDelegate>(global::Type28.ReadArrayOfdateTimeFromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionWriterDelegate>(global::Type29.WriteArrayOfdateTimeToXml),
                    XmlFormatGetOnlyCollectionReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatGetOnlyCollectionReaderDelegate>(global::Type30.ReadArrayOfdateTimeFromXmlIsGetOnly),
                    CollectionItemNameIndex = 111, // dateTime
                    KeyNameIndex = -1,
                    ItemNameIndex = 111, // dateTime
                    ValueNameIndex = -1,
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.GenericList,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 880, // ArrayOfKeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1
                        NamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 880, // ArrayOfKeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1
                        StableNameNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 880, // ArrayOfKeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1
                        TopLevelElementNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.Dictionary`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.Dictionary`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.Dictionary`2, System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b" +
                                    "03f5f7f11d50a3a")),
                    },
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionReaderDelegate>(global::Type31.ReadArrayOfKeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1FromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionWriterDelegate>(global::Type32.WriteArrayOfKeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1ToXml),
                    XmlFormatGetOnlyCollectionReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatGetOnlyCollectionReaderDelegate>(global::Type33.ReadArrayOfKeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1FromXmlIsGetOnly),
                    CollectionItemNameIndex = 969, // KeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1
                    KeyNameIndex = 457, // Key
                    ItemNameIndex = 969, // KeyValueOfintArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ty7Ep6D1
                    ValueNameIndex = 461, // Value
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.GenericDictionary,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1051, // ArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7
                        NamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 1051, // ArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7
                        StableNameNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 1051, // ArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7
                        TopLevelElementNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.Dictionary`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.Dictionary`2, System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b" +
                                    "03f5f7f11d50a3a")),
                    },
                    XmlFormatReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionReaderDelegate>(global::Type36.ReadArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7FromXml),
                    XmlFormatWriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatCollectionWriterDelegate>(global::Type37.WriteArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7ToXml),
                    XmlFormatGetOnlyCollectionReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.XmlFormatGetOnlyCollectionReaderDelegate>(global::Type38.ReadArrayOfKeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7FromXmlIsGetOnly),
                    CollectionItemNameIndex = 1112, // KeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7
                    KeyNameIndex = 457, // Key
                    ItemNameIndex = 1112, // KeyValueOfdateTimeKeyValuePairOfstringstringtwCi8m_S7
                    ValueNameIndex = 461, // Value
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.GenericDictionary,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Runtime.Serialization.KeyValue`2[[System.DateTime, System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.Collections.Generic.KeyValuePair`2[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Private.DataContractSerialization, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1310, // ArrayOfAppVersion
                        NamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        StableNameIndex = 1310, // ArrayOfAppVersion
                        StableNameNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        TopLevelElementNameIndex = 1310, // ArrayOfAppVersion
                        TopLevelElementNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.List`1[[Microsoft.HockeyApp.Model.AppVersion, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.List`1[[Microsoft.HockeyApp.Model.AppVersion, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1, System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7" +
                                    "f11d50a3a")),
                    },
                    CollectionItemNameIndex = 1394, // AppVersion
                    KeyNameIndex = -1,
                    ItemNameIndex = 1394, // AppVersion
                    ValueNameIndex = -1,
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.GenericList,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.AppVersion, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKey" +
                                "Token=b03f5f7f11d50a3a")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1464, // ArrayOfFeedbackMessage
                        NamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        StableNameIndex = 1464, // ArrayOfFeedbackMessage
                        StableNameNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        TopLevelElementNameIndex = 1464, // ArrayOfFeedbackMessage
                        TopLevelElementNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.List`1[[Microsoft.HockeyApp.Model.FeedbackMessage, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.List`1[[Microsoft.HockeyApp.Model.FeedbackMessage, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1, System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7" +
                                    "f11d50a3a")),
                    },
                    CollectionItemNameIndex = 1487, // FeedbackMessage
                    KeyNameIndex = -1,
                    ItemNameIndex = 1487, // FeedbackMessage
                    ValueNameIndex = -1,
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.GenericList,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackMessage, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, Publ" +
                                "icKeyToken=b03f5f7f11d50a3a")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1503, // ArrayOfFeedbackAttachment
                        NamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        StableNameIndex = 1503, // ArrayOfFeedbackAttachment
                        StableNameNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        TopLevelElementNameIndex = 1503, // ArrayOfFeedbackAttachment
                        TopLevelElementNamespaceIndex = 1328, // http://schemas.datacontract.org/2004/07/Microsoft.HockeyApp.Model
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.List`1[[Microsoft.HockeyApp.Model.FeedbackAttachment, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.List`1[[Microsoft.HockeyApp.Model.FeedbackAttachment, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1, System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7" +
                                    "f11d50a3a")),
                    },
                    CollectionItemNameIndex = 1529, // FeedbackAttachment
                    KeyNameIndex = -1,
                    ItemNameIndex = 1529, // FeedbackAttachment
                    ValueNameIndex = -1,
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.GenericList,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.HockeyApp.Model.FeedbackAttachment, Microsoft.HockeyApp.Core45, Version=4.1.5.1043, Culture=neutral, P" +
                                "ublicKeyToken=b03f5f7f11d50a3a")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 1714, // ArrayOfanyType
                        NamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 1714, // ArrayOfanyType
                        StableNameNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 1714, // ArrayOfanyType
                        TopLevelElementNamespaceIndex = 360, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object[], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object[], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    CollectionItemNameIndex = 155, // anyType
                    KeyNameIndex = -1,
                    ItemNameIndex = 155, // anyType
                    ValueNameIndex = -1,
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.Array,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                }
        };
        static readonly byte[] s_enumDataContracts_Hashtable = null;
        // Count=4
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::EnumDataContractEntry[] s_enumDataContracts = new global::EnumDataContractEntry[] {
                new global::EnumDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 719, // AdBundleState
                        NamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        StableNameIndex = 719, // AdBundleState
                        StableNameNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        TopLevelElementNameIndex = 719, // AdBundleState
                        TopLevelElementNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.AdBundleState, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.AdBundleState, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    },
                    BaseContractNameIndex = -1,
                    BaseContractNamespaceIndex = -1,
                    ChildElementNamesListIndex = 103,
                    MemberCount = 5,
                }, 
                new global::EnumDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 758, // NetworkResultContentType
                        NamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        StableNameIndex = 758, // NetworkResultContentType
                        StableNameNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        TopLevelElementNameIndex = 758, // NetworkResultContentType
                        TopLevelElementNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.NetworkResultContentType, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.NetworkResultContentType, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    },
                    BaseContractNameIndex = -1,
                    BaseContractNamespaceIndex = -1,
                    ChildElementNamesListIndex = 180,
                    MemberCount = 2,
                    MemberListIndex = 5,
                }, 
                new global::EnumDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 783, // NetworkRequestMethod
                        NamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        StableNameIndex = 783, // NetworkRequestMethod
                        StableNameNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        TopLevelElementNameIndex = 783, // NetworkRequestMethod
                        TopLevelElementNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.NetworkRequestMethod, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.NetworkRequestMethod, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    },
                    BaseContractNameIndex = -1,
                    BaseContractNamespaceIndex = -1,
                    ChildElementNamesListIndex = 183,
                    MemberCount = 3,
                    MemberListIndex = 7,
                }, 
                new global::EnumDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsValueType = true,
                        NameIndex = 804, // NetworkRequestState
                        NamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        StableNameIndex = 804, // NetworkRequestState
                        StableNameNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        TopLevelElementNameIndex = 804, // NetworkRequestState
                        TopLevelElementNamespaceIndex = 264, // http://schemas.datacontract.org/2004/07/VungleSDK
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.NetworkRequestState, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("VungleSDK.NetworkRequestState, VungleSDK, Version=1.3.15.0, Culture=neutral, PublicKeyToken=null")),
                    },
                    BaseContractNameIndex = -1,
                    BaseContractNamespaceIndex = -1,
                    ChildElementNamesListIndex = 187,
                    MemberCount = 3,
                    MemberListIndex = 10,
                }
        };
        static readonly byte[] s_xmlDataContracts_Hashtable = null;
        // Count=0
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::XmlDataContractEntry[] s_xmlDataContracts = new global::XmlDataContractEntry[0];
        static readonly byte[] s_jsonDelegatesList_Hashtable = null;
        // Count=13
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::JsonDelegateEntry[] s_jsonDelegatesList = new global::JsonDelegateEntry[] {
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 73,
                    IsCollection = true,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionWriterDelegate>(global::Type49.WriteArrayOfAppVersionToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionReaderDelegate>(global::Type48.ReadArrayOfAppVersionFromJson),
                    GetOnlyReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatGetOnlyCollectionReaderDelegate>(global::Type50.ReadArrayOfAppVersionFromJsonIsGetOnly),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 74,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type54.WriteAppVersionToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type53.ReadAppVersionFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 75,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type58.WriteAuthStatusToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type57.ReadAuthStatusFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 76,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type62.WriteCrashDataToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type61.ReadCrashDataFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 77,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type66.WriteFeedbackResponseSingleToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type65.ReadFeedbackResponseSingleFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 78,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type70.WriteFeedbackThreadToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type69.ReadFeedbackThreadFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 79,
                    IsCollection = true,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionWriterDelegate>(global::Type75.WriteArrayOfFeedbackMessageToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionReaderDelegate>(global::Type74.ReadArrayOfFeedbackMessageFromJson),
                    GetOnlyReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatGetOnlyCollectionReaderDelegate>(global::Type76.ReadArrayOfFeedbackMessageFromJsonIsGetOnly),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 80,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type80.WriteFeedbackMessageToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type79.ReadFeedbackMessageFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 81,
                    IsCollection = true,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionWriterDelegate>(global::Type85.WriteArrayOfFeedbackAttachmentToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionReaderDelegate>(global::Type84.ReadArrayOfFeedbackAttachmentFromJson),
                    GetOnlyReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatGetOnlyCollectionReaderDelegate>(global::Type86.ReadArrayOfFeedbackAttachmentFromJsonIsGetOnly),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 82,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type90.WriteFeedbackAttachmentToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type89.ReadFeedbackAttachmentFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 83,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type94.WriteInterstitialAdInfoToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type93.ReadInterstitialAdInfoFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 84,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type98.WriteBannerAdInfoToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type97.ReadBannerAdInfoFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 85,
                    IsCollection = true,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionWriterDelegate>(global::Type103.WriteArrayOfanyTypeToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionReaderDelegate>(global::Type102.ReadArrayOfanyTypeFromJson),
                    GetOnlyReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatGetOnlyCollectionReaderDelegate>(global::Type104.ReadArrayOfanyTypeFromJsonIsGetOnly),
                }
        };
        static char[] s_stringPool = new char[] {
            'b','o','o','l','e','a','n','\0','h','t','t','p',':','/','/','w','w','w','.','w','3','.','o','r','g','/','2','0','0','1',
            '/','X','M','L','S','c','h','e','m','a','\0','h','t','t','p',':','/','/','s','c','h','e','m','a','s','.','m','i','c','r',
            'o','s','o','f','t','.','c','o','m','/','2','0','0','3','/','1','0','/','S','e','r','i','a','l','i','z','a','t','i','o',
            'n','/','\0','b','a','s','e','6','4','B','i','n','a','r','y','\0','c','h','a','r','\0','d','a','t','e','T','i','m','e','\0',
            'd','e','c','i','m','a','l','\0','d','o','u','b','l','e','\0','f','l','o','a','t','\0','g','u','i','d','\0','i','n','t','\0',
            'l','o','n','g','\0','a','n','y','T','y','p','e','\0','Q','N','a','m','e','\0','s','h','o','r','t','\0','b','y','t','e','\0',
            's','t','r','i','n','g','\0','d','u','r','a','t','i','o','n','\0','u','n','s','i','g','n','e','d','B','y','t','e','\0','u',
            'n','s','i','g','n','e','d','I','n','t','\0','u','n','s','i','g','n','e','d','L','o','n','g','\0','u','n','s','i','g','n',
            'e','d','S','h','o','r','t','\0','a','n','y','U','R','I','\0','A','d','B','u','n','d','l','e','\0','h','t','t','p',':','/',
            '/','s','c','h','e','m','a','s','.','d','a','t','a','c','o','n','t','r','a','c','t','.','o','r','g','/','2','0','0','4',
            '/','0','7','/','V','u','n','g','l','e','S','D','K','\0','A','r','r','a','y','O','f','K','e','y','V','a','l','u','e','O',
            'f','s','t','r','i','n','g','D','a','t','e','T','i','m','e','O','f','f','s','e','t','U','6','h','o','3','B','h','d','\0',
            'h','t','t','p',':','/','/','s','c','h','e','m','a','s','.','m','i','c','r','o','s','o','f','t','.','c','o','m','/','2',
            '0','0','3','/','1','0','/','S','e','r','i','a','l','i','z','a','t','i','o','n','/','A','r','r','a','y','s','\0','K','e',
            'y','V','a','l','u','e','O','f','s','t','r','i','n','g','D','a','t','e','T','i','m','e','O','f','f','s','e','t','U','6',
            'h','o','3','B','h','d','\0','K','e','y','\0','V','a','l','u','e','\0','D','a','t','e','T','i','m','e','O','f','f','s','e',
            't','\0','h','t','t','p',':','/','/','s','c','h','e','m','a','s','.','d','a','t','a','c','o','n','t','r','a','c','t','.',
            'o','r','g','/','2','0','0','4','/','0','7','/','S','y','s','t','e','m','\0','K','e','y','V','a','l','u','e','P','a','i',
            'r','O','f','s','t','r','i','n','g','D','a','t','e','T','i','m','e','O','f','f','s','e','t','U','6','h','o','3','B','h',
            'd','\0','h','t','t','p',':','/','/','s','c','h','e','m','a','s','.','d','a','t','a','c','o','n','t','r','a','c','t','.',
            'o','r','g','/','2','0','0','4','/','0','7','/','S','y','s','t','e','m','.','C','o','l','l','e','c','t','i','o','n','s',
            '.','G','e','n','e','r','i','c','\0','A','r','r','a','y','O','f','K','e','y','V','a','l','u','e','O','f','s','t','r','i',
            'n','g','s','t','r','i','n','g','\0','K','e','y','V','a','l','u','e','O','f','s','t','r','i','n','g','s','t','r','i','n',
            'g','\0','K','e','y','V','a','l','u','e','P','a','i','r','O','f','s','t','r','i','n','g','s','t','r','i','n','g','\0','A',
            'd','B','u','n','d','l','e','S','t','a','t','e','\0','1','\0','2','\0','3','\0','4','\0','5','\0','N','e','t','w','o','r','k',
            'R','e','q','u','e','s','t','\0','N','e','t','w','o','r','k','R','e','s','u','l','t','C','o','n','t','e','n','t','T','y',
            'p','e','\0','N','e','t','w','o','r','k','R','e','q','u','e','s','t','M','e','t','h','o','d','\0','N','e','t','w','o','r',
            'k','R','e','q','u','e','s','t','S','t','a','t','e','\0','A','d','S','e','s','s','i','o','n','\0','A','r','r','a','y','O',
            'f','s','t','r','i','n','g','\0','A','r','r','a','y','O','f','d','u','r','a','t','i','o','n','\0','A','r','r','a','y','O',
            'f','d','a','t','e','T','i','m','e','\0','A','r','r','a','y','O','f','K','e','y','V','a','l','u','e','O','f','i','n','t',
            'A','r','r','a','y','O','f','K','e','y','V','a','l','u','e','O','f','d','a','t','e','T','i','m','e','K','e','y','V','a',
            'l','u','e','P','a','i','r','O','f','s','t','r','i','n','g','s','t','r','i','n','g','t','w','C','i','8','m','_','S','7',
            't','y','7','E','p','6','D','1','\0','K','e','y','V','a','l','u','e','O','f','i','n','t','A','r','r','a','y','O','f','K',
            'e','y','V','a','l','u','e','O','f','d','a','t','e','T','i','m','e','K','e','y','V','a','l','u','e','P','a','i','r','O',
            'f','s','t','r','i','n','g','s','t','r','i','n','g','t','w','C','i','8','m','_','S','7','t','y','7','E','p','6','D','1',
            '\0','A','r','r','a','y','O','f','K','e','y','V','a','l','u','e','O','f','d','a','t','e','T','i','m','e','K','e','y','V',
            'a','l','u','e','P','a','i','r','O','f','s','t','r','i','n','g','s','t','r','i','n','g','t','w','C','i','8','m','_','S',
            '7','\0','K','e','y','V','a','l','u','e','O','f','d','a','t','e','T','i','m','e','K','e','y','V','a','l','u','e','P','a',
            'i','r','O','f','s','t','r','i','n','g','s','t','r','i','n','g','t','w','C','i','8','m','_','S','7','\0','K','e','y','V',
            'a','l','u','e','P','a','i','r','O','f','d','a','t','e','T','i','m','e','K','e','y','V','a','l','u','e','P','a','i','r',
            'O','f','s','t','r','i','n','g','s','t','r','i','n','g','t','w','C','i','8','m','_','S','7','\0','K','e','y','V','a','l',
            'u','e','P','a','i','r','O','f','i','n','t','A','r','r','a','y','O','f','K','e','y','V','a','l','u','e','O','f','d','a',
            't','e','T','i','m','e','K','e','y','V','a','l','u','e','P','a','i','r','O','f','s','t','r','i','n','g','s','t','r','i',
            'n','g','t','w','C','i','8','m','_','S','7','t','y','7','E','p','6','D','1','\0','A','r','r','a','y','O','f','A','p','p',
            'V','e','r','s','i','o','n','\0','h','t','t','p',':','/','/','s','c','h','e','m','a','s','.','d','a','t','a','c','o','n',
            't','r','a','c','t','.','o','r','g','/','2','0','0','4','/','0','7','/','M','i','c','r','o','s','o','f','t','.','H','o',
            'c','k','e','y','A','p','p','.','M','o','d','e','l','\0','A','p','p','V','e','r','s','i','o','n','\0','A','u','t','h','S',
            't','a','t','u','s','\0','C','r','a','s','h','D','a','t','a','\0','F','e','e','d','b','a','c','k','R','e','s','p','o','n',
            's','e','S','i','n','g','l','e','\0','F','e','e','d','b','a','c','k','T','h','r','e','a','d','\0','A','r','r','a','y','O',
            'f','F','e','e','d','b','a','c','k','M','e','s','s','a','g','e','\0','F','e','e','d','b','a','c','k','M','e','s','s','a',
            'g','e','\0','A','r','r','a','y','O','f','F','e','e','d','b','a','c','k','A','t','t','a','c','h','m','e','n','t','\0','F',
            'e','e','d','b','a','c','k','A','t','t','a','c','h','m','e','n','t','\0','I','n','t','e','r','s','t','i','t','i','a','l',
            'A','d','I','n','f','o','\0','h','t','t','p',':','/','/','s','c','h','e','m','a','s','.','d','a','t','a','c','o','n','t',
            'r','a','c','t','.','o','r','g','/','2','0','0','4','/','0','7','/','A','d','D','u','p','l','e','x','.','I','n','t','e',
            'r','s','t','i','t','i','a','l','s','.','M','o','d','e','l','s','\0','B','a','n','n','e','r','A','d','I','n','f','o','\0',
            'h','t','t','p',':','/','/','s','c','h','e','m','a','s','.','d','a','t','a','c','o','n','t','r','a','c','t','.','o','r',
            'g','/','2','0','0','4','/','0','7','/','A','d','D','u','p','l','e','x','.','B','a','n','n','e','r','s','.','M','o','d',
            'e','l','s','\0','A','r','r','a','y','O','f','a','n','y','T','y','p','e','\0','A','d','T','y','p','e','\0','B','e','s','t',
            'B','e','f','o','r','e','\0','C','a','m','p','a','i','g','n','\0','I','d','\0','M','r','a','i','d','C','o','n','t','e','n',
            't','\0','P','a','r','t','s','D','a','t','e','\0','P','a','r','t','s','M','D','5','\0','P','a','r','t','s','R','e','a','d',
            'y','\0','P','a','r','t','s','U','r','l','s','\0','R','e','a','d','y','I','n','\0','R','e','c','e','i','v','e','d','A','t',
            '\0','R','e','q','u','e','s','t','A','d','\0','S','t','a','t','u','s','\0','T','e','m','p','l','a','t','e','S','e','t','t',
            'i','n','g','M','a','p','\0','D','a','t','e','T','i','m','e','\0','O','f','f','s','e','t','M','i','n','u','t','e','s','\0',
            'k','e','y','\0','v','a','l','u','e','\0','A','s','F','i','l','e','\0','C','i','d','\0','C','i','d','2','\0','D','a','t','a',
            '\0','E','x','p','e','c','t','e','d','C','o','n','t','e','n','t','T','y','p','e','\0','G','r','o','u','p','\0','H','e','a',
            'd','e','r','s','\0','K','e','e','p','F','i','l','e','\0','L','o','c','a','l','C','a','c','h','e','F','i','l','e','F','o',
            'l','d','e','r','N','a','m','e','\0','M','a','x','B','a','c','k','o','f','f','P','e','r','i','o','d','\0','M','e','t','h',
            'o','d','\0','P','r','o','g','r','e','s','s','i','v','e','B','a','c','k','o','f','f','E','n','a','b','l','e','d','\0','Q',
            'u','e','r','y','\0','R','e','t','r','y','C','o','u','n','t','\0','R','e','t','r','y','P','a','s','s','\0','R','e','t','r',
            'y','P','e','r','i','o','d','\0','S','t','a','t','e','\0','U','r','l','\0','U','s','e','G','z','i','p','\0','W','h','e','n',
            '\0','A','d','D','a','t','a','\0','A','d','D','u','r','a','t','i','o','n','\0','C','l','i','c','k','s','\0','D','o','w','n',
            'l','o','a','d','C','l','i','c','k','e','d','\0','E','n','d','T','i','m','e','\0','E','r','r','o','r','L','i','s','t','\0',
            'E','x','t','r','a','I','n','f','o','\0','I','n','c','e','n','t','i','v','i','z','e','d','\0','P','l','a','c','e','m','e',
            'n','t','\0','P','l','a','y','s','D','u','r','a','t','i','o','n','\0','P','l','a','y','s','S','t','a','r','t','\0','S','t',
            'a','r','t','T','i','m','e','\0','U','s','e','r','\0','U','s','e','r','A','c','t','i','o','n','s','\0','i','s','C','o','m',
            'p','l','e','t','e','d','V','i','e','w','\0','a','p','p','_','i','d','\0','a','p','p','s','i','z','e','\0','d','e','v','i',
            'c','e','_','f','a','m','i','l','y','\0','i','d','\0','m','a','n','d','a','t','o','r','y','\0','m','i','n','i','m','u','m',
            '_','o','s','_','v','e','r','s','i','o','n','\0','n','o','t','e','s','\0','s','h','o','r','t','v','e','r','s','i','o','n',
            '\0','t','i','m','e','s','t','a','m','p','\0','t','i','t','l','e','\0','v','e','r','s','i','o','n','\0','a','u','i','d','\0',
            'i','u','i','d','\0','s','t','a','t','u','s','\0','c','o','n','t','a','c','t','\0','d','e','s','c','r','i','p','t','i','o',
            'n','\0','l','o','g','\0','s','d','k','\0','s','d','k','_','v','e','r','s','i','o','n','\0','u','s','e','r','I','D','\0','f',
            'e','e','d','b','a','c','k','\0','t','o','k','e','n','\0','c','r','e','a','t','e','d','_','a','t','\0','e','m','a','i','l',
            '\0','m','e','s','s','a','g','e','s','\0','n','a','m','e','\0','M','o','d','e','l','\0','T','e','x','t','\0','a','p','p','_',
            'v','e','r','s','o','n','_','i','d','\0','a','t','t','a','c','h','m','e','n','t','s','\0','c','l','e','a','n','_','t','e',
            'x','t','\0','g','r','a','v','a','t','a','r','_','h','a','s','h','\0','i','n','t','e','r','n','a','l','\0','o','e','m','\0',
            'o','s','_','v','e','r','s','i','o','n','\0','s','u','b','j','e','c','t','\0','u','s','e','r','_','s','t','r','i','n','g',
            '\0','v','i','a','\0','f','i','l','e','_','n','a','m','e','\0','u','r','l','\0','H','a','s','h','\0','I','m','a','g','e','U',
            'R','L','\0','M','a','r','k','e','t','p','l','a','c','e','A','p','p','I','d','\0','S','i','z','e','d','A','d','I','d','\0',
            'T','i','m','e','\0','U','p','d','a','t','e','d','O','n','\0','L','i','n','e','1','\0','L','i','n','e','2','\0','L','i','n',
            'e','3','\0','L','i','n','e','4','\0','P','h','o','n','e','N','u','m','b','e','r','\0','S','h','o','w','L','o','g','o','\0'
            };
    }
}
