using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Page1 page1 = new Page1();
        private void Page1Application(object sender, StartupEventArgs e)
        {
            page1.main.Content = new MainWindow();
            page1.Show();
        }
    }
}
