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
    /// Interaction logic for AddAnbar.xaml
    /// </summary>
    public partial class AddAnbar : UserControl
    {
        public AddAnbar()
        {
            //City = new City_Tbl();
            InitializeComponent();
        }
        //public AddAnbar(City_Tbl city)
        //{
        //    City = city;
        //    InitializeComponent();

        //}
        //public City_Tbl City { get; set; }
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
                textBox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Validait())
            {
                City_Tbl anbar = new City_Tbl();
                anbar.CityAnbar = AnbarName_Txt.Text;
                anbar.CityShahr = City_Txt.Text;
                var result = Barbari_BLL.City.Insert(anbar);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    AnbarName_Txt.Text = AnbarName_Txt.Tag.ToString();
                    City_Txt.Text = City_Txt.Tag.ToString();
                    AnbarName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    City_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //foreach (object control in Field_Grid.Children)
                    //{
                    //    if (control is Border)
                    //    {
                    //        if ((control as Border).Child is TextBox)
                    //        {
                    //            (((control as Border).Child) as TextBox).Text = (control as TextBox).Tag.ToString();
                    //            (((control as Border).Child) as TextBox).Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //        }
                    //    }
                    //}

                }
            }
            else
            {
                MessageBox.Show("تمامی فیلد ها باید وارد شوند");
            }

        }
        bool Validait()
        {
            if (AnbarName_Txt.Text == AnbarName_Txt.Tag.ToString())
            {
                return false;
            }
            if (City_Txt.Text == City_Txt.Tag.ToString())
            {
                return false;
            }
            return true;
        }
    }
}
