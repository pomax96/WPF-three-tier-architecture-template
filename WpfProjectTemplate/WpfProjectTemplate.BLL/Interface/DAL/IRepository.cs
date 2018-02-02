using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfProjectTemplate.BLL.Interface.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task DeleteAsync(TEntity item);

    }
}