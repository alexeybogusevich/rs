using KNU.RS.Logic.Models.Recovery;
using KNU.RS.Logic.Services.RecoveryPlanService;
using KNU.RS.UI.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class RecoveryExercisesTableBase : ComponentBase
    {
        [Inject]
        protected IRecoveryPlanService RecoveryService { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Parameter]
        public Guid PatientId { get; set; }


        protected List<RecoveryDailyPlanInfo> Plans { get; set; } = new List<RecoveryDailyPlanInfo>();

        protected bool IsLoading { get; set; } = true;

        protected string PlanDescriptionToDosplay { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await GetPlansAsync();
        }

        protected async Task MarkAsCompletedAsync(Guid planId, int serialNumber)
        {
            await RecoveryService.MarkAsCompletedAsync(planId);
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ChangePlanToCompleted, serialNumber);
        }

        protected async Task DisplayNewPlanAsync()
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "new-plan-modal");
        }

        protected async Task DisplayDescriptionAsync(string description)
        {
            PlanDescriptionToDosplay = description;
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "plan-description-modal");
        }

        protected bool GetButtonDisabled(RecoveryDailyPlanInfo plan)
        {
            if (plan.Completed)
            {
                return true;
            }
            else if (!plan.Completed && plan.DateTime.Day > DateTime.Today.Day)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected string GetStatus(RecoveryDailyPlanInfo plan)
        {
            if (plan.Completed)
            {
                return Labels.Done;
            }
            else if (!plan.Completed && plan.DateTime.Day >= DateTime.Now.Day)
            {
                return Labels.Planned;
            }
            else
            {
                return Labels.Failed;
            }
        }

        protected string GetStatusClass(RecoveryDailyPlanInfo plan)
        {
            if (plan.Completed)
            {
                return "fa-check";
            }
            else if (!plan.Completed && plan.DateTime.Day >= DateTime.Now.Day)
            {
                return "fa-calendar";
            }
            else
            {
                return "fa-times";
            }
        }

        [JSInvokable(JSInvokableMethods.RefreshPlans)]
        protected async Task RefreshAsync()
        {
            await GetPlansAsync();
        }

        private async Task GetPlansAsync()
        {
            IsLoading = true;

            var plans = await RecoveryService.GetInfoAsync(PatientId);
            Plans = plans.ToList();

            IsLoading = false;
        }
    }
}
