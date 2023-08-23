using Barbari_DAL;
using MaterialDesignThemes.Wpf;
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

namespace Barbari_UI.Register_Bar_Ersali
{
    /// <summary>
    /// Interaction logic for TahvilRanande.xaml
    /// </summary>
    public partial class TahvilRanande : UserControl
    {
        public TahvilRanande(BarErsali_Tbl barErsali,bool Edit)
        {
            InitializeComponent();
            BarErsali = barErsali;
            edit = Edit;
        }
        bool edit = false;
        public BarErsali_Tbl BarErsali { get; set; }
        void EditMode()
        {
            if(!string.IsNullOrEmpty(BarErsali.BarErsaliCodeRanande.ToString()))
            {
                Registered_Ranande.IsChecked = true;
                Code_CmBox.Text = BarErsali.BarErsaliCodeRanande.ToString();
            }
            FirstName_Txt.Text = BarErsali.BarErsaliNamRanande;
            LastName_Txt.Text = BarErsali.BarErsaliFamilyRanande;
            Mobile_Txt.Text = BarErsali.BarErsaliMobileRanande;
            Price_Txt.Text = BarErsali.BarErsaliKerayeRanande.ToString();
            Cancel_Btn.Visibility = Visibility.Collapsed;
            Tahvil_Btn_Border.Visibility = Visibility.Collapsed;
            Title_TxtBlock.Visibility= Visibility.Collapsed;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(edit)
            {
                EditMode(); 
            }
            var ranande = Barbari_BLL.Ranande.Select_AllRanandeCode().Data;
            Code_CmBox.ItemsSource= ranande;
        }

        private void Registered_Ranande_Checked(object sender, RoutedEventArgs e)
        {
            FirstName_Txt.Clear();
            LastName_Txt.Clear();
            Mobile_Txt.Clear();
            FirstName_Txt.IsReadOnly = true;
            LastName_Txt.IsReadOnly = true;
            Mobile_Txt.IsReadOnly = true;
            Code_CmBox.IsEnabled= true;
        }

        private void Registered_Ranande_Unchecked(object sender, RoutedEventArgs e)
        {
            FirstName_Txt.Clear();
            LastName_Txt.Clear();
            Mobile_Txt.Clear();
            FirstName_Txt.IsReadOnly = false;
            LastName_Txt.IsReadOnly = false;
            Mobile_Txt.IsReadOnly = false;
            Code_CmBox.Text = "";
            Code_CmBox.IsEnabled = false;
        }

        private void Tahvil_Btn_Click(object sender, RoutedEventArgs e)
        {
           var validation =  Barbari_BLL.Validation.BarErsali_Validation_TahvilRanande(FirstName_Txt.Text, LastName_Txt.Text, Mobile_Txt.Text, Price_Txt.Text, Code_CmBox.Text);
            if (validation.Success)
            {
                BarErsali.BarErsaliNamRanande = FirstName_Txt.Text;
                BarErsali.BarErsaliFamilyRanande = LastName_Txt.Text;
                BarErsali.BarErsaliMobileRanande = Mobile_Txt.Text;
                BarErsali.BarErsaliKerayeRanande = decimal.Parse(Price_Txt.Text);
                if((bool)Registered_Ranande.IsChecked)
                {
                    BarErsali.BarErsaliCodeRanande = int.Parse(Code_CmBox.Text);

                }
                var result = Barbari_BLL.BarErsali.Insert_TahvilBeRanande(BarErsali);
                if(result.Success)
                {
                    if ((bool)PrintToggle.IsChecked)
                    {
                        var query1 = Barbari_BLL.Company.Select();
                        var query2 = Barbari_BLL.BarErsali.Select_KalaDaryafti(BarErsali.BarErsaliBarname);
                        var query3 = Barbari_BLL.BarErsali.Select_Search(BarErsali.BarErsaliBarname);
                        if (query1.Success == true && query2.Success == true && query3.Success == true)
                        {
                            if (!string.IsNullOrEmpty(query3.Data.BarErsaliShahreMaghsad2))
                            {
                                var rpt = StiReportHelper.GetReport("ReportBarnameRanande.mrt");
                                if (query1.Data.CompanyIogo != null)
                                {
                                    var logo = File.ReadAllBytes(query1.Data.CompanyIogo);
                                    rpt.Dictionary.Variables["logo"].ValueObject = logo;
                                }
                                rpt.Dictionary.Variables["NamSherkat"].Value = query1.Data.CompanyName;
                                rpt.Dictionary.Variables["TelephoneSherkat"].Value = query1.Data.CompanyTelephon;
                                rpt.Dictionary.Variables["TarikhSodor"].Value = query3.Data.BarErsaliTarikh;
                                rpt.Dictionary.Variables["ShomareBarname"].Value = query3.Data.BarErsaliBarname.ToString();
                                rpt.Dictionary.Variables["NamAndFamilyFerestande"].Value = query3.Data.BarErsaliNamFerestande + " " + query3.Data.BarErsaliFamilyFerestande;
                                rpt.Dictionary.Variables["ShomareFerestande"].Value = query3.Data.BarErsaliMobileFerestande;
                                rpt.Dictionary.Variables["ShahrMabda"].Value = query3.Data.BarErsaliShahreMabda;
                                rpt.Dictionary.Variables["AnbarMabda"].Value = query3.Data.BarErsaliAnbarMabda;
                                rpt.Dictionary.Variables["NamAndFamilyGerande"].Value = query3.Data.BarErsaliNamGerande + " " + query3.Data.BarErsaliFamilyGerande;
                                rpt.Dictionary.Variables["ShomareGerande"].Value = query3.Data.BarErsaliMobileGerande;
                                rpt.Dictionary.Variables["ShahrMaghsad"].Value = query3.Data.BarErsaliShahreMaghsad1;
                                rpt.Dictionary.Variables["AnbarMaghsad"].Value = query3.Data.BarErsaliAnbarMaghsad1;
                                rpt.Dictionary.Variables["Bime"].Value = query3.Data.BarErsaliBime.ToString();
                                rpt.Dictionary.Variables["Anbardari"].Value = query3.Data.BarErsaliAnbardari.ToString();
                                rpt.Dictionary.Variables["Shahri"].Value = query3.Data.BarErsaliShahri.ToString();
                                rpt.Dictionary.Variables["BasteBandi"].Value = query3.Data.BarErsaliBastebandi.ToString();
                                rpt.Dictionary.Variables["PishKeraye"].Value = query3.Data.BarErsaliPishKeraye.ToString();
                                rpt.Dictionary.Variables["PasKeraye"].Value = query3.Data.BarErsaliPasKeraye.ToString();
                                decimal jam = (decimal)query3.Data.BarErsaliBime + (decimal)query3.Data.BarErsaliAnbardari + (decimal)query3.Data.BarErsaliBastebandi
                                    + (decimal)query3.Data.BarErsaliShahri + query3.Data.BarErsaliPishKeraye + query3.Data.BarErsaliPasKeraye + (decimal)query3.Data.BarErsaliKerayeRanande;
                                rpt.Dictionary.Variables["JamEtelatBar"].Value = jam.ToString();
                                rpt.Dictionary.Variables["Tozihat"].Value = query1.Data.CompanyRules + "\n";
                                rpt.Dictionary.Variables["ShahrMaghsadNahayi"].Value = query3.Data.BarErsaliShahreMaghsad2;
                                rpt.Dictionary.Variables["AnbarMaghsadNahayi"].Value = query3.Data.BarErsaliAnbarMaghsad2;
                                rpt.Dictionary.Variables["NamAndFamilyRanande"].Value = query3.Data.BarErsaliNamRanande +" "+ query3.Data.BarErsaliFamilyRanande;
                                rpt.Dictionary.Variables["ShomareRanande"].Value = query3.Data.BarErsaliMobileRanande;
                                rpt.Dictionary.Variables["TarikhDaryaftBar"].Value = Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now);
                                rpt.Dictionary.Variables["KerayeRanande"].Value = query3.Data.BarErsaliKerayeRanande.ToString();
                                rpt.RegData("KalaDaryafti_Tbl", query2.Data.Select(p => new
                                {
                                    p.KalaDaryaftiNamKala,
                                    p.KalaDaryaftiTedadKala,
                                }));
                                rpt.Show();
                            }
                            else
                            {
                                var rpt = StiReportHelper.GetReport("ReportBarname.mrt");
                                if (query1.Data.CompanyIogo != null)
                                {
                                    var logo = File.ReadAllBytes(query1.Data.CompanyIogo);
                                    rpt.Dictionary.Variables["logo"].ValueObject = logo;
                                }
                                rpt.Dictionary.Variables["NamSherkat"].Value = query1.Data.CompanyName;
                                rpt.Dictionary.Variables["TelephoneSherkat"].Value = query1.Data.CompanyTelephon;
                                rpt.Dictionary.Variables["TarikhSodor"].Value = query3.Data.BarErsaliTarikh;
                                rpt.Dictionary.Variables["ShomareBarname"].Value = query3.Data.BarErsaliBarname.ToString();
                                rpt.Dictionary.Variables["NamAndFamilyFerestande"].Value = query3.Data.BarErsaliNamFerestande + " " + query3.Data.BarErsaliFamilyFerestande;
                                rpt.Dictionary.Variables["ShomareFerestande"].Value = query3.Data.BarErsaliMobileFerestande;
                                rpt.Dictionary.Variables["ShahrMabda"].Value = query3.Data.BarErsaliShahreMabda;
                                rpt.Dictionary.Variables["AnbarMabda"].Value = query3.Data.BarErsaliAnbarMabda;
                                rpt.Dictionary.Variables["NamAndFamilyGerande"].Value = query3.Data.BarErsaliNamGerande + " " + query3.Data.BarErsaliFamilyGerande;
                                rpt.Dictionary.Variables["ShomareGerande"].Value = query3.Data.BarErsaliMobileGerande;
                                rpt.Dictionary.Variables["ShahrMaghsad"].Value = query3.Data.BarErsaliShahreMaghsad1;
                                rpt.Dictionary.Variables["AnbarMaghsad"].Value = query3.Data.BarErsaliAnbarMaghsad1;
                                rpt.Dictionary.Variables["Bime"].Value = query3.Data.BarErsaliBime.ToString();
                                rpt.Dictionary.Variables["Anbardari"].Value = query3.Data.BarErsaliAnbardari.ToString();
                                rpt.Dictionary.Variables["Shahri"].Value = query3.Data.BarErsaliShahri.ToString();
                                rpt.Dictionary.Variables["BasteBandi"].Value = query3.Data.BarErsaliBastebandi.ToString();
                                rpt.Dictionary.Variables["PishKeraye"].Value = query3.Data.BarErsaliPishKeraye.ToString();
                                rpt.Dictionary.Variables["PasKeraye"].Value = query3.Data.BarErsaliPasKeraye.ToString();
                                decimal jam = (decimal)query3.Data.BarErsaliBime + (decimal)query3.Data.BarErsaliAnbardari + (decimal)query3.Data.BarErsaliBastebandi
                                    + (decimal)query3.Data.BarErsaliShahri + query3.Data.BarErsaliPishKeraye + query3.Data.BarErsaliPasKeraye + (decimal)query3.Data.BarErsaliKerayeRanande;
                                rpt.Dictionary.Variables["JamEtelatBar"].Value = jam.ToString();
                                rpt.Dictionary.Variables["Tozihat"].Value = query1.Data.CompanyRules + "\n";
                                rpt.Dictionary.Variables["NamAndFamilyRanande"].Value = query3.Data.BarErsaliNamRanande + " " + query3.Data.BarErsaliFamilyRanande;
                                rpt.Dictionary.Variables["ShomareRanande"].Value = query3.Data.BarErsaliMobileRanande;
                                rpt.Dictionary.Variables["TarikhDaryaftBar"].Value = Barbari_DAL.Possibilities.ConvertToPersian(DateTime.Now);
                                rpt.Dictionary.Variables["KerayeRanande"].Value = query3.Data.BarErsaliKerayeRanande.ToString();
                                rpt.RegData("KalaDaryafti_Tbl", query2.Data.Select(p => new
                                {
                                    p.KalaDaryaftiNamKala,
                                    p.KalaDaryaftiTedadKala,
                                }));
                                rpt.Show();
                            }
                        }

                    }
                    DialogHost.CloseDialogCommand.Execute(null, null);
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
            {
                MessageBox.Show(validation.Message);
            }
        }

        private void Code_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Code_CmBox.SelectedItem != null)
            {
                if (int.TryParse(Code_CmBox.SelectedItem.ToString(), out int code))
                {
                    var result = Barbari_BLL.Ranande.Select_Code(code);
                    if (result.Success)
                    {
                        FirstName_Txt.Text = result.Data[0].RanandeFirstName;
                        LastName_Txt.Text = result.Data[0].RanandeLastName;
                        Mobile_Txt.Text = result.Data[0].RanandeMobile;
                        //FirstName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                        //LastName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                        //Mobile_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                    }
                    else
                    {
                        FirstName_Txt.Text = "";
                        LastName_Txt.Text = "";
                        Mobile_Txt.Text = "";
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show("کد راننده باید عددی باشد");
                    FirstName_Txt.Text = "";
                    LastName_Txt.Text = "";
                    Mobile_Txt.Text = "";
                }
            }
        }

        private void Code_CmBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (int.TryParse(Code_CmBox.Text, out int code))
                {
                    var result = Barbari_BLL.Ranande.Select_Code(code);
                    if (result.Success)
                    {
                        FirstName_Txt.Text = result.Data[0].RanandeFirstName;
                        LastName_Txt.Text = result.Data[0].RanandeLastName;
                        Mobile_Txt.Text = result.Data[0].RanandeMobile;
                        FirstName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                        LastName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                        Mobile_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                    }
                    else
                    {
                        FirstName_Txt.Text = "";
                        LastName_Txt.Text = "";
                        Mobile_Txt.Text = "";
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show("کد مشتری باید عددی باشد");
                    FirstName_Txt.Text = "";
                    LastName_Txt.Text = "";
                    Mobile_Txt.Text = "";
                }
            }
        }

        private void Mobile_Txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PrintToggle_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void PrintToggle_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
