using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithmForNeuralNetwork.NeuralNetworkNS
{
   class OutputLayer : Layer
    {
        public OutputLayer(String _ID, int _neuron_num, int _inputs_num, int _transfer_function)
            : base(_ID, _neuron_num, _inputs_num, _transfer_function) { }
        public override void WeightsRandom(Random _rnd, Config _config)
        {
            double MIN_VALUE = _config.min_weight_value;
            double MAX_VALUE = _config.max_weight_value;
            int PRECISION = 1000;

            int min = (int)(MIN_VALUE * PRECISION);
            int max = (int)(MAX_VALUE * PRECISION);

            for (int i = 0; i < m_neuron_num; i++)
                for (int j = 0; j < m_inputs_num; j++)
                {
                    weights[j, i] = _rnd.Next(min, max + 1);
                    weights[j, i] /= PRECISION;
                }
        }
        public override void WeightsZero()
        {
            for (int i = 0; i < m_neuron_num; i++)
                for (int j = 0; j < m_inputs_num; j++)
                {
                    weights[j, i] = 0.0;
                }
        }
        public override void LayerProc()
        {
            if (inputs == null || weights == null) throw new Exception("Layer " + this.ID + " can't process data.");
            double[] nets;
            outputs = new double[Neuron_num];
            nets = Helper.MatrixMultiplication(inputs, weights);

            for (int i = 0; i < Neuron_num; i++)
            {
                outputs[i] = Helper.functions[Transfer_function](nets[i]);
            }
        }
    }
}
