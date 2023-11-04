using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Windows实验1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        static int buf_size = 20;
        static int Max_Size = 10005;
        int curCnt = 0;
        int remainedCnt = 0;
  //      DateTime beforeDT;
        static int produceNum = 0;
        static int consumeNum = 0;
  //      static int timeUp = 30;
        static Mutex mutex = new Mutex();
        static Semaphore produce = new Semaphore(0, Max_Size);
        static Semaphore consume = new Semaphore(0, Max_Size);
        Queue q1 = new Queue();     //producer
        Queue q2 = new Queue();     //consumer
        public MainWindow()
        {
            InitializeComponent();
        }
        void produceItem(string name, int rate)
        {
            while(true)
            {
                mutex.WaitOne();
                curCnt++;
                while(remainedCnt < buf_size && q1.Count > 0)
                {
                    remainedCnt++;produceNum++;
                    string producer = (string)q1.Dequeue();
                    Dispatcher.Invoke(new Action(() => {
                        ListBoxOutput.Items.Add(producer + " 生产了项目 " + produceNum + "，现在还剩 " + remainedCnt + "个");
                    }));
                }
                if(remainedCnt == buf_size)
                {
                    q1.Enqueue(name);
                }
                else
                {
                    remainedCnt++;produceNum++;
                    Dispatcher.Invoke(new Action(() => {
                        ListBoxOutput.Items.Add(name + " 生产了项目 " + produceNum + "，现在还剩 " + remainedCnt + "个");
                    }));
                    if(q2.Count > 0)
                    {
                        remainedCnt--;consumeNum++;
                        string consumer = (string)q2.Dequeue();
                        Dispatcher.Invoke(new Action(() => {
                            ListBoxOutput.Items.Add(consumer + " 消费了项目 " + consumeNum + "，现在还剩 " + remainedCnt + "个");
                        }));
                    }
                }
                mutex.ReleaseMutex();
                consume.Release();
                Thread.Sleep(rate * 1000);
                //              DateTime afterDT = System.DateTime.Now;
                //              TimeSpan ts = afterDT.Subtract(beforeDT);
                //                if (ts.TotalMilliseconds > timeUp) break;
                if (curCnt > Max_Size) break;
            }
        }
        void consumeItem(string name, int rate)
        {
            while (true)
            {
                mutex.WaitOne();
                if(remainedCnt > 0)
                {
                    remainedCnt--;
                    consumeNum++;
                    Dispatcher.Invoke(new Action(() => {
                        ListBoxOutput.Items.Add(name + " 消费了项目 " + consumeNum + "，现在还剩 " + remainedCnt + "个");
                    }));
                }
                else if(q1.Count > 0)
                {
                    remainedCnt++;
                    consumeNum++;produceNum++;
                    string producer = (string)q1.Dequeue();
                    Dispatcher.Invoke(new Action(() => {
                        ListBoxOutput.Items.Add(producer + " 生产了项目 " + produceNum + "，共生产了" + curCnt + "个，现在还剩 " + remainedCnt + "个");
                    }));
                    Dispatcher.Invoke(new Action(() => {
                        ListBoxOutput.Items.Add(name + " 消费了项目 " + consumeNum + "，现在还剩 " + remainedCnt + "个");
                    }));
                    remainedCnt--;
                }
                else
                {
                    q2.Enqueue(name);
                }
                mutex.ReleaseMutex();
                produce.Release();
                Thread.Sleep(rate * 1000);
                //                DateTime afterDT = System.DateTime.Now;
                //                TimeSpan ts = afterDT.Subtract(beforeDT);
                //                if (ts.TotalMilliseconds > timeUp) break;
                if (curCnt > Max_Size) break;
            }
        }
        void ProducerConsumer(int producerCnt, int consumerCnt, int productRate, int consumeRate
            , int buffer_size)
        {
            ListBoxOutput.Items.Clear();
   //         beforeDT = System.DateTime.Now;
            Thread[] producers = new Thread[producerCnt];
            for (int i = 0; i < producerCnt; i++)
            {
                producers[i] = new Thread(() => { produceItem("producer " + i, productRate); });
                producers[i].IsBackground = true;
                producers[i].Start();
            }
            Thread.Sleep(2000);

            Thread[] consumers = new Thread[consumerCnt];
            for (int i = 0; i < consumerCnt; i++)
            {
                consumers[i] = new Thread(() => { consumeItem("consumer " + i, consumeRate); });
                consumers[i].IsBackground = true;
                consumers[i].Start();
            }
            Console.WriteLine("End of producer consumer problem");
        }
        public void btnStart(object sender, RoutedEventArgs e)
        {
            int producer_count = 0;
            producer_count = int.Parse(textBox1.Text.Trim());

            int comsumer_count = 0;
            comsumer_count = int.Parse(textBox2.Text.Trim());

            int productRate = 1;
            productRate = int.Parse(textBox3.Text.Trim());

            int consumeRate = 1;
            consumeRate = int.Parse(textBox4.Text.Trim());

            btn1.IsEnabled = false;
            ProducerConsumer(producer_count, comsumer_count, productRate, consumeRate, buf_size);
            btn1.IsEnabled = true;
        }
        private delegate void updateDelegate(string comment);
        public void updateBox(string comment)
        {
            if (!ListBoxOutput.Dispatcher.CheckAccess())
            {
                updateDelegate d = showComment;
                ListBoxOutput.Dispatcher.Invoke(d, comment);
            }
            else
            {
                showComment((string)comment);
            }
        }
        public static Boolean isEmpty(String str)
        {
            if ((str == null) || "".Equals(str.Trim()) || "null".Equals(str.Trim()))
                return true;
            return false;
        }
        private void showComment(String comment)
        {
            if (isEmpty(comment)) return;
            ListBoxOutput.Items.Add(comment);
        }
    }
}
