using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
       public class HostingUnit
    {





        public int key;
        public Host owner;
        public string hostingUnitName;
        public string hostingUnitDescription;
        public bool[,] diary = new bool[12, 31];
        public AREA area;
        public TYPE type;
        public int adultNum;
        public int childNum;
        public bool pool;
        public bool jacuzzi;
        public bool wifi;
        public bool disabledAccessible;
        public bool view;
        public int moneyForNight;
        public string address;
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
