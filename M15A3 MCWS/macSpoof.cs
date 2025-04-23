using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Logging;
using System.Windows.Forms;
namespace M15A3_MCWS
{
    public partial class macSpoof : Form
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
        public macSpoof()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.FormBorderStyle = FormBorderStyle.None;
        }
        static RegistryKey NetworkClass = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\");
        String reg = @"Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\";
        private const string br = @"SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002bE10318}\";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
        public static PhysicalAddress randmac()
        {
            var random = new Random();
            var buffer = new byte[6];
            random.NextBytes(buffer);
            var result = String.Concat(buffer.Select(x => string.Format("{0}:", x.ToString("X2"))).ToArray());
            return PhysicalAddress.Parse(result.TrimEnd(':'));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface ni in nics)
                    {
                        using (RegistryKey bkey = RegistryKey.OpenBaseKey(
                        RegistryHive.LocalMachine, RegistryView.Registry32))
                        using (RegistryKey key = bkey.OpenSubKey(br + ni))
                        {
                            NetworkClass.SetValue("NetworkAddress", randmac(), RegistryValueKind.String);
                        }
                    }
                }
                else if (radioButton2.Checked)
                {
                    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface ni in nics)
                    {
                        using (RegistryKey bkey = RegistryKey.OpenBaseKey(
                        RegistryHive.LocalMachine, RegistryView.Registry64))
                        using (RegistryKey key = bkey.OpenSubKey(br + ni))
                        {
                            NetworkClass.SetValue("NetworkAddress", randmac(), RegistryValueKind.String);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M15 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Timers.Timer t = new System.Timers.Timer();
                if (radioButton3.Checked)
                {
                    t.Interval = int.Parse(textBox1.Text) * 60000;
                }
                if (t.Enabled == false)
                {
                    t.Start();
                    if (radioButton1.Checked)
                    {
                        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                        foreach (NetworkInterface ni in nics)
                        {
                            using (RegistryKey bkey = RegistryKey.OpenBaseKey(
                            RegistryHive.LocalMachine, RegistryView.Registry32))
                            using (RegistryKey key = bkey.OpenSubKey(br + ni))
                            {
                                NetworkClass.SetValue("NetworkAddress", randmac(), RegistryValueKind.String);
                            }
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                        foreach (NetworkInterface ni in nics)
                        {
                            using (RegistryKey bkey = RegistryKey.OpenBaseKey(
                            RegistryHive.LocalMachine, RegistryView.Registry64))
                            using (RegistryKey key = bkey.OpenSubKey(br + ni))
                            {
                                NetworkClass.SetValue("NetworkAddress", randmac(), RegistryValueKind.String);
                            }
                        }
                    }
                }
                if (radioButton4.Checked)
                {
                    t.Interval = int.Parse(textBox1.Text) * 3600000;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface ni in nics)
                    {
                        using (RegistryKey bkey = RegistryKey.OpenBaseKey(
                        RegistryHive.LocalMachine, RegistryView.Registry32))
                        using (RegistryKey key = bkey.OpenSubKey(br + ni))
                        {
                            NetworkClass.SetValue("NetworkAddress", PhysicalAddress.Parse(macbox.Text), RegistryValueKind.String);
                        }
                    }
                }
                else if (radioButton2.Checked)
                {
                    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface ni in nics)
                    {
                        using (RegistryKey bkey = RegistryKey.OpenBaseKey(
                        RegistryHive.LocalMachine, RegistryView.Registry64))
                        using (RegistryKey key = bkey.OpenSubKey(br + ni))
                        {
                            NetworkClass.SetValue("NetworkAddress", PhysicalAddress.Parse(macbox.Text), RegistryValueKind.String);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "M15 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void macSpoof_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }
    }
}
