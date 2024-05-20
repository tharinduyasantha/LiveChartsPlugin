using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveChartsPlugin.Models
{
    public class ChartsViewModel
    {
        public ISeries[] Series { get; set; }
        public ISeries[] StackedSeries { get; set; }
        public ISeries[] HeatSeries { get; set; }
        public Axis[] HeatXAxes { get; set; }
        public Axis[] HeatYAxes { get; set; }
        public IEnumerable<ISeries> DonutSeries { get; set; }
        public Axis[] XAxes { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }
}
