using Industrial_Project_2025.wpfControls;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using static Industrial_Project_2025.Constants;

namespace Industrial_Project_2025
{
    public partial class PriceView : Form
    {
        //Joe added code for live chart
        private ElementHost elementHost; // Container for WPF chart
        private ChartControl wpfChart; // Instance of the WPF chart
        public PriceView(Home_Form home_Form)
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(Commodity));
            viewSelectBox.DataSource = Enum.GetValues(typeof(viewType));
            InitializeChart();
        }

        private void InitializeChart()
        {
            // Create ElementHost to embed WPF chart in WinForms
            elementHost = new ElementHost
            {
                Location = new System.Drawing.Point(200, 50), // Adjust position
                Size = new System.Drawing.Size(1200, 800) // Adjust size
            };

            // Create the WPF chart instance
            wpfChart = new ChartControl();
            elementHost.Child = wpfChart; // Attach the WPF control to ElementHost

            // Add ElementHost to form (but not affecting ComboBox)
            Controls.Add(elementHost);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Update the chart based on selected item
            UpdateChartData();
        }

        private void UpdateChartData()
        {
            if (wpfChart == null) return;

            if (comboBox1.SelectedItem == null || viewSelectBox.SelectedItem == null)
                return;

            Commodity selectedCommodity = (Commodity)comboBox1.SelectedItem; // Get selected item

            int year = (int)numericUpDown1.Value;

            if ((viewType)viewSelectBox.SelectedItem == viewType.Price_View)
            {
                ChartData data = PriceViewManager.getPriceData(selectedCommodity, year);
                wpfChart.UpdateChartData(data.Dates, data.ContractPrices, data.BenchmarkPrices);
                wpfChart.SetSeriesTitles("Contract Price", "Benchmark");
            }
            else if ((viewType)viewSelectBox.SelectedItem == viewType.Allocation_View)
            {
                DateTime[] monthPoints = new DateTime[]
                {
                    new DateTime(2024, 1, 1),
                    new DateTime(2024, 2, 1),
                    new DateTime(2024, 3, 1),
                    new DateTime(2024, 4, 1),
                    new DateTime(2024, 5, 1),
                    new DateTime(2024, 6, 1),
                    new DateTime(2024, 7, 1),
                    new DateTime(2024, 8, 1),
                    new DateTime(2024, 9, 1),
                    new DateTime(2024, 10, 1),
                    new DateTime(2024, 11, 1),
                    new DateTime(2024, 12, 1),
                };
                //pass in 12 data-points each will be marked as the first of the month 
                double[][] data = PriceViewManager.getAllocationData(selectedCommodity, year);
                wpfChart.UpdateChartData(monthPoints, data[0], data[1]);
                wpfChart.SetSeriesTitles("Selected Year", "Year Before");
            }

        }

        private void viewSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChartData();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateChartData();
        }
    }
}
