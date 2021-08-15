using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Entry point for the mainspace of Main
/// </summary>
namespace GroupProjectCS3280.Main
{
    /// <summary>
    /// Main logic class
    /// </summary>
    class clsMainLogic
    {
        /// <summary>
        /// pulls from db to create a list of class items to fill combox box
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        public List<clsItem> fillItemsBox(clsDataAccess db, string sSQL)
        {
            try
            {
                DataSet ds;
                List<clsItem> items = new List<clsItem>();

                int iRet = 0;
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    clsItem item = new clsItem(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString());
                    items.Add(item);
                }

                return items;
            }
             catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// adds an invoice to the database
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sSQL"></param>
        public void addInvoice(clsDataAccess db, string sSQL)
        {
            try
            {
                db.ExecuteNonQuery(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// deletes an invoice from the database
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sSQL"></param>
        public void deleteInvoice(clsDataAccess db, string sSQL)
        {
            try
            {
                db.ExecuteNonQuery(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// delete an item from the database
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sSQL"></param>
        public void deleteLineItems(clsDataAccess db, string sSQL)
        {
            try
            {       //get selected index from dbinvoice
                db.ExecuteNonQuery(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// adds a line item to the database
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sSQL"></param>
        public void addLineItem(clsDataAccess db, string sSQL)
        {
            try
            {
                db.ExecuteNonQuery(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// logic for grabbing max invoice number from database
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        public int maxInvoiceNum(clsDataAccess db, string sSQL)
        {
            try
            {
                DataSet ds;
                List<clsItem> items = new List<clsItem>();

                int iRet = 0;
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);
                return Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// logic for gettting line items from invoice
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        public List<clsItem> getLineItemsFromInvoice(clsDataAccess db, string sSQL)
        {
            try
            {
                DataSet ds;
                List<clsItem> items = new List<clsItem>();

                int iRet = 0;
                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    clsItem item = new clsItem(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString());
                    items.Add(item);
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

