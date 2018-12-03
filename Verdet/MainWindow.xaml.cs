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

            string[] test = { "Username"};
            string[] test2 = {"test"};
            //string[] test3 = {"OR"};
            User guncelle = new User();

            List<User> liste = Database.GetUsers(test,test2,false);
            guncelle = liste[0];
            guncelle.Name = "güncellendi";
            Database.UpdateUser(guncelle);
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
