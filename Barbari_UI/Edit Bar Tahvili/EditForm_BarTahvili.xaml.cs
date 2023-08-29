using Barbari_DAL;
using Barbari_UI.Register_Bar_Ersali;
using Barbari_UI.Register_Bar_Tahvili;
using MaterialDesignThemes.Wpf;
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

namespace Barbari_UI.Edit_Bar_Tahvili
{
    /// <summary>
    /// Interaction logic for EditForm_BarTahvili.xaml
    /// </summary>
    public partial class EditForm_BarTahvili : UserControl
    {
        public EditForm_BarTahvili()
        {
            InitializeComponent();
        }
        public EditForm_BarTahvili(BarTahvili_Tbl barTahvili)
        {
            InitializeComponent();
            BarTahvili = barTahvili;
        }
        public BarTahvili_Tbl BarTahvili{ get; set; }
        public RegisterStep1_BarTahvili step1;
        public RegisterStep2_BarTahvili step2;
        public RegisterStep3_BarTahvili step3;
        public RegisterStep4_BarTahvili step4;
        public TahvilCustomer tahvilCustomer;
        bool createStep1 = false;
        bool createStep2 = false;
        bool createStep3 = false;
        bool createStep4 = false;
        bool createTahvil = false;
        void SelectSenderInfo()
        {
            SenderInfo_Border.Background = ConverterColor("#D5DDED");
            SenderInfo_Btn.Foreground = ConverterColor("#2B54A3");
            if (createStep1)
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step1);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                step1 = new RegisterStep1_BarTahvili(BarTahvili) { Height = 256, Width = 622 };
                createStep1 = true;
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
                step2 = new RegisterStep2_BarTahvili(BarTahvili) { Height = 256, Width = 622 };
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
            if (createStep4)
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step4);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                step4 = new RegisterStep4_BarTahvili(BarTahvili);
                createStep4 = true;
                ShowStep_Grid.Children.Add(step4);
            }
        }
        void UnSelectBarInfo()
        {
            BarInfo_Border.Background = ConverterColor("#FFFFFF");
            BarInfo_Btn.Foreground = ConverterColor("#404040");
        }
        void SelectCustomerInfo()
        {
            TahvilCustomerInfo_Border.Background = ConverterColor("#D5DDED");
            TahvilCustomerInfo_Btn.Foreground = ConverterColor("#2B54A3");
            if (createTahvil)
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(tahvilCustomer);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                tahvilCustomer = new TahvilCustomer(BarTahvili, true) { Width = 622/*, VerticalAlignment = VerticalAlignment.Top*/ };
                tahvilCustomer.Field_Grid.RowDefinitions[0].Height = GridLength.Auto;
                tahvilCustomer.Field_Grid.RowDefinitions[2].Height = GridLength.Auto;
                createTahvil = true;
                ShowStep_Grid.Children.Add(tahvilCustomer);
            }
        }
        void UnSelectCustomerInfo()
        {
            TahvilCustomerInfo_Border.Background = ConverterColor("#FFFFFF");
            TahvilCustomerInfo_Btn.Foreground = ConverterColor("#404040");
        }
        void SelectRanandeInfo()
        {
            RanandeInfo_Border.Background = ConverterColor("#D5DDED");
            RanandeInfo_Btn.Foreground = ConverterColor("#2B54A3");
            if (createStep3)
            {
                ShowStep_Grid.Children.Clear();
                ShowStep_Grid.Children.Add(step3);
            }
            else
            {
                ShowStep_Grid.Children.Clear();
                step3 = new RegisterStep3_BarTahvili(BarTahvili, true) { Width = 622/*, VerticalAlignment = VerticalAlignment.Top*/ };

                createStep3 = true;
                ShowStep_Grid.Children.Add(step3);
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
            UnSelectCustomerInfo();
        }

        private void RecieverInfo_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnSelectSenderInfo();
            SelectRecieverInfo();
            UnSelectBarInfo();
            UnSelectRanandeInfo();
            UnSelectCustomerInfo();
        }

        private void SenderInfo_Btn_Click(object sender, RoutedEventArgs e)
        {
            SelectSenderInfo();
            UnSelectRecieverInfo();
            UnSelectBarInfo();
            UnSelectRanandeInfo();
            UnSelectCustomerInfo();
        }

        private void RanandeInfo_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnSelectSenderInfo();
            UnSelectRecieverInfo();
            UnSelectBarInfo();
            SelectRanandeInfo(); 
            UnSelectCustomerInfo();
        }
        bool Validation()
        {
            if (createStep1)
            {
                var validation_Ferestandeh = Barbari_BLL.Validation.BarTahvili_Validation_EtelatFerestande(step1.CityMabda_CmBox.Text, step1.FirstName_Txt.Text,
   step1.LastName_Txt.Text, step1.Mobile_Txt.Text);
                if (!validation_Ferestandeh.Success)
                {
                    MessageBox.Show(validation_Ferestandeh.Message);
                    return false;
                }
            }
            if (createStep2)
            {
                var validaition_Girande = Barbari_BLL.Validation.BarTahvili_Validation_EtelatGerande(step2.CityMaghsad_CmBox.Text,
                   step2.FirstName_Txt.Text, step2.LastName_Txt.Text, step2.Mobile_Txt.Text);
                if (!validaition_Girande.Success)
                {
                    MessageBox.Show(validaition_Girande.Message);
                    return false;
                }
            }
            if (createStep3)
            {
                var validaition_Ranande = Barbari_BLL.Validation.BarTahvili_Validation_EtelatRanande(step3.FirstName_Txt.Text, step3.LastName_Txt.Text,
    step3.Mobile_Txt.Text,step3.Code_CmBox.Text);
                if (!validaition_Ranande.Success)
                {
                    MessageBox.Show(validaition_Ranande.Message);
                    return false;
                }
            }
            if (createStep4)
            {
                var validaition_Bar = Barbari_BLL.Validation.BarErsali_Validation_EtelatBar(step4.PishKeraye_Txt.Text, step4.PasKeraye_Txt.Text,
    step4.Bime_Txt.Text, step4.AnbarDari_Txt.Text,
    step4.Shahri_Txt.Text, step4.BasteBandi_Txt.Text);
                if (!validaition_Bar.Success)
                {
                    MessageBox.Show(validaition_Bar.Message);
                    return false;
                }
            }
            if (createTahvil)
            {
                var validaition_Tahvil = Barbari_BLL.Validation.BarTahvili_Validation_TahvilMoshtari(tahvilCustomer.ValidationSolution_CmBox.Text,tahvilCustomer.ValidationData_Txt.Text);
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
            if (Validation())
            {


                if (createStep1)
                {
                    BarTahvili.BarTahviliShahrFerestande = step1.CityMabda_CmBox.Text;
                    BarTahvili.BarTahviliNamFerestande = step1.FirstName_Txt.Text;
                    BarTahvili.BarTahviliFamilyFerestande = step1.LastName_Txt.Text;
                    BarTahvili.BarTahviliMobileFerestande = step1.Mobile_Txt.Text;
                }
                if (createStep2)
                {
                    BarTahvili.BarTahviliShahrGerande = step2.CityMaghsad_CmBox.Text;
                    BarTahvili.BarTahviliNamGerande = step2.FirstName_Txt.Text;
                    BarTahvili.BarTahviliFamilyGerande = step2.LastName_Txt.Text;
                    BarTahvili.BarTahviliMobileGerande = step2.Mobile_Txt.Text;
                }
                if (createStep3)
                {
                    BarTahvili.BarTahviliNamRanande = step3.FirstName_Txt.Text;
                    BarTahvili.BarTahviliFamilyRanande = step3.LastName_Txt.Text;
                    BarTahvili.BarTahviliMobileRanande = step3.Mobile_Txt.Text;

                }
                if (createStep4)
                {
                    BarTahvili.BarTahviliBarname = step4.CodeBarname_Txt.Text;
                    BarTahvili.BarTahviliAnbardari = decimal.Parse(step4.AnbarDari_Txt.Text);
                    BarTahvili.BarTahviliBastebandi = decimal.Parse(step4.BasteBandi_Txt.Text);
                    BarTahvili.BarTahviliShahri= decimal.Parse(step4.Shahri_Txt.Text);
                    BarTahvili.BarTahviliBime = decimal.Parse(step4.Bime_Txt.Text);
                    BarTahvili.BarTahviliPasKeraye = decimal.Parse(step4.PishKeraye_Txt.Text);
                    BarTahvili.BarTahviliPishKeraye = decimal.Parse(step4.PasKeraye_Txt.Text);
                    BarTahvili.BarTahviliiSaat = step4.HourSodor_TmPicker.Text;
                    BarTahvili.BarTahviliTarikh = step4.DateSodor_DtPicker.Text;
                }
                BarTahvili.BarTahviliUserNameKarmand = WindowsAndPages.home_Window.User.UsersUserName;
                if (createTahvil)
                {
                    BarTahvili.BarTahviliRaveshEhrazHoviat = tahvilCustomer.ValidationSolution_CmBox.Text;
                    BarTahvili.BarTahviliRaveshEhrazHoviatText = tahvilCustomer.ValidationData_Txt.Text;
                }

                var result = Barbari_BLL.BarTahvili.Update(BarTahvili, TahvilCustomerInfo_Btn.IsEnabled);
                if (result.Success)
                {
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
            if (WindowsAndPages.home_Window.Role != null)
            {
                Save_Btn.IsEnabled = WindowsAndPages.home_Window.Role.BarTahviliUpdate;
            }
            else
            {
                Save_Btn.IsEnabled = false;
            }
            if (!string.IsNullOrEmpty(BarTahvili.BarTahviliRaveshEhrazHoviatText))
            {
                TahvilCustomerInfo_Btn.IsEnabled = true;
            }
            else
            {
                TahvilCustomerInfo_Btn.IsEnabled = false;
            }
            SenderInfo_Btn_Click(null, null);
        }

        private void TahvilCustomerInfo_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnSelectSenderInfo();
            UnSelectRecieverInfo();
            UnSelectBarInfo();
            UnSelectRanandeInfo();
            SelectCustomerInfo();
        }
    }
}
