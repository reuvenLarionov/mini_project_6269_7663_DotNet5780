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
    /// Interaction logic for AddGuestRequest1.xaml
    /// </summary>
    public partial class AddGuestRequest : Page
    {

        public AddGuestRequest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!BL_Factory.GetBL_Factory().IsDigitsOnly(id.Text))
            {
                throw new Exception("WPF: Your can only write numbers in your id .");
            }
            if (!BL_Factory.GetBL_Factory().IsDigitsOnly(minimum.Text) && int.Parse(minimum.Text) >= 0)
            {
                throw new Exception("WPF: Your can only write numbers in your minimum that you want to pay  .");
            }
            if (int.Parse(minimum.Text) <= 0)
            {
                throw new Exception("WPF: Your can only enter num that biger then zero  .");

            }
            if (int.Parse(minimum.Text) > int.Parse(maximum.Text))
            {
                throw new Exception("WPF: Your minimum has to be bigger then your maximum.");

            }
            if (!BL_Factory.GetBL_Factory().IsDigitsOnly(maximum.Text))
            {
                throw new Exception("WPF: Your can only write numbers in your maximum that you want to pay  .");
            }
            
            GuestRequest guestRequest = new GuestRequest();
            guestRequest.key = Configuration.guestRequestSerialKey++;
            guestRequest.id = int.Parse(this.id.Text);
            guestRequest.firstName = this.firstName.Text;
            guestRequest.lastName = this.LastName.Text;
            guestRequest.registretionTime = DateTime.Now;
            guestRequest.entryDate = this.entryDate.SelectedDate ?? DateTime.Now;
            guestRequest.releaseDate = this.releaseDate.SelectedDate ?? DateTime.Now;
            switch (this.area.Text)
            {
                case "All":
                    guestRequest.area = AREA.All;
                    break;
                case "North":
                    guestRequest.area = AREA.North;
                    break;
                case "South":
                    guestRequest.area = AREA.South;
                    break;
                case "Jerusalem":
                    guestRequest.area = AREA.Jerusalem;
                    break;
                case "Center":
                    guestRequest.area = AREA.Center;
                    break;
                case "Eilat":
                    guestRequest.area = AREA.Eilat;
                    break;
                default:
                    break;
            }
            switch (this.type.Text)
            {
                case "All":
                    guestRequest.type = TYPE.All;
                    break;
                case "Hotel":
                    guestRequest.type = TYPE.Hotel;
                    break;
                case "Zimmer":
                    guestRequest.type = TYPE.Zimmer;
                    break;
                case "Apartment":
                    guestRequest.type = TYPE.Apartment;
                    break;
                case "Camping":
                    guestRequest.type = TYPE.Camping;
                    break;
                default:
                    break;
            }
         
            guestRequest.pool = this.pool.IsPressed;
            guestRequest.wifi = this.wifi.IsPressed;
            guestRequest.jacuzzi = this.jacuzzi.IsPressed;
            guestRequest.view = this.view.IsPressed;
            guestRequest.disabledAccessible = this.disabledAccessible.IsPressed;
            guestRequest.moneyRange[0] = int.Parse(this.minimum.Text);
            guestRequest.moneyRange[1] = int.Parse(this.maximum.Text);

            BL_Factory.GetBL_Factory().AddGuestRequest(guestRequest);
            App.page1.Content = new AddOrder(guestRequest);
        }
    }
}
