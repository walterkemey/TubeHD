using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTube.YouTube.Json
{
    public class SubscriptionResultObject
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string nextPageToken { get; set; }
        public PageInfo pageInfo { get; set; }
        public List<Subscription> items { get; set; }


        public class PageInfo
        {
            public int totalResults { get; set; }
            public int resultsPerPage { get; set; }
        }

        public class ResourceId
        {
            public string kind { get; set; }
            public string channelId { get; set; }
        }

        public class ContentDetails
        {
            public int totalItemCount { get; set; }
            public int newItemCount { get; set; }
            public string activityType { get; set; }
        }
    }
}
