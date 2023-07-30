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
        RegisterStep1 step1;
        RegisterStep2 step2;
        RegisterStep3 step3;
        byte step = 1;
        bool createStep1= false;
        bool createStep2= false;
        bool createStep3= false;
        bool validateTextBoxes(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Text == textBox.Tag.ToString())
                {
                    return false;
                }
            }
            return true;
        }
        bool validateCmBoxes(params ComboBox[] CmBoxs)
        {
            foreach (ComboBox comboBox in CmBoxs)
            {
                if (comboBox.Text == comboBox.Tag.ToString())
                {
                    return false;
                }
            }
            return true;
        }
        bool validateToggleCm(bool IsChecked,params ComboBox[] cmBoxs)
        {
            if (IsChecked)
            {
                foreach (ComboBox comboBox in cmBoxs)
                {
                    if(comboBox.Text == comboBox.Tag.ToString())
                    {
                        return false;
                    }
                }
                return true;
            }
                return true;

        }
        bool Validait()
        {
            if(step == 1)
            {
                if (validateTextBoxes(step1.FirstName_Txt, step1.LastName_Txt, step1.Mobile_Txt) && validateCmBoxes(step1.CityMabda_CmBox, step1.AnbarMabda_CmBox) 
                    && validateToggleCm((bool)step1.BimariToggle.IsChecked,step1.Code_CmBox))
                {

                    int.TryParse(step1.Code_CmBox.Text, out int code);
                    var validaition = Barbari_BLL.Validation.BarErsali_Validation_EtelatFerestande(step1.CityMabda_CmBox.Text, step1.AnbarMabda_CmBox.Text,
                        step1.FirstName_Txt.Text, step1.LastName_Txt.Text,
                        step1.Mobile_Txt.Text, code,
                        (bool)step1.BimariToggle.IsChecked);
                    if (validaition.Success)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(validaition.Message);
                    }
                }
                else
                {
                    MessageBox.Show("فیلد های ضروری باید پر شوند");
                }
            }
            else if(step == 2)
            {
                if (validateTextBoxes(step2.FirstName_Txt, step2.LastName_Txt, step2.Mobile_Txt) && validateCmBoxes(step2.CityMaghsad_CmBox, step2.AnbarMaghsad_CmBox) 
                    && validateToggleCm((bool)step2.AddSecondMaghsadToggle.IsChecked, step2.CityMaghsadFinal_CmBox, step2.AnbarMaghsadFinal_CmBox))
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
                    }
                    
                }
                else
                {
                    MessageBox.Show("فیلد های ضروری باید پر شوند");
                }
            }
            else if (step == 3)
            {
                if (decimal.TryParse(step3.PishKeraye_Txt.Text, out decimal pishKerayeh) &&
                    decimal.TryParse(step3.PishKeraye_Txt.Text, out decimal pasKerayeh)
                    && decimal.TryParse(step3.PishKeraye_Txt.Text, out decimal bimeh)
                    && decimal.TryParse(step3.PishKeraye_Txt.Text, out decimal anbarDari)
                    && decimal.TryParse(step3.PishKeraye_Txt.Text, out decimal shahri)
                    && decimal.TryParse(step3.PishKeraye_Txt.Text, out decimal basteBandi))
                {
                    var validaition = Barbari_BLL.Validation.BarErsali_Validation_EtelatBar(pishKerayeh, pasKerayeh, bimeh, anbarDari, shahri, basteBandi);
                    if (validaition.Success)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(validaition.Message);
                    }
                }
            }
            return false;
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
                        BarErsaliNamGerande= step2.FirstName_Txt.Text,
                        BarErsaliFamilyGerande= step2.LastName_Txt.Text,
                        BarErsaliMobileGerande= step2.Mobile_Txt.Text,
                        
                    };
                    if ((bool)step1.BimariToggle.IsChecked)
                    {
                        if(int.TryParse(step1.Code_CmBox.Text,out int code))
                        barErsali.BarErsaliCodeFerestande = code;
                    }
                    if ((bool)step2.AddSecondMaghsadToggle.IsChecked)
                    {
                        barErsali.BarErsaliAnbarMaghsad2 = step2.AnbarMaghsadFinal_CmBox.Text;
                        barErsali.BarErsaliShahreMaghsad2 = step2.CityMaghsadFinal_CmBox.Text;
                    }
                    List<KalaDaryafti_Tbl> kalas = step3.GetKalas();
                    var result = Barbari_BLL.BarErsali.Insert(barErsali,kalas,(bool)step1.BimariToggle.IsChecked,(bool)step2.AddSecondMaghsadToggle.IsChecked);
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
                step1 = new RegisterStep1() { Height = 376 ,Width = 622, VerticalAlignment = VerticalAlignment.Top };
                ShowStep_Grid.Children.Add(step1);
            }
            else
            {
                step1.Visibility= Visibility.Visible;
                if(createStep2)
                {
                    step2.Visibility = Visibility.Hidden;
                }
                if(createStep3)
                {
                    step3.Visibility = Visibility.Hidden;
                }
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
                step2 = new RegisterStep2() { Height = 376 ,Width = 622 ,VerticalAlignment = VerticalAlignment.Top};
                ShowStep_Grid.Children.Add(step2);
                step1.Visibility = Visibility.Hidden;
            }
            else
            {
                step1.Visibility = Visibility.Hidden;
                step2.Visibility = Visibility.Visible;
                if(createStep3)
                {
                    step3.Visibility = Visibility.Hidden;
                }
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
                step3 = new RegisterStep3();
                ShowStep_Grid.Children.Add(step3);
                step1.Visibility = Visibility.Hidden;
                step2.Visibility = Visibility.Hidden;
            }
            else
            {
                step1.Visibility = Visibility.Hidden;
                step2.Visibility = Visibility.Hidden;
                step3.Visibility = Visibility.Visible;
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
