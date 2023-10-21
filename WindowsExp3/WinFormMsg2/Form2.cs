using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WinFormMsg2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public const int WM_COPYDATA = 0x004A;
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        private void addMsg(string str)
        {
            if (str == null || str == "") return;
            listBox1.Items.Add(str);
        }
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    COPYDATASTRUCT recv = new COPYDATASTRUCT();
                    Type t = recv.GetType();
                    recv = (COPYDATASTRUCT)m.GetLParam(t);
                    string strResult = recv.lpData;
                    addMsg(strResult);
                    addMsg(DateTime.Now.ToString());
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
