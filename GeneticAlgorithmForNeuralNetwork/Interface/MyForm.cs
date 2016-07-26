using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace GeneticAlgorithmForNeuralNetwork.Interface
{
    using GeneticAlgorithm;
    class MyForm : Form
    {
        double[][] m_values;
        string[] m_titles;
        Panel m_drawing_panel;
        public Panel Drawing_panel
        {
            get { return m_drawing_panel; }
            set { m_drawing_panel = value; }
        }

        public MyForm() : base() {
            int i = Thread.CurrentThread.ManagedThreadId;
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            int dr_width = 500;
            int dr_height = 400;
            this.SetBounds(300, 100, dr_width + 20, dr_height + 20);
            this.Text = "Graphics";
            //m_drawing_panel = new DBPanel();
            //m_drawing_panel.BackColor = Color.White;
            //m_drawing_panel.SetBounds(0, 0, dr_width, dr_height);
            //m_values = null;
            //m_titles = null;

            //m_drawing_panel.Paint += (sender, e) => this.PanellPaintGraphics(sender, e, m_values, m_titles);
            ////this.DoubleBuffered = true;
            ////drawing_panel.Refresh();
            //this.Controls.Add(m_drawing_panel);
            this.Show();
        }
        public void SetParams(string[] _titles, params double[][] _values)
        {
            int i = Thread.CurrentThread.ManagedThreadId;
            this.m_values = _values;
            this.m_titles = _titles;
            m_drawing_panel.Refresh();
        }
        public static void F()
        {
            int i = Thread.CurrentThread.ManagedThreadId; 
        }
        private void PanellPaintGraphics(object sender, PaintEventArgs e, double[][] _values, string[] _titles)
        {
            if (_values == null) return;
            /*lock (GeneticSelection.locker)
            {
                int max_arrays = 6;
                Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Cyan, Color.Yellow, Color.Black };
                int array_num_f = _values.GetLength(0);
                int array_num = (array_num_f > max_arrays) ? max_arrays : array_num_f;

                

                double max_val_y = 0;
                double max_val_x = 0;

                for (int i = 0; i < array_num; i++)
                {
                    double c_max_v = _values[i].Max();
                    if (max_val_y < c_max_v) max_val_y = c_max_v;
                    if (max_val_x < _values[i].GetLength(0)) max_val_x = _values[i].GetLength(0);
                }
                double left_offset = 20, right_offset = 20;
                double upper_offset = 20, bottom_offset = 40;
                //double gr
                //double gr_left_offset = 80;
                double st_x = left_offset, st_y = bottom_offset;
                int width = ((DBPanel)sender).Width;
                int height = ((DBPanel)sender).Height;
                double info_block_width = 80, info_block_height = height - bottom_offset - upper_offset;
                //max_val_y = 1;
                if (max_val_y == 0) { return; }
                Graphics g = e.Graphics;
                while (max_val_y < 1) max_val_y *= 10;
                double per_one_y = (height - bottom_offset - upper_offset) / max_val_y;
                double per_one_x = (width - left_offset - right_offset - info_block_width) / max_val_x;
                Font strFont = new Font("Arial", 10);
                SolidBrush strBrush = new SolidBrush(Color.Black);
                Pen pen = new Pen(Color.Black, 1);
                g.DrawString("0", strFont, strBrush, Convert.ToSingle(st_x - 7), Convert.ToSingle(height - bottom_offset));
                //vertical
                g.DrawLine(pen, Convert.ToSingle(left_offset), Convert.ToSingle(upper_offset), Convert.ToSingle(left_offset), Convert.ToSingle(height - bottom_offset));
                g.DrawString(max_val_y.ToString("0.##"), strFont, strBrush, Convert.ToSingle(st_x + 5), Convert.ToSingle(upper_offset));
                st_y = (height - bottom_offset);
                //horizontal
                g.DrawLine(pen, Convert.ToSingle(left_offset), Convert.ToSingle(height - bottom_offset), Convert.ToSingle(width - right_offset - info_block_width), Convert.ToSingle(st_y));
                g.DrawString(max_val_x.ToString(), strFont, strBrush, Convert.ToSingle(width - right_offset - info_block_width - 20), Convert.ToSingle(st_y));

                double per_str = info_block_height / (_titles.GetLength(0));
                double per_str_min = 20, per_str_max = 40;
                per_str = (per_str_min > per_str) ? per_str_min : per_str;
                per_str = (per_str_max < per_str) ? per_str_max : per_str;
                for (int i = 0; i < _titles.GetLength(0); i++)
                {
                    float len = 20;
                    Pen title_pen = new Pen(colors[i], 2);
                    g.DrawLine(title_pen, Convert.ToSingle(width - right_offset - info_block_width), Convert.ToSingle(height - bottom_offset - per_str * (i + 1) + per_str / 4), Convert.ToSingle(width - right_offset - info_block_width) + len, Convert.ToSingle(height - bottom_offset - per_str * (i + 1) + per_str / 4));
                    g.DrawString(_titles[i], strFont, strBrush, Convert.ToSingle(width - right_offset - info_block_width + len), Convert.ToSingle(height - bottom_offset - per_str * (i + 1)));
                }

                for (int ai = 0; ai < _values.GetLength(0); ai++)
                {
                    pen = new Pen(colors[ai], 2);
                    Brush brush = new SolidBrush(colors[ai]);
                    for (int vi = 0; vi < _values[ai].GetLength(0); vi++)
                    {
                        if (vi + 1 < _values[ai].GetLength(0))
                            g.DrawLine(pen, Convert.ToSingle(st_x + per_one_x * (vi + 1)), Convert.ToSingle(st_y - per_one_y * _values[ai][vi + 1]), Convert.ToSingle(st_x + per_one_x * vi), Convert.ToSingle(st_y - per_one_y * _values[ai][vi]));
                    }
                    pen.Dispose();
                    brush.Dispose();
                }
                //int max_val_y_i = Convert.ToInt32(Math.Ceiling(max_val_y));
                Pen blackpen = new Pen(Color.Black, 3);
                //g.DrawLine(blackpen, 0, 0, 200, 200);
               // g.Dispose();
            }*/
        }
        
    }
}
