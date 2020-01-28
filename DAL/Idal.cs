using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace DAL
{
    public interface Idal
    {





        void AddGuestRequest(GuestRequest guestReq);
        void UpdateGuestRequest(GuestRequest newGuestRequest);



        void AddHostingUnit(HostingUnit hostingUnit);
        void UpDateHostingUnit(HostingUnit hostingunit);
        void ErasеHostingUnit(int key);



        void AddHost(Host host);
        void UpDateHost(Host host);
        void ErasеHost(int key);



        void AddOrder(Order order);
        void UpDateOrder(int key, STATUS st);
        void ErasеOrder(int key);



        List<HostingUnit> GetHostingUnitList();
        List<GuestRequest> GetGuestRequestList();
        List<BankBranch> GetBankBranchList();
        List<Host> GetHostList();
        List<Order> GetOrderList();


    }
}
