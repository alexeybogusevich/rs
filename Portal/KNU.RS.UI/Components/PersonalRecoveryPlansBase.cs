﻿using KNU.RS.Logic.Models.Recovery;
using KNU.RS.Logic.Services.RecoveryPlanService;
using KNU.RS.UI.Constants;
using KNU.RS.UI.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class PersonalRecoveryPlansBase : PageBase
    {
        [Inject]
        protected IRecoveryPlanService RecoveryService { get; set; }


        protected List<RecoveryDailyPlanInfo> Plans { get; set; } = new List<RecoveryDailyPlanInfo>();

        protected List<RecoveryDailyPlanInfo> DisplayedPlans { get; set; } = new List<RecoveryDailyPlanInfo>();

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

            var authenticationState = await AuthenticationStateTask!;

            if (!Guid.TryParse(
                authenticationState?.User?.FindFirstValue(ClaimTypes.NameIdentifier),
                out var userId))
            {
                NavigationManager.NavigateUnauthorized();
            }

            var plans = await RecoveryService.GetInfoByUserAsync(userId, cancellationTokenSource.Token);
            Plans = plans?.OrderByDescending(p => p.DateTime)?.ThenBy(p => p.Completed)?.ToList() ?? new();
            SetDisplayedPlans();

            IsLoading = false;
        }
    }
}
