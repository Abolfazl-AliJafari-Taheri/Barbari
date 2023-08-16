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
    /// Interaction logic for KalaTahviliComponent.xaml
    /// </summary>
    public partial class KalaTahviliComponent : UserControl
    {
        public KalaTahviliComponent()
        {
            InitializeComponent();
        }
        public KalaTahviliComponent(KalaTahvili_Tbl kala, int row, bool Edit)
        {
            InitializeComponent();
            Kala = kala;
            Row = row;
            edit = Edit;
        }
        bool edit;
        public KalaTahvili_Tbl Kala { get; set; }
        public int Row { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                if (WindowsAndPages.home_Window.Role != null)
                {
                    Delte_Btn.IsEnabled = WindowsAndPages.home_Window.Role.BarTahviliUpdate;
                }
                else
                {
                    Delte_Btn.IsEnabled = false;
                }
            }
            //Row_TxtBlock.Text = Kala.KalaDaryaftiCodeKala.ToString();
            Row_TxtBlock.Text = Row.ToString();
            Name_TxtBlock.Text = Kala.KalaTahviliNamKala;
            Number_TxtBlock.Text = Kala.KalaTahviliTedadKala.ToString();
        }

        private async void Delte_Btn_Click(object sender, RoutedEventArgs e)
        {
           if (!edit)
           {
               this.Visibility = Visibility.Collapsed;
               WindowsAndPages.registerBarTahvili.step4.refreshKala();
           }
            else
            {
                await WindowsAndPages.editFormBarTahvili.step4.DialogHost.ShowDialog(new SubmitDelete(CodeBarKalaTahvili: Kala.KalaTahviliCodeBar, CodeKalaTahvili: Kala.KalaTahviliCodeKala) { Height = 160, Width = 400 });
                WindowsAndPages.editFormBarTahvili.step4.RefreshKala();
            }

        }
    }
}
