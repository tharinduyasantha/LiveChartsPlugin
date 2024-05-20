using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System.Collections.ObjectModel;
using LiveChartsPlugin.Models;

namespace LiveChartsPlugin.ChartServices
{
    public class ChartService
    {
        private static readonly int[] sourceArray = new[] { 2, 4, 1, 4, 3 };

        public void InitializeChartsViewModel(ChartsViewModel viewModel)
        {
            viewModel.Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Name = "Mary",
                    Values = new double[] { 2, 5, 4 }
                },
                new ColumnSeries<double>
                {
                    Name = "Ana",
                    Values = new double[] { 3, 1, 6 }
                }
            };

            viewModel.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = new string[] { "Category 1", "Category 2", "Category 3" },
                    LabelsRotation = 0,
                    SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
                    SeparatorsAtCenter = false,
                    TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
                    TicksAtCenter = true,
                    ForceStepToMin = true,
                    MinStep = 1
                }
            };

            viewModel.DonutSeries = sourceArray.AsPieSeries((value, series) =>
            {
                series.MaxRadialColumnWidth = 60;
            });

            viewModel.HeatSeries = new ISeries[]
            {
                new HeatSeries<WeightedPoint>
                {
                    HeatMap = new[]
                    {
                        new SKColor(255, 241, 118).AsLvcColor(),
                        SKColors.DarkSlateGray.AsLvcColor(),
                        SKColors.Blue.AsLvcColor()
                    },
                    Values = new ObservableCollection<WeightedPoint>
                    {
                        new(0, 0, 150), new(0, 1, 123), new(0, 2, 310), new(0, 3, 225), new(0, 4, 473), new(0, 5, 373),
                        new(1, 0, 432), new(1, 1, 312), new(1, 2, 135), new(1, 3, 78), new(1, 4, 124), new(1, 5, 423),
                        new(2, 0, 543), new(2, 1, 134), new(2, 2, 524), new(2, 3, 315), new(2, 4, 145), new(2, 5, 80),
                        new(3, 0, 90), new(3, 1, 123), new(3, 2, 70), new(3, 3, 123), new(3, 4, 432), new(3, 5, 142)
                    }
                }
            };

            viewModel.HeatXAxes = new Axis[]
            {
                new Axis
                {
                    Labels = new[] { "Charles", "Richard", "Ana", "Mari" }
                }
            };

            viewModel.HeatYAxes = new Axis[]
            {
                new Axis
                {
                    Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" }
                }
            };

            viewModel.StackedSeries = new ISeries[]
            {
                new StackedAreaSeries<int>
                {
                    Values = new[] { 4, 4, 7, 2, 8 },
                    Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 },
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null
                },
                new StackedAreaSeries<int>
                {
                    Values = new[] { 7, 5, 3, 2, 6 },
                    Stroke = new SolidColorPaint(SKColors.Red) { StrokeThickness = 8 },
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null
                },
                new StackedAreaSeries<int>
                {
                    Values = new[] { 4, 2, 5, 3, 9 },
                    Stroke = new SolidColorPaint(SKColors.Green) { StrokeThickness = 1 },
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null
                }
            };
        }
    }
}
