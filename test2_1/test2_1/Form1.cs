namespace test2_1
{
    public partial class Form1 : Form
    {
        //链表：保存数据
        LinkedList<int> link = new LinkedList<int>();

        //缓冲区大小
        const int SemaphoreNum = 5;
        //关于有产品缓冲区数量的信号量
        Semaphore filled_num;
        //关于无产品缓冲区数量的信号量
        Semaphore empty_num;
        //互斥量：控制对缓冲区的访问
        Mutex mutex;

        //生产者消费者线程组
        Thread[] producers;
        Thread[] consumers;
        //生产者消费者处理时间
        const int ProduceSleep = 1000;
        const int ConsumeSleep = 500;

        //是否正在交易
        bool isStart;
        //是否取消交易
        CancellationTokenSource cts;

        public Form1()
        {
            InitializeComponent();
            isStart = false;
        }
        private void button_s_Click(object sender, EventArgs e)
        {
            if (!isStart)
            {
                string msg;
                try
                {
                    filled_num = new Semaphore(0, SemaphoreNum);
                    empty_num = new Semaphore(SemaphoreNum, SemaphoreNum);
                    cts = new CancellationTokenSource();
                    producers = new Thread[int.Parse(textBox_pn.Text.Trim())];
                    consumers = new Thread[int.Parse(textBox_cn.Text.Trim())];
                }
                catch (Exception)
                {
                    msg = "Wrong entering, please correct.\r\n";
                    textBox_tip.AppendText(msg);
                    textBox_tip.ScrollToCaret();
                    return;
                }
                mutex = new Mutex();
                isStart = true;

                //创建生产者消费者线程
                for (int i = 0; i < int.Parse(textBox_pn.Text.Trim()); i++)
                {
                    int ID = i + 1;
                    producers[i] = new Thread(() => { produce(ID); });
                    producers[i].IsBackground = true;
                    producers[i].Start();
                }
                Thread.Sleep(300);
                for (int i = 0; i < int.Parse(textBox_cn.Text.Trim()); i++)
                {
                    int ID = i + 1;
                    consumers[i] = new Thread(() => { consume(ID); });
                    consumers[i].IsBackground = true;
                    consumers[i].Start();
                }
                msg = "Running.\r\n";
                textBox_tip.AppendText(msg);
                textBox_tip.ScrollToCaret();
            }
            else
            {
                string msg = "You have to stop first.\r\n";
                textBox_tip.AppendText(msg);
                textBox_tip.ScrollToCaret();
            }
        }

        //生产者的produce,ProduceSleep时间生产一个,涂色一个
        public void produce(int ID)
        {
            while (true)
            {
                try
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("producer" + ID + "stop");
                        break;
                    }
                    empty_num.WaitOne();
                    mutex.WaitOne();
                    Thread.Sleep(ProduceSleep);

                    int product = SaveData();

                    update(ID, product);
                    mutex.ReleaseMutex();
                    filled_num.Release();
                }
                catch (Exception)
                {
                    return;
                }

            }

        }

        public int SaveData()
        {
            Random rd = new Random();
            int product = rd.Next(1, 100);
            if (link == null)
            {
                link.AddFirst(product);
            }
            else
            {
                link.AddLast(product);
            }
            return product;
        }


        //消费者的consume， ConsumeSleep消费一个，涂色一个
        public void consume(int ID)
        {
            while (true)
            {
                try
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("consumer" + ID + "stop");
                        break;
                    }
                    filled_num.WaitOne();
                    mutex.WaitOne();
                    Thread.Sleep(ConsumeSleep);

                    int one = link.First();
                    link.RemoveFirst();


                    update(ID * -1, one);
                    mutex.ReleaseMutex();
                    empty_num.Release();
                }
                catch (Exception)
                {
                    return;
                }

            }
        }

        private delegate void Update(int index, int product);
        //index绝对值为生产者或消费者的编号，负的是消费者

        //生产者消费者的回调函数
        public void update(int ID, int product)
        {
            //Invoke(new Update(Update_pd), new object[] {ID, product});
            Invoke(new Update(UpdateTextBox), new object[] { ID, product });
        }

        public void Update_pd(int ID, int product)
        {   
            System.Drawing.Color color;
            if (ID < 0 )
                color = System.Drawing.Color.Gray;
            else
                color = System.Drawing.Color.GreenYellow;

            Label lb = null;
            if(ID > 0)
            {
                if (pd1.Text == "")
                    lb = pd1;
                else if (pd2.Text == "")
                    lb = pd2;
                else if (pd3.Text == "")
                    lb = pd3;
                else if (pd4.Text == "")
                    lb = pd4;
                else if (pd5.Text == "")
                    lb = pd5;
            }
            else
            {
                if (product.ToString() == pd1.Text)
                    lb = pd1;
                else if (product.ToString() == pd2.Text)
                    lb = pd2;
                else if (product.ToString() == pd3.Text)
                    lb = pd3;
                else if (product.ToString() == pd4.Text)
                    lb = pd4;
                else if (product.ToString() == pd5.Text)
                    lb = pd5;
            }

            lb.BackColor = color;
            if (ID > 0) lb.Text = product.ToString();
            else
            {
                lb.Text = "";
            }
        }

        //更新窗体中关于生产消费过程的信息
        public void UpdateTextBox(int ID, int product)
        {
            string msg;
            if (ID < 0)
            {
                msg = "Consumer" + ID * -1 + " pull " + product.ToString() + "\r\n";
                if (ID == -1)
                {
                    textBox_c1.AppendText(msg);
                    textBox_c1.ScrollToCaret();
                }else if (ID == -2)
                {
                    textBox_c2.AppendText(msg);
                    textBox_c2.ScrollToCaret();
                }
                
            }
            else
            {
                msg = "Producer" + ID + " put " + product.ToString() + "\r\n";
                textBox_p.AppendText(msg);
                textBox_p.ScrollToCaret();
            }
            textBox.AppendText(msg);//追加文本
            textBox.ScrollToCaret();
        }

        public void reset_buffer()
        {
            //复原boxes
            System.Drawing.Color color = System.Drawing.Color.Gray;
            pd1.BackColor = color;
            pd1.Text = "";
            pd2.BackColor = color;
            pd2.Text = "";
            pd3.BackColor = color;
            pd3.Text = "";
            pd4.BackColor = color;
            pd4.Text = "";
            pd5.BackColor = color;
            pd5.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isStart)
            {
                cts.Cancel();
                link.Clear();
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            if (isStart)
            {
                cts.Cancel();
                link.Clear();
                textBox_tip.Text += "Stopped.\r\n";
                isStart = false;
                string msg = "-----------\r\n";
                textBox_tip.AppendText(msg);
                textBox_tip.ScrollToCaret();

            }
            else
            {
                string msg = "You have to start first.\r\n";
                textBox_tip.AppendText(msg);
                textBox_tip.ScrollToCaret();
            }
        }

        private void button_c_Click(object sender, EventArgs e)
        {
            if (isStart)
            {
                string msg = "You have to stop first.\r\n";
                textBox_tip.AppendText(msg);
                textBox_tip.ScrollToCaret();
            }
            else
            {
                reset_buffer();
                textBox_c1.Clear();
                textBox_c2.Clear();
                textBox_p.Clear();
                textBox.Clear();
            }
        }
    }
}