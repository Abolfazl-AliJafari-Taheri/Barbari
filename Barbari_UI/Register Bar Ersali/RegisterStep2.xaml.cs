using Barbari_BLL;
using Barbari_DAL;
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

namespace Barbari_UI.Register_Bar_Ersali
{
    /// <summary>
    /// Interaction logic for RegisterStep2.xaml
    /// </summary>
    public partial class RegisterStep2 : UserControl
    {
        public RegisterStep2()
        {
            InitializeComponent();
        }
        public RegisterStep2(BarErsali_Tbl barErsali)
        {
            InitializeComponent();
            BarErsali = barErsali;
            edit = true;
        }
        bool edit = false;
        public BarErsali_Tbl BarErsali{ get; set; }
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
        void FillComboBox()
        {
            var city = Barbari_BLL.City.Select_Shahr();
            CityMaghsadFinal_CmBox.ItemsSource = city.Data;
            CityMaghsad_CmBox.ItemsSource = city.Data;
        }
        private void AddSecondMaghsadToggle_Checked(object sender, RoutedEventArgs e)
        {
            AnbarMaghsadFinal_CmBox_Border.Visibility = Visibility.Visible;
            CityMaghsadFinal_CmBox_Border.Visibility = Visibility.Visible;
        }

        private void AddSecondMaghsadToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            AnbarMaghsadFinal_CmBox.Text = "";
            CityMaghsadFinal_CmBox.Text = "";
            AnbarMaghsadFinal_CmBox_Border.Visibility = Visibility.Collapsed;
            CityMaghsadFinal_CmBox_Border.Visibility = Visibility.Collapsed;
        }

        private void CityMaghsad_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(CityMaghsad_CmBox.SelectedItem != null)
            {
                var anbar = Barbari_BLL.City.Select_Anbar(CityMaghsad_CmBox.SelectedItem.ToString());
                AnbarMaghsad_CmBox.ItemsSource = anbar.Data;
            }
      
        }

        private void CityMaghsadFinal_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityMaghsadFinal_CmBox.SelectedItem != null)
            {
                var anbar = Barbari_BLL.City.Select_Anbar(CityMaghsadFinal_CmBox.SelectedItem.ToString());
                AnbarMaghsadFinal_CmBox.ItemsSource = anbar.Data;
            }
        }
        void EditMode(BarErsali_Tbl barErsali)
        {
            CityMaghsad_CmBox.Text = barErsali.BarErsaliShahreMaghsad1;
            AnbarMaghsad_CmBox.Text = barErsali.BarErsaliAnbarMaghsad1;
            if(!string.IsNullOrEmpty(barErsali.BarErsaliShahreMaghsad2) && !string.IsNullOrEmpty(barErsali.BarErsaliAnbarMaghsad2))
            {
                AddSecondMaghsadToggle.IsChecked = true;
                CityMaghsadFinal_CmBox.Text = barErsali.BarErsaliShahreMaghsad2;
                AnbarMaghsadFinal_CmBox.Text = barErsali.BarErsaliAnbarMaghsad2;
            }
            FirstName_Txt.Text = barErsali.BarErsaliNamGerande;
            LastName_Txt.Text = barErsali.BarErsaliFamilyGerande;
            Mobile_Txt.Text = barErsali.BarErsaliMobileGerande;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(edit)
            {
                EditMode(BarErsali);
            }
            FillComboBox();
        }
        
        public void Registered()
        {
            AddSecondMaghsadToggle.IsChecked = false;
            FirstName_Txt.Clear();
            LastName_Txt.Clear();
            Mobile_Txt.Clear();
            AnbarMaghsad_CmBox.Text = "";
            CityMaghsad_CmBox.Text = "";

        }

        private void Mobile_Txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
