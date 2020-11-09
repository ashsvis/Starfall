using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Random r;

        public Form1()
        {
            InitializeComponent();
            r = new Random();
            timer1.Enabled = true;
        }

        void DrawStar(Graphics gr, double x, double y)
        {
            int n = 5;
            double R = 10, r = 5;
            double alpha = 0;

            PointF[] points = new PointF[2 * n + 1];
            double a = alpha, da = Math.PI / n, l;
            
            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(x + l * Math.Cos(a)), (float)(y + l * Math.Sin(a)));
                a += da;
            }
            gr.DrawLines(Pens.White, points);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);

            int x, y;
            for (int i = 0; i < 15; i++)
            {
                x = r.Next(pictureBox1.Width);
                y = r.Next(pictureBox1.Height);
                DrawStar(e.Graphics, x, y);
            }

        }
    }
}
