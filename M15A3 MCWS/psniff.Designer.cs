using M15A3_MCWS.Properties;

namespace M15A3_MCWS
{
    partial class psniff
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
            panel2 = new Panel();
            label13 = new Label();
            pictureBox1 = new PictureBox();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            label2 = new Label();
            textBox3 = new TextBox();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            button3 = new Button();
            comboBox1 = new ComboBox();
            button4 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(listView1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1904, 788);
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
            panel2.Location = new Point(-5, -5);
            panel2.Name = "panel2";
            panel2.Size = new Size(2117, 45);
            panel2.TabIndex = 35;
            panel2.MouseDown += panel1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label13.ForeColor = Color.Cyan;
            label13.Location = new Point(84, 15);
            label13.Name = "label13";
            label13.Size = new Size(80, 18);
            label13.TabIndex = 7;
            label13.Text = "M17 MCWS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.nguyenflag;
            pictureBox1.Location = new Point(17, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button18
            // 
            button18.FlatStyle = FlatStyle.Flat;
            button18.ForeColor = Color.MediumSpringGreen;
            button18.Location = new Point(1777, 8);
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
            button19.Location = new Point(1818, 8);
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
            button20.Location = new Point(1859, 8);
            button20.Name = "button20";
            button20.Size = new Size(35, 34);
            button20.TabIndex = 3;
            button20.Text = "X";
            button20.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1085, 147);
            label2.Name = "label2";
            label2.Size = new Size(78, 18);
            label2.TabIndex = 34;
            label2.Text = "Packet data";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(16, 16, 16);
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(1085, 172);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(803, 221);
            textBox3.TabIndex = 33;
            // 
            // listView1
            // 
            listView1.AllowColumnReorder = true;
            listView1.AutoArrange = false;
            listView1.BorderStyle = BorderStyle.None;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(12, 147);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(1066, 374);
            listView1.TabIndex = 25;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Number";
            columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Time";
            columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Source";
            columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Destination";
            columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Protocol";
            columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Length";
            columnHeader6.TextAlign = HorizontalAlignment.Right;
            columnHeader6.Width = 140;
            // 
            // button3
            // 
            button3.BackColor = Color.Lime;
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Black;
            button3.Location = new Point(1548, 76);
            button3.Name = "button3";
            button3.Size = new Size(274, 37);
            button3.TabIndex = 32;
            button3.Text = "Save the session to a pcap file";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_1;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(16, 16, 16);
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.ForeColor = Color.Cyan;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 115);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(1876, 26);
            comboBox1.TabIndex = 31;
            comboBox1.Text = "Select a network interface card";
            // 
            // button4
            // 
            button4.BackColor = Color.Lime;
            button4.BackgroundImageLayout = ImageLayout.None;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.Black;
            button4.Location = new Point(1388, 76);
            button4.Name = "button4";
            button4.Size = new Size(153, 37);
            button4.TabIndex = 30;
            button4.Text = "Open a pcap file";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Lime;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.Black;
            button2.Location = new Point(1248, 76);
            button2.Name = "button2";
            button2.Size = new Size(134, 37);
            button2.TabIndex = 29;
            button2.Text = "Stop sniffing";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1088, 25);
            textBox1.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 55);
            label1.Name = "label1";
            label1.Size = new Size(171, 18);
            label1.TabIndex = 27;
            label1.Text = "Enter the packet filters here";
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(1107, 76);
            button1.Name = "button1";
            button1.Size = new Size(134, 37);
            button1.TabIndex = 26;
            button1.Text = "Start sniffing";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // psniff
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1904, 788);
            Controls.Add(panel1);
            Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "psniff";
            Text = "M17 MCWS - Packet sniffer";
            Load += psniff_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button5;
        private Button button6;
        private GroupBox groupBox2;
        private Button button8;
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
        private Label label2;
        private TextBox textBox3;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Button button3;
        private ComboBox comboBox1;
        private Button button4;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}