using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Emgu.CV.Util;

namespace PhotoFilterEffect
{
    public partial class MainForm : Form
    {
        private Bitmap originalPicture;
        
        private List<Point> blueChannel;
        private List<Point> greenChannel;
        private List<Point> redChannel;

        private Spline blueSpline;
        private Spline greenSpline;
        private Spline redSpline;

        private List<Point> blueDots;
        private List<Point> greenDots;
        private List<Point> redDots;

        public MainForm()
        {
            InitializeComponent();
            InitLoadPicture();
        }

        private void InitLoadPicture()
        {
            originalPicture = new Bitmap("munich.jpg");
            originalPictureBox.Image = originalPicture;
        }

        private Bitmap EffectBW(Bitmap originalBmp)
        {
            Image<Gray, Byte> grayImg = new Image<Gray, byte>(originalBmp);

            Bitmap result = new Bitmap(grayImg.Bitmap);

            grayImg.Dispose();

            return result;
        }

        private Bitmap EffectEqHist(Bitmap originalBmp)
        {
            Image<Bgr, Byte> originalImg = new Image<Bgr, byte>(originalBmp);

            originalImg._EqualizeHist();

            Bitmap result = new Bitmap(originalImg.Bitmap);

            originalImg.Dispose();

            return result;
        }

        private Bitmap EffectCanny(Bitmap originalBmp)
        {
            Image<Gray, Byte> grayImg = new Image<Gray, byte>(originalBmp);

            Image<Gray, Byte> cannyImg = grayImg.Canny(150, 150);

            Bitmap result = new Bitmap(cannyImg.Bitmap);

            grayImg.Dispose();
            cannyImg.Dispose();

            return result;
        }

        private Bitmap EffectHSV(Bitmap originalBmp)
        {
            Image<Hsv, Byte> hsvImg = new Image<Hsv, byte>(originalBmp);

            Bitmap result = new Bitmap(hsvImg.Bitmap);

            hsvImg.Dispose();

            return result;
        }

        private Bitmap ChangeHSV(Bitmap originalBmp)
        {
            int h = trackBarH.Value, s = trackBarS.Value, v = trackBarV.Value;
            int mh = 180, ms = 256, mv = 256;

            Image<Hsv, Byte> hsvImg = new Image<Hsv, byte>(originalBmp);
            byte[, ,] data = hsvImg.Data;

            for (int i = 0; i < hsvImg.Rows; i++)
            {
                for (int j = 0; j < hsvImg.Cols; j++)
                {
                    int ch = (int)(data[i, j, 0] + h);
                    int cs = (int)(data[i, j, 1] + s);
                    int cv = (int)(data[i, j, 2] + v);

                    if (ch > mh) ch = ch % mh;
                    if (ch < 0) ch = 1;

                    if (cs > ms) cs = cs % ms;
                    if (cs < 0) cs = 1;
                    
                    if (cv > mv) cv = cv % mv;
                    if (cv < 0) cv = 1;

                    data[i, j, 0] = (byte)ch;
                    data[i, j, 1] = (byte)cs;
                    data[i, j, 2] = (byte)cv;
                }
            }

            Bitmap result = new Bitmap(hsvImg.Bitmap);

            hsvImg.Dispose();

            return result;
        }
                
        private Bitmap EffectGingham(Bitmap originalBmp)
        {
            Image<Bgr, Byte> originalImg = new Image<Bgr, byte>(originalBmp);

            Mat resultMat = new Mat(originalImg.Rows, originalImg.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 3);
            
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var channels = originalImg.Split();

            Matrix<byte> bLUT = new Matrix<byte>(1, 256, 1);
            Matrix<byte> gLUT = new Matrix<byte>(1, 256, 1);
            Matrix<byte> rLUT = new Matrix<byte>(1, 256, 1);

            #region Color Curves
            blueChannel = new List<Point>();
            blueChannel.Add(new Point(0, 43));
            blueChannel.Add(new Point(28, 51));
            blueChannel.Add(new Point(56, 85));
            blueChannel.Add(new Point(85, 122));
            blueChannel.Add(new Point(113, 159));
            blueChannel.Add(new Point(141, 184));
            blueChannel.Add(new Point(170, 197));
            blueChannel.Add(new Point(198, 203));
            blueChannel.Add(new Point(227, 208));
            blueChannel.Add(new Point(255, 213));

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

            blueSpline = new Spline();
            blueSpline.AddPoints(blueChannel);

            greenSpline = new Spline();
            greenSpline.AddPoints(greenChannel);

            redSpline = new Spline();
            redSpline.AddPoints(redChannel);
            #endregion
            
            for (int i = 0; i < 256; i++)
            {
                bLUT[0, i] = (byte)blueSpline.Calculate(i);
                gLUT[0, i] = (byte)greenSpline.Calculate(i);
                rLUT[0, i] = (byte)redSpline.Calculate(i);
            }

            CvInvoke.LUT(channels[0], bLUT, channels[0]);
            CvInvoke.LUT(channels[1], gLUT, channels[1]);
            CvInvoke.LUT(channels[2], rLUT, channels[2]);

            VectorOfMat vm = new VectorOfMat();
            vm.Push(channels[0].Mat);
            vm.Push(channels[1].Mat);
            vm.Push(channels[2].Mat);

            CvInvoke.Merge(vm, resultMat);

            stopwatch.Stop();

            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";

            Bitmap result = new Bitmap(resultMat.ToImage<Bgr, Byte>().Bitmap);

            originalImg.Dispose();

            return result;
        }
        
        private Bitmap EffectClarendon(Bitmap originalBmp)
        {
            Image<Bgr, Byte> originalImg = new Image<Bgr, byte>(originalBmp);

            Mat resultMat = new Mat(originalImg.Rows, originalImg.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 3);
            
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var channels = originalImg.Split();

            Matrix<byte> bLUT = new Matrix<byte>(1, 256, 1);
            Matrix<byte> gLUT = new Matrix<byte>(1, 256, 1);
            Matrix<byte> rLUT = new Matrix<byte>(1, 256, 1);

            #region Color Curves
            blueChannel = new List<Point>();
            blueChannel.Add(new Point(0, 0));
            blueChannel.Add(new Point(28, 38));
            blueChannel.Add(new Point(56, 66));
            blueChannel.Add(new Point(85, 104));
            blueChannel.Add(new Point(113, 139));
            blueChannel.Add(new Point(141, 175));
            blueChannel.Add(new Point(170, 206));
            blueChannel.Add(new Point(198, 226));
            blueChannel.Add(new Point(255, 255));

            blueSpline = new Spline();
            blueSpline.AddPoints(blueChannel);
            
            greenChannel = new List<Point>();
            greenChannel.Add(new Point(0, 0));
            greenChannel.Add(new Point(28, 24));
            greenChannel.Add(new Point(56, 49));
            greenChannel.Add(new Point(85, 98));
            greenChannel.Add(new Point(113, 141));
            greenChannel.Add(new Point(141, 174));
            greenChannel.Add(new Point(170, 201));
            greenChannel.Add(new Point(198, 223));
            greenChannel.Add(new Point(227, 239));
            greenChannel.Add(new Point(255, 255));

            greenSpline = new Spline();
            greenSpline.AddPoints(greenChannel);
            
            redChannel = new List<Point>();
            redChannel.Add(new Point(0, 0));
            redChannel.Add(new Point(28, 16));
            redChannel.Add(new Point(56, 35));
            redChannel.Add(new Point(85, 64));
            redChannel.Add(new Point(113, 117));
            redChannel.Add(new Point(141, 163));
            redChannel.Add(new Point(170, 200));
            redChannel.Add(new Point(198, 222));
            redChannel.Add(new Point(227, 237));
            redChannel.Add(new Point(255, 249));

            redSpline = new Spline();
            redSpline.AddPoints(redChannel);

            #endregion

            for (int i = 0; i < 256; i++)
            {
                bLUT[0, i] = (byte)blueSpline.Calculate(i);
                gLUT[0, i] = (byte)greenSpline.Calculate(i);
                rLUT[0, i] = (byte)redSpline.Calculate(i);
            }

            CvInvoke.LUT(channels[0], bLUT, channels[0]);
            CvInvoke.LUT(channels[1], gLUT, channels[1]);
            CvInvoke.LUT(channels[2], rLUT, channels[2]);

            VectorOfMat vm = new VectorOfMat();
            vm.Push(channels[0].Mat);
            vm.Push(channels[1].Mat);
            vm.Push(channels[2].Mat);

            CvInvoke.Merge(vm, resultMat); 
            
            stopwatch.Stop();

            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";

            Bitmap result = new Bitmap(resultMat.ToImage<Bgr, Byte>().Bitmap);

            originalImg.Dispose();

            return result;
        }
        
        private Bitmap EffectLark(Bitmap originalBmp)
        {
            Image<Bgr, Byte> originalImg = new Image<Bgr, byte>(originalBmp);

            Mat resultMat = new Mat(originalImg.Rows, originalImg.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 3);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var channels = originalImg.Split();

            Matrix<byte> bLUT = new Matrix<byte>(1, 256, 1);
            Matrix<byte> gLUT = new Matrix<byte>(1, 256, 1);
            Matrix<byte> rLUT = new Matrix<byte>(1, 256, 1);

            #region Color Curves
            blueChannel = new List<Point>();
            blueChannel.Add(new Point(0, 0));
            blueChannel.Add(new Point(52, 48));
            blueChannel.Add(new Point(209, 229));
            blueChannel.Add(new Point(255, 245));

            blueSpline = new Spline();
            blueSpline.AddPoints(blueChannel);

            greenChannel = new List<Point>();
            greenChannel.Add(new Point(0, 0));
            greenChannel.Add(new Point(52, 48));
            greenChannel.Add(new Point(209, 229));
            greenChannel.Add(new Point(255, 245));

            //greenChannel.Add(new Point(0, 8));
            //greenChannel.Add(new Point(106, 109));
            //greenChannel.Add(new Point(213, 229));
            //greenChannel.Add(new Point(255, 247));

            greenSpline = new Spline();
            greenSpline.AddPoints(greenChannel);

            greenDots = new List<Point>();
            for (int i = 0; i < 256; i++)
            {
                int j = greenSpline.Calculate(i);
                greenDots.Add(new Point(i, j));
            }

            redChannel = new List<Point>();
            redChannel.Add(new Point(0, 0));
            redChannel.Add(new Point(52, 48));
            redChannel.Add(new Point(209, 229));
            redChannel.Add(new Point(255, 245));

            redSpline = new Spline();
            redSpline.AddPoints(redChannel);

            redDots = new List<Point>();
            for (int i = 0; i < 256; i++)
            {
                int j = redSpline.Calculate(i);
                redDots.Add(new Point(i, j));
            }
            #endregion

            for (int i = 0; i < 256; i++)
            {
                bLUT[0, i] = (byte)blueSpline.Calculate(i);
                gLUT[0, i] = (byte)greenSpline.Calculate(i);
                rLUT[0, i] = (byte)redSpline.Calculate(i);
            }

            CvInvoke.LUT(channels[0], bLUT, channels[0]);
            CvInvoke.LUT(channels[1], gLUT, channels[1]);
            CvInvoke.LUT(channels[2], rLUT, channels[2]);

            VectorOfMat vm = new VectorOfMat();
            vm.Push(channels[0].Mat);
            vm.Push(channels[1].Mat);
            vm.Push(channels[2].Mat);

            CvInvoke.Merge(vm, resultMat);

            stopwatch.Stop();
            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";

            Bitmap result = new Bitmap(resultMat.ToImage<Bgr, Byte>().Bitmap);

            originalImg.Dispose();

            return result;
        }

        private Bitmap AmaroFilter(Bitmap originalBmp)
        {
            String R = "0:19 30:62 82:148 128:188 145:200 255:250";
            String G = "0:0 48:72 115:188 160:220 233:245 255:255";
            String B = "0:25 35:80 106:175 151:188 215:215 240:235 255:245";
            
            PhotoFilter amaro = new PhotoFilter("Amaro");
            amaro.AddCurve(Curve.Channel.Red, R);
            amaro.AddCurve(Curve.Channel.Green, G);
            amaro.AddCurve(Curve.Channel.Blue, B);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            Bitmap result = amaro.Apply(originalBmp);
            stopwatch.Stop();
            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";

            return result;
        }

        private Bitmap GinghamFilter(Bitmap originalBmp)
        {
            String R = "0:41 28:56 56:82 85:115 114:151 170:193 198:205 227:211 255:220";
            String G = "0:42 28:47 56:76 85:121 113:155 141:176 170:191 198:201 227:207 255:214";
            String B = "0:43 28:51 56:85 85:122 113:159 141:184 170:197 198:203 227:208 255:213";

            PhotoFilter gingham = new PhotoFilter("Gingham");
            gingham.AddCurve(Curve.Channel.Red, R);
            gingham.AddCurve(Curve.Channel.Green, G);
            gingham.AddCurve(Curve.Channel.Blue, B);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            Bitmap result = gingham.Apply(originalBmp);
            stopwatch.Stop();
            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";

            return result;
        }

        private Bitmap MayfairFilter(Bitmap originalBmp)
        {
            String R = "0:30 85:110 125:170 221:232 255:242";
            String G = "0:15 40:55 80:95 142:196 188:215 255:230";
            String B = "0:15 45:60 85:115 135:185 182:215 235:230 255:225";

            PhotoFilter mayfair = new PhotoFilter("Mayfair");
            mayfair.AddCurve(Curve.Channel.Red, R);
            mayfair.AddCurve(Curve.Channel.Green, G);
            mayfair.AddCurve(Curve.Channel.Blue, B);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            Bitmap result = mayfair.Apply(originalBmp);
            stopwatch.Stop();
            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";

            return result;
        }

        private Bitmap HudsonFilter(Bitmap originalBmp)
        {
            String R = "0:35 42:68 85:115 124:165 170:200 215:228 255:255";
            String G = "0:0 45:60 102:135 140:182 192:215 255:255";
            String B = "0:0 24:42 60:100 105:170 145:208 210:235 255:245";

            PhotoFilter hudson = new PhotoFilter("Hudson");
            hudson.AddCurve(Curve.Channel.Red, R);
            hudson.AddCurve(Curve.Channel.Green, G);
            hudson.AddCurve(Curve.Channel.Blue, B);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            Bitmap result = hudson.Apply(originalBmp);
            stopwatch.Stop();
            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";

            return result;
        }
        
        private void btEffect1_Click(object sender, EventArgs e)
        {
            modifiedPictureBox.Image = EffectBW(originalPicture);
        }

        private void btEffect2_Click(object sender, EventArgs e)
        {
            modifiedPictureBox.Image = EffectEqHist(originalPicture);
        }

        private void btEffect3_Click(object sender, EventArgs e)
        {
            modifiedPictureBox.Image = EffectHSV(originalPicture);
        }

        private void trackBarH_MouseUp(object sender, MouseEventArgs e)
        {
            modifiedPictureBox.Image = ChangeHSV(originalPicture);
        }

        private void trackBarS_Scroll(object sender, EventArgs e)
        {
            modifiedPictureBox.Image = ChangeHSV(originalPicture);
        }

        private void trackBarV_Scroll(object sender, EventArgs e)
        {
            modifiedPictureBox.Image = ChangeHSV(originalPicture);
        }

        private void btEffect4_Click(object sender, EventArgs e)
        {
            modifiedPictureBox.Image = EffectGingham(originalPicture);
        }

        private void btEffect5_Click(object sender, EventArgs e)
        {
            modifiedPictureBox.Image = EffectClarendon(originalPicture);
        }

        private void btEffect6_Click(object sender, EventArgs e)
        {
            modifiedPictureBox.Image = EffectLark(originalPicture);            
        }

        private void btAmaro_Click(object sender, EventArgs e)
        {
            modifiedPictureBox.Image = AmaroFilter(originalPicture);
        }

        private void btMayfair_Click(object sender, EventArgs e)
        {
            modifiedPictureBox.Image = MayfairFilter(originalPicture);
        }

        private void btHudson_Click(object sender, EventArgs e)
        {
            modifiedPictureBox.Image = HudsonFilter(originalPicture);
        }

        private void btValencia_Click(object sender, EventArgs e)
        {
            String R = "0:20 50:80 85:120 128:162 228:224 255:240";
            String G = "0:0 18:12 60:70 104:128 148:178 212:224 255:255";
            String B = "0:20 42:62 80:104 124:144 170:182 220:210 255:230";

            PhotoFilter hudson = new PhotoFilter("Hudson");
            hudson.AddCurve(Curve.Channel.Red, R);
            hudson.AddCurve(Curve.Channel.Green, G);
            hudson.AddCurve(Curve.Channel.Blue, B);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            modifiedPictureBox.Image = hudson.Apply(originalPicture);
            stopwatch.Stop();
            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";
        }

        private void btXpro_Click(object sender, EventArgs e)
        {
            String R = "0:0 42:28 105:100 148:160 185:208 255:255";
            String G = "0:0 40:25 85:75 125:130 165:180 212:230 255:255";
            String B = "0:30 40:58 82:90 125:125 170:160 235:210 255:222";

            PhotoFilter hudson = new PhotoFilter("X-Pro II");
            hudson.AddCurve(Curve.Channel.Red, R);
            hudson.AddCurve(Curve.Channel.Green, G);
            hudson.AddCurve(Curve.Channel.Blue, B);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            modifiedPictureBox.Image = hudson.Apply(originalPicture);
            stopwatch.Stop();
            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";
        }

        private void btSierra_Click(object sender, EventArgs e)
        {
            String R = "0:10 48:88 105:155 130:180 190:212 232:234 255:245";
            String G = "0:0 38:72 85:124 124:160 172:186 218:210 255:230";
            String B = "0:30 45:82 95:132 138:164 176:182 210:200 255:218";

            PhotoFilter hudson = new PhotoFilter("Sierra");
            hudson.AddCurve(Curve.Channel.Red, R);
            hudson.AddCurve(Curve.Channel.Green, G);
            hudson.AddCurve(Curve.Channel.Blue, B);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            modifiedPictureBox.Image = hudson.Apply(originalPicture);
            stopwatch.Stop();
            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";
        }

        private void btWillow_Click(object sender, EventArgs e)
        {
            String R = "0:30 68:105 95:145 175:215 255:240";
            String G = "0:30 55:85 105:160 198:210 255:230";
            String B = "0:30 40:70 112:165 195:215 255:228";

            PhotoFilter hudson = new PhotoFilter("Willow");
            hudson.AddCurve(Curve.Channel.Red, R);
            hudson.AddCurve(Curve.Channel.Green, G);
            hudson.AddCurve(Curve.Channel.Blue, B);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            modifiedPictureBox.Image = hudson.Apply(originalPicture);
            stopwatch.Stop();
            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";
        }

        private void btLofi_Click(object sender, EventArgs e)
        {
            String R = "0:0 40:20 88:80 128:150 170:200 230:245 255:255";
            String G = "0:0 35:15 90:70 105:105 148:180 188:218 255:255";
            String B = "0:0 62:50 100:95 130:155 150:182 190:220 255:255";

            PhotoFilter lofi = new PhotoFilter("Hudson");
            lofi.AddRedCurve(R);
            lofi.AddGreenCurve(G);
            lofi.AddBlueCurve(B);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            modifiedPictureBox.Image = lofi.ApplyFilter(originalPicture);
            stopwatch.Stop();
            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";
        }

        private void btRise_Click(object sender, EventArgs e)
        {
            String R = "0:25 30:70 130:192 170:200 233:233 255:255";
            String G = "0:25 30:72 65:118 100:158 152:195 210:230 255:255";
            String B = "0:35 40:75 82:124 120:162 175:188 220:214 255:255";

            PhotoFilter lofi = new PhotoFilter("Rise");
            lofi.AddRedCurve(R);
            lofi.AddGreenCurve(G);
            lofi.AddBlueCurve(B);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            modifiedPictureBox.Image = lofi.ApplyFilter(originalPicture);
            stopwatch.Stop();
            lblInfo.Text = "Info: " + stopwatch.ElapsedMilliseconds + " ms.";
        }
    }
}
