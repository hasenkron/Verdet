using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Collections.Generic;
using System;


namespace Verdet
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Data test = new Data
            {
                OwnerId = 1
            };
            Database.AddData(test);
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
