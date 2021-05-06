﻿using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Services.PatientService;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class ViewPatientBase : PageBase
    {
        [Inject]
        protected IPatientService PatientService { get; set; }


        [Parameter]
        public Guid Id { get; set; }

        protected PatientInfo Patient { get; set; } = new PatientInfo();


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            Patient = await PatientService.GetInfoAsync(Id, cancellationTokenSource.Token);

            IsLoading = false;
        }
    }
}
