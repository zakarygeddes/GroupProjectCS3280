using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Entry point for the Search namespace
/// </summary>
namespace GroupProjectCS3280.Search
{
    /// <summary>
    /// class for SearchSQL logic
    /// </summary>
    class clsSearchSQL
    {
        /// <summary>
        /// generic select all statement
        /// </summary>
        public string SelectAll = "SELECT * FROM Invoices";

        /// <summary>
        /// selects invoice number depending on id
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string SelectInvoiceNum(string num)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + num;
        }

        /// <summary>
        /// selects all from invoices depending on id and date
        /// </summary>
        /// <param name="num"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string SelectInvoiceNumAndDate(string num, string date)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + num + " AND InvoiceDate = #" + date + "#";
        }

        /// <summary>
        /// selects all from invoices depending on the id, date, and total passed in
        /// </summary>
        /// <param name="num"></param>
        /// <param name="date"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public string SelectInvoiceNumAndDateAndTotal(string num, string date, string total)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + num + " AND InvoiceDate = #" + date + "# AND TotalCost = " + total;
        }

        /// <summary>
        /// selects the total invoice where the total is equal to passed in total
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        public string SelectTotal(string total)
        {
            return "SELECT * FROM Invoices WHERE TotalCost = " + total;
        }

        /// <summary>
        /// Below is a collection of sql select statements
        /// </summary>
        //Below code is not finished

        public string SelectTotalAndDate = "SELECT * FROM Invoices WHERE TotalCost = $ AND InvoiceDate = #$#";

        public string SelectDate = "SELECT * FROM Invoices WHERE InvoiceDate = #$#";

        public string FillInvoiceBox = "SELECT DISTINCT InvoiceNum FROM Invoices";

        public string FillDateBox = "SELECT DISTINCT InvoiceDate FROM Invoices";

        public string FillTotalBox = "SELECT DISTINCT TotalCost FROM Invoices";
    }
}
