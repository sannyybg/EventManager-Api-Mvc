using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.DataEF.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {



        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;



        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }



        public IQueryable<T> Table
        {
            get { return _dbSet; }
        }

        public async Task AddAsync(T val)
        {
            await _dbSet.AddAsync(val);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(params object[] key)
        {
            var entity = await GetAsync(key);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {

            var result = await _dbSet.ToListAsync();
            return result;

        }

        public async Task<T> GetAsync(params object[] key)
        {
            return await _dbSet.FindAsync(key);
        }

        public async Task UpdateAsync(T updated)
        {
            if (updated == null)
                return;

            _context.Entry(updated).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
