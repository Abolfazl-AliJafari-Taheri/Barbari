using System;
using System.Collections.Generic;
using System.Data;
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
using Barbari_BLL;
using Barbari_DAL;
using MaterialDesignThemes.Wpf;

namespace Barbari_UI
{
    /// <summary>
    /// Interaction logic for SubmitDelete.xaml
    /// </summary>
    public partial class SubmitDelete : UserControl
    {
        public SubmitDelete(Users_Tbl User =null, City_Tbl City = null, BarErsali_Tbl BarErsali = null, BarTahvili_Tbl BarTahvili = null , Customers_Tbl Customer = null , Ranande_Tbl Driver = null , KalaDaryafti_Tbl KalaDaryafti = null,KalaTahvili_Tbl KalaTahvili = null,Roles_Tbl Role = null , int CodeBarname = 0)
        {
            user= User;
            city= City;
            barErsali = BarErsali;
            barTahvili= BarTahvili;
            driver= Driver;
            kalaDaryafti= KalaDaryafti;
            kalaTahvili= KalaTahvili;
            customer= Customer;
            role = Role;
            codeBaarname = CodeBarname;
            InitializeComponent();
        }
        Users_Tbl user;
        City_Tbl city;
        BarErsali_Tbl barErsali;
        BarTahvili_Tbl barTahvili;
        Customers_Tbl customer;
        Ranande_Tbl driver;
        KalaDaryafti_Tbl kalaDaryafti; 
        KalaTahvili_Tbl kalaTahvili;
        Roles_Tbl role;
        int codeBaarname;
        private void SubmitDelete_Btn_Click(object sender, RoutedEventArgs e)
        {
            
            if (user != null)
            {
                var result = Barbari_BLL.Users.Delete(user.UsersUserName);
                if(!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);
                    WindowsAndPages.karmand.Refresh();
                }
            }
            else if(driver != null)
            {
                var result = Barbari_BLL.Ranande.Delete(driver.RanandeCodeRanande);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);
                    WindowsAndPages.ranandegan.Refresh();
                }
            }
            else if (customer != null)
            {
                var result = Barbari_BLL.Customers.Delete(customer.CustomersCode);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    WindowsAndPages.moshtari.Refresh();
                    DialogHost.CloseDialogCommand.Execute(null, null);
                }
            }
            else if (city != null)
            {
                var result = Barbari_BLL.City.Delete(city.CityShahr,city.CityAnbar);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);
                    WindowsAndPages.cityAnbar.Refresh();
                }
            }
            else if (barErsali != null)
            {
                var result = Barbari_BLL.BarErsali.Delete(barErsali.BarErsaliBarname);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);
                    WindowsAndPages.barErsali.Refresh("");
                }
            }
            else if (role != null)
            {
                var result = Barbari_BLL.Roles.Delete(role.RolesNamRole);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);
                    WindowsAndPages.setting.RefreshRoles();
                }
            }
            else if (codeBaarname != 0)
            {
                Massage_TxtBlock.Text = "آیا از تغییر وضعیت بار مطمئن هستید؟";
                SubmitDelete_Btn.Content = "بله";
                var result = Barbari_DAL.BarErsali.Back_To_Anbar(codeBaarname);
                if (!result.Success)
                {
                    MessageBox.Show("خطایی رخ داده است لطفا با پشتیبان تماس بگیرید");
                }
                else
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);
                    WindowsAndPages.barErsali.Refresh();
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           if (codeBaarname != 0)
            {
                Massage_TxtBlock.Text = "آیا از تغییر وضعیت بار مطمئن هستید؟";
                SubmitDelete_Btn.Content = "بله";
                SubmitDelete_Btn.FontSize = 20;
                Massage_TxtBlock.FontSize = 20;
            }
        }
    }
}
