using Barbari_DAL;
using Barbari_UI.Edit_Bar_Ersali;
using Barbari_UI.Register_Bar_Ersali;
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
    /// Interaction logic for BarErsaliComponent.xaml
    /// </summary>
    public partial class BarErsaliComponent : UserControl
    {
        public BarErsaliComponent()
        {
            InitializeComponent();
        }
        public BarErsaliComponent(BarErsali_Tbl barersali)
        {
            InitializeComponent();
            BarErsali = barersali;
        }
        public BarErsali_Tbl BarErsali{ get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Delete_Btn.IsEnabled = WindowsAndPages.home_Window.Role.BarErsaliDelete;
            Thvil_Btn.IsEnabled = WindowsAndPages.home_Window.Role.BarErsaliUpdate;
            Sender_TxtBlock.Text = BarErsali.BarErsaliNamFerestande+" "+BarErsali.BarErsaliFamilyFerestande;
            Reciever_TxtBlock.Text = BarErsali.BarErsaliNamGerande+" "+BarErsali.BarErsaliFamilyGerande;
            Destination_TxtBlock.Text = BarErsali.BarErsaliShahreMaghsad1;
            StatusChange();
        }
        bool CheckStatus()
        {
            if(!(String.IsNullOrEmpty(BarErsali.BarErsaliNamRanande)))
            {
                return true;
            }
            return false;
        }
        void StatusChange()
        {
            if (CheckStatus())
            {
                Status_TxtBlock.Text = "تحویل شده";
                Status_Lbl.Foreground = ConverterColor("#079459");
                Status_Lbl.Background = ConverterColor("#ACDBC8");
                Thvil_Btn.IsEnabled = false;
                Thvil_Btn.IsEnabled = false;
            }
            else
            {
                Status_TxtBlock.Text = "موجود در انبار";
                Status_Lbl.Foreground = ConverterColor("#2B54A3");
                Status_Lbl.Background = ConverterColor("#B8C6E0");
                Thvil_Btn.IsEnabled = true;
                Thvil_Btn.IsEnabled = true;

            }
        }
        Brush ConverterColor(string ColorCode)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(ColorCode));
        }
        private async void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new SubmitDelete(BarErsali: BarErsali) { Height = 160, Width = 400 });
            
        }

        private async void Thvil_Btn_Click(object sender, RoutedEventArgs e)
        {
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new TahvilRanande(BarErsali,false) { Height = 453, Width = 622 });
            WindowsAndPages.barErsali.Refresh("");
        }

        private async void More_Btn_Click(object sender, RoutedEventArgs e)
        {
            WindowsAndPages.editFormBarErsali = new EditForm(BarErsali);
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(WindowsAndPages.editFormBarErsali);
            WindowsAndPages.barErsali.Refresh("");
        }
    }
}
