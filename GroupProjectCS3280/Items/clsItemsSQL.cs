using System;
using System.Data;

/// <summary>
/// Namespace for the class
/// </summary>
namespace GroupProjectCS3280.Items
{
    /// <summary>
    /// Describes the class for the Items window SQL
    /// </summary>
    class clsItemsSQL
    {
        /// <summary>
        /// creates a contact point between clsItemsSQL and clsDataAccess
        /// </summary>
        clsDataAccess cda = new clsDataAccess();
        /// <summary>
        /// this item is just for the fill box item in clsItemsLogic
        /// </summary>
        public string getAllSQLStatement = "SELECT * FROM ItemDesc";

        /// <summary>
        /// retrive all items from the ItemDesc table
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllItems()
        {
            try
            {
                string getItemsSQL = $"SELECT * FROM ItemDesc";
                int row = 0;
                DataSet getAll = new DataSet();
                getAll = cda.ExecuteSQLStatement(getItemsSQL, ref row);
                DataTable getItems = getAll.Tables[getItemsSQL];

                return getItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves one of each item code from ItemDesc
        /// </summary>
        /// <returns></returns>
        public DataTable GetItemCodes()
        {
            try
            {
                string getItemCodesSQL = $"SELECT DISTINCT(ItemCode) FROM ItemDesc";
                int row = 0;
                DataSet ds = new DataSet();
                ds = cda.ExecuteSQLStatement(getItemCodesSQL, ref row);

                DataTable dt = ds.Tables["Table"]; //converts a dataset to a table

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Inserts an item into the ItemDesc table using values passed in
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public string InsertItem(string code, string desc, int cost)
        {
            try
            {
                string insertSQL = $"INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost) VALUES ('{code}','{desc}',{cost})";
                //int row = 0;
                //DataSet query = new DataSet();
                //query = cda.ExecuteSQLStatement(insertSQL, ref row);
                //DataTable insertQuery = query.Tables[insertSQL];

                return insertSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// gets the invoice related to a particular item using the item code passed in
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetInvoiceNum(string code)
        {
            try
            {
                string getNumSQL = $"SELECT DISTINCT(InvoiceNum) FROM LineItems WHERE ItemCode = '{code}'";
                int row = 0;
                DataSet getQuery = new DataSet();
                getQuery = cda.ExecuteSQLStatement(getNumSQL, ref row);
                DataTable dt = getQuery.Tables[getNumSQL];

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates a table based on the itemcode sql
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public string UpdateAllItems(string code, string desc, int cost)
        {
            try
            {
                string updateSQL = $"UPDATE ItemDesc SET ItemDesc = '{desc}', Cost = {cost} WHERE ItemCode = '{code}'";
                //int row = 0;
                //DataSet update = new DataSet();
                //update = cda.ExecuteSQLStatement(updateSQL, ref row);
                //DataTable dt = update.Tables[updateSQL];

                return updateSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Returns update description sql
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public string UpdateDesc(string code, string desc)
        {
            try
            {
                string updateDescSQL = $"UPDATE ItemDesc SET ItemDesc = '{desc}' WHERE ItemCode = '{code}'";
                //int row = 0;
                //DataSet update = new DataSet();
                //update = cda.ExecuteSQLStatement(updateDescSQL, ref row); //error
                //DataTable dt = update.Tables[updateDescSQL];

                return updateDescSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Returns the update item cost string
        /// </summary>
        /// <param name="code"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public string UpdateCost(string code, int cost)
        {
            try
            {
                string updateCostSQL = $"UPDATE ItemDesc SET Cost = {cost} WHERE ItemCode = '{code}'";
                //int row = 0;
                //DataSet update = new DataSet();
                //update = cda.ExecuteSQLStatement(updateCostSQL, ref row);
                //DataTable dt = update.Tables[updateCostSQL];

                return updateCostSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Returns the 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string DeleteItem(string code)
        {
            try {
                string deleteItemSQL = $"DELETE FROM ItemDesc WHERE ItemCode = \u0022{code}\u0022";

                return deleteItemSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
