using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
namespace GeneticAlgorithmForNeuralNetwork.DataProc
{
    class DataPreprocessor
    {
        private DataTable m_dt;
        private string m_file;
        public string File
        {
            get { return m_file; }
            set { m_file = value; }
        }
        public DataPreprocessor(string _file)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+_file+";Extended Properties=Excel 12.0 XML");
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            foreach (DataRow dr in dtSheet.Rows)
            {
                string sheetName = dr["TABLE_NAME"].ToString();
                if (!sheetName.EndsWith("$"))
                    continue;
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                m_dt = new DataTable();
                m_dt.TableName = sheetName;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(m_dt);
                break;
            }
        }
        public void ReadExcelData(string _file)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+_file+";Extended Properties=Excel 12.0 XML");
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            foreach (DataRow dr in dtSheet.Rows)
            {
                string sheetName = dr["TABLE_NAME"].ToString();
                if (!sheetName.EndsWith("$"))
                    continue;
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                m_dt = new DataTable();
                m_dt.TableName = sheetName;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(m_dt);
                break;
            }
        }
        public double[] GetRowD(string _title)
        {
            double[] array = new double[this.m_dt.Rows.Count];
            for (int i = 0; i < this.m_dt.Rows.Count; i++)
            {
                array[i] = Double.Parse(this.m_dt.Rows[i][_title].ToString());
            }
            return array;
        }
        public int[] GetRowI(string _title)
        {
            int[] array = new int[this.m_dt.Rows.Count];
            for (int i = 0; i < this.m_dt.Rows.Count; i++)
            {
                array[i] = Int32.Parse(this.m_dt.Rows[i][_title].ToString());
            }
            return array;
        }
        /*public static void SplitData(double[] _data, double _perc, out double[] _part1, out double[] _part2)
        {
            int data_n = _data.GetLength(0);
            int p1_n = Convert.ToInt32(Math.Round(Convert.ToDouble(data_n * _perc)));
            int p2_n = data_n - p1_n;
            if (p1_n != 0)
            {
                _part1 = new double[p1_n];
                Array.Copy(_data, _part1, p1_n);
            }
            else _part1 = null;
            if (p2_n != 0)
            {
                _part2 = new double[p2_n];
                Array.Copy(_data, p1_n, _part2, 0, p2_n);
            }
            else _part2 = null;
        }*/
        /*public static void SplitDataForIXOX(double[] _data, int[] _signs, int _g1_s, int _g2_s, int _inputs_num, int _outputs_num, out double[] _part1, out double[] _part2)
        {
            int data_n = _data.GetLength(0);
            int p1_n = _signs.Count(t => t == _g1_s);
            int p2_n = _signs.Count(t => t == _g2_s);
            p1_n -= _inputs_num + _outputs_num;
            p2_n -= _outputs_num;
            _part1 = new double[p1_n];
            _part2 = new double[p2_n];
            int c1=0,c2=0;
            for (int i = 0; i < _signs.GetLength(0); i++){
                if (_signs[i] == _g1_s) _part1[c1++] = _data[i];
                else if (_signs[i] == _g2_s) _part2[c2++] = _data[i];
            }
            if (p1_n == 0) _part1 = null;
            if (p2_n == 0) _part2 = null;
        }*/
        public static void SplitDataIXOXN(double[] _data, int[] _signs, int _tr_s, int _tt_s, int _inputs_num, int _outputs_num, out double[][] _IXtr, out double[][] _OXtr, out double[][] _IXtt, out double[][] _OXtt, out int[] _tr_N, out int[] _tt_N)
        {
            int _tr_s_num = 0;
            int _tt_s_num = 0;
            for (int di = _inputs_num; di < _data.GetLength(0)-(_outputs_num-1); di++)
                if (_signs[di] == _tr_s) _tr_s_num++;
                else if (_signs[di] == _tt_s) _tt_s_num++;
            _IXtr = new double[_tr_s_num][];
            _OXtr = new double[_tr_s_num][];
            _IXtt = new double[_tt_s_num][];
            _OXtt = new double[_tt_s_num][];
            _tr_N = new int[_tr_s_num];
            _tt_N = new int[_tt_s_num];
            for (int i = 0; i < _tr_s_num; i++)
            {
                _IXtr[i] = new double[_inputs_num];
                _OXtr[i] = new double[_outputs_num];
            }
            for (int i = 0; i < _tt_s_num; i++)
            {
                _IXtt[i] = new double[_inputs_num];
                _OXtt[i] = new double[_outputs_num];
            }
            int tr_ind=0, tt_ind=0;
            for (int di = _inputs_num; di < _data.GetLength(0) - (_outputs_num-1); di++)
            {
                if (_signs[di] == _tr_s)
                {
                    _tr_N[tr_ind] = di;//индекс наблюдения
                    Array.Copy(_data, di - _inputs_num, _IXtr[tr_ind], 0, _inputs_num);
                    Array.Copy(_data, di, _OXtr[tr_ind++], 0, _outputs_num);
                }
                else if (_signs[di] == _tt_s)
                {
                    _tt_N[tt_ind] = di;//индекс наблюдения
                    Array.Copy(_data, di - _inputs_num, _IXtt[tt_ind], 0, _inputs_num);
                    Array.Copy(_data, di, _OXtt[tt_ind++], 0, _outputs_num);
                }
            }

        }
        public static double[] NormalizeData(double[] _a, double _d1, double _d2)
        {
            double min = _a.Min();
            double max = _a.Max();
            double[] r = new double[_a.GetLength(0)];
            for (int i = 0; i < _a.GetLength(0); i++)
                r[i] = (_a[i] - min) * (_d2 - _d1) / (max - min) + _d1;
            return r;
        }
        public static double[] DeNormalizeData(double[] _a, double _min, double _max, double _d1, double _d2)
        {
            double[] r = new double[_a.GetLength(0)];
            for (int i = 0; i < _a.GetLength(0); i++)
                r[i] = (_a[i] - _d1) * (_max - _min) / (_d2 - _d1) + _min;
            return r;
        }
        //public static void PrepareIXOX(double[] _data, int _inputs_num, int _outputs_num,out double[][] _IX, out double[][] _OX){
        //    int prep_data_len = _data.GetLength(0) - _inputs_num - _outputs_num;
        //    _IX = new double[prep_data_len][];
        //    _OX = new double[prep_data_len][];
        //    for (int i = 0; i < prep_data_len; i++){
        //        _IX[i] = new double[_inputs_num];
        //        _OX[i] = new double[_outputs_num];
        //    }
        //    for (int i = 0; i < prep_data_len; i++){
        //        Array.Copy(_data, i, _IX[i], 0, _inputs_num);
        //        Array.Copy(_data, i+_inputs_num, _OX[i], 0, _outputs_num);
        //    }
        //}
        //public static void EstimateFunction(double[,] xyTable, int basis)
        //{
        //    double[] result;
        //    double[,] matrix;
        //    basis = 2;
        //    //matrix = MakeSystemForPolynom(xyTable, 2);
        //    matrix = MakeSystemForExp(xyTable);
        //    result = Gauss(matrix, basis, basis + 1);
        //}
        //public static double[,] MakeSystemForExp(double[,] xyTable)
        //{
        //    int basis = 2;
        //    double[,] matrix = new double[basis, basis + 1];
        //    for (int i = 0; i < basis; i++)
        //    {
        //        for (int j = 0; j <= basis; j++)
        //        {
        //            matrix[i, j] = 0;
        //        }
        //    }
        //    for (int i = 0; i < xyTable.GetLength(1); i++)
        //    {
        //        matrix[0, 0]  += Math.Exp(-2 * xyTable[0, i]);
        //        matrix[1, 0] += Math.Exp(-xyTable[0, i]);
        //        matrix[0, 1] += Math.Exp(-xyTable[0, i]);
        //        matrix[1, 1]++;
        //        matrix[0, 2] += xyTable[1, i] * Math.Exp(-xyTable[0, i]);
        //        matrix[1, 2] += xyTable[1, i];
        //    }
        //        /*for (int i = 0; i < basis; i++)
        //        {
        //            for (int j = 0; j < basis; j++)
        //            {
        //                double sumA = 0, sumB = 0;
        //                for (int k = 0; k < xyTable.Length / 2; k++)
        //                {
        //                    sumA += Math.Pow(xyTable[0, k], i) * Math.Pow(xyTable[0, k], j);
        //                    sumB += xyTable[1, k] * Math.Pow(xyTable[0, k], i);
        //                }
        //                matrix[i, j] = sumA;
        //                matrix[i, basis] = sumB;
        //            }
        //        }*/
        //        return matrix;
        //}
        //public static double[,] MakeSystemForPolynom(double[,] xyTable, int basis)
        //{
        //    double[,] matrix = new double[basis, basis + 1];
        //    for (int i = 0; i < basis; i++)
        //    {
        //        for (int j = 0; j <= basis; j++)
        //        {
        //            matrix[i, j] = 0;
        //        }
        //    }
        //    for (int i = 0; i < basis; i++)
        //    {
        //        for (int j = 0; j < basis; j++)
        //        {
        //            double sumA = 0, sumB = 0;
        //            for (int k = 0; k < xyTable.Length / 2; k++)
        //            {
        //                sumA += Math.Pow(xyTable[0, k], i) * Math.Pow(xyTable[0, k], j);
        //                sumB += xyTable[1, k] * Math.Pow(xyTable[0, k], i);
        //            }
        //            matrix[i, j] = sumA;
        //            matrix[i, basis] = sumB;
        //        }
        //    }
        //    return matrix;
        //}
        //private static double[] Gauss(double[,] matrix, int rowCount, int colCount)
        //{
        //    int i;
        //    int[] mask = new int[colCount - 1];
        //    for (i = 0; i < colCount - 1; i++) mask[i] = i;
        //    if (GaussDirectPass(ref matrix, ref mask, colCount, rowCount))
        //    {
        //        double[] answer = GaussReversePass(ref matrix, mask, colCount, rowCount);
        //        return answer;
        //    }
        //    else return null;
        //}
        //private static bool GaussDirectPass(ref double[,] matrix, ref int[] mask,
        //    int colCount, int rowCount)
        //{
        //    int i, j, k, maxId, tmpInt;
        //    double maxVal, tempDouble;
        //    for (i = 0; i < rowCount; i++)
        //    {
        //        maxId = i;
        //        maxVal = matrix[i, i];
        //        for (j = i + 1; j < colCount - 1; j++)
        //            if (Math.Abs(maxVal) < Math.Abs(matrix[i, j]))
        //            {
        //                maxVal = matrix[i, j];
        //                maxId = j;
        //            }
        //        if (maxVal == 0) return false;
        //        if (i != maxId)
        //        {
        //            for (j = 0; j < rowCount; j++)
        //            {
        //                tempDouble = matrix[j, i];
        //                matrix[j, i] = matrix[j, maxId];
        //                matrix[j, maxId] = tempDouble;
        //            }
        //            tmpInt = mask[i];
        //            mask[i] = mask[maxId];
        //            mask[maxId] = tmpInt;
        //        }
        //        for (j = 0; j < colCount; j++) matrix[i, j] /= maxVal;
        //        for (j = i + 1; j < rowCount; j++)
        //        {
        //            double tempMn = matrix[j, i];
        //            for (k = 0; k < colCount; k++)
        //                matrix[j, k] -= matrix[i, k] * tempMn;
        //        }
        //    }
        //    return true;
        //}
        //private static double[] GaussReversePass(ref double[,] matrix, int[] mask,
        //    int colCount, int rowCount)
        //{
        //    int i, j, k;
        //    for (i = rowCount - 1; i >= 0; i--)
        //        for (j = i - 1; j >= 0; j--)
        //        {
        //            double tempMn = matrix[j, i];
        //            for (k = 0; k < colCount; k++)
        //                matrix[j, k] -= matrix[i, k] * tempMn;
        //        }
        //    double[] answer = new double[rowCount];
        //    for (i = 0; i < rowCount; i++) answer[mask[i]] = matrix[i, colCount - 1];
        //    return answer;
        //}
        //public 
        //private 

    }
}
