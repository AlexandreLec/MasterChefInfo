using MCI_Common.Dishes;
using MCI_Common.Ingredients;
using MCI_Common.Recipes;
using Microsoft.Xna.Framework;
using SimulationKitchen.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimulationKitchen.Model
{
    public class CookChief
    {
        public Counter CounterPlate { get; set; }

        /// <summary>
        /// List of the recipe available in menu
        /// </summary>
        public List<Recipe> Menu { get; private set; }

        public List<Cooker> Cookers { get; set; }

        private readonly object LockCookers = new object();

        public CookChief(List<Cooker> cookers, Counter counterplate = null)
        {
            this.CounterPlate = counterplate;
            this.Cookers = cookers;
        }

        public void CarryOrder(Order cmd)
        {
            LogWriter.GetInstance().Write("Starting prepare order n° "+cmd.Id);
            foreach (var item in cmd.Dishes)
            {
                ThreadPool.QueueUserWorkItem(state => PrepareDish(item));
            }
        }

        /// <summary>
        /// Prepare a recipe
        /// </summary>
        /// <param name="recipe">The recipe to prepare</param>
        private void PrepareDish(Dish dish)
        {
            foreach (var step in dish.Recipe.Steps)
            {
                Cooker cooker;
                { cooker = this.ElectCooker(); } while (cooker == null) ;

                if (step.Order == dish.Recipe.Steps.Count()) cooker.PrepareStep(step, dish);
                else cooker.PrepareStep(step);
            }
            if (dish.CurrentOrder.Dishes.All(o => o.Ready)) dish.CurrentOrder.Ready = true;
        }

        public void GenerateMenu()
        {
            this.Menu = new RecipeProcess().GetAll().Where(o => this.RecipeAvailable(o)).ToList();
            this.CounterPlate.RoomCommunication.Send(this.Menu);
        }

        private Cooker ElectCooker()
        {
            lock (LockCookers)
            {
                foreach (var cooker in this.Cookers)
                {
                    if (cooker.IsAvailable) return cooker;
                }
                return null;
            }
            
        }

        private bool RecipeAvailable(Recipe recipe)
        {
            List<bool> result = new List<bool>();

            foreach (var item in new RecipeProcess().GetOne(1).Steps)
            {
                if (item.Ingredients.Count() == 0) continue;
                else
                {
                    result.Add(item.Ingredients.All(o => o.Quantity <= new IngredientProcess().GetOne(o.Id).Quantity));
                }
            }
            return result.All(o => o == true);
        }

    }
}
