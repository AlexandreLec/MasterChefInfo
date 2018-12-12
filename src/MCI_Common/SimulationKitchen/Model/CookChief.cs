using MCI_Common.Communication;
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
using System.Xml.Serialization;

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
            this.Menu = new List<Recipe>();
            this.GenerateMenu();
            this.CounterPlate.RoomCommunication.NewMenuDemand += this.SendMenuDel;
            this.CounterPlate.RoomCommunication.NewOrderArrive += this.CarryOrder;
        }

        public void CarryOrder(object sender, EventArgs e)
        {
            OrderEventArgs order = (OrderEventArgs) e;
            LogWriter.GetInstance().Write("Starting prepare order n° "+order.receiveOrder.Id);
            foreach (var item in order.receiveOrder.Dishes)
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

        private void GenerateMenu()
        {
            List<Recipe> AllRecipe = new RecipeProcess().GetAll();
            this.Menu = AllRecipe.Where(o => this.RecipeAvailable(o)).ToList();
            
        }

        public void SendMenuDel(object sender, EventArgs e)
        {
            this.SendMenu();
        }

        private void SendMenu()
        {
            string msg = Serialization.SerializeAnObject(this.Menu);
            msg += "<MENU>";
            Console.WriteLine(msg);
            this.CounterPlate.RoomCommunication.Send(msg);
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
            List<Ingredient> AllIngredients = new IngredientProcess().ListAll();

            foreach (var item in recipe.Steps)
            {
                if (item.Ingredients.Count() == 0) continue;
                else
                {
                    foreach (var ingredient in item.Ingredients)
                    {
                        if (ingredient.Quantity <= AllIngredients.Where(o => o.Id == ingredient.Id).First().Quantity) result.Add(true);
                        else result.Add(false);
                    }
                }
            }
            return result.All(o => o == true);
        }

    }
}
