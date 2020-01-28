using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class BL_Factory
    {
        static IBL instance = null;

        public static IBL GetBL_Factory()
        {
            if (instance == null)
                instance = new MyBl();
            return instance;
        }
    }
}
