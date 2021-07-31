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
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
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
        /// menu control for opening 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ctrlEditItem_Click(object sender, RoutedEventArgs e)
        { 
            //this class goes to the edit items page, this shouldn't need to interact with the other code
            try
            {
                wndItems test = new wndItems();
                //test.Activate(); is a better way to do this than showdialog, I think, but up to you -Dragon
                test.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// menu control item for opening search page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ctrlSearch_Click(object sender, RoutedEventArgs e)
        {
            //this class is designed to move to the search page, no need for interacting with other pages code
            try
            {
                wndSearch test = new wndSearch();
                //test.Activate(); is a better way to do this than showdialog, I think, but up to you -Dragon
                test.ShowDialog();
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
    }
}
