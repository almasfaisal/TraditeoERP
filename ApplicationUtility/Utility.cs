using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUtility
{
    public static class Utility
    {
        private static string _dateFormat;
        public static string DateFormat
        {
            get { return Utility._dateFormat; }
            set { Utility._dateFormat = value; }
        }
    }
}
