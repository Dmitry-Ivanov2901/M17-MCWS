using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Runtime.InteropServices;

namespace M15A3_MCWS
{
    public partial class custScript : Form
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
        public custScript()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        string[] a;
        string fn;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
            string arg = $"{openFileDialog1.FileName}";
            foreach(string s in args.ar2)
            {
                a.Append<string>($"{s} ");
            }
            if(radioButton1.Checked)
            {
                Process.Start($@"cmd.exe");
            }
            else if(radioButton2.Checked)
            {
                Process.Start(fn, a);
            }
        }

        private void custScript_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            argDialog arg = new argDialog();
            arg.Show();
        }

        private void custScript_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".txt";
            sfd.Title = "M17 MCWS - Save custom attack script configurations";
            sfd.DefaultExt = ".txt";
            sfd.ShowDialog(this);
            File.Create(sfd.FileName);
            File.WriteAllText(sfd.FileName, fn + Environment.NewLine);
            File.WriteAllLines(sfd.FileName, a);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string[] data = File.ReadAllLines(openFileDialog1.FileName);
            fn = data[0];
            string[] ar = data[new Range(1, data.Length)];
            ar.CopyTo(a, 1);
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
    }
}
