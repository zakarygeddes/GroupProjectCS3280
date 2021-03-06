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
        /// <summary>
        /// get all items from itemDesc
        /// </summary>
        /// <returns></returns>
        public string getAllItems()
        {
            try
            {
                return "SELECT * from ItemDesc";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// used for UPDATE statement to edit invoices based on passed in invoice num
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
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

        /// <summary>
        /// used with DELETE statement to delete a record, based on passed in invoice num
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
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

        /// <summary>
        /// used to delete a line item out of LineItems table, this I would normally handle with a trigger
        /// in the SQL side, but for simplicity when an Invoice is deleted, this statement would run as well
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
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

        /// <summary>
        /// delete a line item from a specific invoice
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="linenum"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public string deleteLineItemsFromInvoice(int invoiceNum, int linenum)
        {
            try
            {
                return "DELETE FROM ItemDesc WHERE InvoiceNum = " + invoiceNum + " AND LineItemNum =  " +linenum+ ";";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This is to add a new LineItem, when an Invoice is added, this will also run to update that table
        /// appropiately
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="lineItemNum"></param>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public string addNewLineItem(int invoiceNum, int lineItemNum, string itemCode)
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

        /// <summary>
        /// This is the INSERT statement method to put a brand new invoice in the system,
        /// again works with the add line item function
        /// </summary>
        /// <param name="date"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public string addNewInvoice(DateTime date, int cost)
        {
            try
            {
                return "INSERT INTO Invoices(InvoiceDate, TotalCost) Values(#" + date + "#, " + cost + ");";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Used once a new invoice is added, updates data grid with that invoice
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
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

        /// <summary>
        /// select a single lineitem from an invoice for manipulation
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
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

        /// <summary>
        /// get maxinvoice number
        /// </summary>
        /// <returns></returns>
        public string getMaxInvoiceNum()  
        {
            try
            {
                return "SELECT MAX(InvoiceNum) from Invoices"; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get specific line items from a invoice using a join
        /// </summary>
        /// <param name="invoicenum"></param>
        /// <returns></returns>
        public string getLineItemsFromInvoice(int invoicenum)
        {
            try
            {
                return "SELECT LineItems.InvoiceNum, ItemDesc.ItemDesc, ItemDesc.Cost FROM ItemDesc INNER JOIN LineItems ON ItemDesc.Itemcode = LineItems.ItemCode WHERE LineItems.InvoiceNum = " + invoicenum + ";";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}