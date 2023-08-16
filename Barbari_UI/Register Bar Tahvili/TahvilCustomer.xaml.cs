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

namespace Barbari_UI.Register_Bar_Tahvili
{
    /// <summary>
    /// Interaction logic for TahvilCustomer.xaml
    /// </summary>
    public partial class TahvilCustomer : UserControl
    {
        public TahvilCustomer()
        {
            InitializeComponent();
        }
        public TahvilCustomer(BarTahvili_Tbl barTahvili,bool Edit)
        {
            InitializeComponent();
            BarTahvili = barTahvili;
            edit = Edit;
        }
        bool edit = false;
        public BarTahvili_Tbl BarTahvili { get; set; }
        private void Tahvil_Btn_Click(object sender, RoutedEventArgs e)
        {
            var validation = Barbari_BLL.Validation.BarTahvili_Validation_TahvilMoshtari(ValidationSolution_CmBox.Text,ValidationData_Txt.Text);
            if(validation.Success)
            {
                BarTahvili.BarTahviliRaveshEhrazHoviat = ValidationSolution_CmBox.Text;
                BarTahvili.BarTahviliRaveshEhrazHoviatText = ValidationData_Txt.Text;
                var result = Barbari_BLL.BarTahvili.Insert_TahvilBeMoshtari(BarTahvili);
                if(validation.Success)
                {
                    WindowsAndPages.barTahvili.Refresh("");
                    DialogHost.CloseDialogCommand.Execute(null,null);
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
            {
                MessageBox.Show(validation.Message);
            }
        }
        void FillComboBoxe()
        {
          
            ValidationSolution_CmBox.ItemsSource = validationSolution;
        }
        List<string> validationSolution = new List<string>()
            {
                "شناسنامه",
                "کارت ملی",
                "گواهینامه"
            };
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                int index = validationSolution.IndexOf(BarTahvili.BarTahviliRaveshEhrazHoviat);
                if (index >= 0)
                {
                    ValidationSolution_CmBox.SelectedIndex = index;
                }
                ValidationData_Txt.Text = BarTahvili.BarTahviliRaveshEhrazHoviatText;
                Title_TxtBlock.Visibility = Visibility.Collapsed;
                Cancel_Btn.Visibility = Visibility.Collapsed;
                Tahvil_Btn_Border.Visibility = Visibility.Collapsed;
                ValidationData_Border.Width = 263;
                ValidationSolution_Border.Width = 263;
            }
            //FillComboBoxe();
            //ValidationSolution_CmBox.IsEditable = false;

        }

        private void ValidationSolution_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
