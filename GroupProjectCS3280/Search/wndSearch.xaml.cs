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
using GroupProjectCS3280.Main;

/// <summary>
/// Entry point for the Search namespace
/// </summary>
namespace GroupProjectCS3280.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// Main window
        /// </summary>
        wndMain mainWindow;

        /// <summary>
        /// calls Search Logic class
        /// </summary>
        clsSearchLogic SearchLogic;
        //clsSearchSQL SearchSQL;

        /// <summary>
        /// Initializer of the window; Called when window first appears
        /// </summary>
        public wndSearch()
        {
            try
            {
                InitializeComponent();

                mainWindow = new wndMain();

                SearchLogic = new clsSearchLogic();

                DataGridTextColumn col1 = new DataGridTextColumn();
                DataGridTextColumn col2 = new DataGridTextColumn();
                DataGridTextColumn col3 = new DataGridTextColumn();

                SearchDataGrid.Columns.Add(col1);
                SearchDataGrid.Columns.Add(col2);
                SearchDataGrid.Columns.Add(col3);

                col1.Binding = new Binding("num");
                col2.Binding = new Binding("date");
                col3.Binding = new Binding("cost");

                col1.Header = "Invoice Number";
                col2.Header = "Invoice Date";
                col3.Header = "Total Cost";

                List<clsInvoice> Rows = new List<clsInvoice>();
                string nullstring = null;
                Rows = SearchLogic.RunQuery(nullstring, nullstring, nullstring); //Query will Select all Invoices

                foreach (clsInvoice Row in Rows)
                {
                    SearchDataGrid.Items.Add(Row);
                }

                //Add appropiate values to ComboBoxes

                List<string> InvoiceNums = SearchLogic.FillInvoiceNumBox();

                foreach (string InvoiceNum in InvoiceNums)
                {
                    InvoiceNumberBox.Items.Add(InvoiceNum);
                }

                List<string> InvoiceDates = SearchLogic.FillInvoiceDateBox();

                foreach (string InvoiceDate in InvoiceDates)
                {
                    InvoiceDateBox.Items.Add(InvoiceDate);
                }

                List<string> TotalCharges = SearchLogic.FillTotalChargeBox();

                foreach (string TotalCharge in TotalCharges)
                {
                    TotalChargeBox.Items.Add(TotalCharge);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// At the end, hides the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clsInvoice selectedInvoice = (clsInvoice)SearchDataGrid.SelectedItem;

                // Pass selectedInvoice to mainWindow
                // Ask for public variables in main class, then set that public variable (i.e. main.selectedInvoice = selectedInvoice)

                this.Hide();
                mainWindow.Activate();
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Calls the update data grid function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceNumberBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                UpdateDataGrid();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Calls the update data grid function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceDateBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                UpdateDataGrid();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Calls the update data grid function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TotalChargeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                UpdateDataGrid();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the grid for current data
        /// </summary>
        private void UpdateDataGrid()
        {
            try
            {
                string num = (string)InvoiceNumberBox.SelectedItem;
                string date = (string)InvoiceDateBox.SelectedItem;
                string total = (string)TotalChargeBox.SelectedItem;

                //send these parameters to function RunQuery in clsSearchLogic. RunQuery returns list of invoices to be added to the SearchDataGrid
                List<clsInvoice> Rows;
                Rows = SearchLogic.RunQuery(num, date, total);

                SearchDataGrid.Items.Clear();
                foreach (clsInvoice Row in Rows)
                {
                    SearchDataGrid.Items.Add(Row);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Hides the current window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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
        /// Keeps window from being disposed; really just hides the window instead of closing it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.Hide();
                mainWindow.Activate();
                mainWindow.Show();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
