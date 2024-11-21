using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Term3
{
    class Fuzzy
    {
        Bitmap bitmap;
        int width, heigth;
        int[,] grayArr;
        double x_min = 255, x_mid, x_max = 0;
        double d_min, d_max;
        double adj;
        double i_min, i_mid, i_max;
        double cut, alpha, beta;
        int[,] x_new;

        public Fuzzy(Bitmap bitmap)
        {

            this.bitmap = bitmap;
            width = bitmap.Width;
            heigth = bitmap.Height;
            grayArr = new int[width, heigth];
            gray();

        }

        public void gray()
        {
            Color color;
            int gray;


            for (int x = 0; x < width; x++)
                for (int y = 0; y < heigth; y++)
                {
                    color = bitmap.GetPixel(x, y);
                    gray = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);

                    grayArr[x, y] = gray;
                }
        }

        public Bitmap display(int[,] arr)
        {

            Bitmap newBitmap = new Bitmap(width, heigth);
            for (int x = 0; x < width; x++)
                for (int y = 0; y < heigth; y++)
                    newBitmap.SetPixel(x, y, Color.FromArgb(arr[x, y], arr[x, y], arr[x, y]));

            return newBitmap;
        }

        public int[,] run()
        {

            x_new = new int[width, heigth];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < heigth; y++)
                {
                    x_mid += grayArr[x, y];

                    if (grayArr[x, y] < x_min)
                        x_min = grayArr[x, y];

                    if (grayArr[x, y] > x_max)
                        x_max = grayArr[x, y];

                }

            x_mid /= width * heigth;

            d_max = Math.Abs(x_max - x_mid);
            d_min = Math.Abs(x_mid - x_min);

            if (x_mid > 128) adj = 255 - x_mid;
            else if (x_mid <= d_min) adj = d_min;
            else if (x_mid >= d_max) adj = d_max;
            else adj = x_mid;

            i_max = x_mid + adj;
            i_min = x_mid - adj;
            i_mid = (i_max + i_min) / 2;

            if (i_min != 0) cut = i_min / i_max;
            else cut = 0.5;

            alpha = (i_mid - i_min) * cut + i_min;
            beta = -1 * (i_max - i_mid) * cut + i_max;

            double tmp;
            for (int x = 0; x < width; x++)
                for (int y = 0; y < heigth; y++)
                {
                    tmp = ((grayArr[x, y] - alpha) / (beta - alpha)) * 255;

                    if (tmp > 255)
                        x_new[x, y] = 255;
                    else if (tmp < 0)
                        x_new[x, y] = 0;
                    else
                        x_new[x, y] = (int)tmp;

                }
            return x_new;
        }
    }
}
