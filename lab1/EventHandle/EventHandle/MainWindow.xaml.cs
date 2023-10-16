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

namespace EventHandle
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
            FireAlarm myFireAlarm = new FireAlarm();  //定义一个火情发生源类对象；
                                                      //定义一个火情处理类对象，并将源类对象作为参数传递给这个对象
            FireHandler myFireHandler1 = new FireHandler(this, myFireAlarm);
            //FireWatcherClass myFireHandle2 = new FireWatcherClass(myFireAlarm);
            //发生一种火情，以事件机制执行
            myFireAlarm.ActivateFireAlarm("Kitchen", 3);
            myFireAlarm.ActivateFireAlarm("Kitchen", 6);
        }

    }
}
