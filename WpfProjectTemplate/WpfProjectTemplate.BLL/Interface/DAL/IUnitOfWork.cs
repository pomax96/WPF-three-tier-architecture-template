using System;
using System.Threading.Tasks;
using WpfProjectTemplate.BLL.PresentationModel;

namespace WpfProjectTemplate.BLL.Interface.DAL
{
    public interface IUnitOfWork:IDisposable
    {
       IUserRepository Users { get; }
       IRoleRepository Roles { get; }
        

        void Save();
        Task SaveAsync();
        
        
        void Dispose(bool disposing);
        void Dispose();
    }
}