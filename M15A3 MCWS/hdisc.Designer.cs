namespace M15A3_MCWS
{
    partial class hdisc
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
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label6 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            button1 = new Button();
            checkBox1 = new CheckBox();
            label7 = new Label();
            textBox4 = new TextBox();
            label8 = new Label();
            cIcmp = new RadioButton();
            cTcp = new RadioButton();
            cHttp = new RadioButton();
            cUdp = new RadioButton();
            numericUpDown1 = new NumericUpDown();
            label9 = new Label();
            comboBox3 = new ComboBox();
            panel2 = new Panel();
            label13 = new Label();
            pictureBox1 = new PictureBox();
            button18 = new Button();
            button2 = new Button();
            button19 = new Button();
            button3 = new Button();
            button4 = new Button();
            button20 = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.Location = new Point(529, 153);
            textBox3.Margin = new Padding(4, 6, 4, 6);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(380, 28);
            textBox3.TabIndex = 39;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.WindowFrame;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.ForeColor = Color.Lime;
            textBox2.Location = new Point(22, 260);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Both;
            textBox2.Size = new Size(1411, 612);
            textBox2.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 231);
            label6.Name = "label6";
            label6.Size = new Size(58, 20);
            label6.TabIndex = 31;
            label6.Text = "Results";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(22, 120);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(500, 28);
            textBox1.TabIndex = 26;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 91);
            label5.Name = "label5";
            label5.Size = new Size(269, 20);
            label5.TabIndex = 24;
            label5.Text = "Enter the subnet to scan for hosts here";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.OrangeRed;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(22, 160);
            button1.Name = "button1";
            button1.Size = new Size(165, 68);
            button1.TabIndex = 32;
            button1.Text = "Scan";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(371, 227);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(339, 24);
            checkBox1.TabIndex = 34;
            checkBox1.Text = "Use CIDR notations (default CIDR value is /24)";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(529, 120);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(601, 20);
            label7.TabIndex = 40;
            label7.Text = "Specify a DNS server that you want to use for reverse lookups (e.g. 1.1.1.1) *OPTIONAL*";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1129, 153);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(261, 28);
            textBox4.TabIndex = 42;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1129, 120);
            label8.Name = "label8";
            label8.Size = new Size(430, 20);
            label8.TabIndex = 44;
            label8.Text = "Enter the port on which you want to send the UDP / TCP pings";
            // 
            // cIcmp
            // 
            cIcmp.AutoSize = true;
            cIcmp.Location = new Point(371, 197);
            cIcmp.Name = "cIcmp";
            cIcmp.Size = new Size(63, 24);
            cIcmp.TabIndex = 46;
            cIcmp.TabStop = true;
            cIcmp.Text = "ICMP";
            cIcmp.UseVisualStyleBackColor = true;
            // 
            // cTcp
            // 
            cTcp.AutoSize = true;
            cTcp.Location = new Point(440, 197);
            cTcp.Name = "cTcp";
            cTcp.Size = new Size(54, 24);
            cTcp.TabIndex = 47;
            cTcp.TabStop = true;
            cTcp.Text = "TCP";
            cTcp.UseVisualStyleBackColor = true;
            // 
            // cHttp
            // 
            cHttp.AutoSize = true;
            cHttp.Location = new Point(498, 198);
            cHttp.Name = "cHttp";
            cHttp.Size = new Size(65, 24);
            cHttp.TabIndex = 48;
            cHttp.TabStop = true;
            cHttp.Text = "HTTP";
            cHttp.UseVisualStyleBackColor = true;
            // 
            // cUdp
            // 
            cUdp.AutoSize = true;
            cUdp.Location = new Point(569, 198);
            cUdp.Name = "cUdp";
            cUdp.Size = new Size(58, 24);
            cUdp.TabIndex = 49;
            cUdp.TabStop = true;
            cUdp.Text = "UDP";
            cUdp.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(900, 223);
            numericUpDown1.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(214, 28);
            numericUpDown1.TabIndex = 50;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(900, 201);
            label9.Name = "label9";
            label9.Size = new Size(214, 20);
            label9.TabIndex = 51;
            label9.Text = "Enter the timeout for the pings";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(460, 65);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(1083, 28);
            comboBox3.TabIndex = 52;
            comboBox3.Text = "Select your default network adapter manually (in case of an error)";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(label13);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(button18);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button19);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button20);
            panel2.ForeColor = Color.Red;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1615, 40);
            panel2.TabIndex = 53;
            panel2.MouseDown += panel1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Nunito", 12F);
            label13.ForeColor = Color.Cyan;
            label13.Location = new Point(79, 7);
            label13.Name = "label13";
            label13.Size = new Size(101, 22);
            label13.TabIndex = 7;
            label13.Text = "M17 MCWS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.nguyenflag;
            pictureBox1.Location = new Point(12, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button18
            // 
            button18.FlatStyle = FlatStyle.Flat;
            button18.ForeColor = Color.MediumSpringGreen;
            button18.Location = new Point(1427, 3);
            button18.Name = "button18";
            button18.Size = new Size(34, 34);
            button18.TabIndex = 5;
            button18.Text = "🗕";
            button18.UseVisualStyleBackColor = true;
            button18.Click += pictureBox4_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.MediumSpringGreen;
            button2.Location = new Point(1794, 10);
            button2.Name = "button2";
            button2.Size = new Size(35, 34);
            button2.TabIndex = 5;
            button2.Text = "🗕";
            button2.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            button19.FlatStyle = FlatStyle.Flat;
            button19.ForeColor = Color.DarkOrange;
            button19.Location = new Point(1468, 3);
            button19.Name = "button19";
            button19.Size = new Size(34, 34);
            button19.TabIndex = 4;
            button19.Text = "🗖";
            button19.UseVisualStyleBackColor = true;
            button19.Click += pictureBox3_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.DarkOrange;
            button3.Location = new Point(1835, 10);
            button3.Name = "button3";
            button3.Size = new Size(35, 34);
            button3.TabIndex = 4;
            button3.Text = "🗖";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.FromArgb(255, 57, 57);
            button4.Location = new Point(1876, 10);
            button4.Name = "button4";
            button4.Size = new Size(35, 34);
            button4.TabIndex = 3;
            button4.Text = "X";
            button4.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            button20.FlatStyle = FlatStyle.Flat;
            button20.ForeColor = Color.FromArgb(255, 57, 57);
            button20.Location = new Point(1509, 3);
            button20.Name = "button20";
            button20.Size = new Size(34, 34);
            button20.TabIndex = 3;
            button20.Text = "X";
            button20.UseVisualStyleBackColor = true;
            button20.Click += pictureBox2_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(numericUpDown1);
            panel1.Controls.Add(cUdp);
            panel1.Controls.Add(cHttp);
            panel1.Controls.Add(cTcp);
            panel1.Controls.Add(cIcmp);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1546, 889);
            panel1.TabIndex = 0;
            // 
            // hdisc
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1546, 889);
            Controls.Add(panel1);
            Font = new Font("Nunito", 11.25F);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 6, 4, 6);
            MaximizeBox = false;
            Name = "hdisc";
            Text = "  ";
            Load += hdisc_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox3;
        private TextBox textBox2;
        private Label label6;
        private TextBox textBox1;
        private Label label5;
        private Button button1;
        private CheckBox checkBox1;
        private Label label7;
        private TextBox textBox4;
        private Label label8;
        private RadioButton cIcmp;
        private RadioButton cTcp;
        private RadioButton cHttp;
        private RadioButton cUdp;
        private NumericUpDown numericUpDown1;
        private Label label9;
        private ComboBox comboBox3;
        private Panel panel2;
        private Label label13;
        private PictureBox pictureBox1;
        private Button button18;
        private Button button2;
        private Button button19;
        private Button button3;
        private Button button4;
        private Button button20;
        private Panel panel1;
    }
}