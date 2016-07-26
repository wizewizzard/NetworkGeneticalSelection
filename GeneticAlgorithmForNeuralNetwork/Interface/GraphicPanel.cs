using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GeneticAlgorithmForNeuralNetwork.Interface
{
    class GraphicPanel : Panel
    {
        public GraphicPanel()
            : base()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
        public void GraphicPanelPaint(object sender, PaintEventArgs e, double[] _values)
        {
            /* m_drawing_panel.Paint += (sender, e) => m_drawing_panel.GraphicsPanelPaint(sender, e, this.m_selector.Param_titles,
                this.m_selector.Av_st_dev_tr, this.m_selector.Av_st_dev_tt, this.m_selector.Av_mae_tr, this.m_selector.Av_mae_tt, this.m_selector.Av_mape_tr, this.m_selector.Av_mape_tt);
            m_parameter_panel.Paint += (sender, e) => m_parameter_panel.ParameterPanelPaint(sender, e, this.m_selector);*/
            if (_values == null) return;
            int max_arrays = 6;
            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Cyan, Color.Yellow, Color.Black };
            int array_num_f = _values.GetLength(0);
            int array_num = (array_num_f > max_arrays) ? max_arrays : array_num_f;
            //int info_block_width = 80;
            int left_offset, right_offset, top_offset, bottom_offset;
            left_offset = 0;
            right_offset = 0;
            top_offset = 0;
            bottom_offset = 0;

            Graphics g = e.Graphics;
            int p_width = ((GraphicPanel)sender).Width;
            int p_height = ((GraphicPanel)sender).Height;

            Pen axis_pen = new Pen(Color.Black, 1);
            Pen cells_pen = new Pen(Color.LightGray, 1);
            //g.DrawString("0", strFont, strBrush, Convert.ToSingle(st_x - 7), Convert.ToSingle(height - bottom_offset));
            //vertical
            g.DrawLine(axis_pen, Convert.ToSingle(left_offset), Convert.ToSingle(top_offset), Convert.ToSingle(left_offset), Convert.ToSingle(p_height - bottom_offset));
            /*g.DrawString(max_val_y.ToString("0.##"), strFont, strBrush, Convert.ToSingle(st_x + 5), Convert.ToSingle(upper_offset));
            st_y = (height - bottom_offset);*/
            //horizontal
            int line_num = 6;
            float v_step = (p_width - right_offset - left_offset) / line_num;
            float h_step = (p_height - bottom_offset - top_offset) / line_num;
            for (int i = 1; i <= line_num; i++)
            {
                g.DrawLine(cells_pen, Convert.ToSingle(left_offset + v_step * i), Convert.ToSingle(top_offset), Convert.ToSingle(left_offset + v_step * i), Convert.ToSingle(p_height - bottom_offset));
                g.DrawLine(cells_pen, Convert.ToSingle(left_offset), Convert.ToSingle(p_height - bottom_offset - +h_step * i), Convert.ToSingle(p_width - right_offset), Convert.ToSingle(p_height - bottom_offset - h_step * i));
            }
            g.DrawLine(axis_pen, Convert.ToSingle(left_offset), Convert.ToSingle(p_height - bottom_offset), Convert.ToSingle(p_width - right_offset), Convert.ToSingle(p_height - bottom_offset));
            //g.DrawString(max_val_x.ToString(), strFont, strBrush, Convert.ToSingle(width - right_offset - info_block_width - 20), Convert.ToSingle(st_y));

            Font strFont = new Font("Arial", 10);
            SolidBrush strBrush = new SolidBrush(Color.Black);
            /*double per_str = (p_height - top_offset - bottom_offset) / (_titles.GetLength(0));
            double per_str_min = 15, per_str_max = 40;
            per_str = (per_str_min > per_str) ? per_str_min : per_str;
            per_str = (per_str_max < per_str) ? per_str_max : per_str;
            for (int i = 0; i < _titles.GetLength(0); i++)
            {
                float len = 20;
                Pen title_pen = new Pen(colors[i], 2);
                g.DrawLine(title_pen, Convert.ToSingle(p_width - right_offset - info_block_width), Convert.ToSingle(p_height - bottom_offset - per_str * (i + 1) + per_str / 4), Convert.ToSingle(p_width - right_offset - info_block_width) + len, Convert.ToSingle(p_height - bottom_offset - per_str * (i + 1) + per_str / 4));
                g.DrawString(_titles[i], strFont, strBrush, Convert.ToSingle(p_width - right_offset - info_block_width + len), Convert.ToSingle(p_height - bottom_offset - per_str * (i + 1)));
            }*/

            double max_val_y = _values.Max();
            double min_val_y = Double.PositiveInfinity;
            for (int i = _values.GetLength(0)-1; i >= 0; i--) 
                if (_values[i] != 0 && min_val_y > _values[i]) min_val_y = _values[i];
           
            double max_val_x = _values.GetLength(0);
            if (max_val_y == 0) { return; }
            if (max_val_y / min_val_y > 20) max_val_y = min_val_y * 20;
            double per_one_y = (p_height - bottom_offset - top_offset) / max_val_y;
            double per_one_x = (p_width - left_offset - right_offset) / max_val_x;


                Pen graphics_pen = new Pen(Color.Black, 1);
                Brush brush = new SolidBrush(Color.Black);
                for (int vi = 0; vi < _values.GetLength(0); vi++)
                {
                    if (_values[vi] == 0)
                    {
                        continue;
                    }
                    else
                        if (vi + 1 < _values.GetLength(0))
                            if (_values[vi + 1] == 0)
                                g.FillRectangle(brush, Convert.ToSingle(left_offset + per_one_x * (vi)), Convert.ToSingle(p_height - bottom_offset - per_one_y * _values[vi]), 2, 2);
                            else
                                g.DrawLine(graphics_pen, Convert.ToSingle(left_offset + per_one_x * (vi + 1)), Convert.ToSingle(p_height - bottom_offset - per_one_y * _values[vi + 1]), Convert.ToSingle(left_offset + per_one_x * vi), Convert.ToSingle(p_height - bottom_offset - per_one_y * _values[vi]));
                        else
                            g.FillRectangle(brush, Convert.ToSingle(left_offset + per_one_x * (vi)), Convert.ToSingle(p_height - bottom_offset - per_one_y * _values[vi]), 2, 2);


                }
                graphics_pen.Dispose();
                brush.Dispose();
        }
        public void GraphicPanelPaintTimeSeries(object sender, PaintEventArgs e, int[] _T, int[] _signs, double[] _fact_values, double[] _pred_values)
        {
            if (_fact_values == null || _pred_values == null) return;
            int max_arrays = 6;
            Color[] colors = { Color.Red, Color.Black };
            int array_num_f = _fact_values.GetLength(0);
            int array_num = (array_num_f > max_arrays) ? max_arrays : array_num_f;
            //int info_block_width = 80;
            int left_offset, right_offset, top_offset, bottom_offset;
            left_offset = 0;
            right_offset = 0;
            top_offset = 0;
            bottom_offset = 0;

            Graphics g = e.Graphics;
            int p_width = ((GraphicPanel)sender).Width;
            int p_height = ((GraphicPanel)sender).Height;

            
            Font strFont = new Font("Arial", 10);
            SolidBrush strBrush = new SolidBrush(Color.Black);
            /*double per_str = (p_height - top_offset - bottom_offset) / (_titles.GetLength(0));
            double per_str_min = 15, per_str_max = 40;
            per_str = (per_str_min > per_str) ? per_str_min : per_str;
            per_str = (per_str_max < per_str) ? per_str_max : per_str;
            for (int i = 0; i < _titles.GetLength(0); i++)
            {
                float len = 20;
                Pen title_pen = new Pen(colors[i], 2);
                g.DrawLine(title_pen, Convert.ToSingle(p_width - right_offset - info_block_width), Convert.ToSingle(p_height - bottom_offset - per_str * (i + 1) + per_str / 4), Convert.ToSingle(p_width - right_offset - info_block_width) + len, Convert.ToSingle(p_height - bottom_offset - per_str * (i + 1) + per_str / 4));
                g.DrawString(_titles[i], strFont, strBrush, Convert.ToSingle(p_width - right_offset - info_block_width + len), Convert.ToSingle(p_height - bottom_offset - per_str * (i + 1)));
            }*/

            double max_val_y = _fact_values.Max() > _pred_values.Max() ? _fact_values.Max() : _pred_values.Max();
            double min_val_y = _fact_values.Min() < _pred_values.Min() ? _fact_values.Min() : _pred_values.Min();
            double max_val_x = _T.GetLength(0);
            if (max_val_y == 0) { return; }
            double per_one_y = (p_height - bottom_offset - top_offset) / (Math.Abs(max_val_y) + Math.Abs(min_val_y));
            double per_one_x = (p_width - left_offset - right_offset) / max_val_x;

            double negative_y_offset = per_one_y * min_val_y;
            if(negative_y_offset > 0) negative_y_offset = 0;
            negative_y_offset *=-1;
            Pen axis_pen = new Pen(Color.Black, 1);
            Pen cells_pen = new Pen(Color.LightGray, 1);
            //g.DrawString("0", strFont, strBrush, Convert.ToSingle(st_x - 7), Convert.ToSingle(height - bottom_offset));
            //vertical
            g.DrawLine(axis_pen, Convert.ToSingle(left_offset), Convert.ToSingle(top_offset), Convert.ToSingle(left_offset), Convert.ToSingle(p_height - bottom_offset));
            /*g.DrawString(max_val_y.ToString("0.##"), strFont, strBrush, Convert.ToSingle(st_x + 5), Convert.ToSingle(upper_offset));
            st_y = (height - bottom_offset);*/
            //horizontal
            int line_num = 6;
            float v_step = (p_width - right_offset - left_offset) / line_num;
            float h_step = (p_height - bottom_offset - top_offset) / line_num;
            for (int i = 1; i <= line_num; i++)
            {
                g.DrawLine(cells_pen, Convert.ToSingle(left_offset + v_step * i), Convert.ToSingle(top_offset - negative_y_offset), Convert.ToSingle(left_offset + v_step * i), Convert.ToSingle(p_height - bottom_offset - negative_y_offset));
                g.DrawLine(cells_pen, Convert.ToSingle(left_offset), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - +h_step * i), Convert.ToSingle(p_width - right_offset), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - h_step * i));
            }
            g.DrawLine(axis_pen, Convert.ToSingle(left_offset), Convert.ToSingle(p_height - bottom_offset - negative_y_offset), Convert.ToSingle(p_width - right_offset), Convert.ToSingle(p_height - bottom_offset - negative_y_offset));
            //g.DrawString(max_val_x.ToString(), strFont, strBrush, Convert.ToSingle(width - right_offset - info_block_width - 20), Convert.ToSingle(st_y));


            Pen pred_graph_pen = new Pen(Color.Black, 2);
            Pen fact_graph_pen = new Pen(Color.Red, 2);
            Brush pred_brush = new SolidBrush(Color.Black);
            Brush fact_brush = new SolidBrush(Color.Red);
            int prev_vi = 0;
            for (int vi = 0; vi < _T.GetLength(0); vi++)
            {
                
                    if (vi - 1 > 0)
                    {
                        if (_signs[vi-1] != -1)
                        {
                            g.FillRectangle(pred_brush, Convert.ToSingle(left_offset + per_one_x * (vi)), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _pred_values[vi]), 2, 2);
                            g.DrawLine(pred_graph_pen, Convert.ToSingle(left_offset + per_one_x * (prev_vi)), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _pred_values[prev_vi]), Convert.ToSingle(left_offset + per_one_x * vi), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _pred_values[vi]));
                        }
                        g.FillRectangle(fact_brush, Convert.ToSingle(left_offset + per_one_x * (vi)), Convert.ToSingle(p_height - bottom_offset -negative_y_offset - per_one_y * _fact_values[vi]), 2, 2);
                        g.DrawLine(fact_graph_pen, Convert.ToSingle(left_offset + per_one_x * (prev_vi)), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _fact_values[prev_vi]), Convert.ToSingle(left_offset + per_one_x * vi), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _fact_values[vi]));
                    }
                    else
                    {
                        g.FillRectangle(pred_brush, Convert.ToSingle(left_offset + per_one_x * (vi)), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _pred_values[vi]), 2, 2);
                        g.FillRectangle(fact_brush, Convert.ToSingle(left_offset + per_one_x * (vi)), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _fact_values[vi]), 2, 2);
                    }
                    prev_vi = vi;
            }
            pred_graph_pen.Dispose();
            fact_graph_pen.Dispose();
            fact_brush.Dispose();
            pred_brush.Dispose();
        }
        public void GraphicPanelPaintTimeSeries(object sender, PaintEventArgs e, int[] _T, int[] _signs, double[] _fact_values, double[] _pred_values, int _sign)
        {
            if (_sign == 2) { this.GraphicPanelPaintTimeSeries(sender, e, _T, _signs, _fact_values, _pred_values); return; }
            if (_fact_values == null || _pred_values == null) return;
            int max_arrays = 6;
            Color[] colors = { Color.Red, Color.Black };
            int array_num_f = _fact_values.GetLength(0);
            int array_num = (array_num_f > max_arrays) ? max_arrays : array_num_f;
            //int info_block_width = 80;
            int left_offset, right_offset, top_offset, bottom_offset;
            left_offset = 0;
            right_offset = 0;
            top_offset = 0;
            bottom_offset = 0;

            Graphics g = e.Graphics;
            int p_width = ((GraphicPanel)sender).Width;
            int p_height = ((GraphicPanel)sender).Height;


            Font strFont = new Font("Arial", 10);
            SolidBrush strBrush = new SolidBrush(Color.Black);
            /*double per_str = (p_height - top_offset - bottom_offset) / (_titles.GetLength(0));
            double per_str_min = 15, per_str_max = 40;
            per_str = (per_str_min > per_str) ? per_str_min : per_str;
            per_str = (per_str_max < per_str) ? per_str_max : per_str;
            for (int i = 0; i < _titles.GetLength(0); i++)
            {
                float len = 20;
                Pen title_pen = new Pen(colors[i], 2);
                g.DrawLine(title_pen, Convert.ToSingle(p_width - right_offset - info_block_width), Convert.ToSingle(p_height - bottom_offset - per_str * (i + 1) + per_str / 4), Convert.ToSingle(p_width - right_offset - info_block_width) + len, Convert.ToSingle(p_height - bottom_offset - per_str * (i + 1) + per_str / 4));
                g.DrawString(_titles[i], strFont, strBrush, Convert.ToSingle(p_width - right_offset - info_block_width + len), Convert.ToSingle(p_height - bottom_offset - per_str * (i + 1)));
            }*/

            double max_val_y = _fact_values.Max() > _pred_values.Max() ? _fact_values.Max() : _pred_values.Max();
            double min_val_y = _fact_values.Min() < _pred_values.Min() ? _fact_values.Min() : _pred_values.Min();
            
            double max_val_x;
            double min_val_x;

            try
            {
                max_val_x = Array.LastIndexOf(_signs, _sign);
                min_val_x = Array.IndexOf(_signs, _sign);
            }
            catch (InvalidOperationException exc)
            {
                return;
            }
            
            if (max_val_y == 0 || max_val_x == 0) { return; }
            double per_one_y = (p_height - bottom_offset - top_offset) / (Math.Abs(max_val_y) + Math.Abs(min_val_y));
            double per_one_x = (p_width - left_offset - right_offset) / (Math.Abs(max_val_x) - Math.Abs(min_val_x));

            double negative_y_offset = per_one_y * min_val_y;
            double negative_x_offset = per_one_x * min_val_x;
            if (negative_y_offset > 0) negative_y_offset = 0;
            negative_y_offset *= -1;
            Pen axis_pen = new Pen(Color.Black, 1);
            Pen cells_pen = new Pen(Color.LightGray, 1);
            //g.DrawString("0", strFont, strBrush, Convert.ToSingle(st_x - 7), Convert.ToSingle(height - bottom_offset));
            //vertical
            g.DrawLine(axis_pen, Convert.ToSingle(left_offset), Convert.ToSingle(top_offset - negative_y_offset), Convert.ToSingle(left_offset), Convert.ToSingle(p_height - bottom_offset - negative_y_offset));
            /*g.DrawString(max_val_y.ToString("0.##"), strFont, strBrush, Convert.ToSingle(st_x + 5), Convert.ToSingle(upper_offset));
            st_y = (height - bottom_offset);*/
            //horizontal
            int line_num = 6;
            float v_step = (p_width - right_offset - left_offset) / line_num;
            float h_step = (p_height - bottom_offset - top_offset) / line_num;
            for (int i = 1; i <= line_num; i++)
            {
                g.DrawLine(cells_pen, Convert.ToSingle(left_offset + v_step * i), Convert.ToSingle(top_offset - negative_y_offset), Convert.ToSingle(left_offset + v_step * i), Convert.ToSingle(p_height - bottom_offset - negative_y_offset));
                g.DrawLine(cells_pen, Convert.ToSingle(left_offset), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - +h_step * i), Convert.ToSingle(p_width - right_offset), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - h_step * i));
            }
            g.DrawLine(axis_pen, Convert.ToSingle(left_offset), Convert.ToSingle(p_height - bottom_offset - negative_y_offset), Convert.ToSingle(p_width - right_offset), Convert.ToSingle(p_height - bottom_offset - negative_y_offset));
            //g.DrawString(max_val_x.ToString(), strFont, strBrush, Convert.ToSingle(width - right_offset - info_block_width - 20), Convert.ToSingle(st_y));


            Pen pred_graph_pen = new Pen(Color.Black, 2);
            Pen fact_graph_pen = new Pen(Color.Red, 2);
            Brush pred_brush = new SolidBrush(Color.Black);
            Brush fact_brush = new SolidBrush(Color.Red);
            int prev_vi = 0;
            for (int vi = 0; vi < _T.GetLength(0); vi++)
            {
                if (_sign == _signs[vi])
                {
                    if (vi - 1 > 0)
                    {
                        if (_signs[prev_vi] != -1)
                        {
                            g.FillRectangle(pred_brush, Convert.ToSingle(left_offset - negative_x_offset + per_one_x * (vi)), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _pred_values[vi]), 2, 2);
                            g.DrawLine(pred_graph_pen, Convert.ToSingle(left_offset - negative_x_offset + per_one_x * (prev_vi)), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _pred_values[prev_vi]), Convert.ToSingle(left_offset - negative_x_offset + per_one_x * vi), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _pred_values[vi]));

                            g.FillRectangle(fact_brush, Convert.ToSingle(left_offset - negative_x_offset + per_one_x * (vi)), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _fact_values[vi]), 2, 2);
                            g.DrawLine(fact_graph_pen, Convert.ToSingle(left_offset - negative_x_offset + per_one_x * (prev_vi)), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _fact_values[prev_vi]), Convert.ToSingle(left_offset - negative_x_offset + per_one_x * vi), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _fact_values[vi]));
                        }
                    }
                    else
                    {
                        g.FillRectangle(pred_brush, Convert.ToSingle(left_offset - negative_x_offset + per_one_x * (vi)), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _pred_values[vi]), 2, 2);
                        g.FillRectangle(fact_brush, Convert.ToSingle(left_offset - negative_x_offset + per_one_x * (vi)), Convert.ToSingle(p_height - bottom_offset - negative_y_offset - per_one_y * _fact_values[vi]), 2, 2);
                    }
                        prev_vi = vi;
                }
                else
                {
                    continue;
                }
            }
            pred_graph_pen.Dispose();
            fact_graph_pen.Dispose();
            fact_brush.Dispose();
            pred_brush.Dispose();
        }
    }
}
