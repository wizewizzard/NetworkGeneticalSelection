using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithmForNeuralNetwork.NeuralNetworkNS
{
    class InputLayer : Layer
    {
        public InputLayer(String _ID, int _neuron_num, int _inputs_num, int _transfer_function)
            : base(_ID, _neuron_num, _inputs_num, _transfer_function) {}
        public override void WeightsRandom(Random _rnd, Config _config)
        {
            for (int i = 0; i < m_neuron_num; i++)
                for (int j = 0; j < m_inputs_num; j++)
                {
                    weights[j, i] = 1.0;
                }
        }
        public override void WeightsZero()
        {
            for (int i = 0; i < m_neuron_num; i++)
                for (int j = 0; j < m_inputs_num; j++)
                {
                    weights[j, i] = 1.0;
                }
        }
        public override void LayerProc()
        {
            outputs = inputs;
        }
    }
}
