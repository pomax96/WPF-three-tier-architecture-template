using System.Collections.Generic;
using System.Threading.Tasks;
using WpfProjectTemplate.BLL.PresentationModel;

namespace WpfProjectTemplate.BLL.Interface.DAL
{
    public interface IUserRepository
    {
        Task<UserPM> GetByIdAsync(int id);
        Task<List<UserPM>> GetAllAsync();
        Task CreateAsync(UserPM item);
        Task UpdateAsync(UserPM item);
        Task DeleteAsync(UserPM item);

    }
}