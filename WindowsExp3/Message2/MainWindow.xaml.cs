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

namespace ReceiveC
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
        private void addMsg(string str)
        {
            if (str == null) return;
            listBox1.Items.Add(str);
        }
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
                        addMsg(MyKeyboardHookStruct.lpData);
                        addMsg(DateTime.Now.ToString());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.Write("##");
                        Console.WriteLine(e.Message);
                        break;
                    }

                default:
                    //Console.WriteLine(msg);
                    break;
            }
            return hwnd;
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
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
