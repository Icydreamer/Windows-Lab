﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace test_4
{
    [ComVisible(true)]
    [Guid("72784B9F-6C5D-4AE1-B35E-285CFED4C164")]
    public interface IExpress
    {
        string Minus(int a, int b);//返回值形如“9 = 23 - 14”
        string Divide(int a, int b);//若b为零，则返回“除零错误”；若b不为0，则返回整除表达式，形如“4 = 33 / 8”
    }
    [ComVisible(true)]
    [Guid("C03BE966-41B5-4778-B45C-01C340249442")]
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

