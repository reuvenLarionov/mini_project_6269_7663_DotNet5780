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
    /// Interaction logic for AddHostingUnit.xaml
    /// </summary>
    public partial class AddHostingUnit : Page
    {
        private IBL bl;

        public AddHostingUnit()
        {
            bl = BL_Factory.GetBL_Factory();
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!BL_Factory.GetBL_Factory().IsDigitsOnly(adultNum.Text))
            {
                throw new Exception("WPF: Your can only write numbers in your adultNum.");
            }
            if (!BL_Factory.GetBL_Factory().IsDigitsOnly(childNum.Text))
            {
                throw new Exception("WPF: Your can only write numbers in your childNum.");
            }
            if (!BL_Factory.GetBL_Factory().IsDigitsOnly(moneyForNight.Text))
            {
                throw new Exception("WPF: Your can only write numbers in your moneyForNight that you want to pay.");
            }


            
            
            HostingUnit hostingunit = new HostingUnit();
            foreach (var i in BL_Factory.GetBL_Factory().GetHostList())
            {
                if (int.Parse(owner.Text) == i.key)
                {
                    hostingunit.owner = i;
                }
            }
            hostingunit.hostingUnitName = hostingUnitName.Text;
            hostingunit.hostingUnitDescription = hostingUnitDescription.Text;
            hostingunit.adultNum = int.Parse(adultNum.Text);
            hostingunit.childNum = int.Parse(childNum.Text);
            hostingunit.pool = pool.IsPressed;
            hostingunit.jacuzzi = jacuzzi.IsPressed;
            hostingunit.wifi = wifi.IsPressed;
            hostingunit.disabledAccessible = disabledAccessible.IsPressed;
            hostingunit.view = view.IsPressed;
            hostingunit.moneyForNight = int.Parse(moneyForNight.Text);
            hostingunit.address = city.Text + ' ' + street.Text + ' ' + appnum.Text;


            switch (this.area.Text)
            {
                case "All":
                    hostingunit.area = AREA.All;
                    break;
                case "North":
                    hostingunit.area = AREA.North;
                    break;
                case "South":
                    hostingunit.area = AREA.South;
                    break;
                case "Jerusalem":
                    hostingunit.area = AREA.Jerusalem;
                    break;
                case "Center":
                    hostingunit.area = AREA.Center;
                    break;
                case "Eilat":
                    hostingunit.area = AREA.Eilat;
                    break;
                default:
                    break;
            }
            switch (this.type.Text)
            {
                case "All":
                    hostingunit.type = TYPE.All;
                    break;
                case "Hotel":
                    hostingunit.type = TYPE.Hotel;
                    break;
                case "Zimmer":
                    hostingunit.type = TYPE.Zimmer;
                    break;
                case "Apartment":
                    hostingunit.type = TYPE.Apartment;
                    break;
                case "Camping":
                    hostingunit.type = TYPE.Camping;
                    break;
                default:
                    break;
            }
        }

        
    }
}
