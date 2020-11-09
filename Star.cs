using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Star
    {
        private readonly PointF[] points;

        public Star(int x, int y)
        {
            Location = new Point(x, y);

            int n = 5;
            double alpha = 0;
            double a = alpha, da = Math.PI / n, l;
            double R = 10, r = 5;
            points = new PointF[2 * n + 1];
            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(Location.X + l * Math.Cos(a)), (float)(Location.Y + l * Math.Sin(a)));
                a += da;
            }
        }

        public Point Location { get; set; }

        public void Draw(Graphics gr)
        {
            gr.DrawLines(Pens.White, points);
        }
    }
}
