
namespace M15A3_MCWS
{
    partial class custScript
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(custScript));
            button1 = new Button();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            openFileDialog1 = new OpenFileDialog();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            panel2 = new Panel();
            label13 = new Label();
            pictureBox1 = new PictureBox();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(11, 142);
            button1.Name = "button1";
            button1.Size = new Size(139, 54);
            button1.TabIndex = 12;
            button1.Text = "Select the script file and start the attack";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.ForeColor = Color.Cyan;
            groupBox1.Location = new Point(11, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(357, 69);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "In which programming language was the script written ?";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(78, 23);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(247, 22);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Any compiled programming language";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 23);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(67, 22);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Python";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(156, 142);
            button2.Name = "button2";
            button2.Size = new Size(139, 54);
            button2.TabIndex = 25;
            button2.Text = "Add custom CLI arguments";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(11, 202);
            button3.Name = "button3";
            button3.Size = new Size(139, 54);
            button3.TabIndex = 26;
            button3.Text = "Save the attack settings";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(156, 202);
            button4.Name = "button4";
            button4.Size = new Size(139, 54);
            button4.TabIndex = 27;
            button4.Text = "Load a custom attack file";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
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
            panel2.Location = new Point(-2, -3);
            panel2.Name = "panel2";
            panel2.Size = new Size(744, 45);
            panel2.TabIndex = 28;
            panel2.MouseDown += panel1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label13.ForeColor = Color.Cyan;
            label13.Location = new Point(79, 10);
            label13.Name = "label13";
            label13.Size = new Size(80, 18);
            label13.TabIndex = 7;
            label13.Text = "M17 MCWS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.nguyenflag;
            pictureBox1.Location = new Point(12, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button18
            // 
            button18.FlatStyle = FlatStyle.Flat;
            button18.ForeColor = Color.MediumSpringGreen;
            button18.Location = new Point(253, 6);
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
            button19.Location = new Point(294, 6);
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
            button20.Location = new Point(335, 6);
            button20.Name = "button20";
            button20.Size = new Size(35, 34);
            button20.TabIndex = 3;
            button20.Text = "X";
            button20.UseVisualStyleBackColor = true;
            button20.Click += pictureBox2_Click;
            // 
            // custScript
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(377, 271);
            Controls.Add(panel2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Font = new Font("Nunito", 9.749998F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "custScript";
            Text = "M17 MCWS | Custom attack script menu";
            Load += custScript_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private OpenFileDialog openFileDialog1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Panel panel2;
        private Label label13;
        private PictureBox pictureBox1;
        private Button button18;
        private Button button19;
        private Button button20;
    }
}