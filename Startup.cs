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
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Configuration;
using System.Configuration.Provider;

[assembly: OwinStartup(typeof(OwinOauthAutentication.Startup))]
namespace OwinOauthAutentication
{

    
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthentication();



            /*var builder = new DbConnectionStringBuilder();
            builder.ConnectionString = " Data Source=monitoring.db ";*/
            /*var providerName = (string)builder["ProviderName"];
            builder.Remove("ProviderName");*/

            var providerName="System.Data.SqlClient";

            //DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SQLite.instance);



           /* var factory = DbProviderFactories.GetFactory(providerName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = builder.ConnectionString;*/




            //DbProviderFactories.RegisterFactory("System.Data.SqlClient", typeof(System.Data.SqlClient.SqlClientFactory));

            //services.AddDbContext<OwinOauthAutentication.AuthContext>(dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlite("Data Source=myapp.db"));

            //services.AddOcelot(Configuration);
        }

        public void Configuration(IAppBuilder app)
        {

            ConfigureOAuth(app);
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);


           /* HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);*/
            
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



            //app.MapControllers();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
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
