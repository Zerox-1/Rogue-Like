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
    public partial class MapSize : Form
    {
        public int mp = 10;
        public MapSize()
        {
            InitializeComponent();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numericValue;
            if (radioButton4.Checked == true)
            {
                if (!int.TryParse(textBox1.Text, out numericValue))
                { MessageBox.Show("Сначала введите число", "Сообщение", MessageBoxButtons.OK);
                }
                else if (Convert.ToInt16(textBox1.Text) > 15)
                {
                    MessageBox.Show("Карта не может быть больше 15!", "Сообщение", MessageBoxButtons.OK);
                }
                else if (Convert.ToInt16(textBox1.Text) < 6)
                {
                    MessageBox.Show("Карта не может быть меньше 6!", "Сообщение", MessageBoxButtons.OK);
                }
                else
                {
                    mp = Convert.ToInt16(textBox1.Text);
                    Close();
                }
            }
            else if (radioButton1.Checked == true)
            {
                mp = 10;
                Close();
            }
            else if (radioButton2.Checked == true)
            {
                mp = 11;
                Close();
            }
            else if (radioButton3.Checked == true)
            {
                mp = 12;
                Close();
            }
        }

        private void MapSize_Load(object sender, EventArgs e)
        {

        }
    }
}
