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
    public partial class Music : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public Music()
        {
            InitializeComponent();
        }

        private void Music_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "ms1.wav";
            player.PlayLooping();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "ms2.wav";
            player.PlayLooping();
        }
    }
}
