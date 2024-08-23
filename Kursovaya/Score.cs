using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class Score : Form
    {

        RichTextBox rtb = new RichTextBox();
        
        public Score()
        {
            InitializeComponent();
            rtb.Dock = DockStyle.Fill;
            rtb.ReadOnly = true;
            Controls.Add(rtb);
            string s;
            var f = new StreamReader(@"..\..\1.txt");
            while ((s = f.ReadLine()) != null)
            {
                rtb.Text = rtb.Text + s + "\n";
            }
            f.Close();
        }

        private void Score_Load(object sender, EventArgs e)
        {

        }
    }
}
