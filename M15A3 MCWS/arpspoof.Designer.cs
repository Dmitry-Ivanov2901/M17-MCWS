namespace M15A3_MCWS
{
    partial class arpspoof
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
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            comboBox3 = new ComboBox();
            groupBox1 = new GroupBox();
            label6 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            checkBox1 = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            enemyipbox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(enemyipbox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
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
            panel2.Controls.Add(button7);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.ForeColor = Color.Red;
            panel2.Location = new Point(-2, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(2019, 44);
            panel2.TabIndex = 25;
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
            pictureBox1.Location = new Point(16, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = Color.MediumSpringGreen;
            button7.Location = new Point(1795, 7);
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
            button6.Location = new Point(1836, 7);
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
            button5.Location = new Point(1877, 7);
            button5.Name = "button5";
            button5.Size = new Size(35, 34);
            button5.TabIndex = 3;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(542, 349);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(978, 28);
            comboBox3.TabIndex = 24;
            comboBox3.Text = "Select your default network adapter manually (in case of an error)";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.ForeColor = Color.Cyan;
            groupBox1.Location = new Point(542, 92);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(979, 251);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Check the checkbox and fill in the fields if the tool fails to resolve the MACs";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 164);
            label6.Name = "label6";
            label6.Size = new Size(357, 20);
            label6.TabIndex = 19;
            label6.Text = "Enter the MAC address of the default gateway here";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 187);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(965, 28);
            textBox5.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 54);
            label5.Name = "label5";
            label5.Size = new Size(242, 20);
            label5.TabIndex = 17;
            label5.Text = "Enter your local MAC address here";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(7, 78);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(965, 28);
            textBox4.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 110);
            label4.Name = "label4";
            label4.Size = new Size(262, 20);
            label4.TabIndex = 15;
            label4.Text = "Enter the enemy´s MAC address here";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(7, 133);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(965, 28);
            textBox3.TabIndex = 14;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(7, 28);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(240, 24);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "Enter MAC addresses manually";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(160, 214);
            button1.Name = "button1";
            button1.Size = new Size(140, 60);
            button1.TabIndex = 22;
            button1.Text = "Stop the attack";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(14, 214);
            button2.Name = "button2";
            button2.Size = new Size(140, 60);
            button2.TabIndex = 21;
            button2.Text = "Start the attack";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // enemyipbox
            // 
            enemyipbox.Location = new Point(14, 112);
            enemyipbox.Name = "enemyipbox";
            enemyipbox.Size = new Size(522, 28);
            enemyipbox.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 88);
            label3.Name = "label3";
            label3.Size = new Size(184, 20);
            label3.TabIndex = 19;
            label3.Text = "Enter the enemy´s IP here";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 145);
            label2.Name = "label2";
            label2.Size = new Size(192, 20);
            label2.TabIndex = 18;
            label2.Text = "Enter your gateway IP here";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 168);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(522, 28);
            textBox1.TabIndex = 17;
            // 
            // arpspoof
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1924, 1061);
            Controls.Add(panel1);
            Font = new Font("Nunito", 11.25F);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Name = "arpspoof";
            Text = "M17 MCWS - ARP spoofing menu";
            Load += arpspoof_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label13;
        private PictureBox pictureBox1;
        private Button button7;
        private Button button6;
        private Button button5;
        private ComboBox comboBox3;
        private GroupBox groupBox1;
        private Label label6;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private CheckBox checkBox1;
        private Button button1;
        private Button button2;
        private TextBox enemyipbox;
        private Label label3;
        private Label label2;
        private TextBox textBox1;
    }
}