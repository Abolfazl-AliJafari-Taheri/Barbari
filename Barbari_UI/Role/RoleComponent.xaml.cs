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
            RoleName_TxtBlock.Text = Role.RolesNamRole;
            UseresNumber_TxtBlock.Text = Role.
        }
    }
}
