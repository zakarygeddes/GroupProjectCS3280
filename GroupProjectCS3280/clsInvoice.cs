using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace GroupProjectCS3280
{
    /// <summary>
    /// 
    /// </summary>
    class clsInvoice
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="myNum"></param>
        /// <param name="myDate"></param>
        /// <param name="myCost"></param>
        public clsInvoice(string myNum, string myDate, string myCost)
        {
            num = myNum;
            date = myDate;
            cost = myCost;
        }

        /// <summary>
        /// 
        /// </summary>
        public string num { set; get; }
        public string date { set; get; }
        public string cost { set; get; }
    }
}
