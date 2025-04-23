using HtmlAgilityPack;
using PuppeteerSharp;
using PuppeteerSharp.Input;
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
    public partial class xss : Form
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
        public static string RandString(int length)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random r = new Random();
            string result = "";
            for (int i = 0; i < length; i++)
            {
                result += alphabet[r.Next(alphabet.Length)];
            }
            return result;
        }
        public xss()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScaleMode = AutoScaleMode.Dpi;
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
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] inputPayloads = payload.Text.Split(',');
                string[] urlPayloads = textBox2.Text.Split(",");
                if (textBox2.Text.Length == 0)
                {
                    if (textBox1.Text == "")
                    {
                        openFileDialog1.ShowDialog();
                        var b = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true, ExecutablePath = openFileDialog1.FileName });
                        var p = await b.NewPageAsync();
                        await p.GoToAsync(urlbox.Text);
                        var content = await p.GetContentAsync();
                        string holes = @"Array.from(document.querySelectorAll('input')).map(a => a.innerText)";
                        var inputs = await p.EvaluateExpressionAsync<string[]>(holes);
                        foreach (string input in inputs)
                        {
                            await p.TypeAsync(input, payload.Text);
                            await p.Keyboard.PressAsync(Keys.Enter.ToString());
                            await p.ReloadAsync();
                        }
                        p.CloseAsync();
                    }
                    else
                    {
                        openFileDialog1.ShowDialog();
                        LaunchOptions lo = new LaunchOptions
                        {
                            Headless = false,
                            IgnoreHTTPSErrors = true,
                            ExecutablePath = openFileDialog1.FileName,
                            Args = new[] {
        $"--proxy-server={textBox1.Text}",
        "--no-sandbox",
        "--disable-infobars",
        "--disable-setuid-sandbox",
        "--ignore-certificate-errors",
    },
                        };
                        var b = await Puppeteer.LaunchAsync(lo);
                        var p = await b.NewPageAsync();
                        await p.GoToAsync(urlbox.Text);
                        var content = await p.GetContentAsync();
                        string holes = @"Array.from(document.querySelectorAll('input')).map(a => a.innerText)";
                        var inputs = await p.EvaluateExpressionAsync<string[]>(holes);
                        foreach (string input in inputs)
                        {
                            await p.TypeAsync(input, payload.Text);
                            await p.Keyboard.PressAsync(Keys.Enter.ToString());
                            await p.ReloadAsync();
                        }
                        await p.GoToAsync(urlbox.Text + (char)34 + payload.Text);
                        HtmlWeb hw = new HtmlWeb();
                        HtmlAgilityPack.HtmlDocument doc = hw.Load(urlbox.Text);
                        foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                        {
                            HtmlAttribute att = link.Attributes["href"];
                            await p.GoToAsync(att.Value);
                            var c = await p.GetContentAsync();
                            var i = await p.EvaluateExpressionAsync<string[]>(holes);
                            foreach (string inp in i)
                            {
                                await p.TypeAsync(inp, payload.Text);
                                await p.Keyboard.PressAsync(Keys.Enter.ToString());
                                await p.ReloadAsync();
                            }
                        }
                        p.CloseAsync();
                    }
                }
                else
                {
                    if (textBox1.Text == "")
                    {
                        openFileDialog1.ShowDialog();
                        var b = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true, ExecutablePath = openFileDialog1.FileName });
                        var p = await b.NewPageAsync();
                        await p.GoToAsync(urlbox.Text);
                        var content = await p.GetContentAsync();
                        string holes = @"Array.from(document.querySelectorAll('input')).map(a => a.innerText)";
                        var inputs = await p.EvaluateExpressionAsync<string[]>(holes);
                        foreach (string input in inputs)
                        {
                            await p.TypeAsync(input, payload.Text);
                            await p.Keyboard.PressAsync(Keys.Enter.ToString());
                            await p.ReloadAsync();
                        }
                        await p.GoToAsync(urlbox.Text + (char)34 + payload.Text);
                        p.CloseAsync();
                    }
                    else
                    {
                        openFileDialog1.ShowDialog();
                        LaunchOptions lo = new LaunchOptions
                        {
                            Headless = false,
                            IgnoreHTTPSErrors = true,
                            ExecutablePath = openFileDialog1.FileName,
                            Args = new[] {
        $"--proxy-server={textBox1.Text}",
        "--no-sandbox",
        "--disable-infobars",
        "--disable-setuid-sandbox",
        "--ignore-certificate-errors",
    },
                        };
                        var b = await Puppeteer.LaunchAsync(lo);
                        var p = await b.NewPageAsync();
                        await p.GoToAsync(urlbox.Text);
                        var content = await p.GetContentAsync();
                        string holes = @"Array.from(document.querySelectorAll('input')).map(a => a.innerText)";
                        var inputs = await p.EvaluateExpressionAsync<string[]>(holes);
                        foreach (string input in inputs)
                        {
                            await p.TypeAsync(input, payload.Text);
                            await p.Keyboard.PressAsync(Keys.Enter.ToString());
                            await p.ReloadAsync();
                        }
                        await p.GoToAsync(urlbox.Text + (char)34 + payload.Text);
                        HtmlWeb hw = new HtmlWeb();
                        HtmlAgilityPack.HtmlDocument doc = hw.Load(urlbox.Text);
                        foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                        {
                            HtmlAttribute att = link.Attributes["href"];
                            await p.GoToAsync(att.Value);
                            var c = await p.GetContentAsync();
                            var i = await p.EvaluateExpressionAsync<string[]>(holes);
                            foreach (string inp in i)
                            {
                                foreach (string kod in inputPayloads)
                                {
                                    await p.TypeAsync(inp, kod);
                                    await p.Keyboard.PressAsync(Keys.Enter.ToString());
                                    await p.ReloadAsync();
                                }
                            }
                            foreach (string kod2 in urlPayloads)
                            {
                                await p.GoToAsync(att.Value + (char)34 + payload.Text);
                            }
                        }
                        p.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                string code = File.ReadAllText(openFileDialog1.FileName);
                payload.Text = code;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "M17 MCWS - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
