using Barbari_DAL;
using MaterialDesignThemes.Wpf;
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

namespace Barbari_UI
{
    /// <summary>
    /// Interaction logic for AddKarmand.xaml
    /// </summary>
    public partial class AddKarmand : UserControl
    {
        public AddKarmand(bool loginopened)
        {
            Karmand = new Users_Tbl();
            loginOpened = loginopened;
            InitializeComponent();
        }
        public AddKarmand(Users_Tbl karmand)
        {
            Karmand = karmand;
            edit = true;
            InitializeComponent();

        }
        bool loginOpened = false;
        bool edit = false;
        public Users_Tbl Karmand { get; set; }
        public void RemoveText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
                textBox.Text = "";
                textBox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
        }
        void FillComboBoxe()
        {
            var roles = Barbari_BLL.Roles.Select("");
            foreach (Roles_Tbl role in roles.Data)
            {
                Roles_CmBox.Items.Add(role.RolesNamRole);
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

        void EditMode(Users_Tbl karmand)
        {
            Title_TxtBlock.Text = "ویرایش کارمند";
            FirstName_Txt.Text = karmand.UsersFirstName;
            LastName_Txt.Text = karmand.UsersLastName;
            UserName_Txt.Text = karmand.UsersUserName;
            Mobile_Txt.Text = karmand.UsersMobile;
            PassWord_Txt.Text = karmand.UsersPassWord;
            Roles_CmBox.Text = karmand.UsersRoles;
            Add_Btn.Content = "ویرایش کارمند";
            UserName_Txt.IsReadOnly = true;
            var result = Barbari_BLL.Users.Select_First();
            if(Karmand.UsersUserName==result.Data.UsersUserName)
            {
                Roles_CmBox.IsEnabled= false;
            }
            //FirstName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //LastName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //UserName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //PassWord_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            //Mobile_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                EditMode(Karmand);
            }
            FillComboBoxe();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                Karmand.UsersFirstName = FirstName_Txt.Text;
                Karmand.UsersLastName = LastName_Txt.Text;
                Karmand.UsersUserName = UserName_Txt.Text;
                Karmand.UsersPassWord = PassWord_Txt.Text;
                Karmand.UsersMobile = Mobile_Txt.Text;
                if (string.IsNullOrEmpty(Roles_CmBox.Text))
                {
                    Karmand.UsersRoles = null;
                }
                else
                {
                    Karmand.UsersRoles = Roles_CmBox.Text;
                }
                var result = Barbari_BLL.Users.Update(Karmand);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    WindowsAndPages.karmand.Refresh();
                    DialogHost.CloseDialogCommand.Execute(null, null);
                }

            }
            else
            {
                Users_Tbl karmand = new Users_Tbl();
                karmand.UsersFirstName = FirstName_Txt.Text;
                karmand.UsersLastName = LastName_Txt.Text;
                karmand.UsersUserName = UserName_Txt.Text;
                karmand.UsersPassWord = PassWord_Txt.Text;
                karmand.UsersMobile = Mobile_Txt.Text;
                if(string.IsNullOrEmpty(Roles_CmBox.Text))
                {
                    karmand.UsersRoles = null;
                }
                else
                {
                    karmand.UsersRoles = Roles_CmBox.Text;
                }
               
                var result = Barbari_BLL.Users.Insert(karmand);
                if (!result.Success)
                {
                    if(result.Data == null)
                    {
                        MessageBox.Show(result.Message);
                    }
                    else
                    {
                        UserName_Txt.IsReadOnly = true;
                        if(MessageBox.Show(result.Message,"هشدار",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            var repair = Barbari_BLL.Users.Recovery(UserName_Txt.Text);
                            if(!repair.Success)
                            {
                                MessageBox.Show(repair.Message);
                            }
                            else
                            {
                                MessageBox.Show("با موفقیت بازگردانی شد پنجره را ببندید");
                            }
                        }
                        UserName_Txt.IsReadOnly = false;
                    }
                }
                else
                {
                    if(loginOpened)
                    {
                        DialogHost.CloseDialogCommand.Execute(null,null);
                    }
                    else
                    {
                        FirstName_Txt.Text = "";
                        LastName_Txt.Text = "";
                        UserName_Txt.Text = "";
                        PassWord_Txt.Text = "";
                        Mobile_Txt.Text = "";
                        Roles_CmBox.Text = "";
                    }

                    //FirstName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //LastName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //UserName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //PassWord_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //Mobile_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //foreach (object control in Field_Grid.Children)
                    //{
                    //    if (control is Border)
                    //    {
                    //        if ((control as Border).Child is TextBox)
                    //        {
                    //            (((control as Border).Child) as TextBox).Text = (control as TextBox).Tag.ToString();
                    //            (((control as Border).Child) as TextBox).Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
                    //        }
                    //    }
                    //}

                }
            }
        }

        private void Roles_CmBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Roles_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //bool Validait()
            //{
            //    if (FirstName_Txt.Text == FirstName_Txt.Tag.ToString())
            //    {
            //        return false;
            //    }
            //    if (LastName_Txt.Text == LastName_Txt.Tag.ToString())
            //    {
            //        return false;
            //    }
            //    if (UserName_Txt.Text == UserName_Txt.Tag.ToString())
            //    {
            //        return false;
            //    }
            //    if (PassWord_Txt.Text == PassWord_Txt.Tag.ToString())
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

        private void UserName_Txt_GotFocus(object sender, RoutedEventArgs e)
        {
            if(edit)
            {
                Warning_TxtBlock.Visibility = Visibility.Visible;
            }

        }

        private void UserName_Txt_LostFocus(object sender, RoutedEventArgs e)
        {
            if(edit)
            {
                Warning_TxtBlock.Visibility = Visibility.Hidden;
            }
            
        }

        private void Mobile_Txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UserName_Txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                if (IsPersianCharacter(e.Text)) 
                {
                    e.Handled = true;
                }
            }
        }

        private bool IsPersianCharacter(string text)
        {
            var regex = new Regex(@"\p{IsArabic}"); 
            return regex.IsMatch(text);
        }
    }
}
