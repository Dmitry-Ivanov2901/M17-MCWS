namespace M15A3_MCWS
{
    partial class doxdb
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
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            dataGridView1 = new DataGridView();
            IP = new DataGridViewTextBoxColumn();
            rname = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            steamid = new DataGridViewTextBoxColumn();
            smedianame = new DataGridViewTextBoxColumn();
            location = new DataGridViewTextBoxColumn();
            pn = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            label9 = new Label();
            pnbox = new TextBox();
            label8 = new Label();
            addbox = new TextBox();
            label7 = new Label();
            sidbox = new TextBox();
            label6 = new Label();
            lbox = new TextBox();
            button3 = new Button();
            label5 = new Label();
            label4 = new Label();
            ebox = new TextBox();
            button2 = new Button();
            button1 = new Button();
            namebox = new TextBox();
            label3 = new Label();
            pnamebox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            ipbox = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(radioButton5);
            panel1.Controls.Add(radioButton4);
            panel1.Controls.Add(radioButton3);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(pnbox);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(addbox);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(sidbox);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lbox);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(ebox);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(namebox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pnamebox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(ipbox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1924, 919);
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
            panel2.Location = new Point(-8, -7);
            panel2.Name = "panel2";
            panel2.Size = new Size(2045, 48);
            panel2.TabIndex = 54;
            panel2.MouseDown += panel1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Nunito", 12F);
            label13.ForeColor = Color.Cyan;
            label13.Location = new Point(82, 15);
            label13.Name = "label13";
            label13.Size = new Size(101, 22);
            label13.TabIndex = 7;
            label13.Text = "M17 MCWS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.nguyenflag;
            pictureBox1.Location = new Point(15, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button18
            // 
            button18.FlatStyle = FlatStyle.Flat;
            button18.ForeColor = Color.MediumSpringGreen;
            button18.Location = new Point(1815, 9);
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
            button19.Location = new Point(1856, 9);
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
            button20.Location = new Point(1897, 9);
            button20.Name = "button20";
            button20.Size = new Size(35, 34);
            button20.TabIndex = 3;
            button20.Text = "X";
            button20.UseVisualStyleBackColor = true;
            button20.Click += pictureBox2_Click;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(367, 714);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(160, 24);
            radioButton5.TabIndex = 53;
            radioButton5.TabStop = true;
            radioButton5.Text = "Search by Steam ID";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(367, 682);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(134, 24);
            radioButton4.TabIndex = 52;
            radioButton4.TabStop = true;
            radioButton4.Text = "Search by email";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(367, 651);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(165, 24);
            radioButton3.TabIndex = 51;
            radioButton3.TabStop = true;
            radioButton3.Text = "Search by real name";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(367, 620);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(182, 24);
            radioButton2.TabIndex = 50;
            radioButton2.TabStop = true;
            radioButton2.Text = "Search by profile name";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(367, 589);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(111, 24);
            radioButton1.TabIndex = 49;
            radioButton1.TabStop = true;
            radioButton1.Text = "Search by IP";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IP, rname, address, steamid, smedianame, location, pn, email });
            dataGridView1.Location = new Point(570, 150);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(948, 661);
            dataGridView1.TabIndex = 48;
            // 
            // IP
            // 
            IP.HeaderText = "IP address";
            IP.Name = "IP";
            // 
            // rname
            // 
            rname.HeaderText = "Real name(First name and surname)";
            rname.Name = "rname";
            // 
            // address
            // 
            address.HeaderText = "Real address";
            address.Name = "address";
            // 
            // steamid
            // 
            steamid.HeaderText = "Steam ID";
            steamid.Name = "steamid";
            // 
            // smedianame
            // 
            smedianame.HeaderText = "Social media profile name";
            smedianame.Name = "smedianame";
            // 
            // location
            // 
            location.HeaderText = "Approximate location";
            location.Name = "location";
            // 
            // pn
            // 
            pn.HeaderText = "Phone number";
            pn.Name = "pn";
            // 
            // email
            // 
            email.HeaderText = "E-Mail address";
            email.Name = "email";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 515);
            label9.Name = "label9";
            label9.Size = new Size(208, 20);
            label9.TabIndex = 47;
            label9.Text = "Enter the phone number here";
            // 
            // pnbox
            // 
            pnbox.Location = new Point(12, 538);
            pnbox.Name = "pnbox";
            pnbox.Size = new Size(415, 28);
            pnbox.TabIndex = 46;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 456);
            label8.Name = "label8";
            label8.Size = new Size(162, 20);
            label8.TabIndex = 45;
            label8.Text = "Enter the address here";
            // 
            // addbox
            // 
            addbox.Location = new Point(12, 480);
            addbox.Name = "addbox";
            addbox.Size = new Size(415, 28);
            addbox.TabIndex = 44;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 406);
            label7.Name = "label7";
            label7.Size = new Size(171, 20);
            label7.TabIndex = 43;
            label7.Text = "Enter the Steam ID here";
            // 
            // sidbox
            // 
            sidbox.Location = new Point(12, 429);
            sidbox.Name = "sidbox";
            sidbox.Size = new Size(415, 28);
            sidbox.TabIndex = 42;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 350);
            label6.Name = "label6";
            label6.Size = new Size(161, 20);
            label6.TabIndex = 41;
            label6.Text = "Enter the location here";
            // 
            // lbox
            // 
            lbox.Location = new Point(12, 374);
            lbox.Name = "lbox";
            lbox.Size = new Size(415, 28);
            lbox.TabIndex = 40;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(16, 16, 16);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(12, 692);
            button3.Name = "button3";
            button3.Size = new Size(177, 63);
            button3.TabIndex = 39;
            button3.Text = "Edit the database file";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(570, 127);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 38;
            label5.Text = "Search results";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 295);
            label4.Name = "label4";
            label4.Size = new Size(202, 20);
            label4.TabIndex = 37;
            label4.Text = "Enter the email address here";
            // 
            // ebox
            // 
            ebox.Location = new Point(12, 318);
            ebox.Name = "ebox";
            ebox.Size = new Size(415, 28);
            ebox.TabIndex = 36;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(16, 16, 16);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(195, 622);
            button2.Name = "button2";
            button2.Size = new Size(165, 63);
            button2.TabIndex = 35;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(16, 16, 16);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(12, 622);
            button1.Name = "button1";
            button1.Size = new Size(177, 63);
            button1.TabIndex = 34;
            button1.Text = "Specify the database file";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // namebox
            // 
            namebox.Location = new Point(12, 262);
            namebox.Name = "namebox";
            namebox.Size = new Size(415, 28);
            namebox.TabIndex = 33;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 239);
            label3.Name = "label3";
            label3.Size = new Size(176, 20);
            label3.TabIndex = 32;
            label3.Text = "Enter the real name here";
            // 
            // pnamebox
            // 
            pnamebox.Location = new Point(12, 207);
            pnamebox.Name = "pnamebox";
            pnamebox.Size = new Size(415, 28);
            pnamebox.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 183);
            label2.Name = "label2";
            label2.Size = new Size(193, 20);
            label2.TabIndex = 30;
            label2.Text = "Enter the profile name here";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 123);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 29;
            label1.Text = "Enter the IP here";
            // 
            // ipbox
            // 
            ipbox.Location = new Point(12, 150);
            ipbox.Margin = new Padding(3, 4, 3, 4);
            ipbox.Name = "ipbox";
            ipbox.Size = new Size(415, 28);
            ipbox.TabIndex = 28;
            // 
            // doxdb
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1924, 919);
            Controls.Add(panel1);
            Font = new Font("Nunito", 11.25F);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "doxdb";
            Text = "M17 MCWS - Dox database | The cybernetic counterpart of the 7.62×51mm AK-308 battle rifle";
            Load += doxdb_Load;
            MouseDown += panel1_Click;
            MouseMove += panel1_Click;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IP;
        private DataGridViewTextBoxColumn rname;
        private DataGridViewTextBoxColumn address;
        private DataGridViewTextBoxColumn steamid;
        private DataGridViewTextBoxColumn smedianame;
        private DataGridViewTextBoxColumn location;
        private DataGridViewTextBoxColumn pn;
        private DataGridViewTextBoxColumn email;
        private Label label9;
        private TextBox pnbox;
        private Label label8;
        private TextBox addbox;
        private Label label7;
        private TextBox sidbox;
        private Label label6;
        private TextBox lbox;
        private Button button3;
        private Label label5;
        private Label label4;
        private TextBox ebox;
        private Button button2;
        private Button button1;
        private TextBox namebox;
        private Label label3;
        private TextBox pnamebox;
        private Label label2;
        private Label label1;
        private TextBox ipbox;
    }
}