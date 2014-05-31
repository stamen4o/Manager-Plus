using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerPlus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
            borderPanel1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            label1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            menuStrip1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            
        }
        //mouse event drag:
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender,
        System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            statusBar1.Text = " Ready";
        }

        private void приходиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBar1.Text = "Initializing...";
        }

        private void productsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
        }

       private void makeProductАртикулToolStripMenuItem_Click_1(object sender, EventArgs e)
       {
            MakeProduct makeProduct = new MakeProduct();
            makeProduct.Show();
       }

       private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
       {
           this.Close();
       }

       private void minToolStripMenuItem_Click_1(object sender, EventArgs e)
       {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon1.BalloonTipTitle = "Manager+";
            notifyIcon1.BalloonTipText = "Your application has been minimized to the taskbar.";
            notifyIcon1.ShowBalloonTip(1500);
       }

       private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
       {
           this.WindowState = FormWindowState.Normal;
           
       }
       
    }
}
