using M15A3_MCWS.Properties;

namespace M15A3_MCWS
{
    partial class portscan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            panel2 = new Panel();
            label13 = new Label();
            pictureBox1 = new PictureBox();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            checkBox1 = new CheckBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label6 = new Label();
            textBox5 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(checkBox4);
            panel1.Controls.Add(checkBox3);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(radioButton5);
            panel1.Controls.Add(radioButton4);
            panel1.Controls.Add(radioButton3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1904, 788);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(1174, 353);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(459, 26);
            checkBox4.TabIndex = 41;
            checkBox4.Text = "Disable subdomain scanning (only when scanning a domain)";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(1062, 353);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(106, 26);
            checkBox3.TabIndex = 40;
            checkBox3.Text = "Don´t ping";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(933, 353);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(123, 26);
            checkBox2.TabIndex = 39;
            checkBox2.Text = "OS detection";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(1233, 324);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(106, 26);
            radioButton5.TabIndex = 38;
            radioButton5.TabStop = true;
            radioButton5.Text = "NULL scan";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(1138, 324);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(89, 26);
            radioButton4.TabIndex = 37;
            radioButton4.TabStop = true;
            radioButton4.Text = "FIN scan";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(1035, 324);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(97, 26);
            radioButton3.TabIndex = 36;
            radioButton3.TabStop = true;
            radioButton3.Text = "ACK scan";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(label13);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(button18);
            panel2.Controls.Add(button19);
            panel2.Controls.Add(button20);
            panel2.ForeColor = Color.Red;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1929, 38);
            panel2.TabIndex = 35;
            panel2.MouseDown += panel1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.Cyan;
            label13.Location = new Point(82, 4);
            label13.Name = "label13";
            label13.Size = new Size(101, 22);
            label13.TabIndex = 7;
            label13.Text = "M17 MCWS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.nguyenflag;
            pictureBox1.Location = new Point(15, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button18
            // 
            button18.FlatStyle = FlatStyle.Flat;
            button18.ForeColor = Color.MediumSpringGreen;
            button18.Location = new Point(1775, 1);
            button18.Name = "button18";
            button18.Size = new Size(35, 34);
            button18.TabIndex = 5;
            button18.Text = "🗕";
            button18.UseVisualStyleBackColor = true;
            button18.Click += pictureBox4_Click;
            // 
            // button19
            // 
            button19.FlatStyle = FlatStyle.Flat;
            button19.ForeColor = Color.DarkOrange;
            button19.Location = new Point(1816, 1);
            button19.Name = "button19";
            button19.Size = new Size(35, 34);
            button19.TabIndex = 4;
            button19.Text = "🗖";
            button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            button20.FlatStyle = FlatStyle.Flat;
            button20.ForeColor = Color.FromArgb(255, 57, 57);
            button20.Location = new Point(1857, 1);
            button20.Name = "button20";
            button20.Size = new Size(35, 34);
            button20.TabIndex = 3;
            button20.Text = "Xa";
            button20.UseVisualStyleBackColor = true;
            button20.Click += pictureBox2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(832, 353);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(99, 26);
            checkBox1.TabIndex = 33;
            checkBox1.Text = "UDP scan";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(933, 324);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(96, 26);
            radioButton2.TabIndex = 31;
            radioButton2.TabStop = true;
            radioButton2.Text = "SYN scan";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(832, 324);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(95, 26);
            radioButton1.TabIndex = 30;
            radioButton1.TabStop = true;
            radioButton1.Text = "connect()";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(538, 111);
            label6.Name = "label6";
            label6.Size = new Size(396, 22);
            label6.TabIndex = 27;
            label6.Text = "Enter the ports that you want to scan(Separate with ,)";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(535, 136);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(448, 145);
            textBox5.TabIndex = 21;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(19, 282);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(185, 39);
            button1.TabIndex = 26;
            button1.Text = "Scan the IP";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(15, 353);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(711, 405);
            textBox2.TabIndex = 25;
            textBox2.MouseDown += panel1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 328);
            label2.Name = "label2";
            label2.Size = new Size(66, 22);
            label2.TabIndex = 24;
            label2.Text = "Results";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 75);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(187, 22);
            label1.TabIndex = 23;
            label1.Text = "Enter the IP to scan here";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(19, 101);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(262, 29);
            textBox1.TabIndex = 22;
            // 
            // portscan
            // 
            AutoScaleDimensions = new SizeF(9F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1904, 788);
            Controls.Add(panel1);
            Font = new Font("Nunito", 12F);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "portscan";
            Text = "M17 MCWS - Cloudflare bypasser";
            Load += portscan_Load;
            MouseMove += panel1_Click;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button5;
        private Button button6;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private PictureBox pictureBox5;
        private Panel panel1;
        private Panel panel2;
        private Label label13;
        private PictureBox pictureBox1;
        private Button button18;
        private Button button19;
        private Button button20;
        private CheckBox checkBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label6;
        private TextBox textBox5;
        private Button button1;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton5;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
    }
}