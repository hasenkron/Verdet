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
            string[] test = { "hasenkron", "g36443144s" };
            
            List<User> liste = Helper.Database.GetUsers(GetUsersFrom.All,test);
        }
        
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
