using SanctionExpense.Core.Models;
using SanctionExpense.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionExpense.Repository.Repositories
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
