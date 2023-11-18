using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace CsCallDLL
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string guid = "4C7492D4-9265-4748-83DB-3DCDFA9AC273";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox1.Text.Trim();
            bool isEmpty = (strText1 == String.Empty);
            if (isEmpty)
            {
                textBox11.Text = String.Concat("输入不能为空！");
                return;
            }
            int x = int.Parse(strText1);
            int ret = CppDLLImport.Fac(x);
            textBox11.Text = ret.ToString();
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox2.Text.Trim();
            bool isEmpty = (strText1 == String.Empty);
            if (isEmpty)
            {
                textBox22.Text = String.Concat("输入不能为空！");
                return;
            }
            string[] stringSplitOpt = new string[] { "-" };
            string[] result = strText1.Split(stringSplitOpt, StringSplitOptions.None);
            int[] numbers = new int[2];
            int cnt = 0;
            foreach (string s in result)
            {
                numbers[cnt] = int.Parse(s);
                cnt++;
            }
            int ret = CppDLLImport.subtract(numbers[0], numbers[1]);
            textBox22.Text = String.Concat(ret);
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox3.Text.Trim();
            bool isEmpty = (strText1 == String.Empty);
            if (isEmpty)
            {
                textBox33.Text = String.Concat("输入不能为空！");
                return;
            }
            string[] stringSplitOpt = new string[] { "-" };
            string[] result = strText1.Split(stringSplitOpt, StringSplitOptions.None);
            int[] numbers = new int[2];
            int cnt = 0;
            foreach (string s in result)
            {
                numbers[cnt] = int.Parse(s);
                cnt++;
            }
            Type dycomType = Type.GetTypeFromCLSID(new Guid(guid));
            string ret;
            if (dycomType != null)
            {
                dynamic dycomObject = Activator.CreateInstance(dycomType);
                ret = dycomObject.Minus(numbers[0], numbers[1]);
                textBox33.Text = String.Concat(ret);
            }
        }
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox4.Text.Trim();
            bool isEmpty = (strText1 == String.Empty);
            if (isEmpty)
            {
                textBox4.Text = String.Concat("输入不能为空！");
                return;
            }
            string[] stringSplitOpt = new string[] { "/" };
            string[] result = strText1.Split(stringSplitOpt, StringSplitOptions.None);
            int[] numbers = new int[2];
            int cnt = 0;
            foreach (string s in result)
            {
                numbers[cnt] = int.Parse(s);
                cnt++;
            }
            Type dycomType = Type.GetTypeFromCLSID(new Guid(guid));
            string ret;
            if (dycomType != null)
            {
                dynamic dycomObject = Activator.CreateInstance(dycomType);
                ret = dycomObject.Minus(numbers[0], numbers[1]);
                textBox44.Text = String.Concat(ret);
            }
        }
    }
}
