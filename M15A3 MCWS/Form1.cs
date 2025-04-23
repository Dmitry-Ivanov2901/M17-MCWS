using System.Runtime.InteropServices;
using Plugin.Connectivity;
using Nmap;
using Nmap.NET;
using Nmap.NET.Container;
using M15A3_MCWS.Properties;

namespace M15A3_MCWS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScaleMode = AutoScaleMode.Dpi;
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
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
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
            L4DDoS l4 = new L4DDoS();
            l4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            L7DoS l7 = new L7DoS();
            l7.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cfb cf = new cfb();
            cf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xss xs = new xss();
            xs.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ping p = new ping();
            p.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ebomb eb = new ebomb();
            eb.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqli s = new sqli();
            s.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            macSpoof ms = new macSpoof();
            ms.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tcpreset t = new tcpreset();
            t.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            doxdb dox = new doxdb();
            dox.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            arpspoof arp = new arpspoof();
            arp.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tracert tr = new tracert();
            tr.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            portscan ps = new portscan();
            ps.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            psniff ps = new psniff();
            ps.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button10_Click_1(object sender, EventArgs e)
        {
            portscan psc = new portscan();
            psc.Show();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            fileflood ff = new fileflood();
            ff.Show();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            hdisc hd = new hdisc();
            hd.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            custScript cs = new custScript();
            cs.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            vlanHopping vh = new vlanHopping();
            vh.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            macFlooding mf = new macFlooding();
            mf.Show();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            gl g = new gl();
            g.Show();
        }
    }
}