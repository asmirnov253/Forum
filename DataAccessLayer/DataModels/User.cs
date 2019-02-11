using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace DataAccessLayer.DataModels
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
