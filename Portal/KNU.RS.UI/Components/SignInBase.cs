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
            var passwordCheckSucceeded = await LoginService.CheckLoginAsync(LoginModel);

            if (!passwordCheckSucceeded)
            {
                await JsRuntime.InvokeVoidAsync(SignInJSMethods.SetAuthFailed);
                return;
            }

            await JsRuntime.InvokeVoidAsync(SignInJSMethods.Login, LoginModel.Email, LoginModel.Password);

            NavigationManager.NavigateTo("/main");
        }

        protected async Task ClearErrorsAsync()
        {
            await JsRuntime.InvokeVoidAsync(SignInJSMethods.ClearAuthFailed);
        }
    }
}
