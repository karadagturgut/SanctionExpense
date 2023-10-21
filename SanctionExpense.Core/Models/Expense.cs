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
        /// <summary>
        /// Masraf sahibi kişi.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Harcama Tutarı
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Oluşturulan masraf formunun durumu. Üç değer alabilir: 
        /// 0- Red,
        /// 1- Onay,
        /// 2- Beklemede
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// Harcama nedeni.
        /// </summary>
        // 
        public string Description { get; set; }

        /// <summary>
        /// Talep olumsuz ise reddedilme nedeni.
        /// </summary>
        public string RejectReason { get; set; }



    }
}
