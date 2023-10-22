using Microsoft.EntityFrameworkCore;
using SanctionExpense.Core.Repositories;
using SanctionExpense.Core.Services;
using SanctionExpense.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SanctionExpense.Service
{
    public class GenericService<T> : IService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _genericRepository;
        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<T> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task AddAsync(T entity)
        {
            await _genericRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _genericRepository.AddRange(entities);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _genericRepository.AnyAsync(expression);

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _genericRepository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _genericRepository.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IQueryable<T>> Where(Expression<Func<T, bool>> expression)
        {
            return await _genericRepository.Where(expression);
        }
    }
}
