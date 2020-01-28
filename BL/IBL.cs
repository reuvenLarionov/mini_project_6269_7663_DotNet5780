using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace BL
{
    public interface IBL
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
        void DeleteOrder(int key);



        List<HostingUnit> GetHostingUnitList();
        List<GuestRequest> GetGuestRequestList();
        List<BankBranch> GetBankBranchList();
        List<Host> GetHostList();
        List<Order> GetOrderList();


        void UpdateOrderStatus();
        void UpdateDiary(HostingUnit hostingUnit, Order order);
        int DaysPassed(DateTime d1, DateTime d2);
        List<HostingUnit> Machted(GuestRequest guestRequest);
        int NumOfContractsPerUnit(HostingUnit hostingUnit);
        List<Order> OrdersPerArea(AREA area);
        List<Order> OrdersPerGuestes(int num);
        List<Host> HostsPerHostingUnits(int num);
        List<HostingUnit> HostingUnitsPerArea(AREA area);

        List<HostingUnit> HostingUnitsByDate(DateTime date, int days);
        bool IsDigitsOnly(string str);

    }
}
