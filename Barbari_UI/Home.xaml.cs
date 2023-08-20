using Barbari_DAL;
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
using System.Windows.Shapes;

namespace Barbari_UI
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home(Users_Tbl LoginedUser)
        {
            InitializeComponent();
            User = LoginedUser;
        }

        bool createBarErsali = false;
        bool createBarTahvili = false;
        bool createMoshtari = false;
        bool createKarmand = false;
        bool createRanande = false;
        bool createCityAnbar = false;
        bool createSetting = false;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //e.Cancel = true;
            //logedout= true;
            //WindowsAndPages.home_Window.Visibility= Visibility.Hidden;
        }
        public Users_Tbl User{ get; set; }
        public Roles_Tbl Role{ get; set; }
        private void SelectBarErsaliMenu()
        {
            BarErsaliMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/Bar Ersali Menu Icon(Blue Border).png");
            BarErsaliMenuBtn_Text.Foreground = ConverterColor("#2B54A3");
            BarErsaliMenu_Btn.Background = ConverterColor("#D5DDED");
            BarErsaliMenuBtn_Line.Source = ConverterPhoto("/Source/Icones/Menu Select Line.png");
        }
        private void UnSelectBarErsaliMenu()
        {
            BarErsaliMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/Bar Ersali Menu Icon(Gray Border).png");
            BarErsaliMenu_Btn.Background = ConverterColor("#FFFFFF");
            BarErsaliMenuBtn_Text.Foreground = ConverterColor("#404040");
            BarErsaliMenuBtn_Line.Source = ConverterPhoto("");
        }
        private void SelectBarTahviliMenu()
        {
            BarTahviliMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/Bar Tahvili Menu Icon(Blue Border).png");
            BarTahviliMenuBtn_Text.Foreground = ConverterColor("#2B54A3");
            BarTahviliMenu_Btn.Background = ConverterColor("#D5DDED");
            BarTahviliMenuBtn_Line.Source = ConverterPhoto("/Source/Icones/Menu Select Line.png");
        }
        private void UnSelectBarTahviliMenu()
        {
            BarTahviliMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/Bar Tahvili Menu Icon(Gray Border).png");
            BarTahviliMenuBtn_Text.Foreground = ConverterColor("#404040");
            BarTahviliMenu_Btn.Background = ConverterColor("#FFFFFF");
            BarTahviliMenuBtn_Line.Source = ConverterPhoto("");
        }
        private void SelectMoshtariMenu()
        {
            MoshtariMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/Moshtari Menu Icon(Blue Border).png");
            MoshtariMenu_Btn.Background = ConverterColor("#D5DDED");
            MoshtariMenuBtn_Text.Foreground = ConverterColor("#2B54A3");
            MoshtariMenuBtn_Line.Source = ConverterPhoto("/Source/Icones/Menu Select Line.png");
        }
        private void UnSelectMoshtariMenu()
        {
            MoshtariMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/Moshtari Menu Icon(Gray Border).png");
            MoshtariMenu_Btn.Background = ConverterColor("#FFFFFF");
            MoshtariMenuBtn_Text.Foreground = ConverterColor("#404040");
            MoshtariMenuBtn_Line.Source = ConverterPhoto("");
        }
        private void SelectKarmandMenu()
        {
            KarmandanMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/Karmandan Menu Icon(Blue Border).png");
            KarmandanMenu_Btn.Background = ConverterColor("#D5DDED");
            KarmandanMenuBtn_Text.Foreground = ConverterColor("#2B54A3");
            KarmandanMenuBtn_Line.Source = ConverterPhoto("/Source/Icones/Menu Select Line.png");
        }
        private void UnSelectKarmandMenu()
        {
            KarmandanMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/Karmandan Menu Icon(Gray Border).png");
            KarmandanMenu_Btn.Background = ConverterColor("#FFFFFF");
            KarmandanMenuBtn_Text.Foreground = ConverterColor("#404040");
            KarmandanMenuBtn_Line.Source = ConverterPhoto("");
        }
        private void SelectRanandeMenu()
        {
            RanandeganMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/Ranande Menu Icon(Blue Border).png");
            RanandeganMenu_Btn.Background = ConverterColor("#D5DDED");
            RanandeganMenuBtn_Text.Foreground = ConverterColor("#2B54A3");
            RanandeganMenuBtn_Line.Source = ConverterPhoto("/Source/Icones/Menu Select Line.png");
        }
        private void UnSelectRanandeMenu()
        {
            RanandeganMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/Ranande Menu Icon(Gray Border).png");
            RanandeganMenu_Btn.Background = ConverterColor("#FFFFFF");
            RanandeganMenuBtn_Text.Foreground = ConverterColor("#404040");
            RanandeganMenuBtn_Line.Source = ConverterPhoto("");
        }
        private void SelectCityAnbarMenu()
        {
            CityAnbarMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/City Anbar Menu Icon(Blue Border).png");
            CityAnbarMenu_Btn.Background = ConverterColor("#D5DDED");
            CityAnbarMenuBtn_Text.Foreground = ConverterColor("#2B54A3");
            CityAnbarMenuBtn_Line.Source = ConverterPhoto("/Source/Icones/Menu Select Line.png");
        }
        private void UnSelectCityAnbarMenu()
        {
            CityAnbarMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/City Anbar Menu Icon(Gray Border).png");
            CityAnbarMenu_Btn.Background = ConverterColor("#FFFFFF");
            CityAnbarMenuBtn_Text.Foreground = ConverterColor("#404040");
            CityAnbarMenuBtn_Line.Source = ConverterPhoto("");
        }
        private void SelectSettingMenu()
        {
            SettingMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/Setting Menu Icon(Blue Border).png");
            SettingMenu_Btn.Background = ConverterColor("#D5DDED");
            SettingMenuBtn_Text.Foreground = ConverterColor("#2B54A3");
            SettingMenuBtn_Line.Source = ConverterPhoto("/Source/Icones/Menu Select Line.png");
        }
        private void UnSelectSettingMenu()
        {
            SettingMenuBtn_Icon.Source = ConverterPhoto("/Source/Icones/Setting Menu Icon(Gray Border).png");
            SettingMenu_Btn.Background = ConverterColor("#FFFFFF");
            SettingMenuBtn_Text.Foreground = ConverterColor("#404040");
            SettingMenuBtn_Line.Source = ConverterPhoto("");
        }

        BitmapImage ConverterPhoto(string ImageAddress)
        {
            BitmapImage brush = new BitmapImage(new Uri(ImageAddress, UriKind.Relative));
            return brush;
        }

        Brush ConverterColor (string ColorCode)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(ColorCode));
        }

        private void BarErsaliMenu_Btn_Click(object sender, RoutedEventArgs e)
        {
            SelectBarErsaliMenu();
            UnSelectBarTahviliMenu();
            UnSelectCityAnbarMenu();
            UnSelectKarmandMenu();
            UnSelectMoshtariMenu();
            UnSelectRanandeMenu();
            UnSelectSettingMenu();
            if (createBarErsali)
            {
               MainFrame.Content= WindowsAndPages.barErsali;
            }
            else
            {
                createBarErsali = true;
                WindowsAndPages.barErsali = new BarErsali();
                MainFrame.Content = WindowsAndPages.barErsali;
            }
        }

        private void BarTahviliMenu_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnSelectBarErsaliMenu();
            SelectBarTahviliMenu();
            UnSelectCityAnbarMenu();
            UnSelectKarmandMenu();
            UnSelectMoshtariMenu();
            UnSelectRanandeMenu();
            UnSelectSettingMenu();
            if (createBarTahvili)
            {
                MainFrame.Content = WindowsAndPages.barTahvili;
            }
            else
            {
                createBarTahvili = true;
                WindowsAndPages.barTahvili = new BarTahvili();
                MainFrame.Content = WindowsAndPages.barTahvili;
            }
        }

        private void MoshtariMenu_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnSelectBarErsaliMenu();
            UnSelectBarTahviliMenu();
            UnSelectCityAnbarMenu();
            UnSelectKarmandMenu();
            SelectMoshtariMenu();
            UnSelectRanandeMenu();
            UnSelectSettingMenu();
            if (createMoshtari)
            {
                MainFrame.Content = WindowsAndPages.moshtari;
            }
            else
            {
                createMoshtari = true;
                WindowsAndPages.moshtari = new Moshtari();
                MainFrame.Content = WindowsAndPages.moshtari;
            }
        }

        private void KarmandanMenu_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnSelectBarErsaliMenu();
            UnSelectBarTahviliMenu();
            UnSelectCityAnbarMenu();
            SelectKarmandMenu();
            UnSelectMoshtariMenu();
            UnSelectRanandeMenu();
            UnSelectSettingMenu();
            if (createKarmand)
            {
                MainFrame.Content = WindowsAndPages.karmand;
            }
            else
            {
                createKarmand = true;
                WindowsAndPages.karmand = new Karmand();
                MainFrame.Content = WindowsAndPages.karmand;
            }
        }

        private void RanandeganMenu_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnSelectBarErsaliMenu();
            UnSelectBarTahviliMenu();
            UnSelectCityAnbarMenu();
            UnSelectKarmandMenu();
            UnSelectMoshtariMenu();
            SelectRanandeMenu();
            UnSelectSettingMenu();
            if (createRanande)
            {
                MainFrame.Content = WindowsAndPages.ranandegan;
            }
            else
            {
                createRanande = true;
                WindowsAndPages.ranandegan = new Ranandegan();
                MainFrame.Content = WindowsAndPages.ranandegan;
            }
        }

        private void CityAnbarMenu_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnSelectBarErsaliMenu();
            UnSelectBarTahviliMenu();
            SelectCityAnbarMenu();
            UnSelectKarmandMenu();
            UnSelectMoshtariMenu();
            UnSelectRanandeMenu();
            UnSelectSettingMenu();
            if (createCityAnbar)
            {
                MainFrame.Content = WindowsAndPages.cityAnbar;
            }
            else
            {
                createCityAnbar = true;
                WindowsAndPages.cityAnbar = new CityAnbar();
                MainFrame.Content = WindowsAndPages.cityAnbar;
            }
        }

        private void SettingMenu_Btn_Click(object sender, RoutedEventArgs e)
        {
            UnSelectBarErsaliMenu();
            UnSelectBarTahviliMenu();
            UnSelectCityAnbarMenu();
            UnSelectKarmandMenu();
            UnSelectMoshtariMenu();
            UnSelectRanandeMenu();
            SelectSettingMenu();
            if (createSetting)
            {
                MainFrame.Content = WindowsAndPages.setting;
            }
            else
            {
                createSetting = true;
                WindowsAndPages.setting = new Setting();
                MainFrame.Content = WindowsAndPages.setting;
            }
        }

        private void LogoutMenu_Btn_Click(object sender, RoutedEventArgs e)
        {
            //logedout  =true;
            //WindowsAndPages.home_Window.Visibility= Visibility.Hidden;
            this.Close();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //if (createWhitePage)
            //{
            //    MainFrame.Content = WindowsAndPages.WhitePage;
            //}
            //else
            //{
            //    WindowsAndPages.WhitePage = new Page1();
            //    MainFrame.Content = WindowsAndPages.WhitePage;
            //}
            Role = null;
            UnSelectBarErsaliMenu();
            UnSelectBarTahviliMenu();
            UnSelectCityAnbarMenu();
            UnSelectKarmandMenu();
            UnSelectMoshtariMenu();
            UnSelectRanandeMenu();
            UnSelectSettingMenu();

            if (User.UsersRoles != null)
            {
                var role = Barbari_BLL.Roles.Roles_Login(User.UsersRoles);
                if (role.Success)
                {
                    Role = role.Data;

                    if (Role.RolesBarErsali)
                    {
                        BarErsaliMenu_Btn_Click(null, null);
                    }
                    BarErsaliMenu_Btn.IsEnabled = Role.RolesBarErsali;
                    BarTahviliMenu_Btn.IsEnabled = Role.RolesBarTahvili;
                    MoshtariMenu_Btn.IsEnabled = Role.RolesCustomers;
                    KarmandanMenu_Btn.IsEnabled = Role.RolesUsers;
                    RanandeganMenu_Btn.IsEnabled = Role.RolesRanande;
                    CityAnbarMenu_Btn.IsEnabled = Role.RolesCity;
                    SettingMenu_Btn.IsEnabled = Role.RolesTanzimat;
                    GetReport_Btn.IsEnabled = Role.RolesGozaresh;

                }
                else
                {

                    MessageBox.Show(role.Message);
                }
            }
            else
            {
                BarErsaliMenu_Btn_Click(null, null);
                GetReport_Btn.IsEnabled = false;
            }
            UserRoleName_TxtBlock.Text = User.UsersRoles;
            UserFullName_TxtBlock.Text = User.UsersFirstName + "  " + User.UsersLastName;
            var company = Barbari_BLL.Company.Select();
            if(company.Data != null)
            {
                if (string.IsNullOrEmpty(company.Data.CompanyName))
                {
                    CompanyName_TxtBlock.Text = "";
                }
                else
                {
                    CompanyName_TxtBlock.Text = company.Data.CompanyName;
                }
            }
           else
            {
                CompanyName_TxtBlock.Text = "";
            }

            if (company.Data != null)
            {
                if (company.Data.CompanyIogo != "" && company.Data.CompanyIogo != null)
                {
                    if (File.Exists(company.Data.CompanyIogo))
                    {
                        var brush = new ImageBrush();
                        brush.ImageSource = new BitmapImage(new Uri(company.Data.CompanyIogo, UriKind.Relative));
                        Logo_Border.Background = brush;
                    }
                    else
                    {
                        Logo_Img.Source = ConverterPhoto("/Source/Icones/AppIcon(Black Border).png");
                    }
                }
                else
                {
                    Logo_Img.Source = ConverterPhoto("/Source/Icones/AppIcon(Black Border).png");
                }

            }
            else
            {
                Logo_Img.Source = ConverterPhoto("/Source/Icones/AppIcon(Black Border).png");
            }
           
        }
    }
}
