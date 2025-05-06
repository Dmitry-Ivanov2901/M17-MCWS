using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nmap;
using Nmap.NET;
using Nmap.NET.Utility;
using Nmap.NET.Container;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using SharpPcap;
using M15A3_MCWS.Properties;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Diagnostics;

namespace M15A3_MCWS
{
    public partial class portscan : Form
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
        public portscan()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }
        int x;
        string name;
        PhysicalAddress admac;
        string id;
        string desc;
        PhysicalAddress dgwmac;
        CaptureDeviceList cdl = CaptureDeviceList.Instance;
        ILiveDevice dev;
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process proc = new Process();
                ProcessStartInfo psi = new ProcessStartInfo();
                proc.StartInfo = psi;
                psi.FileName = @"cmd.exe";
                psi.UseShellExecute = true;
                string[] ports = textBox5.Text.Split(',');
                Random r = new Random();
                string args = $"/c start nrecon.py -p {textBox5.Text} -t {textBox1.Text}";
                if (checkBox1.Checked)
                {
                    args += " -sU true ";
                }
                if (checkBox2.Checked) 
                {
                    args += " -O true ";
                }
                if (checkBox3.Checked)
                {
                    args += " -Pn true ";
                }
                if (radioButton2.Checked)
                {
                    args += " -sS true ";
                }
                if (checkBox4.Checked)
                {
                    args += " -Dn true ";
                }
                if (radioButton3.Checked)
                {
                    args += " -sA true ";
                }
                if (radioButton4.Checked)
                {
                    args += " -sF true ";
                }
                if (radioButton5.Checked)
                {
                    args += " -sN true ";
                }
                if (radioButton1.Checked) 
                {
                    foreach (string p in ports) 
                    {
                        int po = Convert.ToInt32(p);
                        textBox2.AppendText(pscan.conn(IPAddress.Parse(textBox1.Text), po));
                    }
                }
                psi.Arguments = args;
                proc.Start();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void portscan_Load(object sender, EventArgs e)
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
                        IPInterfaceProperties p = n.GetIPProperties();
                        if (p != null)
                        {
                            IPAddress ip = p.GatewayAddresses[0].Address;
                            dgwmac = ArpLookup.Arp.Lookup(ip);
                        }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool manual = false;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
