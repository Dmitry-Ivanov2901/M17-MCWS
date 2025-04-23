using M15A3_MCWS.Properties;
using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace M15A3_MCWS
{
    public partial class tcpreset : Form
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
        public tcpreset()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static PhysicalAddress randmac()
        {
            var random = new Random();
            var buffer = new byte[6];
            random.NextBytes(buffer);
            var result = String.Concat(buffer.Select(x => string.Format("{0}:", x.ToString("X2"))).ToArray());
            return PhysicalAddress.Parse(result.TrimEnd(':'));
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
        int x;
        string name;
        string id;
        string desc;
        CaptureDeviceList cdl = CaptureDeviceList.Instance;
        ILiveDevice dev;
        PhysicalAddress admac;
        private void button2_Click(object sender, EventArgs e)
        {
            dev.Open();
            IPAddress ipa = IPAddress.Parse(ipbox.Text);
            ushort sport = ushort.Parse(sportbox.Text);
            ushort dport = ushort.Parse(dportbox.Text);
            IPAddress sp = IPAddress.Parse(sip.Text);
            IPEndPoint ipe = new IPEndPoint(ipa, dport);
            EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip = new IPv4Packet(sp, ipa);
            IPv6Packet ip6 = new IPv6Packet(sp, ipa);
            var tcp = new TcpPacket(sport, dport);
            ushort ttl = 250;
            if (ipa.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = tcp;
                ep.PayloadPacket = ip;
            }
            else if (ipa.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = tcp;
                ep.PayloadPacket = ip6;
            }
            tcp.SourcePort = sport;
            tcp.DestinationPort = dport;
            tcp.Reset = true;
            dev.SendPacket(ep.Bytes);
        }

        private void tcpreset_Load(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                if (Settings.Default.mainnicname == null)
                {
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
                }
                else
                {
                    foreach (NetworkInterface n in nics)
                    {
                        if (n.Name == Settings.Default.mainnicname)
                        {
                            admac = n.GetPhysicalAddress();
                            break;
                        }
                        x++;
                    }
                    dev = cdl[x];
                }
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
        }
    }
}
