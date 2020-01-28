using System;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BE
{
    public class GuestRequest
    {



        public int key;
        public int id;
        public string firstName;
        public string lastName;
        public DateTime registretionTime;
        public DateTime entryDate;
        public DateTime releaseDate;
        public AREA area;
        public TYPE type;
        public int adultNum;
        public int childNum;
        public bool pool;
        public bool jacuzzi;
        public bool wifi;
        public bool disabledAccessible;
        public bool view;
        public int[] moneyRange = new int[2];
        public override string ToString()
        {
            return this.ToStringProperty();
        }
       

    }


}
