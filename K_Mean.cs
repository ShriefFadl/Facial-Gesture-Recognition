using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class K_Mean
    {

        public List<List<double>> Centroids;//[#Cluster][#Features (mean)]
        public List<List<int>> Groups;
        public List<double> Variance;
        public List<List<double>> X;//features after calclating the eu_dist
        public int K;//#hiden neurons=centroids 
        public List<double> GetVariance
        {
            get { return Variance; }
        }

        public K_Mean(ref List<List<double>> Centroids, List<List<double>> X)
        {
            this.X = X;
            this.Centroids = Centroids;
            this.K = Centroids.Count;
            Groups = new List<List<int>>();
            for (int i = 0; i < K; i++)
            {
                Groups.Add(new List<int>());
            }
            Calculate();
            CalculateVariance();
          
        }
        #region calculating min dist and variance 
        public void Calculate() // indexing of minimum distance 
        {
            #region min_distance
            List<int> D = new List<int>();
                for (int i = 0; i < X.Count; i++)
                {
                    double MinD = double.MaxValue;
                    int MinIndex = 0;
                    for (int j = 0; j < K; j++)
                    {
                        double d = 0;
                        for (int k = 0; k < X[i].Count; k++)
                        {
                            d += Math.Pow((Centroids[j][k] - X[i][k]), 2);
                        }
                        d = Math.Sqrt(d);
                        if (d < MinD)
                        {
                            MinD = d;
                            MinIndex = j;
                        }
                    }
                    D.Add(MinIndex);

                }
            #endregion

            #region new C
            List<List<double>> NewCentroids = new List<List<double>>();
                for (int i = 0; i < K; i++)
                {
                    Groups[i].Clear();
                    List<double> Row = new List<double>();
                    int S = X[0].Count;
                    while (S-- > 0)
                    {
                        Row.Add(0);
                    }
                    int counter = 0;
                    for (int j = 0; j < D.Count; j++)
                    {
                        if (D[j] == i)
                        {
                            for (int col = 0; col < Row.Count; col++)
                            {
                                Row[col] += X[j][col];
                            }
                            Groups[i].Add(j);
                            counter++;
                        }
                    }
                    for (int col = 0; col < Row.Count; col++)
                    {
                        Row[col] /= counter;
                    }
                    NewCentroids.Add(Row);
                }
            #endregion

            FillCentroids(NewCentroids);
            

        }
        public void CalculateVariance()
        {
            Variance = new List<double>();
            for (int i = 0; i < Groups.Count; i++)
            {
                double V = 0;
                for (int j = 0; j < Groups[i].Count; j++)
                {
                    int Index = Groups[i][j];
                    double Sum = 0;
                    for (int col = 0; col < X[0].Count; col++)
                    {
                        Sum += Math.Pow((X[Index][col] - Centroids[i][col]), 2);//USING POW AND sqrt to avoid -ve
                    }
                    V += Math.Sqrt(Sum);
                }

                V /= Groups[i].Count;//variance of center(i)
                Variance.Add(V);
            }
        }
        public void FillCentroids(List<List<double>> NewCentroids)
        {
            for (int i = 0; i < Centroids.Count; i++)
            {
                for (int j = 0; j < Centroids[0].Count; j++)
                {
                    Centroids[i][j] = NewCentroids[i][j];
                }
            }
        }
        #endregion
    }
}
