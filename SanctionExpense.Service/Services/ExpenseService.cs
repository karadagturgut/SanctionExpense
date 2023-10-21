using SanctionExpense.Core.Models;
using SanctionExpense.Core.Repositories;
using SanctionExpense.Core.Services;
using SanctionExpense.Core.UnitOfWork;

namespace SanctionExpense.Service.Services
{
    public class ExpenseService : GenericService<Expense>, IExpenseService
    {
        public ExpenseService(IUnitOfWork unitOfWork, IGenericRepository<Expense> genericRepository) : base(unitOfWork, genericRepository)
        {
        }
    }
}
