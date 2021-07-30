using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectCS3280
{
    class clsInvoice
    {
        public clsInvoice(string myNum, string myDate, string myCost)
        {
            num = myNum;
            date = myDate;
            cost = myCost;
        }

        public string num { set; get; }
        public string date { set; get; }
        public string cost { set; get; }
    }
}
