using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CsCallDLL
{
    class CppDLLImport
    {
        [DllImport(@"../../../Debug/CPPCreateDLL.dll", EntryPoint = "plus3", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int plus3(int a, int b, int c);

        [DllImport(@"../../../Debug/CPPCreateDLL.dll", EntryPoint = "mul2", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int mul2(int a, int b);

        [DllImport(@"../../../Debug/CPPCreateDLL.dll", EntryPoint = "unionString", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern string unionString(string a, string b);
        [DllImport(@"../../../Debug/CPPCreateDLL.dll", EntryPoint = "Fac", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int Fac(int x);
        [DllImport(@"../../../Debug/CPPCreateDLL.dll", EntryPoint = "subtract", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int subtract(int a, int b);
    }
}
