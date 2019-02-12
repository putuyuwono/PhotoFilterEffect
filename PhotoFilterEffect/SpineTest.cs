using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoFilterEffect
{
    public partial class SpineTest : Form
    {
        private List<Point> originalPoints;

        private List<Point> blueChannel;
        private List<Point> greenChannel;
        private List<Point> redChannel;

        private List<Point> modBluePoints;
        private List<Point> modGreenPoints;
        private List<Point> modRedPoints;

        private Spline blueSpline;
        private Spline greenSpline;
        private Spline redSpline;

        private List<Point> blueDots;
        private List<Point> greenDots;
        private List<Point> redDots;

        public SpineTest()
        {
            InitializeComponent();

            InitPoints();
        }

        private void InitPoints()
        {
            originalPoints = new List<Point>();
            for (int i = 0; i < 255; i++)
            {
                originalPoints.Add(new Point(i * 2, i * 2));
            }

            blueChannel = new List<Point>();
            blueChannel.Add(new Point(0,43));
            blueChannel.Add(new Point(28,51));
            blueChannel.Add(new Point(56,85));
            blueChannel.Add(new Point(85,122));
            blueChannel.Add(new Point(113,159));
            blueChannel.Add(new Point(141,184));
            blueChannel.Add(new Point(170,197));
            blueChannel.Add(new Point(198,203));
            blueChannel.Add(new Point(227,208));
            blueChannel.Add(new Point(255,213));

            modBluePoints = new List<Point>();
            foreach (var p in blueChannel)
            {
                modBluePoints.Add(new Point(p.X * 2, p.Y * 2));
            }

            greenChannel = new List<Point>();
            greenChannel.Add(new Point(0, 42));
            greenChannel.Add(new Point(28, 47));
            greenChannel.Add(new Point(56, 76));
            greenChannel.Add(new Point(85, 121));
            greenChannel.Add(new Point(113, 155));
            greenChannel.Add(new Point(141, 176));
            greenChannel.Add(new Point(170, 191));
            greenChannel.Add(new Point(198, 201));
            greenChannel.Add(new Point(227, 207));
            greenChannel.Add(new Point(255, 214));

            modGreenPoints = new List<Point>();
            foreach (var p in greenChannel)
            {
                modGreenPoints.Add(new Point(p.X * 2, p.Y * 2));
            }


            redChannel = new List<Point>();
            redChannel.Add(new Point(0, 41));
            redChannel.Add(new Point(28, 56));
            redChannel.Add(new Point(56, 82));
            redChannel.Add(new Point(85, 115));
            redChannel.Add(new Point(114, 151));
            redChannel.Add(new Point(170, 193));
            redChannel.Add(new Point(198, 205));
            redChannel.Add(new Point(227, 211));
            redChannel.Add(new Point(255, 220));

            modRedPoints = new List<Point>();
            foreach (var p in redChannel)
            {
                modRedPoints.Add(new Point(p.X * 2, p.Y * 2));
            }

            blueSpline = new Spline();
            blueSpline.AddPoints(blueChannel);
            blueDots = new List<Point>();

            for (int i = 0; i < 256; i++)
            {
                int j = blueSpline.Calculate(i);
                blueDots.Add(new Point(i * 2, j * 2));
            }

            greenSpline = new Spline();
            greenSpline.AddPoints(greenChannel);
            greenDots = new List<Point>();

            for (int i = 0; i < 256; i++)
            {
                int j = greenSpline.Calculate(i);
                greenDots.Add(new Point(i * 2, j * 2));
            }

            redSpline = new Spline();
            redSpline.AddPoints(redChannel);
            redDots = new List<Point>();

            for (int i = 0; i < 256; i++)
            {
                int j = redSpline.Calculate(i);
                redDots.Add(new Point(i * 2, j * 2));
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            int rectSize = 2;
            Point czero = new Point(0, 0);            
            Point xaxis = new Point(510, 0);
            Point yaxis = new Point(0, 510);
            Point cmaxz = new Point(510, 510);
            using (Pen blackPen = new Pen(Color.Black))
            using (Pen yellowPen = new Pen(Color.YellowGreen))
            using (Pen bluePen = new Pen(Color.Blue))
            using (Pen greenPen = new Pen(Color.Green))
            using (Pen redPen = new Pen(Color.Red))
            using (Brush redBrush = new SolidBrush(Color.Red))
            using (Brush greenBrush = new SolidBrush(Color.Green))
            using (Brush blueBrush = new SolidBrush(Color.Blue))
            using (Graphics g = e.Graphics)
            {
                //Draw x-axis y-axis
                g.DrawLine(blackPen, czero, xaxis);
                g.DrawLine(blackPen, czero, yaxis);
                g.DrawLine(blackPen, xaxis, cmaxz);
                g.DrawLine(blackPen, yaxis, cmaxz);

                g.DrawCurve(yellowPen, originalPoints.ToArray());

                g.DrawCurve(bluePen, modBluePoints.ToArray());
                g.DrawCurve(greenPen, modGreenPoints.ToArray());
                g.DrawCurve(redPen, modRedPoints.ToArray());

                foreach (var point in blueDots)
                {
                    g.FillRectangle(blueBrush, point.X - rectSize / 2, point.Y - rectSize/2, rectSize, rectSize);
                }

                foreach (var point in greenDots)
                {
                    g.FillRectangle(greenBrush, point.X - rectSize / 2, point.Y - rectSize / 2, rectSize, rectSize);
                }

                foreach (var point in redDots)
                {
                    g.FillRectangle(redBrush, point.X - rectSize / 2, point.Y - rectSize / 2, rectSize, rectSize);
                }
            }
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            //inputPoints.Add(e.Location);
            //canvas.Refresh();
        }

    }
}
