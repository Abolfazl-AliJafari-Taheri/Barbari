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
    /// Interaction logic for RanandeComponent.xaml
    /// </summary>
    public partial class RanandeComponent : UserControl
    {
        public RanandeComponent()
        {
            InitializeComponent();
        }
        public RanandeComponent(Ranande_Tbl ranande)
        {
            InitializeComponent();
            Ranande = ranande;
        }
        public Ranande_Tbl Ranande{ get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Name_TxtBlock.Text = Ranande.RanandeFirstName + " " + Ranande.RanandeLastName;
            Code_TxtBlock.Text = Ranande.RanandeCodeRanande;
            MobileNum_TxtBlock.Text = Ranande.RanandeMobile;
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            var result = Barbari_BLL.Ranande.Delete(Ranande.RanandeCodeRanande);
            if(result.Success)
            {
                WindowsAndPages.ranandegan.Refresh();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private async void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
          await WindowsAndPages.home_Window.DialogHost.ShowDialog(new AddRanande(Ranande) { Height = 317, Width = 622 });
        }
    }
}