using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessories
{
    public static  class ExtensionMethods
    {
        //פונקציה רגילה
        //public   int GetGimatria(string str)
        //{
        //    int val = 0;
        //    foreach (char s in str)
        //        val += s switch
        //        {
        //            'א' => 1,
        //            'ב' => 2,
        //            _ => 0
        //        };

        //    return val;
        //}
        //פונקציה סטטית רגילה
        public static  int StaGetGimatria(string str)
        {
            int val = 0;
            foreach (char s in str)
                val += s switch
                {
                    'א' => 1,
                    'ב' => 2,
                    _ => 0
                };

            return val; 
        }

        public static int GetGimatria(this string str)
        {
            int val = 0;
            foreach (char s in str)
                val += s switch
                {
                    'א' => 1,
                    'ב' => 2,
                    _ => 0
                };

            return val;
        }

    }
}
