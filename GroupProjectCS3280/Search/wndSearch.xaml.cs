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

namespace GroupProjectCS3280.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        clsSearchLogic SearchLogic;
        //clsSearchSQL SearchSQL;
        public wndSearch()
        {
            InitializeComponent();

            SearchLogic = new clsSearchLogic();
            //SearchSQL = new clsSearchSQL();
            //Testing adding stuff to the data grid, normally SearchLogic.RunQuery("","",""); would be here instead

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

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            clsInvoice selectedInvoice = (clsInvoice)SearchDataGrid.SelectedItem;

            //Here I would pass selectedInvoice to wndMain. Not entirely sure how to do this.

            this.Hide();
        }

        private void InvoiceNumberBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void InvoiceDateBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void TotalChargeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
