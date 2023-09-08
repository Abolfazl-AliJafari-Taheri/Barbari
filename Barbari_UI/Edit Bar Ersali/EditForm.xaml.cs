using Barbari_DAL;
using Barbari_UI.Register_Bar_Ersali;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Barbari_UI.Edit_Bar_Ersali
{
    /// <summary>
    /// Interaction logic for EditForm.xaml
    /// </summary>
    public partial class EditForm : UserControl
    {
        public EditForm(BarErsali_Tbl barErsali)
        {
            InitializeComponent();
            BarErsali = barErsali;
        }
        public BarErsali_Tbl BarErsali { get; set; }
        public RegisterStep1 step1;
        public RegisterStep2 step2;
        public RegisterStep3 step3;
        public TahvilRanande tahvilRanande;
        bool createStep1= false;
        bool createStep2= false;
        bool createStep3= false;
        bool createTahvil= false;
        void SelectSenderInfo()
        {
            SenderInfo_Border.Background = ConverterColor("#D5DDED");
            SenderInfo_Btn.Foreground = ConverterColor("#2B54A3");
            if(createStep1)
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step1);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                step1 = new RegisterStep1(BarErsali) { Width = 622 };
                createStep1= true;
                ShowStep_Grid.Children.Add(step1);
            }
        }
        void UnSelectSenderInfo()
        {
            SenderInfo_Border.Background = ConverterColor("#FFFFFF");
            SenderInfo_Btn.Foreground = ConverterColor("#404040");
        }
        void SelectRecieverInfo()
        {
            RecieverInfo_Border.Background = ConverterColor("#D5DDED");
            RecieverInfo_Btn.Foreground = ConverterColor("#2B54A3");
            if (createStep2)
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step2);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                step2 = new RegisterStep2(BarErsali) { Width = 622 };
                createStep2 = true;
                ShowStep_Grid.Children.Add(step2);
            }
        }
        void UnSelectRecieverInfo()
        {
            RecieverInfo_Border.Background = ConverterColor("#FFFFFF");
            RecieverInfo_Btn.Foreground = ConverterColor("#404040");
        }
        void SelectBarInfo()
        {
            BarInfo_Border.Background = ConverterColor("#D5DDED");
            BarInfo_Btn.Foreground = ConverterColor("#2B54A3");
            if (createStep3)
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step3);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                step3 = new RegisterStep3(BarErsali) { Width = 622};
                createStep3 = true;
                ShowStep_Grid.Children.Add(step3);
            }
        }
        void UnSelectBarInfo()
        {
            BarInfo_Border.Background = ConverterColor("#FFFFFF");
            BarInfo_Btn.Foreground = ConverterColor("#404040");
        }
        void SelectRanandeInfo()
        {
            RanandeInfo_Border.Background = ConverterColor("#D5DDED");
            RanandeInfo_Btn.Foreground = ConverterColor("#2B54A3");
            if (createTahvil)
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(tahvilRanande);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                tahvilRanande = new TahvilRanande(BarErsali, true) {Height = 344, Width = 622/*, VerticalAlignment = VerticalAlignment.Top*/};
                tahvilRanande.Field_Grid.RowDefinitions[0].Height = GridLength.Auto;
                createTahvil = true;
                ShowStep_Grid.Children.Add(tahvilRanande);
            }
        }
        void UnSelectRanandeInfo()
        {
            RanandeInfo_Border.Background = ConverterColor("#FFFFFF");
            RanandeInfo_Btn.Foreground = ConverterColor("#404040");
        }
        Brush ConverterColor(string ColorCode)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(ColorCode));
        }
        private void BarInfo_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnSelectSenderInfo();
            UnSelectRecieverInfo();
            SelectBarInfo();
            UnSelectRanandeInfo();
        }

        private void RecieverInfo_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnSelectSenderInfo();
            SelectRecieverInfo();
            UnSelectBarInfo();
            UnSelectRanandeInfo();
        }

        private void SenderInfo_Btn_Click(object sender, RoutedEventArgs e)
        {
            SelectSenderInfo();
            UnSelectRecieverInfo();
            UnSelectBarInfo();
            UnSelectRanandeInfo();
        }

        private void RanandeInfo_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnSelectSenderInfo();
            UnSelectRecieverInfo();
            UnSelectBarInfo();
            SelectRanandeInfo();
        }
        bool Validation ()
        {
            if (createStep1)
            {
                var validation_Ferestandeh = Barbari_BLL.Validation.BarErsali_Validation_EtelatFerestande(step1.CityMabda_CmBox.Text, step1.AnbarMabda_CmBox.Text, step1.FirstName_Txt.Text,
   step1.LastName_Txt.Text, step1.Mobile_Txt.Text, step1.Code_CmBox.Text, (bool)step1.BimariToggle.IsChecked);
                if (!validation_Ferestandeh.Success)
                {
                    MessageBox.Show(validation_Ferestandeh.Message);
                    return false;
                }
            }
            if (createStep2)
            {
                var validaition_Girande = Barbari_BLL.Validation.BarErsali_Validation_EtelatGerande(step2.CityMaghsad_CmBox.Text, step2.AnbarMaghsad_CmBox.Text,
                   step2.FirstName_Txt.Text, step2.LastName_Txt.Text, step2.Mobile_Txt.Text,
                   step2.CityMaghsadFinal_CmBox.Text, step2.AnbarMaghsadFinal_CmBox.Text,
                   (bool)step2.AddSecondMaghsadToggle.IsChecked);
                if (!validaition_Girande.Success)
                {
                    MessageBox.Show(validaition_Girande.Message);
                    return false;
                }
            }
            if (createStep3)
            {
                var validaition_Bar = Barbari_BLL.Validation.BarErsali_Validation_EtelatBar(step3.PishKeraye_Txt.Text, step3.PasKeraye_Txt.Text,
    step3.Bime_Txt.Text, step3.AnbarDari_Txt.Text,
    step3.Shahri_Txt.Text, step3.BasteBandi_Txt.Text);
                if (!validaition_Bar.Success)
                {
                    MessageBox.Show(validaition_Bar.Message);
                    return false;
                }
            }
            if (createTahvil)
            {
                var validaition_Tahvil = Barbari_BLL.Validation.BarErsali_Validation_TahvilRanande(tahvilRanande.FirstName_Txt.Text,tahvilRanande.LastName_Txt.Text
                    ,tahvilRanande.Mobile_Txt.Text,tahvilRanande.Price_Txt.Text,tahvilRanande.Code_CmBox.Text);
                if (!validaition_Tahvil.Success)
                {
                    MessageBox.Show(validaition_Tahvil.Message);
                    return false;
                }
            }
            return true;
        }
        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            bool CustomerReg  =false;
            bool MaghsadFinal = false;
            if (Validation())
            {


                if (createStep1)
                {
                    BarErsali.BarErsaliShahreMabda = step1.CityMabda_CmBox.Text;
                    BarErsali.BarErsaliAnbarMabda = step1.AnbarMabda_CmBox.Text;
                    BarErsali.BarErsaliNamFerestande = step1.FirstName_Txt.Text;
                    BarErsali.BarErsaliFamilyFerestande = step1.LastName_Txt.Text;
                    BarErsali.BarErsaliMobileFerestande = step1.Mobile_Txt.Text;
                    if ((bool)step1.BimariToggle.IsChecked)
                    {
                        int.TryParse(step1.Code_CmBox.Text, out int code);
                        BarErsali.BarErsaliCodeFerestande = code;

                    }
                    CustomerReg = (bool)step1.BimariToggle.IsChecked;

                }
                if (createStep2)
                {
                    BarErsali.BarErsaliShahreMaghsad1 = step2.CityMaghsad_CmBox.Text;
                    BarErsali.BarErsaliAnbarMaghsad1 = step2.AnbarMaghsad_CmBox.Text;
                    BarErsali.BarErsaliNamGerande = step2.FirstName_Txt.Text;
                    BarErsali.BarErsaliFamilyGerande = step2.LastName_Txt.Text;
                    BarErsali.BarErsaliMobileGerande = step2.Mobile_Txt.Text;
                    if ((bool)step2.AddSecondMaghsadToggle.IsChecked)
                    {
                        BarErsali.BarErsaliAnbarMaghsad2 = step2.AnbarMaghsadFinal_CmBox.Text;
                        BarErsali.BarErsaliShahreMaghsad2 = step2.CityMaghsadFinal_CmBox.Text;
                    }
                    MaghsadFinal = (bool)step2.AddSecondMaghsadToggle.IsChecked;
                }
                if (createStep3)
                {

                    BarErsali.BarErsaliAnbardari = decimal.Parse(step3.AnbarDari_Txt.Text);
                    BarErsali.BarErsaliBastebandi = decimal.Parse(step3.BasteBandi_Txt.Text);
                    BarErsali.BarErsaliShahri = decimal.Parse(step3.Shahri_Txt.Text);
                    BarErsali.BarErsaliBime = decimal.Parse(step3.Bime_Txt.Text);
                    BarErsali.BarErsaliPishKeraye = decimal.Parse(step3.PishKeraye_Txt.Text);
                    BarErsali.BarErsaliPasKeraye = decimal.Parse(step3.PasKeraye_Txt.Text);
                    BarErsali.BarErsaliSaat = step3.HourSodor_TmPicker.Text;
                    BarErsali.BarErsaliTarikh = step3.DateSodor_DtPicker.Text;
                }
                BarErsali.BarErsaliUserNameKarmand = WindowsAndPages.home_Window.User.UsersUserName;
                if (createTahvil)
                {
                    BarErsali.BarErsaliNamRanande = tahvilRanande.FirstName_Txt.Text;
                    BarErsali.BarErsaliFamilyRanande = tahvilRanande.LastName_Txt.Text;
                    BarErsali.BarErsaliMobileRanande = tahvilRanande.Mobile_Txt.Text;
                    BarErsali.BarErsaliKerayeRanande = int.Parse(tahvilRanande.Price_Txt.Text);
                    if ((bool)tahvilRanande.Registered_Ranande.IsChecked)
                    {
                        BarErsali.BarErsaliCodeRanande = int.Parse(tahvilRanande.Code_CmBox.Text);
                    }
                    else
                    {
                        BarErsali.BarErsaliCodeRanande = null;
                    }
                }

                var result = Barbari_BLL.BarErsali.Update(BarErsali, CustomerReg, MaghsadFinal, RanandeInfo_Btn.IsEnabled);
                if (result.Success)
                {
                    if ((bool)step3.PrintToggle.IsChecked)
                    {
                        var query1 = Barbari_BLL.Company.Select();
                        var query2 = Barbari_BLL.BarErsali.Select_KalaDaryafti(int.Parse(step3.CodeBarname_Txt.Text));
                        var query3 = Barbari_BLL.BarErsali.Select_Search(int.Parse(step3.CodeBarname_Txt.Text));
                        if (query1.Success == true && query2.Success == true && query3.Success == true)
                        {
                            if (!string.IsNullOrEmpty(query3.Data.BarErsaliShahreMaghsad2))
                            {
                                var rpt = StiReportHelper.GetReport("ReportBarnameRanande.mrt");
                                if (query1.Data.CompanyIogo != null)
                                {
                                    if (File.Exists(query1.Data.CompanyIogo))
                                    {
                                        var logo = File.ReadAllBytes(query1.Data.CompanyIogo);
                                        rpt.Dictionary.Variables["logo"].ValueObject = logo;
                                    }
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
                                    + (decimal)query3.Data.BarErsaliShahri + query3.Data.BarErsaliPishKeraye + query3.Data.BarErsaliPasKeraye;
                                rpt.Dictionary.Variables["JamEtelatBar"].Value = jam.ToString();
                                rpt.Dictionary.Variables["Tozihat"].Value = query1.Data.CompanyRules;
                                rpt.Dictionary.Variables["ShahrMaghsadNahayi"].Value = query3.Data.BarErsaliShahreMaghsad2;
                                rpt.Dictionary.Variables["AnbarMaghsadNahayi"].Value = query3.Data.BarErsaliAnbarMaghsad2;
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
                                    if (File.Exists(query1.Data.CompanyIogo))
                                    {
                                        var logo = File.ReadAllBytes(query1.Data.CompanyIogo);
                                        rpt.Dictionary.Variables["logo"].ValueObject = logo;
                                    }
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
                                    + (decimal)query3.Data.BarErsaliShahri + query3.Data.BarErsaliPishKeraye + query3.Data.BarErsaliPasKeraye;
                                rpt.Dictionary.Variables["JamEtelatBar"].Value = jam.ToString();
                                rpt.Dictionary.Variables["Tozihat"].Value = query1.Data.CompanyRules;
                                rpt.RegData("KalaDaryafti_Tbl", query2.Data.Select(p => new
                                {
                                    p.KalaDaryaftiNamKala,
                                    p.KalaDaryaftiTedadKala,
                                }));
                                rpt.Show();
                            }
                        }

                    }
                    if ((bool)tahvilRanande.PrintToggle.IsChecked)
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
                                    if (File.Exists(query1.Data.CompanyIogo))
                                    {
                                        var logo = File.ReadAllBytes(query1.Data.CompanyIogo);
                                        rpt.Dictionary.Variables["logo"].ValueObject = logo;
                                    }
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
                                rpt.Dictionary.Variables["Tozihat"].Value = query1.Data.CompanyRules;
                                rpt.Dictionary.Variables["ShahrMaghsadNahayi"].Value = query3.Data.BarErsaliShahreMaghsad2;
                                rpt.Dictionary.Variables["AnbarMaghsadNahayi"].Value = query3.Data.BarErsaliAnbarMaghsad2;
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
                            else
                            {
                                var rpt = StiReportHelper.GetReport("ReportBarname.mrt");
                                if (query1.Data.CompanyIogo != null)
                                {
                                    if (File.Exists(query1.Data.CompanyIogo))
                                    {
                                        var logo = File.ReadAllBytes(query1.Data.CompanyIogo);
                                        rpt.Dictionary.Variables["logo"].ValueObject = logo;
                                    }
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
                                rpt.Dictionary.Variables["Tozihat"].Value = query1.Data.CompanyRules;
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
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            if(WindowsAndPages.home_Window.Role != null)
            {
                Save_Btn.IsEnabled = WindowsAndPages.home_Window.Role.BarErsaliUpdate;
            }
            else
            {
                Save_Btn.IsEnabled = false;
            }
            if(!string.IsNullOrEmpty(BarErsali.BarErsaliNamRanande))
            {
                tahvilRanande = new TahvilRanande(BarErsali,true);
                tahvilRanande.Field_Grid.RowDefinitions[0].Height = GridLength.Auto;
                tahvilRanande.UserControl_Loaded(null, null);
                createTahvil = true;
                RanandeInfo_Btn.IsEnabled= true;
            }
            else
            {
                tahvilRanande = new TahvilRanande(BarErsali, false);
                RanandeInfo_Btn.IsEnabled = false;
            }
            
            step3 = new RegisterStep3(BarErsali);
            createStep3 = true;
            step3.UserControl_Loaded(null, null);
            SenderInfo_Btn_Click(null,null);
        }
    }
}
