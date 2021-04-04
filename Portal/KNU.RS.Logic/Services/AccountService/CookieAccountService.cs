using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Account;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.AccountService
{
    public class CookieAccountService : IAccountService
    {
        private readonly SignInManager<User> signInManager;

        public CookieAccountService(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(LoginModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password.Trim(), true, true);
            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
