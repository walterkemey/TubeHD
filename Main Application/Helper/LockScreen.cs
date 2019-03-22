using System;
using System.Collections.Generic;
using System.Text;
using Windows.System.Display;

namespace PrimeTube.Helper
{
    public class LockScreen
    {
        private static DisplayRequest g_DisplayRequest = null;

        public static bool DisableLockScreenTimeOut()
        {
            try
            {
                if (g_DisplayRequest == null)
                {
                    // This call creates an instance of the displayRequest object 
                    g_DisplayRequest = new DisplayRequest();
                }
            }
            catch (Exception ex)
            {
                //         rootPage.NotifyUser("Error Creating Display Request: " + ex.Message, NotifyType.ErrorMessage);
            }

            if (g_DisplayRequest != null)
            {
                try
                {
                    // This call activates a display-required request. If successful,  
                    // the screen is guaranteed not to turn off automatically due to user inactivity. 
                    g_DisplayRequest.RequestActive();
                    //         drCount += 1;
                    //             rootPage.NotifyUser("Display request activated (" + drCount + ")", NotifyType.StatusMessage);

                    return true;
                }
                catch (Exception ex)
                {
                    //               rootPage.NotifyUser("Error: " + ex.Message, NotifyType.ErrorMessage);
                }
            }
            return false;
        }

        public static bool Re_EnableLockScreenTimeOut()
        {
            if (g_DisplayRequest != null)
            {
                try
                {
                    // This call de-activates the display-required request. If successful, the screen 
                    // might be turned off automatically due to a user inactivity, depending on the 
                    // power policy settings of the system. The requestRelease method throws an exception  
                    // if it is called before a successful requestActive call on this object. 
                    g_DisplayRequest.RequestRelease();
                    //             drCount -= 1;
                    //                  rootPage.NotifyUser("Display request released (" + drCount + ")", NotifyType.StatusMessage);

                    g_DisplayRequest = null;
                    return true;
                }
                catch (Exception ex)
                {
                    //                rootPage.NotifyUser("Error: " + ex.Message, NotifyType.ErrorMessage);
                }
            }
            return false;
        }
    }
}
