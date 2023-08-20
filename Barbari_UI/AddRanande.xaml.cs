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
using Barbari_DAL;
using MaterialDesignThemes.Wpf;

namespace Barbari_UI
{
    /// <summary>
    /// Interaction logic for AddRanande.xaml
    /// </summary>
    public partial class AddRanande : UserControl
    {
        public AddRanande()
        {
            Ranande = new Ranande_Tbl();
            InitializeComponent();
        }
        public AddRanande(Ranande_Tbl ranande)
        {
            Ranande = ranande;
            edit = true;
            InitializeComponent();
         
        }
        bool edit = false;
        public Ranande_Tbl Ranande { get; set; }
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

        void EditMode(Ranande_Tbl ranande)
        {
            Title_TxtBlock.Text = "ویرایش راننده";
            FirstName_Txt.Text = ranande.RanandeFirstName;
            LastName_Txt.Text = ranande.RanandeLastName;
            Code_Txt.Text = ranande.RanandeCodeRanande.ToString();
            Mobile_Txt.Text = ranande.RanandeMobile;
            Add_Btn.Content = "ویرایش راننده";
            Code_Txt.IsReadOnly= true;
            //FirstName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //LastName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //Code_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //Mobile_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(edit) 
            {
                EditMode(Ranande);
            }
            else
            {
                Code_Txt.Text = (Barbari_BLL.Ranande.Select_CodeLast().Data+1).ToString();
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(edit)
            {
                    Ranande.RanandeFirstName = FirstName_Txt.Text;
                    Ranande.RanandeLastName = LastName_Txt.Text;
                    Ranande.RanandeMobile = Mobile_Txt.Text;
                    var result = Barbari_BLL.Ranande.Update(Ranande);
                    if (!result.Success)
                    {
                        MessageBox.Show(result.Message);
                    }
                    else
                    {
                        Ranande.RanandeFirstName = "";
                        Ranande.RanandeLastName = "";
                        Ranande.RanandeMobile = "";
                        WindowsAndPages.ranandegan.Refresh();
                        DialogHost.CloseDialogCommand.Execute(null, null);
                    }
                
            }
            else
            {
                    Ranande_Tbl ranande= new Ranande_Tbl();
                    ranande.RanandeFirstName = FirstName_Txt.Text;
                    ranande.RanandeLastName= LastName_Txt.Text;
                    ranande.RanandeMobile= Mobile_Txt.Text;
                    var result = Barbari_BLL.Ranande.Insert(ranande);
                    if (!result.Success)
                    {
                        MessageBox.Show(result.Message);
                    }
                    else
                    {
                        FirstName_Txt.Text = "";
                        LastName_Txt.Text = "";
                        Code_Txt.Text = (Barbari_BLL.Ranande.Select_CodeLast().Data+1).ToString();
                        Mobile_Txt.Text = "";

                        //FirstName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                        //LastName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                        //Code_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                        //Mobile_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    }
            }
        }

        private void Mobile_Txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
        //bool Validait()
        //{
        //    if(FirstName_Txt.Text == FirstName_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    if (LastName_Txt.Text == LastName_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    if (Code_Txt.Text == Code_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    if (Mobile_Txt.Text == Mobile_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
