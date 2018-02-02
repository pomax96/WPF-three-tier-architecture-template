using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WpfProjectTemplate.BLL.Interface.DAL;
using WpfProjectTemplate.DAL.EF;

namespace WpfProjectTemplate.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ProjectContext _context;
        DbSet<TEntity> _dbSet;

        public Repository(ProjectContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

    
        public async Task<TEntity> GetByIdAsync(int id)
        {
           return await _dbSet.FindAsync(id);
        }



        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task CreateAsync(TEntity item)
        {
                _dbSet.Add(item);
                await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity item)
        {
                _dbSet.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(TEntity item)
        {
                _dbSet.Attach(item);
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
        }
    }
}