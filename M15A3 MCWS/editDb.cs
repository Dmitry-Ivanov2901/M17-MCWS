using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M15A3_MCWS
{
    public partial class editDb : Form
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
        public editDb()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            SqlConnection sql = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={ofd.FileName};Integrated Security=True");
            sql.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO dox ([id], [IP], [steamid], [rname], [profilename], [address], [email], [phonenumber], [location])" +
                $"VALUES (@id, @ip, @sid, @rn, @profn, @addr, @email, @pn, @loc)", sql);
            cmd.Parameters.AddWithValue("@id", r.Next(0, 900000));
            cmd.Parameters.AddWithValue("@ip", ipbox.Text);
            cmd.Parameters.AddWithValue("@sid", sidbox.Text);
            cmd.Parameters.AddWithValue("@rn", namebox.Text);
            cmd.Parameters.AddWithValue("@profn", pnamebox.Text);
            cmd.Parameters.AddWithValue("@addr", addbox.Text);
            cmd.Parameters.AddWithValue("@email", ebox.Text);
            cmd.Parameters.AddWithValue("@pn", pnbox.Text);
            cmd.Parameters.AddWithValue("@loc", lbox.Text);
            cmd.Connection = sql;
            cmd.ExecuteNonQuery();
            sql.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
