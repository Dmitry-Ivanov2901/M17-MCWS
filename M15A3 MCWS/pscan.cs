using Microsoft.Windows.Themes;
using PacketDotNet;
using SharpPcap;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace M15A3_MCWS
{
    internal class pscan
    {
        public static bool open = false;
        public static bool filtered = false;
        public static bool ofilter = false;
        static IPAddress dst;
        public static PhysicalAddress dgw;
        private static void arrivaltcp(object sender, PacketCapture p)
        {
            RawCapture pkt = p.GetPacket();
            Packet pak = pkt.GetPacket();
            EthernetPacket ep = pak.Extract<EthernetPacket>();
            if (ep != null)
            {
                IPv4Packet ip = pak.Extract<IPv4Packet>();
                if (ip != null && ip.SourceAddress == dst)
                {
                    TcpPacket tcp = pak.Extract<TcpPacket>();
                    if (tcp != null)
                    {
                        open = true;
                    }
                    else
                    {
                        open = false;
                    }
                }
            }
        }
        private static void arrivaludp(object sender, PacketCapture p)
        {
            RawCapture pkt = p.GetPacket();
            Packet pak = pkt.GetPacket();
            EthernetPacket ep = pak.Extract<EthernetPacket>();
            if (ep != null)
            {
                IPv4Packet ip = pak.Extract<IPv4Packet>();
                if (ip != null && ip.SourceAddress == dst)
                {
                    UdpPacket udp = pak.Extract<UdpPacket>();
                    IcmpV4Packet ic = pak.Extract<IcmpV4Packet>();
                    if(udp != null)
                    {
                        open = true;
                    }
                    else if (ic != null && ic.TypeCode == IcmpV4TypeCode.UnreachablePort)
                    {
                        open = false;
                    }
                    else if (ic != null && ic.TypeCode != IcmpV4TypeCode.UnreachablePort)
                    {
                        filtered = true;
                    }
                    else
                    {
                        ofilter = true;
                    }
                }
            }
        }
        public static string tcpping(IPAddress dst, ushort tport, int timeout)
        {
            IPEndPoint ipe = new IPEndPoint(dst, tport);
            Socket s = new Socket(ipe.AddressFamily, SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
            try
            {
                s.ConnectAsync(ipe);
                return $"The host {dst.ToString()} is up." + Environment.NewLine;
            }
            catch (Exception ex)
            {
                return $"The host {dst.ToString()} is down." + Environment.NewLine;
            }
        }
        public static System.Windows.Forms.Timer tim = new System.Windows.Forms.Timer();

        public static string udpping(IPAddress dst, ushort tport, int timeout)
        {
            bool finished = false;
            byte[] data = new byte[65535];
            try
            {
                IPEndPoint ipe = new IPEndPoint(dst, tport);
                Socket so = new Socket(ipe.AddressFamily, SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);
                so.ReceiveTimeout = timeout;
                so.Connect(ipe);
                so.Send(new byte[32]);
                int recv = so.Receive(data);
                if (data != null && recv > 0)
                {
                    return $"The host {dst.ToString()} is up." + Environment.NewLine;
                }
                else if (data == null && recv == 0)
                {
                    return $"The host {dst.ToString()} is down." + Environment.NewLine;
                }
                else
                {
                    return "An unknown error has occured" + Environment.NewLine;
                }
            }
            catch(SocketException ex)
            {
                if(ex.SocketErrorCode == SocketError.ConnectionReset || ex.SocketErrorCode == SocketError.ConnectionRefused || ex.SocketErrorCode == SocketError.IsConnected || ex.SocketErrorCode == SocketError.ProtocolNotSupported || ex.SocketErrorCode == SocketError.Success)
                {
                    return $"The host {dst} is up." + Environment.NewLine;
                }
                else
                {
                    return $"Host: {dst} | ERROR: {ex.Message}" + Environment.NewLine;
                }
            }
        }
        public static string udpping(IPAddress dst, ushort tport, int timeout, short ttl)
        {
            bool finished = false;
            byte[] data = new byte[65535];
            try
            {
                IPEndPoint ipe = new IPEndPoint(dst, tport);
                Socket so = new Socket(ipe.AddressFamily, SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);
                so.Ttl = ttl;
                so.ReceiveTimeout = timeout;
                so.ConnectAsync(ipe);
                so.SendAsync(new byte[32]);
                int recv = so.ReceiveAsync(data).Result;
                if (data != null && recv > 0)
                {
                    return $"The host {dst.ToString()} is up." + Environment.NewLine;
                }
                else if (data == null && recv == 0)
                {
                    return $"The host {dst.ToString()} is down." + Environment.NewLine;
                }
                else
                {
                    return "An unknown error has occured" + Environment.NewLine;
                }
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.ConnectionReset || ex.SocketErrorCode == SocketError.ConnectionRefused || ex.SocketErrorCode == SocketError.IsConnected || ex.SocketErrorCode == SocketError.ProtocolNotSupported || ex.SocketErrorCode == SocketError.Success)
                {
                    return $"The host {dst} is up." + Environment.NewLine;
                }
                else
                {
                    return $"Host: {dst} | ERROR: {ex.Message}" + Environment.NewLine;
                }
            }
        }
        public void icmp(IPAddress ipa, int x, TextBox textBox2)
        {
            try
            {
                byte[] buf = new byte[64];
                Ping p = new Ping();
                textBox2.AppendText($"Pinging {ipa.ToString()}" + Environment.NewLine);
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
        public static string udp(IPAddress src, IPAddress dst, ushort sport, ushort tport, ILiveDevice dev)
        {
            pscan.dst = dst;
            CaptureDeviceList cdl = CaptureDeviceList.Instance;
            if (!portscan.manual)
            {
                NetworkInterface[] nwi = NetworkInterface.GetAllNetworkInterfaces();
                PhysicalAddress mac = PhysicalAddress.None;
                foreach (NetworkInterface n in nwi)
                {
                    if (n.OperationalStatus == OperationalStatus.Up)
                    {
                        mac = n.GetPhysicalAddress();
                    }
                    break;
                }
                foreach (ILiveDevice n in cdl)
                {
                    if (n.MacAddress == mac)
                    {
                        dev = n;
                        break;
                    }
                }
            }
            EthernetPacket ep = new EthernetPacket(dev.MacAddress, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip = new IPv4Packet(src, dst);
            UdpPacket udp = new UdpPacket(sport, tport);
            dev.Open();
            dev.OnPacketArrival += arrivaludp;
            dev.StartCapture();
            ep.PayloadPacket = ip;
            ip.PayloadPacket = udp;
            dev.SendPacket(ep.Bytes);
            if(open)
            {
                return $"UDP port {tport} | OPEN" + Environment.NewLine;
            }
            else if (ofilter)
            {
                return $"UDP port {tport} | OPEN / FILTERED" + Environment.NewLine;
            }
            else
            {
                return $"UDP port {tport} | CLOSED" + Environment.NewLine;
            }
        }
        public static string syn(IPAddress src, IPAddress dst, ushort sport, ushort tport, ILiveDevice dev)
        {
            pscan.dst = dst;
            if (!portscan.manual)
            {
                NetworkInterface[] nwi = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface n in nwi)
                {
                    if (n.OperationalStatus == OperationalStatus.Up)
                    {
                        string hn = Dns.GetHostName();
                        src = Dns.GetHostAddresses(hn)[0];
                    }
                }
            }
            EthernetPacket ep = new EthernetPacket(dev.MacAddress, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
            IPv4Packet ip = new IPv4Packet(src, dst);
            TcpPacket tcp = new TcpPacket(sport, tport);
            tcp.Synchronize = true;
            ep.PayloadPacket = ip;
            ip.PayloadPacket = tcp;
            dev.Open();
            dev.OnPacketArrival += arrivaltcp;
            dev.StartCapture();
            dev.SendPacket(ep);
            if (open)
            {
                EthernetPacket ep1 = new EthernetPacket(dev.MacAddress, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                IPv4Packet ip1 = new IPv4Packet(src, dst);
                TcpPacket tcp1 = new TcpPacket(sport, tport);
                tcp1.Reset = true;
                ep1.PayloadPacket = ip1;
                ip1.PayloadPacket = tcp1;
                dev.SendPacket(ep1);
                open = false;
                dev.StopCapture();
                return $"TCP port {tport} | OPEN" + Environment.NewLine;
            }
            else
            {
                dev.StopCapture();
                return $"TCP port {tport} | CLOSED" + Environment.NewLine;
            }
        }
        public static string conn(IPAddress tg, int port)
        {
            try
            {
                TcpClient t = new TcpClient();
                t.ConnectAsync(tg, port);
                bool tf = t.Connected;
                t.Close();
                if (tf)
                {
                    return $"TCP port {port} | OPEN" + Environment.NewLine;
                }
                else
                {
                    return $"TCP port {port} | CLOSED" + Environment.NewLine;
                }
            }
            catch (SocketException e) 
            {
                if (e.SocketErrorCode == SocketError.TimedOut)
                {
                    return $"TCP port {port} | CLOSED" + Environment.NewLine;
                }
                else if (e.SocketErrorCode == SocketError.Success) 
                {
                    return $"TCP port {port} | OPEN" + Environment.NewLine;
                }
                else if(e.SocketErrorCode == SocketError.IsConnected)
                {
                    return $"TCP port {port} | OPEN" + Environment.NewLine;
                }
                else
                {
                    return $"TCP port {port} | CLOSED" + Environment.NewLine;
                }
            }
        }
    }
}
