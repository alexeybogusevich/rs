using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.User;
using KNU.RS.Logic.Services.UserService;
using KNU.RS.UI.Constants;
using KNU.RS.UI.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class HeaderBase : ComponentBase
    {
        [Inject]
        protected IServiceScopeFactory ServiceScopeFactory { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected UserManager<User> UserManager { get; set; }


        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }


        protected FooterInfo UserFooter { get; set; } = new FooterInfo();


        protected override async Task OnInitializedAsync()
        {
            if (!Guid.TryParse(
                HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                out var userId))
            {
                NavigationManager.NavigateUnauthorized();
            }

            using var scope = ServiceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            var userService = new BaseUserService(context, UserManager);
            UserFooter = await userService.GetFooterAsync(userId);
        }

        protected string GetPhotoURI()
        {
            if (UserFooter.HasPhoto)
            {
                return $"{StaticFileConstants.PhotosRequestPath}/{UserFooter.Id}.{Options.Value.Extension}";
            }

            return "img/user.jpg";
        }

        protected async Task LogoutAsync()
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.Logout);
        }
    }
}
