using KNU.RS.Logic.Models.Account;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateAsync(LoginModel model);
    }
}