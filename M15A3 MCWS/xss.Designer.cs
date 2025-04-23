namespace M15A3_MCWS
{
    partial class xss
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
            label5 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            panel2 = new Panel();
            label13 = new Label();
            pictureBox1 = new PictureBox();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button1 = new Button();
            button2 = new Button();
            urlbox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            payload = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(urlbox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(payload);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Nunito", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1924, 923);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(449, 244);
            label5.Name = "label5";
            label5.Size = new Size(541, 20);
            label5.TabIndex = 27;
            label5.Text = "Enter the payloads to be inputted within the URL here (Separate with commas)";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(449, 267);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(520, 492);
            textBox2.TabIndex = 26;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(16, 121);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(940, 28);
            textBox1.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 98);
            label4.Name = "label4";
            label4.Size = new Size(281, 20);
            label4.TabIndex = 24;
            label4.Text = "Enter your proxy address below (IP:port)";
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
            panel2.Location = new Point(3, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1930, 40);
            panel2.TabIndex = 23;
            panel2.MouseDown += panel1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.Cyan;
            label13.Location = new Point(84, 7);
            label13.Name = "label13";
            label13.Size = new Size(93, 20);
            label13.TabIndex = 7;
            label13.Text = "M17 MCWS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.nguyenflag;
            pictureBox1.Location = new Point(17, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = Color.MediumSpringGreen;
            button7.Location = new Point(1792, 2);
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
            button6.Location = new Point(1833, 2);
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
            button5.Location = new Point(1874, 2);
            button5.Name = "button5";
            button5.Size = new Size(35, 34);
            button5.TabIndex = 3;
            button5.Text = "Xa";
            button5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(229, 170);
            button1.Name = "button1";
            button1.Size = new Size(207, 60);
            button1.TabIndex = 22;
            button1.Text = "Get the payload for the XSS attack from a txt file";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(16, 170);
            button2.Name = "button2";
            button2.Size = new Size(207, 60);
            button2.TabIndex = 21;
            button2.Text = "Start the attack";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // urlbox
            // 
            urlbox.Location = new Point(16, 68);
            urlbox.Name = "urlbox";
            urlbox.Size = new Size(940, 28);
            urlbox.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 45);
            label3.Name = "label3";
            label3.Size = new Size(188, 20);
            label3.TabIndex = 19;
            label3.Text = "Enter the enemy URL here";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 244);
            label2.Name = "label2";
            label2.Size = new Size(431, 20);
            label2.TabIndex = 18;
            label2.Text = "Enter the payloads for input tags here (Separate with commas)";
            // 
            // payload
            // 
            payload.Location = new Point(16, 267);
            payload.Multiline = true;
            payload.Name = "payload";
            payload.Size = new Size(414, 492);
            payload.TabIndex = 17;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // xss
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1924, 923);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 11.25F);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "xss";
            Text = "M15A2 MCWS | XSS menu";
            MouseMove += panel1_Click;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private Panel panel2;
        private Label label13;
        private PictureBox pictureBox1;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button1;
        private Button button2;
        private TextBox urlbox;
        private Label label3;
        private Label label2;
        private TextBox payload;
        private OpenFileDialog openFileDialog1;
    }
}