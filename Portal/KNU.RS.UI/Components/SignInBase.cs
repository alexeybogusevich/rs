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
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected ILoginService LoginService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected LoginModel LoginModel { get; set; } = new LoginModel();

        protected async Task LoginAsync()
        {
            var succeeded = await LoginService.CheckLoginAsync(LoginModel);

            if (!succeeded)
            {
                await JsRuntime.InvokeVoidAsync("blazorExtensions.SET_AUTHN_FAILED");
                return;
            }

            await JsRuntime.InvokeVoidAsync(
                "blazorExtensions.LOGIN", LoginModel.Email, LoginModel.Password);
        }

        protected async Task ClearErrorsAsync()
        {
            await JsRuntime.InvokeVoidAsync("blazorExtensions.CLEAR_AUTN_FAILED");
        }
    }
}
