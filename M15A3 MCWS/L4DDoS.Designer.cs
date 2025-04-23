namespace M15A3_MCWS
{
    partial class L4DDoS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(L4DDoS));
            panel1 = new Panel();
            groupBox6 = new GroupBox();
            label9 = new Label();
            textBox2 = new TextBox();
            button4 = new Button();
            comboBox2 = new ComboBox();
            groupBox3 = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            groupBox2 = new GroupBox();
            comboBox3 = new ComboBox();
            groupBox5 = new GroupBox();
            custtcp = new RadioButton();
            custudp = new RadioButton();
            checkBox13 = new CheckBox();
            groupBox4 = new GroupBox();
            checkBox12 = new CheckBox();
            checkBox11 = new CheckBox();
            checkBox10 = new CheckBox();
            checkBox9 = new CheckBox();
            checkBox8 = new CheckBox();
            checkBox7 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox4 = new CheckBox();
            rp = new CheckBox();
            checkBox2 = new CheckBox();
            rip = new CheckBox();
            trackBar1 = new TrackBar();
            label12 = new Label();
            label11 = new Label();
            cpayload = new TextBox();
            label10 = new Label();
            textBox9 = new TextBox();
            label8 = new Label();
            timeoutbox = new TextBox();
            label7 = new Label();
            ttlbox = new TextBox();
            label6 = new Label();
            sizebox = new TextBox();
            comboBox1 = new ComboBox();
            groupBox1 = new GroupBox();
            spoofbox = new TextBox();
            label5 = new Label();
            dportbox = new TextBox();
            label4 = new Label();
            sportbox = new TextBox();
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
            panel1.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(groupBox6);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(panel2);
            panel1.Font = new Font("Nunito", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            panel1.Location = new Point(-1, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1656, 779);
            panel1.TabIndex = 0;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label9);
            groupBox6.Controls.Add(textBox2);
            groupBox6.Controls.Add(button4);
            groupBox6.ForeColor = Color.Cyan;
            groupBox6.Location = new Point(546, 614);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(1097, 94);
            groupBox6.TabIndex = 23;
            groupBox6.TabStop = false;
            groupBox6.Text = "A10 Thunderbolt DoS (DoS that sends RST packets to specified IPs or its /24 CIDR range, effectively terminating its TCP connections) options";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(275, 28);
            label9.Name = "label9";
            label9.Size = new Size(501, 20);
            label9.TabIndex = 20;
            label9.Text = "Enter the ports to cancel the TCP connections on (separate with commas)";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(275, 51);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(501, 28);
            textBox2.TabIndex = 19;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderColor = Color.MediumSpringGreen;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(6, 27);
            button4.Name = "button4";
            button4.Size = new Size(263, 52);
            button4.TabIndex = 18;
            button4.Text = "Select a text file with the IPs to disconnect the target IP from";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "AppleTalk", "AppleTalkArp", "IPv4", "IPv6", "ARP", "None", "Transparent Ethernet Bridging", "Reverse ARP", "Wake On Lan", "VLAN-tagged frame", "Novell IPX", "MAC Control", "CobraNet", "MPLS Unicast", "MPLS Multicast", "PPPoE discover stage", "PPPoE session stage", "EAP over LAN", "PROFINET", "HyperSCSI", "ATA over Ethernet", "EtherCAT", "Provider Bridging", "AVBTP", "LLDP", "Sercos III", "CESoE", "HomePlug", "PTP", "CFM", "FCOE", "Veritas LLT", "Ethernet loopback", "Echo" });
            comboBox2.Location = new Point(17, 371);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(523, 28);
            comboBox2.TabIndex = 22;
            comboBox2.Text = "Ethernet types for the custom method";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dateTimePicker1);
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(button1);
            groupBox3.ForeColor = Color.Cyan;
            groupBox3.Location = new Point(15, 409);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(523, 133);
            groupBox3.TabIndex = 21;
            groupBox3.TabStop = false;
            groupBox3.Text = "Trigger";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(7, 86);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(329, 28);
            dateTimePicker1.TabIndex = 17;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = Color.OrangeRed;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(152, 28);
            button3.Name = "button3";
            button3.Size = new Size(184, 51);
            button3.TabIndex = 16;
            button3.Text = "Schedule an attack";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.OrangeRed;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(7, 28);
            button2.Name = "button2";
            button2.Size = new Size(138, 51);
            button2.TabIndex = 15;
            button2.Text = "Start the attack";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.MediumSpringGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(343, 28);
            button1.Name = "button1";
            button1.Size = new Size(173, 51);
            button1.TabIndex = 11;
            button1.Text = "Bolt catch";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox3);
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Controls.Add(checkBox13);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(rp);
            groupBox2.Controls.Add(checkBox2);
            groupBox2.Controls.Add(rip);
            groupBox2.Controls.Add(trackBar1);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(cpayload);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(textBox9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(timeoutbox);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(ttlbox);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(sizebox);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.ForeColor = Color.Cyan;
            groupBox2.Location = new Point(546, 69);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1097, 539);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Attack options";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(6, 360);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(1083, 28);
            comboBox3.TabIndex = 4;
            comboBox3.Text = "Select your default network adapter manually (in case of an error)";
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(custtcp);
            groupBox5.Controls.Add(custudp);
            groupBox5.ForeColor = Color.Cyan;
            groupBox5.Location = new Point(363, 458);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(367, 73);
            groupBox5.TabIndex = 17;
            groupBox5.TabStop = false;
            groupBox5.Text = "Does the custom method use UDP or TCP";
            // 
            // custtcp
            // 
            custtcp.AutoSize = true;
            custtcp.Location = new Point(78, 27);
            custtcp.Name = "custtcp";
            custtcp.Size = new Size(54, 24);
            custtcp.TabIndex = 1;
            custtcp.TabStop = true;
            custtcp.Text = "TCP";
            custtcp.UseVisualStyleBackColor = true;
            // 
            // custudp
            // 
            custudp.AutoSize = true;
            custudp.Location = new Point(7, 27);
            custudp.Name = "custudp";
            custudp.Size = new Size(58, 24);
            custudp.TabIndex = 0;
            custudp.TabStop = true;
            custudp.Text = "UDP";
            custudp.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            checkBox13.AutoSize = true;
            checkBox13.Checked = true;
            checkBox13.CheckState = CheckState.Checked;
            checkBox13.Location = new Point(6, 327);
            checkBox13.Name = "checkBox13";
            checkBox13.Size = new Size(567, 24);
            checkBox13.TabIndex = 15;
            checkBox13.Text = "Aggressive mode (TOS-1 only, automatically makes connections, recommended)";
            checkBox13.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(checkBox12);
            groupBox4.Controls.Add(checkBox11);
            groupBox4.Controls.Add(checkBox10);
            groupBox4.Controls.Add(checkBox9);
            groupBox4.Controls.Add(checkBox8);
            groupBox4.Controls.Add(checkBox7);
            groupBox4.Controls.Add(checkBox6);
            groupBox4.Controls.Add(checkBox5);
            groupBox4.Controls.Add(checkBox4);
            groupBox4.ForeColor = Color.Cyan;
            groupBox4.Location = new Point(6, 398);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(351, 133);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "TCP flags";
            // 
            // checkBox12
            // 
            checkBox12.AutoSize = true;
            checkBox12.Location = new Point(137, 88);
            checkBox12.Name = "checkBox12";
            checkBox12.Size = new Size(71, 24);
            checkBox12.TabIndex = 12;
            checkBox12.Text = "XMAS";
            checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            checkBox11.AutoSize = true;
            checkBox11.Location = new Point(137, 60);
            checkBox11.Name = "checkBox11";
            checkBox11.Size = new Size(65, 24);
            checkBox11.TabIndex = 11;
            checkBox11.Text = "CWR";
            checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            checkBox10.AutoSize = true;
            checkBox10.Location = new Point(137, 28);
            checkBox10.Name = "checkBox10";
            checkBox10.Size = new Size(56, 24);
            checkBox10.TabIndex = 10;
            checkBox10.Text = "ECE";
            checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Location = new Point(71, 88);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(57, 24);
            checkBox9.TabIndex = 9;
            checkBox9.Text = "PSH";
            checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Location = new Point(70, 60);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(60, 24);
            checkBox8.TabIndex = 8;
            checkBox8.Text = "URG";
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(70, 28);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(56, 24);
            checkBox7.TabIndex = 7;
            checkBox7.Text = "RST";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(7, 88);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(51, 24);
            checkBox6.TabIndex = 6;
            checkBox6.Text = "FIN";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(7, 60);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(58, 24);
            checkBox5.TabIndex = 5;
            checkBox5.Text = "ACK";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(7, 28);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(57, 24);
            checkBox4.TabIndex = 0;
            checkBox4.Text = "SYN";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // rp
            // 
            rp.AutoSize = true;
            rp.Location = new Point(643, 269);
            rp.Name = "rp";
            rp.Size = new Size(226, 24);
            rp.TabIndex = 14;
            rp.Text = "Use random destination ports";
            rp.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(643, 236);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(195, 24);
            checkBox2.TabIndex = 13;
            checkBox2.Text = "Use random source ports";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // rip
            // 
            rip.AutoSize = true;
            rip.Location = new Point(643, 202);
            rip.Name = "rip";
            rip.Size = new Size(246, 24);
            rip.TabIndex = 12;
            rip.Text = "Use random source IP addresses";
            rip.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(6, 270);
            trackBar1.Maximum = 20;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(631, 45);
            trackBar1.TabIndex = 9;
            trackBar1.Value = 7;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 244);
            label12.Name = "label12";
            label12.Size = new Size(595, 20);
            label12.TabIndex = 10;
            label12.Text = "Set the thread count for the attack (Also increases the amount of Slowloris connections)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(560, 27);
            label11.Name = "label11";
            label11.Size = new Size(337, 20);
            label11.TabIndex = 8;
            label11.Text = "Enter the custom payload for the custom method";
            // 
            // cpayload
            // 
            cpayload.Location = new Point(564, 54);
            cpayload.Multiline = true;
            cpayload.Name = "cpayload";
            cpayload.Size = new Size(361, 141);
            cpayload.TabIndex = 7;
            cpayload.Text = resources.GetString("cpayload.Text");
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(292, 64);
            label10.Name = "label10";
            label10.Size = new Size(219, 20);
            label10.TabIndex = 6;
            label10.Text = "Enter a message for the enemy";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(285, 90);
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(273, 86);
            textBox9.TabIndex = 5;
            textBox9.Text = resources.GetString("textBox9.Text");
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 184);
            label8.Name = "label8";
            label8.Size = new Size(173, 20);
            label8.TabIndex = 6;
            label8.Text = "Enter the packet timeout";
            // 
            // timeoutbox
            // 
            timeoutbox.Location = new Point(6, 210);
            timeoutbox.Name = "timeoutbox";
            timeoutbox.Size = new Size(273, 28);
            timeoutbox.TabIndex = 5;
            timeoutbox.Text = "9001";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 124);
            label7.Name = "label7";
            label7.Size = new Size(149, 20);
            label7.TabIndex = 4;
            label7.Text = "Enter the packet TTL";
            // 
            // ttlbox
            // 
            ttlbox.Location = new Point(6, 150);
            ttlbox.Name = "ttlbox";
            ttlbox.Size = new Size(273, 28);
            ttlbox.TabIndex = 3;
            ttlbox.Text = "250";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 64);
            label6.Name = "label6";
            label6.Size = new Size(167, 20);
            label6.TabIndex = 2;
            label6.Text = "Enter the packet length";
            // 
            // sizebox
            // 
            sizebox.Location = new Point(6, 90);
            sizebox.Name = "sizebox";
            sizebox.Size = new Size(273, 28);
            sizebox.TabIndex = 1;
            sizebox.Text = "1024";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "========DO NOT CLICK THE TABS WITH THE HEADER SIGNS========", "", "========Amplification========", "Multi-vector amplification DDoS (Combines the most powerful methods)", "TP-240 Mitel (Amplification ratio of almost 4.3 billion to 1)", "SLP (2 200x amplification factor)", "Memcached (51 200x amplification factor)", "NTP (556,5x amplification factor)", "WSD (10-500x amplification factor)", "DNS (70x amplification factor)", "CLDAP (50-70x amplification factor)", "SSDP (30x amplification factor)", "Source engine query (5,5x amplification factor)", "", "========Special PMC Nguyen-invented methods========", "[OBSOLETE] 7.92×45mm Патрон Специальный (ПС-23) APHEIHP rounds (Incendiary, AP, excellent stopping power and penetration)", "ТОС-1 thermobaric rounds (Extremely powerful, acts like a botnet, but it's legal due to the fact that it doesn´t use remote access)", "L2023 Napalm (Improved napalm)", "СНЗР-1 hypersonic nuclear packet (Designed to bypass protection and cause a huge nuclear data explosion behind the firewall).", "Napalm", "VX artillery", "White phosphorus artillery (Compressed napalm)", "GMod ultra lag (Designed specially for Garry's Mod servers)", "Custom method", "Stuka dive bombing", "A-10 Thunderbolt DoS (Sends TCP RST packets to all IPs in the target range [CIDR block size: /24]). Great for government networks.", "7.92×45mm PS-24 (7,92mm náboj vz.24) APHEIHP rounds (Improvement over ПС-23 rounds, unbugged and even better than before).", "========Regular methods========", "UDP", "TCP", "ICMP", "LAND", "SYN flood", "Slowloris" });
            comboBox1.Location = new Point(6, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(548, 28);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Method list";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(spoofbox);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dportbox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(sportbox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.ForeColor = Color.Cyan;
            groupBox1.Location = new Point(17, 69);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(523, 296);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Targetting";
            // 
            // spoofbox
            // 
            spoofbox.Location = new Point(6, 232);
            spoofbox.Name = "spoofbox";
            spoofbox.Size = new Size(509, 28);
            spoofbox.TabIndex = 7;
            spoofbox.Text = "1.9.7.5";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 207);
            label5.Name = "label5";
            label5.Size = new Size(169, 20);
            label5.TabIndex = 6;
            label5.Text = "Enter the source IP here";
            // 
            // dportbox
            // 
            dportbox.Location = new Point(6, 172);
            dportbox.Name = "dportbox";
            dportbox.Size = new Size(509, 28);
            dportbox.TabIndex = 5;
            dportbox.Text = "53";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 147);
            label4.Name = "label4";
            label4.Size = new Size(221, 20);
            label4.TabIndex = 4;
            label4.Text = "Enter the destination ports here";
            // 
            // sportbox
            // 
            sportbox.Location = new Point(7, 112);
            sportbox.Name = "sportbox";
            sportbox.Size = new Size(509, 28);
            sportbox.TabIndex = 3;
            sportbox.Text = "53";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 87);
            label3.Name = "label3";
            label3.Size = new Size(183, 20);
            label3.TabIndex = 2;
            label3.Text = "Enter the source port here";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 52);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(509, 28);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 27);
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
            panel2.Location = new Point(0, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(2167, 40);
            panel2.TabIndex = 18;
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
            pictureBox1.Location = new Point(14, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 34);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = Color.MediumSpringGreen;
            button7.Location = new Point(1527, 3);
            button7.Name = "button7";
            button7.Size = new Size(35, 34);
            button7.TabIndex = 5;
            button7.Text = "_";
            button7.UseVisualStyleBackColor = true;
            button7.Click += pictureBox4_Click_1;
            // 
            // button6
            // 
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = Color.DarkOrange;
            button6.Location = new Point(1568, 3);
            button6.Name = "button6";
            button6.Size = new Size(35, 34);
            button6.TabIndex = 4;
            button6.Text = "🗖";
            button6.UseVisualStyleBackColor = true;
            button6.Click += pictureBox3_Click_1;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.FromArgb(255, 57, 57);
            button5.Location = new Point(1609, 3);
            button5.Name = "button5";
            button5.Size = new Size(35, 34);
            button5.TabIndex = 3;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = true;
            button5.Click += pictureBox2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(129, 0);
            label1.Name = "label1";
            label1.Size = new Size(110, 24);
            label1.TabIndex = 2;
            label1.Text = "M17 MCWS";
            // 
            // L4DDoS
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1654, 773);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 11.25F);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "L4DDoS";
            Text = "M17 MCWS - L4 DoS / DDoS menu";
            Load += L4DDoS_Load;
            panel1.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        private GroupBox groupBox6;
        private Label label9;
        private TextBox textBox2;
        private Button button4;
        private ComboBox comboBox2;
        private GroupBox groupBox3;
        private DateTimePicker dateTimePicker1;
        private Button button3;
        private Button button2;
        private Button button1;
        private GroupBox groupBox2;
        private ComboBox comboBox3;
        private GroupBox groupBox5;
        private RadioButton custtcp;
        private RadioButton custudp;
        private CheckBox checkBox13;
        private GroupBox groupBox4;
        private CheckBox checkBox12;
        private CheckBox checkBox11;
        private CheckBox checkBox10;
        private CheckBox checkBox9;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox rp;
        private CheckBox checkBox2;
        private CheckBox rip;
        private TrackBar trackBar1;
        private Label label12;
        private Label label11;
        private TextBox cpayload;
        private Label label10;
        private TextBox textBox9;
        private Label label8;
        private TextBox timeoutbox;
        private Label label7;
        private TextBox ttlbox;
        private Label label6;
        private TextBox sizebox;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private TextBox spoofbox;
        private Label label5;
        private TextBox dportbox;
        private Label label4;
        private TextBox sportbox;
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
    }
}