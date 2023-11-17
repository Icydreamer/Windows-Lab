using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace test_4
{
    [ComVisible(true)]
    [Guid("4B6C433B-FF2B-4A0F-BB32-8B877DF4F43C")]
    public interface IExpress
    {
        string Minus(int a, int b);//返回值形如“9 = 23 - 14”
        string Divide(int a, int b);//若b为零，则返回“除零错误”；若b不为0，则返回整除表达式，形如“4 = 33 / 8”
    }
    [ComVisible(true)]
    [Guid("1FEE64A5-F6FA-4CCE-B87D-FB4AFED41032")]
    [ProgId("test_4.MyClass")]

    public class Class1: IExpress
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
                return a/b + " = " + a + " / " + b;
        }
    }
}

