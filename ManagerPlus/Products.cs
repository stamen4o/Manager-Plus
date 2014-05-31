﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerPlus
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            MaximizeBox = false;
            borderPanel1.MouseDown += new MouseEventHandler(Form1_MouseDown);
        }

        private void Products_Load(object sender, EventArgs e) 
        {
            this.TopMost = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

        private void изходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void borderPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
