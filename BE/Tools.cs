using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BE
{
    public static class Tools
    {








        public static string ToStringProperty<T>(this T t)
        {
            string str = " ";
            foreach (PropertyInfo item in t.GetType().GetProperties())
            {
                str += "/n" + item.Name + ": " + item.GetValue(t, null);
            }
            return str;
        }
    }
}
