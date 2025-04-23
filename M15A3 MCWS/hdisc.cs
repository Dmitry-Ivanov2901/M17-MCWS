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
using System.Net;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using DnsClient;
using SharpPcap;
using PacketDotNet;
using NetTools;

namespace M15A3_MCWS
{
    public partial class hdisc : Form
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
        int x;
        string name;
        PhysicalAddress admac;
        string id;
        string desc;
        CaptureDeviceList cdl = CaptureDeviceList.Instance;
        ILiveDevice dev;
        private void http()
        {
            string url = textBox1.Text;
            if (IPAddress.TryParse(url, out IPAddress ip))
            {
                url = $"http://{textBox1.Text}";
            }
            else if (!IPAddress.TryParse(textBox1.Text, out IPAddress IP))
            {
                url = textBox1.Text;
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(textBox1.Text);
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            if (res.StatusCode >= (HttpStatusCode)100 || res.StatusCode <= (HttpStatusCode)199 || res.StatusCode >= (HttpStatusCode)200 || res.StatusCode <= (HttpStatusCode)299 || res.StatusCode >= (HttpStatusCode)300 || res.StatusCode <= (HttpStatusCode)399 || res.StatusCode >= (HttpStatusCode)400 || res.StatusCode <= (HttpStatusCode)499)
            {
                this.Invoke(new MethodInvoker(() => textBox2.AppendText($"The host is up, the HTTP response code is {res.StatusCode.ToString()}")));
            }
            else
            {
                this.Invoke(new MethodInvoker(() => textBox2.AppendText($"The host is down, the HTTP response code is {res.StatusCode.ToString()}")));
            }
        }
        private void udp(IPAddress ipa)
        {
            this.Invoke(new MethodInvoker(() => textBox2.AppendText(pscan.udpping(ipa, ushort.Parse(textBox4.Text), int.Parse(numericUpDown1.Value.ToString())))));
        }
        private void tcp(IPAddress ipa)
        {
            TcpClient tc = new TcpClient();
            tc.Connect(ipa, int.Parse(textBox4.Text));
            if (tc.Connected)
            {
                this.Invoke(new MethodInvoker(() => textBox2.AppendText($"The host {ipa} is up.")));
            }
            else
            {
                this.Invoke(new MethodInvoker(() => textBox2.AppendText($"The host {ipa} is down.")));
            }
            tc.Close();
        }
        public hdisc()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }
        public static Task<PingReply> pa(IPAddress ipa)
        {
            TaskCompletionSource<PingReply> tcs = new TaskCompletionSource<PingReply>();
            Ping p = new Ping();
            p.PingCompleted += (obj, sender) =>
            {
                tcs.SetResult(sender.Reply);
            };
            p.SendAsync(ipa, new object());
            return tcs.Task;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkBox1.Checked)
                {
                    IPAddressRange ipr = IPAddressRange.Parse($"{textBox1.Text}/24");
                    if (cIcmp.Checked)
                    {
                        Ping p = new Ping();
                        p.PingCompleted += pcomp;
                        IPAddressRange ips = IPAddressRange.Parse($"{textBox1.Text}/24");
                        List<Task<PingReply>> ps = new List<Task<PingReply>>();
                        foreach (IPAddress ipa in ips)
                        {
                            ps.Add(pa(ipa));
                        }
                        Task.WaitAll(ps.ToArray());
                        foreach (var t in ps)
                        {
                            if (t.Result.Status == IPStatus.Success)
                            {
                                textBox2.AppendText($"The host {t.Result.Address.ToString()} has replied in {t.Result.RoundtripTime} ms.");
                            }
                            else
                            {
                                textBox2.AppendText($"The host {t.Result.Address.ToString()} has failed to reply.");
                            }
                        }
                    }
                    else if (cTcp.Checked)
                    {
                        IPAddress beginning = IPAddress.Parse(textBox1.Text);
                        int fOctet = int.Parse(textBox1.Text.Split('.')[0]);
                        int sOctet = int.Parse(textBox1.Text.Split('.')[1]);
                        int tOctet = int.Parse(textBox1.Text.Split('.')[2]);
                        int lastOctet = int.Parse(textBox1.Text.Split('.')[3]);
                        for (int i = 0; i < 255; i++)
                        {
                            string nip = $"{fOctet}.{sOctet}.{tOctet}.{i}";
                            IPAddress ipa = IPAddress.Parse(nip);
                            Task.Run(() => tcp(ipa));
                        }
                    }
                    else if (cUdp.Checked)
                    {
                        IPAddress beginning = IPAddress.Parse(textBox1.Text);
                        int fOctet = int.Parse(textBox1.Text.Split('.')[0]);
                        int sOctet = int.Parse(textBox1.Text.Split('.')[1]);
                        int tOctet = int.Parse(textBox1.Text.Split('.')[2]);
                        int lastOctet = int.Parse(textBox1.Text.Split('.')[3]);
                        foreach (IPAddress ipa in ipr)
                        {
                            Task.Run(() => udp(ipa));
                        }
                    }
                    else if (cHttp.Checked)
                    {
                        IPAddress beginning = IPAddress.Parse(textBox1.Text);
                        int fOctet = int.Parse(textBox1.Text.Split('.')[0]);
                        int sOctet = int.Parse(textBox1.Text.Split('.')[1]);
                        int tOctet = int.Parse(textBox1.Text.Split('.')[2]);
                        int lastOctet = int.Parse(textBox1.Text.Split('.')[3]);
                        for (int i = 0; i < 255; i++)
                        {
                            Task.Run(() => http());
                        }
                    }
                }
                else
                {
                    Ping p = new Ping();
                    p.PingCompleted += pcomp;
                    IPAddressRange ipr = IPAddressRange.Parse(textBox1.Text);
                    if (cIcmp.Checked)
                    {
                        List<Task<PingReply>> ps = new List<Task<PingReply>>();
                        foreach (IPAddress ipa in ipr)
                        {
                            ps.Add(pa(ipa));
                        }
                        Task.WaitAll(ps.ToArray());
                        foreach (var t in ps)
                        {
                            if (t.Result.Status == IPStatus.Success)
                            {
                                textBox2.AppendText($"The host {t.Result.Address.ToString()} has replied in {t.Result.RoundtripTime} ms.");
                            }
                            else
                            {
                                textBox2.AppendText($"The host {t.Result.Address.ToString()} has failed to reply.");
                            }
                        }
                    }
                    else if (cTcp.Checked)
                    {
                        foreach (IPAddress ipa in ipr)
                        {
                            Task.Run(() => udp(ipa));
                        }
                    }
                    else if (cUdp.Checked)
                    {
                        foreach (IPAddress ipa in ipr)
                        {
                            Task.Run(() => udp(ipa));
                        }
                    }
                    else if (cHttp.Checked)
                    {
                        foreach (IPAddress ipa in ipr)
                        {
                            Task.Run(() => udp(ipa));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pcomp(object sender, PingCompletedEventArgs e)
        {
            if (e.Reply.Status == IPStatus.Success)
            {
                textBox2.AppendText($"Host {e.Reply.Address} has responded to an ICMP ping in {e.Reply.RoundtripTime}." + Environment.NewLine);
            }
            else
            {
                textBox2.AppendText($"Host {e.Reply.Address} has failed to respond to an ICMP ping in {e.Reply.RoundtripTime}" + Environment.NewLine);
            }
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
        int i = 0;
        private void hdisc_Load(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dev = cdl[comboBox3.SelectedIndex];
        }
    }
}
