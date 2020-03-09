using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

namespace WindowsFormsApplication1
{
   
    class Back_Propagation
    {

       

        #region attributes
        double MSE = double.MaxValue, threshould, a, learning_rate, epochs = 0;
        bool tanh;
        Random R = new Random();
        Initializer my_init = new Initializer();
     
        private Process process;
        public Back_Propagation(double threshould, double learning_rate, bool tanh)
        {
            
            this.learning_rate = learning_rate;
            this.threshould = threshould;
            this.tanh = tanh;
            my_init.readTrainingData();
            my_init.readTestingData();
            my_init.computeTestingDataFeatures();
            my_init.computeTrainingDataFeatures();

        }
        #endregion

        #region methods
       

        #region learning and error
        public void StartLearning(ref List<List<Neuron>> Layers)
        {
           
            
            //add  layer of 4 Neurons
            List<Neuron> layer;
            layer = new List<Neuron>();
            for (int i = 0; i < 4; i++) layer.Add(new Neuron());
            Layers.Add(layer);
            

            while (MSE > threshould && epochs < 10000/*max*/)
            {
                MSE = 0;
                epochs++;

                //Class 1
                for (int y = 0; y <my_init.c1_training_features.Count; y++)
                {
                    forward(ref Layers, 1, true, true, false);
                
                    Backward(ref Layers, 1, false);
                    feed_forward(ref Layers);
                }
                // Class 2
                for (int y = 0; y <  my_init.c2_training_features.Count; y++)
                {
                    forward(ref Layers,  2, true, true, false);
                    Backward(ref Layers,  2, false);
                    feed_forward(ref Layers);
                }
                // Class 3
                for (int y = 0; y <  my_init.c3_training_features.Count; y++)
                {
                    forward(ref Layers,3, true, true, false );
                    Backward(ref Layers, 3, false);
                    feed_forward(ref Layers);
                }
                //Class 4
                for (int y = 0; y <  my_init.c4_training_features.Count; y++)
                {
                    forward(ref Layers, 4, true, true, false);
                    Backward(ref Layers, 4, false);
                    feed_forward(ref Layers);
                }
               
                // Calculate MSE
                Calculate_MSE(ref Layers);
                Console.WriteLine(epochs + "   " + MSE);
            }
        }
        public void Calculate_MSE(ref List<List<Neuron>> Layers)
        {
            double tmp;

            //Get MSE in Class 1 
            for (int y = 0; y < my_init.c1_testing_features.Count; y++)
            {

                forward(ref Layers, 1, false, true, false);
                tmp = 0;

                for (int i = 0; i < Layers[Layers.Count - 1].Count; i++)
                {
                    if (i == 0)
                        tmp = (1.0 - Layers[Layers.Count - 1][i].output);
                    else
                        tmp = (0.0 - Layers[Layers.Count - 1][i].output);

                    MSE += (tmp * tmp) / (double)2.0;
                }
            }
            // Get MSE in Class 2

            for (int y = 0; y <my_init.c2_testing_features.Count; y++)
            {

                forward(ref Layers, 2, false, true, false);
                tmp = 0;

                for (int i = 0; i < Layers[Layers.Count - 1].Count; i++)
                {
                    if (i == 1)
                        tmp = (1.0 - Layers[Layers.Count - 1][i].output);
                    else
                        tmp = (0.0 - Layers[Layers.Count - 1][i].output);

                    MSE += (tmp * tmp) / (double)2.0;
                }
            }
            // Get MSE in Class 3 

            for (int y = 0; y <  my_init.c3_testing_features.Count; y++)
            {

                forward(ref Layers, 3, false, true, false);
                tmp = 0;

                for (int i = 0; i < Layers[Layers.Count - 1].Count; i++)
                {
                    if (i == 2)
                        tmp = (1.0 - Layers[Layers.Count - 1][i].output);
                    else
                        tmp = (0.0 - Layers[Layers.Count - 1][i].output);

                    MSE += (tmp * tmp) / (double)2.0;
                }
            }
            // Get MSE in Class 4 

            for (int y = 0; y <  my_init.c4_testing_features.Count; y++)
            {

                forward(ref Layers, 4, false, true, false);

                tmp = 0;

                for (int i = 0; i < Layers[Layers.Count - 1].Count; i++)
                {
                    if (i == 3)
                        tmp = (1.0 - Layers[Layers.Count - 1][i].output);
                    else
                        tmp = (0.0 - Layers[Layers.Count - 1][i].output);

                    MSE += (tmp * tmp) / (double)2.0;
                }
            }

            

         
        }
        #endregion


        public void forward(ref List<List<Neuron>> Layers, int Class, bool training, bool sigmoid, bool tanh)
        {

            // featching input layer for testing and training

            for (int i = 0; i < Layers[0].Count; i++)
            {
                
                    Layers[0][i].Inputs = new double[20];
                    Layers[0][i].Weights = new double[20];
                    Layers[0][i].Bias_weight = (double)R.NextDouble();
                


                int indx = 0;
                if (training)// if it training  
                {
                    for (int ii = 0; ii < 12; ii++)
                    {
                        if (Class == 1)
                            Layers[0][i].Inputs[indx] = my_init.c1_training_features[0][ii];
                        else if (Class == 2)
                            Layers[0][i].Inputs[indx] = my_init.c2_training_features[0][ii];
                        else if (Class == 3)
                            Layers[0][i].Inputs[indx] = my_init.c3_training_features[0][ii];
                        else if (Class == 4)
                            Layers[0][i].Inputs[indx] = my_init.c4_training_features[0][ii];
                    }
                }
                else
                
                    for (int ii = 0; ii < 12; ii++)
                    {
                        if (Class == 1)
                            Layers[0][i].Inputs[indx] = my_init.c1_testing_features[0][ii];
                        else if (Class == 2)
                            Layers[0][i].Inputs[indx] = my_init.c2_testing_features[0][ii];
                        else if (Class == 3)
                            Layers[0][i].Inputs[indx] = my_init.c3_testing_features[0][ii];
                        else if (Class == 4)
                            Layers[0][i].Inputs[indx] = my_init.c4_testing_features[0][ii];
                    }


                




                if (sigmoid)
                    Layers[0][i].Sigmoid_Output(a);
                else if (tanh)
                    Layers[0][i].FillOutput_tanh(a);

            }

            for (int i = 1; i < Layers.Count; i++)
            {
                for (int Z = 0; Z < Layers[i].Count; Z++)
                {
                    if (training)
                    {
                        Layers[i][Z].Inputs = new double[Layers[i - 1].Count];
                        Layers[i][Z].Weights = new double[Layers[i - 1].Count];
                        Layers[i][Z].Bias_weight = (double)R.NextDouble();
                    }
                    /*
                    else
                    {
                        string tmp = File.ReadAllText("bin back");
                        Layers[i][Z].Weights = Array.ConvertAll(tmp.Split(','), new Converter<string, double>(Double.Parse));
                    }*/

                    for (int ii = 0; ii < Layers[i - 1].Count; ii++)
                    {
                        Layers[i][Z].Inputs[ii] = Layers[i - 1][ii].output;
                        if (training)
                        {
                            Layers[i][Z].Weights[ii] = (double)R.NextDouble();
                        }
                        

                    }
                    if (sigmoid)
                        Layers[i][Z].Sigmoid_Output(a);
                    else
                        Layers[i][Z].FillOutput_tanh(a);
                }
            }


        }

        public void Backward(ref List<List<Neuron>> Layers, int Class, bool sigmoid)
        {
            //error for first output  
            for (int i = 0; i < Layers[Layers.Count - 1].Count; i++)
            {
                if (sigmoid)
                {
                    if (Class == 1 && i == 0) //(d)*f'(v)
                        Layers[Layers.Count - 1][i].Error = (1.0 - Layers[Layers.Count - 1][i].output) * Layers[Layers.Count - 1][i].SigmoidDervative(a);
                    else if (Class == 2 && i == 1)
                        Layers[Layers.Count - 1][i].Error = (1.0 - Layers[Layers.Count - 1][i].output) * Layers[Layers.Count - 1][i].SigmoidDervative(a);
                    else if (Class == 3 && i == 2)
                        Layers[Layers.Count - 1][i].Error = (1.0 - Layers[Layers.Count - 1][i].output) * Layers[Layers.Count - 1][i].SigmoidDervative(a);
                    else if (Class == 4 && i == 3)
                        Layers[Layers.Count - 1][i].Error = (1.0 - Layers[Layers.Count - 1][i].output) * Layers[Layers.Count - 1][i].SigmoidDervative(a);
                    else
                        Layers[Layers.Count - 1][i].Error = (0.0 - Layers[Layers.Count - 1][i].output) * Layers[Layers.Count - 1][i].SigmoidDervative(a);
                }
                else
                {

                    if (Class == 1 && i == 0) //(d)*f'(v)
                        Layers[Layers.Count - 1][i].Error = (1.0 - Layers[Layers.Count - 1][i].output) * Layers[Layers.Count - 1][i].TanhDervative();
                    else if (Class == 2 && i == 1)
                        Layers[Layers.Count - 1][i].Error = (1.0 - Layers[Layers.Count - 1][i].output) * Layers[Layers.Count - 1][i].TanhDervative();
                    else if (Class == 3 && i == 2)
                        Layers[Layers.Count - 1][i].Error = (1.0 - Layers[Layers.Count - 1][i].output) * Layers[Layers.Count - 1][i].TanhDervative();
                    else if (Class == 4 && i == 3)
                        Layers[Layers.Count - 1][i].Error = (1.0 - Layers[Layers.Count - 1][i].output) * Layers[Layers.Count - 1][i].TanhDervative();
                    else
                        Layers[Layers.Count - 1][i].Error = (0.0 - Layers[Layers.Count - 1][i].output) * Layers[Layers.Count - 1][i].TanhDervative();

                }
            }
            //ba2y el layers

            //calculate signal error for each neuron in each layer
            for (int i = Layers.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < Layers[i].Count; j++)
                {
                    Layers[i][j].Error = 0;
                    for (int k = 0; k < Layers[i + 1].Count; k++)
                    {
                        Layers[i][j].Error += (Layers[i + 1][k].Weights[j] * Layers[i + 1][k].Error);
                    }
                    if (sigmoid)
                        Layers[i][j].Error *= Layers[i][j].SigmoidDervative(a);
                    else
                        Layers[i][j].Error *= Layers[i][j].TanhDervative();

                }
            }



        }
        #region signal the error and Update weights forwarding
        public void feed_forward(ref List<List<Neuron>> Layers)
        {
            for (int i = 0; i < Layers.Count(); i++)
            {
                for (int j = 0; j < Layers[i].Count(); j++)
                {   //temp
                    Layers[i][j].Bias_weight += (learning_rate * Layers[i][j].Error);
                    for (int k = 0; k < Layers[i][j].Weights.Count(); k++)
                    {
                        //update weight new = old+temp
                        Layers[i][j].Weights[k] += (learning_rate * Layers[i][j].Inputs[k] * Layers[i][j].Error);
                      /*  if (k== Layers[i][j].Weights.Count()- 1)
                        {
                            }*/
                    }
                }
              
            }
          //  File.WriteAllText("bin back", string.Join(",", Layers[Layers.Count()][Layers.Count()-1].Weights.Select(o => o.ToString()).ToArray()));


        }
        #endregion

        public void StartTesting(ref List<List<Neuron>> Layers, ref Label _MSE, ref Label Mis_Matchesl, ref Label accuracy_label)
        {

            double Matching_samples = 0;
            double tmp = 0, indx = 1;
          //  my_init.computeTestingDataFeatures();
          

            for (int y = 0; y <5; y++) 
            {
                forward(ref Layers, 1, false, true, false);
                tmp = 0;
                indx = 0;

                for (int i = 0; i < Layers[Layers.Count - 1].Count; i++)
                {
                    if (Layers[Layers.Count - 1][i].output > tmp)
                    {
                        tmp = Layers[Layers.Count - 1][i].output;
                        indx = i;
                    }

                }
                if (indx == 0) Matching_samples++;
            }
           
            for (int y = 0; y < 5; y++)
            {
                forward(ref Layers, 2, false, true, false);
                tmp = 0;
                indx = 0;
                for (int i = 0; i < Layers[Layers.Count - 1].Count; i++)
                {
                    if (Layers[Layers.Count - 1][i].output > tmp)
                    {
                        tmp = Layers[Layers.Count - 1][i].output;
                        indx = i;
                    }
                }
                if (indx == 1) Matching_samples++;
            }
            
            for (int y = 0; y < 5; y++)
            {
                forward(ref Layers, 3,  false, true, false);
                tmp = 0;
                indx = 0;
                for (int i = 0; i < Layers[Layers.Count - 1].Count; i++)
                {
                    if (Layers[Layers.Count - 1][i].output > tmp)
                    {
                        tmp = Layers[Layers.Count - 1][i].output;
                        indx = i;
                    }

                }
                if (indx == 2) Matching_samples++;
            }
            
            for (int y = 0; y < 6; y++)
            {
                forward(ref Layers, 4, false, true, false);
                tmp = 0;
                indx = 0;
                for (int i = 0; i < Layers[Layers.Count - 1].Count; i++)
                {
                    if (Layers[Layers.Count - 1][i].output > tmp)
                    {
                        tmp = Layers[Layers.Count - 1][i].output;
                        indx = i;
                    }
                }
                if (indx == 3) Matching_samples++;
            }
        
            // results
           double MisMatches_sambles = 20/*all testing images*/ - Matching_samples;

            Mis_Matchesl.Text = "Mismatching  are " + MisMatches_sambles.ToString();
            Matching_samples /= 20.0;
            Matching_samples *= 100;
            accuracy_label.Text = "Accuracy IS " + Matching_samples.ToString() + " %";
            _MSE.Text = "MSE IS " + MSE.ToString();
        }

        public void SingleTest(ref List<List<Neuron>> Layers, ref Label singleTest_Label)
            {

            for (int i = 1; i < 5; i++)
            {
                forward(ref Layers, i, false, false, true);
            }
                double tmp = 0;
                double indx = 0;

                for (int i = 0; i < Layers[Layers.Count - 1].Count; i++)
                {
                    if (/*out put layer data*/Layers[Layers.Count - 1][i].output > tmp)// max one that look close to the tmp
                    {
                        tmp = Layers[Layers.Count - 1][i].output;
                        indx = i;
                    }

                }

            if (indx == 0)
            {
                performAction(1);
                singleTest_Label.Text = "closing eyes";
            }
            else if (indx == 1)
            {
                performAction(2);
                singleTest_Label.Text = "looks down";
            }
            else if (indx == 2)
            {
                performAction(3);
                singleTest_Label.Text = "looks front";
            }

            else

                performAction(4);
                 singleTest_Label.Text = "looks left";
            
           
        }

        #region process handling
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public void performAction(int sample_class)
        {
            const int SW_SHOWMINIMIZED = 2;
            const int SW_RESTORE = 9;

         
            if (sample_class == 1)
            {
                foreach (var process in Process.GetProcessesByName("Notepad.exe"))
                {
                    process.Kill();
                }
            
            }
            else if (sample_class == 2)
            {
                
                IntPtr hWnd = FindWindow("Notepad", "Untitled - Notepad");
                if (!hWnd.Equals(IntPtr.Zero))
                    ShowWindowAsync(hWnd, SW_SHOWMINIMIZED);
            }
            else if (sample_class == 3)
            {
               
                process = Process.Start("Notepad");
            }
            else
            {
                
                var processes = Process.GetProcessesByName("Notepad.exe");

                IntPtr hWnd = FindWindow("Notepad", "Untitled - Notepad");
                if (!hWnd.Equals(IntPtr.Zero))
                    ShowWindowAsync(hWnd, SW_RESTORE);
            }

         
        }
        #endregion
        #endregion
    }







}


