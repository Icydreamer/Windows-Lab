namespace CallDLL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_power = new System.Windows.Forms.Button();
            this.textBox_power = new System.Windows.Forms.TextBox();
            this.tb_suba = new System.Windows.Forms.TextBox();
            this.tb_subb = new System.Windows.Forms.TextBox();
            this.label_sub = new System.Windows.Forms.Label();
            this.label_power = new System.Windows.Forms.Label();
            this.button_sub = new System.Windows.Forms.Button();
            this.label_tip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_power
            // 
            this.button_power.Location = new System.Drawing.Point(264, 99);
            this.button_power.Name = "button_power";
            this.button_power.Size = new System.Drawing.Size(112, 34);
            this.button_power.TabIndex = 0;
            this.button_power.Text = "阶乘";
            this.button_power.UseVisualStyleBackColor = true;
            this.button_power.Click += new System.EventHandler(this.button_power_Click);
            // 
            // textBox_power
            // 
            this.textBox_power.Location = new System.Drawing.Point(41, 103);
            this.textBox_power.Name = "textBox_power";
            this.textBox_power.Size = new System.Drawing.Size(150, 30);
            this.textBox_power.TabIndex = 1;
            // 
            // tb_suba
            // 
            this.tb_suba.Location = new System.Drawing.Point(42, 158);
            this.tb_suba.Name = "tb_suba";
            this.tb_suba.Size = new System.Drawing.Size(67, 30);
            this.tb_suba.TabIndex = 2;
            // 
            // tb_subb
            // 
            this.tb_subb.Location = new System.Drawing.Point(124, 158);
            this.tb_subb.Name = "tb_subb";
            this.tb_subb.Size = new System.Drawing.Size(67, 30);
            this.tb_subb.TabIndex = 3;
            // 
            // label_sub
            // 
            this.label_sub.AutoSize = true;
            this.label_sub.Location = new System.Drawing.Point(197, 158);
            this.label_sub.Name = "label_sub";
            this.label_sub.Size = new System.Drawing.Size(42, 24);
            this.label_sub.TabIndex = 4;
            this.label_sub.Text = "____";
            // 
            // label_power
            // 
            this.label_power.AutoSize = true;
            this.label_power.Location = new System.Drawing.Point(197, 106);
            this.label_power.Name = "label_power";
            this.label_power.Size = new System.Drawing.Size(42, 24);
            this.label_power.TabIndex = 5;
            this.label_power.Text = "____";
            // 
            // button_sub
            // 
            this.button_sub.Location = new System.Drawing.Point(264, 156);
            this.button_sub.Name = "button_sub";
            this.button_sub.Size = new System.Drawing.Size(112, 34);
            this.button_sub.TabIndex = 6;
            this.button_sub.Text = "求差";
            this.button_sub.UseVisualStyleBackColor = true;
            this.button_sub.Click += new System.EventHandler(this.button_sub_Click);
            // 
            // label_tip
            // 
            this.label_tip.AutoSize = true;
            this.label_tip.Location = new System.Drawing.Point(41, 38);
            this.label_tip.Name = "label_tip";
            this.label_tip.Size = new System.Drawing.Size(35, 24);
            this.label_tip.TabIndex = 7;
            this.label_tip.Text = "❤";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_tip);
            this.Controls.Add(this.button_sub);
            this.Controls.Add(this.label_power);
            this.Controls.Add(this.label_sub);
            this.Controls.Add(this.tb_subb);
            this.Controls.Add(this.tb_suba);
            this.Controls.Add(this.textBox_power);
            this.Controls.Add(this.button_power);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_power;
        private TextBox textBox_power;
        private TextBox tb_suba;
        private TextBox tb_subb;
        private Label label_sub;
        private Label label_power;
        private Button button_sub;
        private Label label_tip;
    }
}