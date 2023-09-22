using Microsoft.Win32;
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
using System.IO;
using Barbari_DAL;
using Barbari_BLL;
using MaterialDesignThemes.Wpf;
using System.Text.RegularExpressions;
using Barbari_UI.SMS;

namespace Barbari_UI
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Page
    {
        public Setting()
        {
            InitializeComponent();
        }
        string logoAddress;

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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (WindowsAndPages.home_Window.Role != null)
            {
                Save_Btn.IsEnabled = WindowsAndPages.home_Window.Role.TanzimatlogoAndName;
                Add_Btn.IsEnabled = WindowsAndPages.home_Window.Role.TanzimatRoles;
            }
            else
            {
                Add_Btn.IsEnabled = false;
                Save_Btn.IsEnabled = false;
            }
            var sms = Barbari_BLL.SMS.Select();
            if(sms.Success)
            {
                if(sms.Data !=null)
                {
                    CityMabda_CmBox.Text = sms.Data.SMSName;
                    SmsSenderUrl_Txt.Text = sms.Data.SMSURL;

                }
            }
            else
            {
                MessageBox.Show(sms.Message);
            }
            var company = Barbari_BLL.Company.Select();
            if (company.Success)
            {
                if (company.Data != null)
                {
                    logoAddress = company.Data.CompanyIogo;
                    CompanyCity_Txt.Text = company.Data.CompanyCity;
                    CompanyName_Txt.Text = company.Data.CompanyName;
                    CompanyRules_Txt.Text = company.Data.CompanyRules;
                    CompanyPhoneNumber_Txt.Text = company.Data.CompanyTelephon;
                    if (company.Data.CompanyIogo != "" && company.Data.CompanyIogo != null)
                    {
                        if (File.Exists(company.Data.CompanyIogo))
                        {
                            var brush = new ImageBrush();
                            brush.ImageSource = new BitmapImage(new Uri(company.Data.CompanyIogo, UriKind.Relative));
                            Logo_Border.Background = brush;
                            Logo_Img.Source = null;
                        }
                    }
                    else
                    {
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.UriSource = new Uri("/Source/Icones/Insert Icon Setting(Gray Border).png", UriKind.Relative);
                        bitmapImage.EndInit();
                        Logo_Img.Source = bitmapImage;
                        Logo_Border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E6E6E6"));
                    }
                }
            }
            else
            {
                MessageBox.Show(company.Message);
            }
            RefreshRoles();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Company_Tbl company = new Company_Tbl();
                        company.CompanyRules = CompanyRules_Txt.Text;
                    company.CompanyCity = CompanyCity_Txt.Text;
                    company.CompanyName = CompanyName_Txt.Text;
                    company.CompanyIogo = logoAddress;
                    company.CompanyTelephon = CompanyPhoneNumber_Txt.Text;
                    var result = Barbari_BLL.Company.Insert(company);
                    if (!result.Success)
                    {
                        MessageBox.Show(result.Message);
                    }
                    else
                    {
                        WindowsAndPages.home_Window.DialogHost.ShowDialog(new SubmitDelete(CloseApp: true) { Height = 200 ,Width = 700 });
                    }
                
            }
            catch(Exception) 
            {
                
            }
        }
        //bool Validate()
        //{
        //    if(CompanyCity_Txt.Text == CompanyCity_Txt.Tag.ToString())
        //    {
        //        return false;
        //    }
        //    if (CompanyName_Txt.Text == CompanyName_Txt.Tag.ToString())
        //    {  
        //        return false;  
        //    }
            
        //    return true;
        //}
        private void Logo_Btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpeg;*.jpg;*.png;";
            openFileDialog.Title = "انتخاب لوگو شرکت";
            if (openFileDialog.ShowDialog() == true)
            {
                logoAddress = openFileDialog.FileName;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(logoAddress, UriKind.Relative);
                bitmapImage.EndInit();
                Logo_Img.Source = null;
                ImageBrush imageBrush = new ImageBrush(bitmapImage);
                Logo_Border.Background = imageBrush;

            }
        }

        private async void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            Role.AddRole addRole= new Role.AddRole() { Width = 660};
            await WindowsAndPages.home_Window.DialogHost.ShowDialog(addRole);
            if(addRole.Inserted)
            {
                RefreshRoles();
            }
        }
        public void RefreshRoles()
        {
            ShowRoles_StckPnl.Children.Clear();
            var result = Barbari_BLL.Roles.Select("");
            if(result.Success)
            {
                foreach (Roles_Tbl role in result.Data)
                {
                    ShowRoles_StckPnl.Children.Add(new Role.RoleComponent(role) { Height = 72, Width = 1143 });
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void CompanyPhoneNumber_Txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SaveSms_Btn_Click(object sender, RoutedEventArgs e)
        {
            SMS_Tbl sms = new SMS_Tbl()
            {
                SMSName = CityMabda_CmBox.Text,
                SMSURL = SmsSenderUrl_Txt.Text
            };
            OperationResult validationResult = Barbari_BLL.Validation.SMS_Validation(sms);
            OperationResult result;
            if (validationResult.Success)
            {
                result = Barbari_BLL.SMS.Insert(sms);
                if(!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
            }
            else
                MessageBox.Show(validationResult.Message);
        }
    }
}
