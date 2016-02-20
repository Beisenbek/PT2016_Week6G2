using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        Point p1 = new Point(0,0);
        Point p2 = new Point(10,10);
        public Form1()
        {
            InitializeComponent();
            t.Interval = 1000;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            //   this.Text = DateTime.Now.ToString("HH:mm:ss:fff");
            p1.X += 10;
            p1.Y += 3;
            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Red), p1, p2);
            e.Graphics.FillRectangle(new SolidBrush(Color.Green), 20, 20, 40, 40);
        }
    }
}
