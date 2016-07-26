using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithmForNeuralNetwork
{
    public class Config
    {
        //unness
        public static readonly int table_width;
        public static readonly int column_width;
        public static readonly int log_write_epoch_intensivity;
        public static readonly double normalization_bound_low;
        public static readonly double normalization_bound_high;
        //data
        public string data_source;
        //for genetic algo
        public double mutation_chance;
        public int generation_num;
        public int layer_num_min;
        public int layer_num_max;
        public int input_neuron_num_min;
        public int input_neuron_num_max;
        public int hidden_neuron_num_min;
        public int hidden_neuron_num_max;
        public int output_neuron_num_min;
        public int output_neuron_num_max;
        public int[] input_layer_functions_allowed;
        public int[] hidden_layer_functions_allowed;
        public int[] output_layer_functions_allowed;
        public int generation_size;
        //public static readonly double[] survive_criterias;
        //paths
        public static readonly string project_folder;
        public static readonly string save_folder;
        public static readonly string save_file_name;
        public static readonly string state_folder;
        public static readonly string network_log_file_name;
        public static readonly string ga_log_file_name; 
        public static readonly string state_file_name;
        //training
        public int epoch_num;
        public double min_weight_value;
        public double max_weight_value;
        public double error_val_required;
        /*public static void ReadConfig() { }
        public static void SaveConfig() { }*/
        //learning rate
        public double learning_rate;
        public double learning_rate_max;
        static Config()
        {
            //common
            project_folder = @"C:/neural network";
            network_log_file_name = @"ANN.log";
            ga_log_file_name = @"GA.log";
            state_file_name = @"state_*.tmp";
            save_file_name = @"save_*.nn";
            save_folder = "Saved";
            state_folder = "States";
            log_write_epoch_intensivity = 50;
            //print
            table_width = 10;
            column_width = 15;
            normalization_bound_low = 0.0;
            normalization_bound_high = 1.0;
            /*survive_criterias = new double[6];
            survive_criterias[0] = Double.NegativeInfinity;//min res
            survive_criterias[1] = Double.PositiveInfinity;//max res
            survive_criterias[2] = Double.PositiveInfinity;//me
            survive_criterias[3] = Double.PositiveInfinity;//mae
            survive_criterias[4] = Double.PositiveInfinity;//mape
            survive_criterias[5] = Double.PositiveInfinity;//cor coef*/
            //min_neurons_structure = new int[]
        }
        public Config()
        {
            data_source = null;
            //training
            epoch_num = 100;
            min_weight_value = -0.5;
            max_weight_value = 0.5;
            error_val_required = 0.01;
            learning_rate = 0.1;
            learning_rate_max = 0.3;
            //ga
            generation_num = 50;
            mutation_chance = 0.05;
            generation_size = 5;
            layer_num_min = 2;
            layer_num_max = 3;

            input_neuron_num_min = 10;
            input_neuron_num_max = 30;
            hidden_neuron_num_min = 10;
            hidden_neuron_num_max = 20;
            output_neuron_num_min = 1;
            output_neuron_num_max = 1;

            input_layer_functions_allowed = new int[1];
            input_layer_functions_allowed[0] = 0;

            hidden_layer_functions_allowed = new int[Helper.function_types.GetLength(0)];
            output_layer_functions_allowed = new int[Helper.function_types.GetLength(0)];

            for (int i = 0; i < Helper.function_types.GetLength(0); i++)
                hidden_layer_functions_allowed[i] = output_layer_functions_allowed[i] = i;

        }
        public Config(string _ds)
        {
            data_source = _ds;
            //training
            epoch_num = 100;
            min_weight_value = -0.5;
            max_weight_value = 0.5;
            error_val_required = 0.01;
            learning_rate = 0.1;
            learning_rate_max = 0.3;
            //ga
            generation_num = 50;
            mutation_chance = 0.05;
            generation_size = 5;
            layer_num_min = 2;
            layer_num_max = 3;

            input_neuron_num_min = 10;
            input_neuron_num_max = 30;
            hidden_neuron_num_min = 10;
            hidden_neuron_num_max = 20;
            output_neuron_num_min = 1;
            output_neuron_num_max = 1;

            input_layer_functions_allowed = new int[1];
            input_layer_functions_allowed[0] = 0;

            hidden_layer_functions_allowed = new int[Helper.function_types.GetLength(0)];
            output_layer_functions_allowed = new int[Helper.function_types.GetLength(0)];

            for (int i = 0; i < Helper.function_types.GetLength(0); i++)
                hidden_layer_functions_allowed[i] = output_layer_functions_allowed[i] = i;
        }
        public double LearningRateFunction(int epoch) {
            return Math.Exp((Math.Log(learning_rate_max) - (Math.Pow(Convert.ToDouble(epoch) - (Convert.ToDouble(epoch_num)/ 2), 2) / 400)));
        }
        /*public static double CriteriaFunction(int _cr_id, int _ind_num)
        {
            if (_ind_num == 0) return Double.NaN;
            if(Double.IsInfinity(survive_criterias[_cr_id])) return survive_criterias[_cr_id];
            else return Math.Exp(Math.Log(survive_criterias[_cr_id]) - (Math.Pow(Convert.ToDouble(_ind_num) - (Convert.ToDouble(max_individ_num) / 2), 2) / 4000.0));
        }*/
        
    }
}
