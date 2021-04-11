using KNU.RS.Logic.Constants;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.LoginService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
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

        [Inject]
        protected IOptionsMonitor<CookieAuthenticationOptions> CookieAuthNOptionsMonitor { get; set; }

        protected LoginModel LoginModel { get; set; } = new LoginModel();

        protected async Task LoginAsync()
        {
            var ticket = await LoginService.LoginAsync(LoginModel);

            if (ticket == null)
            {
                await JsRuntime.InvokeVoidAsync("blazorExtensions.SET_AUTHN_FAILED");
                return;
            }

            var cookieAuthNOptions = CookieAuthNOptionsMonitor.Get(ConfigurationConstants.CookieV2AuthenticationScheme);
            var value = cookieAuthNOptions.TicketDataFormat.Protect(ticket);
            await JsRuntime.InvokeVoidAsync(
                "blazorExtensions.WRITE_COOKIE", ConfigurationConstants.CookieTokenName, 
                value, cookieAuthNOptions.ExpireTimeSpan.TotalDays);

            NavigationManager.NavigateTo("/adminpanel");
        }

        protected async Task ClearErrorsAsync()
        {
            await JsRuntime.InvokeVoidAsync("blazorExtensions.CLEAR_AUTN_FAILED");
        }
    }
}
