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
        clsDataAccess cda;
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
            string getItemsSQL = $"SELECT * FROM ItemDesc";
            int row = 0;
            DataSet getAll = new DataSet();
            getAll = cda.ExecuteSQLStatement(getItemsSQL, ref row);
            DataTable getItems = getAll.Tables[getItemsSQL];

            return getItems;
        }

        /// <summary>
        /// Retrieves one of each item code from ItemDesc
        /// </summary>
        /// <returns></returns>
        public DataTable GetItemCodes()
        {
            string getItemCodesSQL = $"SELECT DISTINCT(ItemCode) FROM ItemDesc";
            int row = 0;
            DataSet ds = new DataSet();
            ds = cda.ExecuteSQLStatement(getItemCodesSQL, ref row);

            DataTable dt = ds.Tables["Table"]; //converts a dataset to a table

            return dt;
        }

        /// <summary>
        /// Inserts an item into the ItemDesc table using values passed in
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public DataTable InsertItem(string code, string desc, int cost)
        {
            string insertSQL = $"INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost) VALUES (`{code}`, `{desc}`, `{cost}`)";
            int row = 0;
            DataSet query = new DataSet();
            query = cda.ExecuteSQLStatement(insertSQL, ref row);
            DataTable insertQuery = query.Tables[insertSQL];

            return insertQuery;
        }

        /// <summary>
        /// gets the invoice related to a particular item using the item code passed in
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetInvoiceNum(string code)
        {
            string getNumSQL = $"SELECT DISTINCT(InvoiceNum) FROM LineItems WHERE ItemCode = `{code}`";
            int row = 0;
            DataSet getQuery = new DataSet();
            getQuery = cda.ExecuteSQLStatement(getNumSQL, ref row);
            DataTable dt = getQuery.Tables[getNumSQL];

            return dt;
        }

        /// <summary>
        /// Updates a table based on the itemcode
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public DataTable UpdateAllItems(string code, string desc, int cost)
        {
            string updateSQL = $"UPDATE ItemDesc SET ItemCode = `{code}`, ItemDesc = `{desc}`, Cost = {cost} WHERE ItemCode = `{code}`";
            int row = 0;
            DataSet update = new DataSet();
            update = cda.ExecuteSQLStatement(updateSQL, ref row);
            DataTable dt = update.Tables[updateSQL];

            return dt;
        }

        /// <summary>
        /// Updates item description using the item code as a unique identifier
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public DataTable UpdateDesc(string code, string desc)
        {
            string updateDescSQL = $"UPDATE ItemDesc SET ItemDesc = `{desc}` WHERE ItemCode = `{code}`";
            int row = 0;
            DataSet update = new DataSet();
            update = cda.ExecuteSQLStatement(updateDescSQL, ref row);
            DataTable dt = update.Tables[updateDescSQL];

            return dt;
        }

        /// <summary>
        /// Updates item cost using item code as a unique identifier
        /// </summary>
        /// <param name="code"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public DataTable UpdateCost(string code, int cost)
        {
            string updateCostSQL = $"UPDATE ItemDesc SET Cost = {cost} WHERE ItemCode = `{code}`";
            int row = 0;
            DataSet update = new DataSet();
            update = cda.ExecuteSQLStatement(updateCostSQL, ref row);
            DataTable dt = update.Tables[updateCostSQL];

            return dt;
        }
    }
}
