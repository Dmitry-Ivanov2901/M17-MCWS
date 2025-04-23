namespace M15A3_MCWS
{
    partial class macSpoof
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(macSpoof));
            panel1 = new Panel();
            panel2 = new Panel();
            label13 = new Label();
            pictureBox1 = new PictureBox();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            groupBox2 = new GroupBox();
            macbox = new TextBox();
            label2 = new Label();
            button3 = new Button();
            radioButton3 = new RadioButton();
            label1 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            radioButton4 = new RadioButton();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(radioButton3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(radioButton4);
            panel1.Controls.Add(groupBox1);
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
            panel2.Size = new Size(1956, 43);
            panel2.TabIndex = 42;
            panel2.MouseDown += panel1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Nunito", 12F);
            label13.ForeColor = Color.Cyan;
            label13.Location = new Point(81, 10);
            label13.Name = "label13";
            label13.Size = new Size(101, 22);
            label13.TabIndex = 7;
            label13.Text = "M17 MCWS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.nguyenflag;
            pictureBox1.Location = new Point(14, 3);
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
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(macbox);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(button3);
            groupBox2.ForeColor = Color.Cyan;
            groupBox2.Location = new Point(637, 46);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(542, 161);
            groupBox2.TabIndex = 41;
            groupBox2.TabStop = false;
            groupBox2.Text = "Spoof your MAC to a given MAC address";
            // 
            // macbox
            // 
            macbox.Location = new Point(7, 48);
            macbox.Name = "macbox";
            macbox.Size = new Size(525, 25);
            macbox.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 24);
            label2.Name = "label2";
            label2.Size = new Size(220, 18);
            label2.TabIndex = 31;
            label2.Text = "Enter the desired MAC address here";
            // 
            // button3
            // 
            button3.BackColor = Color.Lime;
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Black;
            button3.Location = new Point(7, 84);
            button3.Name = "button3";
            button3.Size = new Size(162, 69);
            button3.TabIndex = 30;
            button3.Text = "Spoof your MAC to the desired MAC address";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(520, 102);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(72, 22);
            radioButton3.TabIndex = 39;
            radioButton3.TabStop = true;
            radioButton3.Text = "Minutes";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(252, 46);
            label1.Name = "label1";
            label1.Size = new Size(345, 18);
            label1.TabIndex = 38;
            label1.Text = "Enter the count of the units of time between MAC changes";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(249, 69);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(263, 25);
            textBox1.TabIndex = 37;
            // 
            // button2
            // 
            button2.BackColor = Color.Lime;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.Black;
            button2.Location = new Point(14, 264);
            button2.Name = "button2";
            button2.Size = new Size(165, 64);
            button2.TabIndex = 36;
            button2.Text = "Change your MAC every x time units";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(14, 189);
            button1.Name = "button1";
            button1.Size = new Size(165, 69);
            button1.TabIndex = 35;
            button1.Text = "Spoof your MAC to a random MAC address";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(520, 69);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(61, 22);
            radioButton4.TabIndex = 40;
            radioButton4.TabStop = true;
            radioButton4.Text = "Hours";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.ForeColor = Color.Cyan;
            groupBox1.Location = new Point(14, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(232, 135);
            groupBox1.TabIndex = 34;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select your architecture";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(7, 61);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(49, 22);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "64x";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(7, 28);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(49, 22);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "32x";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // macSpoof
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1924, 1061);
            Controls.Add(panel1);
            Font = new Font("Nunito", 9.749998F);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "macSpoof";
            Text = "M15A2 MCWS - MAC spoofer";
            Load += macSpoof_Load;
            MouseMove += panel1_Click;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private GroupBox groupBox2;
        private TextBox macbox;
        private Label label2;
        private Button button3;
        private RadioButton radioButton3;
        private Label label1;
        private TextBox textBox1;
        private Button button2;
        private Button button1;
        private RadioButton radioButton4;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
    }
}