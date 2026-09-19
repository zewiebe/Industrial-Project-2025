using LiveCharts.Defaults;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using LiveCharts.Wpf;
using System.Reflection.PortableExecutable;
using LiveCharts.Configurations;

namespace Industrial_Project_2025.wpfControls
{
    public partial class ChartControl : System.Windows.Controls.UserControl, INotifyPropertyChanged
    {
        public ChartValues<DateTimePoint> contractValues { get; set; }
        public ChartValues<DateTimePoint> benchmarkValues { get; set; }
        public Func<double, string> XFormatter { get; set; }
        
        public Func<double, string> YFormatter { get; set; }

        public ChartControl()
        {
            InitializeComponent();
            contractValues = new ChartValues<DateTimePoint>();
            benchmarkValues = new ChartValues<DateTimePoint>();
            YFormatter = value => value.ToString("N0"); // Removes percentage

            // XFormatter converts numbers back to readable dates
            XFormatter = value =>
            {
                try
                {
                    return DateTime.FromOADate(value).ToString("MMM dd");
                }
                catch
                {
                    return "[Invalid]";
                }
            };

            YFormatter = value => value.ToString("N2");

            DataContext = this; // Bind this control to itself
        }

        public void UpdateChartData(DateTime[] dates, double[] contractPrices, double[] benchmarkPrices)
        {
            // Defensive check
            if (dates.Length != contractPrices.Length || dates.Length != benchmarkPrices.Length)
                throw new ArgumentException("Date and price arrays must be the same length");

            // Wipe out any old data or ghost series
            Chart.Series.Clear();
            Chart.AxisX[0].LabelFormatter = XFormatter;
            Chart.AxisY[0].LabelFormatter = YFormatter;

            int strokeSize = 3;
            int pointSize = 10;

            // Create new series with fresh ChartValues
            var contractSeries = new LineSeries
            {
                Title = "Contract Price",
                StrokeThickness = strokeSize,
                PointGeometrySize = pointSize,
                Fill = System.Windows.Media.Brushes.Transparent,
                Configuration = Mappers.Xy<DateTimePoint>()
                    .X(point => point.DateTime.ToOADate())
                    .Y(point => point.Value),
                Values = new ChartValues<DateTimePoint>()
            };

            contractSeries.LabelPoint = point =>
                $"Date: {DateTime.FromOADate(point.X):yyyy-MM-dd}, Price: {point.Y:N2}";

            var benchmarkSeries = new LineSeries
            {
                Title = "Benchmark",
                StrokeThickness = strokeSize,
                PointGeometrySize = pointSize,
                Fill = System.Windows.Media.Brushes.Transparent,
                Configuration = Mappers.Xy<DateTimePoint>()
                    .X(point => point.DateTime.ToOADate())
                    .Y(point => point.Value),
                Values = new ChartValues<DateTimePoint>()
            };

            benchmarkSeries.LabelPoint = point =>
                $"Date: {DateTime.FromOADate(point.X):yyyy-MM-dd}, Benchmark: {point.Y:N2}";

            for (int i = 0; i < dates.Length; i++)
            {
                contractSeries.Values.Add(new DateTimePoint(dates[i], contractPrices[i]));
                benchmarkSeries.Values.Add(new DateTimePoint(dates[i], benchmarkPrices[i]));
                Console.WriteLine($"Date: {dates[i]:yyyy-MM-dd} -> OADate: {dates[i].ToOADate()}");
            }

            Chart.Series.Add(contractSeries);
            Chart.Series.Add(benchmarkSeries);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetSeriesTitles(string title1, string title2)
        {
            if (Chart.Series.Count >= 2)
            {
                var series1 = Chart.Series[0] as LineSeries;
                var series2 = Chart.Series[1] as LineSeries;

                if (series1 != null) series1.Title = title1;
                if (series2 != null) series2.Title = title2;
            }
        }
    }
}
