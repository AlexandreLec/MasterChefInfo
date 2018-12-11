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

namespace SimulationKitchen.Model
{
    public class CookChief
    {
        public Counter CounterPlate { get; set; }

        /// <summary>
        /// List of the recipe available in menu
        /// </summary>
        public List<Recipe>[] Menu { get; private set; }

        public List<Cooker> Cookers { get; set; }

        private readonly object LockCookers = new object();

        public CookChief(List<Cooker> cookers, Counter counterplate = null)
        {
            this.CounterPlate = counterplate;
            this.Cookers = cookers;
            LogWriter.GetInstance().Write("Build menu");
            this.Menu = new List<Recipe>[3];
            LogWriter.GetInstance().Write("generate menu");
            this.GenerateMenu();
            this.CounterPlate.RoomCommunication.NewMenuDemand += this.SendMenuDel;

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

        private void GenerateMenu()
        {
            
            List<Recipe> AllRecipe = new RecipeProcess().GetAll();
            List<Recipe> AllAvailableRecipe = AllRecipe.Where(o => this.RecipeAvailable(o)).ToList();
            List<Recipe> Starter = AllAvailableRecipe.Where(o => o.Type == RecipeType.STARTER).ToList();
            List<Recipe> Main = AllAvailableRecipe.Where(o => o.Type == RecipeType.MAIN).ToList();
            List<Recipe> Dessert = AllAvailableRecipe.Where(o => o.Type == RecipeType.DESSERT).ToList();
            this.Menu[0] = Starter;
            this.Menu[1] = Main;
            this.Menu[2] = Dessert;
            
        }

        public void SendMenuDel(object sender, EventArgs e)
        {
            this.SendMenu();
        }

        private void SendMenu()
        {
            LogWriter.GetInstance().Write(this.Menu[0][0].Name);
            string msg = Serialization.SerializeAnObject(this.Menu[0][0]);
            msg += "<MENU>";
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
