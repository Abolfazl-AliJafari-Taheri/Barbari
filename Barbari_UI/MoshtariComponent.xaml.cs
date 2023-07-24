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
    /// Interaction logic for MoshtariComponent.xaml
    /// </summary>
    public partial class MoshtariComponent : UserControl
    {
        public MoshtariComponent()
        {
            InitializeComponent();
        }
        public MoshtariComponent(Customers_Tbl customer)
        {
            InitializeComponent();
            Customer = customer;
        }
        public Customers_Tbl Customer { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Name_TxtBlock.Text = Customer.CustomersFirstName+ " " + Customer.CustomersLastName;
            City_TxtBlock.Text = Customer.CustomersCity;
            MobileNum_TxtBlock.Text = Customer.CustomersMobile;
            Code_TxtBlock.Text = Customer.CustomersCode.ToString();
        }

        private async void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new SubmitDelete(Customer: Customer) { Height = 160, Width = 400 });

        }

        private async void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new AddCustomer(Customer) { Height = 397, Width = 622 });
        }
    }
}
