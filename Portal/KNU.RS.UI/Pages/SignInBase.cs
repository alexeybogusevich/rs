using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.AccountService;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace KNU.RS.UI.Pages
{
    public class SignInBase : ComponentBase
    {
        [Inject]
        protected IAccountService AccountService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected LoginModel LoginModel { get; set; } = new LoginModel { Email = string.Empty, Password = string.Empty };

        protected async Task LoginAsync()
        {
            var loginResult = await AccountService.LoginAsync(LoginModel);

            if (loginResult)
            {
                NavigationManager.NavigateTo("/");
                return;
            }


        }
    }
}
