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

namespace Event
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
        public class FireEventArgs : EventArgs
        {
            public string room;
            public int level;
            public FireEventArgs(string room, int level)
            {
                this.room = room;
                this.level = level;
            }
        }
        public class FireAlarm
        {
            public delegate void FireEventHandler(object sender, FireEventArgs fire);
            public event FireEventHandler FireEvent;
            public void ActivateFireAlarm(string room, int level)
            {
                FireEventArgs fireArgs = new FireEventArgs(room, level);
                FireEvent(this, fireArgs);
            }
        }
        class FireHandlerClass
        {
            private MainWindow mainWindow;
            private FireAlarm fireAlarm;
            public FireHandlerClass(MainWindow _mainWindow, FireAlarm _fireAlarm)
            {
                mainWindow = _mainWindow;
                fireAlarm = _fireAlarm;
                fireAlarm.FireEvent += new FireAlarm.FireEventHandler(ExtinguishFire);
            }
            void ExtinguishFire(object sender, FireEventArgs fire)
            {
                mainWindow.addMsg(sender.ToString() + " 对象调用ExtinguishFire，主人开始灭火");
                mainWindow.addMsg("火情发生在 " + fire.room);
                if (fire.level < 5)
                {
                    mainWindow.addMsg("主人浇水后，小火被扑灭");
                }
                else if (fire.level < 10)
                {
                    mainWindow.addMsg("主人使用灭火器，中火被扑灭");
                }
                else
                {
                    mainWindow.addMsg("大火无法控制");
                }
            }
        }
        class FireWatcherClass
        {
            private MainWindow mainWindow;
            public FireWatcherClass(MainWindow _mainWindow, FireAlarm fireAlarm)
            {
                mainWindow = _mainWindow;
                fireAlarm.FireEvent += new FireAlarm.FireEventHandler(WatchFire);
            }
            void WatchFire(object sender, FireEventArgs fire)
            {
                mainWindow.addMsg(sender.ToString() + " 对象调用WatchFire，行人发现火情.");
                mainWindow.addMsg("行人看到火情发生在 " + fire.room);
                if (fire.level < 5)
                {
                    mainWindow.addMsg("行人看到主人浇水后火被扑灭了");
                }
                else if (fire.level < 10)
                {
                    mainWindow.addMsg("行人帮助主人灭火，火被扑灭");
                }
                else
                {
                    mainWindow.addMsg("行人及主人无法控制火情");
                }
            }
        }
        void addMsg(string str)
        {
            if (str == null || str == "") return;
            listBox1.Items.Add(str);
        }
        void clearMsg()
        {
            listBox1.Items.Clear();
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            clearMsg();
            string room = textBox1.Text.Trim();
            int level = int.Parse(textBox2.Text.Trim());
            FireAlarm fireAlarm = new FireAlarm();
            FireHandlerClass fireHandler = new FireHandlerClass(this, fireAlarm);
            fireAlarm.ActivateFireAlarm(room, level);
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            clearMsg();
            string room = textBox1.Text.Trim();
            int level = int.Parse(textBox2.Text.Trim());
            FireAlarm fireAlarm = new FireAlarm();
            FireWatcherClass fireWatcher = new FireWatcherClass(this, fireAlarm);
            fireAlarm.ActivateFireAlarm(room, level);
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            clearMsg();
        }
    }
}
