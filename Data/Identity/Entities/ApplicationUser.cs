using Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual User User { get; set; }
    }
}
