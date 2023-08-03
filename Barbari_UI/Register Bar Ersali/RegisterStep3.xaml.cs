using Barbari_DAL;
using FormComponent;
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
    /// Interaction logic for RegisterStep3.xaml
    /// </summary>
    public partial class RegisterStep3 : UserControl
    {
        public RegisterStep3()
        {
            InitializeComponent();
        }
        int row = 1;
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

        private void PrintToggle_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void PrintToggle_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        public List<KalaDaryafti_Tbl> GetKalas()
        {
            List<KalaDaryafti_Tbl> Kalas = new List<KalaDaryafti_Tbl>();
            foreach (KalaComponent kala in ShowKala_StckPnl.Children)
            {
                if(kala.Visibility == Visibility.Visible)
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

                if ((ShowKala_StckPnl.Children[i] as KalaComponent).Visibility == Visibility.Visible)
                {
                    (ShowKala_StckPnl.Children[i] as KalaComponent).Row_TxtBlock.Text = Row.ToString();
                    Row++;
                }
            }


        }
        
        private void AddKala_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(KalaNumber_Txt.Text, out int number) &&
            decimal.TryParse(KalaPrice_Txt.Text, out decimal price))
            {
                var result = Barbari_BLL.Validation.BarErsali_Validation_KalaDaryafti(KalaName_Txt.Text, number, price);
                if (result.Success)
                {
                    ShowKala_StckPnl.Children.Add(new KalaComponent(new KalaDaryafti_Tbl
                    {
                        KalaDaryaftiBarname = int.Parse(CodeBarname_Txt.Text),
                        KalaDaryaftiNamKala = KalaName_Txt.Text,
                        KalaDaryaftiTedadKala = number,
                        KalaDaryaftiArzeshKala = price,
                    }, row)
                    { Height = 72, Width = 558 });
                    KalaName_Txt.Clear();
                    KalaNumber_Txt.Clear();
                    KalaPrice_Txt.Clear();
                    row++;
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
            {
                MessageBox.Show(" تعداد و ارزش کالا را صحیح وارد کنید");
            }

        }
        void GetCodeBraname()
        {
            var code = Barbari_BLL.BarErsali.Select_Barname_Last();
            if(code.Success)
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
            DateSodor_DtPicker.SelectedDate = DateTime.Now;
            HourSodor_TmPicker.SelectedTime = DateTime.Now;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //DateSodor_Txt.Text = ConvertDate.MiladiToShamsiNumberDate(DateTime.Now);
            FillDateTime();
            GetCodeBraname();
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
           
        }

        private void PishKeraye_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(PishKeraye_Txt.Text))
            {
                PishKeraye_Txt.Text = 0.ToString();
            }
            if (PasKeraye_Txt != null)
            {
                if(PishKeraye_Txt.Text != 0.ToString())
                {
                        PasKeraye_Txt.Text = 0.ToString();
                }
                
            }
        }

        private void PishKeraye_Txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(PishKeraye_Txt.Text == 0.ToString())
            {
                e.Handled= true;
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
        }

        private void BasteBandi_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BasteBandi_Txt.Text))
            {
                BasteBandi_Txt.Text = 0.ToString();
            }
        }

        private void Shahri_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Shahri_Txt.Text))
            {
                Shahri_Txt.Text = 0.ToString();
            }
        }

        private void Bime_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Bime_Txt.Text))
            {
                Bime_Txt.Text = 0.ToString();
            }
        }
        public void Registered()
        {
            ShowKala_StckPnl.Children.Clear();
            KalaName_Txt.Clear();
            KalaNumber_Txt.Clear();
            KalaPrice_Txt.Clear();
            GetCodeBraname();
            AnbarDari_Txt.Text = 0.ToString();
            BasteBandi_Txt.Text = 0.ToString();
            Shahri_Txt.Text = 0.ToString();
            Bime_Txt.Text = 0.ToString();
            PishKeraye_Txt.Text = 0.ToString();
            PasKeraye_Txt.Text = 0.ToString();
            FillDateTime();
            PrintToggle.IsChecked= false;
            SendSmsToggle.IsChecked= false;
            
        }
    }
}
