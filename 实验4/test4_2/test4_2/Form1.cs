namespace test4_2
{
    public partial class Form1 : Form
    {
        private string guid = "C03BE966-41B5-4778-B45C-01C340249442";
        public Form1()
        {
            InitializeComponent();
        }

        private void button_m_Click(object sender, EventArgs e)
        {
            if (textBox_m1.Text == "")
            {
                label_m.Text = "操作数1为空，请重新输入！";
                return;
            }
            else if (textBox_m2.Text == "")
            {
                label_m.Text = "操作数2为空，请重新输入！";
                return;
            }

            string strText1 = textBox_m1.Text.Trim();
            string strText2 = textBox_m2.Text.Trim();
            
            string ret = "";
            Type dycomType = Type.GetTypeFromCLSID(new Guid(guid));
            if (dycomType != null)
            {
                //创建类实例
                dynamic dycomObject = Activator.CreateInstance(dycomType);
                //调用
                
                ret = dycomObject?.Minus(int.Parse(strText1), int.Parse(strText2));
            }
            label_m.Text = String.Concat(ret);
        }

        private void button_d_Click(object sender, EventArgs e)
        {
            if (textBox_d1.Text == "")
            {
                label_d.Text = "操作数1为空，请重新输入！";
                return;
            }
            else if (textBox_d2.Text == "")
            {
                label_d.Text = "操作数2为空，请重新输入！";
                return;
            }

            string strText1 = textBox_d1.Text.Trim();
            string strText2 = textBox_d2.Text.Trim();

            string ret = "";
            Type dycomType = Type.GetTypeFromCLSID(new Guid(guid));
            if (dycomType != null)
            {
                //创建类实例
                dynamic dycomObject = Activator.CreateInstance(dycomType);
                //调用
                ret = dycomObject?.Divide(int.Parse(strText1), int.Parse(strText2));
            }
            label_d.Text = String.Concat(ret);
        }

        
        public void keep_int(KeyPressEventArgs e)
        {
            int key = Convert.ToInt32(e.KeyChar);
            if (!(48 <= key && key <= 58 || key == 8)) //数字、 Backspace
            {
                this.Text = "keyChar:" + key.ToString();
                e.Handled = true;
            }
            else this.Text = "";
        }
        private void textBox_m1_KeyPress(object sender, KeyPressEventArgs e)
        {
            keep_int(e);
        }
        private void textBox_m2_KeyPress(object sender, KeyPressEventArgs e)
        {
            keep_int(e);
        }

        private void textBox_d1_KeyPress(object sender, KeyPressEventArgs e)
        {
            keep_int(e);
        }

        private void textBox_d2_KeyPress(object sender, KeyPressEventArgs e)
        {
            keep_int(e);
        }
    }
}
