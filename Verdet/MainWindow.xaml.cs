using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Collections.Generic;


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




            string[] test = { "Name","test"};
            string[] test2 = {"gökhan","asd"};
            string[] test3 = {"OR"};
            User guncelle = new User();
            
           
            //List<User> liste = Database.GetUsers(test,test2,test3);
            //guncelle = liste[0];
            //guncelle.Name = "güncellendi";
            //Database.UpdateUser(guncelle);
        }
        
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
