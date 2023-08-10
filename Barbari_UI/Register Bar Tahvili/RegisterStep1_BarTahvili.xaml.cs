using Barbari_BLL;
using Barbari_DAL;
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

namespace Barbari_UI.Register_Bar_Tahvili
{
    /// <summary>
    /// Interaction logic for RegisterStep1_BarTahvili.xaml
    /// </summary>
    public partial class RegisterStep1_BarTahvili : UserControl
    {
        public RegisterStep1_BarTahvili()
        {
            InitializeComponent();
        }
        public RegisterStep1_BarTahvili(BarTahvili_Tbl barTahvili)
        {
            InitializeComponent();
            BarTahvili = barTahvili;
            edit = true;
        }
        public BarTahvili_Tbl BarTahvili { get; set; }
        bool edit = false;

        private void Mobile_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        void FillComboBox()
        {
            var city = Barbari_BLL.City.Select_Shahr();
            CityMabda_CmBox.ItemsSource = city.Data;
        }

        void EditMode(BarTahvili_Tbl barTahvili)
        {
            CityMabda_CmBox.Text = barTahvili.BarTahviliShahrFerestande;
            FirstName_Txt.Text = barTahvili.BarTahviliNamFerestande;
            LastName_Txt.Text = barTahvili.BarTahviliFamilyFerestande;
            Mobile_Txt.Text = barTahvili.BarTahviliMobileFerestande;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                EditMode(BarTahvili);
            }
            FillComboBox();
        }

        public void Registered()
        {
            CityMabda_CmBox.Text ="";
            FirstName_Txt.Text = "";
            LastName_Txt.Text = "";
            Mobile_Txt.Text = "";
        }
    }
}
