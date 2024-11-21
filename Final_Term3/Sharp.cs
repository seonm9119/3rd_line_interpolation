using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Term3
{
    class Sharp
    {
        double[,] gaussianR, gaussianG, gaussianB;

        public Bitmap GaussianBlur(Bitmap bitmap, int Radius)
        {
            int x, y, col, raw;
            double r = 0;
            double g = 0;
            double b = 0;
            Color color, newColor;
            double weighting;
            double sum = 0;


            //double grayValue = 0;
            int index = 0;
            int BlurRadius = Radius;

            int maxWidth = bitmap.Width - 1;
            int maxHeight = bitmap.Height - 1;
            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            List<double> BlurArray = new List<double>();

            gaussianR = new double[bitmap.Height, bitmap.Width];
            gaussianG = new double[bitmap.Height, bitmap.Width];
            gaussianB = new double[bitmap.Height, bitmap.Width];

            //GetWeighting
            double q = (BlurRadius * 2 + 1) / 2;


            //SetBlurArray
            for (y = BlurRadius; y >= BlurRadius * (-1); y--)
            {
                for (x = BlurRadius * (-1); x <= BlurRadius; x++)
                {
                    //GetWeighting
                    weighting = 1 / (2 * Math.PI * Math.Pow(q, 2)) * Math.Exp(-(x * x + y * y) / (2 * q * q));
                    BlurArray.Add(weighting);
                    sum += weighting;
                    // Console.WriteLine("no " + BlurArray.Count + "weighting : " + weighting);
                }
            }
            //Console.WriteLine("sum ; " + sum);

            for (int i = 0; i < BlurArray.Count; i++)
            {
                BlurArray[i] = BlurArray[i] / sum;
                // Console.WriteLine(i + " : " + BlurArray[i]);
            }


            //GetBlurBitmap
            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    //GetBlurColor
                    for (col = y - BlurRadius; col <= y + BlurRadius; col++)
                    {
                        for (raw = x - BlurRadius; raw <= x + BlurRadius; raw++)
                        {
                            //GetDefautColor
                            if (raw < 0 && col < 0)
                                color = bitmap.GetPixel(0, 0);
                            else if (raw < 0)
                                color = bitmap.GetPixel(0, Math.Min(maxHeight, col));
                            else if (col < 0)
                                color = bitmap.GetPixel(Math.Min(maxWidth, raw), 0);
                            else
                                color = bitmap.GetPixel(Math.Min(maxWidth, raw), Math.Min(maxHeight, col));

                            r += color.R * BlurArray[index];
                            g += color.G * BlurArray[index];
                            b += color.B * BlurArray[index];
                            index++;
                        }
                    }

                    // int gray = (int)Math.Round(grayValue);
                    // color = Color.FromArgb((byte)grayValue, (byte)grayValue, (byte)grayValue);
                    newColor = Color.FromArgb((byte)r, (byte)g, (byte)b);

                    newBitmap.SetPixel(x, y, newColor);

                    gaussianR[y, x] = r;
                    gaussianR[y, x] = g;
                    gaussianR[y, x] = b;

                    index = 0;
                    r = g = b = 0;
                    //grayValue = 0;

                }
            }

            return newBitmap;
        }

        public Bitmap UnsharpenMask(Bitmap bitmap, double weight)
        {
            int x, y;
            double unsharpenR, unsharpenG, unsharpenB;
            Color color, newColor;

            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    color = bitmap.GetPixel(x, y);

                    unsharpenR = Math.Max((color.R - weight * gaussianR[y, x]) / (1 - weight), 0);
                    unsharpenG = Math.Max((color.G - weight * gaussianR[y, x]) / (1 - weight), 0);
                    unsharpenB = Math.Max((color.B - weight * gaussianR[y, x]) / (1 - weight), 0);

                    newColor = Color.FromArgb((byte)unsharpenR, (byte)unsharpenG, (byte)unsharpenB);
                    newBitmap.SetPixel(x, y, newColor);
                }
            }

            return newBitmap;
        }
    }
}
