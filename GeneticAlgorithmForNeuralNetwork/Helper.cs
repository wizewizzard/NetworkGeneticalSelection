using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace GeneticAlgorithmForNeuralNetwork
{
    delegate double DT_transfer_function(double _NET);
    delegate double DT_transfer_function_deriviate_x(double _x);
    delegate double DT_transfer_function_deriviate_out(double _out);
    class Helper
    {
        public static string[] function_types = { "Identity", "Tanh", "Sigmoid (0,1)", "Sigmoid (-1,1)", "Negative exp" };
        public static DT_transfer_function[] functions = { Helper.Identity, Helper.SigmoidTanh, Helper.SigmoidExp1, Helper.SigmoidExp2, Helper.NegativeExponential };
        public static DT_transfer_function_deriviate_x[] functions_deriviate_x = { Helper.IdentityDeriviate, Helper.SigmoidTanhDeriviate, Helper.SigmoidExp1Deriative, Helper.SigmoidExp2Deriative, Helper.NegativeExponentialDeriviate };
        public static DT_transfer_function_deriviate_out[] functions_deriviate_out = { Helper.IdentityDeriviate, Helper.SigmoidTanhDeriviateOut, Helper.SigmoidDeriviateOut, Helper.SigmoidDeriviateOut, Helper.NegativeExponentialDeriviateOut };
        
        public static double[] MatrixMultiplication(double[] _a, double[,] _b)
        {
            if (_a.GetLength(0) != _b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            double[] r = new double[_b.GetLength(1)];
            for (int j = 0; j < _b.GetLength(1); j++)
            {
                for (int k = 0; k < _a.GetLength(0); k++)
                {
                    r[j] += _a[k] * _b[k, j];
                }
            }
            return r;
        }
        public static double[,] MatrixMultiplication(double[,] _a, double[,] _b)
        {
            if (_a.GetLength(1) != _b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            double[,] r = new double[_a.GetLength(0), _b.GetLength(1)];
            for (int i = 0; i < _a.GetLength(0); i++)
            {
                for (int j = 0; j < _b.GetLength(1); j++)
                {
                    for (int k = 0; k < _b.GetLength(0); k++)
                    {
                        r[i, j] += _a[i, k] * _b[k, j];
                    }
                }
            }
            return r;
        }
        public static void ShufflePair<T>( T[] array1, T[] array2)
        {
            int n = array1.Length;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = rnd.Next(n--);
                T temp = array1[n];
                array1[n] = array1[k];
                array1[k] = temp;
                temp = array2[n];
                array2[n] = array2[k];
                array2[k] = temp;
            }
        }
        public static double CalcResudial(double[] _fact, double[] _pred)
        {
            if (_pred.GetLength(0) != _fact.GetLength(0)) throw new Exception("Vectors dimentions are not equal.");
            double s=0;
            for (int i = 0; i < _fact.GetLength(0); i++) s += _fact[i] - _pred[i];
            return s;
        }
        
        public static bool IsFileValid(string _filePath)
        {
            bool IsValid = true;
            if (!File.Exists(_filePath))
            {
                IsValid = false;
            }
            return IsValid;
        }
        public static double Identity(double _x)
        {
            return _x;
        }
        public static double IdentityDeriviate(double _x)
        {
            return 1.0;
        }
        public static double IdentityDeriviateOut(double _out)
        {
            return 1.0;
        }
        public static double SigmoidTanh(double _x)
        {
            return Math.Tanh(_x);
        }
        public static double SigmoidTanhDeriviate(double _x)
        {
            return 1 - Math.Pow(SigmoidTanh(_x), 2);
        }
        public static double SigmoidTanhDeriviateOut(double _out)
        {
            return 1 - Math.Pow(_out, 2);
        }
        public static double SigmoidExp1(double _x)
        {
            return 1 / (1 + Math.Exp(-_x));
        }
        public static double SigmoidExp1Deriative(double _x)
        {
            return 1 - (Math.Pow(SigmoidExp1(_x), 2));
        }
        public static double SigmoidExp2(double _x)
        {
            return 2 / (1 + Math.Exp(-2 * _x)) - 1;
        }
        public static double SigmoidExp2Deriative(double _x)
        {
            return 1 - (Math.Pow(SigmoidExp2(_x), 2));
        }
        public static double SigmoidDeriviateOut(double _out)
        {
            return _out*(1-_out);
        }
        public static double NegativeExponential(double _x)
        {
            return Math.Exp(-_x);
        }
        public static double NegativeExponentialDeriviate(double _x)
        {
            return -Math.Exp(-_x);
        }
        public static double NegativeExponentialDeriviateOut(double _out)
        {
            return -_out;
        }
        //printing
        public static string GenerateString(int _len, Random rnd)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < _len; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rnd.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public static string AlignCentre(string _text, int _width)
        {
            _text = _text.Length > _width ? _text.Substring(0, _width - 3) + "..." : _text;

            if (string.IsNullOrEmpty(_text))
            {
                return new string(' ', _width);
            }
            else
            {
                return _text.PadRight(_width - (_width - _text.Length) / 2).PadLeft(_width);
            }
        }
        public static void PrintLine()
        {
            Console.WriteLine(new string('-', Config.table_width));
        }
        public static string ShowArray(double[] _a)
        {
            return String.Join(" ", _a);
        }
        public static void FileWrite(string _path, string _s)
        {
            FileStream file = File.Open(Path.Combine(Config.project_folder, _path), FileMode.Append);
            StreamWriter stream = new System.IO.StreamWriter(file);
            stream.WriteLine(_s);
            stream.Close();
        }
    }
}
