﻿using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

namespace LiveChartsPlugin.ChartsConfigs
{
    public partial class ChartViewModel
    {
        public ISeries[] Series { get; set; }
        public ISeries[] StackedSeries { get; set; }
        public ISeries[] HeatSeries { get; set; }

        public Axis[] HeatXAxes { get; set; }
        public Axis[] HeatYAxes { get; set; }
        public IEnumerable<ISeries> DonutSeries { get; set; }
        public Axis[] XAxes { get; set; }
        //public string[] Labels { get; set; }
        //public Func<double, string> YFormatter { get; set; }

        private bool _isInitialized = false;
        private static readonly int[] sourceArray = new[] { 2, 4, 1, 4, 3 };

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom() { }

        private void InitializeViewModel()
        {
            Series =
            [
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
            ];

            XAxes = [
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
                ];

            DonutSeries = sourceArray.AsPieSeries((value, series) =>
            {
                series.MaxRadialColumnWidth = 60;
            });

            HeatSeries = [
                new HeatSeries<WeightedPoint>
                {
                    HeatMap =
            [
                new SKColor(255, 241, 118).AsLvcColor(), // the first element is the "coldest"
                SKColors.DarkSlateGray.AsLvcColor(),
                SKColors.Blue.AsLvcColor() // the last element is the "hottest"
            ],
                    Values = new ObservableCollection<WeightedPoint>
            {
                // Charles
                new(0, 0, 150), // Jan
                new(0, 1, 123), // Feb
                new(0, 2, 310), // Mar
                new(0, 3, 225), // Apr
                new(0, 4, 473), // May
                new(0, 5, 373), // Jun

                // Richard
                new(1, 0, 432), // Jan
                new(1, 1, 312), // Feb
                new(1, 2, 135), // Mar
                new(1, 3, 78), // Apr
                new(1, 4, 124), // May
                new(1, 5, 423), // Jun

                // Ana
                new(2, 0, 543), // Jan
                new(2, 1, 134), // Feb
                new(2, 2, 524), // Mar
                new(2, 3, 315), // Apr
                new(2, 4, 145), // May
                new(2, 5, 80), // Jun

                // Mari
                new(3, 0, 90), // Jan
                new(3, 1, 123), // Feb
                new(3, 2, 70), // Mar
                new(3, 3, 123), // Apr
                new(3, 4, 432), // May
                new(3, 5, 142), // Jun
            },
                }
                ];

            HeatXAxes = [
                 new Axis
                 {
                     Labels = new[] { "Charles", "Richard", "Ana", "Mari" }
                 }
                ];

            HeatYAxes = [
                new Axis
                {
                    Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" }
                }
                ];

            StackedSeries = [
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
            ];


            _isInitialized = true;
        }
    }
}