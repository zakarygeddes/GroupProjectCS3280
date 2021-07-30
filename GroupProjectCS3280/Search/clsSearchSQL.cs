using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectCS3280.Search
{
    class clsSearchSQL
    {
        public string SelectAll = "SELECT * FROM Invoices";

        public string SelectInvoiceNum(string num)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + num;
        }

        public string SelectInvoiceNumAndDate(string num, string date)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + num + " AND InvoiceDate = #" + date + "#";
        }

        public string SelectInvoiceNumAndDateAndTotal(string num, string date, string total)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + num + " AND InvoiceDate = #" + date + "# AND TotalCost = " + total;
        }

        public string SelectTotal(string total)
        {
            return "SELECT * FROM Invoices WHERE TotalCost = " + total;
        }

        //Below code is not finished

        public string SelectTotalAndDate = "SELECT * FROM Invoices WHERE TotalCost = $ AND InvoiceDate = #$#";

        public string SelectDate = "SELECT * FROM Invoices WHERE InvoiceDate = #$#";

        public string FillInvoiceBox = "SELECT DISTINCT InvoiceNum FROM Invoices";

        public string FillDateBox = "SELECT DISTINCT InvoiceDate FROM Invoices";

        public string FillTotalBox = "SELECT DISTINCT TotalCost FROM Invoices";
    }
}
