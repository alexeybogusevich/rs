using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.LoginService;
using KNU.RS.Logic.Services.UserService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class ChangePasswordBase : ComponentBase
    {
        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; }

        [Inject]
        protected ILoginService LoginService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IUserService UserService { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }


        protected User User { get; set; }

        protected ChangePasswordModel ChangePasswordModel { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            if (!Guid.TryParse(
                HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                out var userId))
            {
                NavigationManager.NavigateTo("/signin");
            }

            User = await UserService.GetAsync(userId);
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

            await LoginService.ChangePasswordAsync(User, ChangePasswordModel.NewPassword);
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "password_changed");
        }

        public async Task ClearErrorsAsync()
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ClearChangePasswordCurrentFailed);
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ClearChangePasswordConfirmFailed);
        }

        public async Task DoneAsync()
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "password_changed");
            NavigationManager.NavigateTo("/main");
        }
    }
}
