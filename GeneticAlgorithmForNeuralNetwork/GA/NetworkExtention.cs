using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithmForNeuralNetwork.NeuralNetworkNS
{
    partial class NeuralNetwork
    {
        public static NeuralNetwork NetworkInherit(NeuralNetwork _nn1, NeuralNetwork _nn2, Random _rnd, Config _config)
        {
            //сначала структуру, затем возможно веса, не знаю надо ли их наследовать
            double mut_chance;
            int layers_num;
            mut_chance = _rnd.NextDouble();
            if (mut_chance > _config.mutation_chance)
            { //нет мутации по колчиеству слоев
                if (_rnd.Next(0, 2) == 0) layers_num = _nn1.m_layers.GetLength(0);
                else layers_num = _nn2.m_layers.GetLength(0);

                int[] neuron_structure = new int[layers_num];
                int[] function_structure = new int[layers_num];
                for (int li = 0; li < layers_num; li++)
                {
                    int min_n=0, max_n=0;
                    if (li == 0) { min_n = _config.input_neuron_num_min; max_n = _config.input_neuron_num_max; }
                    else if (li == layers_num - 1) { min_n = _config.output_neuron_num_max; max_n = _config.output_neuron_num_max; }
                    else { min_n = _config.hidden_neuron_num_max; max_n = _config.hidden_neuron_num_max; }
                    mut_chance = _rnd.NextDouble();//колчиество нейронов в слоях
                    if (mut_chance > _config.mutation_chance)
                    {
                        if (li < _nn1.m_layers.GetLength(0) && _rnd.Next(0, 2) == 0) neuron_structure[li] = _nn1.Network_neuron_structure[li];
                        else if (li < _nn2.m_layers.GetLength(0)) neuron_structure[li] = _nn2.Network_neuron_structure[li];
                        else neuron_structure[li] = _nn1.Network_neuron_structure[li];
                    }
                    else//мутация по количеству нейронов
                    {
                        if (li < _nn1.m_layers.GetLength(0) && li < _nn2.m_layers.GetLength(0))//учитываем обе сети
                        {
                            if (_rnd.Next(0, 2) == 0)
                                if (_rnd.Next(0, 2) == 0)
                                    if (_nn1.Network_neuron_structure[li] - 1 >= min_n) neuron_structure[li] = _nn1.Network_neuron_structure[li] - 1;
                                    else neuron_structure[li] = _nn1.Network_neuron_structure[li];
                                else if (_nn2.Network_neuron_structure[li] - 1 >= min_n) neuron_structure[li] = _nn2.Network_neuron_structure[li] - 1;
                                else neuron_structure[li] = _nn2.Network_neuron_structure[li];
                            else 
                                if (_rnd.Next(0, 2) == 0)
                                    if (_nn1.Network_neuron_structure[li] + 1 <= max_n) neuron_structure[li] = _nn1.Network_neuron_structure[li] + 1;
                                    else neuron_structure[li] = _nn1.Network_neuron_structure[li];
                                else if (_nn2.Network_neuron_structure[li] + 1 <= max_n) neuron_structure[li] = _nn2.Network_neuron_structure[li] + 1;
                                else neuron_structure[li] = _nn2.Network_neuron_structure[li];
                        }
                        else if (li < _nn1.m_layers.GetLength(0))//учесть только 1
                        {
                            if (_rnd.Next(0, 2) == 0)
                                if (_nn1.Network_neuron_structure[li] - 1 >= min_n) neuron_structure[li] = _nn1.Network_neuron_structure[li] - 1;
                                else neuron_structure[li] = _nn1.Network_neuron_structure[li];
                            else
                                if (_nn1.Network_neuron_structure[li] + 1 <= max_n) neuron_structure[li] = _nn1.Network_neuron_structure[li] + 1;
                                else neuron_structure[li] = _nn1.Network_neuron_structure[li];
                        }
                        else//учесть только 2
                        {
                            if (_rnd.Next(0, 2) == 0)
                                if (_nn2.Network_neuron_structure[li] - 1 >= min_n) neuron_structure[li] = _nn2.Network_neuron_structure[li] - 1;
                                else neuron_structure[li] = _nn2.Network_neuron_structure[li];
                            else
                                if (_nn2.Network_neuron_structure[li] + 1 <= max_n) neuron_structure[li] = _nn2.Network_neuron_structure[li] + 1;
                                else neuron_structure[li] = _nn2.Network_neuron_structure[li];
                        }
                    }
                }
                neuron_structure[layers_num - 1] = _config.output_neuron_num_max;
                for (int li = 0; li < layers_num; li++)
                {
                    mut_chance = _rnd.NextDouble();//функциональная структура
                    if (mut_chance > _config.mutation_chance)
                    {
                        if (li < _nn1.m_layers.GetLength(0) && _rnd.Next(0, 2) == 0) function_structure[li] = _nn1.Network_function_structure[li];
                        else if (li < _nn2.m_layers.GetLength(0)) function_structure[li] = _nn2.Network_function_structure[li];
                        else function_structure[li] = _nn1.Network_function_structure[li];
                    }
                    else
                    {
                        if (li == 0) { function_structure[li] = _config.input_layer_functions_allowed[_rnd.Next(_config.input_layer_functions_allowed.GetLength(0))]; }
                        else if (li == layers_num - 1) { function_structure[li] = _config.output_layer_functions_allowed[_rnd.Next(_config.hidden_layer_functions_allowed.GetLength(0))]; }
                        else { function_structure[li] = _config.hidden_layer_functions_allowed[_rnd.Next(_config.output_layer_functions_allowed.GetLength(0))]; }
                    
                        
                    }
                }
                return new NeuralNetwork(Helper.GenerateString(10, _rnd), layers_num, neuron_structure, function_structure);
            }
            else//мутация колчиества слоев, кажется здесь попросту надо рандомить все функции и колво нейронов
            {
                if (_rnd.Next(0, 2) == 0) layers_num = _nn1.m_layers.GetLength(0);
                else layers_num = _nn2.m_layers.GetLength(0);
                if (_rnd.Next(0, 2) == 0 && layers_num - 1 >= _config.layer_num_min) layers_num--;
                else if (layers_num + 1 <= _config.layer_num_max) layers_num++;

                int[] neuron_structure = new int[layers_num];
                int[] function_structure = new int[layers_num];
                for (int li = 0; li < layers_num; li++)
                {
                    int min_n = 0, max_n = 0;
                    if (li == 0) { min_n = _config.input_neuron_num_min; max_n = _config.input_neuron_num_max; }
                    else if (li == layers_num - 1) { min_n = _config.output_neuron_num_min; max_n = _config.output_neuron_num_max; }
                    else { min_n = _config.hidden_neuron_num_min; max_n = _config.hidden_neuron_num_max; }
                    mut_chance = _rnd.NextDouble();//колчиество нейронов в слоях
                    if (mut_chance > _config.mutation_chance && li < _nn1.m_layers.GetLength(0) - 1 && li < _nn2.m_layers.GetLength(0) - 1)
                    {
                        if (li < _nn1.m_layers.GetLength(0) && _rnd.Next(0, 2) == 0) neuron_structure[li] = _nn1.Network_neuron_structure[li];
                        else if (li < _nn2.m_layers.GetLength(0)) neuron_structure[li] = _nn2.Network_neuron_structure[li];
                        else neuron_structure[li] = _nn1.Network_neuron_structure[li];
                    }
                    else//мутация по количеству нейронов
                    {
                        if (li < _nn1.m_layers.GetLength(0) - 1 && li < _nn2.m_layers.GetLength(0) - 1)//учитываем обе сети
                        {
                            if (_rnd.Next(0, 2) == 0)
                                if (_rnd.Next(0, 2) == 0)
                                    if (_nn1.Network_neuron_structure[li] - 1 >= min_n) neuron_structure[li] = _nn1.Network_neuron_structure[li] - 1;
                                    else neuron_structure[li] = _nn1.Network_neuron_structure[li];
                                else if (_nn2.Network_neuron_structure[li] - 1 >= min_n) neuron_structure[li] = _nn2.Network_neuron_structure[li] - 1;
                                else neuron_structure[li] = _nn2.Network_neuron_structure[li];
                            else
                                if (_rnd.Next(0, 2) == 0)
                                    if (_nn1.Network_neuron_structure[li] + 1 <= max_n) neuron_structure[li] = _nn1.Network_neuron_structure[li] + 1;
                                    else neuron_structure[li] = _nn1.Network_neuron_structure[li];
                                else if (_nn2.Network_neuron_structure[li] + 1 <= max_n) neuron_structure[li] = _nn2.Network_neuron_structure[li] + 1;
                                else neuron_structure[li] = _nn2.Network_neuron_structure[li];
                        }
                        else if (li < _nn1.m_layers.GetLength(0) - 1)//учесть только 1
                        {
                            if (_rnd.Next(0, 2) == 0)
                                if (_nn1.Network_neuron_structure[li] - 1 >= min_n) neuron_structure[li] = _nn1.Network_neuron_structure[li] - 1;
                                else neuron_structure[li] = _nn1.Network_neuron_structure[li];
                            else
                                if (_nn1.Network_neuron_structure[li] + 1 <= max_n) neuron_structure[li] = _nn1.Network_neuron_structure[li] + 1;
                                else neuron_structure[li] = _nn1.Network_neuron_structure[li];
                        }
                        else if (li < _nn2.m_layers.GetLength(0) - 1)//учесть только 2
                        {
                            if (_rnd.Next(0, 2) == 0)
                                if (_nn2.Network_neuron_structure[li] - 1 >= min_n) neuron_structure[li] = _nn2.Network_neuron_structure[li] - 1;
                                else neuron_structure[li] = _nn2.Network_neuron_structure[li];
                            else
                                if (_nn2.Network_neuron_structure[li] + 1 <= max_n) neuron_structure[li] = _nn2.Network_neuron_structure[li] + 1;
                                else neuron_structure[li] = _nn2.Network_neuron_structure[li];
                        }
                        else
                        {
                            neuron_structure[li] = _rnd.Next(min_n, max_n);
                        }
                    }
                }
                neuron_structure[layers_num - 1] = _config.output_neuron_num_max;
                for (int li = 0; li < layers_num; li++)
                {
                    mut_chance = _rnd.NextDouble();//функциональная структура
                    if (mut_chance > _config.mutation_chance && li < _nn1.m_layers.GetLength(0) && li < _nn2.m_layers.GetLength(0))
                    {
                        if (_rnd.Next(0, 2) == 0) function_structure[li] = _nn1.Network_function_structure[li];
                        else function_structure[li] = _nn2.Network_function_structure[li];
                    }
                    else
                    {
                        if (li == 0) { function_structure[li] = _config.input_layer_functions_allowed[_rnd.Next(_config.input_layer_functions_allowed.GetLength(0))]; }
                        else if (li == layers_num - 1) { function_structure[li] = _config.output_layer_functions_allowed[_rnd.Next(_config.hidden_layer_functions_allowed.GetLength(0))]; }
                        else { function_structure[li] = _config.hidden_layer_functions_allowed[_rnd.Next(_config.output_layer_functions_allowed.GetLength(0))]; }
                    }
                }
                return new NeuralNetwork(Helper.GenerateString(10, _rnd), layers_num, neuron_structure, function_structure);
            }
        }
    }
}
