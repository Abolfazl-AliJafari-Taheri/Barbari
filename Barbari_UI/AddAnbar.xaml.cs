using Barbari_BLL;
using Barbari_DAL;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddAnbar.xaml
    /// </summary>
    public partial class AddAnbar : UserControl
    {
        public AddAnbar()
        {
            City = new City_Tbl();
            InitializeComponent();
        }
        public AddAnbar(City_Tbl city)
        {
            City = city;
            edit = true;
            InitializeComponent();
        }
        public City_Tbl City { get; set; }
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
        void EditMode(City_Tbl city)
        {
            Title_TxtBlock.Text = "ویرایش مشتری ثابت";
            City_Txt.Text = city.CityShahr;
            AnbarName_Txt.Text = city.CityAnbar;
            PhoneNum_Txt.Text = city.CityMobile;
            Address_Txt.Text = city.CityAdres;
            Add_Btn.Content = "ویرایش انبار";
            City_Txt.IsReadOnly = true;
            AnbarName_Txt.IsReadOnly = true;
            //City_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //AnbarName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //PhoneNum_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //Address_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                EditMode(City);
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                City.CityAdres = Address_Txt.Text;
                City.CityMobile = PhoneNum_Txt.Text;
                var result = Barbari_BLL.City.Update(City);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    WindowsAndPages.cityAnbar.Refresh("");
                    DialogHost.CloseDialogCommand.Execute(null, null);
                }

            }
            else
            {
                City_Tbl anbar = new City_Tbl();
                anbar.CityAnbar = AnbarName_Txt.Text;
                anbar.CityShahr = City_Txt.Text;
                anbar.CityAdres = Address_Txt.Text;
                anbar.CityMobile = PhoneNum_Txt.Text;
                var result = Barbari_BLL.City.Insert(anbar);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    AnbarName_Txt.Text = "";
                    City_Txt.Text = "";
                    Address_Txt.Text = "";
                    PhoneNum_Txt.Text = "";
                    //AnbarName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //City_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //Address_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //PhoneNum_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));


                }
            }
        }

        private void AnbarName_Txt_GotFocus(object sender, RoutedEventArgs e)
        {
            if(edit)
            {
                WarningName_TxtBlock.Visibility = Visibility.Visible;
            }
        }

        private void AnbarName_Txt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                WarningName_TxtBlock.Visibility = Visibility.Hidden;
            }
        }

        private void City_Txt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                WarningCity_TxtBlock.Visibility = Visibility.Visible;
            }
        }

        private void City_Txt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                WarningCity_TxtBlock.Visibility = Visibility.Hidden;
            }
        }

        private void PhoneNum_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PhoneNum_Txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        //bool Validait()
        //{
        //    if (AnbarName_Txt.Text == AnbarName_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    if (City_Txt.Text == City_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    if (Address_Txt.Text == Address_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    if (PhoneNum_Txt.Text == PhoneNum_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
