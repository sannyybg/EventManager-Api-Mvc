using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.DataEF.BaseRepository
{
    public interface IBaseRepository<T> where T : class
    {

        Task<List<T>> GetAllAsync();

        Task AddAsync(T val);

        Task<T> GetAsync(params object[] key);
        IQueryable<T> Table { get; }

        Task DeleteAsync(params object[] key);

        Task UpdateAsync(T val);


    }
}
