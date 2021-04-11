using KNU.RS.Logic.Models.Account;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.LoginService
{
    public interface ILoginService
    {
        Task<AuthenticationTicket> LoginAsync(LoginModel model);
        Task LogoutAsync();
    }
}