using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Host
    {



        public int key;
        public string privateName;
        public string lastName;
        public int phoneNumber;
        public string mailAddress;
        public BankBranch bankBranchDetails;
        public int bankAccountNumber;
        public bool collectionClearance;
        public int numOfHostingUnits;
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
