using SimulationRestaurant.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationRestaurant
{
    public partial class Form1 : Form
    {
        private static object LockLog = new object();

        public Form1()
        {
            InitializeComponent();
            LogWriter.GetInstance().NewLogEvent += this.RepaintLogs;
        }

        private void btn_start_sim_Click(object sender, EventArgs e)
        {
            Program.Launch();
        }

        private void RepaintLogs(object sender, EventArgs e)
        {
            lock (LockLog)
            {
                LogDisplay.Invoke(new MethodInvoker(delegate
                {
                    LogDisplay.Text += LogWriter.GetInstance().Logs.Last() + Environment.NewLine;
                }));

            }
        }
    }
}
