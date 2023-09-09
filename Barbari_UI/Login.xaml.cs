using Barbari_BLL;
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
using System.Windows.Shapes;

namespace Barbari_UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        public void RemoveText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                textBox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            }
        }
        public void AddText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
            }
        }
        private void PassWord_PassBx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Password_PassBx.Password))
            {
                Password_PassBx.Password = Password_PassBx.Tag.ToString();
                Password_PassBx.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
            }
        }

        private void PassWord_PassBx_GotFocus(object sender, RoutedEventArgs e)
        {

            if (Password_PassBx.Password == Password_PassBx.Tag.ToString())
            {
                Password_PassBx.Password = "";
                Password_PassBx.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            }
        }

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            string userName = Username_Txt.Text.Trim();
            string passWord = Password_PassBx.Password.Trim();
            var result = Barbari_BLL.Users.SearchUserAndPassWord(userName, passWord);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                Username_Txt.Text = "";
                Password_PassBx.Password = "";

                //if (WindowsAndPages.home_Window == null)
                //{
                    WindowsAndPages.home_Window = new Home(result.Data);
                    WindowsAndPages.home_Window.ShowDialog();
                //}
                //else
                //{
                //    WindowsAndPages.home_Window.User= result.Data;
                //    WindowsAndPages.home_Window.Window_Loaded(null,null);
                   
                //    WindowsAndPages.home_Window.ShowDialog();
                //}
            }
        }

        private void Username_Txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Password_PassBx.Focus();
            }
        }

        private void Password_PassBx_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login_Btn_Click(null, null);
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Username_Txt.Focus();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           Application.Current.Shutdown();
        }
        BitmapImage ConverterPhoto(string ImageAddress)
        {
            BitmapImage brush = new BitmapImage(new Uri(ImageAddress, UriKind.Relative));
            return brush;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var roles = Barbari_BLL.Roles.Select("");
            var users = Barbari_BLL.Users.Select("");
            if(roles.Success)
            {
                if(roles.Data.Count == 0)
                {
                    Roles_Tbl role = new Roles_Tbl()
                    {
                        RolesAsli = true,
                        RolesNamRole = "مدیر",
                        BarErsaliDelete = true,
                        BarErsaliInsert = true,
                        BarErsaliUpdate = true,
                        BarTahviliDelete = true,
                        BarTahviliInsert = true,
                        BarTahviliUpdate = true,
                        CityDelete = true,
                        CityInsert = true,
                        CityUpdate = true,
                        CustomersDelete = true,
                        CustomersInsert = true,
                        CustomersUpdate = true,
                        RanandeDelete = true,
                        RanandeInsert = true,
                        RanandeUpdate = true,
                        RolesBarErsali = true,
                        RolesBarTahvili = true,
                        RolesCity = true,
                        RolesCustomers = true,
                        RolesGozaresh = true,
                        RolesRanande = true,
                        RolesTanzimat = true,
                        RolesUsers = true,
                        TanzimatlogoAndName = true,
                        TanzimatRoles = true,
                        UsersDelete = true,
                        UsersInsert = true,
                        UsersUpdate = true
                    };
                    var insertFirstRole = Barbari_BLL.Roles.Insert(role);
                    if(!insertFirstRole.Success)
                    {
                        MessageBox.Show(insertFirstRole.Message);
                    }
                }
               
            }
            else
            {
                MessageBox.Show(roles.Message);
            }
            if (users.Success)
            {
                if(users.Data.Count == 0)
                {
                    DialogHost.ShowDialog(new AddKarmand(true) { Height = 397, Width = 622 });
                }
            }
            else
            {
                MessageBox.Show(users.Message);
            }
            var company = Barbari_BLL.Company.Select();
            if(company.Data != null)
            {
                if (company.Data.CompanyIogo != "" && company.Data.CompanyIogo != null)
                {
                    if(File.Exists(company.Data.CompanyIogo))
                    {
                        var brush = new ImageBrush();
                        brush.ImageSource = new BitmapImage(new Uri(company.Data.CompanyIogo, UriKind.Relative));
                        Logo_Border.Background = brush;
                    }
                    else
                    {
                        Logo_Img.Source = ConverterPhoto("/Source/Icones/AppIcon(White Border).png");
                    }
                }
                else
                {
                    Logo_Img.Source = ConverterPhoto("/Source/Icones/AppIcon(White Border).png");
                }

            }
            else
            {
                Logo_Img.Source = ConverterPhoto("/Source/Icones/AppIcon(White Border).png");
            }

        }

        private void Username_Txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                if (IsPersianCharacter(e.Text))
                {
                    e.Handled = true;
                }
            }
        }
        private bool IsPersianCharacter(string text)
        {
            var regex = new Regex(@"\p{IsArabic}");
            return regex.IsMatch(text);
        }
    }
}
