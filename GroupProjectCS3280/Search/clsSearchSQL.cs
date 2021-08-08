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
            try
            {
                return "SELECT * FROM Invoices WHERE InvoiceNum = " + num;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// selects all from invoices depending on id and date
        /// </summary>
        /// <param name="num"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string SelectInvoiceNumAndDate(string num, string date)
        {
            try
            {
                return "SELECT * FROM Invoices WHERE InvoiceNum = " + num + " AND InvoiceDate = #" + date + "#";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            try
            {
                return "SELECT * FROM Invoices WHERE InvoiceNum = " + num + " AND InvoiceDate = #" + date + "# AND TotalCost = " + total;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// selects the total invoice where the total is equal to passed in total
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        public string SelectTotal(string total)
        {
            try
            {
                return "SELECT * FROM Invoices WHERE TotalCost = " + total;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Selects invoices based on selected total and date
        /// </summary>
        /// <param name="total"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string SelectTotalAndDate(string total, string date)
        {
            try
            {
                return "SELECT * FROM Invoices WHERE TotalCost = " + total + " AND InvoiceDate = #" + date + "#";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Selects invoices based on date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string SelectDate(string date)
        {
            try
            {
                return "SELECT * FROM Invoices WHERE InvoiceDate = #" + date + "#";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Fills the invoice combo box
        /// </summary>
        public string FillInvoiceBox = "SELECT DISTINCT InvoiceNum FROM Invoices";

        /// <summary>
        /// Fills the date combo box
        /// </summary>
        public string FillDateBox = "SELECT DISTINCT InvoiceDate FROM Invoices";

        /// <summary>
        /// Fills the date combo box
        /// </summary>
        public string FillTotalBox = "SELECT DISTINCT TotalCost FROM Invoices";
    }
}
