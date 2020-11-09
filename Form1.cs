using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            // добавляем первые 15 звёзд
            for (int i = 0; i < 15; i++)
                AddNewStar();

            timer1.Enabled = true;
        }

        private void AddNewStar()
        {
            var x = r.Next(pictureBox1.Width);
            var y = r.Next(pictureBox1.Height);
            stars.Add(new Star(x, y));
        }

        void DrawStar(Graphics gr, int x, int y)
        {
            var star = new Star(x, y);
            star.Draw(gr);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // смещение всех звёзд вниз
            foreach (var star in stars)
                star.PutDown();
            // проверяем, может кого уже не видно
            var outstars = stars.Where(item => item.Location.Y > pictureBox1.Height).ToList();
            // вышедшие из видимости удаляем из списка звёзд
            foreach (var star in outstars)
                stars.Remove(star);
            // восполняем пропавшие звёзды новыми
            for (var i = 0; i < outstars.Count; i++)
                AddNewStar();

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
