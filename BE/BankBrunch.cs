using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
     public class BankBranch
    {





        public int bankNumber;
        public string bankName;
        public int branchNumber;
        public string branchAddress;
        public string branchCity;
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
