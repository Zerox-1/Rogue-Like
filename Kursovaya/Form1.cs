using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.IO;

namespace Kursovaya
{
    public partial class Form1 : Form
    {
        private string Player;
        private PictureBox money = new PictureBox();
        private PictureBox player = new PictureBox();
        private PictureBox enemy = new PictureBox();
        private PictureBox hurt=new PictureBox();
        private int Hurtcount=0;
        private int enemycount = 0; 
        private Label labelScore;
        private Label labelHp;
        private int dirX, dirY;
        private int _w=10;
        private int _h=10;
        private int _sizeOfSides = 40;
        public int score = 0;
        private int mhp=5;
        private int hp=5;
        public Form1()
        {
            _StartGame();
        }
        public Form1(int a)
        {
            _w = _h = a;
            _StartGame();
        }

        private void _StartGame()
        {
            InitializeComponent();
            _choiseDif();
            _getName();
            this.Text = Player;
            this.Width = _w*_sizeOfSides+150;
            this.Height = _h*(_sizeOfSides+1)+28;
            dirX = 1;
            dirY = 0;
            labelScore = new Label();
            labelScore.Text = "Score: 0";
            labelScore.Location = new Point(_w * _sizeOfSides + 10, 10);
            labelHp = new Label();
            labelHp.Text = "Hp: " + hp;
            labelHp.Location = new Point(_w * _sizeOfSides + 10, 50);
            this.Controls.Add(labelScore);
            this.Controls.Add(labelHp);
            player.Image = Properties.Resources.gg1;
            player.Location = new Point(200, 200);
            player.Size = new Size(_sizeOfSides - 1, _sizeOfSides - 1);
            player.BackColor = Color.Red;
            this.Controls.Add(player);
            money.Image = Properties.Resources.monei;
            money.BackColor = Color.Yellow;
            money.Size = new Size(_sizeOfSides, _sizeOfSides);
            enemy.Image = Properties.Resources.enemy;
            enemy.Size = new Size(_sizeOfSides, _sizeOfSides);
            hurt.Image = Properties.Resources.hurt;
            hurt.Size = new Size(_sizeOfSides, _sizeOfSides);
            _createMap();
            _generateMoney();
            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(OKP);
        }
        private void _CheckScore()
        {
            List<Tuple<string, int>> a = new List<Tuple<string, int>>();
            string s;
            var f = new StreamReader(@"..\..\1.txt");
            while ((s = f.ReadLine()) != null)
            {
                string[] b = s.Split(Convert.ToChar(" "));
                a.Add(Tuple.Create(b[0], Convert.ToInt32(b[1])));
            }
            f.Close();
            var NEW = new List<Tuple<string, int>>();
            NEW.Add(Tuple.Create(Player, score));
            if (a.Count == 0) { a.Add(Tuple.Create(NEW[0].Item1, NEW[0].Item2)); }
            else if (NEW[0].Item2 > a.Last().Item2 || NEW[0].Item2 >= a.Last().Item2 && a.Count <= 4)
            {
                for (int i = a.Count - 1; i >= 0; i--)
                {
                    if (NEW[0].Item1.ToString() == a[i].Item1.ToString())
                    {
                        if (NEW[0].Item2 > a[i].Item2)
                        {
                            a.Remove(a[i]);
                            break;
                        }
                        else
                        {
                            NEW = new List<Tuple<string, int>>();
                            NEW.Add(Tuple.Create(Player, 0));
                            break;
                        }
                    }
                }
                for (int i = a.Count - 1; i >= 0; i--)
                {
                    if (NEW[0].Item2 >= a[i].Item2)
                    {
                        if (i > 0 && NEW[0].Item2 <= a[i - 1].Item2)
                        {
                            a.Insert(i, Tuple.Create(NEW[0].Item1, NEW[0].Item2));
                            if (a.Count > 5)
                            {
                                a.Remove(a.Last());
                            }
                            break;
                        }
                        else if (i == 0)
                        {
                            a.Insert(i, Tuple.Create(NEW[0].Item1, NEW[0].Item2));
                            if (a.Count > 5)
                            {
                                a.Remove(a.Last());
                            }
                            break;
                        }
                    }
                }

            }
            var help = new FileStream(@"..\..\1.txt", FileMode.OpenOrCreate);
            var f1 = new StreamWriter(help);
            for (int i = 0; i < a.Count; i++)
            {
                f1.WriteLine(a[i].Item1 + " " + a[i].Item2.ToString());
            }
            f1.Close();
            help.Close();
        }
        private void _choiseDif()
        {
            var Dif = new Dif();
            Dif.Size=new Size(275,200);
            Dif.ShowDialog();
            int diff = Dif.diff;
            if (diff == 1)
            {
                mhp = hp = 5;
            }
            else if(diff==2) {
                mhp = hp = 3;
            }
            else if(diff==3)
            {
                mhp = hp = 1;
            }
        }
        private void _getName()
        {
            var PName=new PName();
            PName.Size = new Size(280, 150);
            PName.ShowDialog();
            Player=PName.Name;
        }
        private void _hurtSpavn()
        {
            Random rn = new Random();
            if (hp <mhp && Hurtcount==0)
            {
                int z = rn.Next(0,10);
                if (z == 0)
                {
                    Hurtcount++;
                    int x = rn.Next(1, 9);
                    int y = rn.Next(1, 9);
                    hurt.Location = new Point(x * _sizeOfSides, y * _sizeOfSides);
                    this.Controls.Add(hurt);
                    hurt.BringToFront();
                }
            }
        }
        private void _checkHurt()
        {
            if (player.Location.X == hurt.Location.X && player.Location.Y == hurt.Location.Y)
            {
                hp++;
                labelHp.Text = "Hp: " + hp;
                hurt.Location = new Point(-40, -40);
                this.Controls.Remove(hurt);
                Hurtcount--;
            }
        }
        private void _enemyMove()
        {
            if (enemycount >= 1)
            {
                if (Math.Abs(player.Location.X - enemy.Location.X) < Math.Abs(player.Location.Y - enemy.Location.Y))
                {
                    if (player.Location.Y - enemy.Location.Y < -_sizeOfSides)
                    {
                        enemy.Location = new Point(enemy.Location.X, enemy.Location.Y - _sizeOfSides);
                    }
                    else if (player.Location.Y - enemy.Location.Y > _sizeOfSides)
                    {
                        enemy.Location = new Point(enemy.Location.X, enemy.Location.Y + _sizeOfSides);
                    }
                }
                else
                {
                    if (player.Location.X - enemy.Location.X < -_sizeOfSides)
                    {
                        enemy.Location = new Point(enemy.Location.X - _sizeOfSides, enemy.Location.Y);
                    }
                    else if (player.Location.X - enemy.Location.X > _sizeOfSides)
                    {
                        enemy.Location = new Point(enemy.Location.X + _sizeOfSides, enemy.Location.Y);
                    }
                }
            }
        }
        private void _enemySpawn()
        {
            Random r = new Random();
            int x = r.Next(1, 9);
            int y = r.Next(1, 9);
            enemy.Location = new Point(x * _sizeOfSides, y * _sizeOfSides);
            if (score > 4) { enemycount++; this.Controls.Add(enemy); }
            enemy.BringToFront();
        }
        private void _chekEnemy()
        {
            if (enemycount >= 1)
            {
                if (player.Location.X == enemy.Location.X && player.Location.Y == enemy.Location.Y)
                {
                    string attack = "Вы атакованны!Вы одолели противника!";
                    string attack1 = "Вы атакованны!Вас одолел противник!";
                    Random random = new Random();
                    int x = random.Next(1, 10);
                    enemy.Location = new Point(_w * (_sizeOfSides + 1), _h * (_sizeOfSides + 1));
                    this.Controls.Remove(enemy);
                    if (x != 1)
                    {
                        if (hp > 1)
                        {
                            hp--;
                            labelHp.Text = "Hp: " + hp;
                            score = 0;
                            labelScore.Text = "Score: " + score;
                        }
                        else
                        {
                            hp--;
                            labelHp.Text = "Hp: " + hp;
                            labelScore.Text = "Score: 0";
                        }

                        MessageBox.Show(attack1);
                    }
                    else
                    {
                        MessageBox.Show(attack);
                    }
                    enemycount--;
                }
            }

        }
        private void _generateMoney()
        {
            if (hp > 0)
            {
                Random r = new Random();
                int x = r.Next(1, 9);
                int y = r.Next(1, 9);
                money.Location = new Point(x * _sizeOfSides, y * _sizeOfSides);
                this.Controls.Add(money);
                money.BringToFront();
            }
        }
        private void _chekHp()
        {
            if (hp == 0)
            { 
                player.Location = new Point(4000, 4000);
            }
        }
        private void _checkBorders()
        {
            if (player.Location.X < _sizeOfSides)
            {
                player.Location=new Point(player.Location.X+ _sizeOfSides, player.Location.Y);
                dirX = 1;
            }
            if (player.Location.X >= _w* _sizeOfSides - _sizeOfSides)
            {
                player.Location = new Point(player.Location.X - _sizeOfSides, player.Location.Y);
                dirX = -1;
            }
            if (player.Location.Y < _sizeOfSides)
            {
                player.Location = new Point(player.Location.X, player.Location.Y + _sizeOfSides);
                dirY = 1;
            }
            if (player.Location.Y >= _h* _sizeOfSides - _sizeOfSides)
            {
                player.Location = new Point(player.Location.X , player.Location.Y- _sizeOfSides);
                dirY = -1;
            }
        }
        private void _pickMoney()
        {
            if (player.Location == money.Location)
            {
                score++;
                labelScore.Text = "Score: " +score;
                
                _generateMoney();
            }
        }
        private void _createMap()
        {
            for(int i = 0; i < _w; i++)
            {
                for(int j=0; j < _h; j++)
                {
                    if (i==0 || j == 0 || i==_w-1 ||j==_h-1)
                    {
                        PictureBox pic = new PictureBox();
                        pic.Image = Properties.Resources.wall;
                        pic.Location = new Point(_sizeOfSides * i, _sizeOfSides * j);
                        pic.Size = new Size(_sizeOfSides, _sizeOfSides);
                        this.Controls.Add(pic);
                    }
                    else if(money.Location.X!=i* _sizeOfSides && money.Location.Y!=j* _sizeOfSides)
                    {
                        PictureBox pic = new PictureBox();
                        pic.Image = Properties.Resources.pool;
                        pic.Location = new Point(_sizeOfSides * i, _sizeOfSides * j);
                        pic.Size = new Size(_sizeOfSides, _sizeOfSides);
                        this.Controls.Add(pic);
                    }
                }
            }
            _generateMoney();
        }
        private void _moveWarrior()
        {
            player.Location = new Point(player.Location.X + dirX * (_sizeOfSides), player.Location.Y + dirY * (_sizeOfSides));
            Random r = new Random();
            int z = r.Next(0, 11);
            if (z < 5 && enemycount ==0)
            {
                _enemySpawn();
            }
        }
        private void _checkHP()
        {
            if (hp==0)
            {
                Hide();
                _CheckScore();
                var tp = new End();
                tp.ShowDialog();
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void _update(Object myObject, EventArgs eventsArgs)
        {
            
            //cube.Location = new Point(cube.Location.X + dirX * _sizeOfSides, cube.Location.Y + dirY * _sizeOfSides);
        }
        private void OKP(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "D":
                    dirX = 1;
                    dirY = 0;
                    player.Image = Properties.Resources.gg1;
                    break;
                case "A":
                    dirX = -1;
                    dirY = 0;
                    player.Image = Properties.Resources.gg1_left;
                    break;
                case "W":
                    dirY = -1;
                    dirX = 0;
                    player.Image = Properties.Resources.gg1_up;
                    break;
                case "S":
                    dirY = 1;
                    dirX = 0;
                    player.Image = Properties.Resources.gg1_down;
                    break;
            }
            _chekHp();
            _moveWarrior();
            _enemyMove();
            _hurtSpavn();
            _chekEnemy();
            _pickMoney();
            _checkHurt();
            _checkBorders();
            _checkHP();
        }
    }
}