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

namespace Barbari_UI
{
    /// <summary>
    /// Interaction logic for Moshtari.xaml
    /// </summary>
    public partial class Moshtari : Page
    {
        public Moshtari()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            var moshtariyan = Barbari_BLL.Customers.Select();
            if (!moshtariyan.Success)
            {
                MessageBox.Show(moshtariyan.Message);
            }
            else
            {
                ShowRanade_StckPnl.Children.Clear();
                foreach (Customers_Tbl Moshtari in moshtariyan.Data)
                {
                    MoshtariComponent moshtari = new MoshtariComponent(Moshtari) { Height = 72, Width = 1143 };
                    ShowRanade_StckPnl.Children.Add(moshtari);
                }
            }
        }
        public void Search(string Search)
        {
            var moshtariyan = Barbari_BLL.Customers.Select(Search);
            if (!moshtariyan.Success)
            {
                MessageBox.Show(moshtariyan.Message);
            }
            else
            {
                ShowRanade_StckPnl.Children.Clear();
                foreach (Customers_Tbl Moshtari in moshtariyan.Data)
                {
                    MoshtariComponent moshtari = new MoshtariComponent(Moshtari) { Height = 72, Width = 1143 };
                    ShowRanade_StckPnl.Children.Add(moshtari);
                }
            }
        }
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
                textBox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#BFBFBF"));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Add_Btn.IsEnabled = WindowsAndPages.home_Window.Role.CustomersInsert;
            Refresh();
        }


        private async void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new AddCustomer() { Height = 397, Width = 622 });
            Refresh();
        }

        private void Search_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
                Search(Search_Txt.Text);
        }
    }
}
