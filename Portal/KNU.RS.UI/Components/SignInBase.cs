using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.LoginService;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class SignInBase : ComponentBase
    {
        [Inject]
        protected ILoginService LoginService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        protected LoginModel LoginModel { get; set; } = new LoginModel();

        protected async Task LoginAsync()
        {
            var loginResult = await LoginService.LoginAsync(LoginModel);

            if (!loginResult)
            {
                await JsRuntime.InvokeVoidAsync("setAuthNFailed");
                return;
            }

            NavigationManager.NavigateTo("/");
        }

        protected async Task ClearErrorsAsync()
        {
            await JsRuntime.InvokeVoidAsync("clearAuthNFailed");
        }
    }
}
