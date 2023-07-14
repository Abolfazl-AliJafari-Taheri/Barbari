using Barbari_DAL;
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

namespace Barbari_UI
{
    /// <summary>
    /// Interaction logic for KarmandComponent.xaml
    /// </summary>
    public partial class KarmandComponent : UserControl
    {
        public KarmandComponent()
        {
            InitializeComponent();
        }
        public KarmandComponent(Users_Tbl karmand)
        {
            InitializeComponent();
            Karmand = karmand;
        }
        public Users_Tbl Karmand { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Name_TxtBlock.Text = Karmand.UsersFirstName + " " + Karmand.UsersLastName;
            UserName_TxtBlock.Text = Karmand.UsersUserName;
            MobileNum_TxtBlock.Text = Karmand.UsersMobile;
            PassWord_TxtBlock.Text = Karmand.UsersPassWord;
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result = Barbari_BLL.Users.Delete(Karmand.UsersUserName);
            if (result.Success)
            {
                WindowsAndPages.karmand.Refresh();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private async void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new AddKarmand(Karmand) { Height = 397, Width = 622 });
        }
    }
}
