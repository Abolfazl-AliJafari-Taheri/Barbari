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

namespace Barbari_UI.Register_Bar_Ersali
{
    /// <summary>
    /// Interaction logic for RegisterStep1.xaml
    /// </summary>
    public partial class RegisterStep1 : UserControl
    {
        public RegisterStep1()
        {
            InitializeComponent();
        }
        public RegisterStep1(BarErsali_Tbl barErsali)
        {
            InitializeComponent();
            BarErsali = barErsali;
            edit = true;
        }
        public BarErsali_Tbl BarErsali { get; set; }
        bool edit = false;
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

        public void AddTextCmBox(object sender, EventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            if (string.IsNullOrWhiteSpace(combobox.Text))
            {
                combobox.Text = combobox.Tag.ToString();
                combobox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
            }
        }
        public void RemoveTextCmBox(object sender, EventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            if (combobox.Text == combobox.Tag.ToString())
            {
                combobox.Text = "";
                combobox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            }
        }

        private void Mobile_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        void FillComboBox()
        {
            var codes = Barbari_BLL.Customers.Select_AllCustomersCode();
            var city = Barbari_BLL.City.Select_Shahr();
            Code_CmBox.ItemsSource = codes.Data;
            CityMabda_CmBox.ItemsSource = city.Data;
            
        }

        private void BimariToggle_Checked(object sender, RoutedEventArgs e)
        {
            Code_CmBox.IsEnabled = true;
            FirstName_Txt.IsReadOnly = true;
            LastName_Txt.IsReadOnly = true;
            Mobile_Txt.IsReadOnly = true;
        }

        private void BimariToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            Code_CmBox.IsEnabled = false;
            Code_CmBox.Text = "";
            FirstName_Txt.IsReadOnly = false;
            LastName_Txt.IsReadOnly = false;
            Mobile_Txt.IsReadOnly = false;
            FirstName_Txt.Text = "";
            LastName_Txt.Text = "";
            Mobile_Txt.Text = "";
        }

        void FillCompanyData()
        {
            var company = Barbari_BLL.Company.Select();
            if (company.Success)
            {
                CityMabda_CmBox.Text = company.Data.CompanyCity;
                AnbarMabda_CmBox.Text = company.Data.CompanyName;
                CityMabda_CmBox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                AnbarMabda_CmBox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            }
        }
        void EditMode(BarErsali_Tbl barErsali)
        {
            CityMabda_CmBox.Text = barErsali.BarErsaliShahreMabda;
            AnbarMabda_CmBox.Text = barErsali.BarErsaliAnbarMabda;
            FirstName_Txt.Text = barErsali.BarErsaliNamFerestande;
            LastName_Txt.Text = barErsali.BarErsaliFamilyFerestande;
            Mobile_Txt.Text = barErsali.BarErsaliMobileFerestande;
            if(!string.IsNullOrEmpty(barErsali.BarErsaliCodeFerestande.ToString()))
            {
                BimariToggle.IsChecked = true;
                Code_CmBox.Text = barErsali.BarErsaliCodeFerestande.ToString();
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                EditMode(BarErsali);
            }
            else
            {
                FillCompanyData();
            }
            FillComboBox();

        }

        private void CityMabda_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityMabda_CmBox.SelectedItem != null)
            {
                var anbar = Barbari_BLL.City.Select_Anbar(CityMabda_CmBox.SelectedItem.ToString());
                AnbarMabda_CmBox.ItemsSource = anbar.Data;
            }
        }

        private void Code_CmBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (int.TryParse(Code_CmBox.Text, out int code))
                {
                    var result = Barbari_BLL.Customers.Select_Code(code);
                    if (result.Success)
                    {
                        FirstName_Txt.Text = result.Data[0].CustomersFirstName;
                        LastName_Txt.Text = result.Data[0].CustomersLastName;
                        Mobile_Txt.Text = result.Data[0].CustomersMobile;
                        FirstName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                        LastName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                        Mobile_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                    }
                    else
                    {
                        FirstName_Txt.Text = "";
                        LastName_Txt.Text = "";
                        Mobile_Txt.Text = "";
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show("کد مشتری باید عددی باشد");
                    FirstName_Txt.Text = "";
                    LastName_Txt.Text = "";
                    Mobile_Txt.Text = "";
                }
            }
        }

        private void Code_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Code_CmBox.SelectedItem != null)
            {
                if (int.TryParse(Code_CmBox.SelectedItem.ToString(), out int code))
                {
                    var result = Barbari_BLL.Customers.Select_Code(code);
                    if (result.Success)
                    {
                        FirstName_Txt.Text = result.Data[0].CustomersFirstName;
                        LastName_Txt.Text = result.Data[0].CustomersLastName;
                        Mobile_Txt.Text = result.Data[0].CustomersMobile;
                        //FirstName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                        //LastName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                        //Mobile_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                    }
                    else
                    {
                        FirstName_Txt.Text = "";
                        LastName_Txt.Text = "";
                        Mobile_Txt.Text = "";
                        MessageBox.Show(result.Message);
                    }
                }
                else
                {
                    MessageBox.Show("کد مشتری باید عددی باشد");
                    FirstName_Txt.Text = "";
                    LastName_Txt.Text = "";
                    Mobile_Txt.Text = "";
                }
            }
        }

        public void Registered()
        {
            BimariToggle.IsChecked = true;
            BimariToggle.IsChecked = false;
            FillCompanyData();
        }
    }
}
