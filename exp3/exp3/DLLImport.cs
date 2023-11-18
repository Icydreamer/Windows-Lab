using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exp3
{
    class DLLImport
    {
        [DllImport(@"CreateDLL.dll", EntryPoint = "Fac", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int Fac(int x);
        [DllImport(@"CreateDLL.dll", EntryPoint = "subtract", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int subtract(int a, int b);
    }
}
