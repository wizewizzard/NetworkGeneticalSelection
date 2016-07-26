using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
namespace GeneticAlgorithmForNeuralNetwork
{
    class WindowFunctions
    {
        public static void ShowGraphs(string[] _titles, params double[][] _values)
        {
            
            using (Form form = new Form())
            {
                int dr_width = 500;
                int dr_height = 400;
                form.SetBounds(300, 100, dr_width + 20, dr_height + 20);
                form.Text = "Graphics";
                Panel drawing_panel = new Panel();
                drawing_panel.BackColor = Color.White;
                drawing_panel.SetBounds(0, 0, dr_width, dr_height);
                
                
                    drawing_panel.Paint += (sender, e) => WindowFunctions.PanellPaintGraphics(sender, e, _values, _titles);

                //drawing_panel.Refresh();
                form.Controls.Add(drawing_panel);
                form.ShowDialog();
            }
        }
        private static void PanellPaintGraphics(object sender, PaintEventArgs e, double[][] _values, string[] _titles)
        {
            int max_arrays = 5;
            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Cyan, Color.Yellow };
            int array_num_f = _values.GetLength(0);
            int array_num = (array_num_f > max_arrays) ? max_arrays : array_num_f;
            
            Graphics g = e.Graphics;
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
            int width = ((Panel)sender).Width;
            int height = ((Panel)sender).Height;
            double info_block_width = 80, info_block_height = height - bottom_offset - upper_offset;
            //max_val_y = 1;
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
            g.DrawLine(pen, Convert.ToSingle(left_offset), Convert.ToSingle(height - bottom_offset), Convert.ToSingle(width -right_offset - info_block_width), Convert.ToSingle(st_y));
            g.DrawString(max_val_x.ToString(), strFont, strBrush, Convert.ToSingle(width - right_offset - info_block_width-20), Convert.ToSingle(st_y));
            
            double per_str = info_block_height/(_titles.GetLength(0));
            double per_str_min = 20, per_str_max = 40;
            per_str = (per_str_min > per_str) ? per_str_min : per_str;
            per_str = (per_str_max < per_str) ? per_str_max : per_str;
            for(int i=0; i< _titles.GetLength(0); i++){
                float len = 20;
                Pen title_pen = new Pen(colors[i],2);
                g.DrawLine(title_pen, Convert.ToSingle(width - right_offset - info_block_width), Convert.ToSingle(height - bottom_offset - per_str * (i + 1) + per_str / 4), Convert.ToSingle(width - right_offset - info_block_width) + len, Convert.ToSingle(height - bottom_offset - per_str * (i + 1) + per_str / 4));
                g.DrawString(_titles[i], strFont, strBrush, Convert.ToSingle(width - right_offset - info_block_width +len),  Convert.ToSingle(height - bottom_offset - per_str * (i + 1)));
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
            g.Dispose();
        }
    }
}
