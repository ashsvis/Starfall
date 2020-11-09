using System;
using System.Drawing;
using System.Linq;

namespace WindowsFormsApp1
{
    public class Star
    {
        private readonly PointF[] points;

        public Star(int x, int y)
        {
            int n = 5;
            double alpha = 0;
            double a = alpha, da = Math.PI / n, l;
            double R = 10, r = 5;
            points = new PointF[2 * n + 1];
            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(x + l * Math.Cos(a)), (float)(y + l * Math.Sin(a)));
                a += da;
            }
        }

        public PointF Location 
        {
            get { return new PointF(points.Min(p => p.X), points.Min(p => p.Y)); }
        }

        public void Draw(Graphics gr)
        {
            gr.DrawLines(Pens.White, points);
        }

        public void PutDown()
        {
            for (var i = 0; i < points.Length; i++)
                points[i].Y += 1;
        }
    }
}
