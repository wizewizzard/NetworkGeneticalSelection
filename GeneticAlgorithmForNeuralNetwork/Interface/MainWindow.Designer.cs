namespace GeneticAlgorithmForNeuralNetwork.Interface
{
    partial class MainWindow
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.generation_size_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mutation_chance_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.generation_num_textbox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.neurons_num_min_input_textbox = new System.Windows.Forms.TextBox();
            this.neurons_num_max_input_textbox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.input_f_0_checkbox = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.neurons_num_min_output_textbox = new System.Windows.Forms.TextBox();
            this.neurons_num_max_output_textbox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.output_f_4_checkbox = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.output_f_3_checkbox = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.output_f_2_checkbox = new System.Windows.Forms.CheckBox();
            this.neurons_num_min_hidden_textbox = new System.Windows.Forms.TextBox();
            this.neurons_num_max_hidden_textbox = new System.Windows.Forms.TextBox();
            this.output_f_1_checkbox = new System.Windows.Forms.CheckBox();
            this.output_f_0_checkbox = new System.Windows.Forms.CheckBox();
            this.hidden_f_4_checkbox = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.hidden_f_3_checkbox = new System.Windows.Forms.CheckBox();
            this.hidden_f_2_checkbox = new System.Windows.Forms.CheckBox();
            this.hidden_f_1_checkbox = new System.Windows.Forms.CheckBox();
            this.hidden_f_0_checkbox = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.epoch_num_textbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.max_learning_rate_textbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.req_error_textbox = new System.Windows.Forms.TextBox();
            this.layers_num_min_textbox = new System.Windows.Forms.TextBox();
            this.layers_num_max_textbox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(880, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Начать отбор";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(894, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "График tr. tt.";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 497);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.generation_size_textbox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.mutation_chance_textbox);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.generation_num_textbox);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 497);
            this.panel3.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Число особей";
            // 
            // generation_size_textbox
            // 
            this.generation_size_textbox.Location = new System.Drawing.Point(121, 35);
            this.generation_size_textbox.Name = "generation_size_textbox";
            this.generation_size_textbox.Size = new System.Drawing.Size(55, 20);
            this.generation_size_textbox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Вероятность мутации";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Число поколений";
            // 
            // mutation_chance_textbox
            // 
            this.mutation_chance_textbox.Location = new System.Drawing.Point(121, 87);
            this.mutation_chance_textbox.Name = "mutation_chance_textbox";
            this.mutation_chance_textbox.Size = new System.Drawing.Size(55, 20);
            this.mutation_chance_textbox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Настройки отбора";
            // 
            // generation_num_textbox
            // 
            this.generation_num_textbox.Location = new System.Drawing.Point(121, 61);
            this.generation_num_textbox.Name = "generation_num_textbox";
            this.generation_num_textbox.Size = new System.Drawing.Size(55, 20);
            this.generation_num_textbox.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.epoch_num_textbox);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.max_learning_rate_textbox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.req_error_textbox);
            this.panel2.Controls.Add(this.layers_num_min_textbox);
            this.panel2.Controls.Add(this.layers_num_max_textbox);
            this.panel2.Location = new System.Drawing.Point(217, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 497);
            this.panel2.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label21);
            this.panel5.Controls.Add(this.label22);
            this.panel5.Controls.Add(this.label23);
            this.panel5.Controls.Add(this.neurons_num_min_input_textbox);
            this.panel5.Controls.Add(this.neurons_num_max_input_textbox);
            this.panel5.Controls.Add(this.label24);
            this.panel5.Controls.Add(this.input_f_0_checkbox);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.neurons_num_min_output_textbox);
            this.panel5.Controls.Add(this.neurons_num_max_output_textbox);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.output_f_4_checkbox);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.output_f_3_checkbox);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.output_f_2_checkbox);
            this.panel5.Controls.Add(this.neurons_num_min_hidden_textbox);
            this.panel5.Controls.Add(this.neurons_num_max_hidden_textbox);
            this.panel5.Controls.Add(this.output_f_1_checkbox);
            this.panel5.Controls.Add(this.output_f_0_checkbox);
            this.panel5.Controls.Add(this.hidden_f_4_checkbox);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.hidden_f_3_checkbox);
            this.panel5.Controls.Add(this.hidden_f_2_checkbox);
            this.panel5.Controls.Add(this.hidden_f_1_checkbox);
            this.panel5.Controls.Add(this.hidden_f_0_checkbox);
            this.panel5.Location = new System.Drawing.Point(0, 76);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(657, 252);
            this.panel5.TabIndex = 20;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(103, 160);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 13);
            this.label21.TabIndex = 48;
            this.label21.Text = "от";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(154, 160);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(19, 13);
            this.label22.TabIndex = 47;
            this.label22.Text = "до";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 160);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 13);
            this.label23.TabIndex = 46;
            this.label23.Text = "Число нейронов";
            // 
            // neurons_num_min_input_textbox
            // 
            this.neurons_num_min_input_textbox.Location = new System.Drawing.Point(121, 157);
            this.neurons_num_min_input_textbox.Name = "neurons_num_min_input_textbox";
            this.neurons_num_min_input_textbox.Size = new System.Drawing.Size(30, 20);
            this.neurons_num_min_input_textbox.TabIndex = 41;
            // 
            // neurons_num_max_input_textbox
            // 
            this.neurons_num_max_input_textbox.Location = new System.Drawing.Point(171, 157);
            this.neurons_num_max_input_textbox.Name = "neurons_num_max_input_textbox";
            this.neurons_num_max_input_textbox.Size = new System.Drawing.Size(30, 20);
            this.neurons_num_max_input_textbox.TabIndex = 44;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(89, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(76, 13);
            this.label24.TabIndex = 42;
            this.label24.Text = "Входной слой";
            // 
            // input_f_0_checkbox
            // 
            this.input_f_0_checkbox.AutoSize = true;
            this.input_f_0_checkbox.Checked = true;
            this.input_f_0_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.input_f_0_checkbox.Enabled = false;
            this.input_f_0_checkbox.Location = new System.Drawing.Point(18, 34);
            this.input_f_0_checkbox.Name = "input_f_0_checkbox";
            this.input_f_0_checkbox.Size = new System.Drawing.Size(60, 17);
            this.input_f_0_checkbox.TabIndex = 39;
            this.input_f_0_checkbox.Text = "Identity";
            this.input_f_0_checkbox.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(545, 160);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 13);
            this.label18.TabIndex = 38;
            this.label18.Text = "от";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(596, 160);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(19, 13);
            this.label19.TabIndex = 37;
            this.label19.Text = "до";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(450, 160);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(90, 13);
            this.label20.TabIndex = 36;
            this.label20.Text = "Число нейронов";
            // 
            // neurons_num_min_output_textbox
            // 
            this.neurons_num_min_output_textbox.Enabled = false;
            this.neurons_num_min_output_textbox.Location = new System.Drawing.Point(563, 157);
            this.neurons_num_min_output_textbox.Name = "neurons_num_min_output_textbox";
            this.neurons_num_min_output_textbox.Size = new System.Drawing.Size(30, 20);
            this.neurons_num_min_output_textbox.TabIndex = 34;
            // 
            // neurons_num_max_output_textbox
            // 
            this.neurons_num_max_output_textbox.Enabled = false;
            this.neurons_num_max_output_textbox.Location = new System.Drawing.Point(613, 157);
            this.neurons_num_max_output_textbox.Name = "neurons_num_max_output_textbox";
            this.neurons_num_max_output_textbox.Size = new System.Drawing.Size(30, 20);
            this.neurons_num_max_output_textbox.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(329, 160);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "от";
            // 
            // output_f_4_checkbox
            // 
            this.output_f_4_checkbox.AutoSize = true;
            this.output_f_4_checkbox.Location = new System.Drawing.Point(453, 124);
            this.output_f_4_checkbox.Name = "output_f_4_checkbox";
            this.output_f_4_checkbox.Size = new System.Drawing.Size(89, 17);
            this.output_f_4_checkbox.TabIndex = 33;
            this.output_f_4_checkbox.Text = "Negative exp";
            this.output_f_4_checkbox.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(380, 160);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "до";
            // 
            // output_f_3_checkbox
            // 
            this.output_f_3_checkbox.AutoSize = true;
            this.output_f_3_checkbox.Location = new System.Drawing.Point(453, 101);
            this.output_f_3_checkbox.Name = "output_f_3_checkbox";
            this.output_f_3_checkbox.Size = new System.Drawing.Size(87, 17);
            this.output_f_3_checkbox.TabIndex = 32;
            this.output_f_3_checkbox.Text = "Sigmoid (-1,1)";
            this.output_f_3_checkbox.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(234, 160);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Число нейронов";
            // 
            // output_f_2_checkbox
            // 
            this.output_f_2_checkbox.AutoSize = true;
            this.output_f_2_checkbox.Location = new System.Drawing.Point(453, 80);
            this.output_f_2_checkbox.Name = "output_f_2_checkbox";
            this.output_f_2_checkbox.Size = new System.Drawing.Size(87, 17);
            this.output_f_2_checkbox.TabIndex = 31;
            this.output_f_2_checkbox.Text = "Sigmoid (0,1)";
            this.output_f_2_checkbox.UseVisualStyleBackColor = true;
            // 
            // neurons_num_min_hidden_textbox
            // 
            this.neurons_num_min_hidden_textbox.Location = new System.Drawing.Point(347, 157);
            this.neurons_num_min_hidden_textbox.Name = "neurons_num_min_hidden_textbox";
            this.neurons_num_min_hidden_textbox.Size = new System.Drawing.Size(30, 20);
            this.neurons_num_min_hidden_textbox.TabIndex = 21;
            // 
            // neurons_num_max_hidden_textbox
            // 
            this.neurons_num_max_hidden_textbox.Location = new System.Drawing.Point(397, 157);
            this.neurons_num_max_hidden_textbox.Name = "neurons_num_max_hidden_textbox";
            this.neurons_num_max_hidden_textbox.Size = new System.Drawing.Size(30, 20);
            this.neurons_num_max_hidden_textbox.TabIndex = 22;
            // 
            // output_f_1_checkbox
            // 
            this.output_f_1_checkbox.AutoSize = true;
            this.output_f_1_checkbox.Location = new System.Drawing.Point(453, 57);
            this.output_f_1_checkbox.Name = "output_f_1_checkbox";
            this.output_f_1_checkbox.Size = new System.Drawing.Size(51, 17);
            this.output_f_1_checkbox.TabIndex = 30;
            this.output_f_1_checkbox.Text = "Tanh";
            this.output_f_1_checkbox.UseVisualStyleBackColor = true;
            // 
            // output_f_0_checkbox
            // 
            this.output_f_0_checkbox.AutoSize = true;
            this.output_f_0_checkbox.Location = new System.Drawing.Point(453, 34);
            this.output_f_0_checkbox.Name = "output_f_0_checkbox";
            this.output_f_0_checkbox.Size = new System.Drawing.Size(60, 17);
            this.output_f_0_checkbox.TabIndex = 29;
            this.output_f_0_checkbox.Text = "Identity";
            this.output_f_0_checkbox.UseVisualStyleBackColor = true;
            // 
            // hidden_f_4_checkbox
            // 
            this.hidden_f_4_checkbox.AutoSize = true;
            this.hidden_f_4_checkbox.Location = new System.Drawing.Point(244, 124);
            this.hidden_f_4_checkbox.Name = "hidden_f_4_checkbox";
            this.hidden_f_4_checkbox.Size = new System.Drawing.Size(89, 17);
            this.hidden_f_4_checkbox.TabIndex = 28;
            this.hidden_f_4_checkbox.Text = "Negative exp";
            this.hidden_f_4_checkbox.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(511, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Выходой слой";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(315, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Скрытые слои";
            // 
            // hidden_f_3_checkbox
            // 
            this.hidden_f_3_checkbox.AutoSize = true;
            this.hidden_f_3_checkbox.Location = new System.Drawing.Point(244, 101);
            this.hidden_f_3_checkbox.Name = "hidden_f_3_checkbox";
            this.hidden_f_3_checkbox.Size = new System.Drawing.Size(87, 17);
            this.hidden_f_3_checkbox.TabIndex = 22;
            this.hidden_f_3_checkbox.Text = "Sigmoid (-1,1)";
            this.hidden_f_3_checkbox.UseVisualStyleBackColor = true;
            // 
            // hidden_f_2_checkbox
            // 
            this.hidden_f_2_checkbox.AutoSize = true;
            this.hidden_f_2_checkbox.Location = new System.Drawing.Point(244, 80);
            this.hidden_f_2_checkbox.Name = "hidden_f_2_checkbox";
            this.hidden_f_2_checkbox.Size = new System.Drawing.Size(87, 17);
            this.hidden_f_2_checkbox.TabIndex = 21;
            this.hidden_f_2_checkbox.Text = "Sigmoid (0,1)";
            this.hidden_f_2_checkbox.UseVisualStyleBackColor = true;
            // 
            // hidden_f_1_checkbox
            // 
            this.hidden_f_1_checkbox.AutoSize = true;
            this.hidden_f_1_checkbox.Location = new System.Drawing.Point(244, 57);
            this.hidden_f_1_checkbox.Name = "hidden_f_1_checkbox";
            this.hidden_f_1_checkbox.Size = new System.Drawing.Size(51, 17);
            this.hidden_f_1_checkbox.TabIndex = 20;
            this.hidden_f_1_checkbox.Text = "Tanh";
            this.hidden_f_1_checkbox.UseVisualStyleBackColor = true;
            // 
            // hidden_f_0_checkbox
            // 
            this.hidden_f_0_checkbox.AutoSize = true;
            this.hidden_f_0_checkbox.Location = new System.Drawing.Point(244, 34);
            this.hidden_f_0_checkbox.Name = "hidden_f_0_checkbox";
            this.hidden_f_0_checkbox.Size = new System.Drawing.Size(60, 17);
            this.hidden_f_0_checkbox.TabIndex = 19;
            this.hidden_f_0_checkbox.Text = "Identity";
            this.hidden_f_0_checkbox.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(100, 331);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Настройки обучения";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Количество эпох";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "от";
            // 
            // epoch_num_textbox
            // 
            this.epoch_num_textbox.Location = new System.Drawing.Point(170, 347);
            this.epoch_num_textbox.Name = "epoch_num_textbox";
            this.epoch_num_textbox.Size = new System.Drawing.Size(100, 20);
            this.epoch_num_textbox.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 402);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Макс. скорость обучения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Настройки нейронных сетей";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 376);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Требуемая точность";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(214, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "до";
            // 
            // max_learning_rate_textbox
            // 
            this.max_learning_rate_textbox.Location = new System.Drawing.Point(170, 399);
            this.max_learning_rate_textbox.Name = "max_learning_rate_textbox";
            this.max_learning_rate_textbox.Size = new System.Drawing.Size(100, 20);
            this.max_learning_rate_textbox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Число слоев";
            // 
            // req_error_textbox
            // 
            this.req_error_textbox.Location = new System.Drawing.Point(170, 373);
            this.req_error_textbox.Name = "req_error_textbox";
            this.req_error_textbox.Size = new System.Drawing.Size(100, 20);
            this.req_error_textbox.TabIndex = 12;
            // 
            // layers_num_min_textbox
            // 
            this.layers_num_min_textbox.Location = new System.Drawing.Point(181, 39);
            this.layers_num_min_textbox.Name = "layers_num_min_textbox";
            this.layers_num_min_textbox.Size = new System.Drawing.Size(30, 20);
            this.layers_num_min_textbox.TabIndex = 7;
            // 
            // layers_num_max_textbox
            // 
            this.layers_num_max_textbox.Location = new System.Drawing.Point(231, 39);
            this.layers_num_max_textbox.Name = "layers_num_max_textbox";
            this.layers_num_max_textbox.Size = new System.Drawing.Size(30, 20);
            this.layers_num_max_textbox.TabIndex = 12;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = "C:\\neural network";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(880, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Источник данных";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 583);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainWindow";
            this.Text = "Генетический отбор нейронных сетей";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox layers_num_min_textbox;
        private System.Windows.Forms.TextBox mutation_chance_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox generation_num_textbox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox generation_size_textbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox layers_num_max_textbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox epoch_num_textbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox max_learning_rate_textbox;
        private System.Windows.Forms.TextBox req_error_textbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox hidden_f_3_checkbox;
        private System.Windows.Forms.CheckBox hidden_f_2_checkbox;
        private System.Windows.Forms.CheckBox hidden_f_1_checkbox;
        private System.Windows.Forms.CheckBox hidden_f_0_checkbox;
        private System.Windows.Forms.CheckBox hidden_f_4_checkbox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox neurons_num_min_input_textbox;
        private System.Windows.Forms.TextBox neurons_num_max_input_textbox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox input_f_0_checkbox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox neurons_num_min_output_textbox;
        private System.Windows.Forms.TextBox neurons_num_max_output_textbox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox output_f_4_checkbox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox output_f_3_checkbox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox output_f_2_checkbox;
        private System.Windows.Forms.TextBox neurons_num_min_hidden_textbox;
        private System.Windows.Forms.TextBox neurons_num_max_hidden_textbox;
        private System.Windows.Forms.CheckBox output_f_1_checkbox;
        private System.Windows.Forms.CheckBox output_f_0_checkbox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
    }
}