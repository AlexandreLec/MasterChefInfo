using MCI_Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    class Washer
    {
        /// <summary>
        /// List of the tools to wash
        /// </summary>
        public List<Tool> ToolsToWash { get; private set; }

        /// <summary>
        /// Lock for the tools to wash list
        /// </summary>
        private object LockToolsToWashList = new object();

        public Washer()
        {
            this.ToolsToWash = new List<Tool>();
        }

        private void WashTool(Tool tool)
        {
            Console.WriteLine("Washer start washing tool " + tool.Name);
            Thread.Sleep((int)Math.Round(tool.WashingTime * 60000) / 60);
            Console.WriteLine("Washer finished washing tool " + tool.Name);
            this.ToolsToWash.Remove(tool);
            ToolsManager.GetInstance().ReleaseTool(tool);
            
        }

        public Thread StartWorking()
        {
            return new Thread(() =>
            {
                Console.WriteLine("Washer start working");
                while (true)
                {
                    lock (LockToolsToWashList)
                    {
                        List<Tool> tools = new List<Tool>(this.ToolsToWash);
                        if (tools.Count() > 0)
                        {
                            foreach (var item in tools)
                            {
                                this.WashTool(item);
                            }
                        }
                    }
                }
            });
        }

        public void AddToolsToWash(List<Tool> tools)
        {
            lock (LockToolsToWashList)
            {
                foreach (var item in tools)
                {
                    Console.WriteLine(item.Name + " added to the washing list");
                    this.ToolsToWash.Add(item);
                }
            }
            
        }
    }
}
