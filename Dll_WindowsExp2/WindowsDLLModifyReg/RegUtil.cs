using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace WindowsDLLModifyReg
{
    class RegUtil
    {
        //句柄
        static readonly IntPtr HKEY_CLASSES_ROOT = new IntPtr(unchecked((int)0x80000000));
        static readonly IntPtr HKEY_CURRENT_USER = new IntPtr(unchecked((int)0x80000001));
        static readonly IntPtr HKEY_LOCAL_MACHINE = new IntPtr(unchecked((int)0x80000002));
        static readonly IntPtr HKEY_USERS = new IntPtr(unchecked((int)0x80000003));
        static readonly IntPtr HKEY_PERFORMANCE_DATA = new IntPtr(unchecked((int)0x80000004));
        static readonly IntPtr HKEY_CURRENT_CONFIG = new IntPtr(unchecked((int)0x80000005));
        static readonly IntPtr HKEY_DYN_DATA = new IntPtr(unchecked((int)0x80000006));

        //权限(samDesired参数)
        static int STANDARD_RIGHTS_ALL = (0x001F0000);
        static int KEY_QUERY_VALUE = (0x0001);
        static int KEY_SET_VALUE = (0x0002);
        static int KEY_CREATE_SUB_KEY = (0x0004);
        static int KEY_ENUMERATE_SUB_KEYS = (0x0008);
        static int KEY_NOTIFY = (0x0010);
        static int KEY_CREATE_LINK = (0x0020);
        static int SYNCHRONIZE = (0x00100000);
        static int KEY_WOW64_64KEY = (0x0100);
        static int REG_OPTION_NON_VOLATILE = (0x00000000);
        static int KEY_ALL_ACCESS = (STANDARD_RIGHTS_ALL | KEY_QUERY_VALUE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY | KEY_ENUMERATE_SUB_KEYS
                             | KEY_NOTIFY | KEY_CREATE_LINK) & (~SYNCHRONIZE);

        //获取操作Key值句柄 
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegOpenKeyEx(IntPtr hKey, string lpSubKey, uint ulOptions, int samDesired, out IntPtr phkResult);

        //创建或打开Key值
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegCreateKeyEx(IntPtr hKey, string lpSubKey, int reserved, string type, int dwOptions, int REGSAM, IntPtr lpSecurityAttributes, out IntPtr phkResult,
                                                 out int lpdwDisposition);

        //禁用特定项的注册表反射
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegDisableReflectionKey(IntPtr hKey);

        //开启特定项的注册表反射
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegEnableReflectionKey(IntPtr hKey);

        //获取Key值
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegQueryValueEx(IntPtr hKey, string lpValueName, int lpReserved, out uint lpType, StringBuilder lpData, ref uint lpcbData);

        //设置Key值
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegSetValueEx(IntPtr hKey, string lpValueName, uint unReserved, uint unType, byte[] lpData, uint dataCount);

        //删除键
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegDeleteKeyEx(IntPtr hKey, string lpValueName, int REGSAM, int reserved);

        //关闭Key值
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegCloseKey(IntPtr hKey);

        //删除键值项
        [DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegDeleteValue(IntPtr hkey, string lpValueName);

        public static IntPtr TransferKeyName(string keyName)
        {
            IntPtr ret = IntPtr.Zero;
            switch (keyName)
            {
                case "HKEY_CLASSES_ROOT":     ret = HKEY_CLASSES_ROOT;     break;
                case "HKEY_CURRENT_USER":     ret = HKEY_CURRENT_USER;     break;
                case "HKEY_LOCAL_MACHINE":    ret = HKEY_LOCAL_MACHINE;    break;
                case "HKEY_USERS":            ret = HKEY_USERS;            break;
                case "HKEY_PERFORMANCE_DATA": ret = HKEY_PERFORMANCE_DATA; break;
                case "HKEY_CURRENT_CONFIG":   ret = HKEY_CURRENT_CONFIG;   break;
                case "HKEY_DYN_DATA":         ret = HKEY_DYN_DATA;         break;
                default:                      ret = HKEY_LOCAL_MACHINE;    break;
            }
            return ret;
        }

        public static void SetRegistryKey(string key, string subKey, string name, string value)
        {
            IntPtr hroot = TransferKeyName(key);
            IntPtr pHKey = IntPtr.Zero;

            int lpdwDisposition = 0;
            int ret = 0;

            ret = RegCreateKeyEx(hroot, subKey, 0, "", REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS | KEY_WOW64_64KEY, IntPtr.Zero, out pHKey, out lpdwDisposition);
            RegDisableReflectionKey(pHKey);

            uint REG_SZ = 1;
            byte[] data = Encoding.Unicode.GetBytes(value);

            RegSetValueEx(pHKey, name, 0, REG_SZ, data, (uint)data.Length);
            RegEnableReflectionKey(pHKey);
            RegCloseKey(pHKey);
        }
        public static string GetRegistryValue(string hkey, string path, string key)
        {
            IntPtr hroot = TransferKeyName(hkey);
            IntPtr pHKey = IntPtr.Zero;
            int ret = 0;
            uint t1 = 0, t2 = 20;
            StringBuilder strb = new StringBuilder();
            ret = RegOpenKeyEx(hroot, path, 0, KEY_ALL_ACCESS | KEY_WOW64_64KEY, out pHKey);
//            if (ret != 0) Console.WriteLine("^^^^^^^^^");
            RegDisableReflectionKey(pHKey);
            ret = RegQueryValueEx(pHKey, key, 0, out t1, strb, ref t2);
//            if (ret != 0) Console.WriteLine(ret);
            RegEnableReflectionKey(pHKey);
            RegCloseKey(pHKey);
            return strb.ToString();
        }
        public static void DeleteRegistryValue(string hkey, string path, string key)
        {
            IntPtr hroot = TransferKeyName(hkey);
            IntPtr pHKey = IntPtr.Zero;
            int ret = 0;
            ret = RegOpenKeyEx(hroot, path, 0, KEY_ALL_ACCESS | KEY_WOW64_64KEY, out pHKey);
            RegDisableReflectionKey(pHKey);
            ret = RegDeleteValue(pHKey, key);
            if (ret != 0) Console.WriteLine(ret);
            RegEnableReflectionKey(pHKey);
            RegCloseKey(pHKey);
        }
    }
}
