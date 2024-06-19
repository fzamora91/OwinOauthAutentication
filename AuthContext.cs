using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OwinOauthAutentication
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {

       /* public AuthContext() 
        { 
        
        
        }

        public AuthContext(string nameOrConnectionString)
        {

            var s = System.Configuration.ConfigurationManager.ConnectionStrings["AuthContext"].ConnectionString;

           
        }*/


        public AuthContext(string nameOrConnectionString)
        : base(nameOrConnectionString)
        {

        }

        public static AuthContext Create()
        {

            //System.Configuration.ConfigurationManager.ConnectionStrings.Add(new System.Configuration.ConnectionStringSettings("AuthContext", "Data Source=monitoring.db"));

            var s = System.Configuration.ConfigurationManager.ConnectionStrings["AuthContextCS"].ConnectionString;
            return new AuthContext("AuthContextCS");
        }


    }
}
