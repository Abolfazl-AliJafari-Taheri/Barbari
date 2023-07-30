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
            Code_CmBox.Text = Code_CmBox.Tag.ToString();
            FirstName_Txt.IsReadOnly = false;
            LastName_Txt.IsReadOnly = false;
            Mobile_Txt.IsReadOnly = false;
        }

        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            var company = Barbari_BLL.Company.Select();
            if(company.Success)
            {
                CityMabda_CmBox.Text = company.Data.CompanyCity;
                AnbarMabda_CmBox.Text = company.Data.CompanyName;
                CityMabda_CmBox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                AnbarMabda_CmBox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            }
        }

        private void CityMabda_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var anbar = Barbari_BLL.City.Select_Anbar(CityMabda_CmBox.Text);
            AnbarMabda_CmBox.ItemsSource = anbar.Data;
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
                        MessageBox.Show(result.Message);
                    }
                }
            }
        }
    }
}
