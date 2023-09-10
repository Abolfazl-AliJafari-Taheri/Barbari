using Barbari_DAL;
using Barbari_UI.Register_Bar_Ersali;
using FormComponent;
using PersianToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Barbari_UI.Register_Bar_Tahvili
{
    /// <summary>
    /// Interaction logic for RegisterStep4_BarTahvili.xaml
    /// </summary>
    public partial class RegisterStep4_BarTahvili : UserControl
    {
        public RegisterStep4_BarTahvili()
        {
            InitializeComponent();
        }
        public RegisterStep4_BarTahvili(BarTahvili_Tbl barTahvili)
        {
            InitializeComponent();
            BarTahvili = barTahvili;
            edit = true;
        }
        public BarTahvili_Tbl BarTahvili { get; set; }
        bool edit = false;
        int row = 1;

        private void PrintToggle_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void PrintToggle_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        public List<KalaTahvili_Tbl> GetKalas()
        {
            List<KalaTahvili_Tbl> Kalas = new List<KalaTahvili_Tbl>();
            foreach (KalaTahviliComponent kala in ShowKala_StckPnl.Children)
            {
                if (kala.Visibility == Visibility.Visible)
                {
                    Kalas.Add(kala.Kala);
                }
            }
            return Kalas;
        }
        public void refreshKala()
        {
            int Row = 1;
            for (int i = 0; i < ShowKala_StckPnl.Children.Count; i++)
            {

                if ((ShowKala_StckPnl.Children[i] as KalaTahviliComponent).Visibility == Visibility.Visible)
                {
                    (ShowKala_StckPnl.Children[i] as KalaTahviliComponent).Row_TxtBlock.Text = Row.ToString();
                    Row++;
                }
            }
        }

        private void AddKala_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result = Barbari_BLL.Validation.BarTahvili_Validation_KalaTahvili(KalaName_Txt.Text, KalaNumber_Txt.Text);
            if (result.Success)
            {

                    KalaTahvili_Tbl kala = new KalaTahvili_Tbl()
                    {
                        KalaTahviliNamKala = KalaName_Txt.Text,
                        KalaTahviliTedadKala = int.Parse(KalaNumber_Txt.Text),
                    };
                    if (edit)
                    {
                    kala.KalaTahviliCodeBar = BarTahvili.BarTahviliCodeBar;
                        var resultInsertKala = Barbari_BLL.BarTahvili.Insert_KalaTahvili(kala);
                        if (resultInsertKala.Success)
                        {
                            ShowKala_StckPnl.Children.Add(new KalaTahviliComponent(kala, row, edit)
                            { Height = 72, Width = 558 });
                            var resultUpdateKarmand = Barbari_BLL.BarTahvili.Update_BarTahviliUserNameKarmand(BarTahvili.BarTahviliCodeBar, WindowsAndPages.home_Window.User.UsersUserName);
                            if (!resultUpdateKarmand.Success)
                            {
                                MessageBox.Show(resultUpdateKarmand.Message);
                            }
                            KalaName_Txt.Clear();
                            KalaNumber_Txt.Clear();
                            row++;
                        }
                        else
                        {
                            MessageBox.Show(resultInsertKala.Message);
                        }

                    }
                    else
                    {
                        ShowKala_StckPnl.Children.Add(new KalaTahviliComponent(kala, row, edit)
                        { Height = 72, Width = 558 });
                        KalaName_Txt.Clear();
                        KalaNumber_Txt.Clear();
                        row++;

                    }
               
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
        void GetCodeBraname()
        {
            var code = Barbari_BLL.BarErsali.Select_Barname_Last();
            if (code.Success)
            {
                CodeBarname_Txt.Text = (code.Data + 1).ToString();

            }
            else
            {
                MessageBox.Show(code.Message);
            }
        }
        void FillDateTime()
        {
            //DateSodor_DtPicker.SelectedDate = DateTime.Now;
            //DateSodor_DtPicker.Text = ConvertDate.MiladiToShamsiNumberDate((DateTime)DateSodor_DtPicker.SelectedDate);
            //dateLoaded = true;
            HourSodor_TmPicker.SelectedTime = DateTime.Now;
        }
        void EditMode(BarTahvili_Tbl barTahvili)
        {
            RefreshKala();
            CodeBarname_Txt.Text = barTahvili.BarTahviliBarname.ToString();
            AnbarDari_Txt.Text = barTahvili.BarTahviliAnbardari.ToString();
            BasteBandi_Txt.Text = barTahvili.BarTahviliBastebandi.ToString();
            Shahri_Txt.Text = barTahvili.BarTahviliShahri.ToString();
            Bime_Txt.Text = barTahvili.BarTahviliBime.ToString();
            PishKeraye_Txt.Text = barTahvili.BarTahviliPishKeraye.ToString();
            PasKeraye_Txt.Text = barTahvili.BarTahviliPasKeraye.ToString();
            DateSodor_DtPicker.Text = barTahvili.BarTahviliTarikh.ToString();
            HourSodor_TmPicker.Text = barTahvili.BarTahviliiSaat.ToString();
        }
        public void RefreshKala()
        {

            var Kalas = Barbari_BLL.BarTahvili.Select_KalaTahvili(BarTahvili.BarTahviliCodeBar);
            if (Kalas.Success)
            {
                row = 1;
                ShowKala_StckPnl.Children.Clear();
                for (int i = 0; i < Kalas.Data.Count; i++)
                {
                    ShowKala_StckPnl.Children.Add(new KalaTahviliComponent(Kalas.Data[i], row, edit) { Height = 72, Width = 558 });
                    row++;
                }
            }
            else
            {
                MessageBox.Show(Kalas.Message);
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ConfigHelper.Instance.SetLanguage(ConfigHelper.Language.Persian);
            DateSodor_DtPicker.Text = ConvertDate.MiladiToShamsiNumberDate(DateTime.Now);
            if (edit)
            {
                if (WindowsAndPages.home_Window.Role != null)
                {
                    AddKala_Btn.IsEnabled = WindowsAndPages.home_Window.Role.BarTahviliUpdate;
                }
                else
                {
                    AddKala_Btn.IsEnabled = false;
                }
                EditMode(BarTahvili);
            }
            else
            {
                FillDateTime();
                //GetCodeBraname();
            }

        }

        private void PasKeraye_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasKeraye_Txt.Text))
            {
                PasKeraye_Txt.Text = 0.ToString();
            }
            if (PishKeraye_Txt != null)
            {
                if (PasKeraye_Txt.Text != 0.ToString())
                {
                    PishKeraye_Txt.Text = 0.ToString();
                }
            }
            double number = double.Parse(PasKeraye_Txt.Text);
            string letter = Barbari_DAL.Possibilities.Convert(PasKeraye_Txt.Text);
            PasKeraye_Txt.ToolTip = letter + "\n" + number.ToString("#,##0");
        }

        private void PishKeraye_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PishKeraye_Txt.Text))
            {
                PishKeraye_Txt.Text = 0.ToString();
            }
            if (PasKeraye_Txt != null)
            {
                if (PishKeraye_Txt.Text != 0.ToString())
                {
                    PasKeraye_Txt.Text = 0.ToString();
                }

            }
            double number = double.Parse(PishKeraye_Txt.Text);
            string letter = Barbari_DAL.Possibilities.Convert(PishKeraye_Txt.Text);
            PishKeraye_Txt.ToolTip = letter + "\n" + number.ToString("#,##0");
        }

        private void PishKeraye_Txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (PishKeraye_Txt.Text == 0.ToString())
            {
                e.Handled = true;
            }
        }

        private void PasKeraye_Txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (PasKeraye_Txt.Text == 0.ToString())
            {
                e.Handled = true;
            }
        }

        private void AnbarDari_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AnbarDari_Txt.Text))
            {
                AnbarDari_Txt.Text = 0.ToString();
            }
            double number = double.Parse(AnbarDari_Txt.Text);
            string letter = Barbari_DAL.Possibilities.Convert(AnbarDari_Txt.Text);
            AnbarDari_Txt.ToolTip = letter + "\n" + number.ToString("#,##0");
        }

        private void BasteBandi_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BasteBandi_Txt.Text))
            {
                BasteBandi_Txt.Text = 0.ToString();
            }
            double number = double.Parse(BasteBandi_Txt.Text);
            string letter = Barbari_DAL.Possibilities.Convert(BasteBandi_Txt.Text);
            BasteBandi_Txt.ToolTip = letter + "\n" + number.ToString("#,##0");
        }

        private void Shahri_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Shahri_Txt.Text))
            {
                Shahri_Txt.Text = 0.ToString();
            }
            double number = double.Parse(Shahri_Txt.Text);
            string letter = Barbari_DAL.Possibilities.Convert(Shahri_Txt.Text);
            Shahri_Txt.ToolTip = letter + "\n" + number.ToString("#,##0");
        }

        private void Bime_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Bime_Txt.Text))
            {
                Bime_Txt.Text = 0.ToString();
            }
            double number = double.Parse(Bime_Txt.Text);
            string letter = Barbari_DAL.Possibilities.Convert(Bime_Txt.Text);
            Bime_Txt.ToolTip = letter + "\n" + number.ToString("#,##0");
        }
        public void Registered()
        {
            ShowKala_StckPnl.Children.Clear();
            CodeBarname_Txt.Clear(); 
            KalaName_Txt.Clear();
            KalaNumber_Txt.Clear();
            AnbarDari_Txt.Text = 0.ToString();
            BasteBandi_Txt.Text = 0.ToString();
            Shahri_Txt.Text = 0.ToString();
            Bime_Txt.Text = 0.ToString();
            PishKeraye_Txt.Text = 0.ToString();
            PasKeraye_Txt.Text = 0.ToString();
            FillDateTime();
            //PrintToggle.IsChecked = false;
            SendSmsToggle.IsChecked = false;

        }

        private void DateSodor_DtPicker_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(DateSodor_DtPicker.Text));
        }


        private void CodeBarname_Txt_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        //private void DateSodor_DtPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if(dateLoaded ==true)
        //    {
        //        DateSodor_DtPicker.Text = ConvertDate.MiladiToShamsiNumberDate((DateTime)DateSodor_DtPicker.SelectedDate);
        //    }
        //}
    }
}
