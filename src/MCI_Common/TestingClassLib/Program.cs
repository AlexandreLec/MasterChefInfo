using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCI_Common;
using MCI_Common.Devices;
using MCI_Common.Recipes;
using MCI_Common.RoomMaterials;

namespace TestingClassLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new RecipeProcess().GetAll().Count());

            Console.Read();
        }
    }
}