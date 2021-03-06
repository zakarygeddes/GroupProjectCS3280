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
using System.Reflection;
using System.Collections.ObjectModel;

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
        /// <summary>
        /// variable for search page
        /// </summary>
        wndSearch Search;
        /// <summary>
        /// variable for items page
        /// </summary>
        wndItems Items;
        /// <summary>
        /// flag for new invoice check
        /// </summary>
        bool newInvoice;
        /// <summary>
        /// flag for editing invoice
        /// </summary>
        bool isEditing;
        /// <summary>
        /// varaible to store selected index of dg item
        /// </summary>
        int selectedIndex;
        /// <summary>
        /// variable to store total cost
        /// </summary>
        int totalCost;
        /// <summary>
        /// variable for invoice id
        /// </summary>
        public int selectedInvoiceNum;
        /// <summary>
        /// variable for checking db index
        /// </summary>
        public int index;
        /// <summary>
        /// variable to store line item code
        /// </summary>
        public string selectedCode;
        /// <summary>
        /// variable to hold main SQL class
        /// </summary>
        clsMainSQL clsMainSQL;
        /// <summary>
        /// Database access class
        /// </summary>
        clsDataAccess db;
        /// <summary>
        /// variable to hold main logic class
        /// </summary>
        clsMainLogic clsMainLogic;
        /// <summary>
        /// list of items
        /// </summary>
        List<clsItem> items;

        /// <summary>
        /// Called when the Window initializes
        /// </summary>
        public wndMain()
        {
            try
            {
                InitializeComponent();
                clsMainSQL = new clsMainSQL();
                clsMainLogic = new clsMainLogic();
                db = new clsDataAccess();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                fillcmbItems();
                gridInputs.IsEnabled = false;
                btnDeleteInvoice.IsEnabled = false;
                btnEditInvoice.IsEnabled = false;
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
            try
            {
                items = new List<clsItem>();
                items = clsMainLogic.fillItemsBox(db, clsMainSQL.getAllItems());
                selectedIndex = cmbItems.SelectedIndex;

                for (int i = 0; i < items.Count; i++)
                {
                    if (selectedIndex == i)
                    {
                        txtCost.Text = items[i].cost;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Button to handle new invoice generation
        /// allowing and disallowing certain button clicks 
        /// and allowing the grid of inputs to be enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewInvoice_Click(object sender, RoutedEventArgs e)
        {          
            try
            {
                isEditing = false;
                gridInputs.IsEnabled = true;
                btnEnter.IsEnabled = true;
                btnSave.IsEnabled = true;
                btnEditInvoice.IsEnabled = false;
                btnDeleteInvoice.IsEnabled = false;
                dgInvoice.Items.Clear();
                totalCost = 0;
                DatePicker.SelectedDate = null;
                txtInvoiceNum.Text = "TBD";
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
            try
            {
                isEditing = true;
                btnNewInvoice.IsEnabled = false;
                btnDeleteInvoice.IsEnabled = false;
                btnEnter.IsEnabled = true;
                btnSave.IsEnabled = true;
                btnDeleteLine.Visibility = Visibility.Visible;

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
            try
            {
                //populate dg and labels with either new invoice or variable from search class
                //handle deleting from db through logic and sql classes
                items = new List<clsItem>();
                String sSQL= clsMainSQL.deleteLineItems(Int32.Parse(txtInvoiceNum.Text));
                clsMainLogic.deleteLineItems(db, sSQL);
                sSQL = clsMainSQL.deleteInvoices(Int32.Parse(txtInvoiceNum.Text));
                clsMainLogic.deleteInvoice(db, sSQL);
                dgInvoice.Items.Clear();
                txtInvoiceNum.Text = "";
                DatePicker.SelectedDate = null;
                cmbItems.SelectedItem = "";
                GlobalVariables.selectedInvoice = null;
                btnDeleteInvoice.IsEnabled = false;
                btnEditInvoice.IsEnabled = false;
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
                items = new List<clsItem>();
                items = clsMainLogic.fillItemsBox(db, clsMainSQL.getAllItems());
                selectedIndex = cmbItems.SelectedIndex;
                clsItem item; //what does this line do?

                if (DatePicker.Text == "")
                {
                    MessageBox.Show("Please select a date.");
                }
                if (cmbItems.SelectedItem == null)
                {
                    MessageBox.Show("Please select an item.");
                }
            

                for (int i = 0; i < items.Count; i++)
                {
                    if (selectedIndex == i)
                    {
                        item = items[i];
                        totalCost += Int32.Parse(item.cost);
                        lblTotalCostNum.Content = totalCost.ToString();
                        dgInvoice.Items.Add(item);
                    }
                }

               
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// handles control menu clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ctrlEditItem.IsChecked == true)
                {
                    this.Hide();
                    wndItems Items = new wndItems();
                    Items.ShowDialog();
                    fillcmbItems();
                }
                if (ctrlSearch.IsChecked == true)
                {
                    this.Hide();
                    wndSearch Search = new wndSearch();

                    Search.ShowDialog();


                    string sSQL = "";
                    clsInvoice invoice = GlobalVariables.selectedInvoice;
                    sSQL = clsMainSQL.getLineItemsFromInvoice(Int32.Parse(invoice.num));
                    List<clsItem> dgItems = new List<clsItem>();
                    db = new clsDataAccess(); //how does it affect the data integrity if we refresh the database class every time? (This is legit me asking. Does it mess with the data that's been changed before?) -Wyn
                    dgInvoice.Items.Clear(); //clears the datagrid
                    dgItems = clsMainLogic.getLineItemsFromInvoice(db, sSQL); //then gets the new items...
                    ObservableCollection<clsItem> collectionItems = new ObservableCollection<clsItem>(dgItems); //then sends it to the clsItem class and makes a list?
                    dgInvoice.ItemsSource = collectionItems; //and now replaces the items' source in the datagrid with the items from the clsItem class list you just made
                    /*
                    for (int i = 0; i < dgItems.Count; i++)
                    {
                        dgInvoice.Items.Add(dgItems[i]);
                    }
                    */
                    dgInvoice.Items.Refresh(); //so this should display the clsItems class list item source
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method to fill combo items box
        /// </summary>
        private void fillcmbItems()
        {
            try
            {
                items = new List<clsItem>();

                items = clsMainLogic.fillItemsBox(db, clsMainSQL.getAllItems());

                for (int i = 0; i < items.Count; i++)
                {
                    cmbItems.Items.Add(items[i].description);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// button to deal with saving invoice after adding items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime date = DatePicker.SelectedDate.Value;

                if (!isEditing)
                {
                    string sSQL = clsMainSQL.addNewInvoice(date, totalCost);
                    clsMainLogic.addInvoice(db, sSQL);

                    sSQL = clsMainSQL.getMaxInvoiceNum();
                    int invoiceNum = clsMainLogic.maxInvoiceNum(db, sSQL);
                    selectedInvoiceNum = invoiceNum;

                    txtInvoiceNum.Text = invoiceNum.ToString();

                    List<clsItem> items = new List<clsItem>();
                    for (int i = 0; i < dgInvoice.Items.Count; i++)
                    {
                        items.Add((clsItem)dgInvoice.Items.GetItemAt(i));
                    }

                    for (int i = 0; i < items.Count; i++)
                    {
                        sSQL = clsMainSQL.addNewLineItem(invoiceNum, (i + 1), items[i].code);
                        clsMainLogic.addLineItem(db, sSQL);
                    }




                    clsInvoice invoice = new clsInvoice(invoiceNum.ToString(), date.ToString(), totalCost.ToString());
                    GlobalVariables.selectedInvoice = invoice;

                    sSQL = clsMainSQL.getLineItemsFromInvoice(Int32.Parse(invoice.num));
                    List<clsItem> dgItems = new List<clsItem>();
                    db = new clsDataAccess();
                    dgInvoice.Items.Clear();
                    dgItems = clsMainLogic.getLineItemsFromInvoice(db, sSQL);

                    for (int i = 0; i < dgItems.Count; i++)
                    {
                        dgInvoice.Items.Add(dgItems[i]);
                    }



                }
                else
                {
                    //TODO handle editing logic and sql and populating datagrid?
                }


                btnSave.IsEnabled = false;
                btnEnter.IsEnabled = false;
                btnEditInvoice.IsEnabled = true;
                btnDeleteInvoice.IsEnabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for handling selected datagrid item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                clsItem item = (clsItem)dgInvoice.SelectedItem;
                selectedCode = item.code;
                index = dgInvoice.SelectedIndex + 1;
                lblSelected.Content = "Item: " + item.description +" Line " + index;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for deleting line item off of an invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteLine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sSQL = clsMainSQL.deleteLineItemsFromInvoice(selectedInvoiceNum, index);
                clsMainLogic.deleteLineItems(db, sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
