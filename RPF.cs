using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WindowsFormsApplication1
{
    public class RPF
    {
        #region insalize
        Neuron neuron = new Neuron();
        Initializer my_init = new Initializer();

        public int num_epocks, K;
        public double max_error, learningRate;
        public List<List<double>> Centroids;
        public List<double> Variance;
        public List<List<double>> trainingSamples;
        public List<List<double>> testSamples;

        K_Mean k_means;
        Random r = new Random();

        List<List<Neuron>> hd_layer = new List<List<Neuron>>();
        List<List<Neuron>> out_layer = new List<List<Neuron>>();
        double[] ee = new double[1000];
        double[] mse_l = new double[1000];

        double mse = 0;

        #endregion
        public RPF(int _k, int num_epocks, double learningRate, double max_error)
        {

            this.num_epocks = num_epocks;
            my_init.readTestingData();
            my_init.readTrainingData();
            my_init.computeTestingDataFeatures();
            my_init.computeTrainingDataFeatures();
            trainingSamples = new List<List<double>>();
            testSamples = new List<List<double>>();


            #region featch
            //////
            #region train
            for (int indx = 1; indx < 5; indx++)
            {
                for (int i = 0; i < 14; i++)
                {
                    List<double> o = new List<double>();
                    if (indx == 1)
                    {
                        for (int ii = 0; ii < 12; ++ii)
                        {
                            var tmp = my_init.c1_training_features[i][ii];
                            o.Add(tmp);
                        }
                        trainingSamples.Add(o);
                    }

                    if (indx == 2)
                    {
                        for (int ii = 0; ii < 12; ii++)
                        {
                            var tmp = my_init.c1_training_features[i][ii];
                            o.Add(tmp);
                        }
                        trainingSamples.Add(o);
                    }

                    if (indx == 3)
                    {
                        for (int ii = 0; ii < 12; ii++)
                        {
                            var tmp = my_init.c1_training_features[i][ii];
                            o.Add(tmp);
                        }
                        trainingSamples.Add(o);
                    }

                    if (indx == 4)
                    {
                        for (int ii = 0; ii < 12; ii++)
                        {
                            var tmp = my_init.c1_training_features[i][ii];
                            o.Add(tmp);
                        }
                        trainingSamples.Add(o);
                    }

                }
            }
            #endregion

            #region test
            /////
            for (int indx = 1; indx < 5; indx++)
            {
                for (int i = 0; i < 4; i++)
                {
                    List<double> o = new List<double>();
                    if (indx == 1)
                    {
                        for (int ii = 0; ii < 12; ii++)
                    {
                            var tmp = my_init.c1_testing_features[i][ii];
                            o.Add(tmp);
                        }
                        testSamples.Add(o);
                    }
                    if (indx == 2)
                    {
                        for (int ii = 0; ii < 12; ii++)
                    {
                            var tmp = my_init.c2_testing_features[i][ii];
                            o.Add(tmp);
                        }
                        testSamples.Add(o);
                    }
                    if (indx == 3)
                    {
                        for (int ii = 0; ii < 12; ii++)
                    {
                            var tmp = my_init.c3_testing_features[i][ii];
                            o.Add(tmp);
                        }
                        testSamples.Add(o);
                    }
                    if (indx == 4)
                    {
                        for (int ii = 0; ii < 12; ii++)
                    {
                            var tmp = my_init.c4_testing_features[i][ii];
                            o.Add(tmp);
                        }
                        testSamples.Add(o);
                    }
                    }
                }
            #endregion
            #endregion


            this.K = _k;
            this.max_error = max_error;
            this.learningRate = learningRate;
            Centroids = new List<List<double>>();
            int counter = _k;
            Random rnd = new Random();
            while (counter > 0)
            {
                int index = rnd.Next(trainingSamples.Count);
                Centroids.Add(trainingSamples[index]);
                counter--;
            }
            k_means = new K_Mean(ref Centroids, trainingSamples);
            Variance = k_means.GetVariance;

        }

        public void Training(ref List<List<Neuron>> Layers)
        {
            double[] wights = new double[K];

            for (int E = 0; E < num_epocks; E++)
            {
                double Error = 0;
                for (int index = 0; index < trainingSamples.Count; index++)
                {
                    List<double> Gaussian = new List<double>();

                    for (int i = 0; i < Variance.Count; i++)
                    {
                        double R_Sqr = 0;

                        for (int col = 0; col < trainingSamples[index].Count; col++)
                        {
                            double r = Math.Abs(trainingSamples[index][col] - Centroids[i][col]);
                            R_Sqr += (r * r);
                        }

                        Gaussian.Add(Math.Exp((-1 * R_Sqr) / (2 * Variance[i] * Variance[i])));//exp(−𝑟2/2*𝜎2)
                    }
                    Random R = new Random();
                    int desir = 0;

                    for (int ii = 0; ii < K; ii++)
                    {
                        wights[ii] = R.NextDouble();
                    }


                    int tmp = trainingSamples.Count;


                    while (tmp != 0)
                    {
                        for (int i = 0; i < K; i++)//hd neurons
                        {

                            for (int ii = 0; ii < 4; ii++)//out neurons
                            {

                                double net = wights[i] * Gaussian[i];

                                if (net > 1)
                                    desir = 1;
                                else
                                    desir = 0;


                                Error = desir - wights[i] * Gaussian[i];
                                wights[i] += learningRate * Error * Gaussian[i];
                               

                            }
                            if (i == K - 1)
                            {
                                File.WriteAllText("bin", string.Join(",", wights.Select(o => o.ToString()).ToArray()));
                            }
                            ee[i] = Error;
                        }

                        mse_l[E] = Math.Pow(ee[E], 2);
                        tmp--;
                    }


                }
                //random weghts on first inpout of hidden layer then error then update weghts 
                //weights  *gaussian
                //error
                mse = ee.Average();
                if (mse < max_error)
                    return;

            }


        }
        public int[,] Testing()
        {
            int[,] matrix = new int[3, 4];
            double Error = 0;
            double[] wights = new double[K];
            List<double> out_puts = new List<double>();

            for (int index = 0; index < testSamples.Count; index++)
            {
                List<double> Gaussian = new List<double>();

                for (int i = 0; i < Variance.Count; i++)
                {
                    double R_Sqr = 0;

                    for (int col = 0; col < testSamples[index].Count; col++)
                    {
                        double r = Math.Abs(testSamples[index][col] - Centroids[i][col]);
                        R_Sqr += (r * r);
                    }

                    Gaussian.Add(Math.Exp((-1 * R_Sqr) / (2 * Variance[i] * Variance[i])));
                }

               string tmp= File.ReadAllText("bin");

                double[] wighs = Array.ConvertAll(tmp.Split(','), new Converter<string, double>(Double.Parse));
                for (int i = 0; i < Gaussian.Count; i++)
                {
                    out_puts.Add(wighs[i] * Gaussian[i]);
                        }
                int actualClass = checkClass(out_puts);
                int desiredClass = index / 4;
                if (desiredClass == 0)
                    desiredClass++;
                if (actualClass == -1)
                    actualClass = 3;
                while (actualClass > 4)
                {
                    actualClass /= 4;
                    if (index == 0)
                        actualClass = actualClass % 4;
                }



                    matrix[desiredClass, actualClass]++;

            }



            return matrix;
        }

        private int checkClass(List<double> actualOutput)
        {
            int index = 0;
            double max = 0;
            for (int i = 0; i < actualOutput.Count; ++i)
            {
                if (actualOutput[i] > max)
                {
                    max = actualOutput[i];
                    index = i;
                }
            }

            int counter = 0;
            for (int i = 0; i < actualOutput.Count; ++i)
            {
                if (max == actualOutput[i])
                {
                    counter++;
                }
                else
                    break;
            }
            if (counter == actualOutput.Count)
                return -1;
            return index;
        }
    }
}




