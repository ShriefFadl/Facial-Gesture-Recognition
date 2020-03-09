namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Learning_rate = new System.Windows.Forms.TextBox();
            this.epochs_num = new System.Windows.Forms.TextBox();
            this.mse_threshold = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.add_btn_Click = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Neurons_num_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Hidden_layers_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.back_propagation_chk = new System.Windows.Forms.CheckBox();
            this.RBF_ch = new System.Windows.Forms.CheckBox();
            this.Train_bt = new System.Windows.Forms.Button();
            this.Test_bt = new System.Windows.Forms.Button();
            this.S_test = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.accuracy_label = new System.Windows.Forms.Label();
            this.Mis_Matchesl = new System.Windows.Forms.Label();
            this._MSE = new System.Windows.Forms.Label();
            this.singleTest_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(68, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Learning rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "#epochs ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "MSE threshhold";
            // 
            // Learning_rate
            // 
            this.Learning_rate.Location = new System.Drawing.Point(106, 32);
            this.Learning_rate.Name = "Learning_rate";
            this.Learning_rate.Size = new System.Drawing.Size(100, 20);
            this.Learning_rate.TabIndex = 5;
            // 
            // epochs_num
            // 
            this.epochs_num.Location = new System.Drawing.Point(106, 64);
            this.epochs_num.Name = "epochs_num";
            this.epochs_num.Size = new System.Drawing.Size(100, 20);
            this.epochs_num.TabIndex = 6;
            // 
            // mse_threshold
            // 
            this.mse_threshold.Location = new System.Drawing.Point(106, 90);
            this.mse_threshold.Name = "mse_threshold";
            this.mse_threshold.Size = new System.Drawing.Size(100, 20);
            this.mse_threshold.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.add_btn_Click);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Neurons_num_txt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Hidden_layers_txt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mse_threshold);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.epochs_num);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Learning_rate);
            this.groupBox1.Location = new System.Drawing.Point(264, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 216);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General params ";
            // 
            // add_btn_Click
            // 
            this.add_btn_Click.Location = new System.Drawing.Point(21, 185);
            this.add_btn_Click.Name = "add_btn_Click";
            this.add_btn_Click.Size = new System.Drawing.Size(75, 23);
            this.add_btn_Click.TabIndex = 14;
            this.add_btn_Click.Text = "Add";
            this.add_btn_Click.UseVisualStyleBackColor = true;
            this.add_btn_Click.Click += new System.EventHandler(this.add_btn_Click_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Neurons number";
            // 
            // Neurons_num_txt
            // 
            this.Neurons_num_txt.Location = new System.Drawing.Point(106, 151);
            this.Neurons_num_txt.Name = "Neurons_num_txt";
            this.Neurons_num_txt.Size = new System.Drawing.Size(100, 20);
            this.Neurons_num_txt.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Layer number";
            // 
            // Hidden_layers_txt
            // 
            this.Hidden_layers_txt.Location = new System.Drawing.Point(106, 116);
            this.Hidden_layers_txt.Name = "Hidden_layers_txt";
            this.Hidden_layers_txt.Size = new System.Drawing.Size(100, 20);
            this.Hidden_layers_txt.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Expected _classification";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(68, 185);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(131, 83);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Actual _classification";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(264, 260);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(268, 96);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // back_propagation_chk
            // 
            this.back_propagation_chk.AutoSize = true;
            this.back_propagation_chk.Location = new System.Drawing.Point(574, 104);
            this.back_propagation_chk.Name = "back_propagation_chk";
            this.back_propagation_chk.Size = new System.Drawing.Size(109, 17);
            this.back_propagation_chk.TabIndex = 15;
            this.back_propagation_chk.Text = "back propagation";
            this.back_propagation_chk.UseVisualStyleBackColor = true;
            // 
            // RBF_ch
            // 
            this.RBF_ch.AutoSize = true;
            this.RBF_ch.Location = new System.Drawing.Point(574, 143);
            this.RBF_ch.Name = "RBF_ch";
            this.RBF_ch.Size = new System.Drawing.Size(47, 17);
            this.RBF_ch.TabIndex = 16;
            this.RBF_ch.Text = "RBF";
            this.RBF_ch.UseVisualStyleBackColor = true;
            // 
            // Train_bt
            // 
            this.Train_bt.Location = new System.Drawing.Point(620, 258);
            this.Train_bt.Name = "Train_bt";
            this.Train_bt.Size = new System.Drawing.Size(75, 23);
            this.Train_bt.TabIndex = 17;
            this.Train_bt.Text = "Train";
            this.Train_bt.UseVisualStyleBackColor = true;
            this.Train_bt.Click += new System.EventHandler(this.Train_bt_Click);
            // 
            // Test_bt
            // 
            this.Test_bt.Location = new System.Drawing.Point(674, 307);
            this.Test_bt.Name = "Test_bt";
            this.Test_bt.Size = new System.Drawing.Size(75, 23);
            this.Test_bt.TabIndex = 18;
            this.Test_bt.Text = "Test";
            this.Test_bt.UseVisualStyleBackColor = true;
            this.Test_bt.Click += new System.EventHandler(this.Test_bt_Click);
            // 
            // S_test
            // 
            this.S_test.Location = new System.Drawing.Point(574, 307);
            this.S_test.Name = "S_test";
            this.S_test.Size = new System.Drawing.Size(75, 23);
            this.S_test.TabIndex = 19;
            this.S_test.Text = "single test";
            this.S_test.UseVisualStyleBackColor = true;
            this.S_test.Click += new System.EventHandler(this.S_test_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // accuracy_label
            // 
            this.accuracy_label.AutoSize = true;
            this.accuracy_label.Location = new System.Drawing.Point(686, 333);
            this.accuracy_label.Name = "accuracy_label";
            this.accuracy_label.Size = new System.Drawing.Size(52, 13);
            this.accuracy_label.TabIndex = 20;
            this.accuracy_label.Text = "Accuracy";
            // 
            // Mis_Matchesl
            // 
            this.Mis_Matchesl.AutoSize = true;
            this.Mis_Matchesl.Location = new System.Drawing.Point(686, 377);
            this.Mis_Matchesl.Name = "Mis_Matchesl";
            this.Mis_Matchesl.Size = new System.Drawing.Size(70, 13);
            this.Mis_Matchesl.TabIndex = 21;
            this.Mis_Matchesl.Text = "miss matches";
            // 
            // _MSE
            // 
            this._MSE.AutoSize = true;
            this._MSE.Location = new System.Drawing.Point(696, 355);
            this._MSE.Name = "_MSE";
            this._MSE.Size = new System.Drawing.Size(30, 13);
            this._MSE.TabIndex = 22;
            this._MSE.Text = "MSE";
            // 
            // singleTest_Label
            // 
            this.singleTest_Label.AutoSize = true;
            this.singleTest_Label.Location = new System.Drawing.Point(595, 354);
            this.singleTest_Label.Name = "singleTest_Label";
            this.singleTest_Label.Size = new System.Drawing.Size(54, 13);
            this.singleTest_Label.TabIndex = 23;
            this.singleTest_Label.Text = "test single";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 410);
            this.Controls.Add(this.singleTest_Label);
            this.Controls.Add(this._MSE);
            this.Controls.Add(this.Mis_Matchesl);
            this.Controls.Add(this.accuracy_label);
            this.Controls.Add(this.S_test);
            this.Controls.Add(this.Test_bt);
            this.Controls.Add(this.Train_bt);
            this.Controls.Add(this.RBF_ch);
            this.Controls.Add(this.back_propagation_chk);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Learning_rate;
        private System.Windows.Forms.TextBox epochs_num;
        private System.Windows.Forms.TextBox mse_threshold;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button add_btn_Click;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Neurons_num_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Hidden_layers_txt;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox back_propagation_chk;
        private System.Windows.Forms.CheckBox RBF_ch;
        private System.Windows.Forms.Button Train_bt;
        private System.Windows.Forms.Button Test_bt;
        private System.Windows.Forms.Button S_test;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label accuracy_label;
        private System.Windows.Forms.Label Mis_Matchesl;
        private System.Windows.Forms.Label _MSE;
        private System.Windows.Forms.Label singleTest_Label;
    }
}

