using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.LoginService
{
    public class BaseLoginService : ILoginService
    {
        private readonly ApplicationContext context;
        private readonly SignInManager<User> signInManager;

        public BaseLoginService(
            ApplicationContext context, SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
            this.context = context;
        }

        public async Task<bool> CheckLoginAsync(LoginModel model)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email.Equals(model.Email));
            if (user == null)
            {
                return false;
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
