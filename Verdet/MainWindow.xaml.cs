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

            

            //User add = new User();
            //add.Name = "testiye";
            //add.Surname = "testi";
            //add.Username = "xd";
            //add.Password = "lul";
            //Helper.Database.AddUser(add);
            string[] test = {"Username"};
            string[] test2 = { "test" };
            User guncelle = new User();
            List<User> liste = Database.GetUsers(test,test2);
            guncelle = liste[0];
            guncelle.Name = "güncellendi";
            Database.UpdateUser(guncelle);
        }
        
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
