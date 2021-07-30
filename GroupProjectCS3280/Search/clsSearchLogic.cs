using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GroupProjectCS3280.Search
{
    class clsSearchLogic
    {
        clsDataAccess db = new clsDataAccess();
        clsSearchSQL SearchSQL = new clsSearchSQL();
        public List<clsInvoice> RunQuery(string num, string date, string total)
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
                dsRows = db.ExecuteSQLStatement(SearchSQL.SelectInvoiceNumAndDate(num,date), ref iRet);

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
            }
            if (num == null && date != null && total == null)
            {
                //run SelectDate
            }

            //default return value
            List<clsInvoice> defaultret = new List<clsInvoice>();
            return defaultret;
        }

        public List<string> FillInvoiceNumBox()
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

        public List<string> FillInvoiceDateBox()
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

        public List<string> FillTotalChargeBox()
        {
            DataSet dsRows;
            List<string> lstTotalCharges = new List<string>();

            //Query to select Flights
            int iRet = 0;
            dsRows = db.ExecuteSQLStatement(SearchSQL.FillTotalBox, ref iRet);

            for (int i = 0; i < iRet; i++)
            {
                string TotalCharge = dsRows.Tables[0].Rows[i][0].ToString();
                lstTotalCharges.Add(TotalCharge);
            }

            return lstTotalCharges;
        }
    }
}
