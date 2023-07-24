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
    /// Interaction logic for CityAnbar.xaml
    /// </summary>
    public partial class CityAnbar : Page
    {
        public CityAnbar()
        {
            InitializeComponent();
        }
        public void Refresh()
        {
            var anbars = Barbari_BLL.City.Select();
            if (!anbars.Success)
            {
                MessageBox.Show(anbars.Message);
            }
            else
            {
                ShowRanade_StckPnl.Children.Clear();
                foreach (City_Tbl Anbar in anbars.Data)
                {
                    CityAnbarComponent anbar = new CityAnbarComponent(Anbar) { Height = 72, Width = 1143 };
                    ShowRanade_StckPnl.Children.Add(anbar);
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
            Refresh();
        }

        private async void AddRanande_Btn_Click(object sender, RoutedEventArgs e)
        {
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new AddAnbar() { Height = 309, Width = 622 });
            Refresh();
        }
    }
}
