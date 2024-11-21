using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Term3
{
    class Nearest
    {
        int width, heigth;
        int nwidth, nheigth;

        int[,,] arr;
        int[,,] newArr;

        public void initialize(Bitmap bitmap, int nwidth, int nheigth)
        {
            this.width = bitmap.Width;
            this.heigth = bitmap.Height;
            this.nwidth = nwidth;
            this.nheigth = nheigth;

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
            initialize(bitmap, nwidth, nheigth);

            Resize();

            Bitmap FinalBm = new Bitmap(nwidth, nheigth);
            for (int x = 0; x < nwidth; x++)
                for (int y = 0; y < nheigth; y++)
                    FinalBm.SetPixel(x, y, Color.FromArgb(newArr[0, x, y], newArr[1, x, y], newArr[2, x, y]));

            return FinalBm;
        }

        public void Resize()
        {
            int x, y;
            double rx, ry;
            for (int i = 0; i < nwidth; i++)
                for (int j = 0; j < nheigth; j++)
                {
                    rx = (double)(width - 1) * i / (nwidth - 1);
                    ry = (double)(heigth - 1) * j / (nheigth - 1);
                    x = (int)(rx + 0.5);
                    y = (int)(ry + 0.5);

                    if (x >= width) x = width - 1;
                    if (y >= heigth) y = heigth - 1;

                    for(int k=0; k<3; k++)
                     newArr[k,i, j] = arr[k,x,y];
                }
        }
    }
}
