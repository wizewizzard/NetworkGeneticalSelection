using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GeneticAlgorithmForNeuralNetwork.Interface
{
    using DataProc;
    using NeuralNetworkNS;
    public partial class ForecastingWindow : Form
    {
        private NeuralNetwork m_NN;
        private int m_mode;
        private double[] m_fact_values;
        private double[] m_pred_values;
        private int[] m_signs;
        private int[] m_T;
        private Random m_rand;
        public ForecastingWindow()
        {
            InitializeComponent();
            m_rand = new Random();
            m_pred_values = m_fact_values = null;
            m_T = m_signs = null;
            m_mode = 2;
            this.panel1.Paint += (sender, e) => panel1.GraphicPanelPaintTimeSeries(sender, e, this.m_T, m_signs, m_fact_values, m_pred_values, m_mode);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    m_mode = 2;
                    this.panel1.Invalidate();
                }
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    m_mode = 0;
                    this.panel1.Invalidate();
                }
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    m_mode = 1;
                    this.panel1.Invalidate();
                }
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string network_id = this.textBox1.Text;
            string data_source = this.textBox2.Text;
            try
            {
                this.m_NN = new NeuralNetwork(network_id);
                DataPreprocessor dp = new DataPreprocessor(data_source);
                this.m_fact_values = dp.GetRowD("var1");
                int[] signs = dp.GetRowI("sign");
                double min_v = m_fact_values.Min(), max_v = m_fact_values.Max();
                double[] n_data = DataPreprocessor.NormalizeData(m_fact_values, Config.normalization_bound_low, Config.normalization_bound_high);
                
                double[][] IXtr;
                double[][] OXtr;
                double[][] IXtt;//определяется входным слоем
                double[][] OXtt;
                int[] tr_N;
                int[] tt_N;
                DataPreprocessor.SplitDataIXOXN(n_data, signs, 0, 1, m_NN.Network_neuron_structure[0], 1, out IXtr, out OXtr, out IXtt, out OXtt, out tr_N, out tt_N);
                ResultAnalysis.NetworkProcessTrTT(m_NN, n_data, IXtr, IXtt, tr_N, tt_N, out m_T, out m_signs, out m_pred_values);
                this.m_pred_values = DataPreprocessor.DeNormalizeData(m_pred_values, min_v, max_v, Config.normalization_bound_low, Config.normalization_bound_high);
                this.panel1.Invalidate();
            }
            catch (EXC.FileLoadException exc)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string data_source = this.textBox3.Text;
            int layers_num;
            int[] neuron_structure;
            int[] function_structure;
            try
            {
                if (!Int32.TryParse(this.layers_num_textbox.Text, out layers_num)) throw new Exception("Wrong epoch num");
                neuron_structure = new int[layers_num];
                function_structure = new int[layers_num];
                function_structure[0] = 0;
                if (!Int32.TryParse(this.neurons_num_input_textbox.Text, out neuron_structure[0])) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.neurons_num_output_textbox.Text, out neuron_structure[layers_num-1])) throw new Exception("Wrong epoch num");
                string hidden_neuron_structure_s = this.neurons_num_hidden_textbox.Text;
                string hidden_fuction_structure_s = this.hidden_functions_textbox.Text;
                string[] neurons_num_str_arr = hidden_neuron_structure_s.Split(';');
                string[] functions_structure_str_arr = hidden_fuction_structure_s.Split(';');
                for (int i = 1; i < layers_num - 1; i++)
                {
                    if(!Int32.TryParse(neurons_num_str_arr[i-1], out neuron_structure[i])) throw new Exception("Wrong epoch num");;
                    function_structure[i] = Array.IndexOf(Helper.function_types, functions_structure_str_arr[i - 1]);
                }
                var checkedButton = this.panel2.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
                string name = checkedButton.Name;
                function_structure[layers_num - 1] = Int32.Parse(Regex.Match(name, @"\d+").Value);
                /*
                if (!Int32.TryParse(this.neurons_num_input_textbox.Text, out new_config.generation_num)) throw new Exception("Wrong generation num");
                if (!Int32.TryParse(this.generation_size_textbox.Text, out new_config.generation_size)) throw new Exception("Wrong generation size");
                if (!Int32.TryParse(this.layers_num_max_textbox.Text, out new_config.layer_num_max)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.layers_num_textbox.Text, out new_config.layer_num_min)) throw new Exception("Wrong epoch num");
                if (!Double.TryParse(this.max_learning_rate_textbox.Text, out new_config.learning_rate_max)) throw new Exception("Wrong epoch num");
                if (!Double.TryParse(this.mutation_chance_textbox.Text, out new_config.mutation_chance)) throw new Exception("Wrong mutation chance");
                if (!Int32.TryParse(this.neurons_num_min_input_textbox.Text, out new_config.input_neuron_num_min)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.neurons_num_input_textbox.Text, out new_config.input_neuron_num_max)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.neurons_num_min_hidden_textbox.Text, out new_config.hidden_neuron_num_min)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.neurons_num_hidden_textbox.Text, out new_config.hidden_neuron_num_max)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.neurons_num_min_output_textbox.Text, out new_config.output_neuron_num_min)) throw new Exception("Wrong epoch num");
                if (!Int32.TryParse(this.neurons_num_output_textbox.Text, out new_config.output_neuron_num_max)) throw new Exception("Wrong epoch num");
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
                }*/
                this.m_NN = new NeuralNetwork(Helper.GenerateString(10, m_rand), layers_num, neuron_structure, function_structure);
                DataPreprocessor dp = new DataPreprocessor(data_source);
                this.m_fact_values = dp.GetRowD("var1");
                int[] signs = dp.GetRowI("sign");
                double min_v = m_fact_values.Min(), max_v = m_fact_values.Max();
                double[] n_data = DataPreprocessor.NormalizeData(m_fact_values, Config.normalization_bound_low, Config.normalization_bound_high);

                double[][] IXtr;
                double[][] OXtr;
                double[][] IXtt;//определяется входным слоем
                double[][] OXtt;
                int[] tr_N;
                int[] tt_N;
                DataPreprocessor.SplitDataIXOXN(n_data, signs, 0, 1, m_NN.Network_neuron_structure[0], 1, out IXtr, out OXtr, out IXtt, out OXtt, out tr_N, out tt_N);
                Config default_config = new Config();
                m_NN.WeightsRandom(m_rand, default_config);
                this.m_NN.NetworkTraining(IXtr, OXtr, IXtt, OXtt, default_config);
                ResultAnalysis.NetworkProcessTrTT(m_NN, n_data, IXtr, IXtt, tr_N, tt_N, out m_T, out m_signs, out m_pred_values);
                this.m_pred_values = DataPreprocessor.DeNormalizeData(m_pred_values, min_v, max_v, Config.normalization_bound_low, Config.normalization_bound_high);
                this.panel1.Invalidate();
            }
            catch (Exception exc)
            {
                return;
            }
        }
    }
}
