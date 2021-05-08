using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.LineChart;
using System.Collections.Generic;

namespace KNU.RS.UI.Helpers
{
    public static class ChartHelper
    {
        public static LineConfig GetLineChartConfig()
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

        public static LineDataset<T> GetChartDataset<T>(
            IEnumerable<T> data, string label, string backgroundColor, string borderColor)
        {
            return new LineDataset<T>(data)
            {
                Label = label,
                BorderWidth = 1,
                BackgroundColor = backgroundColor,
                BorderColor = borderColor
            };
        }
    }
}
