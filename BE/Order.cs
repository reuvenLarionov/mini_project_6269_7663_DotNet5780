using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Order
    {






        public HostingUnit orderHostingUnit;
        public int guestRequestKey;
        public int guestId;
        public int key;
        public DateTime createDate;
        public DateTime orderEntryDate;
        public DateTime orderReleaseDate;
        public STATUS status;
        public int ownerFee;
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
