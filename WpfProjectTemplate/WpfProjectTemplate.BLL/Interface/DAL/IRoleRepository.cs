using System.Collections.Generic;
using System.Threading.Tasks;
using WpfProjectTemplate.BLL.PresentationModel;

namespace WpfProjectTemplate.BLL.Interface.DAL
{
    public interface IRoleRepository
    {
        Task<RolePM> GetByIdAsync(int id);
        Task<List<RolePM>> GetAllAsync();
        Task CreateAsync(RolePM item);
        Task UpdateAsync(RolePM item);
        Task DeleteAsync(RolePM item);

    }
}