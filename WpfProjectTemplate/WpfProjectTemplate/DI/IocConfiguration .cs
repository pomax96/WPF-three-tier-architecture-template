using System.Net;
using Ninject.Modules;
using WpfProjectTemplate.BLL.Interface;
using WpfProjectTemplate.BLL.Interface.DAL;
using WpfProjectTemplate.BLL.Service;
using WpfProjectTemplate.DAL.Repository;
using WpfProjectTemplate.ViewModel;

namespace WpfProjectTemplate.DI
{
    public class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthenticationService>().To<AuthenticationService>().InSingletonScope(); // Reuse same storage every time

            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();

            Bind<IRoleRepository>().To<RoleRepository>().InSingletonScope();

            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();

            Bind<MainViewModel>().ToSelf().InTransientScope(); // Create new instance every time
        }
    }
}