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

namespace Barbari_UI.Register_Bar_Ersali
{
    /// <summary>
    /// Interaction logic for KalaComponent.xaml
    /// </summary>
    public partial class KalaComponent : UserControl
    {
        public KalaComponent()
        {
            InitializeComponent();
        }
        public KalaComponent(KalaDaryafti_Tbl kala)
        {
            InitializeComponent();
            Kala = kala;
        }
        public KalaDaryafti_Tbl Kala{ get; set;}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Row_TxtBlock.Text = Kala.KalaDaryaftiCodeKala.ToString();
            Name_TxtBlock.Text = Kala.KalaDaryaftiNamKala;
            Number_TxtBlock.Text = Kala.KalaDaryaftiTedadKala.ToString();
            Price_TxtBlock.Text = Kala.KalaDaryaftiArzeshKala.ToString();
        }

        private void Delte_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility= Visibility.Hidden;
        }
    }
}
