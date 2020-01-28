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
    /// Interaction logic for AddGuestRequest2.xaml
    /// </summary>
    public partial class AddOrder : Page
    {
        GuestRequest gr = new GuestRequest();
        public AddOrder(GuestRequest guestRequest)
        {
            InitializeComponent();
            gr = guestRequest;
            foreach (var h in BL_Factory.GetBL_Factory().Machted(gr))
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = h.hostingUnitName +", "+h.address + "/n " + h.hostingUnitDescription;
                hostingUnits.Items.Add(comboBoxItem);
            }
            meyutar.Content = gr.key;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            infoButton.Visibility = Visibility.Visible;
        }

        private void chooseButton_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            foreach (var i in BL_Factory.GetBL_Factory().GetHostingUnitList())
            {

                if (hostingUnits.SelectedItem.ToString() == i.hostingUnitName + ", " + i.address + "/n " + i.hostingUnitDescription)
                {
                    order.createDate = DateTime.Now;
                    order.orderHostingUnit = i;
                    order.status = STATUS.NotYetActivated;
                    order.ownerFee=(order.orderReleaseDate.DayOfYear-order.orderEntryDate.DayOfYear)*Configuration.fee;
                    order.key = Configuration.orderSerialKey++;
                    order.guestRequestKey = int.Parse(string.Format("{0}", meyutar.Content));
                    break;
                }
            }
            App.page1.main.Content = new MainWindow();
        }
    }
}
