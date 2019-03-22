using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeTube.YouTube;
using PrimeTube.Common;

namespace PrimeTube.ViewModel
{
    public class UserViewModel : BindableBase
    {
        #region Activities
        private Google.Apis.YouTube.v3.Data.Activity _activitiy;
        public Google.Apis.YouTube.v3.Data.Activity activitiy
        {
            get { return _activitiy; }
            set { this.SetProperty(ref this._activitiy, value); }
        }

        private bool IsLoadingActivities = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelid"></param>
        /// <returns></returns>
        public async Task LoadActivities(string channelid = null)
        {
            if (IsLoadingActivities)
                return;
            IsLoadingActivities = true;

            //https://developers.google.com/youtube/v3/docs/channelSections/list#try-it
            var videoInfoRequest = YoutubeService.service.Activities.List("contentDetails,id,snippet");
            if (channelid != null)
                videoInfoRequest.ChannelId = channelid;
            else
                videoInfoRequest.Home = true; // must be authenticated
            try
            {
                var videoResultResponse = await videoInfoRequest.ExecuteAsync();

                if (videoResultResponse.Items.Count >= 0)
                {
                    Google.Apis.YouTube.v3.Data.Activity videoNew = videoResultResponse.Items[0];

                    activitiy = videoNew;
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
            }
            IsLoadingActivities = false;
        }
        #endregion
    }
}
