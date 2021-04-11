using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Constants;
using KNU.RS.Logic.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System.Security.Claims;
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

        public async Task<AuthenticationTicket> LoginAsync(LoginModel model)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email.Equals(model.Email));
            if (user == null)
            {
                return null;
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
            {
                return null;
            }

            var principal = await signInManager.CreateUserPrincipalAsync(user);
            var identity = new ClaimsIdentity(
                principal.Claims,
                ConfigurationConstants.CookieV2AuthenticationScheme
            );

            principal = new ClaimsPrincipal(identity);
            signInManager.Context.User = principal;
            hostAuthentication.SetAuthenticationState(Task.FromResult(new AuthenticationState(principal)));

            var ticket = new AuthenticationTicket(principal, null, ConfigurationConstants.CookieV2AuthenticationScheme);
            return ticket;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
