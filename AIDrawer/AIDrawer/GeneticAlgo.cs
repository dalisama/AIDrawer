using System.Drawing;
using System.Linq;

namespace AIDrawer
{
    public class GeneticAlgo
    {
        public Bitmap[] Population;
        public int PopulationSize;
        public double[] Fitness;
        public Bitmap ImageToMimic;
        public double MutationRate;
        private int ImageToMimicWidth;
        private int ImageToMimicHeight;

        public GeneticAlgo(int populationSize, Bitmap imageToMimic, double mutationRate)
        {

            PopulationSize = populationSize;
            Population = new Bitmap[populationSize];
            Fitness = new double[populationSize];
            ImageToMimic = imageToMimic;
            MutationRate = mutationRate;
            ImageToMimicWidth = ImageToMimic.Width;
            ImageToMimicHeight = ImageToMimic.Height;

        }

        private Bitmap GenerateRandomBitMap()
        {
            Bitmap image = new Bitmap(ImageToMimicWidth, ImageToMimicHeight);
            for (int i = 0; i < ImageToMimicHeight; i++)
            {
                for (int j = 0; j < ImageToMimicWidth; j++)
                {
                    var grey = ParallelRandom.Next(256);
                    image.SetPixel(j, i, Color.FromArgb(grey, grey, grey));

                }
            }
            return image;

        }

        public void GenerateFirstPopulation()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                Population[i] = GenerateRandomBitMap();
            }


        }

        private int NaturalSelection()
        {
            var accept = false;
            var rd = 0;
            var rd2 = 0;
            while (!accept)
            {

                rd = ParallelRandom.Next(PopulationSize);
                rd2 = ParallelRandom.Next((int)Fitness.Max());
                if (rd2 <= Fitness[rd])
                {
                    accept = true;
                }

            }
            return rd;
        }

        private void Mutation(Bitmap image)
        {
            for (int i = 0; i < ImageToMimicHeight; i++)
            {
                for (int j = 0; j < ImageToMimicWidth; j++)
                {
                    if (ParallelRandom.Next(100) < MutationRate)
                        image.SetPixel(j, i, Color.FromArgb(ParallelRandom.Next(256), ParallelRandom.Next(256), ParallelRandom.Next(256), ParallelRandom.Next(256)));

                }
            }
        }

        private Bitmap Crossover()
        {
            var indexFather = NaturalSelection();
            var indexMother = NaturalSelection();
            var child = new Bitmap(ImageToMimicWidth, ImageToMimicHeight);
            for (int i = 0; i < ImageToMimicHeight; i++)
            {
                for (int j = 0; j < ImageToMimicWidth; j++)
                {
                    if (ParallelRandom.Next((int)Fitness[indexFather] + (int)Fitness[indexMother]) < (int)Fitness[indexFather])
                    {
                        child.SetPixel(j, i, Population[indexFather].GetPixel(j, i));
                    }
                    else
                    {

                        child.SetPixel(j, i, Population[indexMother].GetPixel(j, i));
                    }

                    if (ParallelRandom.Next(100) < MutationRate)
                        child.SetPixel(j, i, Color.FromArgb(ParallelRandom.Next(256), ParallelRandom.Next(256), ParallelRandom.Next(256), ParallelRandom.Next(256)));


                }
            }
            return child;
        }

        public void CalculateFitness()
        {
            for (int index = 0; index < PopulationSize; index++)
            {

                var score = 0;
                for (int i = 0; i < ImageToMimicHeight; i++)
                {
                    for (int j = 0; j < ImageToMimicWidth; j++)
                    {
                        if (ImageToMimic.GetPixel(j, i).R == Population[index].GetPixel(j, i).R)
                        {

                            score++;
                        }

                    }
                }
                Fitness[index] = score * 100;
            };
        }

        public void GenerateNewPopulation()
        {
            var tmpPopulation = new Bitmap[PopulationSize];
            for (int i = 0; i < PopulationSize; i++)
            {
                tmpPopulation[i] = Crossover();
            }
            for (int i = 0; i < PopulationSize; i++)
            {
                Population[i] = tmpPopulation[i];
            }
        }
    }
}

