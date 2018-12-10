using MCI_Common.Recipes;
using MCI_Common.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Kitchen.Model
{
    class Cooker
    {
        public bool IsAvailable { get; set; }

        public ToolsManager ToolsStorage { get; set; }

        public Cooker(ToolsManager toolsStorage)
        {
            this.ToolsStorage = toolsStorage;
        }

        public void PrepareStep(Step step)
        {
            Console.WriteLine("Cooker start step "+step.Order+" : " + step.Description);
            this.IsAvailable = false;
            if (!this.LeaseNeededTools(step.Tools)) Console.WriteLine("Outils insuffisants pour réaliser la tâche");
            else
            {
                Console.WriteLine("Working ...");
                Thread.Sleep((int) Math.Round(step.Time*60000)/60);
                Console.WriteLine("Step finished");
            }
        }

        private bool LeaseNeededTools(List<Tool> tools)
        {
            Console.WriteLine(tools.Count());
            foreach (var item in tools)
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                while (s.Elapsed < TimeSpan.FromSeconds(5))
                {
                    if (this.ToolsStorage.LeaseTool(item))
                    {
                        item.IsAvailable = true;
                        break;
                    }
                }
                s.Stop();
            }

            return tools.All(tool => tool.IsAvailable);
        }
    }
}
