using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Industrial_Project_2025.Constants;

namespace Industrial_Project_2025
{
    //manager class for the price view 
    //doesnt have much use now but building for the future 
    internal abstract class PriceViewManager
    {
        //pass the price data from access to ui for display 
        internal static ChartData getPriceData(Constants.Commodity commodityId, int year)
        {
            ChartData test = DataAccess.GetPriceChartData(commodityId, year);
            return test;
        }

        //returns 24 datapoints, the first 12 are from the selected year months the last 12 are from the prevous year
        internal static double[][] getAllocationData(Constants.Commodity commodityId, int year)
        {
            double[][] dataPoints = new double[2][]; // last year and selected year
            dataPoints[0] = new double[Constants.numMonths];
            dataPoints[1] = new double[Constants.numMonths];

            for (int month = 0; month < 12; month++)
            {
                dataPoints[0][ month] = DataAccess.GetMonthlyContractQuantity(commodityId, year, month); //selected year
                dataPoints[1][ month] = DataAccess.GetMonthlyContractQuantity(commodityId, year-1, month); //year before
            }

            return dataPoints;
        }

        //test method that just gives test data
        internal static ChartData getPriceDataTest()
        {
            DateTime[] dates = new DateTime[]
            {
                    new DateTime(2024, 1, 1),
                    new DateTime(2024, 2, 1),
                    new DateTime(2024, 3, 1),
                    new DateTime(2024, 4, 1),
                    new DateTime(2024, 5, 1)
            };

            double[] contract = new double[] { 5.5, 5.8, 6.0, 6.1, 6.3 };
            double[] benchmark = new double[] { 5.3, 5.6, 5.9, 6.0, 6.2 };

            return new ChartData(dates, contract, benchmark);
        }

        //test method that just gives test data
        internal static double[][] getAllocationDataTest()
        {
            double[][] dataPoints = new double[2][];
            dataPoints[0] = new double[12]
            {
                600000, 570000, 450000, 480000, 430000, 390000,
                340000, 300000, 250000, 210000, 700000, 120000
            };

            dataPoints[1] = new double[12]
            {
                720000, 540000, 500000, 680000, 410000, 370000,
                320000, 280000, 230000, 190000, 140000, 320000
            };

            return dataPoints;
        }
    }
}
