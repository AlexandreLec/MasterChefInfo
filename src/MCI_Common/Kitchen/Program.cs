using Kitchen.Model;
using MCI_Common.Ingredients;
using MCI_Common.Recipes;
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
            ToolsManager manager = new ToolsManager();

            Cooker cuisto = new Cooker(manager);
            cuisto.PrepareStep(new RecipeProcess().GetOne(1).Steps[1]);
            Cooker cuisto2 = new Cooker(manager);
            cuisto2.PrepareStep(new RecipeProcess().GetOne(1).Steps[1]);

            Console.Read();
        }
    }
}
