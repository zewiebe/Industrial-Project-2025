using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrial_Project_2025
{
    internal class Constants
    {
        public enum Commodity
        {
            Corn, //0
            Wheat,//1
            Soybean_Meal,//2
            Canola_Meal//3
        }

        public enum viewType
        {
            Price_View,
            Allocation_View
        }

        public const int numMonths = 12;
    }
}
