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
    /// Interaction logic for UpDateOrder.xaml
    /// </summary>
    public partial class DeleteOrder1 : Page
    {
        private IBL bl;

        public DeleteOrder1()
        {
            bl = BL_Factory.GetBL_Factory();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Order> list = new List<Order>();
              list=  BL_Factory.GetBL_Factory().GetOrderList();
            if (!list.Exists(or => or.guestId == int.Parse(id.Text)))
                throw new Exception("Wpf: There is no order that you created.");
            App.page1.main.Content = new DeleteOrder2(int.Parse(id.Text));
        }


    }
}
