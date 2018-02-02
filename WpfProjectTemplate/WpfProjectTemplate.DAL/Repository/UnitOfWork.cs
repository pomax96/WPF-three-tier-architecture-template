using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProjectTemplate.BLL.Interface.DAL;
using WpfProjectTemplate.BLL.PresentationModel;
using WpfProjectTemplate.DAL.EF;
using WpfProjectTemplate.DAL.Entities;

namespace WpfProjectTemplate.DAL.Repository
{
  public partial class UnitOfWork : IUnitOfWork
    {
        private ProjectContext _db = new ProjectContext();

        private IUserRepository UserRepository;
        private IRoleRepository RoleRepository;

        
        public IUserRepository Users => UserRepository ?? (UserRepository = new UserRepository(_db));

        public IRoleRepository Roles => RoleRepository ?? (RoleRepository = new RoleRepository(_db));

    }
}
