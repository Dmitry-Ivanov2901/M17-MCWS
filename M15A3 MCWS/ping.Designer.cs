
namespace M15A3_MCWS
{
    partial class ping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ping));
            panel1 = new Panel();
            panel2 = new Panel();
            label13 = new Label();
            pictureBox1 = new PictureBox();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            checkBox2 = new CheckBox();
            comboBox3 = new ComboBox();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            label8 = new Label();
            textBox5 = new TextBox();
            groupBox1 = new GroupBox();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label2 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            button6 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(numericUpDown1);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1920, 1061);
            panel1.TabIndex = 0;
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
            panel2.Size = new Size(1958, 38);
            panel2.TabIndex = 36;
            panel2.MouseDown += panel1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Nunito", 12F);
            label13.ForeColor = Color.Cyan;
            label13.Location = new Point(86, 7);
            label13.Name = "label13";
            label13.Size = new Size(101, 22);
            label13.TabIndex = 7;
            label13.Text = "M17 MCWS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.nguyenflag;
            pictureBox1.Location = new Point(19, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button18
            // 
            button18.FlatStyle = FlatStyle.Flat;
            button18.ForeColor = Color.MediumSpringGreen;
            button18.Location = new Point(1791, 3);
            button18.Name = "button18";
            button18.Size = new Size(35, 34);
            button18.TabIndex = 5;
            button18.Text = "🗕";
            button18.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            button19.FlatStyle = FlatStyle.Flat;
            button19.ForeColor = Color.DarkOrange;
            button19.Location = new Point(1832, 3);
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
            button20.Location = new Point(1873, 3);
            button20.Name = "button20";
            button20.Size = new Size(35, 34);
            button20.TabIndex = 3;
            button20.Text = "X";
            button20.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(641, 345);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(330, 22);
            checkBox2.TabIndex = 35;
            checkBox2.Text = "Select your default network interface card manually";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(638, 313);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(877, 26);
            comboBox3.TabIndex = 34;
            comboBox3.Text = "Select your default network adapter manually (in case of an error)";
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(893, 257);
            label5.Name = "label5";
            label5.Size = new Size(207, 18);
            label5.TabIndex = 33;
            label5.Text = "Enter the timeout value here in ms";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(890, 278);
            numericUpDown1.Maximum = new decimal(new int[] { 1874919423, 2328306, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(210, 25);
            numericUpDown1.TabIndex = 32;
            numericUpDown1.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(893, 179);
            label8.Name = "label8";
            label8.Size = new Size(414, 18);
            label8.TabIndex = 31;
            label8.Text = "Enter the port on which you want to send the TCP or UDP ping probes";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(890, 208);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(146, 25);
            textBox5.TabIndex = 30;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.ForeColor = Color.Cyan;
            groupBox1.Location = new Point(562, 208);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(325, 80);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ping type";
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(128, 22);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(50, 22);
            radioButton4.TabIndex = 15;
            radioButton4.TabStop = true;
            radioButton4.Text = "TCP";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(69, 22);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(53, 22);
            radioButton3.TabIndex = 14;
            radioButton3.TabStop = true;
            radioButton3.Text = "UDP";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(6, 50);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(276, 22);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "HTTP(Use only on domains and L7 targets)";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(57, 22);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "ICMP";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(433, 208);
            label2.Name = "label2";
            label2.Size = new Size(125, 18);
            label2.TabIndex = 28;
            label2.Text = "Amount of the pings";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(430, 235);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(129, 25);
            textBox3.TabIndex = 27;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(16, 16, 16);
            textBox2.ForeColor = Color.Cyan;
            textBox2.Location = new Point(19, 313);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(616, 383);
            textBox2.TabIndex = 26;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(16, 16, 16);
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(19, 235);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(120, 68);
            button6.TabIndex = 25;
            button6.Text = "Ping";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 101);
            label1.Name = "label1";
            label1.Size = new Size(206, 18);
            label1.TabIndex = 24;
            label1.Text = "Enter the target IP or domain here";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(19, 129);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(348, 25);
            textBox1.TabIndex = 23;
            // 
            // ping
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1920, 1061);
            Controls.Add(panel1);
            Font = new Font("Nunito", 9.749998F);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "ping";
            Text = "M17 MCWS | ICMP ping";
            Load += ping_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label13;
        private PictureBox pictureBox1;
        private Button button18;
        private Button button19;
        private Button button20;
        private CheckBox checkBox2;
        private ComboBox comboBox3;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private Label label8;
        private TextBox textBox5;
        private GroupBox groupBox1;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label2;
        private TextBox textBox3;
        private TextBox textBox2;
        private Button button6;
        private Label label1;
        private TextBox textBox1;
    }
}