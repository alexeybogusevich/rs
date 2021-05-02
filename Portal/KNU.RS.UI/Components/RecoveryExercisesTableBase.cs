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

        protected List<RecoveryDailyPlanInfo> DisplayedPlans { get; set; } = new List<RecoveryDailyPlanInfo>();

        protected bool IsLoading { get; set; } = true;

        private int BatchSize { get; set; } = 10;

        private int Batches { get; set; } = 1;

        protected string PlanDescriptionToDisplay { get; set; }

        protected RecoveryDailyPlanInfo PlanToDelete { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await SetPlansAsync();
        }

        protected async Task MarkAsCompletedAsync(Guid planId, int serialNumber)
        {
            var completed = await RecoveryService.MarkAsCompletedAsync(planId);

            if (completed)
            {
                await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ChangePlanToCompleted, serialNumber);
            }
        }

        protected async Task DisplayNewPlanAsync()
        {
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "new-plan-modal");
        }

        protected async Task DisplayDescriptionAsync(string description)
        {
            PlanDescriptionToDisplay = description;
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "plan-description-modal");
        }

        protected bool GetButtonDisabled(RecoveryDailyPlanInfo plan)
        {
            return plan.Completed || (!plan.Completed && plan.DateTime >= DateTime.Today.AddDays(1));
        }

        protected string GetButtonDisplay(RecoveryDailyPlanInfo plan)
        {
            return plan.Completed || plan.DateTime < DateTime.Today ? "hide" : string.Empty;
        }

        protected string GetStatus(RecoveryDailyPlanInfo plan)
        {
            if (plan.Completed)
            {
                return Labels.Done;
            }

            return plan.DateTime >= DateTime.Today ? Labels.Planned : Labels.Failed;
        }

        protected string GetStatusClass(RecoveryDailyPlanInfo plan)
        {
            if (plan.Completed)
            {
                return "fa-check";
            }

            return plan.DateTime >= DateTime.Today ? "fa-calendar" : "fa-times";
        }

        protected async Task SetPlanToDeleteAsync(RecoveryDailyPlanInfo plan)
        {
            PlanToDelete = plan;
            await JsRuntime.InvokeVoidAsync(JSExtensionMethods.ToggleModal, "delete-plan");
        }

        protected void ClearPlanToDelete()
        {
            PlanToDelete = null;
        }

        protected async Task DeleteAsync()
        {
            if (PlanToDelete == null)
            {
                return;
            }

            await RecoveryService.DeleteAsync(PlanToDelete.Id);

            var deletedDoctor = Plans.FirstOrDefault(d => d.Id.Equals(PlanToDelete.Id));
            Plans.Remove(deletedDoctor);
            SetDisplayedPlans();

            PlanToDelete = null;
        }

        protected void LoadMore()
        {
            if (DisplayedPlans.Count == Plans.Count)
            {
                return;
            }

            Batches++;
            SetDisplayedPlans();
        }

        private void SetDisplayedPlans()
        {
            DisplayedPlans = Plans.Take(Batches * BatchSize).ToList();
        }

        protected async Task SetPlansAsync()
        {
            IsLoading = true;

            var plans = await RecoveryService.GetInfoByPatientAsync(PatientId);
            Plans = plans?.OrderByDescending(p => p.DateTime)?.ThenBy(p => p.Completed)?.ToList() ?? new();
            SetDisplayedPlans();

            IsLoading = false;
        }
    }
}
