using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Term3
{
    class Mask
    {
        Bitmap bitmap;
        int width, height;

        public Mask(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            this.width = bitmap.Width;
            this.height = bitmap.Height;
            
        }

        public int[,] gray()
        {
            Color color;
            int gray;
            int[,] gArr = new int[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    color = bitmap.GetPixel(x, y);
                    gray = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);

                    gArr[x, y] = gray;
                }

            return gArr;
        }

        private int[,] convolve(int[,] grayArr, double[,] mask, int maskCol, int maskRow, double factor, int bias)
        {

            int[,] result = new int[width, height];
            int xpad = maskCol / 2;
            int ypad = maskRow / 2;

            double sum;

            for (int x = 0; x < width - xpad * 2; x++)
                for (int y = 0; y < height - ypad * 2; y++)
                {
                    sum = 0;
                    for (int c = 0; c < maskCol; c++)
                        for (int r = 0; r < maskRow; r++)
                            sum += grayArr[x + c, y + r] * mask[c, r];

                    sum *= factor + bias;
                    if (sum > 255) sum = 255;
                    else if (sum < 0) sum = 0;
                    result[x + xpad, y + ypad] = (int)(sum);

                }

            return result;
        }


        public int[,] gaussian()
        {
            int[,] gArr = gray();

            double[,] gmask = { {  1,   4,  6,  4,  1 },
                              {  4,  16, 24, 16,  4 },
                              {  6,  24, 36, 24,  6 },
                              {  4,  16, 24, 16,  4 },
                              {  1,   4,  6,  4,  1 }, };

            int[,] gaussianArr = convolve(gArr,gmask, 5, 5, 1.0 / 256.0, 0);

            return gaussianArr;
        }

        public int[,] LOG()
        {

            int[,] gArr = gaussian();

            double[,] lmask = { { 1, 1, 1 }, { 1, -8, 1 }, { 1, 1, 1 } };

            int[,] laplacianArr = convolve(gArr, lmask, 3, 3, 1.0, 0);

            return laplacianArr;
        }

        public int[,] v_sobel()
        {
            int[,] gArr = gaussian();
            double[,] v_smask = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] v_sobelArr = convolve(gArr, v_smask, 3, 3, 1.0, 0);

            return v_sobelArr;
        }

        public int[,] h_sobel()
        {
            int[,] gArr = gaussian();

            double[,] h_smask = { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
            int[,] h_sobelArr = convolve(gArr, h_smask, 3, 3, 1.0, 0);

            return h_sobelArr;
        }
    }
}
