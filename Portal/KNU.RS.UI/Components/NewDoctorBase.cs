using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.AccountService;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class NewDoctorBase : ComponentBase
    {
        [Inject]
        protected IAccountService AccountService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected DoctorRegistrationModel RegistrationModel { get; set; } = new DoctorRegistrationModel();

        protected async Task SaveDoctorAsync()
        {
            await AccountService.RegisterAsync(RegistrationModel);
        }
    }
}
