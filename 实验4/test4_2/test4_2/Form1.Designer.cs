namespace test4_2
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
            this.label_m = new System.Windows.Forms.Label();
            this.button_m = new System.Windows.Forms.Button();
            this.label_d = new System.Windows.Forms.Label();
            this.button_d = new System.Windows.Forms.Button();
            this.textBox_m1 = new System.Windows.Forms.TextBox();
            this.textBox_m2 = new System.Windows.Forms.TextBox();
            this.textBox_d1 = new System.Windows.Forms.TextBox();
            this.textBox_d2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_m
            // 
            this.label_m.AutoSize = true;
            this.label_m.Location = new System.Drawing.Point(566, 41);
            this.label_m.Name = "label_m";
            this.label_m.Size = new System.Drawing.Size(74, 24);
            this.label_m.TabIndex = 0;
            this.label_m.Text = "________";
            // 
            // button_m
            // 
            this.button_m.Location = new System.Drawing.Point(399, 37);
            this.button_m.Name = "button_m";
            this.button_m.Size = new System.Drawing.Size(112, 34);
            this.button_m.TabIndex = 1;
            this.button_m.Text = "减法";
            this.button_m.UseVisualStyleBackColor = true;
            this.button_m.Click += new System.EventHandler(this.button_m_Click);
            // 
            // label_d
            // 
            this.label_d.AutoSize = true;
            this.label_d.Location = new System.Drawing.Point(566, 116);
            this.label_d.Name = "label_d";
            this.label_d.Size = new System.Drawing.Size(74, 24);
            this.label_d.TabIndex = 2;
            this.label_d.Text = "________";
            // 
            // button_d
            // 
            this.button_d.Location = new System.Drawing.Point(399, 106);
            this.button_d.Name = "button_d";
            this.button_d.Size = new System.Drawing.Size(112, 34);
            this.button_d.TabIndex = 3;
            this.button_d.Text = "除法";
            this.button_d.UseVisualStyleBackColor = true;
            this.button_d.Click += new System.EventHandler(this.button_d_Click);
            // 
            // textBox_m1
            // 
            this.textBox_m1.Location = new System.Drawing.Point(29, 41);
            this.textBox_m1.Name = "textBox_m1";
            this.textBox_m1.Size = new System.Drawing.Size(150, 30);
            this.textBox_m1.TabIndex = 4;
            this.textBox_m1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_m1_KeyPress);
            // 
            // textBox_m2
            // 
            this.textBox_m2.Location = new System.Drawing.Point(205, 41);
            this.textBox_m2.Name = "textBox_m2";
            this.textBox_m2.Size = new System.Drawing.Size(150, 30);
            this.textBox_m2.TabIndex = 5;
            this.textBox_m2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_m2_KeyPress);
            // 
            // textBox_d1
            // 
            this.textBox_d1.Location = new System.Drawing.Point(29, 106);
            this.textBox_d1.Name = "textBox_d1";
            this.textBox_d1.Size = new System.Drawing.Size(150, 30);
            this.textBox_d1.TabIndex = 7;
            this.textBox_d1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_d1_KeyPress);
            // 
            // textBox_d2
            // 
            this.textBox_d2.Location = new System.Drawing.Point(205, 106);
            this.textBox_d2.Name = "textBox_d2";
            this.textBox_d2.Size = new System.Drawing.Size(150, 30);
            this.textBox_d2.TabIndex = 8;
            this.textBox_d2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_d2_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_d);
            this.Controls.Add(this.button_d);
            this.Controls.Add(this.textBox_d2);
            this.Controls.Add(this.textBox_d1);
            this.Controls.Add(this.label_m);
            this.Controls.Add(this.button_m);
            this.Controls.Add(this.textBox_m2);
            this.Controls.Add(this.textBox_m1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_m;
        private Button button_m;
        private Label label_d;
        private Button button_d;
        private TextBox textBox_m1;
        private TextBox textBox_m2;
        private TextBox textBox_d1;
        private TextBox textBox_d2;
    }
}