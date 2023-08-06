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

namespace Barbari_UI.Register_Bar_Ersali
{
    /// <summary>
    /// Interaction logic for TahvilRanande.xaml
    /// </summary>
    public partial class TahvilRanande : UserControl
    {
        public TahvilRanande(BarErsali_Tbl barErsali)
        {
            InitializeComponent();
            BarErsali = barErsali;
        }
        public BarErsali_Tbl BarErsali { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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
    }
}
