using ChartJs.Blazor;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.LineChart;
using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Models.Patient;
using KNU.RS.Logic.Models.Study;
using KNU.RS.Logic.Services.PatientService;
using KNU.RS.Logic.Services.StudyService;
using KNU.RS.UI.Constants;
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

        protected Dictionary<StudyKey, StudyValue> Charts = new Dictionary<StudyKey, StudyValue>();


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            var studyDetails = await StudyService.GetDetailsInfoAsync(Patient.Id, cancellationTokenSource.Token);
            StudyDetails = studyDetails.OrderBy(s => s.DateTime).Take(15).ToList();

            var studies = await StudyService.GetInfoAsync(Patient.Id, cancellationTokenSource.Token);
            Studies = studies.OrderByDescending(s => s.DateTime).ToList();

            if (Studies.Count < 2)
            {
                return;
            }

            var groupedStudies = StudyDetails.GroupBy(s => new { s.SerialNumber, Name = s.StudySubtypeName });

            foreach (var studiesOfSubtype in groupedStudies)
            {
                var typeName = studiesOfSubtype.FirstOrDefault()?.StudyTypeName;
                var title = $"{typeName} : {studiesOfSubtype.Key.Name}";

                var clockwiseStudies = studiesOfSubtype.Select(s => decimal.ToDouble(s.AvgClockwiseDegrees));
                var counterClockwiseStudies = studiesOfSubtype.Select(s => decimal.ToDouble(s.AvgCounterClockwiseDegrees));

                var labels = studiesOfSubtype.Select(s => s.DateTime.GetValueOrDefault().ToString("dd.MM.yyyy")).ToList();

                var config = GetChartConfig(title);

                var datasetClockwise = GetChartDataset(
                    clockwiseStudies, Labels.ClockwiseDegreesTitle, 
                    ChartConstants.BackgroundClockwise, ChartConstants.BorderClockwise);

                var datasetCounterClockwise = GetChartDataset(
                    counterClockwiseStudies, Labels.CounterClockwiseTitle, 
                    ChartConstants.BackgroundCounterClockwise, ChartConstants.BorderCounterClockwise);

                config.Data.Datasets.Add(datasetClockwise);
                config.Data.Datasets.Add(datasetCounterClockwise);

                foreach (var label in labels)
                {
                    config.Data.Labels.Add(label);
                }

                var chart = new Chart();

                var key = new StudyKey
                {
                    SerialNumber = studiesOfSubtype.Key.SerialNumber,
                    TypeName = typeName,
                    SubtypeName = studiesOfSubtype.Key.Name
                };

                var value = new StudyValue
                {
                    Chart = chart,
                    Configuration = config
                };

                Charts.Add(key, value);
            }

            IsLoading = false;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            foreach (var chart in Charts)
            {
                chart.Value.Chart.Update();
            }

            base.OnAfterRender(firstRender);
        }

        protected LineConfig GetChartConfig(string title)
        {
            return new LineConfig
            {
                Options = new LineOptions
                {
                    Responsive = true,
                    Legend = new Legend
                    {
                        Display = false
                    },
                    Tooltips = new Tooltips
                    {
                        Mode = InteractionMode.Index,
                        Intersect = false
                    },
                    Scales = new Scales
                    {
                        YAxes = new List<CartesianAxis>
                        {
                            new LinearCartesianAxis
                            {
                                Ticks = new LinearCartesianTicks
                                {
                                    BeginAtZero = true,
                                    SuggestedMax = 90
                                }
                            }
                        }
                    },
                    MaintainAspectRatio = true
                }
            };
        }

        protected LineDataset<double> GetChartDataset(
            IEnumerable<double> data, string label, string backgroundColor, string borderColor)
        {
            return new LineDataset<double>(data)
            {
                Label = label,
                BorderWidth = 1,
                BackgroundColor = backgroundColor,
                BorderColor = borderColor
            };
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (Studies.Count < 2)
        //    {
        //        return;
        //    }

        //    var groupedStudies = StudyDetails.GroupBy(s => new { s.SerialNumber, Name = s.StudySubtypeName });

        //    foreach (var studiesOfSubtype in groupedStudies)
        //    {
        //        var typeName = studiesOfSubtype.FirstOrDefault()?.StudyTypeName;
        //        var title = $"{typeName} : {studiesOfSubtype.Key.Name}";

        //        var clockwiseStudies = studiesOfSubtype.Select(s => s.AvgClockwiseDegrees).ToList();
        //        var counterClockwiseStudies = studiesOfSubtype.Select(s => s.AvgCounterClockwiseDegrees).ToList();

        //        var labels = studiesOfSubtype.Select(s => s.DateTime.GetValueOrDefault().ToString("dd.MM.yyyy")).ToList();

        //        await JsRuntime.InvokeVoidAsync(JSExtensionMethods.InitializeCharts);

        //        await JsRuntime.InvokeVoidAsync(
        //            JSExtensionMethods.FillStudyLinechart,
        //            title, labels,
        //            Labels.ClockwiseDegreesTitle, Labels.CounterClockwiseDegreesTitle,
        //            clockwiseStudies, counterClockwiseStudies, studiesOfSubtype.Key.SerialNumber);
        //    }
        //}

        protected async Task LoadCategoryResultsAsync(int serialNumber, int category)
        {
            var groupedStudies = StudyDetails.GroupBy(s => new { s.SerialNumber, Name = s.StudySubtypeName });
            var studiesOfTypeNumber = groupedStudies.FirstOrDefault(s => s.Key.SerialNumber.Equals(serialNumber));

            Func<StudyDetailsInfo, decimal> filterClockwise;
            Func<StudyDetailsInfo, decimal> filterCounterClockwise;

            switch(category)
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

            var typeName = studiesOfTypeNumber.FirstOrDefault()?.StudyTypeName;
            var title = $"{typeName} : {studiesOfTypeNumber.Key.Name}";

            var clockwiseStudies = studiesOfTypeNumber.Select(filterClockwise).ToList();
            var counterClockwiseStudies = studiesOfTypeNumber.Select(filterCounterClockwise).ToList();

            var labels = studiesOfTypeNumber.Select(s => s.DateTime.GetValueOrDefault().ToString("dd.MM.yyyy")).ToList();

            await JsRuntime.InvokeVoidAsync(
                JSExtensionMethods.RefillStudyLinechart,
                clockwiseStudies, counterClockwiseStudies, studiesOfTypeNumber.Key.SerialNumber, category);
        }

        protected class StudyKey
        {
            public int SerialNumber { get; set; }
            public string TypeName { get; set; }
            public string SubtypeName { get; set; }
        }

        protected class StudyValue
        {
            public Chart Chart { get; set; }
            public LineConfig Configuration { get; set; }
        }
    }
}
