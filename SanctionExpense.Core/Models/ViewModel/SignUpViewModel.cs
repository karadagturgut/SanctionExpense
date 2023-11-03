using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SanctionExpense.Core.Models.ViewModel
{

    public class SignUpViewModel
    {
        [Display(Name = "İsim")]
        [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
        public string Name { get; set; }
        [Display(Name = "Soy İsim")]
        [Required(ErrorMessage = "Soy isim alanı boş bırakılamaz.")]
        public string Surname { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı alanı boş bırakılamaz.")]
        public string UserName { get; set; }
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Mail alanı boş bırakılamaz.")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Girdiğiniz şifre aynı değildir.")]
        [Display(Name = "Şifre Tekrar")]
        [Required(ErrorMessage = "Şifre Tekrar alanı boş bırakılamaz.")]
        public string PasswordConfirm { get; set; }
        [Display(Name = "Şirket Id")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı rolünü seçiniz.")]
        public string Role { get; set; }
    }
    public class SignUpResponseModel
    {
        public List<string>? MessageList { get; set; }
    }
}
