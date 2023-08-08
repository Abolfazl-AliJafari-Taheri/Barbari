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
    /// Interaction logic for BarErsali.xaml
    /// </summary>
    public partial class BarErsali : Page
    {
        public BarErsali()
        {
            InitializeComponent();
        }
        public void Refresh(string search = "")
        {
            var barErsali = Barbari_BLL.BarErsali.Select(search);
            if (!barErsali.Success)
            {
                MessageBox.Show(barErsali.Message);
            }
            else
            {
                ShowRanade_StckPnl.Children.Clear();
                foreach (BarErsali_Tbl BarErsali in barErsali.Data)
                {
                    BarErsaliComponent barersali = new BarErsaliComponent(BarErsali) { Height = 72, Width = 1143 };
                    ShowRanade_StckPnl.Children.Add(barersali);
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
            if(WindowsAndPages.home_Window.Role != null)
            {
                Add_Btn.IsEnabled = WindowsAndPages.home_Window.Role.BarErsaliInsert;
            }
            else
            {
                Add_Btn.IsEnabled = false;

            }
            Refresh();
        }

        private async void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            WindowsAndPages.registerBarErsali = new Register_Bar_Ersali.Register_Form();
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(WindowsAndPages.registerBarErsali);
            if(WindowsAndPages.registerBarErsali.inserted)
            {
                Refresh();
            }
        }

        private void Search_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh(Search_Txt.Text);
        }
    }
}
