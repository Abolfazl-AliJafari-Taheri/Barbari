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
using Barbari_DAL;
using MaterialDesignThemes.Wpf;

namespace Barbari_UI.Role
{
    /// <summary>
    /// Interaction logic for RoleComponent.xaml
    /// </summary>
    public partial class RoleComponent : UserControl
    {
        public RoleComponent(Roles_Tbl role)
        {
            InitializeComponent();
            Role = role;
        }
        public Roles_Tbl Role { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (WindowsAndPages.home_Window.Role != null)
            {
                Delete_Btn.IsEnabled = WindowsAndPages.home_Window.Role.TanzimatRoles;
                Edit_Btn.IsEnabled = WindowsAndPages.home_Window.Role.TanzimatRoles;
            }
            else
            {
                Delete_Btn.IsEnabled = false;
                Edit_Btn.IsEnabled = false;
            }
            RoleName_TxtBlock.Text = Role.RolesNamRole;
            var userNumber = Barbari_BLL.Roles.Select_Count(Role.RolesNamRole);
            if(userNumber.Success)
            {
                UseresNumber_TxtBlock.Text = userNumber.Data.Count.ToString();
            }
            else
            {
                MessageBox.Show(userNumber.Message);
            }

        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            WindowsAndPages.home_Window.DialogHost.ShowDialog(new SubmitDelete(Role:Role) { Height = 160, Width = 400 });
        }

        private async void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Role.AddRole addRole = new Role.AddRole(Role) { Width = 660 };
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(addRole);
            WindowsAndPages.setting.RefreshRoles();

        }

        private void NumberUsers_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result = Barbari_BLL.Roles.Select_Count(Role.RolesNamRole);
            if(result.Success)
            {
                WindowsAndPages.home_Window.DialogHost.ShowDialog(new ShowUsersRole(result.Data,Role.RolesNamRole) { Width = 622});
            }
        }
    }
}
