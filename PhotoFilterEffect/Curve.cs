using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFilterEffect
{
    public class Curve
    {
        public enum Channel
        {
            Red, Green, Blue, RGB
        };

        public Channel channel;
        public List<Point> points;
        
        public Curve(Channel ch)
        {
            this.channel = ch;
            this.points = new List<Point>();
        }

        public void AddPoint(Point pt)
        {
            this.points.Add(pt);
        }

        public void AddPoints(List<Point> pts)
        {
            this.points.AddRange(pts);
        }

        public void ParsePoints(String text)
        {
            String[] pts = text.Trim().Split(' ');
            if (pts.Length > 0)
            {
                foreach (var pt in pts)
                {
                    String[] value = pt.Split(':');
                    if (value.Length == 2)
                    {
                        int input = Int32.Parse(value[0]);
                        int output = Int32.Parse(value[1]);
                        Point p = new Point(input, output);
                        this.AddPoint(p);
                    }
                }
            }
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
