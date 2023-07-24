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
    /// Interaction logic for Karmand.xaml
    /// </summary>
    public partial class Karmand : Page
    {
        public Karmand()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            var karmandan = Barbari_BLL.Users.Select();
            if (!karmandan.Success)
            {
                MessageBox.Show(karmandan.Message);
            }
            else
            {
                ShowRanade_StckPnl.Children.Clear();
                foreach (Users_Tbl Karmand in karmandan.Data)
                {
                    KarmandComponent karmand = new KarmandComponent(Karmand) { Height = 72, Width = 1143 };
                    ShowRanade_StckPnl.Children.Add(karmand);
                }
            }
        }
        public void Search(string Search)
        {
            var karmandan = Barbari_BLL.Users.Select(Search);
            if (!karmandan.Success)
            {
                MessageBox.Show(karmandan.Message);
            }
            else
            {
                ShowRanade_StckPnl.Children.Clear();
                foreach (Users_Tbl Karmand in karmandan.Data)
                {
                    KarmandComponent karmand = new KarmandComponent(Karmand) { Height = 72, Width = 1143 };
                    ShowRanade_StckPnl.Children.Add(karmand);
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
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new AddKarmand() { Height = 397, Width = 622 });
            Refresh();
        }

        private void Search_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Search_Txt.Text != Search_Txt.Tag.ToString())
            {
                Search(Search_Txt.Text);
            }
        }
    }
}
