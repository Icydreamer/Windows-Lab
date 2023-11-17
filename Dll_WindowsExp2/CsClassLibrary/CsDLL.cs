using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsClassLibrary
{
    public class CsDLL
    {
        public static long Fac(long x) { return x == 0 ? 1 : x * Fac(x - 1); }
        public static string JudgePrime(long x)
        {
            string ret = "";
            bool flag = false;
            for(long i = 2; i * i <= x; i++)
            {
                if (x % i == 0)
                {
                    flag = true;
                    break;
                }
            }
            if (x <= 1) flag = true;
            if (flag) ret += "No";
            else ret += "Yes";
            return ret;
        }
        public static string ReverseStr(string str)
        {
            string ret = "";
            int len = str.Length;
            for (int i = 0; i < len; i++) ret += str[len - i - 1];
            return ret;
        }
    }
}
