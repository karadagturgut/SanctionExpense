using SanctionExpense.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionExpense.Core.Models
{
    public class Expense : BaseModel
    {
        public string Description { get; set; }
        public byte IsApproved { get; set; }
    }
}
