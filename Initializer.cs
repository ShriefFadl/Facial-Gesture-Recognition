using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WindowsFormsApplication1
{
    
        public class Initializer
        {
        //4 classes to train C1_down,C2_left, C3_front and C4_clossing eyes
        #region positions 
        public List<List<Tuple<double, double>>> c1_training_positions, c2_training_positions, c3_training_positions, c4_training_positions;
        public List<List<Tuple<double, double>>> c1_testing_positions, c2_testing_positions, c3_testing_positions, c4_testing_positions;
        #endregion

        #region features
        public List<List<double>> c1_training_features, c2_training_features, c3_training_features, c4_training_features;
        public List<List<double>> c1_testing_features, c2_testing_features, c3_testing_features, c4_testing_features;
        #endregion

        public Initializer()
            {
                c1_training_positions = new List<List<Tuple<double, double>>>();
                c2_training_positions = new List<List<Tuple<double, double>>>();
                c3_training_positions = new List<List<Tuple<double, double>>>();
                c4_training_positions = new List<List<Tuple<double, double>>>();

                c1_testing_positions = new List<List<Tuple<double, double>>>();
                c2_testing_positions = new List<List<Tuple<double, double>>>();
                c3_testing_positions = new List<List<Tuple<double, double>>>();
                c4_testing_positions = new List<List<Tuple<double, double>>>();

                c1_training_features = new List<List<double>>();
                c2_training_features = new List<List<double>>();
                c3_training_features = new List<List<double>>();
                c4_training_features = new List<List<double>>();

                c1_testing_features = new List<List<double>>();
                c2_testing_features = new List<List<double>>();
                c3_testing_features = new List<List<double>>();
                c4_testing_features = new List<List<double>>();

            //first 15 positions
                for (int i = 0; i < 15; i++)
                {
                //testing data
                    if (i < 5)
                    {
                        c1_testing_positions.Add(new List<Tuple<double, double>>());
                        c2_testing_positions.Add(new List<Tuple<double, double>>());
                        c3_testing_positions.Add(new List<Tuple<double, double>>());
                        c4_testing_positions.Add(new List<Tuple<double, double>>());

                        c1_testing_features.Add(new List<double>());
                        c2_testing_features.Add(new List<double>());
                        c3_testing_features.Add(new List<double>());
                        c4_testing_features.Add(new List<double>());
                    }

                    c1_training_positions.Add(new List<Tuple<double, double>>());
                    c2_training_positions.Add(new List<Tuple<double, double>>());
                    c3_training_positions.Add(new List<Tuple<double, double>>());
                    c4_training_positions.Add(new List<Tuple<double, double>>());

                    c1_training_features.Add(new List<double>());
                    c2_training_features.Add(new List<double>());
                    c3_training_features.Add(new List<double>());
                    c4_training_features.Add(new List<double>());
                }
            }


        # region read files_positions 
        public void readTrainingData()
        {
            string folderPath;
            int sample_index;

            //Read Training Dataset Class 1
            folderPath = @"Dataset\Training Dataset\Closing Eyes";
            sample_index = 0;
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.pts"))
            {
                string[] contents = File.ReadAllLines(file);
                for (int i = 3; i < contents.Length - 1; i++)
                {
                    string[] tmp = contents[i].Split(' ');
                    Tuple<double, double> position = new Tuple<double, double>(double.Parse(tmp[0]), double.Parse(tmp[1]));
                    c1_training_positions[sample_index].Add(position);
                }
                sample_index++;
            }

            //Read Training Dataset Class 2
            folderPath = @"Dataset\Training Dataset\Looking Down";
            sample_index = 0;
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.pts"))
            {
                string[] contents = File.ReadAllLines(file);
                for (int i = 3; i < contents.Length - 1; i++)
                {
                    string[] tmp = contents[i].Split(' ');
                    Tuple<double, double> position = new Tuple<double, double>(double.Parse(tmp[0]), double.Parse(tmp[1]));
                    c2_training_positions[sample_index].Add(position);
                }
                sample_index++;
            }

            //Read Training Dataset Class 3
            folderPath = @"Dataset\Training Dataset\Looking Front";
            sample_index = 0;
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.pts"))
            {
                string[] contents = File.ReadAllLines(file);
                for (int i = 3; i < contents.Length - 1; i++)
                {
                    string[] tmp = contents[i].Split(' ');
                    Tuple<double, double> position = new Tuple<double, double>(double.Parse(tmp[0]), double.Parse(tmp[1]));
                    c3_training_positions[sample_index].Add(position);
                }
                sample_index++;
            }

            //Read Training Dataset Class 4
            folderPath = @"Dataset\Training Dataset\Looking Left";
            sample_index = 0;
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.pts"))
            {
                string[] contents = File.ReadAllLines(file);
                for (int i = 3; i < contents.Length - 1; i++)
                {
                    string[] tmp = contents[i].Split(' ');
                    Tuple<double, double> position = new Tuple<double, double>(double.Parse(tmp[0]), double.Parse(tmp[1]));
                    c4_training_positions[sample_index].Add(position);
                }
                sample_index++;
            }
        }
        public void readTestingData()
        {
            string folderPath;
            int sample_index;

            //Read Testing Dataset Class 1
            folderPath = @"Dataset\Testing Dataset\Closing Eyes";
            sample_index = 0;
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.pts"))
            {
                string[] contents = File.ReadAllLines(file);
                for (int i = 3; i < contents.Length - 1; i++)
                {
                    string[] tmp = contents[i].Split(' ');
                    Tuple<double, double> position = new Tuple<double, double>(double.Parse(tmp[0]), double.Parse(tmp[1]));
                    c1_testing_positions[sample_index].Add(position);
                }
                sample_index++;
            }

            //Read Testing Dataset Class 2
            folderPath = @"Dataset\Testing Dataset\Looking Down";
            sample_index = 0;
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.pts"))
            {
                string[] contents = File.ReadAllLines(file);
                for (int i = 3; i < contents.Length - 1; i++)
                {
                    string[] tmp = contents[i].Split(' ');
                    Tuple<double, double> position = new Tuple<double, double>(double.Parse(tmp[0]), double.Parse(tmp[1]));
                    c2_testing_positions[sample_index].Add(position);
                }
                sample_index++;
            }

            //Read Testing Dataset Class 3
            folderPath = @"Dataset\Testing Dataset\Looking Front";
            sample_index = 0;
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.pts"))
            {
                string[] contents = File.ReadAllLines(file);
                for (int i = 3; i < contents.Length - 1; i++)
                {
                    string[] tmp = contents[i].Split(' ');
                    Tuple<double, double> position = new Tuple<double, double>(double.Parse(tmp[0]), double.Parse(tmp[1]));
                    c3_testing_positions[sample_index].Add(position);
                }
                sample_index++;
            }

            //Read Testing Dataset Class 4
            folderPath = @"Dataset\Testing Dataset\Looking Left";
            sample_index = 0;
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.pts"))
            {
                string[] contents = File.ReadAllLines(file);
                for (int i = 3; i < contents.Length - 1; i++)
                {
                    string[] tmp = contents[i].Split(' ');
                    Tuple<double, double> position = new Tuple<double, double>(double.Parse(tmp[0]), double.Parse(tmp[1]));
                    c4_testing_positions[sample_index].Add(position);
                }
                sample_index++;
            }
        }
        #endregion


        public void computeTrainingDataFeatures()
            {
                //Class 1
                for (int i = 0; i < c1_training_positions.Count; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        //1 8 10 12 13 15 16
                        if (j == 14 || BadFeature(j + 1))
                            continue;
                        //featuer 14 is the tip of nose
                        double feature = euclideanDistance(c1_training_positions[i][j], c1_training_positions[i][14]);
                        c1_training_features[i].Add(feature);
                    }
                }

                //Class 2
                for (int i = 0; i < c2_training_positions.Count; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j == 14 || BadFeature(j + 1))
                            continue;
                        double feature = euclideanDistance(c2_training_positions[i][j], c2_training_positions[i][14]);
                        c2_training_features[i].Add(feature);
                    }
                }

                //Class 3
                for (int i = 0; i < c3_training_positions.Count; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j == 14 || BadFeature(j + 1))
                            continue;
                        double feature = euclideanDistance(c3_training_positions[i][j], c3_training_positions[i][14]);
                        c3_training_features[i].Add(feature);
                    }
                }

                //Class 4
                for (int i = 0; i < c4_training_positions.Count; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j == 14 || BadFeature(j + 1))
                            continue;
                        double feature = euclideanDistance(c4_training_positions[i][j], c4_training_positions[i][14]);
                        c4_training_features[i].Add(feature);
                    }
                }
            }

        public void computeTestingDataFeatures()
            {
                //Class 1
                for (int i = 0; i < c1_testing_positions.Count; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j == 14 || BadFeature(j + 1))
                            continue;
                        double feature = euclideanDistance(c1_testing_positions[i][j], c1_testing_positions[i][14]);
                        c1_testing_features[i].Add(feature);
                    }
                }

                //Class 2
                for (int i = 0; i < c2_testing_positions.Count; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j == 14 || BadFeature(j + 1))
                            continue;
                        double feature = euclideanDistance(c2_testing_positions[i][j], c2_testing_positions[i][14]);
                        c2_testing_features[i].Add(feature);
                    }
                }

                //Class 3
                for (int i = 0; i < c3_testing_positions.Count; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j == 14 || BadFeature(j + 1))
                            continue;

                        double feature = euclideanDistance(c3_testing_positions[i][j], c3_testing_positions[i][14]);
                        c3_testing_features[i].Add(feature);
                    }
                }

                //Class 4
                for (int i = 0; i < c4_testing_positions.Count; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (j == 14 || BadFeature(j + 1))
                            continue;

                        double feature = euclideanDistance(c4_testing_positions[i][j], c4_testing_positions[i][14]);
                        c4_testing_features[i].Add(feature);
                    }
                }
            }

        public bool BadFeature(int feature_num)
        {
            // non careing positions
            /*15 = right nostril
            16 = left nsostril
            17 = center point on outer edge of upper lip
            18 = center point on outer edge of lower lip
            19 = tip of chin*/


            if (feature_num >= 16)
                feature_num--;
            int[] arr = { 1, 8, 10, 12, 13, 15, 16 };
            for (int i = 0; i < arr.Length; i++)
                if (feature_num == arr[i])
                    return true;
            return false;
        }

        public double euclideanDistance(Tuple<double, double> t1, Tuple<double, double> t2)
        {
            return Math.Sqrt(Math.Pow(t1.Item1 - t2.Item1, 2) + Math.Pow(t1.Item2 - t2.Item2, 2));
        }

    }
}
