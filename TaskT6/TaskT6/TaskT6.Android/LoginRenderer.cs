using Android.App;
using System;
using TaskT6.Droid;
using TaskT6.ViewModels;
using TaskT6.Views;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(ProviderLoginPage), typeof(LoginRenderer))]
namespace TaskT6.Droid
{
    public class LoginRenderer : PageRenderer
    {
        public LoginRenderer()
        {

        }
        bool showlogin = true;
        private OAuth2Authenticator GetAuthenticator()
        {
            OAuth2Authenticator auth = null;
            
                auth = new OAuth2Authenticator(
                                clientId: "2262635877322852",
                                scope: "",
                                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html")
                        );
           
            return auth;
        }
        public OAuth2Request GetRequest()
        {
            OAuth2Request request = null;
           
                request = new OAuth2Request("GET",
                    new Uri("https://graph.facebook.com/me?fields=name,picture,cover,birthday"), null, null);
           
            return request;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            var activity = this.Context as Activity;
            if(showlogin && FacebookAuth.User==null)
            {
                showlogin = false;
                var loginPage = Element as ProviderLoginPage;
             
                var auth = GetAuthenticator();
                auth.Completed += async (sender, eventArgs) =>
                 {
                     if (eventArgs.IsAuthenticated)
                     {
                         var request = GetRequest();
                         request.Account = eventArgs.Account;
                         var fbReponse = await request.GetResponseAsync();
                         FacebookAuth.SetUser(fbReponse.GetResponseText());
                     }
                     else
                     {
                            
                     }
                 };
                activity.StartActivity(auth.GetUI(activity));
            }
        }
    }
}