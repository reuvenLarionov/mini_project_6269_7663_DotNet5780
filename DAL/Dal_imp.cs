using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DS;
namespace DAL
{






    class Dal_imp : Idal
    {
        public void AddGuestRequest(GuestRequest guestRequest)
        {
            guestRequest.key = Configuration.guestRequestSerialKey++;
            DataSource.guestRequestList.Add(guestRequest);
        }
        public void UpdateGuestRequest(GuestRequest newGuestRequest)
        {
            if (!DataSource.guestRequestList.Exists(or => or.key == newGuestRequest.key))
                throw new Exception("Dal: There is no such guest request.");
            int i = DataSource.guestRequestList.FindIndex(j => j.key == newGuestRequest.key);
            DataSource.guestRequestList[i] = newGuestRequest;
        }




        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            hostingUnit.key = Configuration.hostingUnitSerialKey++;
            DataSource.hostingUnitList.Add(hostingUnit);
        }
        public void UpDateHostingUnit(HostingUnit newHostingUnit)
        {
            if (!DataSource.hostingUnitList.Exists(or => or.key == newHostingUnit.key))
                throw new Exception("Dal: There is no such hosting unit.");
            int i = DataSource.hostingUnitList.FindIndex(j => j.key == newHostingUnit.key);
            DataSource.hostingUnitList[i] = newHostingUnit;
        }
        public void ErasеHostingUnit(int key)
        {
            if (!DataSource.hostingUnitList.Exists(or => or.key == key))
                throw new Exception("Dal: There is no such hosting unit.");
            int i = DataSource.hostingUnitList.FindIndex(j => j.key == key);
            DataSource.hostingUnitList.Remove(DataSource.hostingUnitList[i]);
        }



        public void AddHost(Host host)
        {
            host.key = Configuration.hostSerialKey++;
            DataSource.hostList.Add(host);
        }
        public void UpDateHost(Host newHost)
        {
            if (!DataSource.hostList.Exists(or => or.key == newHost.key))
                throw new Exception("Dal: There is no such host.");
            int i = DataSource.hostList.FindIndex(j => j.key == newHost.key);
            DataSource.hostList[i] = newHost;
        }
        public void ErasеHost(int key)
        {
            if (!DataSource.hostList.Exists(or => or.key == key))
                throw new Exception("Dal: There is no such host.");
            int i = DataSource.hostList.FindIndex(j => j.key == key);
            DataSource.hostList.Remove(DataSource.hostList[i]);
        }



        public void AddOrder(Order order)
        {
            order.key = Configuration.orderSerialKey++;
            DataSource.orderList.Add(order);
        }
        public void UpDateOrder(int key, STATUS st)
        {
            if (!DataSource.orderList.Exists(or => or.key == key))
                throw new Exception("Dal: There is no such order.");
            int i = DataSource.orderList.FindIndex(j => j.key == key);
            DataSource.orderList[i].status = st;
        }
        public void ErasеOrder(int key)
        {
            if (!DataSource.orderList.Exists(or => or.key == key))
                throw new Exception("Dal: There is no such order.");
            int i = DataSource.orderList.FindIndex(j => j.key == key);
            DataSource.orderList.Remove(DataSource.orderList[i]);
        }




        public List<HostingUnit> GetHostingUnitList()
        {
            List<HostingUnit> list = new List<HostingUnit>(DataSource.hostingUnitList);
            if (list.Count == 0)
                throw new Exception("Dal: There is no hosting units.");
            return list;
        }
        public List<GuestRequest> GetGuestRequestList()
        {
            List<GuestRequest> list = new List<GuestRequest>(DataSource.guestRequestList);
            if (list.Count == 0)
                throw new Exception("Dal: There is no guest requests.");
            return list;
        }
        public List<BankBranch> GetBankBranchList()
        {
            List<BankBranch> list = new List<BankBranch>(DataSource.bankBranchList);
            if (list.Count == 0)
                throw new Exception("Dal: There is no bank branches.");
            return list;
        }
        public List<Host> GetHostList()
        {
            List<Host> list = new List<Host>(DataSource.hostList);
            if (list.Count == 0)
                throw new Exception("Dal: There is no hosts.");
            return list;
        }
        public List<Order> GetOrderList()
        {
            List<Order> list = new List<Order>(DataSource.orderList);
            if (list.Count == 0)
                throw new Exception("Dal: There is no orders.");
            return list;
        }
    }
}
