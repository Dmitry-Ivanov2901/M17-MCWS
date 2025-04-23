using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
namespace M15A3_MCWS
{
    public partial class tracert : Form
    {
        public tracert()
        {
            this.AutoScaleMode = AutoScaleMode.Font;
            InitializeComponent();
        }

        private void tracert_Load(object sender, EventArgs e)
        {

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
        private async void button6_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                IPAddress dst = IPAddress.Parse(textBox1.Text);
                int timeout = (int)numericUpDown1.Value;
                Ping p = new Ping();
                PingOptions po = new PingOptions();
                int x = 1;
                for (int i = 1; i < int.Parse(textBox2.Text); i++)
                {
                    po.Ttl = i;
                    PingReply pr = p.Send(dst, timeout);
                    if (pr.Status == IPStatus.Success || pr.Status == IPStatus.DestinationPortUnreachable)
                    {
                        textBox3.AppendText($"Hop {x}) IP: {pr.Address} | Time: {pr.RoundtripTime}" + Environment.NewLine);
                    }
                    else
                    {
                        textBox3.AppendText($"Hop {x}) IP: **** | Timed out" + Environment.NewLine);
                    }
                    x++;
                }
            }
            if (radioButton1.Checked)
            {
                IPAddress ipa = IPAddress.Parse(textBox1.Text);
                IPEndPoint ipe = new IPEndPoint(ipa, int.Parse(textBox4.Text));
                Socket s = new Socket(ipe.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
                s.ReceiveTimeout = (int)numericUpDown1.Value;
                int x = 1;
                for (int i = 1; i < int.Parse(textBox2.Text); i++)
                {
                    try
                    {
                        s.Ttl = (short)i;
                        s.Connect(ipe);
                        s.Disconnect(true);
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode == SocketError.Success || ex.SocketErrorCode == SocketError.IsConnected || ex.SocketErrorCode == SocketError.ProtocolType || ex.SocketErrorCode == SocketError.ConnectionReset || ex.SocketErrorCode == SocketError.ConnectionRefused)
                        {
                            textBox3.AppendText($"Hop {x}) IP: {((IPEndPoint)s.RemoteEndPoint).Address}" + Environment.NewLine);
                        }
                        else
                        {
                            textBox3.AppendText($"Hop {x}) IP: **** | Timed out" + Environment.NewLine);
                        }
                    }
                    x++;
                }
            }
        }
    }
}
