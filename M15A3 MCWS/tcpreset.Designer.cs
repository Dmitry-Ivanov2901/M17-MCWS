namespace M15A3_MCWS
{
    partial class tcpreset
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
            comboBox3 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            dportbox = new TextBox();
            sportbox = new TextBox();
            button2 = new Button();
            ipbox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            sip = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(dportbox);
            panel1.Controls.Add(sportbox);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(ipbox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(sip);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1924, 1061);
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
            panel2.Size = new Size(1996, 43);
            panel2.TabIndex = 34;
            panel2.MouseDown += panel1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Nunito", 12F);
            label13.ForeColor = Color.Cyan;
            label13.Location = new Point(70, 10);
            label13.Name = "label13";
            label13.Size = new Size(101, 22);
            label13.TabIndex = 7;
            label13.Text = "M17 MCWS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.nguyenflag;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button18
            // 
            button18.FlatStyle = FlatStyle.Flat;
            button18.ForeColor = Color.MediumSpringGreen;
            button18.Location = new Point(1795, 3);
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
            button19.Location = new Point(1836, 3);
            button19.Name = "button19";
            button19.Size = new Size(35, 34);
            button19.TabIndex = 4;
            button19.Text = "🗖";
            button19.UseVisualStyleBackColor = true;
            button19.Click += pictureBox3_Click;
            // 
            // button20
            // 
            button20.FlatStyle = FlatStyle.Flat;
            button20.ForeColor = Color.FromArgb(255, 57, 57);
            button20.Location = new Point(1877, 3);
            button20.Name = "button20";
            button20.Size = new Size(35, 34);
            button20.TabIndex = 3;
            button20.Text = "X";
            button20.UseVisualStyleBackColor = true;
            button20.Click += pictureBox2_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(487, 132);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(1095, 28);
            comboBox3.TabIndex = 33;
            comboBox3.Text = "Select your default network adapter manually (in case of an error)";
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 272);
            label4.Name = "label4";
            label4.Size = new Size(214, 20);
            label4.TabIndex = 31;
            label4.Text = "Enter the destination port here";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 214);
            label5.Name = "label5";
            label5.Size = new Size(183, 20);
            label5.TabIndex = 32;
            label5.Text = "Enter the source port here";
            // 
            // dportbox
            // 
            dportbox.Location = new Point(23, 300);
            dportbox.Name = "dportbox";
            dportbox.Size = new Size(328, 28);
            dportbox.TabIndex = 29;
            // 
            // sportbox
            // 
            sportbox.Location = new Point(23, 241);
            sportbox.Name = "sportbox";
            sportbox.Size = new Size(328, 28);
            sportbox.TabIndex = 30;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(23, 335);
            button2.Name = "button2";
            button2.Size = new Size(219, 47);
            button2.TabIndex = 28;
            button2.Text = "Start the attack";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ipbox
            // 
            ipbox.Location = new Point(23, 132);
            ipbox.Name = "ipbox";
            ipbox.Size = new Size(328, 28);
            ipbox.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 105);
            label3.Name = "label3";
            label3.Size = new Size(184, 20);
            label3.TabIndex = 26;
            label3.Text = "Enter the enemy´s IP here";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 160);
            label2.Name = "label2";
            label2.Size = new Size(179, 20);
            label2.TabIndex = 25;
            label2.Text = "Enter the server´s IP here";
            // 
            // sip
            // 
            sip.Location = new Point(23, 188);
            sip.Multiline = true;
            sip.Name = "sip";
            sip.Size = new Size(328, 26);
            sip.TabIndex = 24;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // tcpreset
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1924, 1061);
            Controls.Add(panel1);
            Font = new Font("Nunito", 11.25F);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "tcpreset";
            Text = " ";
            Load += tcpreset_Load;
            MouseDown += panel1_Click;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private ComboBox comboBox3;
        private Label label4;
        private Label label5;
        private TextBox dportbox;
        private TextBox sportbox;
        private Button button2;
        private TextBox ipbox;
        private Label label3;
        private Label label2;
        private TextBox sip;
        private OpenFileDialog openFileDialog1;
    }
}