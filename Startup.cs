/*using Microsoft.Owin.Security.OAuth;
using Owin;
using OwinOauthAutentication.App_Start;
using System.Web.Http;*/

using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OwinOauthAutentication.App_Start;


namespace OwinOauthAutentication
{
    public class Startup
    {


        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }



        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };


            //Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }



    }
}
