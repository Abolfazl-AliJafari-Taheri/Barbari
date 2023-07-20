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
        string companyName;
        string companyCity;
        string companyRules;

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

        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                companyCity = CompanyCity_Txt.Text;
                companyName = CompanyName_Txt.Text;
                companyRules = CompanyRules_Txt.Text;
                string directoryPath = "";
                List<string> directory = Environment.CurrentDirectory.Split('\\').ToList();
                directory.RemoveAt(directory.Count-1);
                directory.RemoveAt(directory.Count-1);
                for (int i = 0; i < directory.Count; i++)
                {
                    directory[i] = directory[i] + "\\";
                    directoryPath += directory[i];
                }
             directoryPath += "Source\\Icones";
                string fileName = "AppIcon.png";
                string destinationFilePath = Path.Combine(directoryPath, fileName);

                File.Copy(logoAddress, destinationFilePath,true);
            }
            catch(Exception) 
            {
                
            }
        }

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
    }
}
