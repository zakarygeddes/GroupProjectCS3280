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
            try
            {

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
