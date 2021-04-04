using KNU.RS.Logic.Models.Account;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.RegistrationService
{
    public interface IRegistrationService
    {
        Task RegisterAsync(PatientRegistrationModel model);
        Task RegisterAsync(DoctorRegistrationModel model);
    }
}