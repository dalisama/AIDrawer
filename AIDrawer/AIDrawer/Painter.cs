using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AIPainter
{
    public partial class Painter : Form
    {
        public Painter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(320, 360);
            var rand = new Random();

            while (true)
            {
                Bitmap flag = new Bitmap(640, 360);

         
                for (int i = 0; i < flag.Height; i++)
                {
                    for (int j = 0; j < flag.Width; j++)
                    {

                        flag.SetPixel(j, i, Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256), rand.Next(256)));



                    }
                }
                pictureBox1.Image = flag;
                Refresh();
            }


        }
        private Bitmap ConvertToBitmap(string fileName)
        {
            Bitmap bitmap;
            using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);

                bitmap = new Bitmap(image);

            }
            return bitmap;
        }
    }
}
