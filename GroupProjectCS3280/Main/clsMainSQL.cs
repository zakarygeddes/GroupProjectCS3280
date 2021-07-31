using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Namespace for the Main class
/// </summary>
namespace GroupProjectCS3280.Main
{
    /// <summary>
    /// Main logic class to handle the backend business logic of the window
    /// </summary>
    class clsMainSQL
    {
        public string updateInvoices(int cost, int invoiceNum)
        {
            try
            {
                return "UPDATE Invoices SET TotalCost = " + cost + " WHERE InvoiceNum = " + invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string deleteInvoices(int invoiceNum)
        {
            try
            {
                return "DELETE From Invoices WHERE InvoiceNum = " + invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string deleteLineItems(int invoiceNum)
        {
            try
            {
                return "DELETE From LineItems WHERE InvoiceNum = " + invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string addNewLineItem(int invoiceNum, int lineItemNum, char itemCode)
        {
            try
            {
                return "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) Values(" + invoiceNum + ", " + lineItemNum + ", '" + itemCode + "')";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string addNewInvoice(DateTime date, int cost)
        {
            try
            {
                return "INSERT INTO Invoices(InvoiceDate, TotalCost) Values('#" + date + "#', " + cost + "')";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string selectInvoice(int invoiceNum)
        {
            try
            {
                return "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = " + invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string selectItem(int invoiceNum)
        {
            try
            {
                return "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = " + invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}