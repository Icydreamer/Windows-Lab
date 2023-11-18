using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyCOM
{
    [ComVisible(true)]
    [Guid("ECE71F4D-CD3D-4760-8467-E5AE5FDB4CC9")]
    public interface IExpress
    {
        string Minus(int a, int b);//返回值形如“9 = 23 - 14”
        string Divide(int a, int b);//若b为零，则返回“除零错误”；若b不为0，则返回整除表达式，形如“4 = 33 / 8”
    }
    [ComVisible(true)]
    [Guid("714F055D-36B1-460E-9A9A-86CD6B7FBC6E")]
    [ProgId("MyCom")]
    public class MyCOM : IExpress
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
