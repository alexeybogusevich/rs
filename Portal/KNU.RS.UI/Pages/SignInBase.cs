using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.LoginService;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace KNU.RS.UI.Pages
{
    public class SignInBase : ComponentBase
    {
        //[Inject]
        //protected ILoginService LoginService { get; set; }

        //[Inject]
        //protected NavigationManager NavigationManager { get; set; }

        //[Inject]
        //protected IJSRuntime JsRuntime { get; set; }

        //protected LoginModel LoginModel { get; set; } = new LoginModel();

        //private async Task LoginAsync()
        //{
        //    var loginResult = await LoginService.LoginAsync(LoginModel);

        //    if (!loginResult)
        //    {
        //        await JsRuntime.InvokeVoidAsync("setAuthNFailed");
        //        return;
        //    }

        //    NavigationManager.NavigateTo("/");
        //}

        //private async Task ClearErrorAsync()
        //{
        //    await JsRuntime.InvokeVoidAsync("clearAuthNFailed");
        //}
    }
}
