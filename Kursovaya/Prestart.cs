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
    public partial class Prestart : Form
    {
        public Prestart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true && checkBox2.Checked==true && checkBox3.Checked == true)
            {
                Close();
            }
            else
            {
                MessageBox.Show("Вы должны подтвердить все 3 пункта!", "Сообщение", MessageBoxButtons.OK);
            }
        }

        private void Prestart_Load(object sender, EventArgs e)
        {
            
        }
    }
}
