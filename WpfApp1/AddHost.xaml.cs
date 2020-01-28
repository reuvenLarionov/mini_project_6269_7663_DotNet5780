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
using BE;
using BL;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AddHost.xaml
    /// </summary>
    public partial class AddHost : Page
    {
        private IBL bl;
        public AddHost()
        {
            bl = BL_Factory.GetBL_Factory();
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!collectionClearance.IsPressed)
            {
                throw new Exception("WPF: You can't sign up if you don't agree to our clearence about collection from bank accounts.");
            }
            if (!BL_Factory.GetBL_Factory().IsDigitsOnly(numberphone.Text))
            {
                throw new Exception("WPF: You can only write numbers in your numberphone.");
            }
            if (!BL_Factory.GetBL_Factory().IsDigitsOnly(banknumber.Text))
            {
                throw new Exception("WPF: You can only write numbers in your banknumber.");
            }
            Host host = new Host();
            host.privateName = privatename.Text;
            host.lastName = familyname.Text;
            host.phoneNumber = int.Parse(numberphone.Text);
            host.mailAddress = emailaddres.Text;
            host.bankAccountNumber = int.Parse(banknumber.Text);
            host.collectionClearance = collectionClearance.IsPressed;
            host.key = Configuration.hostSerialKey++;
            bl.AddHost(host);
            App.page1.main.Content = new MainWindow();

        }


    }
}
