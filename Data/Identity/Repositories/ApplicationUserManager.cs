using Data.Identity.Entities;
using Microsoft.AspNet.Identity;

namespace Data.Identity.Repositories
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }
    }
}
