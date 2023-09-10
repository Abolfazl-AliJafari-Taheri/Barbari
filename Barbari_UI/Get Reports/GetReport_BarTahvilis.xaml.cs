using PersianToolkit;
using System;
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
            var result_Etelat = Barbari_BLL.Report.Select_BarTahvili_Ranande(OneDriverListBarCodeDriver_CmBox.Text, OneDriverListBarFromDate_DtPicker.Text, OneDriverListBarToDate_DtPicker.Text);
            if (result_Etelat.Success)
            {
                var rpt = StiReportHelper.GetReport("ReportBarTahviliRanande.mrt");
                var result_Ranande = Barbari_BLL.Ranande.Select_Code_NotList(int.Parse(OneDriverListBarCodeDriver_CmBox.Text));
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
                    rpt.Dictionary.Variables["azTarikh"].Value = OneDriverListBarFromDate_DtPicker.Text;
                    rpt.Dictionary.Variables["TaTarikhe"].Value = OneDriverListBarToDate_DtPicker.Text;
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

                        item.BarTahviliPishKeraye += (decimal)item.BarTahviliBime + (decimal)item.BarTahviliAnbardari + (decimal)item.BarTahviliBastebandi
                                            + (decimal)item.BarTahviliShahri + item.BarTahviliPasKeraye;

                    }
                    foreach (var item in result_Etelat.Data)
                    {

                        item.BarTahviliNamFerestande = item.BarTahviliNamFerestande + " " + item.BarTahviliFamilyFerestande;
                        item.BarTahviliNamGerande = item.BarTahviliNamGerande + " " + item.BarTahviliFamilyGerande;
                    }
                    rpt.RegData("BarTahvili_Tbl", result_Etelat.Data.Select(p => new
                    {
                        p.BarTahviliBarname,
                        p.BarTahviliNamFerestande,
                        p.BarTahviliNamGerande,
                        p.BarTahviliShahrFerestande,
                        p.BarTahviliShahrGerande,
                        p.BarTahviliTarikh,
                        p.BarTahviliPishKeraye
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
        private void GetReportListBarInAnbar_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result_Etelat = Barbari_BLL.Report.Select_BarTahviliMojodDarAnbar(ListBarInAnbarFromDate_DtPicker.Text, ListBarInAnbarToDate_DtPicker.Text);
            if (result_Etelat.Success)
            {
                var rpt = StiReportHelper.GetReport("ReportBarTahviliMojodDarAnbar.mrt");
                var result_Company = Barbari_BLL.Company.Select();
                if (result_Company.Success == true)
                {
                    rpt.Dictionary.Variables["NamSherkat"].Value = result_Company.Data.CompanyName;
                    rpt.Dictionary.Variables["TarikhChap"].Value = Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now);
                    rpt.Dictionary.Variables["TelephonCompany"].Value = result_Company.Data.CompanyTelephon;
                    rpt.Dictionary.Variables["tedad"].Value = result_Etelat.Data.Count.ToString();
                    rpt.Dictionary.Variables["AzTarikh"].Value = ListBarFromDate_DtPicker.Text;
                    rpt.Dictionary.Variables["TaTarikhe"].Value = ListBarToDate_DtPicker.Text;
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

                        item.BarTahviliPishKeraye += (decimal)item.BarTahviliBime + (decimal)item.BarTahviliAnbardari + (decimal)item.BarTahviliBastebandi
                                            + (decimal)item.BarTahviliShahri + item.BarTahviliPasKeraye;

                    }
                    foreach (var item in result_Etelat.Data)
                    {
                        item.BarTahviliNamFerestande = item.BarTahviliNamFerestande + " " + item.BarTahviliFamilyFerestande;
                        item.BarTahviliNamGerande = item.BarTahviliNamGerande + " " + item.BarTahviliFamilyGerande;
                    }
                    rpt.RegData("BarTahvili_Tbl", result_Etelat.Data.Select(p => new
                    {
                        p.BarTahviliBarname,
                        p.BarTahviliNamFerestande,
                        p.BarTahviliNamGerande,
                        p.BarTahviliShahrFerestande,
                        p.BarTahviliShahrGerande,
                        p.BarTahviliTarikh,
                        p.BarTahviliPishKeraye
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
        private void GetReportListBar_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result_Etelat = Barbari_BLL.Report.Select_BarTahviliListBar(ListBarFromDate_DtPicker.Text, ListBarToDate_DtPicker.Text);
            if (result_Etelat.Success)
            {
                var rpt = StiReportHelper.GetReport("ReportBarTahviliTarikh.mrt");
                var result_Company = Barbari_BLL.Company.Select();
                if (result_Company.Success == true)
                {
                    rpt.Dictionary.Variables["NamSherkat"].Value = result_Company.Data.CompanyName;
                    rpt.Dictionary.Variables["TarikhChap"].Value = Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now);
                    rpt.Dictionary.Variables["TelephonCompany"].Value = result_Company.Data.CompanyTelephon;
                    rpt.Dictionary.Variables["tedad"].Value = result_Etelat.Data.Count.ToString();
                    rpt.Dictionary.Variables["AzTarikh"].Value = ListBarFromDate_DtPicker.Text;
                    rpt.Dictionary.Variables["TaTarikhe"].Value = ListBarToDate_DtPicker.Text;
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

                        item.BarTahviliPishKeraye += (decimal)item.BarTahviliBime + (decimal)item.BarTahviliAnbardari + (decimal)item.BarTahviliBastebandi
                                            + (decimal)item.BarTahviliShahri + item.BarTahviliPasKeraye;

                    }
                    foreach (var item in result_Etelat.Data)
                    {
                        item.BarTahviliNamFerestande = item.BarTahviliNamFerestande + " " + item.BarTahviliFamilyFerestande;
                        item.BarTahviliNamGerande = item.BarTahviliNamGerande + " " + item.BarTahviliFamilyGerande;
                    }
                    rpt.RegData("BarTahvili_Tbl", result_Etelat.Data.Select(p => new
                    {
                        p.BarTahviliBarname,
                        p.BarTahviliNamFerestande,
                        p.BarTahviliNamGerande,
                        p.BarTahviliShahrFerestande,
                        p.BarTahviliShahrGerande,
                        p.BarTahviliTarikh,
                        p.BarTahviliPishKeraye
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
            ConfigHelper.Instance.SetLanguage(ConfigHelper.Language.Persian);
            ListBarReport_Toggle.IsChecked = true;
            fillComboBoxe();
        }
    }
}
