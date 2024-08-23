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
    public partial class Dif : Form
    {
        public int diff=1;
        public int mp;
        public Dif()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            diff = 1;
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            diff = 2;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            diff = 3;
            Close();
        }

        private void Dif_Load(object sender, EventArgs e)
        {

        }
    }
}
