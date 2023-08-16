using Barbari_DAL;
using Barbari_UI.Edit_Bar_Ersali;
using Barbari_UI.Register_Bar_Ersali;
using Barbari_UI.Register_Bar_Tahvili;
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
    /// Interaction logic for BarTahviliComponent.xaml
    /// </summary>
    public partial class BarTahviliComponent : UserControl
    {
        public BarTahviliComponent()
        {
            InitializeComponent();
        }
        public BarTahviliComponent(BarTahvili_Tbl bartahvili)
        {
            InitializeComponent();
            BarTahvili = bartahvili;
        }
        public BarTahvili_Tbl BarTahvili { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (WindowsAndPages.home_Window.Role != null)
            {
                Delete_Btn.IsEnabled = WindowsAndPages.home_Window.Role.BarTahviliDelete;
                Thvil_Btn.IsEnabled = WindowsAndPages.home_Window.Role.BarTahviliUpdate;
            }
            else
            {
                Thvil_Btn.IsEnabled = false;
                Delete_Btn.IsEnabled = false;
                Thvil_Btn.IsEnabled = false;
            }

            Sender_TxtBlock.Text = BarTahvili.BarTahviliNamFerestande + " " + BarTahvili.BarTahviliFamilyFerestande;
            Reciever_TxtBlock.Text = BarTahvili.BarTahviliFamilyGerande + " " + BarTahvili.BarTahviliNamGerande;
            Mabda_TxtBlock.Text = BarTahvili.BarTahviliShahrFerestande;

            StatusChange();
        }
        bool CheckStatus()
        {
            if (!(String.IsNullOrEmpty(BarTahvili.BarTahviliRaveshEhrazHoviatText)))
            {
                return true;
            }
            return false;
        }
        void StatusChange()
        {
            if (CheckStatus())
            {
                Status_TxtBlock.Text = "تحویل مشتری";
                Thvil_Btn.Content = "برگشت به انبار";
                Status_Lbl.Foreground = ConverterColor("#079459");
                Status_Lbl.Background = ConverterColor("#ACDBC8");
            }
            else
            {
                Status_TxtBlock.Text = "موجود در انبار";
                Thvil_Btn.Content = "تحویل به مشتری";
                Status_Lbl.Foreground = ConverterColor("#2B54A3");
                Status_Lbl.Background = ConverterColor("#B8C6E0");
                if (WindowsAndPages.home_Window.Role != null)
                {
                    if (WindowsAndPages.home_Window.Role.BarErsaliUpdate)
                    {
                        Thvil_Btn.IsEnabled = true;
                    }
                }
                else
                {
                    Thvil_Btn.IsEnabled = false;
                }



            }
        }
        Brush ConverterColor(string ColorCode)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(ColorCode));
        }
        private async void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(new SubmitDelete(BarTahvili: BarTahvili) { Height = 160, Width = 400 });
        }

        private async void Thvil_Btn_Click(object sender, RoutedEventArgs e)
        {
            string content = Thvil_Btn.Content.ToString();
            if (content == "تحویل به مشتری")
            {
                await WindowsAndPages.home_Window.DialogHost.ShowDialog(new TahvilCustomer(BarTahvili,false) { Height = 237, Width = 750 });

            }
            else
            {
                await WindowsAndPages.home_Window.DialogHost.ShowDialog(new SubmitDelete(CodeBar: BarTahvili.BarTahviliCodeBar) { Height = 160, Width = 400 });
            }
            WindowsAndPages.barErsali.Refresh("");
        }

        private async void More_Btn_Click(object sender, RoutedEventArgs e)
        {
            WindowsAndPages.editFormBarTahvili = new Edit_Bar_Tahvili.EditForm_BarTahvili(BarTahvili);
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(WindowsAndPages.editFormBarTahvili);
            WindowsAndPages.barTahvili.Refresh("");
        }
    }
}
