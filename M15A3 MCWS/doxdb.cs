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
    public partial class doxdb : Form
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
        public doxdb()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        OpenFileDialog openFile = new OpenFileDialog();
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

        private void doxdb_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
            if (radioButton1.Checked)
            {
                SqlConnection conn = new SqlConnection($@"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={openFile.FileName};Integrated Security=True");
                SqlCommand sqlc = new SqlCommand($"Select * from dox where IP like {ipbox.Text}");
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                sqlc.Connection = conn;
                sqlc.ExecuteNonQuery();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (radioButton2.Checked)
            {
                SqlConnection conn = new SqlConnection($@"Data Source=DIMA;Initial Catalog={openFile.FileName};Integrated Security=True;Pooling=False");
                SqlCommand sqlc = new SqlCommand($"Select * from dox where profilename like {pnamebox.Text}");
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                sqlc.Connection = conn;
                sqlc.ExecuteNonQuery();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (radioButton3.Checked)
            {
                SqlConnection conn = new SqlConnection($@"Data Source=DIMA;Initial Catalog={openFile.FileName};Integrated Security=True;Pooling=False");
                SqlCommand sqlc = new SqlCommand($"Select * from dox where rname like {namebox.Text}");
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                sqlc.Connection = conn;
                sqlc.ExecuteNonQuery();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (radioButton4.Checked)
            {
                SqlConnection conn = new SqlConnection($@"Data Source=DIMA;Initial Catalog={openFile.FileName};Integrated Security=True;Pooling=False");
                SqlCommand sqlc = new SqlCommand($"Select * from dox where email like {ebox.Text}");
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                sqlc.Connection = conn;
                sqlc.ExecuteNonQuery();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (radioButton5.Checked)
            {
                SqlConnection conn = new SqlConnection($@"Data Source=DIMA;Initial Catalog={openFile.FileName};Integrated Security=True;Pooling=False");
                SqlCommand sqlc = new SqlCommand($"Select * from dox where steamid like {sidbox.Text}");
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                sqlc.Connection = conn;
                sqlc.ExecuteNonQuery();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            editDb ed = new editDb();
            ed.Show();
        }
    }
}
