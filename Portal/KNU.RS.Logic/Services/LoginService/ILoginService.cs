using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Account;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.LoginService
{
    public interface ILoginService
    {
        Task<bool> CheckLoginAsync(LoginModel model);
        Task<bool> ChangePasswordAsync(User user, string password);
        Task LogoutAsync();
    }
}