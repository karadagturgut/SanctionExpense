using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionExpense.Core.Models.DTO
{
    public class ExpenseDTO:BaseDTO
    {
        public string Description { get; set; }
        public string Owner { get; set; }
        public decimal Amount { get; set; }
        public byte IsApproved { get; set; }
    }
}
