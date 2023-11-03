using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SanctionExpense.Core.Models.Auth;
using SanctionExpense.Core.Models.Enum;
using SanctionExpense.Core.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionExpense.Service.Services
{
    public class AuthService
    {
        private readonly UserManager<SanctionUser> _userManager;
        private readonly SignInManager<SanctionUser> _signInManager;
        private readonly IMapper _mapper;


        public AuthService(UserManager<SanctionUser> userManager, SignInManager<SanctionUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

      
        public async Task<SignInResponseModel> SignIn(SignInViewModel model)
        {
            var returnObject = new SignInResponseModel();
            returnObject.MessageList = new();
            var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
            returnObject.Status = signInResult.Succeeded;

            #region Kullanıcı Adı ve Şifre kontrolü
            if (signInResult.Succeeded.Equals(false))
            {
                var hasUser = await _userManager.FindByNameAsync(model.UserName);
                if (hasUser == null)
                {
                    returnObject.MessageList?.Add("Kullanıcı bulunamadı");
                    return returnObject;
                }
                else
                {
                    var remainingLoginCount = await _userManager.GetAccessFailedCountAsync(hasUser);
                    remainingLoginCount = 3 - remainingLoginCount;
                    returnObject.MessageList?.Add($"Şifrenizi kontrol ediniz.(Kalan giriş hakkı sayısı: {remainingLoginCount})");
                    return returnObject;
                }
            }
            #endregion
            if (signInResult.IsLockedOut)
            {
                returnObject.MessageList = new();
                returnObject.MessageList?.Add("3 kez hatalı giriş yaptınız. Kullanıcınız 10 dakika boyunca geçici olarak kilitlenmiştir.");
            }

            return returnObject;
        }
        public async void SignOut()
        {

            await _signInManager.SignOutAsync();
        }
    }
}
