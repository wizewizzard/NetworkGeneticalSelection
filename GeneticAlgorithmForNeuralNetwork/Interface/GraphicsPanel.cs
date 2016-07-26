using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GeneticAlgorithmForNeuralNetwork.Interface
{
    class GraphicsPanel : Panel
    {
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private GraphicPanel panel9;
        private GraphicPanel panel8;
        private GraphicPanel panel7;
        private GraphicPanel panel6;
        private GraphicPanel panel5;
        private GraphicPanel panel4;
        private GraphicPanel panel3;
        private GraphicPanel panel2;
        private GraphicPanel panel1;
        private GeneticAlgorithm.GeneticSelection selector;
        public GraphicsPanel(GeneticAlgorithm.GeneticSelection _selector)
            : base()
        {
            selector = _selector;
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new GraphicPanel();
            this.panel8 = new GraphicPanel();
            this.panel7 = new GraphicPanel();
            this.panel6 = new GraphicPanel();
            this.panel5 = new GraphicPanel();
            this.panel4 = new GraphicPanel();
            this.panel3 = new GraphicPanel();
            this.panel2 = new GraphicPanel();
            this.panel1 = new GraphicPanel();
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(772, 419);
            this.label9.Name = "label6";
            this.label9.Size = new System.Drawing.Size(73, 19);
            this.label9.TabIndex = 9;
            this.label9.Text = "Av. hidden num";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(445, 419);
            this.label8.Name = "label5";
            this.label8.Size = new System.Drawing.Size(73, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "Av. inputs num";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(65, 419);
            this.label7.Name = "label4";
            this.label7.Size = new System.Drawing.Size(62, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Av. layers num.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(772, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "MAPE tt.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(772, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "MAPE tr.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(445, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "MAE tr.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(445, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "MAE tt.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(65, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Standart deviation tt.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(65, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Standart deviation tr.";
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Location = new System.Drawing.Point(651, 441);
            this.panel9.Name = "Av.hidden num";
            this.panel9.Size = new System.Drawing.Size(300, 174);
            this.panel9.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Location = new System.Drawing.Point(326, 441);
            this.panel8.Name = "Av.inputs num";
            this.panel8.Size = new System.Drawing.Size(300, 174);
            this.panel8.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Location = new System.Drawing.Point(1, 441);
            this.panel7.Name = "Av.layers num";
            this.panel7.Size = new System.Drawing.Size(300, 174);
            this.panel7.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(1, 235);
            this.panel6.Name = "St.dev.tt";
            this.panel6.Size = new System.Drawing.Size(300, 174);
            this.panel6.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(651, 235);
            this.panel5.Name = "MAPE tt.";
            this.panel5.Size = new System.Drawing.Size(300, 174);
            this.panel5.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(326, 235);
            this.panel4.Name = "MAE tt.";
            this.panel4.Size = new System.Drawing.Size(300, 174);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(651, 29);
            this.panel3.Name = "MAPE tr.";
            this.panel3.Size = new System.Drawing.Size(300, 174);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(326, 29);
            this.panel2.Name = "MAE tr.";
            this.panel2.Size = new System.Drawing.Size(300, 174);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(1, 29);
            this.panel1.Name = "St.dev.tr.";
            this.panel1.Size = new System.Drawing.Size(300, 174);
            this.panel1.TabIndex = 0;
            // 
            this.panel1.Paint += (sender, e) => panel1.GraphicPanelPaint(sender, e, selector.Av_st_dev_tr);
            this.panel2.Paint += (sender, e) => panel2.GraphicPanelPaint(sender, e, selector.Av_mae_tr);
            this.panel3.Paint += (sender, e) => panel3.GraphicPanelPaint(sender, e, selector.Av_mape_tr);
            this.panel4.Paint += (sender, e) => panel4.GraphicPanelPaint(sender, e, selector.Av_mae_tt);
            this.panel5.Paint += (sender, e) => panel5.GraphicPanelPaint(sender, e, selector.Av_mape_tt);
            this.panel6.Paint += (sender, e) => panel6.GraphicPanelPaint(sender, e, selector.Av_st_dev_tt);
            this.panel7.Paint += (sender, e) => panel7.GraphicPanelPaint(sender, e, selector.Av_layers_num);
            this.panel8.Paint += (sender, e) => panel8.GraphicPanelPaint(sender, e, selector.Av_input_neurons_num);
            this.panel9.Paint += (sender, e) => panel9.GraphicPanelPaint(sender, e, selector.Av_hidden_neurons_num);
        }
        public void GraphicsPanelPaint(object sender, PaintEventArgs e)
        {
            this.panel1.Invalidate();
            this.panel2.Invalidate();
            this.panel3.Invalidate();
            this.panel4.Invalidate();
            this.panel5.Invalidate();
            this.panel6.Invalidate();
            this.panel7.Invalidate();
            this.panel8.Invalidate();
            this.panel9.Invalidate();
        }

    }
}
