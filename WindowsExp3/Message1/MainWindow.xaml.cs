using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace SenderA
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        #region 定义常量消息值
        public const int WM_COPYDATA = 0x004A;
        private static readonly IntPtr WND_BROADCAST = new IntPtr(0xffff);
        #endregion

        #region 定义结构体
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        #endregion

        //动态链接库引入
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
        IntPtr hWnd, // handle to destination window 
        int Msg, // message 
        int wParam, // first message parameter 
        ref COPYDATASTRUCT lParam // second message parameter 
        );

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        private IntPtr MainWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_COPYDATA:
                    try
                    {
                        COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                        Type mytype = mystr.GetType();
                        Console.WriteLine("#####");
                        COPYDATASTRUCT MyKeyboardHookStruct = (COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(COPYDATASTRUCT));
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.Write("##");
                        Console.WriteLine(e.Message);
                        break;
                    }

                default:
 //                   Console.WriteLine(msg);
                    break;
            }
            return hwnd;
        }

        private void sendMessage(string msg)
        {
            IntPtr WINDOW_HANDLER = FindWindow(null, "ReceiveB");
            Console.WriteLine(WINDOW_HANDLER);
            if (WINDOW_HANDLER != IntPtr.Zero)
            {
                int calcID;
                GetWindowThreadProcessId(WINDOW_HANDLER, out calcID);
                Console.WriteLine(calcID);
                COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                mystr.dwData = (IntPtr)0;
                byte[] sarr = System.Text.Encoding.Unicode.GetBytes(msg);
                mystr.cbData = sarr.Length + 1;
                mystr.lpData = msg;
                int ret = SendMessage(WINDOW_HANDLER, WM_COPYDATA, 0, ref mystr);
                Console.Write("ret"); Console.WriteLine(ret);
            }
            IntPtr WINDOW_HANDLER2 = FindWindow(null, "ReceiveC");
            Console.WriteLine(WINDOW_HANDLER2);
            if (WINDOW_HANDLER2 != IntPtr.Zero)
            {
                int calcID2;
                GetWindowThreadProcessId(WINDOW_HANDLER2, out calcID2);
                Console.WriteLine(calcID2);
                COPYDATASTRUCT mystr2 = new COPYDATASTRUCT();
                mystr2.dwData = (IntPtr)0;
                byte[] sarr2 = System.Text.Encoding.Unicode.GetBytes(msg);
                mystr2.cbData = sarr2.Length + 1;
                mystr2.lpData = msg;
                int ret2 = SendMessage(WINDOW_HANDLER2, WM_COPYDATA, 0, ref mystr2);
                Console.Write("ret"); Console.WriteLine(ret2);
            }
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            string str = textBox1.Text;
            Console.WriteLine(str);
            sendMessage(str);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper wih = new WindowInteropHelper(this);
            var hwnd = wih.Handle;
            HwndSource hWndSource = HwndSource.FromHwnd(hwnd);
            hWndSource.AddHook(MainWindowProc);
        }
    }
}
