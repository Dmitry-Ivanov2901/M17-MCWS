using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M15A3_MCWS
{
    internal class args
    {
        public struct argy
        {
            public string identifier;
            public string value;
        }
        public static argy[] ar = new argy[25];
        public static string[] ar2 = new string[50];
        public static int x = 0;
        public static void addArg(string identifier, string value)
        {
            x++;
            if(x <= 25)
            {
                argy a;
                a.value = value;
                a.identifier = identifier;
                ar[x] = a;
                ar2[x] = $"{a.identifier} {a.value} ";
            }
        }
    }
}
