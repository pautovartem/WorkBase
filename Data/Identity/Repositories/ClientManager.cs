using Data.EF;
using Data.Entities;
using Data.Identity.Interfaces;

namespace Data.Identity.Repositories
{
    public class ClientManager : IClientManager
    {
        public WorkBaseContext Database { get; set; }
        public ClientManager(WorkBaseContext db)
        {
            Database = db;
        }

        public void Create(User item)
        {
            Database.Users.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
