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
        public KalaComponent(KalaDaryafti_Tbl kala,int row,bool Edit)
        {
            InitializeComponent();
            Kala = kala;
            Row= row;
            edit = Edit;
        }
        bool edit;
        public KalaDaryafti_Tbl Kala{ get; set;}
        public int Row { get; set; }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(edit)
            {
                if(WindowsAndPages.home_Window.Role != null)
                {
                    Delte_Btn.IsEnabled = WindowsAndPages.home_Window.Role.BarErsaliUpdate;
                }
                else
                {
                    Delte_Btn.IsEnabled = false;
                }
            }
            //Row_TxtBlock.Text = Kala.KalaDaryaftiCodeKala.ToString();
            Row_TxtBlock.Text = Row.ToString();
            Name_TxtBlock.Text = Kala.KalaDaryaftiNamKala;
            Number_TxtBlock.Text = Kala.KalaDaryaftiTedadKala.ToString();
            Price_TxtBlock.Text = Kala.KalaDaryaftiArzeshKala.ToString();
        }

        private async void Delte_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(!edit)
            {
                this.Visibility = Visibility.Collapsed;
                WindowsAndPages.registerBarErsali.step3.refreshKala();
            }
            else
            {
                await WindowsAndPages.editFormBarErsali.step3.DialogHost.ShowDialog(new SubmitDelete(CodeBarnameKalaDaryafti:Kala.KalaDaryaftiBarname,CodeKalaDaryafti:Kala.KalaDaryaftiCodeKala) { Height = 160, Width = 400 });
                WindowsAndPages.editFormBarErsali.step3.RefreshKala();
            }
          
        }
    }
}
