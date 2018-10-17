using AIDrawer;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
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

                        _image = new Bitmap(image, image.Width / 2, image.Height / 2);
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
                        pictureBox1.Image = _image;
                    }
                }
            }
            var copyImage = _image.Clone(new Rectangle(0, 0, _image.Width, _image.Height), _image.PixelFormat);
            pictureBox1.Image = copyImage;
        }

        private void AIPaint(object sender, EventArgs e)
        {

            var geneticAlgo = new GeneticAlgo(500, _image, 0.1);
            geneticAlgo.GenerateFirstPopulation();
            var generation = 0;
            var BestScore = 0.0;
            while (true)
            {
                geneticAlgo.CalculateFitness();
                var score = geneticAlgo.Fitness.Max();
                if (score > BestScore)
                {
                    BestScore = score;
                }
                maxScoreLbl.Text = "Best score: " + BestScore;
                ScoreLbl.Text = "Score: " + score;
                generationLbl.Text = "Generation: " + generation;



                var indexScore = Array.IndexOf(geneticAlgo.Fitness, score);
                var tmpImage = geneticAlgo.Population[indexScore];
                var copyImage = tmpImage.Clone(new Rectangle(0, 0, tmpImage.Width, tmpImage.Height), tmpImage.PixelFormat);

                if (generation % 100 == 0)
                {
                    copyImage.Save(@"c:\monalisa\" + generation + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                }

                pictureBox2.Image = copyImage;

                this.Refresh();
                geneticAlgo.GenerateNewPopulation();
                generation++;


            }
        }
    }
}
