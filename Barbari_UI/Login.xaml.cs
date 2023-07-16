using Barbari_BLL;
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
            var result = Users.SearchUserAndPassWord(userName, passWord);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                if(WindowsAndPages.home_Window == null)
                {
                    WindowsAndPages.home_Window = new Home(result.Data);
                    WindowsAndPages.home_Window.ShowDialog();
                }
                else
                {
                    WindowsAndPages.home_Window.User= result.Data;
                    WindowsAndPages.home_Window.Window_Loaded(null,null);
                    WindowsAndPages.home_Window.ShowDialog();
                }
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
    }
}
