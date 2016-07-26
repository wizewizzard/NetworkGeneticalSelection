using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithmForNeuralNetwork.DataProc
{
    using NeuralNetworkNS;
    class ResultAnalysis
    {
        public class AnalisysReport
        {
            private NeuralNetwork m_nn;
            internal NeuralNetwork Nn
            {
                get { return m_nn; }
                set { m_nn = value; }
            }
            private double m_min_res_tr;
            public double Min_res_tr
            {
                get { return m_min_res_tr; }
                set { m_min_res_tr = value; }
            }
            private double m_max_res_tr;
            public double Max_res_tr
            {
                get { return m_max_res_tr; }
                set { m_max_res_tr = value; }
            }
            private double m_st_deviation_tr;
            public double St_deviation_tr
            {
                get { return m_st_deviation_tr; }
                set { m_st_deviation_tr = value; }
            }
            private double m_mae_tr;
            public double Mae_tr
            {
                get { return m_mae_tr; }
                set { m_mae_tr = value; }
            }
            private double m_mape_tr;
            public double Mape_tr
            {
                get { return m_mape_tr; }
                set { m_mape_tr = value; }
            }
            private double m_cor_coef_tr;
            public double Cor_coef_tr
            {
                get { return m_cor_coef_tr; }
                set { m_cor_coef_tr = value; }
            }
            private double m_min_res_tt;
            public double Min_res_tt
            {
                get { return m_min_res_tt; }
                set { m_min_res_tt = value; }
            }
            private double m_max_res_tt;
            public double Max_res_tt
            {
                get { return m_max_res_tt; }
                set { m_max_res_tt = value; }
            }
            private double m_st_deviation_tt;
            public double St_deviation_tt
            {
                get { return m_st_deviation_tt; }
                set { m_st_deviation_tt = value; }
            }
            private double m_mae_tt;
            public double Mae_tt
            {
                get { return m_mae_tt; }
                set { m_mae_tt = value; }
            }
            private double m_mape_tt;
            public double Mape_tt
            {
                get { return m_mape_tt; }
                set { m_mape_tt = value; }
            }
            private double m_cor_coef_tt;
            public double Cor_coef_tt
            {
                get { return m_cor_coef_tt; }
                set { m_cor_coef_tt = value; }
            }

            public string GetAllInfo()
            {
                int width = Config.table_width;
                string str = "";
                str += m_nn.GetBriefInfo();
                str += "|" + Helper.AlignCentre("", width) + "|";
                str += "|" + Helper.AlignCentre("Min res ", width) + "|";
                str += "|" + Helper.AlignCentre("Max res ", width) + "|";
                str += "|" + Helper.AlignCentre("St. dev ", width) + "|";
                str += "|" + Helper.AlignCentre("ME ", width) + "|";
                str += "|" + Helper.AlignCentre("MAE ", width) + "|";
                str += "|" + Helper.AlignCentre("MAPE ", width) + "|";
                str += "|" + Helper.AlignCentre("DK ", width) + "|";
                str += "\n";
                str += "|" + Helper.AlignCentre("Training", width) + "|";
                str += "|" + Helper.AlignCentre(m_min_res_tr.ToString(), width) + "|";
                str += "|" + Helper.AlignCentre(m_max_res_tr.ToString(), width) + "|";
                str += "|" + Helper.AlignCentre(m_st_deviation_tr.ToString(), width) + "|";
                str += "|" + Helper.AlignCentre(m_mae_tr.ToString(), width) + "|";
                str += "|" + Helper.AlignCentre(m_mae_tr.ToString(), width) + "|";
                str += "|" + Helper.AlignCentre(m_mape_tr.ToString(), width) + "|";
                str += "|" + Helper.AlignCentre(m_cor_coef_tr.ToString(), width) + "|";
                str += "\n";
                str += "|" + Helper.AlignCentre("Testing", width) + "|";
                str += "|" + Helper.AlignCentre(m_min_res_tt.ToString(), width) + "|";
                str += "|" + Helper.AlignCentre(m_max_res_tt.ToString(), width) + "|";
                str += "|" + Helper.AlignCentre(m_st_deviation_tt.ToString(), width) + "|";
                str += "|" + Helper.AlignCentre(m_mae_tt.ToString(), width) + "|";
                str += "|" + Helper.AlignCentre(m_mae_tt.ToString(), width) + "|";
                str += "|" + Helper.AlignCentre(m_mape_tt.ToString(), width) + "|";
                str += "|" + Helper.AlignCentre(m_cor_coef_tt.ToString(), width) + "|";
                str += "\n";
                return str;
            }
        }
        public static AnalisysReport CalculateParams(NeuralNetwork _NN, double[][] _IXtr, double[][] _OXtr, double[][] _IXtt, double[][] _OXtt, double _min, double _max, double _d1, double _d2)
        {
            if(_IXtr.GetLength(0) != _OXtr.GetLength(0)) throw new Exception("Wrong training data.");
            if(_IXtt.GetLength(0) != _OXtt.GetLength(0)) throw new Exception("Wrong training data.");

            AnalisysReport ar = new AnalisysReport();
            ar.Nn = _NN;
            double[][] output_tr, output_tt, OXtr, OXtt;
            double[] tr_residues = new double[_OXtr.GetLength(0)], tt_residues = new double[_OXtt.GetLength(0)];
            output_tr = new double[_OXtr.GetLength(0)][];
            output_tt = new double[_OXtt.GetLength(0)][];
            OXtr = new double[_OXtr.GetLength(0)][];
            OXtt = new double[_OXtt.GetLength(0)][];
            for (int i = 0; i < _OXtr.GetLength(0); i++)
            {
                output_tr[i] = new double[_OXtr[0].GetLength(0)];
                OXtr[i] = new double[_OXtr[0].GetLength(0)];
            }
            for (int i = 0; i < _OXtt.GetLength(0); i++)
            {
                output_tt[i] = new double[_OXtt[0].GetLength(0)];
                OXtt[i] = new double[_OXtt[0].GetLength(0)];
            }

            for (int i = 0; i < _IXtr.GetLength(0); i++)
            {
                output_tr[i] = DataPreprocessor.DeNormalizeData(_NN.NetworkProc(_IXtr[i]), _min, _max, _d1, _d2);
                OXtr[i] = DataPreprocessor.DeNormalizeData(_OXtr[i], _min, _max, _d1, _d2);
            }
            for (int i = 0; i < _IXtt.GetLength(0); i++)
            {
                output_tt[i] = DataPreprocessor.DeNormalizeData(_NN.NetworkProc(_IXtt[i]), _min, _max, _d1, _d2);
                OXtt[i] = DataPreprocessor.DeNormalizeData(_OXtt[i], _min, _max, _d1, _d2);
            }
            for (int i = 0; i < output_tr.GetLength(0); i++)
                tr_residues[i] = Helper.CalcResudial(OXtr[i], output_tr[i]);
            for (int i = 0; i < output_tt.GetLength(0); i++)
                tt_residues[i] = Helper.CalcResudial(OXtt[i], output_tt[i]);

            ar.Min_res_tr = tr_residues.Min();
            ar.Max_res_tr = tr_residues.Max();
            ar.Min_res_tt = tt_residues.Min();
            ar.Max_res_tt = tt_residues.Max();
            ar.Mae_tr = tr_residues.Average();
            ar.Mae_tt = tt_residues.Average();
            ar.St_deviation_tr = 0;
            ar.St_deviation_tt = 0;

            for (int i = 0; i < tr_residues.GetLength(0); i++)
                ar.St_deviation_tr += tr_residues[i]*tr_residues[i];
            for (int i = 0; i < tt_residues.GetLength(0); i++)
                ar.St_deviation_tt += tt_residues[i] * tt_residues[i];

            ar.St_deviation_tr = Math.Sqrt( ar.St_deviation_tr/tr_residues.GetLength(0));
            ar.St_deviation_tt = Math.Sqrt( ar.St_deviation_tt / tt_residues.GetLength(0));
            

            for (int i = 0; i < tr_residues.GetLength(0); i++)
                ar.Mae_tr += Math.Abs(tr_residues[i]);
            ar.Mae_tr /= tr_residues.GetLength(0);
            for (int i = 0; i < tt_residues.GetLength(0); i++)
                ar.Mae_tt += Math.Abs(tt_residues[i]);
            ar.Mae_tt /= tt_residues.GetLength(0);

            for (int i = 0; i < tr_residues.GetLength(0); i++)
                ar.Mape_tr += 2*Math.Abs(tr_residues[i]) / (Math.Abs(OXtr[i][0]) + Math.Abs(output_tr[i][0]));
            ar.Mape_tr = ar.Mape_tr / tr_residues.GetLength(0) * 100;
            for (int i = 0; i < tt_residues.GetLength(0); i++)
                ar.Mape_tt += 2*Math.Abs(tt_residues[i]) / (Math.Abs(OXtt[i][0]) + Math.Abs(output_tt[i][0]));
            ar.Mape_tt = ar.Mape_tt / tt_residues.GetLength(0) * 100;
            ar.Cor_coef_tr = CorrelationCoefficient(output_tr, _OXtr);
            ar.Cor_coef_tt = CorrelationCoefficient(output_tt, _OXtt);

            return ar;
           // Console.WriteLine(ResultAnalysis.GetAllInfo(_NN,min_res_tr, max_res_tr, me_tr, mae_tr, mape_tr, cor_coef_tr, min_res_tt, max_res_tt, me_tt, mae_tt, mape_tt, cor_coef_tt));
        }
        public static string GetAllInfo(NeuralNetwork _NN,double min_res_tr=0,            double max_res_tr=0,            double me_tr = 0,            double mae_tr=0,
            double mape_tr = 0,            double cor_coef_tr = 0,            double min_res_tt = 0,            double max_res_tt = 0,
            double me_tt = 0,            double mae_tt=0,            double mape_tt = 0,            double cor_coef_tt = 0)
        {
            int width = Config.table_width;
            string str = "";
            str += _NN.GetBriefInfo();
            str += "|" + Helper.AlignCentre("", width) + "|";
            str += "|" + Helper.AlignCentre("Min res ", width) + "|";
            str += "|" + Helper.AlignCentre("Max res ", width) + "|";
            str += "|" + Helper.AlignCentre("St. dev ", width) + "|";
            str += "|" + Helper.AlignCentre("ME " , width) + "|";
            str += "|" + Helper.AlignCentre("MAE ", width) + "|";
            str += "|" + Helper.AlignCentre("MAPE ", width) + "|";
            str += "|" + Helper.AlignCentre("DK ", width) + "|";
            str += "\n";
            str += "|" + Helper.AlignCentre("Training", width) + "|";
            str += "|" + Helper.AlignCentre(min_res_tr.ToString(), width) + "|";
            str += "|" + Helper.AlignCentre(max_res_tr.ToString(), width) + "|";
            str += "|" + Helper.AlignCentre(max_res_tr.ToString(), width) + "|";
            str += "|" + Helper.AlignCentre(me_tr.ToString() , width) + "|";
            str += "|" + Helper.AlignCentre(mae_tr.ToString(), width) + "|";
            str += "|" + Helper.AlignCentre(mape_tr.ToString(), width) + "|";
            str += "|" + Helper.AlignCentre(cor_coef_tr.ToString(), width) + "|";
            str += "\n";
            str += "|" + Helper.AlignCentre("Testing", width) + "|";
            str += "|" + Helper.AlignCentre(min_res_tt.ToString(), width) + "|";
            str += "|" + Helper.AlignCentre(max_res_tt.ToString(), width) + "|";
            str += "|" + Helper.AlignCentre(me_tt.ToString() , width) + "|";
            str += "|" + Helper.AlignCentre(mae_tt.ToString(), width) + "|";
            str += "|" + Helper.AlignCentre(mape_tt.ToString(), width) + "|";
            str += "|" + Helper.AlignCentre(cor_coef_tt.ToString(), width) + "|";
            str += "\n";

            return str;
        }
        private static double CorrelationCoefficient(double[][] _output, double[][] _OX)
        {
            double av_d = 0.0, av_p = 0.0;
            for (int i = 0; i < _output.GetLength(0); i++)
            {
                av_d += _OX[i][0];
                av_p += _output[i][0];
            }
            av_d /= _output.GetLength(0);
            av_p /= _OX.GetLength(0);
            double st = 0;
            double sb1 = 0, sb2 = 0;
            for (int i = 0; i < _OX.GetLength(0); i++)
            {
                st += (_OX[i][0] - av_d) * (_output[i][0] - av_p);
                sb1 += Math.Pow((_OX[i][0] - av_d), 2);
                sb2 += Math.Pow((_output[i][0] - av_p), 2);
            }
            return st / Math.Sqrt(sb1 * sb2);
        }
        public static void NetworkProcessTrTT(NeuralNetwork _NN, double[] _data, double[][] _IXtr, double[][] _IXtt, int[] _tr_N, int[] _tt_N, 
            out int[] _T, out int[] _signs, out double[] _values)//выходные параметры
        {
            int len = _data.GetLength(0);
            int inputs_num = _NN.Network_neuron_structure[0];

            _T = new int[len];
            _signs = new int[len];
            _values = new double[len];

            for (int i = 0; i < inputs_num; i++) { _T[i] = i; _signs[i] = -1; _values[i] = 0; }
            int tr_i = 0, tt_i = 0;
            for (int i = inputs_num; i < _values.GetLength(0); i++)
            {
                _T[i] = i;
                if (_tr_N.Contains(i))
                {
                    _signs[i] = 0;
                    _values[i] = _NN.NetworkProc(_IXtr[tr_i++])[0];
                }
                else if (_tt_N.Contains(i))
                {
                    _signs[i] = 1;
                    _values[i] = _NN.NetworkProc(_IXtt[tt_i++])[0];
                }
                else throw new Exception("Wrong tr_N or tt_N array");
            }
        }
        /*public static void NetworkProcessPrediction(NeuralNetwork _NN, double[][] _IX, int _prediction_len, int[] _N, 
            out int[] _T, out int[] _signs, out double[] _values)//выходные параметры
        {
            //_T = new int[];
        }*/
    }
}
