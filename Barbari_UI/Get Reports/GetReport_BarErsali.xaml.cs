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
    /// Interaction logic for GetReport_BarErsali.xaml
    /// </summary>
    public partial class GetReport_BarErsali : UserControl
    {
        public GetReport_BarErsali()
        {
            InitializeComponent();
        }

        private void RanandeFromDate_DtPicker_SelectedDateChanged(object sender, RoutedEventArgs e)
        {

        }
        private void RanandeFromDate_DtPicker_SelectedDateChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void RanandeToDate_DtPicker_SelectedDateChanged(object sender, RoutedEventArgs e)
        {

        }

        private void DriverReport_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowDriverReport_Grid.Visibility = Visibility.Visible;
            CustomerReport_Toggle.IsChecked = false;
            OneDestinationReport_Toggle.IsChecked = false;
            BarVorodiListReport_Toggle.IsChecked = false;
            KalaKhorojiListReport_Toggle.IsChecked = false;
            MojodiFeliAnbarReport_Toggle.IsChecked = false;
            MablaghShahriReport_Toggle.IsChecked = false;
        }

        private void DriverReport_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowDriverReport_Grid.Visibility = Visibility.Collapsed;
        }

        private void CustomerReport_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowCustomerReport_Grid.Visibility = Visibility.Visible;
            DriverReport_Toggle.IsChecked = false;
            OneDestinationReport_Toggle.IsChecked = false;
            BarVorodiListReport_Toggle.IsChecked = false;
            KalaKhorojiListReport_Toggle.IsChecked = false;
            MojodiFeliAnbarReport_Toggle.IsChecked = false;
            MablaghShahriReport_Toggle.IsChecked = false;
        }
        private void CustomerReport_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowCustomerReport_Grid.Visibility = Visibility.Collapsed;
        }
        private void OneDestinationReport_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            CustomerReport_Toggle.IsChecked = false;
            DriverReport_Toggle.IsChecked = false;
            BarVorodiListReport_Toggle.IsChecked = false;
            KalaKhorojiListReport_Toggle.IsChecked = false;
            MojodiFeliAnbarReport_Toggle.IsChecked = false;
            MablaghShahriReport_Toggle.IsChecked = false;
            ShowOneDestinationReport_Grid.Visibility = Visibility.Visible;

        }
        private void OneDestinationReport_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowOneDestinationReport_Grid.Visibility = Visibility.Collapsed;

        }
        private void BarVorodiListReport_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            CustomerReport_Toggle.IsChecked = false;
            OneDestinationReport_Toggle.IsChecked = false;
            DriverReport_Toggle.IsChecked = false;
            KalaKhorojiListReport_Toggle.IsChecked = false;
            MojodiFeliAnbarReport_Toggle.IsChecked = false;
            MablaghShahriReport_Toggle.IsChecked = false;
            ShowBarVorodiListReport_Grid.Visibility = Visibility.Visible;
        }

        private void BarVorodiListReport_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowBarVorodiListReport_Grid.Visibility = Visibility.Collapsed;
        }

        private void MojodiFeliAnbarReport_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            CustomerReport_Toggle.IsChecked = false;
            OneDestinationReport_Toggle.IsChecked = false;
            BarVorodiListReport_Toggle.IsChecked = false;
            KalaKhorojiListReport_Toggle.IsChecked = false;
            DriverReport_Toggle.IsChecked = false;
            MablaghShahriReport_Toggle.IsChecked = false;
            ShowMojodiFeliAnbarReport_Grid.Visibility = Visibility.Visible;
        }

        private void MojodiFeliAnbarReport_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowMojodiFeliAnbarReport_Grid.Visibility = Visibility.Collapsed;
        }

        private void KalaKhorojiListReport_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            CustomerReport_Toggle.IsChecked = false;
            OneDestinationReport_Toggle.IsChecked = false;
            BarVorodiListReport_Toggle.IsChecked = false;
            DriverReport_Toggle.IsChecked = false;
            MojodiFeliAnbarReport_Toggle.IsChecked = false;
            MablaghShahriReport_Toggle.IsChecked = false;
            ShowKalaKhorojiListReport_Grid.Visibility = Visibility.Visible;

        }

        private void KalaKhorojiListReport_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowKalaKhorojiListReport_Grid.Visibility = Visibility.Collapsed;

        }

        private void MablaghShahriReport_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            CustomerReport_Toggle.IsChecked = false;
            OneDestinationReport_Toggle.IsChecked = false;
            BarVorodiListReport_Toggle.IsChecked = false;
            KalaKhorojiListReport_Toggle.IsChecked = false;
            MojodiFeliAnbarReport_Toggle.IsChecked = false;
            DriverReport_Toggle.IsChecked = false;
            ShowMablaghShahriReport_Grid.Visibility = Visibility.Visible;

        }

        private void MablaghShahriReport_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowMablaghShahriReport_Grid.Visibility = Visibility.Collapsed;

        }
        private void GetReportOneDestination_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GetReportMablaghShahri_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetReportMojodiFeliAnbar_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetReportKalaKhorojiList_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetReportBarVorodiList_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetReportCustomer_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GetReportDriver_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
        void fillComboBoxe()
        {
            var citys = Barbari_BLL.City.Select_Shahr();
            if(citys.Success)
            {
                CityOneDestination_CmBox.ItemsSource = citys.Data;
                CityMablaghShahri_CmBox.ItemsSource = citys.Data;
            }
            else
            {
                MessageBox.Show(citys.Message);
            }

            var codeCustomers = Barbari_BLL.Customers.Select_AllCustomersCode();
            if(codeCustomers.Success)
            {
                CodeCustomer_CmBox.ItemsSource = codeCustomers.Data;
            }
            else
            {
                MessageBox.Show(codeCustomers.Message);
            }

            var codeDrivers = Barbari_BLL.Ranande.Select_AllRanandeCode();
            if(codeDrivers.Success)
            {
                CodeRanande_CmBox.ItemsSource = codeDrivers.Data;
            }
            else
            {
                MessageBox.Show(codeDrivers.Message);
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DriverReport_Toggle.IsChecked= true;
            fillComboBoxe();
        }

        private void Code_CmBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
