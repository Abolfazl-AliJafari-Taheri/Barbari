using Barbari_DAL;
using Barbari_UI.Register_Bar_Ersali;
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

namespace Barbari_UI.Register_Bar_Tahvili
{
    /// <summary>
    /// Interaction logic for RegisterForm_BarTahvili.xaml
    /// </summary>
    public partial class RegisterForm_BarTahvili : UserControl
    {
        public RegisterForm_BarTahvili()
        {
            InitializeComponent();
        }
        private void Step3_Toggle_Click(object sender, RoutedEventArgs e)
        {
            bool? check = !Step3_Toggle.IsChecked;
            Step3_Toggle.IsChecked = check;

        }
        public RegisterStep1_BarTahvili step1;
        public RegisterStep2_BarTahvili step2;
        public RegisterStep3_BarTahvili step3;
        public RegisterStep4_BarTahvili step4;
        byte step = 1;
        bool createStep1 = false;
        bool createStep2 = false;
        bool createStep3 = false;
        bool createStep4 = false;
        public bool inserted = false;
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

        private void Step4_Toggle_Click(object sender, RoutedEventArgs e)
        {
            bool? check = !Step4_Toggle.IsChecked;
            Step4_Toggle.IsChecked = check;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ShowStep1();
        }

        private void PerviuosStep_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (step - 1 <= 4 && step - 1 >= 1)
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
        bool Validait()
        {
            if (step == 1)
            {
                var validaition = Barbari_BLL.Validation.BarTahvili_Validation_EtelatFerestande(step1.CityMabda_CmBox.Text,step1.FirstName_Txt.Text ,
                    step1.LastName_Txt.Text, step1.Mobile_Txt.Text);
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
                var validaition = Barbari_BLL.Validation.BarTahvili_Validation_EtelatGerande(step2.CityMaghsad_CmBox.Text,
                    step2.FirstName_Txt.Text, step2.LastName_Txt.Text, step2.Mobile_Txt.Text);
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
                var validaition = Barbari_BLL.Validation.BarTahvili_Validation_EtelatRanande(step3.FirstName_Txt.Text, step3.LastName_Txt.Text,step3.Mobile_Txt.Text,step3.Code_CmBox.Text);
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
            else if (step == 4)
            {
                var validaition = Barbari_BLL.Validation.barTahvili_Validation_EtelatBar(step4.CodeBarname_Txt.Text,step4.PishKeraye_Txt.Text, step4.PasKeraye_Txt.Text,
                    step4.Bime_Txt.Text, step4.AnbarDari_Txt.Text,
                    step4.Shahri_Txt.Text, step4.BasteBandi_Txt.Text ,
                    step4.DateSodor_DtPicker.Text);
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
            if (Validait())
            {
                if (step + 1 <= 5 && step + 1 >= 0)
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
                else if (step == 4)
                {
                    ShowStep4();
                }
                else
                {
                    BarTahvili_Tbl barTahvili = new BarTahvili_Tbl()
                    {
                        
                        BarTahviliShahrFerestande = step1.CityMabda_CmBox.Text,
                        BarTahviliNamFerestande = step1.FirstName_Txt.Text,
                        BarTahviliFamilyFerestande = step1.LastName_Txt.Text,
                        BarTahviliMobileFerestande = step1.Mobile_Txt.Text,
                        BarTahviliShahrGerande = step2.CityMaghsad_CmBox.Text,
                        BarTahviliNamGerande = step2.FirstName_Txt.Text,
                        BarTahviliFamilyGerande = step2.LastName_Txt.Text,
                        BarTahviliMobileGerande = step2.Mobile_Txt.Text,
                        BarTahviliNamRanande= step3.FirstName_Txt.Text,
                        BarTahviliFamilyRanande= step3.LastName_Txt.Text,
                        BarTahviliMobileRanande= step3.Mobile_Txt.Text,
                        BarTahviliAnbardari = decimal.Parse(step4.AnbarDari_Txt.Text),
                        BarTahviliBastebandi = decimal.Parse(step4.BasteBandi_Txt.Text),
                        BarTahviliShahri = decimal.Parse(step4.Shahri_Txt.Text),
                        BarTahviliBime = decimal.Parse(step4.Bime_Txt.Text),
                        BarTahviliPishKeraye = decimal.Parse(step4.PishKeraye_Txt.Text),
                        BarTahviliPasKeraye = decimal.Parse(step4.PasKeraye_Txt.Text),
                        BarTahviliBarname = step4.CodeBarname_Txt.Text,
                        BarTahviliiSaat = step4.HourSodor_TmPicker.Text,
                        BarTahviliTarikh = step4.DateSodor_DtPicker.Text,
                        BarTahviliUserNameKarmand = WindowsAndPages.home_Window.User.UsersUserName,
                    };
                    if ((bool)step3.Registered_Ranande.IsChecked)
                    {
                        barTahvili.BarErsaliCodeRanande = int.Parse(step3.Code_CmBox.Text);
                    }
                    List<KalaTahvili_Tbl> kalas = step4.GetKalas();
                    if (kalas.Count == 0)
                    {
                        MessageBox.Show("حداقل یک کالا اضافه کنید");
                    }
                    else
                    {
                        var result = Barbari_BLL.BarTahvili.Insert(barTahvili, kalas);
                        if (result.Success)
                        {
                            inserted = true;
                            step1.Registered();
                            step2.Registered();
                            step3.Registered();
                            step4.Registered();
                            step = 0;
                            NextStep_Btn_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show(result.Message);
                        }
                    }
                }
            }
        }
        void ShowStep1()
        {
            if (!createStep1)
            {
                createStep1 = true;
                step1 = new RegisterStep1_BarTahvili() {Height= 256, Width = 622 };
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
            Step4_Toggle.Background = ConverterColor("#BFBFBF");
            Step1_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step2_TxtBlock.Foreground = ConverterColor("#BFBFBF");
            Step3_TxtBlock.Foreground = ConverterColor("#BFBFBF");
            Step4_TxtBlock.Foreground = ConverterColor("#BFBFBF");
            Step1_Toggle.IsChecked = false;
            Step2_Toggle.IsChecked = false;
            Step4_Toggle.IsChecked = false;
            Step3_Toggle.IsChecked = false;
        }
        void ShowStep2()
        {
            if (!createStep2)
            {
                createStep2 = true;
                step2 = new RegisterStep2_BarTahvili() { Height = 256, Width = 622 };
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
            Step4_Toggle.Background = ConverterColor("#BFBFBF");
            Step1_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step2_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step3_TxtBlock.Foreground = ConverterColor("#BFBFBF");
            Step4_TxtBlock.Foreground = ConverterColor("#BFBFBF");
            NextStep_Btn.Content = "بعدی";
            Step1_Toggle.IsChecked = true;
            Step2_Toggle.IsChecked = false;
            Step4_Toggle.IsChecked = false;
            Step3_Toggle.IsChecked = false;
        }
        void ShowStep3()
        {
            if (!createStep3)
            {
                createStep3 = true;
                step3 = new RegisterStep3_BarTahvili() {  Width = 622 };
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step3);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step3);
            }
            Step1_Toggle.Background = ConverterColor("#2B54A3");
            Step2_Toggle.Background = ConverterColor("#2B54A3");
            Step3_Toggle.Background = ConverterColor("#2B54A3");
            Step4_Toggle.Background = ConverterColor("#BFBFBF");
            Step1_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step2_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step3_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step4_TxtBlock.Foreground = ConverterColor("#BFBFBF");
            NextStep_Btn.Content = "بعدی"; 
            Step1_Toggle.IsChecked = true;
            Step2_Toggle.IsChecked = true;
            Step3_Toggle.IsChecked = false;
            Step4_Toggle.IsChecked = false;

        }
        void ShowStep4()
        {
            if (!createStep4)
            {
                createStep4 = true;
                step4 = new RegisterStep4_BarTahvili() {Width = 622 };
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step4);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step4);
            }
            Step1_Toggle.Background = ConverterColor("#2B54A3");
            Step2_Toggle.Background = ConverterColor("#2B54A3");
            Step3_Toggle.Background = ConverterColor("#2B54A3");
            Step4_Toggle.Background = ConverterColor("#2B54A3");
            Step1_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step2_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step3_TxtBlock.Foreground = ConverterColor("#2B54A3");
            Step4_TxtBlock.Foreground = ConverterColor("#2B54A3");
            NextStep_Btn.Content = "صدور";
            Step1_Toggle.IsChecked = true;
            Step2_Toggle.IsChecked = true;
            Step3_Toggle.IsChecked = true;
            Step4_Toggle.IsChecked = false;

        }
        Brush ConverterColor(string ColorCode)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(ColorCode));
        }
    }
}
