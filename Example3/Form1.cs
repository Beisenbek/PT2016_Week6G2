using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example3
{
    public partial class Form1 : Form
    {
        Rectangle r = new Rectangle(0, 0, 40, 40);

        Graphics g;
        Bitmap bmp;
        int dx = 1;
        int dy = 1;

        int speed = 1;


        Timer t = new Timer();

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
          
            t.Tick += T_Tick;
            t.Interval = 10;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (r.X + dx * speed + r.Width > Width)
            {
                dx = -1;
            }
            if (r.Y + dy * speed + r.Height > Height)
            {
                dy = -1;
            }

            if (r.X + dx * speed < 0)
            {
                dx = 1;
            }
            if (r.Y + dy * speed < 0)
            {
                dy = 1;
            }

            r.X += dx * speed;
            r.Y += dy * speed;


            g.Clear(Color.White);
            g.FillEllipse(new SolidBrush(Color.Red), r);

            pictureBox1.Image = bmp;
        }
    }
}
