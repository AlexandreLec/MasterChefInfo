using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCI_Common;
using MCI_Common.Devices;
using MCI_Common.Recipes;

namespace TestingClassLib
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeProcess RecipeManagement = new RecipeProcess();

            Console.WriteLine(RecipeManagement.GetOne("Feuilleté au crabe").Steps[1].Ingredients);
            
            Console.Read();
        }
    }
}