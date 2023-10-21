using AutoMapper;
using SanctionExpense.Core.Models;
using SanctionExpense.Core.Models.Enum;
using SanctionExpense.Core.Repositories;
using SanctionExpense.Core.Services;
using SanctionExpense.Core.UnitOfWork;

namespace SanctionExpense.Service.Services
{
    public class ExpenseService : GenericService<Expense>, IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        public ExpenseService(IUnitOfWork unitOfWork, IGenericRepository<Expense> genericRepository, IExpenseRepository expenseRepository, IMapper mapper) : base(unitOfWork, genericRepository)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<Expense>> GetAwaitingRequest()
        {
           return await _expenseRepository.Where(x => x.Status.Equals(ExpenseStatus.Awaiting));
        }
    }
}
