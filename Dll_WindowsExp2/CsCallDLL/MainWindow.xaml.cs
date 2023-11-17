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
using CsClassLibrary;

namespace CsCallDLL
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
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox1.Text.Trim();
            bool isEmpty = (strText1 == String.Empty);
            if(isEmpty)
            {
                textBox11.Text = String.Concat("输入不能为空！");
                return;
            }
            string[] stringSplitOpt = new string[] { "+" };
            string[] result = strText1.Split(stringSplitOpt, StringSplitOptions.None);
            int[] numbers = new int[4];
            int cnt = 0;
            foreach(string s in result)
            {
                numbers[cnt] = int.Parse(s);
                cnt++;
            }
            int ret = CppDLLImport.plus3(numbers[0], numbers[1], numbers[2]);
            textBox11.Text = String.Concat(ret);
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
            string[] stringSplitOpt = new string[] { "*" };
            string[] result = strText1.Split(stringSplitOpt, StringSplitOptions.None);
            int[] numbers = new int[4];
            int cnt = 0;
            foreach (string s in result)
            {
                numbers[cnt] = int.Parse(s);
                cnt++;
            }
            int ret = CppDLLImport.mul2(numbers[0], numbers[1]);
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
            string[] stringSplitOpt = new string[] { "+" };
            string[] result = strText1.Split(stringSplitOpt, StringSplitOptions.None);
            string ret = "";
            if(result.Length == 1) ret = CppDLLImport.unionString(result[0], "");
            else ret = CppDLLImport.unionString(result[0], result[1]);
            textBox33.Text = String.Concat(ret);
        }
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox4.Text.Trim();
            bool isEmpty = (strText1 == String.Empty);
            if (isEmpty)
            {
                textBox44.Text = String.Concat("输入不能为空！");
                return;
            }
            long x = long.Parse(strText1);

            long ret = CsDLL.Fac(x);
            textBox44.Text = String.Concat(ret);
        }
        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox5.Text.Trim();
            bool isEmpty = (strText1 == String.Empty);
            if (isEmpty)
            {
                textBox55.Text = String.Concat("输入不能为空！");
                return;
            }
            long x = long.Parse(strText1);

            string ret = CsDLL.JudgePrime(x);
            textBox55.Text = String.Concat(ret);
        }
        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox6.Text.Trim();
            bool isEmpty = (strText1 == String.Empty);
            if (isEmpty)
            {
                textBox66.Text = String.Concat("输入不能为空！");
                return;
            }
            string ret = CsDLL.ReverseStr(strText1);
            textBox66.Text = String.Concat(ret);
        }
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            Assembly assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "CsClassLibrary.dll");
            Type type = assembly.GetType("CsClassLibrary.CsDLL");
            System.Reflection.PropertyInfo[] propertyInfos = type.GetProperties();
            System.Reflection.MethodInfo[] ms = type.GetMethods();

            foreach (System.Reflection.PropertyInfo p in propertyInfos)
            {
                string str = "";
                str += p.PropertyType + " " + p.Name;
                listBox1.Items.Add(str);
            }
            foreach (System.Reflection.MethodInfo methodInfo in ms)
            {
                string str = "";
                str += methodInfo.ReturnType.Name + " " + methodInfo.Name;
                System.Reflection.ParameterInfo[] ps = methodInfo.GetParameters();
                bool firstValue = true;
                str += "(";
                foreach (System.Reflection.ParameterInfo parameter in ps)
                {
                    if (firstValue) str += parameter.ParameterType.Name + " " + parameter.Name;
                    else str += "," + parameter.ParameterType.Name + " " + parameter.Name;
                    firstValue = false;
                }
                str += ")";
                listBox1.Items.Add(str);
            }
        }
    }
}
