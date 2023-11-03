using SanctionExpense.Core.Models.ViewModel;


namespace SanctionExpense.Core.Services
{
    public interface IAuthService
    {
        Task<SignUpResponseModel> SignUp(SignUpViewModel model);
        Task<SignInResponseModel> SignIn(SignInViewModel model);
        void SignOut();
    }
}
