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

namespace Barbari_UI
{
    /// <summary>
    /// Interaction logic for RanandeComponent.xaml
    /// </summary>
    public partial class RanandeComponent : UserControl
    {
        public RanandeComponent(Ranande_Tbl ranande)
        {
            InitializeComponent();
        }
        public Ranande_Tbl Ranande{ get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Name_TxtBlock.Text = Ranande.RanandeFirstName + " " + Ranande.RanandeLastName;
            Code_TxtBlock.Text = Ranande.RanandeCodeRanande;
            MobileNum_TxtBlock.Text = Ranande.RanandeMobile;
        }
    }
}
