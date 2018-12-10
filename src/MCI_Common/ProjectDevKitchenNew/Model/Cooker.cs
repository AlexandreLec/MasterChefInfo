using MCI_Common.Devices;
using MCI_Common.Dishes;
using MCI_Common.Recipes;
using MCI_Common.Tools;
using MCI_Common.Behaviour;
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
    class Cooker : Movable
    {
        /// <summary>
        /// Identifier of the cooker
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Availability of the cooker
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Tools manager to lease tools
        /// </summary>
        public ToolsManager ToolsStorage { get; set; }

        /// <summary>
        /// Devices manager to lease devices
        /// </summary>
        public DevicesManager DevicesStorage { get; set; }

        public Washer WasherEngine { get; set; }

        public Oven OvenCook { get; private set; }

        /// <summary>
        /// Instantiate a cooker
        /// </summary>
        /// <param name="toolsStorage"></param>
        public Cooker(int id, Washer washer, Oven oven)
        {
            this.Id = id;
            this.ToolsStorage = ToolsManager.GetInstance();
            this.DevicesStorage = DevicesManager.GetInstance();
            this.WasherEngine = washer;
            this.OvenCook = oven;
            this.IsAvailable = true;
        }

        /// <summary>
        /// Prepare a step
        /// </summary>
        /// <param name="step">The step to prepare</param>
        public void PrepareStep(Step step, Dish dish = null)
        {
            Console.WriteLine("Cooker "+this.Id+" start step "+step.Order+" : " + step.Description);
            this.IsAvailable = false;
            if (!this.LeaseNeededTools(step.Tools)) Console.WriteLine("Ustensiles insuffisants pour réaliser la tâche");
            else if (!this.LeaseNeededDevices(step.Devices)) Console.WriteLine("Appareils insuffisants pour réaliser la tâche");
            else
            {
                Console.WriteLine("Working ...");
                Thread.Sleep((int) Math.Round(step.Time*60000)/60);
                Console.WriteLine("Step finished");
                this.WasherEngine.AddToolsToWash(step.Tools);
                this.DevicesStorage.ReleaseDevices(step.Devices);

                if (dish != null)
                {
                    if (dish.Recipe.BakeTime == 0)
                    {
                        dish.Ready = true;
                        Console.WriteLine("Dish n° " + dish.Id + " is finished");
                    }
                    else while (!this.OvenCook.PutInOven(dish)) { };
                }

                this.IsAvailable = true;
            }
        }

        /// <summary>
        /// Lease the differents tools needed for a specific step
        /// </summary>
        /// <param name="tools">Tools to lease</param>
        /// <returns>True if the lease is accept else false</returns>
        private bool LeaseNeededTools(List<Tool> tools)
        {
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

        /// <summary>
        /// Lease the differents devices needed for a specific step
        /// </summary>
        /// <param name="tools">Devices to lease</param>
        /// <returns>True if the lease is accept else false</returns>
        private bool LeaseNeededDevices(List<Device> devices)
        {
            foreach (var item in devices)
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                while (s.Elapsed < TimeSpan.FromSeconds(5))
                {
                    if (this.DevicesStorage.LeaseDevice(item))
                    {
                        item.IsAvailable = true;
                        break;
                    }
                }
                s.Stop();
            }
            return devices.All(device => device.IsAvailable);
        }
    }
}
