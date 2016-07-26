using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeneticAlgorithmForNeuralNetwork.Interface
{
    public partial class ParametersPanel : UserControl
    {
        public ParametersPanel()
        {
            InitializeComponent();
        }
        public void ParameterPanelPaint(object sender, PaintEventArgs e, GeneticAlgorithm.GeneticSelection _selector)
        {
            this.label1.Text = _selector.Min_st_dev_tr.ToString("0.####");
            this.label2.Text = _selector.Min_st_dev_tt.ToString("0.####");
            this.label3.Text = _selector.Min_mae_tr.ToString("0.####");
            this.label4.Text = _selector.Min_mae_tt.ToString("0.####");
            this.label5.Text = _selector.Min_mape_tr.ToString("0.####");
            this.label6.Text = _selector.Min_mape_tt.ToString("0.####");

            this.min_st_dev_tr_textbox.Text = _selector.Min_st_dev_tr_nn_id;
            this.min_st_dev_tt_textbox.Text = _selector.Min_st_dev_tt_nn_id;
            this.min_mae_tr_textbox.Text = _selector.Min_mae_nn_tr_nn_id;
            this.min_mae_tt_textbox.Text = _selector.Min_mae_nn_tt_nn_id;
            this.min_mape_tr_textbox.Text = _selector.Min_mape_tr_nn_id;
            this.min_mape_tt_textbox.Text = _selector.Min_mape_tt_nn_id;

            this.label15.Text = _selector.Cur_generation.ToString();
            try
            {
                this.label7.Text = _selector.Av_st_dev_tr.Last(x => x != 0).ToString("0.####");
            }
            catch (InvalidOperationException ex)
            {
                this.label7.Text = "Undef.";
            }
            try
            {
                this.label8.Text = _selector.Av_st_dev_tt.Last(x => x != 0).ToString("0.####");
            }
            catch (InvalidOperationException ex)
            {
                this.label8.Text = "Undef.";
            }
            try
            {
                this.label9.Text = _selector.Av_mae_tr.Last(x => x != 0).ToString("0.####");
            }
            catch (InvalidOperationException ex)
            {
                this.label9.Text = "Undef.";
            }
            try
            {
                this.label10.Text = _selector.Av_mae_tt.Last(x => x != 0).ToString("0.####");
            }
            catch (InvalidOperationException ex)
            {
                this.label10.Text = "Undef.";
            }
            try
            {
                this.label11.Text = _selector.Av_mape_tr.Last(x => x != 0).ToString("0.####");
            }
            catch (InvalidOperationException ex)
            {
                this.label11.Text = "Undef.";
            }
            try
            {
                this.label12.Text = _selector.Av_mape_tt.Last(x => x != 0).ToString("0.####");
            }
            catch (InvalidOperationException ex)
            {
                this.label12.Text = "Undef.";
            }
            try
            {
                this.label23.Text = _selector.Av_layers_num_cur.ToString("0.##");
            }
            catch (InvalidOperationException ex)
            {
                this.label23.Text = "Undef.";
            }
            try
            {
                this.label24.Text = _selector.Av_input_neurons_num_cur.ToString("0.##");
            }
            catch (InvalidOperationException ex)
            {
                this.label24.Text = "Undef.";
            }
            try
            {
                this.label26.Text = _selector.Av_hidden_neurons_num_cur.ToString("0.##");
            }
            catch (InvalidOperationException ex)
            {
                this.label26.Text = "Undef.";
            }

        }
    }
}
