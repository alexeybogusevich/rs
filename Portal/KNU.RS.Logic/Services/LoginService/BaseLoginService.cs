using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
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

        public async Task<bool> CheckLoginAsync(LoginModel model, CancellationToken cancellationToken = default)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email.Equals(model.Email), cancellationToken);
            if (user == null)
            {
                return false;
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            return result.Succeeded;
        }

        public async Task<bool> ChangePasswordAsync(User user, string password)
        {
            IdentityResult setPasswordResult;

            if (await userManager.HasPasswordAsync(user))
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                setPasswordResult = await userManager.ResetPasswordAsync(user, token, password);
            }
            else
            {
                setPasswordResult = await userManager.AddPasswordAsync(user, password);
            }

            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return setPasswordResult.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
