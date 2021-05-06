using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.LoginService;
using KNU.RS.Logic.Services.UserService;
using KNU.RS.UI.Constants;
using KNU.RS.UI.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class ChangePasswordBase : PageBase
    {
        [Inject]
        protected ILoginService LoginService { get; set; }

        [Inject]
        protected IUserService UserService { get; set; }


        protected User User { get; set; }

        protected ChangePasswordModel ChangePasswordModel { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await AuthenticationStateTask!;

            if (!Guid.TryParse(
                authenticationState?.User?.FindFirstValue(ClaimTypes.NameIdentifier),
                out var userId))
            {
                NavigationManager.NavigateUnauthorized();
            }

            User = await UserService.GetAsync(userId, cancellationTokenSource.Token);
        }

        protected async Task ChangePasswordAsync()
        {
            var loginModel = new LoginModel { Email = User.Email, Password = ChangePasswordModel.CurrentPassword };
            if (!await LoginService.CheckLoginAsync(loginModel))
            {
                await JsRuntime.InvokeVoidAsync(JSExtensionMethods.SetChangePasswordCurrentFailed);
                return;
            }

            if (!ChangePasswordModel.NewPassword.Equals(ChangePasswordModel.NewPasswordConfirmed))
            {
                await JsRuntime.InvokeVoidAsync(JSExtensionMethods.SetChangePasswordConfirmFailed);
                return;
            }

            var completed = await LoginService.ChangePasswordAsync(User, ChangePasswordModel.NewPassword);
            if (completed)
            {
                await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "password_changed");
                return;
            }

            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "password_change_failed");
        }

        public async Task ClearErrorsAsync()
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ClearChangePasswordCurrentFailed);
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ClearChangePasswordConfirmFailed);
        }

        public async Task DoneAsync()
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.BackToPreviousPage);
        }
    }
}
