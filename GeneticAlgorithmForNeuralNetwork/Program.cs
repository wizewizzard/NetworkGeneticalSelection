using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
namespace GeneticAlgorithmForNeuralNetwork
{
    using NeuralNetworkNS;
    using DataProc;
    using GeneticAlgorithm;
    using Interface;
    class Program
    {
        /*private static void OnTimerTick(object source, ElapsedEventArgs e, MyForm _window, Thread _thread)
        {
            int i = Thread.CurrentThread.ManagedThreadId;
            if (!_thread.IsAlive) { ((System.Timers.Timer)source).Stop(); return; }
            //_window.SetParams(new string[] { "1", "2", "3", "4", "5", "6" }, GeneticSelection.av_mae_tr, GeneticSelection.av_mae_tt, GeneticSelection.av_mape_tr, GeneticSelection.av_mape_tt, GeneticSelection.av_st_dev_tr, GeneticSelection.av_st_dev_tt);
            Action<string[], double[][]> action = (str, vals) => _window.SetParams(str, vals);
            //Action action =MyFrom.F;
            if (_window.InvokeRequired)
            {
                _window.Invoke(action, new string[] { "1", "2", "3", "4", "5", "6" }, GeneticSelection.av_mae_tr, GeneticSelection.av_mae_tt, GeneticSelection.av_mape_tr, GeneticSelection.av_mape_tt, GeneticSelection.av_st_dev_tr, GeneticSelection.av_st_dev_tt);
                //_window.Drawing_panel.Invoke(action);
            }
        }*/
        [STAThread]
        static void Main(string[] args)
        {
            MainWindow MW = new MainWindow();

            /*Console.SetWindowSize(120, 50);
            DataPreprocessor dp = new DataPreprocessor(@"C:\neural network\data1.xlsx");
            double[] data = dp.GetRowD("var1");
            int[] signs = dp.GetRowI("sign");
            MyForm window = new MyForm();
            Config config = new Config(@"C:\neural network\data1.xlsx");
            GeneticSelection selector = new GeneticSelection(config);
            ThreadStart starter = delegate { selector.StartSelection(data, signs); };
            Thread thread = new Thread(starter);
            int i = Thread.CurrentThread.ManagedThreadId;
            thread.Start();
            
            System.Timers.Timer timer = new System.Timers.Timer(1000);*/
            //timer.Elapsed += (sender, e) => OnTimerTick(sender, e, window, thread);
            //timer.Start();
                /*double max_v = data.Max();
                double min_v = data.Min();
                double d1 = 0, d2 = 1;
                data = DataPreprocessor.NormalizeData(data, d1, d2);
                double[][] IXtr;
                double[][] OXtr;
                double[][] IXtt;
                double[][] OXtt;
                int in_n = 3;
                int[] ls = { 25, 20, 1 };
                int[] ls2 = { 25, 1 };
                int[] fs1 = { 0, 0 };
                int[] fs2 = { 0, 0, 1 };
                int[] fs3 = { 0, 0, 2 };
                int[] fs4 = { 0, 0, 3 };
                int[] fs5 = { 0, 0, 4 };
                int[] fs6 = { 0, 1, 0 };
                int[] fs7 = { 0, 1, 1 };
                int[] fs8 = { 0, 1, 2 };
                int[] fs9 = { 0, 1, 3 };
                int[] fs10 = { 0, 1, 4 };
                int[] fs11 = { 0, 2, 0 };
                int[] fs12 = { 0, 2, 1 };
                int[] fs13 = { 0, 2, 2 };
                int[] fs14 = { 0, 2, 3 };
                int[] fs15 = { 0, 2, 4 };
                int[] fs16 = { 0, 3, 0 };
                int[] fs17 = { 0, 3, 1 };
                int[] fs18 = { 0, 3, 2 };
                int[] fs19 = { 0, 3, 3 };
                int[] fs20 = { 0, 3, 4 };
                int[] fs21 = { 0, 4, 0 };
                int[] fs22 = { 0, 4, 1 };
                int[] fs23 = { 0, 4, 2 };
                int[] fs24 = { 0, 4, 3 };
                int[] fs25 = { 0, 4, 4 };

                DataPreprocessor.SplitDataIXOX(data, signs, 0, 1,ls[0], ls[in_n - 1], out IXtr, out OXtr, out IXtt, out OXtt);

                NeuralNetwork NN1 = new NeuralNetwork("My NW1", 2, ls2, fs1);
                NeuralNetwork NN2 = new NeuralNetwork("My NW2", in_n, ls, fs9);
                NeuralNetwork NN3 = new NeuralNetwork("My NW3", in_n, ls, fs2);
                NeuralNetwork NN4 = new NeuralNetwork("My NW4", in_n, ls, fs3);
                NeuralNetwork NN5 = new NeuralNetwork("My NW5", in_n, ls, fs4);
                NeuralNetwork NN6 = new NeuralNetwork("My NW6", in_n, ls, fs5);
                NeuralNetwork NN7 = new NeuralNetwork("My NW7", in_n, ls, fs6);
                NeuralNetwork NN8 = new NeuralNetwork("My NW8", in_n, ls, fs7);
                NeuralNetwork NN9 = new NeuralNetwork("My NW9", in_n, ls, fs8);
                NeuralNetwork NN10 = new NeuralNetwork("My NW10", in_n, ls, fs10);
                NeuralNetwork NN11 = new NeuralNetwork("My NW11", in_n, ls, fs11);
                NeuralNetwork NN12 = new NeuralNetwork("My NW12", in_n, ls, fs12);
                NeuralNetwork NN13 = new NeuralNetwork("My NW13", in_n, ls, fs13);
                NeuralNetwork NN14 = new NeuralNetwork("My NW14", in_n, ls, fs14);
                NeuralNetwork NN15 = new NeuralNetwork("My NW15", in_n, ls, fs15);
                NeuralNetwork NN16 = new NeuralNetwork("My NW16", in_n, ls, fs16);
                NeuralNetwork NN17 = new NeuralNetwork("My NW17", in_n, ls, fs17);
                NeuralNetwork NN18 = new NeuralNetwork("My NW18", in_n, ls, fs18);
                NeuralNetwork NN19 = new NeuralNetwork("My NW19", in_n, ls, fs19);
                NeuralNetwork NN20 = new NeuralNetwork("My NW20", in_n, ls, fs20);
                NeuralNetwork NN21 = new NeuralNetwork("My NW21", in_n, ls, fs21);
                NeuralNetwork NN22 = new NeuralNetwork("My NW22", in_n, ls, fs22);
                NeuralNetwork NN23 = new NeuralNetwork("My NW23", in_n, ls, fs23);
                NeuralNetwork NN24 = new NeuralNetwork("My NW24", in_n, ls, fs24);
                NeuralNetwork NN25 = new NeuralNetwork("My NW25", in_n, ls, fs25);


                //Console.WriteLine(NN.GetAllInfo());
                NN1.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                /*NN2.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN3.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN4.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN5.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN6.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN7.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN8.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN9.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN10.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN11.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN12.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN13.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN14.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN15.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN16.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN17.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN18.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN19.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN20.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN21.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN22.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN23.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN24.NetworkTraining(IXtr, OXtr, IXtt, OXtt);
                NN25.NetworkTraining(IXtr, OXtr, IXtt, OXtt);*/
                /*double[] ix= new double[ls[0]];
                double[] results = new double[data.GetLength(0)];//172?
                for (int i = ls[0]; i < data.GetLength(0) - (ls[in_n - 1] - 1); i++ )
                {
                    Array.Copy(data, i - ls[0], ix, 0, ls[0]);
                    double[] r = NN1.NetworkProc(ix);
                    results[i] = r[0];
                }
                data = DataPreprocessor.DeNormalizeData(data, min_v, max_v, d1, d2);
                results = DataPreprocessor.DeNormalizeData(results, min_v, max_v, d1, d2);
                double cor_koef = 0.0;
                double av_d=0.0, av_p = 0.0;
                for (int i = ls[0]; i < data.GetLength(0); i++)
                {
                    av_d += data[i];
                    av_p += results[i];
                }
                av_d /= (data.GetLength(0) - ls[0]);
                av_p /= (data.GetLength(0) - ls[0]);
                double st = 0;
                double sb1=0, sb2=0;
                for (int i = ls[0]; i < data.GetLength(0); i++)
                {
                    st += (data[i] - av_d) * (results[i] - av_p);
                    sb1 += Math.Pow((data[i] - av_d), 2);
                    sb2+=Math.Pow((results[i] - av_p), 2);
                }
                cor_koef = st / Math.Sqrt(sb1 * sb2);
                Console.WriteLine(cor_koef);
                WindowFunctions.ShowGraphs(new string[] { "real", "pred" }, data, results);*/
                /* ResultAnalysis.CalculateParams(NN1, data, IXtr, OXtr, IXtt, OXtt,min_v,max_v,d1,d2);
                 ResultAnalysis.CalculateParams(NN2, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN3, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN4, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN5, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN6, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN7, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN8, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN9, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN10, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN11, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN12, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN13, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN14, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN15, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN16, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN17, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN18, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN19, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN20, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN21, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN22, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN23, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN24, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);
                 ResultAnalysis.CalculateParams(NN25, data, IXtr, OXtr, IXtt, OXtt, min_v, max_v, d1, d2);

                 /*double[] ix = new double[101];
                 for (int i = 0; i <= 100; i++)
                 {
                     ix[i] = Config.LearningRateFunction(i);
                 }
                 WindowFunctions.ShowGraphs(new string[] { "lr" }, ix);*/
                /*double[] ix= new double[ls[0]];
                Array.Copy(data,160, ix, 0, ls[0]);
                double[] r = NN.NetworkProc(ix);
                Console.WriteLine(data[160+ls[0]]);
                Console.WriteLine(Helper.ShowArray(r));*/
                //NeuralNetwork NN = new NeuralNetwork("My NW");
                //Console.WriteLine(NN.GetAllInfo());*/
                //double[,] xy = { { 0.75, 1.5, 2.25   }, { 2.5, 1.2, 1.12 } };
                //DataPreprocessor.EstimateFunction(xy, 1);
                Console.Read();
        }
    }
}
