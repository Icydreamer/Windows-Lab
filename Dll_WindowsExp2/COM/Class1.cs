using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace COM
{
    [ComVisible(true)]
    [Guid("C5753F46-558C-4A7E-AD92-98CBA76A5D74")]
    public interface IExpress
    {
        string Minus(int a, int b);//返回值形如“9 = 23 - 14”
        string Divide(int a, int b);//若b为零，则返回“除零错误”；若b不为0，则返回整除表达式，形如“4 = 33 / 8”
    }
    [ComVisible(true)]
    [Guid("4C7492D4-9265-4748-83DB-3DCDFA9AC273")]
    [ProgId("MyCom")]
    public class Class1 : IExpress
    {
        public string Minus(int a, int b)
        {
            int ans = a - b;
            return ans + " = " + a + " - " + b;
        }
        public string Divide(int a, int b)
        {
            if (b == 0)
                return "除零错误";
            else
                return a / b + " = " + a + " / " + b;
        }
    }
}
