using M15A3_MCWS.Properties;

namespace M15A3_MCWS
{
    partial class cfb
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
            results = new RichTextBox();
            panel2 = new Panel();
            label13 = new Label();
            pictureBox1 = new PictureBox();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            label4 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
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
            panel1.Controls.Add(results);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1904, 788);
            panel1.TabIndex = 0;
            // 
            // results
            // 
            results.BackColor = Color.FromArgb(64, 64, 64);
            results.BorderStyle = BorderStyle.None;
            results.Location = new Point(13, 365);
            results.Name = "results";
            results.Size = new Size(695, 400);
            results.TabIndex = 32;
            results.Text = "";
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
            panel2.Location = new Point(-5, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(2005, 42);
            panel2.TabIndex = 31;
            panel2.MouseDown += panel1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label13.ForeColor = Color.Cyan;
            label13.Location = new Point(85, 10);
            label13.Name = "label13";
            label13.Size = new Size(80, 18);
            label13.TabIndex = 7;
            label13.Text = "M17 MCWS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.nguyenflag;
            pictureBox1.Location = new Point(18, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button18
            // 
            button18.FlatStyle = FlatStyle.Flat;
            button18.ForeColor = Color.MediumSpringGreen;
            button18.Location = new Point(1770, 3);
            button18.Name = "button18";
            button18.Size = new Size(35, 34);
            button18.TabIndex = 5;
            button18.Text = "🗕";
            button18.UseVisualStyleBackColor = true;
            button18.Click += pictureBox4_Click_1;
            // 
            // button19
            // 
            button19.FlatStyle = FlatStyle.Flat;
            button19.ForeColor = Color.DarkOrange;
            button19.Location = new Point(1811, 3);
            button19.Name = "button19";
            button19.Size = new Size(35, 34);
            button19.TabIndex = 4;
            button19.Text = "🗖";
            button19.UseVisualStyleBackColor = true;
            button19.Click += pictureBox3_Click_1;
            // 
            // button20
            // 
            button20.FlatStyle = FlatStyle.Flat;
            button20.ForeColor = Color.FromArgb(255, 57, 57);
            button20.Location = new Point(1852, 3);
            button20.Name = "button20";
            button20.Size = new Size(35, 34);
            button20.TabIndex = 3;
            button20.Text = "X";
            button20.UseVisualStyleBackColor = true;
            button20.Click += pictureBox2_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(281, 152);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(330, 18);
            label4.TabIndex = 30;
            label4.Text = "Specify a DNS server that you want to use (e.g. 1.1.1.1)";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(281, 179);
            textBox3.Margin = new Padding(4, 5, 4, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(427, 25);
            textBox3.TabIndex = 29;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(13, 218);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(182, 65);
            button1.TabIndex = 28;
            button1.Text = "Look up the records";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 342);
            label2.Name = "label2";
            label2.Size = new Size(304, 18);
            label2.TabIndex = 27;
            label2.Text = "Results(DNS record data, there might be more IPs)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 152);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(151, 18);
            label1.TabIndex = 26;
            label1.Text = "Enter the website´s URL";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(13, 179);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(259, 25);
            textBox1.TabIndex = 25;
            // 
            // cfb
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
            Name = "cfb";
            Text = "M17 MCWS - DNS lookup";
            Load += Form1_Load;
            MouseMove += panel1_Click;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button button4;
        private Button button3;
        private Button button2;
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
        private RichTextBox results;
        private Panel panel2;
        private Label label13;
        private PictureBox pictureBox1;
        private Button button18;
        private Button button19;
        private Button button20;
        private Label label4;
        private TextBox textBox3;
        private Button button1;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
    }
}