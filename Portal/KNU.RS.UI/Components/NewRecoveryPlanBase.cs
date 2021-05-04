using KNU.RS.Logic.Models.Recovery;
using KNU.RS.Logic.Services.RecoveryPlanService;
using KNU.RS.UI.Constants;
using KNU.RS.UI.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class NewRecoveryPlanBase : PageBase
    {
        [Inject]
        protected IRecoveryPlanService RecoveryService { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; }


        [Parameter]
        public Guid PatientId { get; set; }

        [Parameter]
        public EventCallback ParentCallback { get; set; }


        protected RecoveryDailyPlanModel RecoveryModel { get; set; } = new RecoveryDailyPlanModel();


        protected async Task CreateAsync()
        {
            if (!Guid.TryParse(
                HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                out var userId))
            {
                NavigationManager.NavigateUnauthorized();
            }

            await RecoveryService.CreateAsync(RecoveryModel, userId, PatientId);
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "new-plan-modal");
            await ParentCallback.InvokeAsync();
        }
    }
}
