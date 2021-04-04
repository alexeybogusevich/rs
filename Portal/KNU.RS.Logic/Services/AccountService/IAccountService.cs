using KNU.RS.Logic.Models.Account;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.AccountService
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(LoginModel model);
        Task LogoutAsync();
    }
}