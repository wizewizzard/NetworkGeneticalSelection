using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GeneticAlgorithmForNeuralNetwork.NeuralNetworkNS
{
    abstract class Layer : INNInstance
    {
        private String m_ID;

        public String ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        protected int m_neuron_num;
        protected internal int Neuron_num
        {
            get { return m_neuron_num; }
            set { m_neuron_num = value; }
        }
        protected int m_inputs_num;
        protected internal int Inputs_num
        {
            get { return m_inputs_num; }
            set { m_inputs_num = value; }
        }
        protected int m_transfer_function;
        protected internal int Transfer_function
        {
            get { return m_transfer_function; }
            set { m_transfer_function = value; }
        }

        internal protected double[] inputs;
        internal protected double[] outputs;
        internal protected double[,] weights;

        //constr
        protected Layer(String _ID, int _neuron_num, int _inputs_num, int _transfer_function)
        {
            m_ID = _ID;
            m_neuron_num = _neuron_num;
            m_inputs_num = _inputs_num;
            m_transfer_function = _transfer_function;
            weights = new double[_inputs_num, _neuron_num];
        }
        //set get
        public void SetInputs(double[] _inputs)
        {
            if (_inputs == null) throw new Exception("Inputs are empty.");
            this.inputs = _inputs;
        }
        public double[] GetOutputs()
        {
            return outputs;
        }
        public abstract void WeightsRandom(Random _rnd, Config _config);
        public abstract void WeightsZero();
        //save load
        public int SizeOf()
        {
            return sizeof(double) * m_neuron_num * m_inputs_num;
        }
        protected internal void SaveLayer(BinaryWriter writer)
        {
                for (int i = 0; i < m_neuron_num; i++)
                    for (int j = 0; j < this.m_inputs_num; j++)
                        writer.Write(weights[j, i]);
        }
        protected internal void LoadLayer(BinaryReader reader) {
        for (int i = 0; i < m_neuron_num; i++)
                for (int j = 0; j < m_inputs_num; j++)
                    weights[j, i] = reader.ReadDouble();
        }
        //abstract
        public abstract void LayerProc();
        //interface
        public string GetBriefInfo()
        {
            string str = this.m_ID;
            str += " " + this.m_neuron_num.ToString();
            return str;
        }
        public string GetAllInfo()
        {
            int width = (Config.table_width - (this.m_neuron_num + 1)) / (this.m_neuron_num + 1);
            if (width > Config.column_width) width = Config.column_width;
            string str="";
            str += "|" + Helper.AlignCentre("", width) + "|";
            for (int j = 0; j < this.m_neuron_num; j++)
                str += "|" + Helper.AlignCentre("Neuron " + j.ToString(), width) + "|";
            str += "\n";
            for (int i = 0; i < this.m_inputs_num; i++)
            {
                str += "|" + Helper.AlignCentre("Input " + i.ToString(), width) + "|";
                for (int j = 0; j < this.m_neuron_num; j++)
                    str += "|" + Helper.AlignCentre(weights[i, j].ToString(), width) + "|";
                str += "\n";
            }
            return str;
        }
    }
}
