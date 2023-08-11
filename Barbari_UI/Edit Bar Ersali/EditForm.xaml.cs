using Barbari_DAL;
using Barbari_UI.Register_Bar_Ersali;
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
                step1 = new RegisterStep1(BarErsali) { Height = 376 ,Width = 622 };
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
                step2 = new RegisterStep2(BarErsali) { Height = 376 ,Width = 622 };
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
                step3 = new RegisterStep3(BarErsali);
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
                tahvilRanande = new TahvilRanande(BarErsali, true) {Height = 312, Width = 622 , VerticalAlignment = VerticalAlignment.Top};
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
                RanandeInfo_Btn.IsEnabled= true;
            }
            else
            {
                RanandeInfo_Btn.IsEnabled = false;
            }
            SenderInfo_Btn_Click(null,null);
        }
    }
}
