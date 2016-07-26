using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace GeneticAlgorithmForNeuralNetwork.Interface
{
    using GeneticAlgorithm;
    public partial class GAStatusWindow : Form
    {
        private Thread m_monitored_thread;
        private GeneticSelection m_selector;
        private System.Timers.Timer m_timer;
        public GAStatusWindow()
        {
            InitializeComponent();
            this.FormClosing += this.FormClosingEvnt;
            m_selector = null;
            m_monitored_thread = null;
            m_timer = null;
        }
        public GAStatusWindow(Thread _monitored_thread, GeneticSelection _selector)
        {
            m_selector = _selector;
            InitializeComponent();
            this.FormClosing += this.FormClosingEvnt;
            m_monitored_thread = _monitored_thread;
            m_timer = new System.Timers.Timer();
            m_timer.Interval = 500;
            m_timer.Elapsed += new ElapsedEventHandler(this.TimerRefreshPanelData);
            m_timer.Enabled = true;
            this.Show();
        }
        public void TimerRefreshPanelData(object _source, ElapsedEventArgs _e)
        {
                this.m_graphics_panel.Invalidate();
                this.m_parameter_panel.Invalidate();
        }
        private void FormClosingEvnt(object sender, System.ComponentModel.CancelEventArgs e)
        {
           if(this.m_monitored_thread.IsAlive) this.m_selector.Active = false;
        }

    }
}
