using AIDrawer;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AIPainter
{
    public partial class Painter : Form
    {
        private Bitmap _image;
        public Painter()
        {
            InitializeComponent();
        }


        private void UploadImage(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "jpg (*.jpg) | *.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (Stream bmpStream = System.IO.File.Open(ofd.FileName, System.IO.FileMode.Open))
                    {

                        Image image = Image.FromStream(bmpStream);

                        _image = new Bitmap(image, image.Width / 10, image.Height / 10);
                        for (int i = 0; i < _image.Width; i++)
                        {
                            for (int j = 0; j < _image.Height; j++)
                            {
                                var color = _image.GetPixel(i, j);
                                var avg = (int)(color.R * 0.3) + (int)(color.G * 0.59) + (int)(color.B * 0.11);
                                var newColor = Color.FromArgb(avg, avg, avg);
                                _image.SetPixel(i, j, newColor);
                            }
                        }
                        _image.Save(@"c:\monalisa\monalisa.bmp");
                        pictureBox1.Image = _image;
                 
                    }
                }
            }
            var copyImage = _image.Clone(new Rectangle(0, 0, _image.Width, _image.Height), _image.PixelFormat);
            pictureBox1.Image = copyImage;
        }

        private void WhereTheMagicHappen()
        {

            var gAlg = new GeneticAlgo(20000, _image.ConvertToMatrix(), 1, 20, 1, 30);
            gAlg.GenerateFirstPopulation();
            var time = new Stopwatch();
            time.Start();
            while (true)
            {
                gAlg.CalculateFitness();
                gAlg.GetTheBestPopulation();
                var score = gAlg.Fitness.Max();

                ScoreLbl.Text = "Score: " + score;
                generationLbl.Text = "Generation: " + gAlg.Generation;
                completionRateLbl.Text = "Completion: " + gAlg.CompletionRate.ToString("0.00") + "%";
                timeLbl.Text = time.Elapsed.ToString(@"d\.hh\:mm\:ss");

                var indexScore = Array.IndexOf(gAlg.Fitness, score);
                var tmpImage = gAlg.Population[indexScore];
                if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                pictureBox2.Image = tmpImage.ConvertToBitmap();
                this.Refresh();
                gAlg.GenerateNewPopulation();
                gAlg.Generation++;



            }
        }
        private void AIPaint(object sender, EventArgs e)
        {
            WhereTheMagicHappen();
        
        }


    }
}
