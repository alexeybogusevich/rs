using KNU.RS.Logic.Models.Account;
using System;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.AccountService
{
    public interface IAccountService
    {
        Task RegisterAsync(PatientRegistrationModel model);
        Task RegisterAsync(DoctorRegistrationModel model);
        Task EditAsync(PatientRegistrationModel model);
        Task EditAsync(DoctorRegistrationModel model);
        Task EditAsync(RegistrationModel model);
        Task HandleForgotPasswordAsync(ForgotPasswordModel model);
        Task PromoteToAdminAsync(Guid id);
    }
}