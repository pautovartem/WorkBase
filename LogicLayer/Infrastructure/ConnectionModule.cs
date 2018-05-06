using Ninject.Modules;
using Data.Interfaces;
using Data.Repositories;
using Data.Identity.Interfaces;
using Data.Identity.Repositories;

namespace LogicLayer.Infrastructure
{
    public class ConnectionModule : NinjectModule
    {
        private string connectionString;

        public ConnectionModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
            Bind<IUnitOfWorkIdentity>().To<IdentityUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
