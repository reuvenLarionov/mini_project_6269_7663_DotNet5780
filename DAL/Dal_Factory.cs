using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Dal_Factory
    {
       private static Idal instance = null;

        public static Idal GetDal_Factory()
        {
            if (instance == null)
                instance = new Dal_imp();
            return instance;
        }

        
    }
}
