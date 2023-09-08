using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Stimulsoft.Report.Func;


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
            var result_Etelat = Barbari_BLL.Report.Select_Maghsad(CityOneDestination_CmBox.Text, OneDestinationFromDate_DtPicker.Text, OneDestinationToDate_DtPicker.Text);
            if (result_Etelat.Success)
            {
                var rpt = StiReportHelper.GetReport("ReportMaghsad.mrt");
                var result_Company = Barbari_BLL.Company.Select();
                if (result_Company.Success == true)
                {
                    rpt.Dictionary.Variables["NamSherkat"].Value = result_Company.Data.CompanyName;
                    rpt.Dictionary.Variables["TarikhChap"].Value = Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now);
                    rpt.Dictionary.Variables["TelephonCompany"].Value = result_Company.Data.CompanyTelephon;
                    rpt.Dictionary.Variables["tedad"].Value = result_Etelat.Data.Count.ToString();
                    rpt.Dictionary.Variables["NamShahrMaghsad"].Value = CityOneDestination_CmBox.Text;
                    rpt.Dictionary.Variables["AzTarikh"].Value = OneDestinationFromDate_DtPicker.Text;
                    rpt.Dictionary.Variables["TaTarikh"].Value = OneDestinationToDate_DtPicker.Text;
                    if (result_Company.Data.CompanyIogo != null)
                    {
                        if (File.Exists(result_Company.Data.CompanyIogo))
                        {
                            var logo = File.ReadAllBytes(result_Company.Data.CompanyIogo);
                            rpt.Dictionary.Variables["LogoCompany"].ValueObject = logo;
                        }
                    }
                    foreach (var item in result_Etelat.Data)
                    {

                        item.BarErsaliNamFerestande = item.BarErsaliNamFerestande + " " + item.BarErsaliFamilyFerestande;
                        item.BarErsaliNamGerande = item.BarErsaliNamGerande + " " + item.BarErsaliFamilyGerande;
                    }
                    rpt.RegData("BarErsali_Tbl", result_Etelat.Data.Select(p => new
                    {
                        p.BarErsaliBarname,
                        p.BarErsaliNamFerestande,
                        p.BarErsaliNamGerande,
                        p.BarErsaliShahreMabda,
                        p.BarErsaliTarikh
                    }));
                    rpt.Show();
                }
                else
                {
                    MessageBox.Show(result_Company.Message);
                }
            }
            else
            {
                MessageBox.Show(result_Etelat.Message);
            }
        }
        private void GetReportMablaghShahri_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result_Etelat = Barbari_BLL.Report.Select_MablaghShahri(CityMablaghShahri_CmBox.Text,MablaghShahriFromDate_DtPicker.Text, MablaghShahriToDate_DtPicker.Text);
            if (result_Etelat.Success)
            {
                var rpt = StiReportHelper.GetReport("ReportMablaghShahri.mrt");
                var result_Company = Barbari_BLL.Company.Select();
                if (result_Company.Success == true)
                {
                    rpt.Dictionary.Variables["NamSherkat"].Value = result_Company.Data.CompanyName;
                    rpt.Dictionary.Variables["TarikhChap"].Value = Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now);
                    rpt.Dictionary.Variables["TelephonCompany"].Value = result_Company.Data.CompanyTelephon;
                    rpt.Dictionary.Variables["Shahr"].Value = CityMablaghShahri_CmBox.Text;
                    rpt.Dictionary.Variables["AzTarikh"].Value = MablaghShahriFromDate_DtPicker.Text;
                    rpt.Dictionary.Variables["TaTarikh"].Value = MablaghShahriToDate_DtPicker.Text;
                    if (result_Company.Data.CompanyIogo != null)
                    {
                        if (File.Exists(result_Company.Data.CompanyIogo))
                        {
                            var logo = File.ReadAllBytes(result_Company.Data.CompanyIogo);
                            rpt.Dictionary.Variables["LogoCompany"].ValueObject = logo;
                        }
                    }
                    foreach (var item in result_Etelat.Data)
                    {

                        item.BarErsaliNamFerestande = item.BarErsaliNamFerestande + " " + item.BarErsaliFamilyFerestande;
                        item.BarErsaliNamGerande = item.BarErsaliNamGerande + " " + item.BarErsaliFamilyGerande;
                    }
                    rpt.RegData("BarErsali_Tbl", result_Etelat.Data.Select(p => new
                    {
                        p.BarErsaliBarname,
                        p.BarErsaliNamFerestande,
                        p.BarErsaliNamGerande,
                        p.BarErsaliShahri
                    }));
                    rpt.Show();
                }
                else
                {
                    MessageBox.Show(result_Company.Message);
                }
            }
            else
            {
                MessageBox.Show(result_Etelat.Message);
            }
        }

        private void GetReportMojodiFeliAnbar_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result_Etelat = Barbari_BLL.Report.Select_MojodiFeliErsali(Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now));
            var result_Etelat2 = Barbari_BLL.Report.Select_MojodiFeliTahvili(Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now));
            if (result_Etelat.Success == true && result_Etelat2.Success == true)
            {
                var rpt = StiReportHelper.GetReport("ReportMojodiAnbar.mrt");
                var result_Company = Barbari_BLL.Company.Select();
                if (result_Company.Success == true)
                {
                    rpt.Dictionary.Variables["NamSherkat"].Value = result_Company.Data.CompanyName;
                    rpt.Dictionary.Variables["TarikhChap"].Value = Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now);
                    rpt.Dictionary.Variables["TelephonCompany"].Value = result_Company.Data.CompanyTelephon;
                    rpt.Dictionary.Variables["tedad"].Value = (result_Etelat.Data.Count + result_Etelat2.Data.Count).ToString();
                    rpt.Dictionary.Variables["DarTarikh"].Value = Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now);
                    if (result_Company.Data.CompanyIogo != null)
                    {
                        if (File.Exists(result_Company.Data.CompanyIogo))
                        {
                            var logo = File.ReadAllBytes(result_Company.Data.CompanyIogo);
                            rpt.Dictionary.Variables["LogoCompany"].ValueObject = logo;
                        }
                        
                    }
                    foreach (var item in result_Etelat.Data)
                    {

                        item.BarErsaliNamFerestande = item.BarErsaliNamFerestande + " " + item.BarErsaliFamilyFerestande;
                        item.BarErsaliNamGerande = item.BarErsaliNamGerande + " " + item.BarErsaliFamilyGerande;
                    }
                    foreach (var item in result_Etelat2.Data)
                    {

                        item.BarTahviliNamFerestande = item.BarTahviliNamFerestande + " " + item.BarTahviliFamilyFerestande;
                        item.BarTahviliNamGerande = item.BarTahviliNamGerande + " " + item.BarTahviliFamilyGerande;
                    }
                    rpt.RegData("BarErsali_Tbl", result_Etelat.Data.Select(p => new
                    {
                        p.BarErsaliBarname,
                        p.BarErsaliNamFerestande,
                        p.BarErsaliNamGerande,
                    }));
                    rpt.RegData("BarTahvili_Tbl", result_Etelat2.Data.Select(p => new
                    {
                        p.BarTahviliBarname,
                        p.BarTahviliNamFerestande,
                        p.BarTahviliNamGerande,
                    }));
                    rpt.Show();
                }
                else
                {
                    MessageBox.Show(result_Company.Message);
                }
            }
            else
            {
                MessageBox.Show(result_Etelat.Message);
            }
        }

        private void GetReportKalaKhorojiList_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result_Etelat = Barbari_BLL.Report.Select_KhorojBar(KalaKhorojiListFromDate_DtPicker.Text, KalaKhorojiListToDate_DtPicker.Text);
            if (result_Etelat.Success)
            {
                var rpt = StiReportHelper.GetReport("ReportVorodeBar.mrt");
                var result_Company = Barbari_BLL.Company.Select();
                if (result_Company.Success == true)
                {
                    rpt.Dictionary.Variables["NamSherkat"].Value = result_Company.Data.CompanyName;
                    rpt.Dictionary.Variables["TarikhChap"].Value = Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now);
                    rpt.Dictionary.Variables["TelephonCompany"].Value = result_Company.Data.CompanyTelephon;
                    rpt.Dictionary.Variables["tedad"].Value = result_Etelat.Data.Count.ToString();
                    rpt.Dictionary.Variables["azTarikh"].Value = KalaKhorojiListFromDate_DtPicker.Text;
                    rpt.Dictionary.Variables["TaTarikh"].Value = KalaKhorojiListToDate_DtPicker.Text;
                    if (result_Company.Data.CompanyIogo != null)
                    {
                        if (File.Exists(result_Company.Data.CompanyIogo))
                        {
                            var logo = File.ReadAllBytes(result_Company.Data.CompanyIogo);
                            rpt.Dictionary.Variables["LogoCompany"].ValueObject = logo;
                        }
                    }
                    foreach (var item in result_Etelat.Data)
                    {

                        item.BarErsaliPishKeraye += (decimal)item.BarErsaliBime + (decimal)item.BarErsaliAnbardari + (decimal)item.BarErsaliBastebandi
                                            + (decimal)item.BarErsaliShahri + item.BarErsaliPasKeraye;

                    }
                    foreach (var item in result_Etelat.Data)
                    {

                        item.BarErsaliNamFerestande = item.BarErsaliNamFerestande + " " + item.BarErsaliFamilyFerestande;
                        item.BarErsaliNamGerande = item.BarErsaliNamGerande + " " + item.BarErsaliFamilyGerande;
                    }
                    rpt.RegData("BarErsali_Tbl", result_Etelat.Data.Select(p => new
                    {
                        p.BarErsaliBarname,
                        p.BarErsaliNamFerestande,
                        p.BarErsaliNamGerande,
                        p.BarErsaliPishKeraye,
                        p.BarErsaliTarikh
                    }));
                    rpt.Show();
                }
                else
                {
                    MessageBox.Show(result_Company.Message);
                }
            }
            else
            {
                MessageBox.Show(result_Etelat.Message);
            }
        }

        private void GetReportBarVorodiList_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result_Etelat = Barbari_BLL.Report.Select_VorodiBar(BarVorodiListFromDate_DtPicker.Text, BarVorodiListToDate_DtPicker.Text);
            if (result_Etelat.Success)
            {
                var rpt = StiReportHelper.GetReport("ReportVorodeBar.mrt");
                var result_Company = Barbari_BLL.Company.Select();
                if (result_Company.Success == true)
                {
                    rpt.Dictionary.Variables["NamSherkat"].Value = result_Company.Data.CompanyName;
                    rpt.Dictionary.Variables["TarikhChap"].Value = Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now);
                    rpt.Dictionary.Variables["TelephonCompany"].Value = result_Company.Data.CompanyTelephon;
                    rpt.Dictionary.Variables["tedad"].Value = result_Etelat.Data.Count.ToString();
                    rpt.Dictionary.Variables["azTarikh"].Value = BarVorodiListFromDate_DtPicker.Text;
                    rpt.Dictionary.Variables["TaTarikh"].Value = BarVorodiListToDate_DtPicker.Text;
                    if (result_Company.Data.CompanyIogo != null)
                    {
                        if (File.Exists(result_Company.Data.CompanyIogo))
                        {
                            var logo = File.ReadAllBytes(result_Company.Data.CompanyIogo);
                            rpt.Dictionary.Variables["LogoCompany"].ValueObject = logo;
                        }
                    }
                    foreach (var item in result_Etelat.Data)
                    {

                        item.BarErsaliPishKeraye += (decimal)item.BarErsaliBime + (decimal)item.BarErsaliAnbardari + (decimal)item.BarErsaliBastebandi
                                            + (decimal)item.BarErsaliShahri + item.BarErsaliPasKeraye;

                    }
                    foreach (var item in result_Etelat.Data)
                    {

                        item.BarErsaliNamFerestande = item.BarErsaliNamFerestande + " " + item.BarErsaliFamilyFerestande;
                        item.BarErsaliNamGerande = item.BarErsaliNamGerande + " " + item.BarErsaliFamilyGerande;
                    }
                    rpt.RegData("BarErsali_Tbl", result_Etelat.Data.Select(p => new
                    {
                        p.BarErsaliBarname,
                        p.BarErsaliNamFerestande,
                        p.BarErsaliNamGerande,
                        p.BarErsaliPishKeraye,
                        p.BarErsaliTarikh
                    }));
                    rpt.Show();
                }
                else
                {
                    MessageBox.Show(result_Company.Message);
                }
            }
            else
            {
                MessageBox.Show(result_Etelat.Message);
            }
        }

        private void GetReportCustomer_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result_Etelat = Barbari_BLL.Report.Select_MoshtariSabet(CodeCustomer_CmBox.Text, CustomerFromDate_DtPicker.Text, CustomerToDate_DtPicker.Text);
            if (result_Etelat.Success)
            {
                var rpt = StiReportHelper.GetReport("ReportMoshtari.mrt");
                var result_Moshtari = Barbari_BLL.Customers.Select_Code_NotList(int.Parse(CodeCustomer_CmBox.Text));
                var result_Company = Barbari_BLL.Company.Select();
                if (result_Moshtari.Success == true && result_Company.Success == true)
                {
                    rpt.Dictionary.Variables["NamSherkat"].Value = result_Company.Data.CompanyName;
                    rpt.Dictionary.Variables["TarikhChap"].Value = Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now);
                    rpt.Dictionary.Variables["TelephonCompany"].Value = result_Company.Data.CompanyTelephon;
                    rpt.Dictionary.Variables["tedad"].Value = result_Etelat.Data.Count.ToString();
                    rpt.Dictionary.Variables["FirstNameAndLastNameMoshtari"].Value = result_Moshtari.Data.CustomersFirstName + " " + result_Moshtari.Data.CustomersLastName;
                    rpt.Dictionary.Variables["CodeEshterak"].Value = result_Moshtari.Data.CustomersCode.ToString();
                    rpt.Dictionary.Variables["ShomareMoshtari"].Value = result_Moshtari.Data.CustomersMobile;
                    rpt.Dictionary.Variables["azTarikh"].Value = CustomerFromDate_DtPicker.Text;
                    rpt.Dictionary.Variables["TaTarikhe"].Value = CustomerToDate_DtPicker.Text;
                    foreach (var item in result_Etelat.Data)
                    {
                        item.BarErsaliPishKeraye += (decimal)item.BarErsaliBime + (decimal)item.BarErsaliAnbardari + (decimal)item.BarErsaliBastebandi
                                            + (decimal)item.BarErsaliShahri + item.BarErsaliPasKeraye;
                        
                    }
                    foreach (var item in result_Etelat.Data)
                    {
                        item.BarErsaliNamGerande = item.BarErsaliNamGerande + " " + item.BarErsaliFamilyGerande;
                    }
                    if (result_Company.Data.CompanyIogo != null)
                    {
                        if (File.Exists(result_Company.Data.CompanyIogo))
                        {
                            var logo = File.ReadAllBytes(result_Company.Data.CompanyIogo);
                            rpt.Dictionary.Variables["LogoCompany"].ValueObject = logo;
                        }
                    }
                    rpt.RegData("BarErsali_Tbl", result_Etelat.Data.Select(p => new
                    {
                        p.BarErsaliBarname,
                        p.BarErsaliNamGerande,
                        p.BarErsaliTarikh,
                        p.BarErsaliPishKeraye
                    }));
                    rpt.Show();
                }
                else
                {
                    MessageBox.Show(result_Company.Message);
                }
            }
            else
            {
                MessageBox.Show(result_Etelat.Message);
            }
        }
        private void GetReportDriver_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result_Etelat = Barbari_BLL.Report.Select_Ranande(CodeRanande_CmBox.Text, RanandeFromDate_DtPicker.Text, RanandeToDate_DtPicker.Text);
            if (result_Etelat.Success)
            {
                var rpt = StiReportHelper.GetReport("ReportRanande.mrt");
                var result_Ranande = Barbari_BLL.Ranande.Select_Code_NotList(int.Parse(CodeRanande_CmBox.Text));
                var result_Company = Barbari_BLL.Company.Select();
                if (result_Ranande.Success == true && result_Company.Success == true)
                {
                    rpt.Dictionary.Variables["NamSherkat"].Value = result_Company.Data.CompanyName;
                    rpt.Dictionary.Variables["TarikhChap"].Value = Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now);
                    rpt.Dictionary.Variables["TelephonCompany"].Value = result_Company.Data.CompanyTelephon;
                    rpt.Dictionary.Variables["tedad"].Value = result_Etelat.Data.Count.ToString();
                    rpt.Dictionary.Variables["FirstNameAndLastNameRanade"].Value = result_Ranande.Data.RanandeFirstName + " " + result_Ranande.Data.RanandeLastName;
                    rpt.Dictionary.Variables["CodeRanande"].Value = result_Ranande.Data.RanandeCodeRanande.ToString();
                    rpt.Dictionary.Variables["ShomareRanande"].Value = result_Ranande.Data.RanandeMobile;
                    rpt.Dictionary.Variables["azTarikh"].Value = RanandeFromDate_DtPicker.Text;
                    rpt.Dictionary.Variables["TaTarikhe"].Value = RanandeToDate_DtPicker.Text;
                    if (result_Company.Data.CompanyIogo != null)
                    {
                        if (File.Exists(result_Company.Data.CompanyIogo))
                        {
                            var logo = File.ReadAllBytes(result_Company.Data.CompanyIogo);
                            rpt.Dictionary.Variables["LogoCompany"].ValueObject = logo;
                        }
                    }
                    foreach (var item in result_Etelat.Data)
                    {

                        item.BarErsaliNamFerestande = item.BarErsaliNamFerestande + " " + item.BarErsaliFamilyFerestande;
                        item.BarErsaliNamGerande = item.BarErsaliNamGerande + " " + item.BarErsaliFamilyGerande;
                    }
                    rpt.RegData("BarErsali_Tbl", result_Etelat.Data.Select(p => new
                    {
                        p.BarErsaliBarname,
                        p.BarErsaliNamFerestande,
                        p.BarErsaliNamGerande,
                        p.BarErsaliTarikh
                    }));
                    rpt.Show();
                }
                else
                {
                    MessageBox.Show(result_Company.Message);
                }
            }
            else
            {
                MessageBox.Show(result_Etelat.Message);
            }


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
