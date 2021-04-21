using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.LoginService;
using KNU.RS.UI.Constans;
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
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.DisableSignIn);

            var passwordCheckSucceeded = await LoginService.CheckLoginAsync(LoginModel);

            if (!passwordCheckSucceeded)
            {
                await JsRuntime.InvokeVoidAsync(JSExtensionMethods.SetAuthFailed);
                await JsRuntime.InvokeVoidAsync(JSExtensionMethods.EnableSignIn);
                return;
            }

            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.Login, LoginModel.Email, LoginModel.Password);
        }

        protected async Task ClearErrorsAsync()
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ClearAuthFailed);
        }
    }
}
