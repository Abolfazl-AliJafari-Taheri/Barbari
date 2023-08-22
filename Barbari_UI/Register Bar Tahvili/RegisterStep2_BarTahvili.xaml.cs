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
    /// Interaction logic for RegisterStep2_BarTahvili.xaml
    /// </summary>
    public partial class RegisterStep2_BarTahvili : UserControl
    {
        public RegisterStep2_BarTahvili()
        {
            InitializeComponent();
        }
        public RegisterStep2_BarTahvili(BarTahvili_Tbl barTahvili)
        {
            InitializeComponent();
            BarTahvili = barTahvili;
            edit = true;
        }
        bool edit = false;
        public BarTahvili_Tbl BarTahvili { get; set; }
        void FillComboBox()
        {
            var city = Barbari_BLL.City.Select_Shahr();
            CityMaghsad_CmBox.ItemsSource = city.Data;
        }

        private void CityMaghsad_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        void EditMode(BarTahvili_Tbl barTahvili)
        {
            CityMaghsad_CmBox.Text = barTahvili.BarTahviliShahrGerande;
            FirstName_Txt.Text = barTahvili.BarTahviliNamGerande;
            LastName_Txt.Text = barTahvili.BarTahviliFamilyGerande;
            Mobile_Txt.Text = barTahvili.BarTahviliMobileGerande;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CityMaghsad_CmBox.Text = WindowsAndPages.home_Window.Company.CompanyCity;
            if (edit)
            {
                EditMode(BarTahvili);
            }
            FillComboBox();
        }

        public void Registered()
        {
            FirstName_Txt.Clear();
            LastName_Txt.Clear();
            Mobile_Txt.Clear();
            CityMaghsad_CmBox.Text = "";
        }
    }
}
