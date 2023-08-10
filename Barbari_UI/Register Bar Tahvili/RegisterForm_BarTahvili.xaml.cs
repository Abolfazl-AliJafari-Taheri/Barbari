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

namespace Barbari_UI.Register_Bar_Tahvili
{
    /// <summary>
    /// Interaction logic for RegisterForm_BarTahvili.xaml
    /// </summary>
    public partial class RegisterForm_BarTahvili : UserControl
    {
        public RegisterForm_BarTahvili()
        {
            InitializeComponent();
        }
        private void Step3_Toggle_Click(object sender, RoutedEventArgs e)
        {
            bool? check = !Step3_Toggle.IsChecked;
            Step3_Toggle.IsChecked = check;

        }

        private void Step2_Toggle_Click(object sender, RoutedEventArgs e)
        {
            bool? check = !Step2_Toggle.IsChecked;
            Step2_Toggle.IsChecked = check;

        }

        private void Step1_Toggle_Click(object sender, RoutedEventArgs e)
        {
            bool? check = !Step1_Toggle.IsChecked;
            Step1_Toggle.IsChecked = check;
        }

        private void Step4_Toggle_Click(object sender, RoutedEventArgs e)
        {
            bool? check = !Step4_Toggle.IsChecked;
            Step4_Toggle.IsChecked = check;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void PerviuosStep_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextStep_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
