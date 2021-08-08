using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

/// <summary>
/// Entry point for the Search namespace
/// </summary>
namespace GroupProjectCS3280.Search
{
    /// <summary>
    /// Entry point for the cls search logic class, where the logic is processed
    /// </summary>
    class clsSearchLogic
    {
        /// <summary>
        /// data access class runs database queries
        /// searchsql holds all the sql statements to be run
        /// </summary>
        clsDataAccess db = new clsDataAccess();
        clsSearchSQL SearchSQL = new clsSearchSQL();

        /// <summary>
        /// Runs queries and executes sql statements
        /// </summary>
        /// <param name="num"></param>
        /// <param name="date"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<clsInvoice> RunQuery(string num, string date, string total)
        {
            try
            {
                if (num == null && date == null && total == null)
                {
                    //run SelectAll

                    DataSet dsRows;
                    List<clsInvoice> lstInvoices = new List<clsInvoice>();

                    int iRet = 0;
                    dsRows = db.ExecuteSQLStatement(SearchSQL.SelectAll, ref iRet);

                    for (int i = 0; i < iRet; i++)
                    {
                        clsInvoice Invoice = new clsInvoice(dsRows.Tables[0].Rows[i][0].ToString(), dsRows.Tables[0].Rows[i][1].ToString(), dsRows.Tables[0].Rows[i][2].ToString());
                        lstInvoices.Add(Invoice);
                    }

                    return lstInvoices;
                }
                if (num != null && date == null && total == null)
                {
                    //run SelectInvoiceNum

                    DataSet dsRows;
                    List<clsInvoice> lstInvoices = new List<clsInvoice>();

                    int iRet = 0;
                    dsRows = db.ExecuteSQLStatement(SearchSQL.SelectInvoiceNum(num), ref iRet);

                    for (int i = 0; i < iRet; i++)
                    {
                        clsInvoice Invoice = new clsInvoice(dsRows.Tables[0].Rows[i][0].ToString(), dsRows.Tables[0].Rows[i][1].ToString(), dsRows.Tables[0].Rows[i][2].ToString());
                        lstInvoices.Add(Invoice);
                    }

                    return lstInvoices;
                }
                if (num != null && date != null && total == null)
                {
                    //run SelectInvoiceNumAndDate

                    DataSet dsRows;
                    List<clsInvoice> lstInvoices = new List<clsInvoice>();

                    int iRet = 0;
                    dsRows = db.ExecuteSQLStatement(SearchSQL.SelectInvoiceNumAndDate(num, date), ref iRet);

                    for (int i = 0; i < iRet; i++)
                    {
                        clsInvoice Invoice = new clsInvoice(dsRows.Tables[0].Rows[i][0].ToString(), dsRows.Tables[0].Rows[i][1].ToString(), dsRows.Tables[0].Rows[i][2].ToString());
                        lstInvoices.Add(Invoice);
                    }

                    return lstInvoices;
                }
                if (num != null && date != null && total != null)
                {
                    //run SelectInvoiceNumAndDateAndTotal

                    DataSet dsRows;
                    List<clsInvoice> lstInvoices = new List<clsInvoice>();

                    int iRet = 0;
                    dsRows = db.ExecuteSQLStatement(SearchSQL.SelectInvoiceNumAndDateAndTotal(num, date, total), ref iRet);

                    for (int i = 0; i < iRet; i++)
                    {
                        clsInvoice Invoice = new clsInvoice(dsRows.Tables[0].Rows[i][0].ToString(), dsRows.Tables[0].Rows[i][1].ToString(), dsRows.Tables[0].Rows[i][2].ToString());
                        lstInvoices.Add(Invoice);
                    }

                    return lstInvoices;
                }
                if (num == null && date == null && total != null)
                {
                    //run SelectTotal

                    DataSet dsRows;
                    List<clsInvoice> lstInvoices = new List<clsInvoice>();

                    int iRet = 0;
                    dsRows = db.ExecuteSQLStatement(SearchSQL.SelectTotal(total), ref iRet);

                    for (int i = 0; i < iRet; i++)
                    {
                        clsInvoice Invoice = new clsInvoice(dsRows.Tables[0].Rows[i][0].ToString(), dsRows.Tables[0].Rows[i][1].ToString(), dsRows.Tables[0].Rows[i][2].ToString());
                        lstInvoices.Add(Invoice);
                    }

                    return lstInvoices;
                }
                if (num == null && date != null && total != null)
                {
                    //run SelectTotalAndDate

                    DataSet dsRows;
                    List<clsInvoice> lstInvoices = new List<clsInvoice>();

                    int iRet = 0;
                    dsRows = db.ExecuteSQLStatement(SearchSQL.SelectTotalAndDate(total,date), ref iRet);

                    for (int i = 0; i < iRet; i++)
                    {
                        clsInvoice Invoice = new clsInvoice(dsRows.Tables[0].Rows[i][0].ToString(), dsRows.Tables[0].Rows[i][1].ToString(), dsRows.Tables[0].Rows[i][2].ToString());
                        lstInvoices.Add(Invoice);
                    }

                    return lstInvoices;
                }
                if (num == null && date != null && total == null)
                {
                    //run SelectDate

                    DataSet dsRows;
                    List<clsInvoice> lstInvoices = new List<clsInvoice>();

                    int iRet = 0;
                    dsRows = db.ExecuteSQLStatement(SearchSQL.SelectDate(date), ref iRet);

                    for (int i = 0; i < iRet; i++)
                    {
                        clsInvoice Invoice = new clsInvoice(dsRows.Tables[0].Rows[i][0].ToString(), dsRows.Tables[0].Rows[i][1].ToString(), dsRows.Tables[0].Rows[i][2].ToString());
                        lstInvoices.Add(Invoice);
                    }

                    return lstInvoices;
                }

                //default return value
                List<clsInvoice> defaultret = new List<clsInvoice>();
                return defaultret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// fills the invoice number box
        /// </summary>
        /// <returns></returns>
        public List<string> FillInvoiceNumBox()
        {
            try
            {
                DataSet dsRows;
                List<string> lstInvoiceNums = new List<string>();

                int iRet = 0;
                dsRows = db.ExecuteSQLStatement(SearchSQL.FillInvoiceBox, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    string InvoiceNum = dsRows.Tables[0].Rows[i][0].ToString();
                    lstInvoiceNums.Add(InvoiceNum);
                }

                return lstInvoiceNums;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Fills the invoice date box
        /// </summary>
        /// <returns></returns>
        public List<string> FillInvoiceDateBox()
        {
            try
            {
                DataSet dsRows;
                List<string> lstInvoiceDates = new List<string>();

                int iRet = 0;
                dsRows = db.ExecuteSQLStatement(SearchSQL.FillDateBox, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    string InvoiceDate = dsRows.Tables[0].Rows[i][0].ToString();
                    lstInvoiceDates.Add(InvoiceDate);
                }

                return lstInvoiceDates;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Fills the total charge data box
        /// </summary>
        /// <returns></returns>
        public List<string> FillTotalChargeBox()
        {
            try
            {
                DataSet dsRows;
                List<string> lstTotalCharges = new List<string>();

                int iRet = 0;
                dsRows = db.ExecuteSQLStatement(SearchSQL.FillTotalBox, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    string TotalCharge = dsRows.Tables[0].Rows[i][0].ToString();
                    lstTotalCharges.Add(TotalCharge);
                }

                return lstTotalCharges;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
