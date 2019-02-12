using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFilterEffect
{
    class Spline
    {
        private List<Point> points;

        public Spline()
        {
            points = new List<Point>();
        }

        public void AddPoint(Point p)
        {
            points.Add(p);
        }

        public void AddPoints(List<Point> points)
        {
            this.points.AddRange(points);
        }

        public int Calculate(int x)
        {
            int result = -1;

            for (int i = 0; i < points.Count - 1; i++)
            {
                Point p1 = points.ElementAt(i);
                Point p2 = points.ElementAt(i + 1);

                if (x >= p1.X && x <= p2.X)
                {
                    result = (int)((float)(p1.Y - p2.Y) * (float)(x - p1.X) / (float)(p1.X - p2.X)) + p1.Y;
                    break;
                }
            }

            return result;
        }
    }
}
