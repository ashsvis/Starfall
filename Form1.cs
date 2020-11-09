using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Random r;
        List<Star> stars;

        public Form1()
        {
            InitializeComponent();
            r = new Random();
            stars = new List<Star>();
 
            for (int i = 0; i < 15; i++)
            {
                var x = r.Next(pictureBox1.Width);
                var y = r.Next(pictureBox1.Height);
                stars.Add(new Star(x, y));
            }

            timer1.Enabled = true;
        }

        void DrawStar(Graphics gr, int x, int y)
        {
            var star = new Star(x, y);
            star.Draw(gr);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var star in stars)
                star.PutDown();
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            foreach (var star in stars)
                star.Draw(e.Graphics);
        }
    }
}
