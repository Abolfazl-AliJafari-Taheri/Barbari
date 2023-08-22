using Barbari_DAL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Barbari_UI.Register_Bar_Ersali
{
    /// <summary>
    /// Interaction logic for Register_Form.xaml
    /// </summary>
    public partial class Register_Form : UserControl
    {
        public Register_Form()
        {
            InitializeComponent();
        }
        public RegisterStep1 step1;
        public RegisterStep2 step2;
        public RegisterStep3 step3;
        byte step = 1;
        bool createStep1= false;
        bool createStep2= false;
        bool createStep3= false;
        public  bool inserted = false;
        bool Validait()
        {
            if (step == 1)
            {
                var validaition = Barbari_BLL.Validation.BarErsali_Validation_EtelatFerestande(step1.CityMabda_CmBox.Text, step1.AnbarMabda_CmBox.Text,
                    step1.FirstName_Txt.Text, step1.LastName_Txt.Text,
                    step1.Mobile_Txt.Text, step1.Code_CmBox.Text,
                    (bool)step1.BimariToggle.IsChecked);
                if (validaition.Success)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(validaition.Message);
                    return false;
                }
            }
            else if (step == 2)
            {
                var validaition = Barbari_BLL.Validation.BarErsali_Validation_EtelatGerande(step2.CityMaghsad_CmBox.Text, step2.AnbarMaghsad_CmBox.Text,
                    step2.FirstName_Txt.Text, step2.LastName_Txt.Text, step2.Mobile_Txt.Text,
                    step2.CityMaghsadFinal_CmBox.Text, step2.AnbarMaghsadFinal_CmBox.Text,
                    (bool)step2.AddSecondMaghsadToggle.IsChecked);
                if (validaition.Success)
                {
                    return true;
                }
                else
                {

                    MessageBox.Show(validaition.Message);
                    return false;
                }
            }
            else if (step == 3)
            {
                var validaition = Barbari_BLL.Validation.BarErsali_Validation_EtelatBar(step3.PishKeraye_Txt.Text, step3.PasKeraye_Txt.Text,
                    step3.Bime_Txt.Text, step3.AnbarDari_Txt.Text,
                    step3.Shahri_Txt.Text, step3.BasteBandi_Txt.Text);
                if (validaition.Success)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(validaition.Message);
                    return false;
                }
            }
            return true;
        }
        private void NextStep_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(Validait())
            {
                if (step + 1 <= 4 && step + 1 >= 0)
                {
                    step++;
                }
                if (step == 1)
                {
                    ShowStep1();
                }
                else if (step == 2)
                {
                    ShowStep2();
                }
                else if (step == 3)
                {
                    ShowStep3();
                }
                else
                {
                    BarErsali_Tbl barErsali = new BarErsali_Tbl()
                    {
                        BarErsaliShahreMabda = step1.CityMabda_CmBox.Text,
                        BarErsaliAnbarMabda = step1.AnbarMabda_CmBox.Text,
                        BarErsaliNamFerestande = step1.FirstName_Txt.Text,
                        BarErsaliFamilyFerestande = step1.LastName_Txt.Text,
                        BarErsaliMobileFerestande = step1.Mobile_Txt.Text,
                        BarErsaliShahreMaghsad1 = step2.CityMaghsad_CmBox.Text,
                        BarErsaliAnbarMaghsad1 = step2.AnbarMaghsad_CmBox.Text,
                        BarErsaliNamGerande = step2.FirstName_Txt.Text,
                        BarErsaliFamilyGerande = step2.LastName_Txt.Text,
                        BarErsaliMobileGerande = step2.Mobile_Txt.Text,
                        BarErsaliAnbardari = decimal.Parse(step3.AnbarDari_Txt.Text),
                        BarErsaliBastebandi = decimal.Parse(step3.BasteBandi_Txt.Text),
                        BarErsaliShahri = decimal.Parse(step3.Shahri_Txt.Text),
                        BarErsaliBime = decimal.Parse(step3.Bime_Txt.Text),
                        BarErsaliPishKeraye = decimal.Parse(step3.PishKeraye_Txt.Text),
                        BarErsaliPasKeraye = decimal.Parse(step3.PasKeraye_Txt.Text),
                        BarErsaliSaat = step3.HourSodor_TmPicker.Text,
                        BarErsaliTarikh = step3.DateSodor_DtPicker.Text,
                        BarErsaliUserNameKarmand = WindowsAndPages.home_Window.User.UsersUserName,
                        
                    };
                    if ((bool)step1.BimariToggle.IsChecked)
                    {
                        int.TryParse(step1.Code_CmBox.Text, out int code);
                        barErsali.BarErsaliCodeFerestande = code;
                    }
                    if ((bool)step2.AddSecondMaghsadToggle.IsChecked)
                    {
                        barErsali.BarErsaliAnbarMaghsad2 = step2.AnbarMaghsadFinal_CmBox.Text;
                        barErsali.BarErsaliShahreMaghsad2 = step2.CityMaghsadFinal_CmBox.Text;
                    }
                    
                    List<KalaDaryafti_Tbl> kalas = step3.GetKalas();
                    if(kalas.Count == 0)
                    {
                        MessageBox.Show("حداقل یک کالا اضافه کنید");
                    }
                    else
                    {
                        var result = Barbari_BLL.BarErsali.Insert(barErsali, kalas, (bool)step1.BimariToggle.IsChecked, (bool)step2.AddSecondMaghsadToggle.IsChecked);
                        if(result.Success)
                        {
                            if ((bool)step3.PrintToggle.IsChecked)
                            {
                                var query1 = Barbari_BLL.Company.Select();
                                var query2 = Barbari_BLL.BarErsali.Select_KalaDaryafti(int.Parse(step3.CodeBarname_Txt.Text));
                                if (query1.Success == true && query2.Success == true)
                                {
                                    if ((bool)step2.AddSecondMaghsadToggle.IsChecked)
                                    {
                                        var rpt = StiReportHelper.GetReport("ReportBarnameRanande.mrt");
                                        string logopath = System.IO.Path.Combine(query1.Data.CompanyIogo);
                                        var uri = new Uri(logopath);
                                        var bitmap = new BitmapImage(uri);
                                        rpt.Dictionary.Variables["logo"].ValueObject = bitmap;
                                        rpt.Dictionary.Variables["NamSherkat"].Value = query1.Data.CompanyName;
                                        rpt.Dictionary.Variables["TelephoneSherkat"].Value = query1.Data.CompanyTelephon;
                                        rpt.Dictionary.Variables["TarikhSodor"].Value = step3.DateSodor_DtPicker.Text;
                                        rpt.Dictionary.Variables["ShomareBarname"].Value = step3.CodeBarname_Txt.Text;
                                        rpt.Dictionary.Variables["NamAndFamilyFerestande"].Value = step1.FirstName_Txt.Text + " " + step1.LastName_Txt.Text;
                                        rpt.Dictionary.Variables["ShomareFerestande"].Value = step1.Mobile_Txt.Text;
                                        rpt.Dictionary.Variables["ShahrMabda"].Value = step1.CityMabda_CmBox.Text;
                                        rpt.Dictionary.Variables["AnbarMabda"].Value = step1.AnbarMabda_CmBox.Text;
                                        rpt.Dictionary.Variables["NamAndFamilyGerande"].Value = step2.FirstName_Txt.Text + " " + step2.LastName_Txt.Text;
                                        rpt.Dictionary.Variables["ShomareGerande"].Value = step2.Mobile_Txt.Text;
                                        rpt.Dictionary.Variables["ShahrMaghsad"].Value = step2.CityMaghsad_CmBox.Text;
                                        rpt.Dictionary.Variables["AnbarMaghsad"].Value = step2.AnbarMaghsad_CmBox.Text;
                                        rpt.Dictionary.Variables["Bime"].Value = step3.Bime_Txt.Text;
                                        rpt.Dictionary.Variables["Anbardari"].Value = step3.AnbarDari_Txt.Text;
                                        rpt.Dictionary.Variables["Shahri"].Value = step3.Shahri_Txt.Text;
                                        rpt.Dictionary.Variables["BasteBandi"].Value = step3.BasteBandi_Txt.Text;
                                        rpt.Dictionary.Variables["PishKeraye"].Value = step3.PishKeraye_Txt.Text;
                                        rpt.Dictionary.Variables["PasKeraye"].Value = step3.PasKeraye_Txt.Text;
                                        int jam = int.Parse(step3.Bime_Txt.Text) + int.Parse(step3.AnbarDari_Txt.Text) + int.Parse(step3.Shahri_Txt.Text)
                                            + int.Parse(step3.BasteBandi_Txt.Text) + int.Parse(step3.PishKeraye_Txt.Text) + int.Parse(step3.PasKeraye_Txt.Text);
                                        rpt.Dictionary.Variables["JamEtelatBar"].Value = jam.ToString();
                                        rpt.Dictionary.Variables["Tozihat"].Value = query1.Data.CompanyRules;
                                        rpt.Dictionary.Variables["ShahrMaghsadNahayi"].Value = step2.CityMaghsadFinal_CmBox.Text;
                                        rpt.Dictionary.Variables["AnbarMaghsadNahayi"].Value = step2.AnbarMaghsadFinal_CmBox.Text;
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
                                        rpt.Dictionary.Variables["NamSherkat"].Value = query1.Data.CompanyName;
                                        rpt.Dictionary.Variables["TelephoneSherkat"].Value = query1.Data.CompanyTelephon;
                                        rpt.Dictionary.Variables["TarikhSodor"].Value = step3.DateSodor_DtPicker.Text;
                                        rpt.Dictionary.Variables["ShomareBarname"].Value = step3.CodeBarname_Txt.Text;
                                        rpt.Dictionary.Variables["NamAndFamilyFerestande"].Value = step1.FirstName_Txt.Text + " " + step1.LastName_Txt.Text;
                                        rpt.Dictionary.Variables["ShomareFerestande"].Value = step1.Mobile_Txt.Text;
                                        rpt.Dictionary.Variables["ShahrMabda"].Value = step1.CityMabda_CmBox.Text;
                                        rpt.Dictionary.Variables["AnbarMabda"].Value = step1.AnbarMabda_CmBox.Text;
                                        rpt.Dictionary.Variables["NamAndFamilyGerande"].Value = step2.FirstName_Txt.Text + " " + step2.LastName_Txt.Text;
                                        rpt.Dictionary.Variables["ShomareGerande"].Value = step2.Mobile_Txt.Text;
                                        rpt.Dictionary.Variables["ShahrMaghsad"].Value = step2.CityMaghsad_CmBox.Text;
                                        rpt.Dictionary.Variables["AnbarMaghsad"].Value = step2.AnbarMaghsad_CmBox.Text;
                                        rpt.Dictionary.Variables["Bime"].Value = step3.Bime_Txt.Text;
                                        rpt.Dictionary.Variables["Anbardari"].Value = step3.AnbarDari_Txt.Text;
                                        rpt.Dictionary.Variables["Shahri"].Value = step3.Shahri_Txt.Text;
                                        rpt.Dictionary.Variables["BasteBandi"].Value = step3.BasteBandi_Txt.Text;
                                        rpt.Dictionary.Variables["PishKeraye"].Value = step3.PishKeraye_Txt.Text;
                                        rpt.Dictionary.Variables["PasKeraye"].Value = step3.PasKeraye_Txt.Text;
                                        int jam = int.Parse(step3.Bime_Txt.Text) + int.Parse(step3.AnbarDari_Txt.Text) + int.Parse(step3.Shahri_Txt.Text)
                                            + int.Parse(step3.BasteBandi_Txt.Text) + int.Parse(step3.PishKeraye_Txt.Text) + int.Parse(step3.PasKeraye_Txt.Text);
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
                            inserted = true;
                            step1.Registered();
                            step2.Registered();
                            step3.Registered();
                            step = 0;
                            NextStep_Btn_Click(null,null);
                        }
                        else
                        {
                            MessageBox.Show(result.Message);
                        }
                    }
                }
            }
           
        }
        
        Brush ConverterColor(string ColorCode)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(ColorCode));
        }
        void ShowStep1()
        {
            if (!createStep1)
            {
                createStep1 = true;
                step1 = new RegisterStep1() { Height = 376 ,Width = 622};
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step1);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step1);
            }
            Step1_Toggle.Background = ConverterColor("#2B54A3");
            Step2_Toggle.Background = ConverterColor("#BFBFBF");
            Step3_Toggle.Background = ConverterColor("#BFBFBF");
            Step1_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step2_TxtBlock.Foreground = ConverterColor("#BFBFBF");
            Step3_TxtBlock.Foreground = ConverterColor("#BFBFBF");
            Step1_Toggle.IsChecked = false;
            Step2_Toggle.IsChecked = false;
            Step3_Toggle.IsChecked = false;
        }
        void ShowStep2()
        {
            if (!createStep2)
            {
                createStep2 = true;
                step2 = new RegisterStep2() { Height = 376 ,Width = 622 };
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step2);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step2);
            }
            Step1_Toggle.Background = ConverterColor("#2B54A3");
            Step2_Toggle.Background = ConverterColor("#2B54A3");
            Step3_Toggle.Background = ConverterColor("#BFBFBF");
            Step1_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step2_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step3_TxtBlock.Foreground = ConverterColor("#BFBFBF");
            NextStep_Btn.Content = "بعدی";
            Step1_Toggle.IsChecked = true;
            Step2_Toggle.IsChecked = false;
            Step3_Toggle.IsChecked = false;
        }
        void ShowStep3()
        {
            if (!createStep3)
            {
                createStep3 = true;
                step3 = new RegisterStep3() { Height = 854, Width = 622 };
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step3);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step3);
            }
            NextStep_Btn.Content = "صدور";
            Step1_Toggle.Background = ConverterColor("#2B54A3");
            Step2_Toggle.Background = ConverterColor("#2B54A3");
            Step3_Toggle.Background = ConverterColor("#2B54A3");
            Step1_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step2_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step3_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step1_Toggle.IsChecked = true;
            Step2_Toggle.IsChecked = true;
            Step3_Toggle.IsChecked = false;

        }
        private void PerviuosStep_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (step - 1 <= 3 && step - 1 >= 1)
            {
                step--;
            }
            if (step == 1)
            {
                ShowStep1();
            }
            else if (step == 2)
            {
                ShowStep2();
            }
            else
            {
                ShowStep3();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ShowStep1();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Step3_Toggle_Click(object sender, RoutedEventArgs e)
        {
            bool? check = !Step3_Toggle.IsChecked;
            Step3_Toggle.IsChecked = check;

        }

        private void Step2_Toggle_Click(object sender, RoutedEventArgs e)
        {
            bool? check = !Step2_Toggle.IsChecked;
            Step2_Toggle.IsChecked = check;

        }

        private void Step1_Toggle_Click(object sender, RoutedEventArgs e)
        {
            bool? check = !Step1_Toggle.IsChecked;
            Step1_Toggle.IsChecked = check;
        }
    }
}
