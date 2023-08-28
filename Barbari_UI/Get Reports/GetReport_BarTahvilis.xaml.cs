using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Barbari_UI.Get_Reports
{
    /// <summary>
    /// Interaction logic for GetReport_BarTahvilis.xaml
    /// </summary>
    public partial class GetReport_BarTahvilis : UserControl
    {
        public GetReport_BarTahvilis()
        {
            InitializeComponent();
        }

        private void ListBarReport_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowListBarReport_Grid.Visibility = Visibility.Collapsed;
        }

        private void ListBarReport_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowListBarReport_Grid.Visibility = Visibility.Visible;
            ListBarInAnbarReport_Toggle.IsChecked = false;
            OneDriverListBarReport_Toggle.IsChecked = false;
        }

  
        private void ListBarInAnbarReport_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowListBarInAnbarReport_Grid.Visibility = Visibility.Visible;
            ListBarReport_Toggle.IsChecked = false;
            OneDriverListBarReport_Toggle.IsChecked = false;
        }

        private void ListBarInAnbarReport_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowListBarInAnbarReport_Grid.Visibility = Visibility.Collapsed;
        }


        private void OneDriverListBarReport_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowOneDriverListBarReport_Grid.Visibility = Visibility.Visible;
            ListBarInAnbarReport_Toggle.IsChecked = false;
            ListBarReport_Toggle.IsChecked = false;
        }

        private void OneDriverListBarReport_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowOneDriverListBarReport_Grid.Visibility = Visibility.Collapsed;
        }

        private void OneDriverListBarCodeDriver_CmBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
   

        private void GetReportOneDriverListBar_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GetReportListBarInAnbar_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GetReportListBar_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        void fillComboBoxe()
        {
            var codeDrivers = Barbari_BLL.Ranande.Select_AllRanandeCode();
            if (codeDrivers.Success)
            {
                OneDriverListBarCodeDriver_CmBox.ItemsSource = codeDrivers.Data;
            }
            else
            {
                MessageBox.Show(codeDrivers.Message);
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListBarReport_Toggle.IsChecked = true;
            fillComboBoxe();
        }
    }
}
