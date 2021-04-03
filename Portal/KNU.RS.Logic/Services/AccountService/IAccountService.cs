using KNU.RS.Logic.Models.Account;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.AccountService
{
    public interface IAccountService
    {
        Task<bool> LoginCookieAsync(LoginModel model);
        Task LogoutCookieAsync();
        Task<string> LoginJWTAsync(LoginModel model);
        Task RegisterAsync(PatientRegistrationModel model);
        Task RegisterAsync(DoctorRegistrationModel model);
    }
}