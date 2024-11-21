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
    public partial class Form2 : Form
    {
        Bitmap bitmap;
        Graphics grBm;

        public Form2(String str)
        {
            InitializeComponent();
            setShadowBitmap();
            this.Text = str;
        }

        void setShadowBitmap()
        {
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            grBm = Graphics.FromImage(bitmap);
            grBm.Clear(BackColor);
        }

        public void initialize(Bitmap bitmap)
        {
            this.ClientSize = new System.Drawing.Size(bitmap.Width, bitmap.Height);
            setShadowBitmap();

            grBm.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
            Invalidate();

            //메모리 회수(델파이코드)
            grBm.Dispose();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawImage(bitmap, 0, 0);
        }
    }
}
