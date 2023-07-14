﻿using Barbari_DAL;
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
    /// Interaction logic for AddKarmand.xaml
    /// </summary>
    public partial class AddKarmand : UserControl
    {
        public AddKarmand()
        {
            InitializeComponent();
        }
        public AddKarmand(Users_Tbl karmand)
        {
            Karmand = karmand;
            edit = true;
            InitializeComponent();

        }
        bool edit = false;
        public Users_Tbl Karmand { get; set; }
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

        void EditMode(Users_Tbl karmand)
        {
            Title_TxtBlock.Text = "ویرایش کارمند";
            FirstName_Txt.Text = karmand.UsersFirstName;
            LastName_Txt.Text = karmand.UsersLastName;
            UserName_Txt.Text = karmand.UsersUserName;
            UserName_Txt.Text = karmand.UsersMobile;
            Add_Btn.Content = "ویرایش کارمند";
            UserName_Txt.IsReadOnly = true;
            FirstName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            LastName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            UserName_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            PassWord_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            Mobile_Txt.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                EditMode(Karmand);
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                if (Validait())
                {
                    Karmand.UsersFirstName = FirstName_Txt.Text;
                    Karmand.UsersLastName = LastName_Txt.Text;
                    Karmand.UsersLastName = UserName_Txt.Text;
                    Karmand.UsersPassWord= PassWord_Txt.Text;
                    Karmand.UsersMobile = Mobile_Txt.Text;
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
                if (Validait())
                {
                    Karmand.UsersFirstName = FirstName_Txt.Text;
                    Karmand.UsersLastName = LastName_Txt.Text;
                    Karmand.UsersLastName = UserName_Txt.Text;
                    Karmand.UsersPassWord = PassWord_Txt.Text;
                    Karmand.UsersMobile = Mobile_Txt.Text;
                }
                var result = Barbari_BLL.Users.Insert(Karmand);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    FirstName_Txt.Text = FirstName_Txt.Tag.ToString();
                    LastName_Txt.Text = LastName_Txt.Tag.ToString();
                    UserName_Txt.Text = UserName_Txt.Tag.ToString();
                    PassWord_Txt.Text = PassWord_Txt.Tag.ToString();
                    Mobile_Txt.Text = Mobile_Txt.Tag.ToString();
                }

            }
        }
        bool Validait()
        {
            if (FirstName_Txt.Text == FirstName_Txt.Tag.ToString())
            {
                return false;
            }
            if (LastName_Txt.Text == LastName_Txt.Tag.ToString())
            {
                return false;
            }
            if (UserName_Txt.Text == UserName_Txt.Tag.ToString())
            {
                return false;
            }
            if (PassWord_Txt.Text == PassWord_Txt.Tag.ToString())
            {
                return false;
            }
            if (Mobile_Txt.Text == Mobile_Txt.Tag.ToString())
            {
                return false;
            }
            return true;
        }
    }
}
