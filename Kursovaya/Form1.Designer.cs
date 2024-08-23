using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Kursovaya
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ScoreB=new Button();
            this.ScoreB.Location = new System.Drawing.Point(_w * _sizeOfSides + 10, 90);
            this.ScoreB.Name = "ScoreB";
            this.ScoreB.Size = new System.Drawing.Size(113, 74);
            this.ScoreB.TabIndex = 0;
            this.ScoreB.Text = "Очки";
            this.ScoreB.UseVisualStyleBackColor = true;
            this.ScoreB.Click += new System.EventHandler(this.ScoreB_Click);

            this.MusicB = new Button();
            this.MusicB.Location = new System.Drawing.Point(_w * _sizeOfSides + 10, 170);
            this.MusicB.Name = "MusicB";
            this.MusicB.Size = new System.Drawing.Size(113, 74);
            this.MusicB.TabIndex = 0;
            this.MusicB.Text = "Музыка";
            this.MusicB.UseVisualStyleBackColor = true;
            this.MusicB.Click += new System.EventHandler(this.MusicB_Click);

            this.StartPosition= FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.Controls.Add(this.ScoreB);
            this.Controls.Add(this.MusicB);
            this.ResumeLayout(false);

        }

        private void MusicB_Click(object sender, EventArgs e)
        {
            var Mus=new Music();
            Mus.ShowDialog();
        }
        private void ScoreB_Click(object sender, EventArgs e)
        { 
            Form SpScore = new Form();
            SpScore.Text = "Score Table";
            SpScore.Size = new Size(300, 200);
            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;
            rtb.ReadOnly = true;
            SpScore.Controls.Add(rtb);
            string s;
            StreamReader f;
            if (File.Exists(@"..\..\1.txt"))
            {
                f = new StreamReader(@"..\..\1.txt");
            }
            else
            {
                var tmp=File.Create(@"..\..\1.txt");
                tmp.Close();
                f = new StreamReader(@"..\..\1.txt");
            }
            while ((s = f.ReadLine()) != null)
            {
                rtb.Text = rtb.Text + s + "\n";
            }
            SpScore.StartPosition = FormStartPosition.CenterScreen;
            SpScore.Show();
            f.Close();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Button ScoreB;
        private Button MusicB;
    }
}

