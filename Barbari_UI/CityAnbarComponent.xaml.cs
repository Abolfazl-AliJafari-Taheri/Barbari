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
    /// Interaction logic for CityAnbarComponent.xaml
    /// </summary>
    public partial class CityAnbarComponent : UserControl
    {
        public CityAnbarComponent()
        {
            InitializeComponent();
        }
        public CityAnbarComponent(City_Tbl anbar)
        {
            InitializeComponent();
            Anbar = anbar;
        }
        public City_Tbl Anbar { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Delete_Btn.IsEnabled = WindowsAndPages.home_Window.Role.CityDelete;
            Edit_Btn.IsEnabled = WindowsAndPages.home_Window.Role.CityUpdate;
            AnbarName_TxtBlock.Text = Anbar.CityAnbar;
            City_TxtBlock.Text = Anbar.CityShahr;
            Address_TxtBlock.Text = Anbar.CityAdres;
            PhoneNum_TxtBlock.Text = Anbar.CityMobile;
        }

        private async void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new SubmitDelete(City: Anbar) { Height = 160, Width = 400 });

        }

        private async void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new AddAnbar(Anbar) { Height = 309, Width = 622 });

        }
    }
}
