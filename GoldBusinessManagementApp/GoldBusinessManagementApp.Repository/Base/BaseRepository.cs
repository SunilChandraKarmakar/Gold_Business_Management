using GoldBusinessManagementApp.Database.DBConfig;
using GoldBusinessManagementApp.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GoldBusinessManagementApp.Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly GoldBusinessManagementDbContext _context;

        public BaseRepository()
        {
            _context = new GoldBusinessManagementDbContext();
        }

        public virtual async Task<T> GetById(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<bool> Create(T entity)
        {
            _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
