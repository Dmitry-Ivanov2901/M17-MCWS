using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpPcap.LibPcap;
using SharpPcap;
using PacketDotNet;
using System.Windows.Controls;
using PacketDotNet.Ieee80211;
using System.Net.Sockets;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace M15A3_MCWS
{
    public partial class psniff : Form
    {
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
        public psniff()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }
        int x;
        RawCapture rc;
        ILiveDevice dev;
        SaveFileDialog sfd = new SaveFileDialog();
        CaptureFileWriterDevice de;
        Dictionary<int, Packet> pkts = new Dictionary<int, Packet>();
        bool save = false;
        int count = -1;
        int i = 0;
        CaptureDeviceList cdl = CaptureDeviceList.Instance;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int x = comboBox1.SelectedIndex;
                dev = cdl[x];
                dev.Open();
                dev.OnPacketArrival += arrival;
                dev.Filter = textBox1.Text;
                dev.StartCapture();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        System.Windows.Forms.ListViewItem item;
        private void arrival(object sender, PacketCapture e)
        {
            try
            {
                rc = e.GetPacket();
                de.Write(rc);
                DateTime dt = rc.Timeval.Date;
                string tstr = $"{dt.Hour}:{dt.Minute}:{dt.Second}:{dt.Millisecond}";
                Packet p = rc.GetPacket();
                int len = rc.PacketLength;
                count++;
                pkts.Add(count, p);
                IPPacket ip = p.Extract<IPPacket>();
                string sip = "";
                string dip = "";
                int ttl = 0;
                int errorcode = 0;
                if (ip != null)
                {
                    sip = ip.SourceAddress.ToString();
                    dip = ip.DestinationAddress.ToString();
                    ttl = ip.TimeToLive;
                }
                TcpPacket tcp = p.Extract<TcpPacket>();
                UdpPacket udp = p.Extract<UdpPacket>();
                IcmpV4Packet icmp = p.Extract<IcmpV4Packet>();
                IcmpV6Packet icmp6 = p.Extract<IcmpV6Packet>();
                IgmpPacket igmp = p.Extract<IgmpPacket>();
                GrePacket gre = p.Extract<GrePacket>();
                ArpPacket arp = p.Extract<ArpPacket>();
                DhcpV4Packet dhcp = p.Extract<DhcpV4Packet>();
                EthernetPacket ep = p.Extract<EthernetPacket>();
                int sp = 0;
                PhysicalAddress smac = ep.SourceHardwareAddress;
                PhysicalAddress dmac = ep.DestinationHardwareAddress;
                string proto = "Ethernet";
                int dp = 0;
                if (icmp != null)
                {
                    proto = "ICMPv4";
                }
                if (icmp6 != null)
                {
                    proto = "ICMPv6";
                }
                if (igmp != null)
                {
                    proto = "IGMP";
                }
                if (gre != null)
                {
                    proto = "GRE";
                }
                if (arp != null)
                {
                    proto = "ARP";
                }
                if (dhcp != null)
                {
                    proto = "DHCP";
                }
                if (tcp != null)
                {
                    proto = "TCP";
                    sp = tcp.SourcePort;
                    dp = tcp.DestinationPort;
                }
                if (udp != null)
                {
                    proto = "UDP";
                    sp = udp.SourcePort;
                    dp = udp.DestinationPort;
                }
                string[] s = {$"{count}. | Time: {tstr} | Source IP: {sip} | Destination IP: {dip} | Ports: {sp} => {dp} | Protocol: {proto} | Length : {len}" + Environment.NewLine };
                item = new System.Windows.Forms.ListViewItem(s, 0, Color.Black, Color.LightBlue, new Font("Bahnschrift", 9));
                switch (proto)
                {
                    case "UDP":
                        item.BackColor = Color.LightSkyBlue;
                        item.ForeColor = Color.Black;
                        break;
                    case "TCP":
                        item.BackColor = Color.PaleVioletRed;
                        item.ForeColor = Color.Black;
                        break;
                    case "ICMP":
                        item.BackColor = Color.LightPink;
                        item.ForeColor = Color.Black;
                        break;
                }
                item.SubItems.Add("Time: " + tstr);
                item.SubItems.Add("Source IP: " + sip);
                item.SubItems.Add("Destination IP: " + dip);
                item.SubItems.Add("Protocol: " + proto);
                item.SubItems.Add("Ports: " + sp.ToString() + "=>" + dp.ToString());
                item.SubItems.Add("Data: " + rc.Data.ToString());
                item.SubItems.Add("Length: " + len.ToString());
                item.SubItems.Add("Source MAC: " + smac);
                item.SubItems.Add("Destination MAC: " + dmac);
                Action action = () =>  listView1.Items.Add(item);
                listView1.Invoke(action);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void psniff_Load(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                de = new CaptureFileWriterDevice(saveFileDialog1.FileName);
                de.Open();
                if (cdl.Count > 0)
                {
                    foreach(ILiveDevice d in cdl)
                    {
                        comboBox1.Items.Insert(i, i + ") " + d.Name + d.Description);
                        i++;
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No NICs were detected, try installing Npcap.", "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try {
            this.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                dev.StopCapture();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                CaptureFileReaderDevice cfrd = new CaptureFileReaderDevice(openFileDialog1.FileName);
                cfrd.Open();
                cfrd.OnPacketArrival += arrival;
                cfrd.StartCapture();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                de.Write(rc);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Packet p = pkts[e.ItemIndex];
            IPPacket ip = p.Extract<IPPacket>();
            string sip = "";
            string dip = "";
            int ttl = 0;
            if (ip != null)
            {
                sip = ip.SourceAddress.ToString();
                dip = ip.DestinationAddress.ToString();
                ttl = ip.TimeToLive;
            }
            TcpPacket tcp = p.Extract<TcpPacket>();
            UdpPacket udp = p.Extract<UdpPacket>();
            IcmpV4Packet icmp = p.Extract<IcmpV4Packet>();
            IcmpV6Packet icmp6 = p.Extract<IcmpV6Packet>();
            IgmpPacket igmp = p.Extract<IgmpPacket>();
            GrePacket gre = p.Extract<GrePacket>();
            ArpPacket arp = p.Extract<ArpPacket>();
            DhcpV4Packet dhcp = p.Extract<DhcpV4Packet>();
            EthernetPacket ep = p.Extract<EthernetPacket>();
            int sp = 0;
            PhysicalAddress smac = ep.SourceHardwareAddress;
            PhysicalAddress dmac = ep.DestinationHardwareAddress;
            string proto = "Ethernet";
            int dp = 0;
            if (icmp != null)
            {
                proto = "ICMPv4";
            }
            if (icmp6 != null)
            {
                proto = "ICMPv6";
            }
            if (igmp != null)
            {
                proto = "IGMP";
            }
            if (gre != null)
            {
                proto = "GRE";
            }
            if (arp != null)
            {
                proto = "ARP";
            }
            if (dhcp != null)
            {
                proto = "DHCP";
            }
            if (tcp != null)
            {
                proto = "TCP";
                sp = tcp.SourcePort;
                dp = tcp.DestinationPort;
            }
            if (udp != null)
            {
                proto = "UDP";
                sp = udp.SourcePort;
                dp = udp.DestinationPort;
            }
            List<Packet> packets = new List<Packet>();
            for (int i = 0; i < 15; i++)
            {
                if (p.HasPayloadPacket)
                {
                    Packet pkt = p.PayloadPacket;
                    if (pkt != null) 
                    {
                        packets.Add(pkt);
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
