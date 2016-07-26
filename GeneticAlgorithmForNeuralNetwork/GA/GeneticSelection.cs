using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GeneticAlgorithmForNeuralNetwork.GeneticAlgorithm
{
    using NeuralNetworkNS;
    using DataProc;
    public class GeneticSelection
    {
        #region fields and props
        private bool m_active;
        public bool Active
        {
            get { return m_active; }
            set { m_active = value; }
        }
        private Config m_config;
        internal Config Config
        {
            get { return m_config; }
            set { m_config = value; }
        }
        //for thread
        public object locker = new object();
        int m_cur_generation;
        public int Cur_generation
        {
            get { return m_cur_generation; }
            set { m_cur_generation = value; }
        }
        private string[] m_param_titles;
        public string[] Param_titles
        {
            get { return m_param_titles; }
            set { m_param_titles = value; }
        }
        private double m_av_layers_num_cur;
        public double Av_layers_num_cur
        {
            get { return m_av_layers_num_cur; }
            set { m_av_layers_num_cur = value; }
        }
        private double m_av_input_neurons_num_cur;
        public double Av_input_neurons_num_cur
        {
            get { return m_av_input_neurons_num_cur; }
            set { m_av_input_neurons_num_cur = value; }
        }
        private double m_av_hidden_neurons_num_cur;
        public double Av_hidden_neurons_num_cur
        {
            get { return m_av_hidden_neurons_num_cur; }
            set { m_av_hidden_neurons_num_cur = value; }
        }
        private double[] m_av_layers_num;
        public double[] Av_layers_num
        {
            get { return m_av_layers_num; }
            set { m_av_layers_num = value; }
        }
        private double[] m_av_input_neurons_num;
        public double[] Av_input_neurons_num
        {
            get { return m_av_input_neurons_num; }
            set { m_av_input_neurons_num = value; }
        }
        private double[] m_av_hidden_neurons_num;
        public double[] Av_hidden_neurons_num
        {
            get { return m_av_hidden_neurons_num; }
            set { m_av_hidden_neurons_num = value; }
        }
        private double[] m_av_st_dev_tr;
        public double[] Av_st_dev_tr
        {
            get { return m_av_st_dev_tr; }
            set { m_av_st_dev_tr = value; }
        }
        private double[] m_av_st_dev_tt;
        public double[] Av_st_dev_tt
        {
            get { return m_av_st_dev_tt; }
            set { m_av_st_dev_tt = value; }
        }
        private double[] m_av_mae_tr;
        public double[] Av_mae_tr
        {
            get { return m_av_mae_tr; }
            set { m_av_mae_tr = value; }
        }
        private double[] m_av_mae_tt;
        public double[] Av_mae_tt
        {
            get { return m_av_mae_tt; }
            set { m_av_mae_tt = value; }
        }
        private double[] m_av_mape_tr;
        public double[] Av_mape_tr
        {
            get { return m_av_mape_tr; }
            set { m_av_mape_tr = value; }
        }
        private double[] m_av_mape_tt;
        public double[] Av_mape_tt
        {
            get { return m_av_mape_tt; }
            set { m_av_mape_tt = value; }
        }
        private double m_min_st_dev_tr;
        public double Min_st_dev_tr
        {
            get { return m_min_st_dev_tr; }
            set { m_min_st_dev_tr = value; }
        }
        private string m_min_st_dev_tr_nn_id;
        public string Min_st_dev_tr_nn_id
        {
            get { return m_min_st_dev_tr_nn_id; }
            set { m_min_st_dev_tr_nn_id = value; }
        }
        private int m_min_st_dev_tr_gen_id;
        public int Min_st_dev_tr_gen_id
        {
            get { return m_min_st_dev_tr_gen_id; }
            set { m_min_st_dev_tr_gen_id = value; }
        }
        private double m_min_st_dev_tt;
        public double Min_st_dev_tt
        {
            get { return m_min_st_dev_tt; }
            set { m_min_st_dev_tt = value; }
        }
        private string m_min_st_dev_tt_nn_id;
        public string Min_st_dev_tt_nn_id
        {
            get { return m_min_st_dev_tt_nn_id; }
            set { m_min_st_dev_tt_nn_id = value; }
        }
        private int m_min_st_dev_tt_gen_id;
        public int Min_st_dev_tt_gen_id
        {
            get { return m_min_st_dev_tt_gen_id; }
            set { m_min_st_dev_tt_gen_id = value; }
        }
        private double m_min_mae_tr;
        public double Min_mae_tr
        {
            get { return m_min_mae_tr; }
            set { m_min_mae_tr = value; }
        }
        private string m_min_mae_nn_tr_nn_id;
        public string Min_mae_nn_tr_nn_id
        {
            get { return m_min_mae_nn_tr_nn_id; }
            set { m_min_mae_nn_tr_nn_id = value; }
        }
        private int m_min_mae_nn_tr_gen_id;
        public int Min_mae_nn_tr_gen_id
        {
            get { return m_min_mae_nn_tr_gen_id; }
            set { m_min_mae_nn_tr_gen_id = value; }
        }
        private double m_min_mae_tt;
        public double Min_mae_tt
        {
            get { return m_min_mae_tt; }
            set { m_min_mae_tt = value; }
        }
        private string m_min_mae_nn_tt_nn_id;
        public string Min_mae_nn_tt_nn_id
        {
            get { return m_min_mae_nn_tt_nn_id; }
            set { m_min_mae_nn_tt_nn_id = value; }
        }
        private int m_min_mae_nn_tt_gen_id;
        public int Min_mae_nn_tt_gen_id
        {
            get { return m_min_mae_nn_tt_gen_id; }
            set { m_min_mae_nn_tt_gen_id = value; }
        }
        private double m_min_mape_tr;
        public double Min_mape_tr
        {
            get { return m_min_mape_tr; }
            set { m_min_mape_tr = value; }
        }
        private string m_min_mape_tr_nn_id;
        public string Min_mape_tr_nn_id
        {
            get { return m_min_mape_tr_nn_id; }
            set { m_min_mape_tr_nn_id = value; }
        }
        private int m_min_mape_tr_gen_id;
        public int Min_mape_tr_gen_id
        {
            get { return m_min_mape_tr_gen_id; }
            set { m_min_mape_tr_gen_id = value; }
        }
        private double m_min_mape_tt;
        public double Min_mape_tt
        {
            get { return m_min_mape_tt; }
            set { m_min_mape_tt = value; }
        }
        private string m_min_mape_tt_nn_id;
        public string Min_mape_tt_nn_id
        {
            get { return m_min_mape_tt_nn_id; }
            set { m_min_mape_tt_nn_id = value; }
        }
        private int m_min_mape_tt_gen_id;
        public int Min_mape_tt_gen_id
        {
            get { return m_min_mape_tt_gen_id; }
            set { m_min_mape_tt_gen_id = value; }
        }
        #endregion
        public GeneticSelection(Config _config)
        {
            m_min_st_dev_tr = Double.PositiveInfinity; m_min_st_dev_tr_nn_id = ""; m_min_st_dev_tr_gen_id = -1;
            m_min_st_dev_tt = Double.PositiveInfinity; m_min_st_dev_tt_nn_id = ""; m_min_st_dev_tt_gen_id = -1;
            m_min_mae_tr = Double.PositiveInfinity; m_min_mae_nn_tr_nn_id = ""; m_min_mae_nn_tr_gen_id = -1;
            m_min_mae_tt = Double.PositiveInfinity; m_min_mae_nn_tt_nn_id = ""; m_min_mae_nn_tt_gen_id = -1;
            m_min_mape_tr = Double.PositiveInfinity; m_min_mape_tr_nn_id = ""; m_min_mape_tr_gen_id = -1;
            m_min_mape_tt = Double.PositiveInfinity; m_min_mape_tt_nn_id = ""; m_min_mape_tt_gen_id = -1;
            m_config = _config;
            m_param_titles = new string[] { "av_st_dev_tr", "av_st_dev_tt", "av_mae_tr", "av_mae_tt", "av_mape_tr", "av_mape_tt" };
            m_av_st_dev_tr = new double[_config.generation_num];
            m_av_st_dev_tt = new double[_config.generation_num];
            m_av_mae_tr = new double[_config.generation_num];
            m_av_mae_tt = new double[_config.generation_num];
            m_av_mape_tr = new double[_config.generation_num];
            m_av_mape_tt = new double[_config.generation_num];
            m_cur_generation = 0;
            this.m_av_layers_num = new double[_config.generation_num];
            this.Av_input_neurons_num = new double[_config.generation_num];
            this.Av_hidden_neurons_num = new double[_config.generation_num];
            this.m_active = true;
        }
        public void StartSelection(double[] _data, int[] _signs) {
            double max_v = _data.Max();
            double min_v = _data.Min();
            double d1 = 0, d2 = 1;
            double[] data = DataPreprocessor.NormalizeData(_data, d1, d2);
            double[][][] IXtr = new double[m_config.input_neuron_num_max - m_config.input_neuron_num_min + 1][][];
            double[][][] OXtr = new double[m_config.input_neuron_num_max - m_config.input_neuron_num_min + 1][][]; ;
            double[][][] IXtt = new double[m_config.input_neuron_num_max - m_config.input_neuron_num_min + 1][][]; //определяется входным слоем
            double[][][] OXtt = new double[m_config.input_neuron_num_max - m_config.input_neuron_num_min + 1][][];
            int[][] tr_N = new int[m_config.input_neuron_num_max - m_config.input_neuron_num_min + 1][];
            int[][] tt_N = new int[m_config.input_neuron_num_max - m_config.input_neuron_num_min + 1][];

            for (int di = 0; di < m_config.input_neuron_num_max - m_config.input_neuron_num_min + 1; di++) // for NI = k => IX[k-min_neur]
                DataPreprocessor.SplitDataIXOXN(data, _signs, 0, 1, m_config.input_neuron_num_min + di, 1, out IXtr[di], out OXtr[di], out IXtt[di], out OXtt[di], out tr_N[di], out tt_N[di]);

            NeuralNetwork[] NN_population, NN_next_population;
            NN_population = new NeuralNetwork[m_config.generation_size];
            NN_next_population = new NeuralNetwork[m_config.generation_size];
            Random rnd = new Random();
            //дополнительные значения хранящие минимальные значения параметров и идентификаторов сетей, которые им соотв.
            
            Helper.FileWrite(Config.ga_log_file_name, DateTime.Now.ToString("h:mm:ss tt") + " GA initialized. Generation size = " + m_config.generation_size + ". Generation num = " + m_config.generation_num);
            //формирование первого поколения
            for (int i = 0; i < m_config.generation_size && m_active; i++)
            {
                int layers_num = rnd.Next(m_config.layer_num_min, m_config.layer_num_max + 1);
                int[] neuron_structure = new int[layers_num];
                int[] function_structure = new int[layers_num];
                for(int j=0; j < layers_num; j++){
                    if (j == 0) { //in
                        neuron_structure[j] = rnd.Next(m_config.input_neuron_num_min, m_config.input_neuron_num_max + 1);
                        function_structure[j] = m_config.input_layer_functions_allowed[rnd.Next(m_config.input_layer_functions_allowed.GetLength(0))];
                    }
                    else if (j == layers_num - 1)//out
                    {
                        neuron_structure[j] = rnd.Next(m_config.output_neuron_num_min, m_config.output_neuron_num_max + 1);
                        function_structure[j] = m_config.output_layer_functions_allowed[rnd.Next(m_config.output_layer_functions_allowed.GetLength(0))];
                    }
                    else {//hidden
                        neuron_structure[j] = rnd.Next(m_config.hidden_neuron_num_min, m_config.hidden_neuron_num_max + 1);
                        function_structure[j] = m_config.hidden_layer_functions_allowed[rnd.Next(m_config.hidden_layer_functions_allowed.GetLength(0))];
                    }
                        
                }
                //neuron_structure[layers_num - 1] = m_config.max_neurons_structure.Last();
                NN_population[i] = new NeuralNetwork(Helper.GenerateString(10, rnd),layers_num,neuron_structure,function_structure);
            }
            for (m_cur_generation = 1; m_cur_generation <= m_config.generation_num && m_active; m_cur_generation++)
            {
                double t = 0;
                for (int ni = 0; ni < m_config.generation_size; ni++) t += NN_population[ni].Network_layers_num;
                this.m_av_layers_num_cur = t / Convert.ToDouble(m_config.generation_size);
                t = 0;
                for (int ni = 0; ni < m_config.generation_size; ni++) t += NN_population[ni].Network_neuron_structure[0];
                this.m_av_input_neurons_num_cur = t / Convert.ToDouble(m_config.generation_size);
                t = 0;
                int multilayer_networks = 0;
                for (int ni = 0; ni < m_config.generation_size; ni++){
                    if (NN_population[ni].Network_neuron_structure.GetLength(0) > 2) multilayer_networks++;
                    for (int j = 1; j < NN_population[ni].Network_neuron_structure.GetLength(0) - 1; j++)
                        t += Convert.ToDouble(NN_population[ni].Network_neuron_structure[j]) / Convert.ToDouble(NN_population[ni].Network_neuron_structure.GetLength(0) - 2);
                    }
                if (multilayer_networks != 0) 
                    this.m_av_hidden_neurons_num_cur = t / Convert.ToDouble(multilayer_networks);
                else this.m_av_hidden_neurons_num_cur = 0;
                this.m_av_layers_num[m_cur_generation - 1] = this.m_av_layers_num_cur;
                this.m_av_input_neurons_num[m_cur_generation - 1] = this.m_av_input_neurons_num_cur;
                this.m_av_hidden_neurons_num[m_cur_generation - 1] = this.m_av_hidden_neurons_num_cur;
                Helper.FileWrite(Config.ga_log_file_name, DateTime.Now.ToString("h:mm:ss tt") + " Processing generation " + m_cur_generation + ".");
                ResultAnalysis.AnalisysReport[] analisys_reports = new ResultAnalysis.AnalisysReport[NN_population.GetLength(0)];
                for (int ni = 0; ni < m_config.generation_size; ni++)
                {
                    //training each NN
                    int ix_ind = NN_population[ni].Network_neuron_structure[0] - m_config.input_neuron_num_min;
                    NN_population[ni].WeightsRandom(rnd,m_config);
                    NN_population[ni].NetworkTraining(IXtr[ix_ind], OXtr[ix_ind], IXtt[ix_ind], OXtt[ix_ind], m_config);
                    //stat analisys
                    NN_population[ni].NetworkSave();
                    analisys_reports[ni] = ResultAnalysis.CalculateParams(NN_population[ni], IXtr[ix_ind], OXtr[ix_ind], IXtt[ix_ind], OXtt[ix_ind], min_v, max_v, d1, d2);
                    if (analisys_reports[ni].St_deviation_tr < m_min_st_dev_tr) { m_min_st_dev_tr = analisys_reports[ni].St_deviation_tr; m_min_st_dev_tr_nn_id = analisys_reports[ni].Nn.ID; m_min_st_dev_tr_gen_id = m_cur_generation; }
                    if (analisys_reports[ni].St_deviation_tt < m_min_st_dev_tt) { m_min_st_dev_tt = analisys_reports[ni].St_deviation_tt; m_min_st_dev_tt_nn_id = analisys_reports[ni].Nn.ID; m_min_st_dev_tt_gen_id = m_cur_generation; }
                    if (analisys_reports[ni].Mae_tr < m_min_mae_tr) { m_min_mae_tr = analisys_reports[ni].Mae_tr; m_min_mae_nn_tr_nn_id = analisys_reports[ni].Nn.ID; m_min_mae_nn_tr_gen_id = m_cur_generation; }
                    if (analisys_reports[ni].Mae_tt < m_min_mae_tt) { m_min_mae_tt = analisys_reports[ni].Mae_tt; m_min_mae_nn_tt_nn_id = analisys_reports[ni].Nn.ID; m_min_mae_nn_tt_gen_id = m_cur_generation; }
                    if (analisys_reports[ni].Mape_tr < m_min_mape_tr) { m_min_mape_tr = analisys_reports[ni].Mape_tr; m_min_mape_tr_nn_id = analisys_reports[ni].Nn.ID; m_min_mape_tr_gen_id = m_cur_generation; }
                    if (analisys_reports[ni].Mape_tt < m_min_mape_tt) { m_min_mape_tt = analisys_reports[ni].Mape_tt; m_min_mape_tt_nn_id = analisys_reports[ni].Nn.ID; m_min_mape_tt_gen_id = m_cur_generation; }
                }
                //здесь сравнение, скорее всего лучше сравнивать по мае
                double rev_koef_tt = 0.0;
                double av_mae_tr_for_generation = 0;
                double av_mae_tt_for_generation = 0;
                double av_st_dev_tr_for_generation = 0;
                double av_st_dev_tt_for_generation = 0;
                double av_mape_tr_for_generation = 0;
                double av_mape_tt_for_generation = 0;
                double[] pick_chance = new double[m_config.generation_size];//шанс быть выбраным для размножения
                for (int ni = 0; ni < m_config.generation_size; ni++)
                {
                    rev_koef_tt += 1 / analisys_reports[ni].Mae_tt;
                    av_mae_tt_for_generation += analisys_reports[ni].Mae_tt;
                    av_mae_tr_for_generation += analisys_reports[ni].Mae_tr;
                    av_mape_tt_for_generation += analisys_reports[ni].Mape_tt;
                    av_mape_tr_for_generation += analisys_reports[ni].Mape_tr;
                    av_st_dev_tr_for_generation += analisys_reports[ni].St_deviation_tr;
                    av_st_dev_tt_for_generation += analisys_reports[ni].St_deviation_tt; 
                }
                lock (locker)
                {
                    this.m_av_mae_tt[m_cur_generation - 1] = av_mae_tt_for_generation = av_mae_tt_for_generation / NN_population.GetLength(0);
                    this.m_av_mae_tr[m_cur_generation - 1] = av_mae_tr_for_generation = av_mae_tr_for_generation / NN_population.GetLength(0);
                    this.m_av_mape_tt[m_cur_generation - 1] = av_mape_tt_for_generation = av_mape_tt_for_generation / NN_population.GetLength(0);
                    this.m_av_mape_tr[m_cur_generation - 1] = av_mape_tr_for_generation = av_mape_tr_for_generation/ NN_population.GetLength(0);
                    this.m_av_st_dev_tr[m_cur_generation - 1] = av_st_dev_tr_for_generation = av_st_dev_tr_for_generation/ NN_population.GetLength(0);
                    this.m_av_st_dev_tt[m_cur_generation - 1] = av_st_dev_tt_for_generation = av_st_dev_tt_for_generation / NN_population.GetLength(0);
                }
                for (int ni = 0; ni < m_config.generation_size; ni++) pick_chance[ni] = 1 / analisys_reports[ni].Mae_tt / rev_koef_tt;
                //double a = pick_chance.Sum();
                
                double average_layers_num=0;
                for (int ni = 0; ni < m_config.generation_size; ni++) average_layers_num += NN_population[ni].Network_layers_num;
                average_layers_num /= m_config.generation_size;
               /* Console.WriteLine("Generation " + geni + ": " + ". Average LN = " + average_layers_num.ToString("0.##") + ".");
                Console.WriteLine(Helper.AlignCentre("Average tr. st. dev = " + average_st_dev_tr_for_generation.ToString("0.##"), width) + Helper.AlignCentre(" Average tt. st. dev = " + average_st_dev_tt_for_generation.ToString("0.##"), width));
                Console.WriteLine(Helper.AlignCentre("Average tr. MAE = " + average_mae_tr_for_generation.ToString("0.##"), width) + Helper.AlignCentre(" Average tt. MAE = " + average_mae_tt_for_generation.ToString("0.##"), width));
                Console.WriteLine(Helper.AlignCentre("Average tr. MAPE = " + average_mape_tr_for_generation.ToString("0.##"), width) + Helper.AlignCentre(" Average tt. MAPE = " + average_mae_tt_for_generation.ToString("0.##"), width));*/
                for (int chi = 0; chi < m_config.generation_size; chi++)
                {
                    int p1i, p2i;
                    PickTwo(analisys_reports, pick_chance, out  p1i, out  p2i, rnd, m_config);
                    NN_next_population[chi] = NeuralNetwork.NetworkInherit(NN_population[p1i], NN_population[p2i], rnd, m_config);
                }

                for (int chi = 0; chi < m_config.generation_size; chi++)
                    NN_population[chi] = NN_next_population[chi];
                
            }

            Helper.FileWrite(Config.ga_log_file_name, DateTime.Now.ToString("h:mm:ss tt") + " Selection is over. Results:");
            Helper.FileWrite(Config.ga_log_file_name, "Min tr. st. deviation = " + m_min_st_dev_tr + " at " + m_min_st_dev_tr_nn_id + " Network: " + m_min_st_dev_tr_nn_id);
            Helper.FileWrite(Config.ga_log_file_name, "Min tt. st. deviation = " + m_min_st_dev_tt + " at " + m_min_st_dev_tt_gen_id + " Network: " + m_min_st_dev_tt_nn_id);
            Helper.FileWrite(Config.ga_log_file_name, "Min tr. MAE = " + m_min_mae_tr + " at " + m_min_mae_nn_tr_gen_id + " Network: " + m_min_mae_nn_tr_nn_id);
            Helper.FileWrite(Config.ga_log_file_name, "Min tt. MAE = " + m_min_mae_tt + " at " + m_min_mae_nn_tt_gen_id + " Network: " + m_min_mae_nn_tt_nn_id);
            Helper.FileWrite(Config.ga_log_file_name, "Min tr. MAPE = " + m_min_mape_tr + " at " + m_min_mape_tr_gen_id + " Network: " + m_min_mape_tr_nn_id);
            Helper.FileWrite(Config.ga_log_file_name, "Min tt. MAPE = " + m_min_mape_tt + " at " + m_min_mape_tt_gen_id + " Network: " + m_min_mape_tt_nn_id);
            
        }
        private static void PickTwo(ResultAnalysis.AnalisysReport[] _analisys_reports, double[] _pick_chance, out int _i1, out int _i2, Random _rnd, Config _config)
        {

            double ch1 = _rnd.NextDouble();
            double ch2 = _rnd.NextDouble();
            double s = 0;
            _i1=_i2 = 0;
            for (int ni = 0; ni < _config.generation_size; ni++)
            {
                s += _pick_chance[ni];
                if (s >= ch1) { _i1 = ni; break; }
            }
            double[] pick_chance_no_elem = new double[_pick_chance.GetLength(0)-1];

            double rev_koef_tt = 0.0;
            double[] pick_chance = new double[_config.generation_size];//шанс быть выбраным для размножения
            for (int ni = 0; ni < _config.generation_size; ni++) if (ni != _i1) rev_koef_tt += 1 / _analisys_reports[ni].Mae_tt;
            int ind = 0;
            for (int ni = 0; ni < _config.generation_size; ni++) if (ni != _i1) pick_chance_no_elem[ind++] = 1 / _analisys_reports[ni].Mae_tt / rev_koef_tt;
            s = 0;
            for (int ni = 0; ni < _config.generation_size; ni++)
            {
                s += pick_chance_no_elem[ni];
                if (s >= ch2) { _i2 = ni; break; }
            }
            if (_i2 >= _i1) _i2++;
        }
    }
}
