using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using GroupProjectCS3280.Main;

/// <summary>
/// Namespace for the class behind the xaml window
/// </summary>
namespace GroupProjectCS3280.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        /// <summary>
        /// accesses the database
        /// </summary>
        clsDataAccess cda;
        /// <summary>
        /// calls upon the clsItemLogic class
        /// </summary>
        clsItemsLogic itemLogic;
        /// <summary>
        /// Calls the mainWindow
        /// </summary>
        wndMain mainWindow;

        /// <summary>
        /// Initializer for the window
        /// </summary>
        public wndItems() {
            try
            {
                // initializes the required classes and windows
                itemLogic = new clsItemsLogic();
                cda = new clsDataAccess();
                mainWindow = new wndMain();

                DataSet ds = new DataSet();
                ds = itemLogic.InitializeDataGrid(); //fill up with data

                InitializeComponent();
                SearchItemsDataGrid.IsReadOnly = true; //sets data grid to read only
                SearchItemsDataGrid.ItemsSource = ds.Tables[0].AsDataView(); //populate data grid
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Keeps window from being disposed; really just hides the window instead of closing it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.Hide();
                mainWindow.Activate(); //should bring up the main window again
                mainWindow.Show();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Returns the user to the Main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //current invoice id, if we have one, will go here 
                //valid invoice might go here too 
                //basically, pass needed information back to main window via public variables
                this.Close();
                mainWindow.Activate();
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Check for input before sending inputs through
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool codeCheck = false;
                bool descCheck = false;
                bool costCheck = false;
                int cost = 0;
                if (NewItemCodeTxt.Text != "i.e. 'AA'" && NewItemCodeTxt.Text.Length > 1)
                    codeCheck = true;
                if (NewItemDescTxt.Text != "i.e. 'Anniversary'" && NewItemDescTxt.Text.Length > 1)
                    descCheck = true;
                if (NewItemCostTxt.Text != "i.e. '300'" && NewItemCostTxt.Text.Length > 0)
                {
                    if (int.TryParse(NewItemCostTxt.Text, out cost))
                        costCheck = true;
                    else
                    {
                        MessageBox.Show("Please enter an integer into the cost box.");
                        return;
                    }
                }
                if (codeCheck == true && descCheck == true && costCheck == true)
                {
                    string code = NewItemCodeTxt.Text;
                    string desc = NewItemDescTxt.Text;
                    itemLogic.AddLogic(code, desc, cost);
                }
                else
                {
                    MessageBox.Show("Please enter correct inputs before submitting. " +
                        "Cost must be an integer, and item code and item description " +
                        "must be at least one character in length.");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Allows the user to edit an item depending on what they clicked and parameters entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ItemCodeCombo.SelectedItem != null) //item code should have been selected
                {
                    string code = ItemCodeCombo.SelectedItem.ToString(); //get the item code
                    string desc = '"' + EditItemDescTxt.Text + '"'; //put quotes around item description
                    bool check = int.TryParse(EditItemCostTxt.Text, out int cost); //check if entered information is an integer

                    if (EditItemDescCheck.IsChecked == true && EditItemCostCheck.IsChecked == true) //edit both
                    {
                        if (check)
                            itemLogic.EditAll(code, desc, cost);
                        else 
                        { 
                            MessageBox.Show("Cost entered is not an integer.");
                            return;
                        }
                    }
                    else if (EditItemDescCheck.IsChecked == true && EditItemCostCheck.IsChecked == false) //edit only description
                    {
                        itemLogic.EditDesc(code, desc);
                    }
                    else if (EditItemDescCheck.IsChecked == false && EditItemCostCheck.IsChecked == true) //edit only cost
                    {
                        if (check)
                            itemLogic.EditCost(code, cost);
                        else
                        {
                            MessageBox.Show("Cost entered is not an integer.");
                            return;
                        }
                    }
                    else //nothing is checked
                    {
                        MessageBox.Show("Please select a box if you'd like to edit an item.");
                        return;
                    }
                }
                else //item code was not selected
                {
                    MessageBox.Show("Please select the item code of the item to edit.");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the item from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string code = ItemCodeCombo.SelectedItem.ToString();
                itemLogic.DeleteLogic(code);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Loads and populates the combo box on the window loading. Default selection is "not"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemCodeCombo_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<String> items = itemLogic.GetItems();
                ItemCodeCombo.ItemsSource = items;
                ItemCodeCombo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Refresh the data grid to keep items current
        /// </summary>
        public void RefreshDataWindow()
        {
            try
            {
                SearchItemsDataGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
