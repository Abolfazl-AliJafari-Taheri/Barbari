using Barbari_BLL;
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
    /// Interaction logic for Ranandegan.xaml
    /// </summary>
    public partial class Ranandegan : Page
    {
        public Ranandegan()
        {
            InitializeComponent();
        }

        public void Refresh(string Search)
        {
            var ranandegan = Barbari_BLL.Ranande.Select(Search);
            if (!ranandegan.Success)
            {
                MessageBox.Show(ranandegan.Message);
            }
            else
            {
                ShowRanade_StckPnl.Children.Clear();
                foreach (Ranande_Tbl Ranande in ranandegan.Data)
                {
                    RanandeComponent ranande = new RanandeComponent(Ranande) { Height = 72, Width = 1143 };
                    ShowRanade_StckPnl.Children.Add(ranande);
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
            if (WindowsAndPages.home_Window.Role != null)
            {
                AddRanande_Btn.IsEnabled = WindowsAndPages.home_Window.Role.RanandeInsert;
            }
            else
            {
                AddRanande_Btn.IsEnabled=false;
            }
      
            Refresh(""); 
        }

        private async void AddRanande_Btn_Click(object sender, RoutedEventArgs e)
        {
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new AddRanande() { Height = 317, Width = 622 });
            Refresh("");
        }

        private void Search_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh(Search_Txt.Text);
        }
    }
}
