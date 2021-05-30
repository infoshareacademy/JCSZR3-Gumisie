using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafik_Logic
{
    public class ShiftChecker
    {
        public static string CheckShift(string date)
        {
            return date == "1" ? "1" : "0"; 
        }
    }

}
