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

namespace Barbari_UI.Register_Bar_Tahvili
{
    /// <summary>
    /// Interaction logic for RegisterStep3_BarTahvili.xaml
    /// </summary>
    public partial class RegisterStep3_BarTahvili : UserControl
    {
        public RegisterStep3_BarTahvili()
        {
            InitializeComponent();
        }
        public RegisterStep3_BarTahvili(BarTahvili_Tbl barTahvili, bool Edit)
        {
            InitializeComponent();
            BarTahvili = barTahvili;
            edit = Edit;
        }
        bool edit = false;
        public BarTahvili_Tbl BarTahvili { get; set; }
        void EditMode()
        {
            FirstName_Txt.Text = BarTahvili.BarTahviliNamRanande;
            LastName_Txt.Text = BarTahvili.BarTahviliFamilyRanande;
            Mobile_Txt.Text = BarTahvili.BarTahviliMobileRanande;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                EditMode();
            }
        }
         
        public void Registered()
        {
            FirstName_Txt.Clear();
            LastName_Txt.Clear();
            Mobile_Txt.Clear();
        }
    }
}
