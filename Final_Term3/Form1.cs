using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Term3
{
    public partial class Form1 : Form
    {

        Image image;
        Bitmap OriginalBm;
        Bitmap FinalBm;
        Bitmap ROIbitmap;
        Bitmap cuBm;

        private bool bLeftButtonDown = false;
        private Point ClickPoint = new Point();
        private Point CurrentTopLeft = new Point();
        private Point CurrentBottomRight = new Point();
        private Pen MyPen;
        private Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "영상 파일 열기";
            openFileDialog1.Filter = "All Files(*.*) |*.*| Bitmap File(*.bmp) | *.bmp | Jpeg File(*.jpg) | *.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strFilename = openFileDialog1.FileName;
                image = Image.FromFile(strFilename);
                OriginalBm = new Bitmap(image);


            }

            pictureBox1.Image = image;

        }

        public Bitmap display(int[,] arr)
        {
            Bitmap newbitmap = new Bitmap(320, 320);

            for (int x = 0; x < 320; x++)
                for (int y = 0; y < 320; y++)
                    newbitmap.SetPixel(x, y, Color.FromArgb(arr[x, y], arr[x, y], arr[x, y]));

            return newbitmap;
        }

        private void ROI_Click(object sender, EventArgs e)
        {
            g = this.pictureBox1.CreateGraphics();
            MyPen = new Pen(Color.Red, 2);
            MyPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bLeftButtonDown)
            {
                //X좌표 계산
                if (e.X < ClickPoint.X)
                {
                    CurrentTopLeft.X = e.X;
                    CurrentBottomRight.X = ClickPoint.X;
                }
                else
                {
                    CurrentTopLeft.X = ClickPoint.X;
                    CurrentBottomRight.X = e.X;
                }
                //Y좌표계산
                if (e.Y < ClickPoint.Y)
                {
                    CurrentTopLeft.Y = e.Y;
                    CurrentBottomRight.Y = ClickPoint.Y;
                }
                else
                {
                    CurrentTopLeft.Y = ClickPoint.Y;
                    CurrentBottomRight.Y = e.Y;
                }

                //화면초기화
                pictureBox1.Refresh();

                g.DrawRectangle(MyPen, CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X,
               CurrentBottomRight.Y - CurrentTopLeft.Y);

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            bLeftButtonDown = true;
            this.Cursor = Cursors.Cross;
            ClickPoint = new Point(e.X, e.Y);
            //화면초기화
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            bLeftButtonDown = false;
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int curLx = (CurrentTopLeft.X * OriginalBm.Width) / 440;
            int curLy = (CurrentTopLeft.Y * OriginalBm.Height) / 400;
            int curRx = (CurrentBottomRight.X * OriginalBm.Width) / 440;
            int curRy = (CurrentBottomRight.Y * OriginalBm.Height) / 400;

            int testx = CurrentTopLeft.X;
            int testy = CurrentTopLeft.Y;
            int testx2 = CurrentBottomRight.X;
            int testy2 = CurrentBottomRight.Y;

            Console.Write(testx +"  "+ testy +"  "+ testx2 +"  "+ testy2);

            ROIbitmap = new Bitmap(curRx - curLx, curRy - curLy);

            for (int x = curLx; x < curRx; x++)
                for (int y = curLy; y < curRy; y++)
                    ROIbitmap.SetPixel(x - curLx, y - curLy, OriginalBm.GetPixel(x, y));

            Form2 form2 = new Form2("ROI이미지");

            form2.initialize(ROIbitmap);
            form2.Show();
        }

        private void 기본확대ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2("기본 확대 320*320");
            Bitmap basicBm = new Bitmap(ROIbitmap, 320, 320);

            form2.initialize(basicBm);
            form2.Show();
        }

        private void 차회선보간법ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cubic cubic = new Cubic();
            cuBm = cubic.run(ROIbitmap, 320, 320);

            Form2 form2 = new Form2("3차 회선 보간법 320*320");

            form2.initialize(cuBm);
            form2.Show();
        }

        private void 결과화면ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Improvecubic improvecubic = new Improvecubic();
            Bitmap imBm = improvecubic.run(ROIbitmap,320,320);

            Form2 form2 = new Form2("개선된 3차 회선 보간 320*320");

            form2.initialize(imBm);
            form2.Show();

        }

        private void 차회선확ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nearest nearest = new Nearest();
            Bitmap nearBm = nearest.run(ROIbitmap, 320, 320);

            Form2 form2 = new Form2("최근방 이웃 보간법 320*320");

            form2.initialize(nearBm);
            form2.Show();
           
        }

        private void 윤곽추출ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Improvecubic improvecubic = new Improvecubic();
            Bitmap imBm = improvecubic.run(ROIbitmap,320,320);
            //Cubic cubic = new Cubic();
            //Bitmap basicBm = cubic.run(ROIbitmap, 320, 320);
            Bitmap basicBm = new Bitmap(ROIbitmap, 320, 320);


            Mask mask = new Mask(imBm);
            Mask mask2 = new Mask(basicBm);

            int[,] logArr=mask.LOG();
            int[,] logArr2 = mask2.LOG();

            Bitmap newBm = display(logArr);
            Bitmap newBm2 = display(logArr2);

            

            Form2 form = new Form2("개선된 3차 회선 보간 320*320");


            form.initialize(newBm);
            form.Show();

            Form2 form2 = new Form2("3차 회선 320*320");

            form2.initialize(newBm2);
            form2.Show();
        }

        private void fuzzyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Improvecubic improvecubic = new Improvecubic();
            Bitmap imBm = improvecubic.run(ROIbitmap,320,320);
            //Cubic cubic = new Cubic();
            //Bitmap basicBm = cubic.run(ROIbitmap, 320, 320);

            //Cubic cubic = new Cubic();
            Bitmap basicBm = new Bitmap(ROIbitmap, 320, 320);

            Fuzzy fuzzy1 = new Fuzzy(imBm);
            int[,] f1= fuzzy1.run();

            Fuzzy fuzzy2 = new Fuzzy(basicBm);
            int[,] f2 = fuzzy2.run();

            Bitmap newBm = display(f1);
            Bitmap newBm2 = display(f2);

            Form2 form = new Form2("개선된 3차 회선 보간 320*320");


            form.initialize(newBm);
            form.Show();

            Form2 form2 = new Form2("3차 회선 320*320");

            form2.initialize(newBm2);
            form2.Show();

        }

        private void vsobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Improvecubic improvecubic = new Improvecubic();
            Bitmap imBm = improvecubic.run(ROIbitmap, 320, 320);
            //Cubic cubic = new Cubic();
            //Bitmap basicBm = cubic.run(ROIbitmap, 320, 320);
            Bitmap basicBm = new Bitmap(ROIbitmap, 320, 320);


            Mask mask = new Mask(imBm);
            Mask mask2 = new Mask(basicBm);

            int[,] sobelArr = mask.v_sobel();
            int[,] sobelArr2 = mask2.v_sobel();

            Bitmap newBm = display(sobelArr);
            Bitmap newBm2 = display(sobelArr2);



            Form2 form = new Form2("개선된 3차 회선 보간 320*320");


            form.initialize(newBm);
            form.Show();

            Form2 form2 = new Form2("3차 회선 320*320");

            form2.initialize(newBm2);
            form2.Show();
        }
    }
}
