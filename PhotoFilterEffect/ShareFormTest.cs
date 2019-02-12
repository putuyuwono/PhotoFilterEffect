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
    public partial class ShareFormTest : Form
    {
        private Bitmap originalBitmap;
        private List<PhotoFilter> filters;

        private static Font FilterTextFont = new Font(FontFamily.GenericMonospace, 150.0f, FontStyle.Bold);
        private static Brush FilterTextBrush = new SolidBrush(Color.OrangeRed);
        
        public ShareFormTest()
        {
            InitializeComponent();

            InitFilters();
            InitUI();
            InitViewPicture();
        }

        private void InitUI()
        {
            originalBitmap = new Bitmap("munich.jpg");

            pictureBox.Image = originalBitmap;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            panel.Size = new System.Drawing.Size(1280, 145);
            panel.Location = new Point(0, 720 - panel.Height);                        
        }

        private void InitViewPicture()
        {
            Size sz = new Size(160, 120);
            int px = 0, py = 5;
            PictureBox pb; 
            Bitmap filterBmp;
            foreach (var filter in filters)
            {
                pb = new PictureBox();
                pb.Size = sz;
                pb.Location = new Point(px, py);

                px += sz.Width + 5;

                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                filterBmp = filter.Apply(originalBitmap);
                using (Graphics g = Graphics.FromImage(filterBmp))
                {
                    g.DrawString(filter.GetName(), FilterTextFont, FilterTextBrush, 5.0f, 5.0f);
                }
                pb.Image = filterBmp;

                pb.MouseClick += new MouseEventHandler(delegate(Object o, MouseEventArgs a)
                {
                    pictureBox.Image = filter.Apply(originalBitmap);
                });

                panel.Controls.Add(pb);
            }

        }

        private void InitFilters()
        {
            filters = new List<PhotoFilter>();

            String R, G, B, RGB;
            PhotoFilter filter;

            #region Original
            RGB = "0:0 255:255";
            
            filter = new PhotoFilter("Original");
            filter.AddCurve(Curve.Channel.RGB, RGB);
            filters.Add(filter);
            #endregion

            #region Lo-fi
            R = "0:25 30:70 130:192 170:200 233:233 255:255";
            G = "0:25 30:72 65:118 100:158 152:195 210:230 255:255";
            B = "0:35 40:75 82:124 120:162 175:188 220:214 255:255";

            filter = new PhotoFilter("Lo-Fi");
            filter.AddCurve(Curve.Channel.Red, R);
            filter.AddCurve(Curve.Channel.Green, G);
            filter.AddCurve(Curve.Channel.Blue, B);

            filters.Add(filter);
            #endregion

            #region Gingham
            R = "0:41 28:56 56:82 85:115 114:151 170:193 198:205 227:211 255:220";
            G = "0:42 28:47 56:76 85:121 113:155 141:176 170:191 198:201 227:207 255:214";
            B = "0:43 28:51 56:85 85:122 113:159 141:184 170:197 198:203 227:208 255:213";

            filter = new PhotoFilter("Gingham");
            filter.AddCurve(Curve.Channel.Red, R);
            filter.AddCurve(Curve.Channel.Green, G);
            filter.AddCurve(Curve.Channel.Blue, B);

            filters.Add(filter);
            #endregion

            #region Mayfair
            R = "0:30 85:110 125:170 221:232 255:242";
            G = "0:15 40:55 80:95 142:196 188:215 255:230";
            B = "0:15 45:60 85:115 135:185 182:215 235:230 255:225";

            filter = new PhotoFilter("Mayfair");
            filter.AddCurve(Curve.Channel.Red, R);
            filter.AddCurve(Curve.Channel.Green, G);
            filter.AddCurve(Curve.Channel.Blue, B);

            filters.Add(filter);
            #endregion

            #region Hudson
            R = "0:35 42:68 85:115 124:165 170:200 215:228 255:255";
            G = "0:0 45:60 102:135 140:182 192:215 255:255";
            B = "0:0 24:42 60:100 105:170 145:208 210:235 255:245";

            filter = new PhotoFilter("Hudson");
            filter.AddCurve(Curve.Channel.Red, R);
            filter.AddCurve(Curve.Channel.Green, G);
            filter.AddCurve(Curve.Channel.Blue, B);

            filters.Add(filter);
            #endregion

            #region Rise
            R = "0:25 30:70 130:192 170:200 233:233 255:255";
            G = "0:25 30:72 65:118 100:158 152:195 210:230 255:255";
            B = "0:35 40:75 82:124 120:162 175:188 220:214 255:255";

            filter = new PhotoFilter("Rise");
            filter.AddCurve(Curve.Channel.Red, R);
            filter.AddCurve(Curve.Channel.Green, G);
            filter.AddCurve(Curve.Channel.Blue, B);

            filters.Add(filter);
            #endregion

            #region Willow
            R = "0:30 68:105 95:145 175:215 255:240";
            G = "0:30 55:85 105:160 198:210 255:230";
            B = "0:30 40:70 112:165 195:215 255:228";

            filter = new PhotoFilter("Willow");
            filter.AddCurve(Curve.Channel.Red, R);
            filter.AddCurve(Curve.Channel.Green, G);
            filter.AddCurve(Curve.Channel.Blue, B);

            filters.Add(filter);
            #endregion

            #region Sierra
            R = "0:10 48:88 105:155 130:180 190:212 232:234 255:245";
            G = "0:0 38:72 85:124 124:160 172:186 218:210 255:230";
            B = "0:30 45:82 95:132 138:164 176:182 210:200 255:218";

            filter = new PhotoFilter("Sierra");
            filter.AddCurve(Curve.Channel.Red, R);
            filter.AddCurve(Curve.Channel.Green, G);
            filter.AddCurve(Curve.Channel.Blue, B);

            filters.Add(filter);
            #endregion

            #region X-Pro
            R = "0:0 42:28 105:100 148:160 185:208 255:255";
            G = "0:0 40:25 85:75 125:130 165:180 212:230 255:255";
            B = "0:30 40:58 82:90 125:125 170:160 235:210 255:222";

            filter = new PhotoFilter("X-Pro II");
            filter.AddCurve(Curve.Channel.Red, R);
            filter.AddCurve(Curve.Channel.Green, G);
            filter.AddCurve(Curve.Channel.Blue, B);

            filters.Add(filter);
            #endregion

            #region Valencia
            R = "0:20 50:80 85:120 128:162 228:224 255:240";
            G = "0:0 18:12 60:70 104:128 148:178 212:224 255:255";
            B = "0:20 42:62 80:104 124:144 170:182 220:210 255:230";

            filter = new PhotoFilter("Valencia");
            filter.AddCurve(Curve.Channel.Red, R);
            filter.AddCurve(Curve.Channel.Green, G);
            filter.AddCurve(Curve.Channel.Blue, B);

            filters.Add(filter);
            #endregion

            #region Amaro
            R = "0:19 30:62 82:148 128:188 145:200 255:250";
            G = "0:0 48:72 115:188 160:220 233:245 255:255";
            B = "0:25 35:80 106:175 151:188 215:215 240:235 255:245";

            filter = new PhotoFilter("Amaro");
            filter.AddCurve(Curve.Channel.Red, R);
            filter.AddCurve(Curve.Channel.Green, G);
            filter.AddCurve(Curve.Channel.Blue, B);

            filters.Add(filter);
            #endregion
        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            panel.Visible = !panel.Visible;
        }
    }
}
