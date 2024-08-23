using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class Start : Form
    {
        public int mp=10;
        public Start()
        {
            var prev=new Prestart();
            prev.ShowDialog();
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        public Start(int a)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var form1 = new Form1(mp);
            form1.ShowDialog();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var next = new Score();
            next.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var next = new Music();
            next.Size=new Size(500,500);
            next.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var next=new MapSize();
            next.ShowDialog();
            mp = next.mp;
        }
    }
}
