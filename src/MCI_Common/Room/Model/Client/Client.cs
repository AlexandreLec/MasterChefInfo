using MCI_Common.Recipes;
using Room.Model.Behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Client
{
    class Client : OrderBehaviour
    {

        /// <summary>
        /// If the client received its dish
        /// </summary>
        private Boolean Served;

        /// <summary>
        /// List of the dishes ordered by the client
        /// </summary>
        private Recipe[] Order = new Recipe[3];

        /// <summary>
        /// Order meal, either 2 or 3 dishes at a time
        /// </summary>
        /// <param name="Menu"></param>
        private void OrderMeal(List<Recipe> Menu)
        {
            Random choice = new Random();

            Order[0] = Menu[choice.Next(6)];
        }

        /// <summary>
        /// Order a single dish
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Menu"></param>
        private void OrderDish(RecipeType Type, List<Recipe> Menu)
        {
            Random choice = new Random();

            if (Type == RecipeType.STARTER)
                Order[0] = Menu[choice.Next(0, 6)];

            else if (Type == RecipeType.MAIN)
                Order[1] = Menu[choice.Next(6, 12)];

            else if (Type == RecipeType.DESSERT)
                Order[1] = Menu[choice.Next(12, 18)];

            else
                Console.WriteLine("dish type unknown");


        }

        public void OrderMeal()
        {
            throw new NotImplementedException();
        }

        void OrderBehaviour.OrderMeal(List<Recipe> Menu)
        {
            throw new NotImplementedException();
        }
    }
}

