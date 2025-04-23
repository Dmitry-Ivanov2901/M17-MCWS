using DnsClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M15A3_MCWS
{
    public partial class cfb : Form
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
        public cfb()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LookupClient lc = new LookupClient();
                if(textBox3.Text != "")
                {
                    lc = new LookupClient(IPAddress.Parse(textBox3.Text));
                }
                var result = lc.Query(textBox1.Text, QueryType.ANY);
                var mxRecords = result.Answers.MxRecords();
                var nsRecords = result.Answers.NsRecords();
                var aRecords = result.Answers.ARecords();
                var aaaaRecords = result.Answers.AaaaRecords();
                results.SelectionStart = 0;
                results.SelectionLength = 1;
                results.SelectionFont = new Font("Bahnschrift", 22, FontStyle.Underline);
                results.SelectionColor = Color.Orange;
                results.AppendText("A records");
                results.SelectionColor = Color.Cyan;
                foreach (var x in aRecords)
                {
                    results.SelectionLength++;
                    results.AppendText($"TYPE: A | HOSTNAME: {x.DomainName} | IP: {lc.Query(x.DomainName, QueryType.A).Answers.ARecords().First().Address}");
                }
                results.SelectionColor = Color.Orange;
                results.AppendText("NS records");
                results.SelectionColor = Color.Cyan;
                foreach (var x in nsRecords)
                {
                    results.SelectionLength++;
                    results.AppendText($"TYPE: NS | HOSTNAME: {x.DomainName} | IP: {lc.Query(x.DomainName, QueryType.A).Answers.ARecords().First().Address}");
                }
                results.SelectionColor = Color.Orange;
                results.AppendText("MX records");
                results.SelectionColor = Color.Cyan;
                foreach (var x in mxRecords)
                {
                    results.SelectionLength++;
                    results.AppendText($"TYPE: MX | HOSTNAME: {x.DomainName} | IP: {lc.Query(x.DomainName, QueryType.A).Answers.ARecords().First().Address}");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "M15A2 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
