using ChartJs.Blazor;
using ChartJs.Blazor.LineChart;
using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Models.Study;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.Logic.Services.StudyService;
using KNU.RS.UI.Constants;
using KNU.RS.UI.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.UI.Components
{
    public class PatientProfileBase : PageBase
    {
        [Inject]
        protected IOptions<PhotoConfiguration> Options { get; set; }

        [Inject]
        protected IPatientService PatientService { get; set; }

        [Inject]
        protected IStudyService StudyService { get; set; }


        [Parameter]
        public PatientInfo Patient { get; set; }

        protected List<StudyInfo> Studies { get; set; } = new List<StudyInfo>();

        protected List<StudyDetailsInfo> StudyDetails { get; set; } = new List<StudyDetailsInfo>();

        protected Dictionary<int, StudyValue> Containers = new Dictionary<int, StudyValue>();


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            var studyDetails = await StudyService.GetDetailsInfoAsync(Patient.Id, cancellationTokenSource.Token);
            StudyDetails = studyDetails.OrderBy(s => s.DateTime).Take(15).ToList();

            var studies = await StudyService.GetInfoAsync(Patient.Id, cancellationTokenSource.Token);
            Studies = studies.OrderByDescending(s => s.DateTime).ToList();

            if (Studies.Count < 2)
            {
                IsLoading = false;
                return;
            }

            var groupedStudies = StudyDetails.GroupBy(s => new { s.SerialNumber, Name = s.StudySubtypeName });

            foreach (var studiesOfSubtype in groupedStudies)
            {
                var typeName = studiesOfSubtype.FirstOrDefault()?.StudyTypeName;
                var title = $"{typeName} : {studiesOfSubtype.Key.Name}";

                var clockwiseStudies = studiesOfSubtype.Select(s => s.AvgClockwiseDegrees);
                var counterClockwiseStudies = studiesOfSubtype.Select(s => s.AvgCounterClockwiseDegrees);

                var labels = studiesOfSubtype.Select(s => s.DateTime.GetValueOrDefault().ToString("dd.MM.yyyy")).ToList();

                var config = ChartHelper.GetLineChartConfig();

                var datasetClockwise = ChartHelper.GetChartDataset(
                    clockwiseStudies, Labels.ClockwiseDegreesTitle,
                    ChartConstants.BackgroundClockwise, ChartConstants.BorderClockwise);

                var datasetCounterClockwise = ChartHelper.GetChartDataset(
                    counterClockwiseStudies, Labels.CounterClockwiseTitle,
                    ChartConstants.BackgroundCounterClockwise, ChartConstants.BorderCounterClockwise);

                config.Data.Datasets.Add(datasetClockwise);
                config.Data.Datasets.Add(datasetCounterClockwise);

                foreach (var label in labels)
                {
                    config.Data.Labels.Add(label);
                }

                var value = new StudyValue
                {
                    Chart = new Chart(),
                    Configuration = config,
                    TypeName = typeName,
                    SubtypeName = studiesOfSubtype.Key.Name
                };

                Containers.Add(studiesOfSubtype.Key.SerialNumber, value);
            }

            IsLoading = false;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            foreach (var container in Containers)
            {
                container.Value.Chart.Update();
            }

            base.OnAfterRender(firstRender);
        }

        protected async Task LoadCategoryResultsAsync(int serialNumber, int category)
        {
            var groupedStudies = StudyDetails.GroupBy(s => new { s.SerialNumber, Name = s.StudySubtypeName });
            var studiesOfTypeNumber = groupedStudies.FirstOrDefault(s => s.Key.SerialNumber.Equals(serialNumber));

            Func<StudyDetailsInfo, decimal> filterClockwise;
            Func<StudyDetailsInfo, decimal> filterCounterClockwise;

            switch (category)
            {
                case (1):
                    filterClockwise = s => s.MinClockwiseDegrees;
                    filterCounterClockwise = s => s.MinCounterClockwiseDegrees;
                    break;
                case (2):
                    filterClockwise = s => s.AvgClockwiseDegrees;
                    filterCounterClockwise = s => s.AvgCounterClockwiseDegrees;
                    break;
                case (3):
                    filterClockwise = s => s.MaxClockwiseDegrees;
                    filterCounterClockwise = s => s.MaxCounterClockwiseDegrees;
                    break;
                default:
                    throw new ArgumentException();
            }

            var clockwiseStudies = studiesOfTypeNumber.Select(filterClockwise).ToList();
            var counterClockwiseStudies = studiesOfTypeNumber.Select(filterCounterClockwise).ToList();

            var container = Containers[serialNumber];
            container.Configuration.Data.Datasets.Clear();

            var datasetClockwise = ChartHelper.GetChartDataset(
                clockwiseStudies, Labels.ClockwiseDegreesTitle,
                ChartConstants.BackgroundClockwise, ChartConstants.BorderClockwise);

            var datasetCounterClockwise = ChartHelper.GetChartDataset(
                counterClockwiseStudies, Labels.CounterClockwiseTitle,
                ChartConstants.BackgroundCounterClockwise, ChartConstants.BorderCounterClockwise);

            container.Configuration.Data.Datasets.Add(datasetClockwise);
            container.Configuration.Data.Datasets.Add(datasetCounterClockwise);
            await container.Chart.Update();

            await JsRuntime.InvokeVoidAsync(
                JSExtensionMethods.SetStudyChartButtons, studiesOfTypeNumber.Key.SerialNumber, category);
        }

        protected class StudyValue
        {
            public Chart Chart { get; set; }
            public LineConfig Configuration { get; set; }
            public string TypeName { get; set; }
            public string SubtypeName { get; set; }
        }
    }
}
