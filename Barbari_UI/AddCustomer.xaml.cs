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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : UserControl
    {
        public AddCustomer()
        {
            Customer = new Customers_Tbl();
            InitializeComponent();
        }
        public AddCustomer(Customers_Tbl customer)
        {
            Customer = customer;
            edit = true;
            InitializeComponent();

        }
        bool edit = false;
        public Customers_Tbl Customer { get; set; }
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

        List<string> citys = new List<string>()
        { 
            "کاشان",
            "تهران",
            "اصفهان",
            "مشهد",
            "تبریز",
            "قم",
            "شیراز",
            "قزوین",
            "شهریار",
            "سمنان",
            "گیلان",
            "مازندران",
            "فارس",
            "خوزستان",
            "کرمانشاه",
            "گرگان",
            "همدان",
            "یزد",
            "گلستان",
            "کرج",
            "اهواز",
            "ارومیه",
            "رشت",
            "زاهدان",
            "سنندج",
            "بندرعباس",
            "اردبیل",
            "اراک",
            "ساری",
            "بیرجند",
            "ساوه",
            "پردیس",
            "بوشهر",
            "رامسر",
            "انزلی"
        };

        void EditMode(Customers_Tbl customer)
        {
            Title_TxtBlock.Text = "ویرایش مشتری ثابت";
            FirstName_Txt.Text = customer.CustomersFirstName;
            LastName_Txt.Text = customer.CustomersLastName;
            Code_Txt.Text = customer.CustomersCode.ToString();
            Mobile_Txt.Text = customer.CustomersMobile;
            //int index = City_Txt.Items.IndexOf(customer.CustomersCity);
            //if (index <0)
            //{
            //    City_Txt.SelectedIndex= index;
            //}
            //else
            //{
                City_Txt.Text = customer.CustomersCity;
            //}
          
            Add_Btn.Content = "ویرایش مشتری";
            Code_Txt.IsReadOnly = true;
            //FirstName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //LastName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //Code_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //City_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //Mobile_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                EditMode(Customer);
            }
            else
            {
                Code_Txt.Text = (Barbari_BLL.Customers.Select_CodeLast().Data+1).ToString();
            }
            City_Txt.ItemsSource = citys;
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                Customer.CustomersFirstName = FirstName_Txt.Text;
                Customer.CustomersLastName = LastName_Txt.Text;
                Customer.CustomersCity = City_Txt.Text;
                Customer.CustomersMobile = Mobile_Txt.Text;
                var result = Barbari_BLL.Customers.Update(Customer);
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
            else
            {
                Customers_Tbl Customer = new Customers_Tbl();
                Customer.CustomersFirstName = FirstName_Txt.Text;
                Customer.CustomersLastName = LastName_Txt.Text;
                Customer.CustomersCity = City_Txt.Text.Trim();
                Customer.CustomersMobile = Mobile_Txt.Text;
                var result = Barbari_BLL.Customers.Insert(Customer);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    FirstName_Txt.Text = "";
                    LastName_Txt.Text = "";
                    Code_Txt.Text = (Barbari_BLL.Customers.Select_CodeLast().Data + 1).ToString();

                    City_Txt.Text = "";
                    Mobile_Txt.Text = "";
                    //FirstName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //LastName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //Code_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //City_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //Mobile_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //foreach (object control in Field_Grid.Children)
                    //{
                    //    if (control is Border)
                    //    {
                    //        if ((control as Border).Child is TextBox)
                    //        {
                    //            (((control as Border).Child) as TextBox).Text = (control as TextBox).Tag.ToString();
                    //            (((control as Border).Child) as TextBox).Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //        }
                    //    }
                    //}
                }
            }
        }
        //bool Validait()
        //{
        //    if (FirstName_Txt.Text == FirstName_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    if (LastName_Txt.Text == LastName_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    if (Code_Txt.Text == Code_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    if (City_Txt.Text == City_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    if (Mobile_Txt.Text == Mobile_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        private void City_Txt_GotFocus(object sender, RoutedEventArgs e)
        {
            ComboBox combobox= (ComboBox)sender;
            if (combobox.Text == combobox.Tag.ToString())
            {
                combobox.Text = "";
                combobox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            }
        }

        private void City_Txt_LostFocus(object sender, RoutedEventArgs e)
        {

            ComboBox combobox = (ComboBox)sender;
            if (string.IsNullOrWhiteSpace(combobox.Text))
            {
                combobox.Text = combobox.Tag.ToString();
                combobox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
            }
        }
    }
}
