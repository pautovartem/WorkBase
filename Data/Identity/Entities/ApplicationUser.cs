using Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace Data.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual User User { get; set; }
    }
}
