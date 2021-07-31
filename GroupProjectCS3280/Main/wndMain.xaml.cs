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
        /// Calls the test dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Temp_Search_Click(object sender, RoutedEventArgs e)
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
    }
}
