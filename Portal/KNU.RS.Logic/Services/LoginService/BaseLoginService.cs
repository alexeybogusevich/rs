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
        private readonly UserManager<User> userManager;

        public BaseLoginService(
            ApplicationContext context, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.context = context;
            this.userManager = userManager;
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

        public async Task ChangePasswordAsync(User user, string password)
        {
            if (await userManager.HasPasswordAsync(user))
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                await userManager.ResetPasswordAsync(user, token, password);
            }
            else
            {
                await userManager.AddPasswordAsync(user, password);
            }

            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
