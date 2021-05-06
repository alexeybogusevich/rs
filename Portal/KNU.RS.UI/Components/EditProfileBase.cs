using KNU.RS.Data.Enums;
using KNU.RS.Logic.Converters;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.AccountService;
using KNU.RS.Logic.Services.PhotoService;
using KNU.RS.Logic.Services.UserService;
using KNU.RS.UI.Constants;
using KNU.RS.UI.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class EditProfileBase : PageBase
    {
        [Inject]
        protected IAccountService AccountService { get; set; }

        [Inject]
        protected IUserService UserService { get; set; }

        [Inject]
        protected IPhotoService PhotoService { get; set; }

        protected Guid Id { get; set; }

        protected RegistrationModel EditModel { get; set; } = new RegistrationModel();

        protected bool IsMaleGender { get; set; } = true;


        protected async Task AssignPhotoAsync(InputFileChangeEventArgs e)
        {
            EditModel.Photo = await PhotoService.ValidateAndGetBytesAsync(e.File, cancellationTokenSource.Token);
        }

        protected async Task SaveUserAsync()
        {
            IsLoading = true;

            await AccountService.EditAsync(EditModel);

            IsLoading = false;

            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.BackToPreviousPage);
        }

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            var authenticationState = await AuthenticationStateTask!;

            if (!Guid.TryParse(
                authenticationState?.User?.FindFirstValue(ClaimTypes.NameIdentifier),
                out var userId))
            {
                NavigationManager.NavigateUnauthorized();
            }

            var user = await UserService.GetAsync(userId, cancellationTokenSource.Token);
            EditModel = UserConverter.ConvertProfile(user);
            IsMaleGender = EditModel.Gender.Equals(Gender.Male);
            Id = userId;

            IsLoading = false;
        }
    }
}
