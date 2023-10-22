using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SanctionExpense.Core.Services
{
    public interface IService<T> where T : class
    {
        /// <summary>
        /// Tüm verileri döner.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// Id parametresine göre veri döner.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Bir expression ifadesine göre veri döner.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
       Task <IQueryable<T>> Where(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Expression ifadesine göre veri kontrolü yapar.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Veri ekleme. 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity);

        Task AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Güncelleme.
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(T entity);
    }
}
