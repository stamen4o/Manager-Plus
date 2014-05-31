using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerPlus
{
    public partial class MakeProduct : Form
    {
        public MakeProduct()
        {
            InitializeComponent();
            MaximizeBox = false;
            borderPanel1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            pictureBox1.MouseDown += new MouseEventHandler(Form1_MouseDown);
            pictureBox2.MouseDown += new MouseEventHandler(Form1_MouseDown);
            menuStrip1.MouseDown += new MouseEventHandler(Form1_MouseDown);
        }

        private void MakeProduct_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       private void button1_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            var dir = "C:\\Manager+\\" + name;  // folder location
            if (!Directory.Exists(dir))
            {                                       // if it doesn't exist, create
                Directory.CreateDirectory(dir);
            }
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Filter = "GIF files|*.gif";
            openFileDialog1.FileName = "Изберете файл";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sourceFile = openFileDialog1.FileName;
                string sourceFolder = Path.GetDirectoryName(sourceFile);
               
                string imagePath = (@"C:\Manager+\" + name + @"\" + name + ".gif");
                
                if (File.Exists(@"C:\Manager+\" + name + @"\" + name + ".gif"))
                {
                    File.Delete(@"C:\Manager+\" + name + @"\" + name + ".gif");
                }
                File.Copy(sourceFile, imagePath);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string barCode = textBox2.Text;
            string manufacture = textBox3.Text;
            string importer = textBox4.Text;
            string priceIN = textBox5.Text;
            string priceOUT = textBox6.Text;
            string VAT = textBox7.Text;

            var dir = "C:\\Manager+\\" + name;  // folder location
            if (!Directory.Exists(dir))
            {                                       // if it doesn't exist, create
                Directory.CreateDirectory(dir);
            }

            string path = dir + @"\" + name + ".txt";
            try
            {
                string amount = listBox1.SelectedItem.ToString();
                TextWriter tw = new StreamWriter(path, true);

                tw.WriteLine("Име : " + name);
                tw.WriteLine("Баркод : " + barCode);
                tw.WriteLine("Производител : " + manufacture);
                tw.WriteLine("Вносител : " + importer);
                tw.WriteLine("Доставна цена : " + priceIN);
                tw.WriteLine("Крайна цена : " + priceOUT);
                tw.WriteLine("ДДС : " + VAT);
                tw.WriteLine("Мярка : " + amount);
                tw.WriteLine("Произведено на : " + dateTimePicker1.Value);
                tw.WriteLine("Годно до : " + dateTimePicker2.Value);
                tw.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Изберете мярка.");
            }
            this.Close();
        }

    }
}
