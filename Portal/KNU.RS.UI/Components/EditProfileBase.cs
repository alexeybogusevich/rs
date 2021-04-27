using KNU.RS.Data.Enums;
using KNU.RS.Logic.Converters;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.AccountService;
using KNU.RS.Logic.Services.PhotoService;
using KNU.RS.Logic.Services.UserService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class EditProfileBase : ComponentBase
    {
        [Inject]
        protected IAccountService AccountService { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; }

        [Inject]
        protected IUserService UserService { get; set; }

        [Inject]
        protected IPhotoService PhotoService { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected bool IsLoading { get; set; } = true;


        protected RegistrationModel EditModel { get; set; } = new RegistrationModel();

        protected Guid Id { get; set; }

        protected bool IsMaleGender { get; set; } = true;

        protected async Task AssignPhotoAsync(InputFileChangeEventArgs e)
        {
            EditModel.Photo = await PhotoService.ValidateAndGetBytesAsync(e.File);
        }

        protected async Task SaveUserAsync()
        {
            IsLoading = true;
            await AccountService.EditAsync(EditModel);
            IsLoading = false;

            NavigationManager.NavigateTo("/main");
        }

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            if(!Guid.TryParse(
                HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), 
                out var userId))
            {
                NavigationManager.NavigateTo("/signin");
            }

            var user = await UserService.GetAsync(userId);
            EditModel = UserConverter.ConvertProfile(user);
            IsMaleGender = EditModel.Gender.Equals(Gender.Male);
            Id = userId;

            IsLoading = false;
        }
    }
}
