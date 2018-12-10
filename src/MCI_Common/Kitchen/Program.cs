using Kitchen.Model;
using MCI_Common.Dishes;
using MCI_Common.Ingredients;
using MCI_Common.Recipes;
using ProjectDevKitchenNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(new SocketCom("10.162.128.230", 11000).Send(new IngredientProcess().GetOne(1)));

            //Cooker cuisto = new Cooker(1);
            //cuisto.PrepareStep(new RecipeProcess().GetOne(1).Steps[0]);

           /* Washer washman = new Washer();
            Oven four = new Oven();

            Order order = new Order();
            Dish one = new Dish(order);
            Dish two = new Dish(order);
            one.Recipe = new RecipeProcess().GetOne(1);
            two.Recipe = new RecipeProcess().GetOne(2);

            order.Dishes.Add(one);
            order.Dishes.Add(two);

            one.Id = 1;
            two.Id = 2;

            CookChief chief = new CookChief(4, washman);
            chief.CarryOrder(order);*/

            Console.Read();

            using (var game = new Game1())
                game.Run();
            Console.Read();
        }
    }
}
