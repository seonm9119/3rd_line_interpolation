using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Term3
{
    class Cubic
    {
        Bitmap bitmap;

        int width, heigth;
        int nwidth, nheigth;

        int[,] weight;
        int[,,] arr;
        int[,,] newArr;

        public void initialize()
        {
          

            arr = new int[3, width, heigth];


            newArr = new int[3, nwidth, nheigth];


            for (int x = 0; x < width; x++)
                for (int y = 0; y < heigth; y++)
                {
                    arr[0, x, y] = bitmap.GetPixel(x, y).R;
                    arr[1, x, y] = bitmap.GetPixel(x, y).G;
                    arr[2, x, y] = bitmap.GetPixel(x, y).B;

                }
        }


        public Bitmap run(Bitmap bitmap, int nwidth, int nheigth)
        {
            this.bitmap = bitmap;
            this.width = bitmap.Width;
            this.heigth = bitmap.Height;
            this.nwidth = nwidth;
            this.nheigth = nheigth;
           

            initialize();

            Resize();

            Bitmap FinalBm = new Bitmap(nwidth, nheigth);
            for (int x = 0; x < nwidth; x++)
                for (int y = 0; y < nheigth; y++)
                    FinalBm.SetPixel(x, y, Color.FromArgb(newArr[0, x, y], newArr[1, x, y], newArr[2, x, y]));

            return FinalBm;
        }

        public void Resize()
        {

            int result;
            int x1, x2, x3, x4, y1, y2, y3, y4;
            double v1, v2, v3, v4, v;
            double rx, ry, p, q;

            for (int x = 0; x < nwidth; x++)
                for (int y = 0; y < nheigth; y++)
                {
                    rx = (double)(width - 1) * x / (nwidth - 1);
                    ry = (double)(heigth - 1) * y / (nheigth - 1);

                    x2 = (int)rx;
                    x1 = x2 - 1; if (x1 < 0) x1 = 0;
                    x3 = x2 + 1; if (x3 >= width) x3 = width - 1;
                    x4 = x2 + 2; if (x4 >= width) x4 = width - 1;
                    p = rx - x2;

                    y2 = (int)ry;
                    y1 = y2 - 1; if (y1 < 0) y1 = 0;
                    y3 = y2 + 1; if (y3 >= heigth) y3 = heigth - 1;
                    y4 = y2 + 2; if (y4 >= heigth) y4 = heigth - 1;
                    q = ry - y2;

                    for (int i = 0; i < 3; i++)
                    {
                        v1 = cubic_interpolation(arr[i, x1, y1], arr[i, x2, y1], arr[i, x3, y1], arr[i, x4, y1], p);
                        v2 = cubic_interpolation(arr[i, x1, y2], arr[i, x2, y2], arr[i, x3, y2], arr[i, x4, y2], p);
                        v3 = cubic_interpolation(arr[i, x1, y3], arr[i, x2, y3], arr[i, x3, y3], arr[i, x4, y3], p);
                        v4 = cubic_interpolation(arr[i, x1, y4], arr[i, x2, y4], arr[i, x3, y4], arr[i, x4, y4], p);

                        v = cubic_interpolation(v1, v2, v3, v4, q);


                        result = (int)(v + 0.5);

                        if (result > 255) result = 255;
                        else if (result < 0) result = 0;

                        newArr[i, x, y] = result;
                    }
                }


        }
        double cubic_interpolation(double v1, double v2, double v3, double v4, double d)
        {
            double v, p1, p2, p3, p4;

            p1 = 2 * v2;
            p2 = -v1 + v3;
            p3 = 2 * v1 - 5 * v2 + 4 * v3 - v4;
            p4 = -v1 + 3 * v2 - 3 * v3 + v4;

            v = (p1 + d * (p2 + d * (p3 + d * p4))) / 2;

            return v;
        }
    }
}
