using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.LoginService
{
    public class CookieLoginService : ILoginService
    {
        private readonly ApplicationContext context;
        private readonly SignInManager<User> signInManager;
        private readonly IHostEnvironmentAuthenticationStateProvider hostAuthentication;

        public CookieLoginService(
            ApplicationContext context, SignInManager<User> signInManager, 
            IHostEnvironmentAuthenticationStateProvider hostAuthentication)
        {
            this.signInManager = signInManager;
            this.context = context;
            this.hostAuthentication = hostAuthentication;
        }

        public async Task<bool> LoginAsync(LoginModel model)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email.Equals(model.Email));
            if (user == null)
            {
                return false;
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
            {
                return false;
            }

            var principal = await signInManager.CreateUserPrincipalAsync(user);
            signInManager.Context.User = principal;
            hostAuthentication.SetAuthenticationState(Task.FromResult(new AuthenticationState(principal)));

            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
