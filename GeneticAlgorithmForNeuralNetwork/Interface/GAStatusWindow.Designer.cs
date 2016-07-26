using System.Drawing;
namespace GeneticAlgorithmForNeuralNetwork.Interface
{
    partial class GAStatusWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_parameter_panel = new GeneticAlgorithmForNeuralNetwork.Interface.ParametersPanel();
            this.m_graphics_panel = new GeneticAlgorithmForNeuralNetwork.Interface.GraphicsPanel(this.m_selector);
            this.m_graphics_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_parameter_panel
            // 
            this.m_parameter_panel.Location = new System.Drawing.Point(12, 0);
            this.m_parameter_panel.Name = "m_parameter_panel";
            this.m_parameter_panel.Size = new System.Drawing.Size(951, 110);
            this.m_parameter_panel.TabIndex = 1;
            // 
            // m_drawing_panel
            // 
            this.m_graphics_panel.BackColor = System.Drawing.Color.White;

            this.m_graphics_panel.Location = new System.Drawing.Point(12, 120);
            this.m_graphics_panel.Name = "m_graphics_panel";
            this.m_graphics_panel.Size = new System.Drawing.Size(951, 615);
            this.m_graphics_panel.TabIndex = 0;
            
            // GAStatusWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 766);
            this.Controls.Add(this.m_parameter_panel);
            this.Controls.Add(this.m_graphics_panel);
            this.Name = "GAStatusWindow";
            this.Text = "GAStatusWindow";
            this.m_graphics_panel.ResumeLayout(false);
            this.m_graphics_panel.PerformLayout();
            this.ResumeLayout(false);

            m_graphics_panel.Paint += (sender, e) => m_graphics_panel.GraphicsPanelPaint(sender, e);
            m_parameter_panel.Paint += (sender, e) => m_parameter_panel.ParameterPanelPaint(sender, e, this.m_selector);
        }

        #endregion

        private GraphicsPanel m_graphics_panel;
        private ParametersPanel m_parameter_panel;
        
        
        
    }
}