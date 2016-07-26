using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace GeneticAlgorithmForNeuralNetwork.Interface
{
    using GeneticAlgorithm;
    using DataProc;
    public partial class MainWindow : Form
    {
        private ArrayList m_status_monitors;
        //Thread[] m_genetic_algorithms_threads;
        public MainWindow()
        {
            InitializeComponent();
            Config default_cfg = new Config();
            this.epoch_num_textbox.Text = default_cfg.epoch_num.ToString();
            this.generation_num_textbox.Text = default_cfg.generation_num.ToString();
            this.generation_size_textbox.Text = default_cfg.generation_size.ToString();
            this.layers_num_max_textbox.Text = default_cfg.layer_num_max.ToString();
            this.layers_num_min_textbox.Text = default_cfg.layer_num_min.ToString();
            this.max_learning_rate_textbox.Text = default_cfg.learning_rate_max.ToString();
            this.mutation_chance_textbox.Text = default_cfg.mutation_chance.ToString();
            this.neurons_num_min_input_textbox.Text = default_cfg.input_neuron_num_min.ToString();
            this.neurons_num_max_input_textbox.Text = default_cfg.input_neuron_num_max.ToString();
            this.neurons_num_min_hidden_textbox.Text = default_cfg.hidden_neuron_num_min.ToString();
            this.neurons_num_max_hidden_textbox.Text = default_cfg.hidden_neuron_num_max.ToString();
            this.neurons_num_min_output_textbox.Text = default_cfg.output_neuron_num_min.ToString();
            this.neurons_num_max_output_textbox.Text = default_cfg.output_neuron_num_max.ToString();
            this.req_error_textbox.Text = default_cfg.error_val_required.ToString();
            string check_box_name = "(1)_f_(2)_checkbox";
            for (int i = 0; i < default_cfg.input_layer_functions_allowed.GetLength(0); i++)
            {
                ((CheckBox)(this.Controls.Find(check_box_name.Replace("(1)", "input").Replace("(2)", default_cfg.input_layer_functions_allowed[i].ToString()), true)[0])).Checked = true;
            }
            for (int i = 0; i < default_cfg.hidden_layer_functions_allowed.GetLength(0); i++)
            {
                ((CheckBox)this.Controls.Find(check_box_name.Replace("(1)", "hidden").Replace("(2)", default_cfg.hidden_layer_functions_allowed[i].ToString()), true)[0]).Checked = true;
            }
            for (int i = 0; i < default_cfg.output_layer_functions_allowed.GetLength(0); i++)
            {
                ((CheckBox)this.Controls.Find(check_box_name.Replace("(1)", "output").Replace("(2)", default_cfg.output_layer_functions_allowed[i].ToString()), true)[0]).Checked = true;
            }

                m_status_monitors = new ArrayList();
            this.ShowDialog();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data_source = this.openFileDialog1.FileName;
            if (data_source == null || data_source == "") return;
            Config new_config = new Config(data_source);
            try
            {
                if (!Int32.TryParse(this.epoch_num_textbox.Text, out new_config.epoch_num)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.generation_num_textbox.Text, out new_config.generation_num)) throw new Exception("Wrong generation num");
                if (!Int32.TryParse(this.generation_size_textbox.Text, out new_config.generation_size)) throw new Exception("Wrong generation size");
                if (!Int32.TryParse(this.layers_num_max_textbox.Text, out new_config.layer_num_max)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.layers_num_min_textbox.Text, out new_config.layer_num_min)) throw new Exception("Wrong epoch num");
                if (!Double.TryParse(this.max_learning_rate_textbox.Text, out new_config.learning_rate_max)) throw new Exception("Wrong epoch num");
                if (!Double.TryParse(this.mutation_chance_textbox.Text, out new_config.mutation_chance)) throw new Exception("Wrong mutation chance");
                if (!Int32.TryParse(this.neurons_num_min_input_textbox.Text, out new_config.input_neuron_num_min)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.neurons_num_max_input_textbox.Text, out new_config.input_neuron_num_max)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.neurons_num_min_hidden_textbox.Text, out new_config.hidden_neuron_num_min)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.neurons_num_max_hidden_textbox.Text, out new_config.hidden_neuron_num_max)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.neurons_num_min_output_textbox.Text, out new_config.output_neuron_num_min)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.neurons_num_max_output_textbox.Text, out new_config.output_neuron_num_max)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.epoch_num_textbox.Text, out new_config.epoch_num)) throw new Exception("Wrong epoch num");
                if (!Double.TryParse(this.req_error_textbox.Text, out new_config.error_val_required)) throw new Exception("Wrong mutation chance");
                string check_box_name = "(1)_f_(2)_checkbox";
                for (int i = 0; i < new_config.input_layer_functions_allowed.GetLength(0); i++)
                {
                    if (!((CheckBox)(this.Controls.Find(check_box_name.Replace("(1)", "input").Replace("(2)", new_config.input_layer_functions_allowed[i].ToString()), true)[0])).Checked)
                    {
                        int t = new_config.input_layer_functions_allowed[i];
                        new_config.input_layer_functions_allowed = new_config.input_layer_functions_allowed.Where(x => x != new_config.input_layer_functions_allowed[i]).ToArray();
                        i--;
                    }
                }
                for (int i = 0; i < new_config.hidden_layer_functions_allowed.GetLength(0); i++)
                {
                    if (!((CheckBox)(this.Controls.Find(check_box_name.Replace("(1)", "hidden").Replace("(2)", new_config.hidden_layer_functions_allowed[i].ToString()), true)[0])).Checked)
                    {
                        int t = new_config.hidden_layer_functions_allowed[i];
                        new_config.hidden_layer_functions_allowed = new_config.hidden_layer_functions_allowed.Where(x => x != new_config.hidden_layer_functions_allowed[i]).ToArray();
                        i--;
                    }
                }
                for (int i = 0; i < new_config.output_layer_functions_allowed.GetLength(0); i++)
                {
                    if (!((CheckBox)(this.Controls.Find(check_box_name.Replace("(1)", "output").Replace("(2)", new_config.output_layer_functions_allowed[i].ToString()), true)[0])).Checked)
                    {
                        int t = new_config.output_layer_functions_allowed[i];
                        new_config.output_layer_functions_allowed = new_config.output_layer_functions_allowed.Where(x => x != new_config.output_layer_functions_allowed[i]).ToArray();
                        i--;
                    }
                }
            }
            catch(Exception exc){
                return;
            }
            StatusMonitorThread ts = new StatusMonitorThread(new_config);
            ts.StartMonitoring();
            m_status_monitors.Add(ts);
            /*Config cfg = new Config(@"C:\neural network\data1.xlsx");
            StatusMonitorThread ts = new StatusMonitorThread(cfg);
            ts.StartMonitoring();
            m_status_monitors.Add(ts);*/
            /*ThreadStart starter = delegate { ts.StartThread() };
            Thread new_selection_thread = new Thread(starter);
            m_genetic_algorithms_threads.Add(new_selection_thread);
            new_selection_thread.Start();*/
            /*DataPreprocessor dp = new DataPreprocessor(cfg.data_source);
            double[] data = dp.GetRowD("var1");
            int[] signs = dp.GetRowI("sign");
            GeneticSelection selector = new GeneticSelection(cfg);
            ThreadStart starter = delegate { selector.StartSelection(data, signs); };
            Thread new_selection_thread = new Thread(starter);
            m_genetic_algorithms_threads.Add(new_selection_thread);
            new_selection_thread.Start();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ForecastingWindow fc_form = new ForecastingWindow();
            fc_form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                /*System.IO.StreamReader sr = new
                   System.IO.StreamReader(this.openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();*/
            }
        }
    }
}
