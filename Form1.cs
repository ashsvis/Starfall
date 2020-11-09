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

        void DrawStar(Graphics gr, int x, int y)
        {
            var star = new Star(x, y);
            star.Draw(gr);
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
