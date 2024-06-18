using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace OwinOauthAutentication
{
    public class AuthContext : IdentityDbContext<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>
    {

        public AuthContext()
            : base("AuthContext")
        {
        }


    }
}
