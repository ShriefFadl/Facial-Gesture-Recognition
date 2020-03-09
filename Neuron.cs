using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
   public class Neuron
    {
        public double output;
        public double Error;
        public double[] Weights;
        public double Bias_weight;
        public double[] Inputs; 

        public void Sigmoid_Output(double a)
        {
            double sum = Bias_weight;

            for (int i = 0; i < Inputs.Length; i++)
                sum += (Inputs[i] * Weights[i]);
           
            output = 1.0 / (1.0 + Math.Exp(-a * sum));
        }
        public double SigmoidDervative(double a)//a*y*(1-y)
        {
            double tmp = a * output * (1 - output);
            return tmp;
        }
        public void FillOutput_tanh(double a)
        {
            double sum = Bias_weight;

            for (int i = 0; i < Inputs.Length; i++)
                sum += (Inputs[i] * Weights[i]);
            

            output = Math.Tanh(a * sum);
        }
        public double TanhDervative()//1-tanh(av)^2 , tanh(av) is the output
        {
            return (1 - output * output);
        }


        public double LinerActivationFunction()
        {
            double V = 0;
            for (int i = 0; i < Inputs.Length; i++)
            {
                V += (Inputs[i] * Weights[i]);
            }
            return V;
        }

        public double calculate_output()
        {
            output = LinerActivationFunction();
            return output;
        }
    }
}
