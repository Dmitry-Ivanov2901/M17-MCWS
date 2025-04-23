namespace M15A3_MCWS
{
    partial class fileflood
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
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            button3 = new Button();
            button2 = new Button();
            groupBox2 = new GroupBox();
            comboBox3 = new ComboBox();
            rip = new CheckBox();
            trackBar1 = new TrackBar();
            label12 = new Label();
            comboBox1 = new ComboBox();
            groupBox1 = new GroupBox();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            label13 = new Label();
            pictureBox1 = new PictureBox();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1654, 696);
            panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dateTimePicker1);
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(button2);
            groupBox3.ForeColor = Color.Cyan;
            groupBox3.Location = new Point(12, 339);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(523, 120);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Trigger";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(7, 77);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(329, 28);
            dateTimePicker1.TabIndex = 17;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = Color.OrangeRed;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(152, 25);
            button3.Name = "button3";
            button3.Size = new Size(184, 46);
            button3.TabIndex = 16;
            button3.Text = "Schedule an attack";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.OrangeRed;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(7, 25);
            button2.Name = "button2";
            button2.Size = new Size(138, 46);
            button2.TabIndex = 15;
            button2.Text = "Start the attack";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox3);
            groupBox2.Controls.Add(rip);
            groupBox2.Controls.Add(trackBar1);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.ForeColor = Color.Cyan;
            groupBox2.Location = new Point(541, 60);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1097, 399);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Attack options";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(6, 61);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(1082, 28);
            comboBox3.TabIndex = 24;
            comboBox3.Text = "Select your default network adapter manually (in case of an error or if you have more NICs)";
            // 
            // rip
            // 
            rip.AutoSize = true;
            rip.Location = new Point(16, 289);
            rip.Name = "rip";
            rip.Size = new Size(246, 24);
            rip.TabIndex = 12;
            rip.Text = "Use random source IP addresses";
            rip.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(16, 339);
            trackBar1.Maximum = 20;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(631, 45);
            trackBar1.TabIndex = 9;
            trackBar1.Value = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(16, 317);
            label12.Name = "label12";
            label12.Size = new Size(238, 20);
            label12.TabIndex = 10;
            label12.Text = "Set the thread count for the attack";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "========DO NOT CLICK THE TABS WITH THE HEADER SIGNS========", "Normal TCP file flood", "Spoofed TCP file flood [DON´T USE FILES LARGER THAN 1500 BYTES]." });
            comboBox1.Location = new Point(6, 27);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(548, 28);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Method list";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.ForeColor = Color.Cyan;
            groupBox1.Location = new Point(12, 60);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(523, 274);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Targetting";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(7, 203);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(509, 28);
            textBox4.TabIndex = 7;
            textBox4.Text = "1.9.7.5";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 180);
            label5.Name = "label5";
            label5.Size = new Size(169, 20);
            label5.TabIndex = 6;
            label5.Text = "Enter the source IP here";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(7, 151);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(509, 28);
            textBox3.TabIndex = 5;
            textBox3.Text = "443";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 129);
            label4.Name = "label4";
            label4.Size = new Size(214, 20);
            label4.TabIndex = 4;
            label4.Text = "Enter the destination port here";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(7, 97);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(509, 28);
            textBox2.TabIndex = 3;
            textBox2.Text = "443";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 74);
            label3.Name = "label3";
            label3.Size = new Size(183, 20);
            label3.TabIndex = 2;
            label3.Text = "Enter the source port here";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(7, 45);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(509, 28);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 23);
            label2.Name = "label2";
            label2.Size = new Size(182, 20);
            label2.TabIndex = 0;
            label2.Text = "Enter the enemy's IP here";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(label13);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(button7);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(label1);
            panel2.ForeColor = Color.Red;
            panel2.Location = new Point(-7, -3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1698, 45);
            panel2.TabIndex = 8;
            panel2.MouseDown += panel1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.Cyan;
            label13.Location = new Point(81, 10);
            label13.Name = "label13";
            label13.Size = new Size(93, 20);
            label13.TabIndex = 7;
            label13.Text = "M17 MCWS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.nguyenflag;
            pictureBox1.Location = new Point(19, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = Color.MediumSpringGreen;
            button7.Location = new Point(1527, 7);
            button7.Name = "button7";
            button7.Size = new Size(35, 34);
            button7.TabIndex = 5;
            button7.Text = "_";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = Color.DarkOrange;
            button6.Location = new Point(1568, 7);
            button6.Name = "button6";
            button6.Size = new Size(35, 34);
            button6.TabIndex = 4;
            button6.Text = "🗖";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.FromArgb(255, 57, 57);
            button5.Location = new Point(1609, 7);
            button5.Name = "button5";
            button5.Size = new Size(35, 34);
            button5.TabIndex = 3;
            button5.Text = "Xa";
            button5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nunito", 14.25F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(129, 0);
            label1.Name = "label1";
            label1.Size = new Size(117, 26);
            label1.TabIndex = 2;
            label1.Text = "M17 MCWS";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileflood
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1654, 696);
            Controls.Add(panel1);
            Font = new Font("Nunito", 11.25F);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "fileflood";
            Text = "M17 MCWS - L4 DoS / DDoS menu";
            Load += fileflood_Load;
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox3;
        private DateTimePicker dateTimePicker1;
        private Button button3;
        private Button button2;
        private GroupBox groupBox2;
        private ComboBox comboBox3;
        private CheckBox rip;
        private TrackBar trackBar1;
        private Label label12;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private Panel panel2;
        private Label label13;
        private PictureBox pictureBox1;
        private Button button7;
        private Button button6;
        private Button button5;
        private Label label1;
        private OpenFileDialog openFileDialog1;
    }
}