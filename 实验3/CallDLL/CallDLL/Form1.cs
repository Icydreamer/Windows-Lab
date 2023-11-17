using System.Runtime.InteropServices;
namespace CallDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("CreateDLL.dll")]
        public extern static int power(int a);
        private void button_power_Click(object sender, EventArgs e)
        {
            //��ȡ��ǰ���̵�����·���������ļ���(������)��
            //string str = this.GetType().Assembly.Location;
            try
            {
                int num = Convert.ToInt32(textBox_power.Text);
                int ans = power(num);
                if (ans == -1)
                {
                    label_tip.Text = "��������";
                    label_power.Text = "";
                    return;
                }
                label_power.Text = ans.ToString();
                label_tip.Text = "����ɹ�";
            }
            catch
            {
                label_power.Text = "";
                label_tip.Text = "����������";
            }
        }

        [DllImport(".\\CreateDLL.dll")]
        public extern static int subtract(int a, int b);
        private void button_sub_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(tb_suba.Text);
                int b = Convert.ToInt32(tb_subb.Text);
                label_sub.Text = subtract(a, b).ToString();
                label_tip.Text = "����ɹ�";
            }
            catch
            {
                label_sub.Text = "";
                label_tip.Text = "����������";
            }
        }
    }
}