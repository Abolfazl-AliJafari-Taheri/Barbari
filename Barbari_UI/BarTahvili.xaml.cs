using Barbari_DAL;
using MaterialDesignColors;
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

namespace Barbari_UI
{
    /// <summary>
    /// Interaction logic for BarTahvili.xaml
    /// </summary>
    public partial class BarTahvili : Page
    {
        public BarTahvili()
        {
            InitializeComponent();
        }

        private void Search_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh(Search_Txt.Text);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh("");
        }
        public void Refresh(string search)
        {
            var barErsali = Barbari_BLL.BarTahvili.Select(search);
            if (!barErsali.Success)
            {
                MessageBox.Show(barErsali.Message);
            }
            else
            {
                ShowRanade_StckPnl.Children.Clear();
                foreach (BarTahvili_Tbl BarTahvili in barErsali.Data)
                {
                    BarTahviliComponent bartahvili = new BarTahviliComponent(BarTahvili) { Height = 72, Width = 1143 };
                    ShowRanade_StckPnl.Children.Add(bartahvili);
                }
            }


        }
        private async void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            WindowsAndPages.registerBarTahvili = new Register_Bar_Tahvili.RegisterForm_BarTahvili();
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(WindowsAndPages.registerBarTahvili);
            if (WindowsAndPages.registerBarTahvili.inserted)
            {
                Refresh("");
            }
        }
    }
}
