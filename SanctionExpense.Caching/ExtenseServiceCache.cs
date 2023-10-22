using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SanctionExpense.Core.Models;
using SanctionExpense.Core.Models.Enum;
using SanctionExpense.Core.Repositories;
using SanctionExpense.Core.Services;
using SanctionExpense.Core.UnitOfWork;

namespace SanctionExpense.Caching
{
    public class ExtenseServiceCache : IExpenseService
    {
        #region Key List
        private const string AllExpensesKey = "AllExpensesKey";
        #endregion

        #region ctor - initializing
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExtenseServiceCache(IUnitOfWork unitOfWork, IMemoryCache cache, IMapper mapper, IExpenseRepository expenseRepository)
        {
            _unitOfWork = unitOfWork;
            _expenseRepository = expenseRepository;
            _cache = cache;
            _mapper = mapper;

            if (!_cache.TryGetValue(AllExpensesKey, out _))
            {
                _cache.Set(AllExpensesKey, _expenseRepository.GetAllAsync().ToList());
            }
        }
        #endregion


        public async Task AddAsync(Expense entity)
        {
            await _expenseRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            await CachingAllKeysAsync();
             
        }

        public async Task AddRange(IEnumerable<Expense> entities)
        {
            await _expenseRepository.AddRange(entities);
            await _unitOfWork.SaveAsync();
            await CachingAllKeysAsync();
        }
        public Task<bool> AnyAsync(Expression<Func<Expense, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Expense>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Expense>> GetAwaitingRequest()
        {
            throw new NotImplementedException();

        }

        public Task<Expense> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Expense entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Expense>> Where(Expression<Func<Expense, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task CachingAllKeysAsync()
        {
            _cache.Set(AllExpensesKey, await _expenseRepository.GetAllAsync().ToListAsync());
        }

      
    }
}
