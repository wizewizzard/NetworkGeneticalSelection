using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
namespace GeneticAlgorithmForNeuralNetwork.Interface
{
    using GeneticAlgorithm;
    using DataProc;
    class StatusMonitorThread
    {
        private Form m_status_window;
        private Config m_config;

        public StatusMonitorThread(Config _cfg)
        {
            m_config = _cfg;
        }
        public void StartMonitoring()
        {
            DataPreprocessor dp = new DataPreprocessor(m_config.data_source);
            double[] data = dp.GetRowD("var1");
            int[] signs = dp.GetRowI("sign");

            GeneticSelection selector = new GeneticSelection(m_config);
            
            ThreadStart starter = delegate { selector.StartSelection(data, signs); };
            Thread selection_thread = new Thread(starter);
            
            selection_thread.Start();
            m_status_window = new GAStatusWindow(selection_thread, selector);
            //m_status_window.FormClosing += m_status_window.FormClosingEvnt;
            m_status_window.Show();
            //selector.StartSelection(data, signs);

        }
    }
}
