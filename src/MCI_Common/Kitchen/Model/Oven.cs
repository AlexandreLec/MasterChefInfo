using MCI_Common.Dishes;
using MCI_Common.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    class Oven
    {
        public bool IsAvailable { get; set; }

        public Oven()
        {
            this.IsAvailable = true;
        }

        public bool PutInOven(Dish dish)
        {
            if (!this.IsAvailable) return false;
            else
            {
                FireRecipe(dish);
                return true;
            }
        }

        private void FireRecipe(Dish dish)
        {
            this.IsAvailable = false;
            new Thread(() =>
            {
                Console.WriteLine("Fire starting");
                Thread.Sleep((int)Math.Round(dish.Recipe.BakeTime * 60000) / 60);
                dish.Ready = true;
                Console.WriteLine("Dish n° " + dish.Id +" is finished");
                this.IsAvailable = true;
            }).Start();
        }
    }
}
