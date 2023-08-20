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

namespace Barbari_UI.Register_Bar_Ersali
{
    /// <summary>
    /// Interaction logic for TahvilRanande.xaml
    /// </summary>
    public partial class TahvilRanande : UserControl
    {
        public TahvilRanande(BarErsali_Tbl barErsali,bool Edit)
        {
            InitializeComponent();
            BarErsali = barErsali;
            edit = Edit;
        }
        bool edit = false;
        public BarErsali_Tbl BarErsali { get; set; }
        void EditMode()
        {
            if(!string.IsNullOrEmpty(BarErsali.BarErsaliCodeRanande.ToString()))
            {
                Registered_Ranande.IsChecked = true;
                Code_CmBox.Text = BarErsali.BarErsaliCodeRanande.ToString();
            }
            FirstName_Txt.Text = BarErsali.BarErsaliNamRanande;
            LastName_Txt.Text = BarErsali.BarErsaliFamilyRanande;
            Mobile_Txt.Text = BarErsali.BarErsaliMobileRanande;
            Price_Txt.Text = BarErsali.BarErsaliKerayeRanande.ToString();
            Cancel_Btn.Visibility = Visibility.Collapsed;
            Tahvil_Btn_Border.Visibility = Visibility.Collapsed;
            Title_TxtBlock.Visibility= Visibility.Collapsed;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(edit)
            {
                EditMode(); 
            }
            var ranande = Barbari_BLL.Ranande.Select_AllRanandeCode().Data;
            Code_CmBox.ItemsSource= ranande;
        }

        private void Registered_Ranande_Checked(object sender, RoutedEventArgs e)
        {
            FirstName_Txt.Clear();
            LastName_Txt.Clear();
            Mobile_Txt.Clear();
            FirstName_Txt.IsReadOnly = true;
            LastName_Txt.IsReadOnly = true;
            Mobile_Txt.IsReadOnly = true;
            Code_CmBox.IsEnabled= true;
        }

        private void Registered_Ranande_Unchecked(object sender, RoutedEventArgs e)
        {
            FirstName_Txt.Clear();
            LastName_Txt.Clear();
            Mobile_Txt.Clear();
            FirstName_Txt.IsReadOnly = false;
            LastName_Txt.IsReadOnly = false;
            Mobile_Txt.IsReadOnly = false;
            Code_CmBox.Text = "";
            Code_CmBox.IsEnabled = false;
        }

        private void Tahvil_Btn_Click(object sender, RoutedEventArgs e)
        {
           var validation =  Barbari_BLL.Validation.BarErsali_Validation_TahvilRanande(FirstName_Txt.Text, LastName_Txt.Text, Mobile_Txt.Text, Price_Txt.Text, Code_CmBox.Text);
            if (validation.Success)
            {
                BarErsali.BarErsaliNamRanande = FirstName_Txt.Text;
                BarErsali.BarErsaliFamilyRanande = LastName_Txt.Text;
                BarErsali.BarErsaliMobileRanande = Mobile_Txt.Text;
                BarErsali.BarErsaliKerayeRanande = decimal.Parse(Price_Txt.Text);
                if((bool)Registered_Ranande.IsChecked)
                {
                    BarErsali.BarErsaliCodeRanande = int.Parse(Code_CmBox.Text);

                }
                var result = Barbari_BLL.BarErsali.Insert_TahvilBeRanande(BarErsali);
                if(result.Success)
                {
                     DialogHost.CloseDialogCommand.Execute(null, null);
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

        private void Code_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Code_CmBox.SelectedItem != null)
            {
                if (int.TryParse(Code_CmBox.SelectedItem.ToString(), out int code))
                {
                    var result = Barbari_BLL.Ranande.Select_Code(code);
                    if (result.Success)
                    {
                        FirstName_Txt.Text = result.Data[0].RanandeFirstName;
                        LastName_Txt.Text = result.Data[0].RanandeLastName;
                        Mobile_Txt.Text = result.Data[0].RanandeMobile;
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
                    MessageBox.Show("کد راننده باید عددی باشد");
                    FirstName_Txt.Text = "";
                    LastName_Txt.Text = "";
                    Mobile_Txt.Text = "";
                }
            }
        }

        private void Code_CmBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (int.TryParse(Code_CmBox.Text, out int code))
                {
                    var result = Barbari_BLL.Ranande.Select_Code(code);
                    if (result.Success)
                    {
                        FirstName_Txt.Text = result.Data[0].RanandeFirstName;
                        LastName_Txt.Text = result.Data[0].RanandeLastName;
                        Mobile_Txt.Text = result.Data[0].RanandeMobile;
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

        private void Mobile_Txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
