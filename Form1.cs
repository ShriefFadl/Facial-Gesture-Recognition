using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Initializer intialize = new Initializer();
        List<List<Neuron>> Layers = new List<List<Neuron>>();// All layers without input layer
        List<Neuron> layer; // temp # earch layer 
        int LayerNum;
        string file;
        int i = 0;
        string fn = string.Empty;
        string os = "0000";
     

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Press \"Enter\" to open an image");
            
        }
        private void showimage()
        {
            string si = i.ToString();
            if (si.Length == 1)
                si = "000" + si;
            else if (si.Length == 2)
                si = "00" + si;
            else if (si.Length == 3)
                si = "0" + si;
            fn = fn.Replace(os, si);
            os = si;

            Bitmap B = PGMUtil.ToBitmap(fn);
            pictureBox1.Image = (Image)B;
            pictureBox1.Invalidate();

            int s = fn.LastIndexOf('\\') + 1;
            this.Text = fn.Substring(s) + " (W: " + B.Width.ToString() + ", H: " + B.Height.ToString() + ")";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string fn = openFileDialog1.FileName;
            Bitmap B = PGMUtil.ToBitmap(fn);
            //this.Size = B.Size;
            pictureBox1.Image = (Image)B;
            int s = fn.LastIndexOf('\\') + 1;
            this.Text = fn.Substring(s) + " (W: " + B.Width.ToString() + ", H: " + B.Height.ToString() + ")";


           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > pictureBox1.Width / 2)
                i++;
            if (e.X < pictureBox1.Width / 2)
                i--;
            showimage();

            ;

        }
        #region add layers
        private void add_btn_Click_Click(object sender, EventArgs e)
        {
            if(LayerNum > int.Parse(Hidden_layers_txt.Text))
            {
                MessageBox.Show(" over number of layers");
                return;
            }
            layer = new List<Neuron>();

            for (int i = 0; i < int.Parse(Neurons_num_txt.Text); i++) layer.Add(new Neuron());

                Layers.Add(layer);
            
            richTextBox1.Text=  int.Parse(Neurons_num_txt.Text)+ "  Neourons have been added to hideen layer  "  + int.Parse(Hidden_layers_txt.Text);
            LayerNum++;
          
        }
        #endregion

        private void Train_bt_Click(object sender, EventArgs e)

        {

            // intialize.readTrainingData();

            //richTextBox1.Text = "training data been readed";

            //setup stopwatch and begin timing
            if (back_propagation_chk.Checked)
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();
                Back_Propagation BP = new Back_Propagation(double.Parse(mse_threshold.Text), double.Parse(Learning_rate.Text), true);
                BP.StartLearning(ref Layers);
                BP.StartTesting(ref Layers, ref _MSE, ref Mis_Matchesl, ref accuracy_label);
                timer.Stop();
                var elapsed = timer.Elapsed;
                MessageBox.Show("training time" + elapsed.ToString("mm':'ss':'fff"));
            }
            if (RBF_ch.Checked)
            {
                int count = Layers[0].Count;
                RPF rpf = new RPF(count, int.Parse(epochs_num.Text), double.Parse(Learning_rate.Text), double.Parse(mse_threshold.Text));

                var timer1 = System.Diagnostics.Stopwatch.StartNew();
                rpf.Training(ref Layers);
                //int[,] mat = rpf.Testing();
                //int tmp = mat[0, 0];
                //MessageBox.Show(" " + tmp + " ");

                timer1.Stop();
                var elapsed1 = timer1.Elapsed;
                MessageBox.Show("training time" + elapsed1.ToString("mm':'ss':'fff"));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
        }

        private void Test_bt_Click(object sender, EventArgs e)
        {
            //setup stopwatch and begin timing
            var timer = System.Diagnostics.Stopwatch.StartNew();
            //Back_Propagation BP = new Back_Propagation(double.Parse(mse_threshold.Text), double.Parse(Learning_rate.Text), true);
         
            timer.Stop();
            var elapsed = timer.Elapsed;

            // display result time
            MessageBox.Show("training time" + elapsed.ToString("mm':'ss':'fff"));


        }

        private void S_test_Click(object sender, EventArgs e)
        {
            
            Back_Propagation BP = new Back_Propagation(double.Parse(mse_threshold.Text), double.Parse(Learning_rate.Text), true);
            BP.SingleTest(ref Layers, ref singleTest_Label);
            if (singleTest_Label.Text == "closing eyes")
            {
                Bitmap B = PGMUtil.ToBitmap("Dataset\\Testing Dataset\\Closing Eyes\\BioID_0069.pgm");
                //this.Size = B.Size;
                pictureBox2.Image = (Image)B;
                int s = fn.LastIndexOf('\\') + 1;
                this.Text = fn.Substring(s) + " (W: " + B.Width.ToString() + ", H: " + B.Height.ToString() + ")";
            }
            if (singleTest_Label.Text == "looks down")
            {
                Bitmap B = PGMUtil.ToBitmap("Dataset\\Testing Dataset\\Closing Eyes\\BioID_0113.pgm");
                //this.Size = B.Size;
                pictureBox2.Image = (Image)B;
                int s = fn.LastIndexOf('\\') + 1;
                this.Text = fn.Substring(s) + " (W: " + B.Width.ToString() + ", H: " + B.Height.ToString() + ")";
            }
            if (singleTest_Label.Text == "looks front")
            {
                Bitmap B = PGMUtil.ToBitmap("Dataset\\Testing Dataset\\Looking Front\\BioID_0379.pgm");
                //this.Size = B.Size;
                pictureBox2.Image = (Image)B;
                int s = fn.LastIndexOf('\\') + 1;
                this.Text = fn.Substring(s) + " (W: " + B.Width.ToString() + ", H: " + B.Height.ToString() + ")";
            }
            if (singleTest_Label.Text == "looks left")
            {
                Bitmap B = PGMUtil.ToBitmap("Dataset\\Testing Dataset\\Looking Left\\BioID_0107.pgm");
                //this.Size = B.Size;
                pictureBox2.Image = (Image)B;
                int s = fn.LastIndexOf('\\') + 1;
                this.Text = fn.Substring(s) + " (W: " + B.Width.ToString() + ", H: " + B.Height.ToString() + ")";
            }


        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > pictureBox2.Width / 2)
                i++;
            if (e.X < pictureBox2.Width / 2)
                i--;
            showimage();
        }
    }
}
