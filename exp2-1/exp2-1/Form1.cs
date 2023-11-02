using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
namespace exp2_1
{
    public partial class Form1 : Form
    {
        public static Process cmdP;
        public static StreamWriter cmdStreamInput;
        private static StringBuilder cmdOutput = null;
        public Form1()
        {
            InitializeComponent();
        }
        //动态链接库引入
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
        IntPtr hWnd, // handle to destination window
        int Msg, // message
        int wParam, // first message parameter
        int lParam // second message parame
        );
        public const int TRAN_FINISHED = 0x500;
        public static IntPtr main_whandle;
        public static IntPtr text_whandle;

        [DllImport("User32.dll", EntryPoint = "RedrawWindow")]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr prect, IntPtr hrgnUpdate, uint flags);

        public const int WM_VSCROLL = 0x0115;
        public const int SB_BOTTOM = 0x0007;
        public static int WM_SETREDRAW = 0x0B;

        private void button1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;

            string address = "10.135.15.21";
            if (textBox1.Text != address) { address = textBox1.Text; }
            string strCmd = "ping " + address + " -n 10";

            process.Start();
            process.StandardInput.WriteLine(strCmd);
            process.StandardInput.WriteLine("exit");

            textBox2.Text = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            process.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmdP != null)
            {
                if (!cmdP.HasExited)
                {
                    cmdP.Close();
                }
            }
            cmdP = new Process();
            cmdP.StartInfo.FileName = "cmd.exe";
            cmdP.StartInfo.CreateNoWindow = true;
            cmdP.StartInfo.UseShellExecute = false;

            cmdP.StartInfo.RedirectStandardOutput = true;
            cmdP.StartInfo.RedirectStandardInput = true;

            cmdOutput = new StringBuilder("");

            //输出数据异步处理事件
            cmdP.OutputDataReceived += new DataReceivedEventHandler(strOutputHandler);
            //异步处理中通知您的应用程序某个进程已退出
            cmdP.EnableRaisingEvents = true;

            string address = "10.135.15.21";
            if (textBox1.Text != address) { address = textBox1.Text; }
            string strCmd = "ping " + address + " -n 10";

            cmdP.Start();
            cmdP.StandardInput.WriteLine(strCmd);

            //开始异步输出的读入
            cmdP.BeginOutputReadLine();
        }
        private static void strOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            //将每次输出产生的数据附加到结果字符串中
            cmdOutput.AppendLine(outLine.Data);
            //设置输出文本框内容
            SendMessage(main_whandle, TRAN_FINISHED, 0, 0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            main_whandle = this.Handle;
            text_whandle = textBox2.Handle;
        }
        protected override void DefWndProc(ref Message m)
        {//窗体消息处理重载
            switch (m.Msg)
            {
                case TRAN_FINISHED:
                    SendMessage(text_whandle, WM_SETREDRAW, 0, 0);
                    textBox2.Text = cmdOutput.ToString();
                    //文本框控件无滚动事件,可向文本框发送滚动消息，令其文本滚动为最后
                    SendMessage(text_whandle, WM_VSCROLL, SB_BOTTOM, 50);
                    SendMessage(text_whandle, WM_SETREDRAW, 1, 0);
                    RedrawWindow(text_whandle, IntPtr.Zero, IntPtr.Zero, 1 | 4 | 128);

                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }
    }
}
