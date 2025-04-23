using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketDotNet;
using SharpPcap;
using Azure.Core.Pipeline;
using Microsoft.Windows.Themes;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Windows.Controls;
using System.Windows;
using M15A3_MCWS.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MessageBox = System.Windows.Forms.MessageBox;
using TextBox = System.Windows.Forms.TextBox;
using PuppeteerSharp;

namespace M15A3_MCWS
{
    public partial class ping : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
    int nLeftRect,     // x-coordinate of upper-left corner
    int nTopRect,      // y-coordinate of upper-left corner
    int nRightRect,    // x-coordinate of lower-right corner
    int nBottomRect,   // y-coordinate of lower-right corner
    int nWidthEllipse, // width of ellipse
    int nHeightEllipse // height of ellipse
);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public ping()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        public static int timeout = 5000;
        public static bool manual = false;
        private void icmp(IPAddress ipa)
        {
            try
            {
                byte[] buf = new byte[64];
                if (IPAddress.TryParse(textBox1.Text, out IPAddress IP))
                {
                    ipa = IPAddress.Parse(textBox1.Text);
                }
                else if (!IPAddress.TryParse(textBox1.Text, out IPAddress IP2))
                {
                    IPAddress[] ads = Dns.GetHostAddresses(textBox1.Text);
                    foreach (IPAddress ad in ads)
                    {
                        if (ad.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipa = ad;
                            break;
                        }
                    }
                }
                Ping p = new Ping();
                textBox2.AppendText($"Pinging {ipa.ToString()}" + Environment.NewLine);
                int x = int.Parse(textBox3.Text);
                int success = 0;
                long time = 0;
                for (int i = 0; i < x; i++)
                {
                    PingReply pr = p.Send(ipa, 5000);
                    if (pr.Status == IPStatus.Success)
                    {
                        textBox2.AppendText($"Reply from {pr.Address.ToString()} in {pr.RoundtripTime.ToString()} | IP status: {pr.Status.ToString()}" + Environment.NewLine);
                        success++;
                        time += pr.RoundtripTime;
                    }
                    else
                    {
                        textBox2.AppendText($"Failed to receive the reply from the target | IP status: {pr.Status.ToString()}");
                    }
                }
                int percentage = x / success;
                textBox2.AppendText($"{x} packets sent, {percentage}% packet loss");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void icmp(IPAddress ipa, int x, TextBox textBox2)
        {
            try
            {
                byte[] buf = new byte[64];
                if (IPAddress.TryParse(textBox1.Text, out IPAddress IP))
                {
                    ipa = IPAddress.Parse(textBox1.Text);
                }
                else if (!IPAddress.TryParse(textBox1.Text, out IPAddress IP2))
                {
                    IPAddress[] ads = Dns.GetHostAddresses(textBox1.Text);
                    foreach (IPAddress ad in ads)
                    {
                        if (ad.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipa = ad;
                            break;
                        }
                    }
                }
                Ping p = new Ping();
                this.Invoke(new MethodInvoker(() => textBox2.AppendText($"Pinging {ipa.ToString()}" + Environment.NewLine)));
                int success = 0;
                long time = 0;
                for (int i = 0; i < x; i++)
                {
                    PingReply pr = p.Send(ipa, 5000);
                    if (pr.Status == IPStatus.Success)
                    {
                        this.Invoke(new MethodInvoker(() => textBox2.AppendText($"Reply from {pr.Address.ToString()} in {pr.RoundtripTime.ToString()} | IP status: {pr.Status.ToString()}" + Environment.NewLine)));
                        success++;
                        time += pr.RoundtripTime;
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(() => textBox2.AppendText($"Failed to receive the reply from the target | IP status: {pr.Status.ToString()}")));
                    }
                }
                int percentage = x / success;
                this.Invoke(new MethodInvoker(() => textBox2.AppendText($"{x} packets sent, {percentage}% packet loss")));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void udp()
        {
            int c = (int)numericUpDown1.Value;
            ushort port = ushort.Parse(textBox5.Text);
            IPAddress ipa = IPAddress.Parse(textBox1.Text);
            for (int i = 0; i < int.Parse(textBox3.Text); i++)
            {
                this.Invoke(new MethodInvoker(() => textBox2.AppendText(pscan.udpping(ipa, port, c))));
            }
        }
        private void udp(IPAddress ipa)
        {
            for (int i = 0; i < int.Parse(textBox3.Text); i++)
            {
                this.Invoke(new MethodInvoker(() => textBox2.AppendText(pscan.udpping(ipa, ushort.Parse(textBox5.Text), int.Parse(numericUpDown1.Value.ToString())))));
            }
        }
        private void http()
        {
            for (int i = 0; i < int.Parse(textBox3.Text); i++)
            {
                string url = textBox1.Text;
                if (!IPAddress.TryParse(textBox1.Text, out IPAddress IP))
                {
                    url = textBox1.Text;
                }
                else if (IPAddress.TryParse(textBox1.Text, out IPAddress IP2))
                {
                    url = $"http://{textBox1.Text}";
                }
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(textBox1.Text);
                req.Method = "GET";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (res.StatusCode >= (HttpStatusCode)100 || res.StatusCode <= (HttpStatusCode)199 || res.StatusCode >= (HttpStatusCode)200 || res.StatusCode <= (HttpStatusCode)299 || res.StatusCode >= (HttpStatusCode)300 || res.StatusCode <= (HttpStatusCode)399 || res.StatusCode >= (HttpStatusCode)400 || res.StatusCode <= (HttpStatusCode)499)
                {
                    textBox2.AppendText($"The host is up, the HTTP response code is {res.StatusCode.ToString()}");
                }
                else
                {
                    textBox2.AppendText($"The host is down, the HTTP response code is {res.StatusCode.ToString()}");
                }
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(textBox3.Text);
                bool isIp = IPAddress.TryParse(textBox1.Text, out IPAddress ip);
                TextBox t = textBox2;
                IPAddress ipa = IPAddress.Parse(textBox1.Text);
                if (isIp)
                {
                    manual = checkBox2.Checked;
                    timeout = (int)numericUpDown1.Value;
                    textBox2.Clear();
                    if (radioButton1.Checked)
                    {
                        Task.Run(() => icmp(ipa, x, t));
                    }
                    else if (radioButton2.Checked)
                    {
                        Task.Run(() => http());
                    }
                    else if (radioButton3.Checked)
                    {
                        Task.Run(() => udp());
                    }
                    else if (radioButton4.Checked)
                    {
                        for (int i = 0; i < int.Parse(textBox3.Text); i++)
                        {
                            pscan.tcpping(IPAddress.Parse(textBox1.Text), ushort.Parse(textBox5.Text), int.Parse(numericUpDown1.Value.ToString()));
                        }
                    }
                }
                else
                {
                    IPAddress target = Dns.GetHostAddresses(textBox1.Text)[0];
                    manual = checkBox2.Checked;
                    timeout = (int)numericUpDown1.Value;
                    textBox2.Clear();
                    textBox2.AppendText($"Pinging {textBox1.Text} ({target}) with 64 bytes of data:");
                    if (radioButton1.Checked)
                    {
                        Task.Run(() => icmp(target, x, textBox2));
                    }
                    else if (radioButton2.Checked)
                    {
                        Task.Run(() => http());
                    }
                    else if (radioButton3.Checked)
                    {
                        Task.Run(() => udp(target));
                    }
                    else if (radioButton4.Checked)
                    {
                        for (int i = 0; i < int.Parse(textBox3.Text); i++)
                        {
                            pscan.tcpping(IPAddress.Parse(textBox1.Text), ushort.Parse(textBox5.Text), int.Parse(numericUpDown1.Value.ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int x;
        string name;
        PhysicalAddress admac;
        string id;
        string desc;
        int i = 0;
        CaptureDeviceList cdl = CaptureDeviceList.Instance;
        ILiveDevice dev;
        private void ping_Load(object sender, EventArgs e)
        {
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface n in nics)
                {
                    if (n.OperationalStatus == OperationalStatus.Up)
                    {
                        admac = n.GetPhysicalAddress();
                        name = n.Name;
                        id = n.Id;
                        desc = n.Description;
                        break;
                    }
                    else
                    {
                        x++;
                    }
                }
                foreach (ILiveDevice d in cdl)
                {
                    if (d.MacAddress == admac && d.Name == name)
                    {
                        dev = d;
                    }
                }
                if (cdl.Count > 0)
                {
                    foreach (ILiveDevice d in cdl)
                    {
                        comboBox3.Items.Insert(i, i + ") " + d.Name + d.Description + " | MAC Address: " + d.MacAddress);
                        i++;
                    }
                }
                textBox5.Text = $"{new Random().Next(0, 65535)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dev = cdl[comboBox3.SelectedIndex];
        }
    }
}
