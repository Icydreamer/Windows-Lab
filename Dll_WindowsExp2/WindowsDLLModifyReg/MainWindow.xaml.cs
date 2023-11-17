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
using System.Windows.Forms;
using WindowsDLLModifyReg;

namespace WindowsDLLModifyReg
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

        string Gitpath = @"SOFTWARE\GitForWindows";
        string key = "CurrentVersion";
        private void Window_Initialized(object sender, EventArgs e)
        {
            string value = RegUtil.GetRegistryValue("HKEY_LOCAL_MACHINE", Gitpath, key);
            Console.WriteLine(value);
            label2.Content = value;
        }

        private void btnModify(object sender, EventArgs e)
        {
            string value = textBox1.Text.Trim();
            RegUtil.SetRegistryKey("HKEY_LOCAL_MACHINE", Gitpath, key, value);
            string newValue = RegUtil.GetRegistryValue("HKEY_LOCAL_MACHINE", Gitpath, key);
            label5.Content = newValue;
        }
        private void btnReset(object sender, EventArgs e)
        {
            string value = RegUtil.GetRegistryValue("HKEY_LOCAL_MACHINE", Gitpath, key);
            label2.Content = value;
            textBox1.Clear();
            label5.Content = "";
        }
        private void btnCreate(object sender, EventArgs e)
        {
            string value = "AVBCD24532";
            RegUtil.SetRegistryKey("HKEY_LOCAL_MACHINE", Gitpath, "test", value);
        }
        private void btnDelete(object sender, EventArgs e)
        {
            string str = "test";
            RegUtil.DeleteRegistryValue("HKEY_LOCAL_MACHINE", Gitpath, str);
        }
    }
}
