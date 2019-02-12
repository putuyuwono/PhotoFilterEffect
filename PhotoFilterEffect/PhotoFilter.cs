using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFilterEffect
{
    class PhotoFilter
    {
        private String name;
        private List<Curve> curves;

        private Curve red;
        private Curve green;
        private Curve blue;
        private Curve rgb;
             
                
        public PhotoFilter(String name)
        {
            this.name = name;
            this.curves = new List<Curve>();
        }

        public void AddRedCurve(String pts)
        {
            red = new Curve(Curve.Channel.Red);
            red.ParsePoints(pts);
        }

        public void AddGreenCurve(String pts)
        {
            green = new Curve(Curve.Channel.Green);
            green.ParsePoints(pts);
        }

        public void AddBlueCurve(String pts)
        {
            blue = new Curve(Curve.Channel.Blue);
            blue.ParsePoints(pts);
        }

        public void AddRgbCurve(String pts)
        {
            rgb = new Curve(Curve.Channel.RGB);
            rgb.ParsePoints(pts);
        }

        public void AddCurve(Curve curve)
        {
            this.curves.Add(curve);
        }

        public void AddCurve(Curve.Channel ch, String pts)
        {
            Curve c = new Curve(ch);
            c.ParsePoints(pts);
            this.curves.Add(c);
        }

        public Bitmap ApplyFilter(Bitmap inputBmp)
        {
            Image<Bgr, Byte> inputImg = new Image<Bgr, byte>(inputBmp);
            Mat resultMat = new Mat(inputImg.Rows, inputImg.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 3);
            var imgChannels = inputImg.Split();

            Matrix<byte> bLUT = new Matrix<byte>(1, 256, 1);
            Matrix<byte> gLUT = new Matrix<byte>(1, 256, 1);
            Matrix<byte> rLUT = new Matrix<byte>(1, 256, 1);

            byte b;
            for (int i = 0; i < 256; i++)
            {
                if (red != null)
                {
                    b = (byte)red.Calculate(i);
                    rLUT[0, i] = b;
                }

                if (green != null)
                {
                    b = (byte)green.Calculate(i);
                    gLUT[0, i] = b;
                }

                if (blue != null)
                {
                    b = (byte)blue.Calculate(i);
                    bLUT[0, i] = b;
                }

                if (rgb != null)
                {
                    b = (byte)rgb.Calculate(i);
                    rLUT[0, i] = b;
                    gLUT[0, i] = b;
                    bLUT[0, i] = b;
                }
            }

            CvInvoke.LUT(imgChannels[0], bLUT, imgChannels[0]);
            CvInvoke.LUT(imgChannels[1], gLUT, imgChannels[1]);
            CvInvoke.LUT(imgChannels[2], rLUT, imgChannels[2]);

            VectorOfMat vm = new VectorOfMat();
            vm.Push(imgChannels[0].Mat);
            vm.Push(imgChannels[1].Mat);
            vm.Push(imgChannels[2].Mat);

            CvInvoke.Merge(vm, resultMat);

            Bitmap output = new Bitmap(resultMat.ToImage<Bgr, Byte>().Bitmap);

            return output;
        }

        public Bitmap Apply(Bitmap inputBmp)
        {
            Image<Bgr, Byte> inputImg = new Image<Bgr, byte>(inputBmp);
            Mat resultMat = new Mat(inputImg.Rows, inputImg.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 3);
            var imgChannels = inputImg.Split();

            Matrix<byte> bLUT = new Matrix<byte>(1, 256, 1);
            Matrix<byte> gLUT = new Matrix<byte>(1, 256, 1);
            Matrix<byte> rLUT = new Matrix<byte>(1, 256, 1);


            for (int i = 0; i < 256; i++)
            {
                foreach (var curve in curves)
                {
                    byte b = (byte)curve.Calculate(i);
                    switch (curve.channel)
                    {
                        case Curve.Channel.Red:
                            rLUT[0, i] = b;
                            break;
                        case Curve.Channel.Green:
                            gLUT[0, i] = b;
                            break;
                        case Curve.Channel.Blue:
                            bLUT[0, i] = b;
                            break;
                        case Curve.Channel.RGB:
                            rLUT[0, i] = b;
                            gLUT[0, i] = b;
                            bLUT[0, i] = b;
                            break;
                        default:
                            break;
                    }
                }
            }

            CvInvoke.LUT(imgChannels[0], bLUT, imgChannels[0]);
            CvInvoke.LUT(imgChannels[1], gLUT, imgChannels[1]);
            CvInvoke.LUT(imgChannels[2], rLUT, imgChannels[2]);

            VectorOfMat vm = new VectorOfMat();
            vm.Push(imgChannels[0].Mat);
            vm.Push(imgChannels[1].Mat);
            vm.Push(imgChannels[2].Mat);

            CvInvoke.Merge(vm, resultMat);

            Bitmap output = new Bitmap(resultMat.ToImage<Bgr, Byte>().Bitmap);

            inputImg.Dispose();
            resultMat.Dispose();

            return output;
        }

        public String GetName()
        {
            return this.name;
        }
    }
}
