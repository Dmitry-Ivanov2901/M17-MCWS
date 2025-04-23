
namespace M15A3_MCWS
{
    partial class vlanHopping
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
            button3 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            checkBox1 = new CheckBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(checkBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1924, 955);
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
            panel2.Size = new Size(1955, 39);
            panel2.TabIndex = 31;
            panel2.MouseDown += panel1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Nunito", 12F);
            label13.ForeColor = Color.Cyan;
            label13.Location = new Point(87, 10);
            label13.Name = "label13";
            label13.Size = new Size(101, 22);
            label13.TabIndex = 7;
            label13.Text = "M17 MCWS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.nguyenflag;
            pictureBox1.Location = new Point(20, 3);
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
            // button3
            // 
            button3.BackColor = Color.FromArgb(16, 16, 16);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(18, 226);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(137, 54);
            button3.TabIndex = 30;
            button3.Text = "Start the attack";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(18, 190);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(582, 25);
            textBox2.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 167);
            label2.Name = "label2";
            label2.Size = new Size(234, 18);
            label2.TabIndex = 28;
            label2.Text = "Enter the ID of the enemy´s VLAN here";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 113);
            label1.Name = "label1";
            label1.Size = new Size(235, 18);
            label1.TabIndex = 27;
            label1.Text = "Enter your the ID of the VLAN you´re in";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 135);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(583, 25);
            textBox1.TabIndex = 26;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(17, 55);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(921, 26);
            comboBox1.TabIndex = 33;
            comboBox1.Text = "Select a network interface card here";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(316, 167);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(196, 22);
            checkBox1.TabIndex = 32;
            checkBox1.Text = "Is the current VLAN on IPv6 ?";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // vlanHopping
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1924, 955);
            Controls.Add(panel1);
            Font = new Font("Nunito", 9.749998F);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "vlanHopping";
            Text = "M17 MCWS | VLAN Hopping menu";
            Load += vlanHopping_Load;
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
        private Button button3;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private CheckBox checkBox1;
    }
}