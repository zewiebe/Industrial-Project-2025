using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrial_Project_2025
{
    //class used to pass data from Price view manager to ui
    public class ChartData
    {
        public DateTime[] Dates { get; set; }
        public double[] ContractPrices { get; set; }
        public double[] BenchmarkPrices { get; set; }

        public ChartData(DateTime[] dates, double[] contractPrices, double[] benchmarkPrices)
        {
            Dates = dates;
            ContractPrices = contractPrices;
            BenchmarkPrices = benchmarkPrices;
        }
    }
}
