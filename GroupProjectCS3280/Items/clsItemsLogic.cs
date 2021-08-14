using GroupProjectCS3280.Main;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace GroupProjectCS3280.Items
{
    /// <summary>
    /// Contains all business logic for Items
    /// </summary>
    class clsItemsLogic
    {
        /// <summary>
        /// Access to the queries
        /// </summary>
        private clsItemsSQL sql;
        /// <summary>
        /// Access to database
        /// </summary>
        private clsDataAccess db;

        /// <summary>
        /// stores the item description string
        /// </summary>
        private string itemDesc;


        /// <summary>
        /// Constructor statement for logic class
        /// </summary>
        public clsItemsLogic()
        {
            try
            {
                sql = new clsItemsSQL();
                db = new clsDataAccess();
                itemDesc = "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Returns a string list of all item codes
        /// </summary>
        /// <returns></returns>
        public List<String> GetItems()
        {
            DataTable itemCodes = sql.GetItemCodes();
            List<String> items = new List<string>();

            for (int i = 0; i < itemCodes.Rows.Count; i++)
            {
                DataRow currentRow = itemCodes.Rows[i];
                items.Add(Convert.ToString(currentRow["ItemCode"]));
            }

            return items;
        }

        /// <summary>
        /// checks through all item codes and sees if passed in information is the same
        /// </summary>
        public bool CheckForPreExistingItemCode(string item)
        {
            try
            {
                DataTable check = sql.GetItemCodes();   //check returned null
                string content = "";
                DataRow[] row = check.Select(content);


                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i][0] == item)
                    {
                        return true;
                    }
                    return false;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Should handle logic for when an item is added
        /// Checks for duplicate item code
        /// </summary>
        /// <param name="itemCode"></param>
        public void AddLogic(string itemCode, string desc, int cost)
        {
            try
            {
                if (CheckForPreExistingItemCode(itemCode) == true)
                {
                    MessageBox.Show("Item code already exists in system.");
                    return;
                }
                else
                {
                    sql.InsertItem(itemCode, desc, cost);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// logic for deleting an item
        /// </summary>
        /// <param name="itemCode"></param>
        public void DeleteLogic(string itemCode)
        {
            try
            {
                if (sql.GetInvoiceNum(itemCode) != null)     //item is on an invoice
                {
                    MessageBox.Show("Item is on an invoice and cannot be deleted");
                    return;
                }
                else
                {
                    db.ExecuteNonQuery($"DELETE FROM ItemDesc WHERE ItemCode = {itemCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// logic for editing all items (cost, description)
        /// item codes cannot be edited
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        /// <param name="cost"></param>
        public void EditAll(string code, string desc, int cost)
        {
            try
            {
                sql.UpdateAllItems(code, desc, cost);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// logic for editing description alone
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        public void EditDesc(string code, string desc)
        {
            try
            {
                sql.UpdateDesc(code, desc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// logic for editing cost alone
        /// </summary>
        /// <param name="code"></param>
        /// <param name="cost"></param>
        public void EditCost(string code, int cost)
        {
            try
            {
                sql.UpdateCost(code, cost);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// For initializing the dataGrid and filling its contents
        /// </summary>
        /// <returns></returns>
        public DataSet InitializeDataGrid()
        {
            try
            {
                string sqlStatement = sql.getAllSQLStatement;
                int iRef = 0;
                return db.ExecuteSQLStatement(sqlStatement, ref iRef); //
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
