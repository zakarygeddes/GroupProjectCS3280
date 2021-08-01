using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GroupProjectCS3280.Search;
using GroupProjectCS3280.Items;

/// <summary>
/// Namespace for the project field
/// </summary>
namespace GroupProjectCS3280.Main
{
    //This is the main page, it handles getting to the search or edit items pages from
    //a control box called "Options" at the top left.
    //this page also can make a new invoice, or through a seperate invoice class used
    //as an object manager grab data from the search page and use it to populate the 
    //data grid box. This page has buttons that will connect with the logic and SQL classes for
    //the main page and handle the logic. Primarily by passing button click choices to 
    //the logic to set flags and be clear on what they are doing, and that class will go 
    //to the SQL class to generate strings of SQL to execute the statements in the logic
    //this page also interacts with the items pages, in that it will need to
    //populate its combo box with new items if that has been updated.
    //I am not sure if passing some sort of boolean flag out of that page to mark whether
    //it has been updated so that then the combobox knows to refresh

    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        wndSearch Search;
        wndItems Items;
        /// <summary>
        /// Called when the Window initializes
        /// </summary>
        public wndMain()
        {
            try
            {
                InitializeComponent();
                

                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
   
        /// <summary>
        /// Combo box drop down click method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this class will be what handles filling the combo box, this will need to pull from the database,
            //but also be aware of when updates have happened in the Items page code. I am thinking it will check
            //a variable passed by items page out, like a bool for isUpdated
            try
            {
             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Button to handle new invoice generation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewInvoice_Click(object sender, RoutedEventArgs e)
        {
            //this will set a flag in the logic to say that I am making a new invoice, so that when the save button 
            //at the bottom is clicked, it will know to run an INSERT and not an UPDATE
            //it will also know to not fill the datagrid
            //this button click will also have to clear out whatever is being edited
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// button to handle editting invoices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditInvoice_Click(object sender, RoutedEventArgs e)
        {
            //this will need to grab the currently selected invoice from the search page
            //i am thinking this will be a global variable so that all pages can access what 
            //the search page has selected
            try
            {
                //this will populate the datagrid with the invoice passed from the search page
                //this will have to be in some sort of global class/variable/ potentiall an object manager type
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// button to handle deleting invoices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            //it will interact with both logic and sql classes 
            //this will run both a search and delete function. I am thinking it pulls up the selected invoice number
            //then presents the delete as a second chance
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// button to submit new line to invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            //this will store the invoice info in variables and get them ready to be used by the sql class in 
            //creating full sql statement strings
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// handles control menu clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(ctrlEditItem.IsChecked==true)
            {
                this.Hide();
                wndItems Items = new wndItems();
                Items.ShowDialog();
            }
            if (ctrlSearch.IsChecked == true)
            {
                this.Hide();
                wndSearch Search = new wndSearch();
                Search.ShowDialog();
            }
        }
    }
}
