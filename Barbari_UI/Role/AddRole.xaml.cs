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
    /// Interaction logic for AddRole.xaml
    /// </summary>
    public partial class AddRole : UserControl
    {
        public AddRole()
        {
            InitializeComponent();
        }

        private void BarErsali_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowBarErsaliAccess_Grid.Visibility= Visibility.Visible;    
        }

        private void BarErsali_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowBarErsaliAccess_Grid.Visibility = Visibility.Collapsed;
        }

        private void BarTahvili_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowBarTahviliAccess_Grid.Visibility = Visibility.Collapsed;
        }

        private void BarTahvili_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowBarTahviliAccess_Grid.Visibility = Visibility.Visible;
        }

        private void Customers_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowCustomersAccess_Grid.Visibility = Visibility.Collapsed;
        }

        private void Customers_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowCustomersAccess_Grid.Visibility = Visibility.Visible;
        }

        private void Users_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowUsersAccess_Grid.Visibility = Visibility.Collapsed;
        }

        private void Users_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowUsersAccess_Grid.Visibility = Visibility.Visible;
        }

        private void Ranande_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowRanandeAccess_Grid.Visibility = Visibility.Visible;
        }

        private void Ranande_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowRanandeAccess_Grid.Visibility = Visibility.Collapsed;
        }

        private void CityAnbar_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowCityAnbarAccess_Grid.Visibility = Visibility.Visible;
        }

        private void CityAnbar_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowCityAnbarAccess_Grid.Visibility = Visibility.Collapsed;
        }

        private void Setting_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowSettingAccess_Grid.Visibility = Visibility.Visible;
        }

        private void Setting_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowSettingAccess_Grid.Visibility = Visibility.Collapsed;
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {

            Roles_Tbl role = new Roles_Tbl()
            {
                RolesBarErsali = (bool)BarErsali_Toggle.IsChecked,
                BarErsaliInsert = (bool)BarErsaliInsert_Toggle.IsChecked,
                BarErsaliUpdate = (bool)BarErsaliUpdate_Toggle.IsChecked,
                BarErsaliDelete = (bool)BarErsaliDelete_Toggle.IsChecked,
                RolesBarTahvili = (bool)BarTahvili_Toggle.IsChecked,
                BarTahviliInsert = (bool)BarTahviliInsert_Toggle.IsChecked,
                BarTahviliUpdate = (bool)BarTahviliUpdate_Toggle.IsChecked,
                BarTahviliDelete = (bool)BarTahviliDelete_Toggle.IsChecked,
                RolesCustomers = (bool)Customers_Toggle.IsChecked,
                CustomersInsert = (bool)CustomersInsert_Toggle.IsChecked,
                CustomersUpdate = (bool)CustomersUpdate_Toggle.IsChecked,
                CustomersDelete = (bool)CustomersDelete_Toggle.IsChecked,
                RolesUsers = (bool)Users_Toggle.IsChecked,
                UsersInsert = (bool)UsersInsert_Toggle.IsChecked,
                UsersUpdate = (bool)UsersUpdate_Toggle.IsChecked,
                UsersDelete = (bool)UsersDelete_Toggle.IsChecked,
                RolesRanande = (bool)Ranande_Toggle.IsChecked,
                RanandeInsert = (bool)RanandeInsert_Toggle.IsChecked,
                RanandeUpdate = (bool)RanandeUpdate_Toggle.IsChecked,
                RanandeDelete = (bool)RanandeDelete_Toggle.IsChecked,
                RolesCity = (bool)CityAnbar_Toggle.IsChecked,
                CityInsert = (bool)CityAnbarInsert_Toggle.IsChecked,
                CityUpdate = (bool)CityAnbarUpdate_Toggle.IsChecked,
                CityDelete = (bool)CityAnbarDelete_Toggle.IsChecked,
                RolesTanzimat = (bool)UsersDelete_Toggle.IsChecked,
                TanzimatlogoAndName = (bool)Setting_ToggleCompanyData.IsChecked,
                TanzimatRoles = (bool)SettingRoles_Toggle.IsChecked,
                RolesNamRole = RoleName_Txt.Text,
                RolesGozaresh = (bool)Print_Toggle.IsChecked
            };
            var validation = Barbari_BLL.Validation.Roles_Validation(role);
            if (validation.Success)
            {
                var result = Barbari_BLL.Roles.Insert(role);
                if(result.Success)
                {
                    
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
            {
                MessageBox.Show(validation.Message);
            }

        }
    }
}
