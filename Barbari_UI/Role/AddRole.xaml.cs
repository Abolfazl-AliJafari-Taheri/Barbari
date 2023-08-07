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
        public AddRole(Roles_Tbl role)
        {
            InitializeComponent();
            Role = role;
            edit = true;
        }
        bool edit = false;
        public Roles_Tbl Role { get; set; }
        public bool Inserted { get; set; }
        private void BarErsali_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowBarErsaliAccess_Grid.Visibility= Visibility.Visible;    
        }

        private void BarErsali_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowBarErsaliAccess_Grid.Visibility = Visibility.Collapsed;
            BarErsaliInsert_Toggle.IsChecked = false;
            BarErsaliUpdate_Toggle.IsChecked = false;
            BarErsaliDelete_Toggle.IsChecked = false;
        }

        private void BarTahvili_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowBarTahviliAccess_Grid.Visibility = Visibility.Collapsed;
            BarTahviliInsert_Toggle.IsChecked = false;
            BarTahviliUpdate_Toggle.IsChecked = false;
            BarTahviliDelete_Toggle.IsChecked = false;
        }

        private void BarTahvili_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowBarTahviliAccess_Grid.Visibility = Visibility.Visible;
        }

        private void Customers_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowCustomersAccess_Grid.Visibility = Visibility.Collapsed;
            CustomersInsert_Toggle.IsChecked = false;
            CustomersUpdate_Toggle.IsChecked = false;
            CustomersDelete_Toggle.IsChecked = false;
        }

        private void Customers_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowCustomersAccess_Grid.Visibility = Visibility.Visible;
        }

        private void Users_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowUsersAccess_Grid.Visibility = Visibility.Collapsed;
            UsersInsert_Toggle.IsChecked = false;
            UsersUpdate_Toggle.IsChecked = false;
            UsersDelete_Toggle.IsChecked = false;
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
            RanandeInsert_Toggle.IsChecked = false;
            RanandeUpdate_Toggle.IsChecked = false;
            RanandeDelete_Toggle.IsChecked = false;
        }

        private void CityAnbar_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowCityAnbarAccess_Grid.Visibility = Visibility.Visible;
        }

        private void CityAnbar_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowCityAnbarAccess_Grid.Visibility = Visibility.Collapsed;
            CityAnbarInsert_Toggle.IsChecked = false;
            CityAnbarUpdate_Toggle.IsChecked = false;
            CityAnbarDelete_Toggle.IsChecked = false;
        }

        private void Setting_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            ShowSettingAccess_Grid.Visibility = Visibility.Visible;
        }

        private void Setting_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowSettingAccess_Grid.Visibility = Visibility.Collapsed;
            Setting_ToggleCompanyData.IsChecked = false;
            SettingRoles_Toggle.IsChecked = false;
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(!edit)
            {
                Role = new Roles_Tbl();
            }
            Role.RolesBarErsali = (bool)BarErsali_Toggle.IsChecked;
            Role.BarErsaliInsert = (bool)BarErsaliInsert_Toggle.IsChecked;
            Role.BarErsaliUpdate = (bool)BarErsaliUpdate_Toggle.IsChecked;
            Role.BarErsaliDelete = (bool)BarErsaliDelete_Toggle.IsChecked;
            Role.RolesBarTahvili = (bool)BarTahvili_Toggle.IsChecked;
            Role.BarTahviliInsert = (bool)BarTahviliInsert_Toggle.IsChecked;
            Role.BarTahviliUpdate = (bool)BarTahviliUpdate_Toggle.IsChecked;
            Role.BarTahviliDelete = (bool)BarTahviliDelete_Toggle.IsChecked;
            Role.RolesCustomers = (bool)Customers_Toggle.IsChecked;
            Role.CustomersInsert = (bool)CustomersInsert_Toggle.IsChecked;
            Role.CustomersUpdate = (bool)CustomersUpdate_Toggle.IsChecked;
            Role.CustomersDelete = (bool)CustomersDelete_Toggle.IsChecked;
            Role.RolesUsers = (bool)Users_Toggle.IsChecked;
            Role.UsersInsert = (bool)UsersInsert_Toggle.IsChecked;
            Role.UsersUpdate = (bool)UsersUpdate_Toggle.IsChecked;
            Role.UsersDelete = (bool)UsersDelete_Toggle.IsChecked;
            Role.RolesRanande = (bool)Ranande_Toggle.IsChecked;
            Role.RanandeInsert = (bool)RanandeInsert_Toggle.IsChecked;
            Role.RanandeUpdate = (bool)RanandeUpdate_Toggle.IsChecked;
            Role.RanandeDelete = (bool)RanandeDelete_Toggle.IsChecked;
            Role.RolesCity = (bool)CityAnbar_Toggle.IsChecked;
            Role.CityInsert = (bool)CityAnbarInsert_Toggle.IsChecked;
            Role.CityUpdate = (bool)CityAnbarUpdate_Toggle.IsChecked;
            Role.CityDelete = (bool)CityAnbarDelete_Toggle.IsChecked;
            Role.RolesTanzimat = (bool)Setting_Toggle.IsChecked;
            Role.TanzimatlogoAndName = (bool)Setting_ToggleCompanyData.IsChecked;
            Role.TanzimatRoles = (bool)SettingRoles_Toggle.IsChecked;
            Role.RolesNamRole = RoleName_Txt.Text;
            Role.RolesGozaresh = (bool)Print_Toggle.IsChecked;
            if(edit)
            {
                var validation = Barbari_BLL.Validation.Roles_Validation(Role);
                if (validation.Success)
                {
                    var result = Barbari_BLL.Roles.Update(Role);
                    if (result.Success)
                    {
                        DialogHost.CloseDialogCommand.Execute(null,null);
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
            else
            {
                var validation = Barbari_BLL.Validation.Roles_Validation(Role);
                if (validation.Success)
                {
                    var result = Barbari_BLL.Roles.Insert(Role);
                    if (result.Success)
                    {
                        Inserted = true;
                        Registered();
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
        void EditMode(Roles_Tbl role)
        {
            Title_TxtBlock.Text = "ویرایش نقش";
            Add_Btn.Content = "ویرایش نقش";
            RoleName_Txt.Text = role.RolesNamRole;
            BarErsali_Toggle.IsChecked = role.RolesBarErsali;
            BarErsaliInsert_Toggle.IsChecked = role.BarErsaliInsert;
            BarErsaliUpdate_Toggle.IsChecked = role.BarErsaliUpdate;
            BarErsaliDelete_Toggle.IsChecked = role.BarErsaliDelete;
            BarTahvili_Toggle.IsChecked = role.RolesBarTahvili;
            BarTahviliInsert_Toggle.IsChecked = role.BarTahviliInsert;
            BarTahviliUpdate_Toggle.IsChecked = role.BarErsaliUpdate;
            BarTahviliDelete_Toggle.IsChecked = role.BarTahviliDelete;
            Customers_Toggle.IsChecked = role.RolesCustomers;
            CustomersInsert_Toggle.IsChecked = role.CustomersInsert;
            CustomersUpdate_Toggle.IsChecked = role.CustomersUpdate;
            CustomersDelete_Toggle.IsChecked = role.CustomersDelete;
            Users_Toggle.IsChecked = role.RolesUsers;
            UsersInsert_Toggle.IsChecked = role.UsersInsert;
            UsersUpdate_Toggle.IsChecked = role.UsersUpdate;
            UsersDelete_Toggle.IsChecked = role.UsersDelete;
            Ranande_Toggle.IsChecked = role.RolesRanande;
            RanandeInsert_Toggle.IsChecked = role.RanandeInsert;
            RanandeUpdate_Toggle.IsChecked = role.RanandeInsert;
            RanandeDelete_Toggle.IsChecked = role.RanandeDelete;
            CityAnbar_Toggle.IsChecked = role.RolesCity;
            CityAnbarInsert_Toggle.IsChecked = role.CityInsert;
            CityAnbarUpdate_Toggle.IsChecked = role.CityUpdate;
            CityAnbarDelete_Toggle.IsChecked = role.CityDelete;
            Setting_Toggle.IsChecked = role.RolesTanzimat;
            Setting_ToggleCompanyData.IsChecked = role.TanzimatlogoAndName;
            SettingRoles_Toggle.IsChecked = role.TanzimatRoles;
            Print_Toggle.IsChecked = role.RolesGozaresh;
        }
        void Registered()
        {
            BarErsali_Toggle.IsChecked = false;
            BarErsaliInsert_Toggle.IsChecked = false;
            BarErsaliUpdate_Toggle.IsChecked = false;
            BarErsaliDelete_Toggle.IsChecked = false;
            BarTahvili_Toggle.IsChecked = false;
            BarTahviliInsert_Toggle.IsChecked = false;
            BarTahviliUpdate_Toggle.IsChecked = false;
            BarTahviliDelete_Toggle.IsChecked = false;
            Customers_Toggle.IsChecked = false;
            CustomersInsert_Toggle.IsChecked = false;
            CustomersUpdate_Toggle.IsChecked = false;
            CustomersDelete_Toggle.IsChecked = false;
            Users_Toggle.IsChecked = false;
            UsersInsert_Toggle.IsChecked = false;
            UsersUpdate_Toggle.IsChecked = false;
            UsersDelete_Toggle.IsChecked = false;
            Ranande_Toggle.IsChecked = false;
            RanandeInsert_Toggle.IsChecked = false;
            RanandeUpdate_Toggle.IsChecked = false;
            RanandeDelete_Toggle.IsChecked = false;
            CityAnbar_Toggle.IsChecked = false;
            CityAnbarInsert_Toggle.IsChecked = false;
            CityAnbarUpdate_Toggle.IsChecked = false;
            CityAnbarDelete_Toggle.IsChecked = false;
            Setting_Toggle.IsChecked = false;
            Setting_ToggleCompanyData.IsChecked = false;
            SettingRoles_Toggle.IsChecked = false;
            RoleName_Txt.Text = "";
            Print_Toggle.IsChecked = false;
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(edit)
            {
                EditMode(Role);
            }
            else
            {
                Inserted = false;
            }
        }
    }
}
