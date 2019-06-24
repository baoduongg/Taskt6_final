using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TaskT6.Views;
using Xamarin.Auth;
using Xamarin.Forms;

namespace TaskT6.ViewModels
{
   public static class FacebookAuth
    {
        public static UserFB User;
        public static bool loginfb = false;
        public static void SetUser(string response)
        {
            loginfb = true;
            
                User = JsonConvert.DeserializeObject<UserFB>(response);

            Application.Current.MainPage = new PageMaster();
        }
     
    }
}
