using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanctionExpense.Core.Models.Auth
{
    public class SanctionUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        /// <summary>
        /// Bu alan bu tabloda oluşmasın
        /// </summary>
        [NotMapped]
        public string Role { get; set; }


    }
}
