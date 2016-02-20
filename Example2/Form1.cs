using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2
{
    public partial class Form1 : Form
    {
        GraphicsPath gp = new GraphicsPath();

        Rectangle r = new Rectangle(0, 0, 40, 40);
        Timer t = new Timer();
        public Form1()
        {
            InitializeComponent();
            t.Interval = 1000;
            t.Tick += v;
            t.Start();

            gp.AddLine(new PointF(0, 0), new PointF(19, 19));
            gp.AddLine(new PointF(10, 0), new PointF(19, 19));
            gp.AddLine(new PointF(0, 10), new PointF(19, 19));
            gp.AddLine(new PointF(20, 0), new PointF(19, 19));


        }

        int dx = 1;
        int dy = 1;

        int speed = 10;
        Matrix m = new Matrix();

        private void v(object sender, EventArgs e)
        {
            m.Translate(10, 10);


            gp.Transform(m);


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

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


            e.Graphics.DrawPath(new Pen(Color.Green), gp);

            e.Graphics.FillEllipse(new SolidBrush(Color.Red), r);
            e.Graphics.DrawRectangle(new Pen(Color.Green, 2), 0, 0, Width, Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
    }
}

