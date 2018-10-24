using csMatrix;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AIDrawer
{
    public class GeneticAlgo
    {
        public Matrix[] Population;
        public int PopulationSize;
        public double[] Fitness;
        public Matrix ImageToMimic;
        public double CompletionRate;
        public Matrix BestMimic;
        public int Generation;

        private double _mutationRate;
        private int _imageToMimicWidth;
        private int _imageToMimicHeight;
        private int _tolerance;
        private int _theBestParentRate;
        private int _theBestParentSize;
        private Matrix[] _theBestParentPopulation;
        private int _newBloodSize;
        private int _newBloodRate;

        public GeneticAlgo(int populationSize, Matrix imageToMimic, double mutationRate, int tolerance, int theBestParentRate, int newBloodRate)
        {
            Generation = 0;
            _tolerance = tolerance;
            PopulationSize = populationSize;
            Population = new Matrix[populationSize];
            Fitness = new double[populationSize];
            ImageToMimic = imageToMimic;
            _mutationRate = mutationRate;
            _imageToMimicHeight = imageToMimic.Rows;
            _imageToMimicWidth = imageToMimic.Columns;
            _theBestParentRate = theBestParentRate;
            _theBestParentSize = populationSize * _theBestParentRate / 100;
            _newBloodRate = newBloodRate;
            _newBloodSize = populationSize * _newBloodRate / 100;
            _theBestParentPopulation = new Matrix[_theBestParentSize];
            CompletionRate = 0;
      

        }




        public void GenerateFirstPopulation()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                Population[i] = GenerateRandomMatrix();
            }


        }
        public Matrix GenerateRandomMatrix()
        {
            var tmp = new double[_imageToMimicHeight * _imageToMimicWidth];
            for (int j = 0; j < tmp.Length; j++)
            {
                tmp[j] = ParallelRandom.Next(256);
            }
            return new Matrix(_imageToMimicHeight, _imageToMimicWidth, tmp);
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


        private Matrix Crossover()
        {
            var indexFather = NaturalSelection();
            var indexMother = NaturalSelection();
            var child = new Matrix(_imageToMimicHeight, _imageToMimicWidth, Population[indexFather].Data);
            for (int i = 0; i < _imageToMimicHeight; i++)
            {
                for (int j = 0; j < _imageToMimicWidth; j++)
                {
                    if (ParallelRandom.Next((int)Fitness[indexFather] + (int)Fitness[indexMother]) < (int)Fitness[indexMother])
                    {
                        child[i, j] = Population[indexMother][i, j];
                    }

                    if (ParallelRandom.Next(100) < _mutationRate)
                    {
                        child[i, j] = ParallelRandom.Next(256);

                    }



                }
            }
            
            return child;
        }

        public void CalculateFitness()
        {
            for (int index = 0; index < PopulationSize; index++)
            {

                var score = 0;
                var completed = 0;
                for (int i = 0; i < ImageToMimic.Data.Length; i++)
                {
                    var tmp = Population[index];
                    if (tmp.Data[i] == ImageToMimic.Data[i])
                    {
                        score = score + 500;
                        completed++;
                    }
                    if (Math.Abs(tmp.Data[i] - ImageToMimic.Data[i]) < _tolerance)
                    {
                        score = score + _tolerance - (int)Math.Abs(tmp.Data[i] - ImageToMimic.Data[i]);
                    }
                }
                var rate = (double)(completed * 100) / (double)ImageToMimic.Data.Length;
                if (rate > CompletionRate)
                {
                    CompletionRate = rate;
                    BestMimic = new Matrix(Population[index]);
                    var tmpBitmap = BestMimic.ConvertToBitmap();
                    var fileName = @"c:\monalisa\" + Generation + ".bmp";
                    if (File.Exists(fileName)) File.Delete(fileName);
                    tmpBitmap.Save(fileName);
                    tmpBitmap.Dispose();
                }
                Fitness[index] = score;
            };
        }

        public void GenerateNewPopulation()
        {
            var tmpPopulation = new Matrix[PopulationSize];
            Parallel.For(0, PopulationSize, i =>
            {
                if (i < _theBestParentSize)
                {
                    tmpPopulation[i] = _theBestParentPopulation[i];
                }
                else if (i < _newBloodSize + _theBestParentSize)
                {
                    tmpPopulation[i] = GenerateRandomMatrix();
                }
                else
                {
                    tmpPopulation[i] = Crossover();
                }

            });


            for (int i = 0; i < PopulationSize; i++)
            {
                Population[i] = tmpPopulation[i];
            }
        }


        public void GetTheBestPopulation()
        {
            var bestScore = Fitness.OrderBy(x => x).Reverse().Take(_theBestParentSize).ToArray();
            for (int i = 0; i < _theBestParentSize; i++)
            {
                var index = Array.IndexOf(Fitness, bestScore[i]);
                _theBestParentPopulation[i] = new Matrix(Population[index]);
            }
        }


    }
}

