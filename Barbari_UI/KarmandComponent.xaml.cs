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
            Delete_Btn.IsEnabled = WindowsAndPages.home_Window.Role.UsersDelete;
            Edit_Btn.IsEnabled = WindowsAndPages.home_Window.Role.UsersUpdate;
            Name_TxtBlock.Text = Karmand.UsersFirstName + " " + Karmand.UsersLastName;
            UserName_TxtBlock.Text = Karmand.UsersUserName;
            MobileNum_TxtBlock.Text = Karmand.UsersMobile;
            PassWord_TxtBlock.Text = Karmand.UsersPassWord;
        }

        private async void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
           await WindowsAndPages.home_Window.DialogHost.ShowDialog(new SubmitDelete(User: Karmand) { Height = 160, Width = 400 }) ;
           
        }

        private async void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new AddKarmand(Karmand) { Height = 397, Width = 622 });
        }
    }
}
