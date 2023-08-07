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

namespace Barbari_UI.Role
{
    /// <summary>
    /// Interaction logic for ShowUsersRole.xaml
    /// </summary>
    public partial class ShowUsersRole : UserControl
    {
        public ShowUsersRole(List<Users_Tbl> users,string RoleName)
        {
            InitializeComponent();
            Users = users;
            roleName = RoleName;
        }
        public List<Users_Tbl> Users { get; set; }
        string roleName = "";
        void Refresh ()
        {
            ShowUsers_StckPnl.Children.Clear();
            if(Users.Count != 0)
            {
                foreach (Users_Tbl user in Users)
                {
                    ShowUsers_StckPnl.Children.Add(new UserRoleComponent(user) { Height = 72, Width = 574 });
                }
            }
           
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
                Massage_TxtBlock.Text = "کاربران نقش " + roleName;
            Refresh();
        }
    }
}
