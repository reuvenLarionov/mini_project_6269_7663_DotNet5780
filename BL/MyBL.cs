using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;
using DS;
namespace BL
{






    public class MyBl:IBL
    {
        public void AddGuestRequest(GuestRequest guestReq)
        {
            if (guestReq.entryDate.DayOfYear - guestReq.releaseDate.DayOfYear < 1)
                throw new Exception("BL: Your entry date have to be at least one day before your release date.");
            if (guestReq.entryDate.DayOfYear - DateTime.Now.DayOfYear < 1 )
                throw new Exception("BL: Your entry date have to be at least one day before today.");
            if (guestReq.releaseDate.Year > DateTime.Now.Year)
                throw new Exception("BL: Your can only make an order for this year.");
            Dal_Factory.GetDal_Factory().AddGuestRequest(guestReq);
        }
        public void UpdateGuestRequest(GuestRequest newGuestRequest)
        {
            Dal_Factory.GetDal_Factory().UpdateGuestRequest(newGuestRequest);
        }



        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            int i = DataSource.hostList.FindIndex(j => j.key == hostingUnit.owner.key);
            DataSource.hostList[i].numOfHostingUnits++;
            Dal_Factory.GetDal_Factory().AddHostingUnit(hostingUnit);
        }
        public void UpDateHostingUnit(HostingUnit hostingunit)
        {
            Dal_Factory.GetDal_Factory().UpDateHostingUnit(hostingunit);
        }
        public void ErasеHostingUnit(int key)
        {
            Dal_Factory.GetDal_Factory().ErasеHostingUnit(key);
        }



        public void AddHost(Host host)
        {
            Dal_Factory.GetDal_Factory().AddHost(host);
        }
        public void UpDateHost(Host host)
        {
            Dal_Factory.GetDal_Factory().UpDateHost(host);
        }
        public void ErasеHost(int key)
        {
            Dal_Factory.GetDal_Factory().ErasеHost(key);
        }



        public void AddOrder(Order order)
        {
            UpdateDiary(order.orderHostingUnit, order);
            order.ownerFee = (order.orderReleaseDate.DayOfYear - order.orderEntryDate.DayOfYear) * Configuration.fee;
            Dal_Factory.GetDal_Factory().AddOrder(order);
        }
        public void UpDateOrder(int key, STATUS st)
        {
            int i = DataSource.orderList.FindIndex(or => or.key == key);

            UpdateDiary(DataSource.orderList[i].orderHostingUnit, DataSource.orderList[i]);
            Dal_Factory.GetDal_Factory().UpDateOrder(key,st);
        }
        public void ErasеOrder(int key)
        {
            Dal_Factory.GetDal_Factory().ErasеOrder(key);
        }
        public void DeleteOrder(int key)
        {
            int i = DataSource.orderList.FindIndex(j => j.key == key);
            DataSource.orderList[i].status = STATUS.Deleted;
            int h = DataSource.hostingUnitList.FindIndex(j => j.key == key);
            for (int g = DataSource.orderList[i].orderEntryDate.Month-1; g < DataSource.orderList[i].orderReleaseDate.Month-1; g++)
            {
                for (int f = DataSource.orderList[i].orderEntryDate.Month-1; f < DataSource.orderList[i].orderReleaseDate.Month-1; f++)
                {
                    DataSource.hostingUnitList[h].diary[g,f]=true;
                }
            }
        }


        public List<HostingUnit> GetHostingUnitList()
        {
            return Dal_Factory.GetDal_Factory().GetHostingUnitList();
        }
        public List<GuestRequest> GetGuestRequestList()
        {
            return Dal_Factory.GetDal_Factory().GetGuestRequestList();
        }
        public List<BankBranch> GetBankBranchList()
        {
            return Dal_Factory.GetDal_Factory().GetBankBranchList();
        }
        public List<Host> GetHostList()
        {
            return Dal_Factory.GetDal_Factory().GetHostList();
        }
        public List<Order> GetOrderList()
        {
            return Dal_Factory.GetDal_Factory().GetOrderList();
        }








        public void UpdateOrderStatus()
        {
            List<Order> list = new List<Order>(DataSource.orderList);
            foreach (var i in list)
            {
                if (i.orderEntryDate.DayOfYear <= DateTime.Now.DayOfYear)
                    i.status = STATUS.NotYetActivated;
                if (i.orderEntryDate.DayOfYear >= DateTime.Now.DayOfYear)
                    i.status = STATUS.Active;
                if (i.orderReleaseDate.DayOfYear >= DateTime.Now.DayOfYear)
                    i.status = STATUS.OutDated;
            }
        }



        public void UpdateDiary(HostingUnit hostingUnit, Order order)
        {
            int lastDay, lastMonth, days;
            days = order.orderReleaseDate.DayOfYear - order.orderEntryDate.DayOfYear;
            lastDay = (order.orderEntryDate.Day + days % 31) % 31;
            lastMonth = order.orderEntryDate.Month + days / 31 + (order.orderEntryDate.Day + days) / 31;
                for (int j = order.orderEntryDate.Month - 1; j < lastMonth; j++)
                {
                    for (int h = order.orderEntryDate.Day - 1; h < lastDay; h++)
                    {
                        hostingUnit.diary[j, h] = false;
                    }
                }
            }



        public List<HostingUnit> HostingUnitsByDate(DateTime date,int days)
        {
            List<HostingUnit> list=new List<HostingUnit>();
            int lastDay, lastMonth;
            lastDay = (date.Day+days%31)%31;
            lastMonth = date.Month + days / 31 + (date.Day + days) / 31;
            foreach (var i in GetHostingUnitList())
            {
                bool flag = true;
                for (int j = date.Month-1; j < lastMonth; j++)
                {
                    for (int h = date.Day-1; h < lastDay; h++)
                    {
                        if (!i.diary[j, h])
                            flag = false;
                    }
                }
                if (flag)
                    list.Add(i);
            }
            return list;
        }


        public int DaysPassed(DateTime d1, DateTime d2)
        {
            if (d1.DayOfYear > DateTime.Now.DayOfYear)
                return 0;
            return DateTime.Now.DayOfYear - d1.DayOfYear % (d2.DayOfYear - d1.DayOfYear);
        }
        
        public List<HostingUnit> Machted(GuestRequest guestRequest)
        {
            List<HostingUnit> list = new List<HostingUnit>();
            bool flag = true;
            foreach (var i in GetHostingUnitList())
            {
                if (!(i.area==guestRequest.area))
                    flag = false;
                if (!(i.type==guestRequest.type))
                    flag = false;
                if (!((i.adultNum >= guestRequest.adultNum && i.childNum >= guestRequest.childNum) || (i.adultNum >= guestRequest.adultNum + guestRequest.childNum - i.childNum)))
                    flag = false;
                if (!(i.pool == guestRequest.pool))
                    flag = false;
                if (!(i.jacuzzi == guestRequest.jacuzzi))
                    flag = false;
                if (!(i.wifi == guestRequest.wifi))
                    flag = false;
                if (!(i.view == guestRequest.view))
                    flag = false;
                if (!(i.disabledAccessible == guestRequest.disabledAccessible))
                    flag = false;
                if (!(i.moneyForNight > guestRequest.moneyRange[0]))
                    flag = false;
                if (!(i.moneyForNight == guestRequest.moneyRange[1]))
                    flag = false;
                if (flag)
                    list.Add(i);
            }
            return list;
        }



        public int NumOfContractsPerUnit(HostingUnit hostingUnit)
        {
            List<Order> list = new List<Order>();
            List<Order> list1 = new List<Order>();

            list = GetOrderList();
            list1 = list.FindAll(j => j.orderHostingUnit.key == hostingUnit.key);
            return list1.Count;
        }



        public List<Order> OrdersPerArea(AREA area)
        {
            List<Order> list = new List<Order>();
            list = GetOrderList();

            return list.FindAll(j => j.orderHostingUnit.area == area);
        }



        public List<Order> OrdersPerGuestes(int num)
        {
            List<Order> list = new List<Order>();
            list = GetOrderList();

            return list.FindAll(j => j.orderHostingUnit.adultNum+j.orderHostingUnit.childNum == num);
        }



        public List<Host> HostsPerHostingUnits(int num)
        {
            List<Host> list = new List<Host>();
            list = GetHostList();

            return list.FindAll(j => j.numOfHostingUnits == num);
        }



        public List<HostingUnit> HostingUnitsPerArea(AREA area)
        {
            List<HostingUnit> list = new List<HostingUnit>();
            list = GetHostingUnitList();

            return list.FindAll(j => j.area == area);
        }



        public bool IsHost(int key)
        {
            List<Host> list = new List<Host>();
            list = GetHostList();

            return list.Exists(j => j.key == key);
        }



        public bool ManagerCheck(string psw)
        {
            return psw == Configuration.managerPassword;
        }



        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
