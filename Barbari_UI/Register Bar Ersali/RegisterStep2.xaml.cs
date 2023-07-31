﻿using System;
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
    /// Interaction logic for RegisterStep2.xaml
    /// </summary>
    public partial class RegisterStep2 : UserControl
    {
        public RegisterStep2()
        {
            InitializeComponent();
        }
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

        public void AddTextCmBox(object sender, EventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            if (string.IsNullOrWhiteSpace(combobox.Text))
            {
                combobox.Text = combobox.Tag.ToString();
                combobox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B8B8B8"));
            }
        }
        public void RemoveTextCmBox(object sender, EventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            if (combobox.Text == combobox.Tag.ToString())
            {
                combobox.Text = "";
                combobox.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            }
        }
        void FillComboBox()
        {
            var city = Barbari_BLL.City.Select_Shahr();
            CityMaghsadFinal_CmBox.ItemsSource = city.Data;
            CityMaghsad_CmBox.ItemsSource = city.Data;
        }
        private void AddSecondMaghsadToggle_Checked(object sender, RoutedEventArgs e)
        {
            AnbarMaghsadFinal_CmBox.IsEnabled = true;
            CityMaghsadFinal_CmBox.IsEnabled = true;
        }

        private void AddSecondMaghsadToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            AnbarMaghsadFinal_CmBox.IsEnabled = false;
            CityMaghsadFinal_CmBox.IsEnabled = false;
        }

        private void CityMaghsad_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CityMaghsad_CmBox.SelectedItem != null)
            {
                var anbar = Barbari_BLL.City.Select_Anbar(CityMaghsad_CmBox.SelectedItem.ToString());
                AnbarMaghsad_CmBox.ItemsSource = anbar.Data;
            }
      
        }

        private void CityMaghsadFinal_CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityMaghsadFinal_CmBox.SelectedItem != null)
            {
                var anbar = Barbari_BLL.City.Select_Anbar(CityMaghsadFinal_CmBox.SelectedItem.ToString());
                AnbarMaghsadFinal_CmBox.ItemsSource = anbar.Data;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
        }
    }
}
