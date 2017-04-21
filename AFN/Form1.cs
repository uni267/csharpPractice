using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
        }

        private KeyStateHelper _keyHelper = new KeyStateHelper();

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            _keyHelper.RegisterPressedKey(e.KeyCode);
            // CTRL + SHIFT + A + B + C判定
            if (!e.Control || !e.Shift) return;
            // A,B,C同時押し判定
            if (_keyHelper.IsPressedKey(new Keys[] { Keys.A, Keys.B, Keys.C }))
            {
                _keyHelper.ClearPressedKey();
                Console.WriteLine("pressed");
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _keyHelper.UnregisterPressedKey(e.KeyCode);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _keyHelper.RegisterPressedKey(e.KeyCode);

            //受け取ったキーを表示する
            //Console.WriteLine(e.KeyCode);
            int speed=5;
            int x = this.pictureBox1.Location.X;
            int y = this.pictureBox1.Location.Y;
            /*
           switch (e.KeyCode){
               case  System.Windows.Forms.Keys.Right :
                   this.pictureBox1.Location = new Point(nowx + speed, nowy);
                   break;
               case System.Windows.Forms.Keys.Left:
                   this.pictureBox1.Location = new Point(nowx - speed, nowy);
                   break;
               case System.Windows.Forms.Keys.Up:
                   this.pictureBox1.Location = new Point(nowx, nowy - speed);
                   break;
               case System.Windows.Forms.Keys.Down:
                   this.pictureBox1.Location = new Point(nowx, nowy + speed);
                   break;
               default:
                   break;

           }
           */
            if (_keyHelper.IsPressedKey(Keys.Right)||_keyHelper.IsPressedKey(Keys.D))
                x += speed;
            if (_keyHelper.IsPressedKey(Keys.Left) || _keyHelper.IsPressedKey(Keys.A))
                x -= speed;
            if (_keyHelper.IsPressedKey(Keys.Up) || _keyHelper.IsPressedKey(Keys.W))
                y -= speed;
            if (_keyHelper.IsPressedKey(Keys.Down) || _keyHelper.IsPressedKey(Keys.S))
                y += speed;
    
            this.pictureBox1.Location = new Point(x, y);

        }
    }
}