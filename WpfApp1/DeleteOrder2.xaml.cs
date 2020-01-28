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
    /// Interaction logic for EraseOrderOptions.xaml
    /// </summary>
    public partial class DeleteOrder2 : Page
    {
        private IBL bl;

        int id;
        public DeleteOrder2(int num)
        {
            bl = BL_Factory.GetBL_Factory();
            InitializeComponent();
            id = num;
            List<Order> list = new List<Order>(), list1 = new List<Order>();
            list = bl.GetOrderList();
            foreach (var i in list)
                if (i.guestId == id && i.status == STATUS.NotYetActivated)
                    list1.Add(i);
            foreach (var o in list1)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = o.orderHostingUnit.hostingUnitName +", "+o.orderHostingUnit.address+ "/n " + o.orderEntryDate.ToString() + "-" + o.orderReleaseDate.ToString();
                orders.Items.Add(comboBoxItem);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var i in BL_Factory.GetBL_Factory().GetOrderList())
            {

                if (orders.SelectedItem.ToString() == i.ToString())
                {
                    BL_Factory.GetBL_Factory().DeleteOrder(i.key);
                    break;
                }
            }
            App.page1.main.Content = new MainWindow();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.page1.main.Content = new DeleteOrder1();
        }
    }
}
