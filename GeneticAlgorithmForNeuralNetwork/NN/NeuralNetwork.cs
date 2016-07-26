using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GeneticAlgorithmForNeuralNetwork.NeuralNetworkNS
{
    partial class NeuralNetwork : INNInstance
    {
        private bool training_mode;
        private double[][] m_layers_outputs;
        private double[][] m_layers_inputs;
        private string m_ID;
        public string ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        private Layer[] m_layers;
        private int[] m_neuron_structure;
        private int[] m_function_strucure;
        private TrainingReport m_last_training_report;
        public int[] Network_neuron_structure
        {
            get { return m_neuron_structure; }
            set { m_neuron_structure = value; }
        }
        public int[] Network_function_structure
        {
            get { return m_function_strucure; }
            set { m_function_strucure = value; }
        }
        public int Network_layers_num
        {
            get { return m_layers.GetLength(0); }
        }
        //constr
        public NeuralNetwork(string _ID)
        {
            m_last_training_report = null;
            m_layers_outputs = m_layers_inputs = null;
            training_mode = false;
            this.m_ID = _ID;
            this.NetworkLoad();
        }
        public NeuralNetwork(string _ID, int _layers_num, int[] _neuron_structure, int[] _function_strucure)
        {
            this.m_ID = _ID;
            m_last_training_report = null;
            training_mode = false;
            m_layers_outputs = m_layers_inputs = null;
            m_neuron_structure = new int[_layers_num];
            m_function_strucure = new int[_layers_num];
            Array.Copy(_neuron_structure,m_neuron_structure,_layers_num);
            Array.Copy(_function_strucure,m_function_strucure,_layers_num);
            m_layers = new Layer[_layers_num];
            m_layers[0] = new InputLayer("InputLayer", _neuron_structure[0], _neuron_structure[0], _function_strucure[0]);
            for (int i = 1; i < _layers_num; i++)
                m_layers[i] = new HiddenLayer("OutputLayer", _neuron_structure[i], _neuron_structure[i - 1], _function_strucure[i]);
            m_layers[_layers_num - 1] = new OutputLayer("OutputLayer", _neuron_structure[_layers_num - 1], _neuron_structure[_layers_num - 2], _function_strucure[_layers_num - 1]);

        }
        //training
        public class TrainingReport {
            private double[] m_train_errors;
            public double[] Train_errors
            {
                get { return m_train_errors; }
                set { m_train_errors = value; }
            }
            private double[] m_test_error;
            public double[] Test_error
            {
                get { return m_test_error; }
                set { m_test_error = value; }
            }
            private int m_epochs_num;
            public int Epochs_num
            {
                get { return m_epochs_num; }
                set { m_epochs_num = value; }
            }
            public TrainingReport(double[] _tr_errors, double[] _tt_errors, int _epoch)
            {
                m_train_errors = new double[_epoch];
                m_test_error = new double[_epoch];
                m_epochs_num = _epoch;
                Array.Copy(_tr_errors, m_train_errors, m_epochs_num);
                Array.Copy(_tt_errors, m_test_error, m_epochs_num);
            }
        }
        //proc
        public double[] NetworkProc(double[] _IX)
        {
            if (training_mode)
            {
                double[] inputs = new double[_IX.GetLength(0)];
                double[] outputs = new double[_IX.GetLength(0)];
                Array.Copy(_IX, outputs, _IX.GetLength(0));
                for (int i = 0; i < this.m_layers.GetLength(0); i++)
                {
                    inputs = outputs;
                    Array.Copy(inputs, this.m_layers_inputs[i], outputs.GetLength(0));
                    m_layers[i].SetInputs(inputs);
                    m_layers[i].LayerProc();
                    outputs = m_layers[i].GetOutputs();
                    Array.Copy(outputs, this.m_layers_outputs[i], outputs.GetLength(0));
                }
                return outputs;
            }
            else
            {
                double[] inputs = new double[_IX.GetLength(0)];
                double[] outputs = new double[_IX.GetLength(0)];
                Array.Copy(_IX, outputs, _IX.GetLength(0));
                for (int i = 0; i < this.m_layers.GetLength(0); i++)
                {
                    inputs = outputs;
                    m_layers[i].SetInputs(inputs);
                    m_layers[i].LayerProc();
                    outputs = m_layers[i].GetOutputs();
                }
                return outputs;
            }
        }
        //training
        public void WeightsRandom(Random _rnd, Config _config)
        {
            foreach (Layer l in m_layers) l.WeightsRandom(_rnd, _config);
        }
        public void WeightsZero()
        {
            foreach (Layer l in m_layers) l.WeightsZero();
        }
        public void StateSave(int _epoch)
        {
            string path = Path.Combine(Config.project_folder, Config.state_folder, Config.state_file_name.Replace("*", this.m_ID));
            int size_of = sizeof(int) * 2 + m_neuron_structure.GetLength(0) * sizeof(int) + m_function_strucure.GetLength(0) * sizeof(int);
            using (var stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None))
            using (var writer = new BinaryWriter(stream))
            {
                    for (int i = 0; i < m_layers.GetLength(0); i++) size_of += m_layers[i].SizeOf();
                    writer.Write(size_of);
                    writer.Write(m_layers.GetLength(0));
                    foreach (int n in m_neuron_structure) writer.Write(n);
                    foreach (int f in m_function_strucure) writer.Write(f);
                    foreach (Layer l in m_layers) l.SaveLayer(writer);
            }
        }
        public void StateLoad(int _epoch)
        {
            string path = Path.Combine(Config.project_folder, Config.state_folder, Config.state_file_name.Replace("*", this.m_ID));
            int layers_num;
            if (!Helper.IsFileValid(path)) throw new FileLoadException("No input file.");
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var reader = new BinaryReader(stream))
            {
                int size_of = reader.ReadInt32();
                reader.BaseStream.Seek(size_of * (_epoch-1), SeekOrigin.Current);
                layers_num = reader.ReadInt32();
                m_layers = new Layer[layers_num];
                m_neuron_structure = new int[layers_num];
                m_function_strucure = new int[layers_num];
                for (int i = 0; i < layers_num; i++)
                    m_neuron_structure[i] = reader.ReadInt32();
                for (int i = 0; i < layers_num; i++)
                    m_function_strucure[i] = reader.ReadInt32();
                m_layers[0] = new InputLayer("InputLayer", m_neuron_structure[0], m_neuron_structure[0], m_function_strucure[0]);
                for (int i = 1; i < layers_num; i++)
                    m_layers[i] = new HiddenLayer("HiddenLayer", m_neuron_structure[i], m_neuron_structure[i - 1], m_function_strucure[i]);
                m_layers[layers_num - 1] = new OutputLayer("OutputLayer", m_neuron_structure[layers_num - 1], m_neuron_structure[layers_num - 2], m_function_strucure[layers_num - 1]);
                for (int i = 0; i < layers_num; i++)
                    m_layers[i].LoadLayer(reader);
            }
        }
        public void SetTrainingMode(bool v)
        {
            training_mode = v;
            if (training_mode)
            {
                m_layers_outputs = new double[m_layers.GetLength(0)][];
                m_layers_inputs = new double[m_layers.GetLength(0)][];
                for (int i = 0; i < m_layers.GetLength(0); i++)
                {
                    m_layers_inputs[i] = new double[m_layers[i].Inputs_num];
                    m_layers_outputs[i] = new double[m_layers[i].Neuron_num];
                }
            }
            else { 
                m_layers_inputs = m_layers_outputs = null;
                if (File.Exists(Path.Combine(Config.project_folder, Config.state_folder, Config.state_file_name.Replace("*", this.m_ID))))
                    File.Delete(Path.Combine(Config.project_folder, Config.state_folder, Config.state_file_name.Replace("*", this.m_ID)));
            }
        }
        public void NetworkTraining(double[][] IXtr, double[][] OXtr, //обучающая выборка
                double[][] IXtt, double[][] OXtt, Config _config)
        {//тестовая выборка
            
            this.SetTrainingMode(true);
            int input_dimension = IXtr[0].GetLength(0);
            int output_dim = OXtr[0].GetLength(0);
            double train_error=0.0, test_error=0.0;
            int epoch;
            double[][] shuffled_IXtr=IXtr.Select(s => s.ToArray()).ToArray();
            double[][] shuffled_OXtr=OXtr.Select(s => s.ToArray()).ToArray();
            double[][,] corrected_weights;
            double[] tr_errors_array = new double[_config.epoch_num];
            double[] tt_errors_array = new double[_config.epoch_num];
            corrected_weights = new double[m_layers.GetLength(0)][,];
            for (int li = 0; li < m_layers.GetLength(0); li++)
            {
                corrected_weights[li] = new double[m_layers[li].Inputs_num,m_layers[li].Neuron_num];
                for (int ii = 0; ii < m_layers[li].Inputs_num; ii++)
                    for (int ni = 0; ni < m_layers[li].Neuron_num; ni++)
                        corrected_weights[li][ii,ni] = m_layers[li].weights[ii,ni];
            }
            
            double[] error_values = new double[shuffled_OXtr[0].GetLength(0)];
            double learning_rate = _config.learning_rate;
            Helper.FileWrite(Config.network_log_file_name, DateTime.Now.ToString("h:mm:ss tt") + " Training for " + this.m_ID + " has been initialized.");
            for (epoch = 1; epoch <= _config.epoch_num; epoch++)
            {
                learning_rate = _config.LearningRateFunction(epoch);
               // Helper.FileWrite(Config.network_log_file_name, DateTime.Now.ToString("h:mm:ss tt") + " Epoch " + epoch + " has started.");
                Helper.ShufflePair(shuffled_IXtr, shuffled_OXtr);
                //Console.WriteLine(this.GetAllInfo());
                for(int i=0;i<shuffled_IXtr.GetLength(0); i++){
                    double[] output = this.NetworkProc(shuffled_IXtr[i]);
                    if(output.GetLength(0) != output_dim) throw new Exception("Wrong output dimension.");
                    double Di = 0.0;
                    for (int j = 0; j < output.GetLength(0); j++)
                        Di += (output[j] - shuffled_OXtr[i][j]) * (output[j] - shuffled_OXtr[i][j]);
                    train_error += Di;
                }
                for (int i = 0; i < IXtt.GetLength(0); i++)
                {
                    double[] output = this.NetworkProc(IXtt[i]);
                    if (output.GetLength(0) != output_dim) throw new Exception("Wrong output dimension.");
                    double Di = 0.0;
                    for (int j = 0; j < output.GetLength(0); j++) Di += (output[j] - OXtt[i][j]) * (output[j] - OXtt[i][j]);
                    test_error += Di;
                }

                tr_errors_array[epoch - 1] = train_error = Math.Sqrt(train_error / shuffled_OXtr.GetLength(0));
                tt_errors_array[epoch - 1] = test_error = Math.Sqrt(test_error / OXtt.GetLength(0));

                //if (Double.IsNaN(train_error) || Double.IsNaN(test_error)) break;

                if (_config.error_val_required >= train_error && _config.error_val_required >= test_error)
                {
                    this.SetTrainingMode(false);
                    this.m_last_training_report = new TrainingReport(tr_errors_array, tt_errors_array, epoch);
                    Helper.FileWrite(Config.network_log_file_name, DateTime.Now.ToString("h:mm:ss tt") + " Training has finished for " + epoch + " epochs.");
                    Helper.FileWrite(Config.network_log_file_name, "Tr. error = " + train_error / shuffled_IXtr.GetLength(0) + " Test error = " + test_error / IXtt.GetLength(0));
                    WindowFunctions.ShowGraphs(new string[] { "tr", "tt" }, tr_errors_array, tt_errors_array);
                    return;
                }
                if (epoch % Config.log_write_epoch_intensivity == 0)
                {
                    Helper.FileWrite(Config.network_log_file_name, " Epoch = " + epoch + " Tr. error = " + train_error / shuffled_IXtr.GetLength(0) + " Test error = " + test_error / IXtt.GetLength(0));
                }
                this.StateSave(epoch);
                train_error = 0.0;
                test_error = 0.0;
                //обучить сеть в epoch эпохе на i-ых примерах
                for (int i = 0; i < shuffled_IXtr.GetLength(0); i++)
                {
                    double[] output = this.NetworkProc(shuffled_IXtr[i]);
                    if (output.GetLength(0) != output_dim) throw new Exception("Wrong output dimension.");
                    for (int j = 0; j < output.GetLength(0); j++)
                        error_values[j] = shuffled_OXtr[i][j] - output[j];
                    double sum_error = 0.0;
                    for (int j = 0; j < output.GetLength(0); j++)
                        sum_error += Math.Abs(error_values[j]);
                    if (sum_error > _config.error_val_required)
                    {
                        BackPropagationRecursive(learning_rate, m_layers.GetLength(0) - 1, ref corrected_weights, error_values);
                        for (int li = 0; li < m_layers.GetLength(0); li++) Array.Copy(corrected_weights[li], 0, m_layers[li].weights, 0, corrected_weights[li].Length);
                    }
                }
            }
            double tr_min_val, tt_min_val;
            int tr_min_val_ind, tt_min_val_ind;
            tr_min_val = tt_min_val = tr_min_val_ind = tt_min_val_ind = -1;
            for (int i = 0; i < tr_errors_array.GetLength(0); i++)
            {
                if (Double.IsNaN(tr_errors_array[i])) tr_errors_array[i] = -1;
                else if (tr_min_val == -1 || tr_min_val > tr_errors_array[i])
                {
                    tr_min_val = tr_errors_array[i];
                    tr_min_val_ind = i;
                }
                if (Double.IsNaN(tt_errors_array[i])) tt_errors_array[i] = -1;
                else if (tt_min_val == -1 || tt_min_val > tt_errors_array[i])
                {
                    tt_min_val = tt_errors_array[i];
                    tt_min_val_ind = i;
                }
            }
            int epoch_of_min_error = tt_min_val_ind+1;
            try
            {
                this.StateLoad(epoch_of_min_error);
            }
            catch (FileLoadException exc)
            {
                Helper.FileWrite(Config.network_log_file_name, DateTime.Now.ToString("h:mm:ss tt") + exc.Message + " Weights will be zeroed.");
                this.WeightsZero();
                this.m_last_training_report = new TrainingReport(tr_errors_array, tt_errors_array, 0);
                this.SetTrainingMode(false);
                return;
            }
            this.m_last_training_report = new TrainingReport(tr_errors_array, tt_errors_array, epoch_of_min_error);
            //WindowFunctions.ShowGraphs(new string[] { "tr_error", "tt_error" }, tr_errors_array, tt_errors_array);
            this.SetTrainingMode(false);
            Helper.FileWrite(Config.network_log_file_name, DateTime.Now.ToString("h:mm:ss tt") + " Epochs number = " + _config.epoch_num + " has been exhausted. " + "Loading epoch... " + epoch_of_min_error + " Tr. error = " + tr_errors_array[tt_min_val_ind] + " Tt. error = " + tt_errors_array[tt_min_val_ind]);
            //Helper.FileWrite(Config.network_log_file_name, "Tr. error = " + train_error / shuffled_IXtr.GetLength(0) + " Test error = " + test_error/ IXtt.GetLength(0));
            //Console.WriteLine(test_error.ToString());
           // Console.WriteLine(train_error.ToString());
        }
        private void BackPropagationRecursive(double _learning_rate, int _cur_layer, ref double[][,] _corrected_weights, double[] _data_buffer)
        {
            if (_cur_layer == 0) return;//input layer
            if (_cur_layer == this.m_layers.GetLength(0) - 1){//last layer
                double[] _layer_deltas = new double[m_layers[_cur_layer].Neuron_num];
                for (int ni = 0; ni < m_layers[_cur_layer].Neuron_num; ni++)
                {
                    for (int ii = 0; ii < m_layers[_cur_layer].Inputs_num; ii++)
                    {
                        double delta_ni = 0.0;
                        //double[] nets = Helper.MatrixMultiplication(m_layers_inputs[_cur_layer], m_layers[_cur_layer].weights);
                        _layer_deltas[ni] = delta_ni = _data_buffer[ni] * Helper.functions_deriviate_out[m_layers[_cur_layer].Transfer_function](m_layers_outputs[_cur_layer][ni]);
                        _corrected_weights[_cur_layer][ii,ni] += 2 * _learning_rate * delta_ni * m_layers_inputs[_cur_layer][ii];
                    }
                }
                BackPropagationRecursive(_learning_rate, _cur_layer - 1, ref _corrected_weights, _layer_deltas);
            }
            else
            {
                double[] _layer_deltas = new double[m_layers[_cur_layer].Neuron_num];
                for (int ni = 0; ni < m_layers[_cur_layer].Neuron_num; ni++)
                {
                    for (int ii = 0; ii < m_layers[_cur_layer].Inputs_num; ii++)
                    {
                        double delta_ni = 0.0;
                        double sum = 0.0;
                        for(int pr_l_n =0; pr_l_n < m_layers[_cur_layer+1].Neuron_num; pr_l_n++) sum += _data_buffer[pr_l_n]*m_layers[_cur_layer+1].weights[ni, pr_l_n];
                        _layer_deltas[ni] = delta_ni = Helper.functions_deriviate_out[m_layers[_cur_layer].Transfer_function](m_layers_outputs[_cur_layer][ni]) * sum;
                        _corrected_weights[_cur_layer][ii, ni] += 2 * _learning_rate * delta_ni * m_layers_inputs[_cur_layer][ii];
                    }
                }
                BackPropagationRecursive(_learning_rate, _cur_layer - 1, ref _corrected_weights, _layer_deltas);
            }
        }        
        //print
        public string GetBriefInfo()
        {
            string str = "";
            str += this.m_ID + "\n";
            int[] nn_structure = new int[m_layers.GetLength(0)];
            int[] func_structure = new int[m_layers.GetLength(0)];
            for (int i = 0; i < m_layers.GetLength(0); i++)
            {
                //str += m_layers[i].GetBriefInfo() + "\n";
                nn_structure[i] = m_layers[i].Neuron_num;
                func_structure[i] = m_layers[i].Transfer_function;
            }
            str+=String.Join("-", nn_structure) + "\n";
            str+=String.Join("-", func_structure) + "\n";
            if (m_last_training_report != null)
            {
                str += "Epochs for learning = " + m_last_training_report.Epochs_num + "\n";
                str += "Tr. error = " + m_last_training_report.Train_errors[m_last_training_report.Epochs_num - 1];
                str += " Tt. error = " + m_last_training_report.Train_errors[m_last_training_report.Epochs_num - 1];
                str += "\n";
            }
            return str;
        }
        public string GetAllInfo()
        {
            string str = "";
            str += this.m_ID;
            str += "\n";
            string str2="";
            int[] nn_structure = new int[m_layers.GetLength(0)];
            for (int i = 0; i < m_layers.GetLength(0); i++)
            {
                str2 += m_layers[i].ID + "\n";
                str2 += m_layers[i].GetAllInfo() + "\n";
                nn_structure[i] = m_layers[i].Neuron_num;
            }
            str +=str2.Insert(0, String.Join("-", nn_structure) + "\n");
            return str;
        }
        public void NetworkSave()
        {
            String path = Path.Combine(Config.project_folder, Config.save_folder, Config.save_file_name.Replace("*", this.m_ID));
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(m_layers.GetLength(0));
                foreach (int n in m_neuron_structure) writer.Write(n);
                foreach (int f in m_function_strucure) writer.Write(f);
                foreach (Layer l in m_layers) l.SaveLayer(writer);
            }
        }
        public void NetworkLoad()
        {
            String path = Path.Combine(Config.project_folder, Config.save_folder, Config.save_file_name.Replace("*", this.m_ID));
            int layers_num;
            if (!Helper.IsFileValid(path)) throw new FileLoadException("No input file.");
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var reader = new BinaryReader(stream))
            {
                layers_num = reader.ReadInt32();
                m_layers = new Layer[layers_num];
                m_neuron_structure = new int[layers_num];
                m_function_strucure = new int[layers_num];
                for (int i = 0; i < layers_num; i++)
                    m_neuron_structure[i] = reader.ReadInt32();
                for (int i = 0; i < layers_num; i++)
                    m_function_strucure[i] = reader.ReadInt32();
                m_layers[0] = new InputLayer("InputLayer", m_neuron_structure[0], m_neuron_structure[0], m_function_strucure[0]);
                for (int i = 1; i < layers_num; i++)
                    m_layers[i] = new HiddenLayer("HiddenLayer", m_neuron_structure[i], m_neuron_structure[i - 1], m_function_strucure[i]);
                m_layers[layers_num - 1] = new OutputLayer("OutputLayer", m_neuron_structure[layers_num - 1], m_neuron_structure[layers_num - 2], m_function_strucure[layers_num - 1]);
                for(int i=0; i < layers_num; i++)
                    m_layers[i].LoadLayer(reader);
            }
            
        }
}
}
