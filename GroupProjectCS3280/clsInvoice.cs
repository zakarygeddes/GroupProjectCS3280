using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Namespace of the project
/// </summary>
namespace GroupProjectCS3280
{
    /// <summary>
    /// Class that defines the invoice
    /// </summary>
    class clsInvoice
    {
        /// <summary>
        /// Sets what the variables are
        /// </summary>
        /// <param name="myNum"></param>
        /// <param name="myDate"></param>
        /// <param name="myCost"></param>
        public clsInvoice(string myNum, string myDate, string myCost)
        {
            try
            {
                num = myNum;
                date = myDate;
                cost = myCost;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Invoice variables
        /// </summary>
        public string num { set; get; }
        public string date { set; get; }
        public string cost { set; get; }
    }
}
