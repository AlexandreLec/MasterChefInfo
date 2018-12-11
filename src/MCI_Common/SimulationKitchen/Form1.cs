using SimulationKitchen.Controller;
using SimulationKitchen.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationKitchen
{
    public partial class Form1 : Form
    {

        private static object LockLog = new object();

        public Form1()
        {
            InitializeComponent();
            LogWriter.GetInstance().NewLogEvent += this.RepaintLogs;

            this.txt_conf_nb_cookers.Text = Configuration.CookersNumber.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Launch();
        }

        private void btn_conf_save_Click(object sender, EventArgs e)
        {
            Configuration.CookersNumber = int.Parse(txt_conf_nb_cookers.Text);
            this.txt_conf_nb_cookers.Text = Configuration.CookersNumber.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
