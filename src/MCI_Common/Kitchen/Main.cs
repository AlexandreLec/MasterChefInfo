using MCI_Common.Recipes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjectDevKitchenNew;

namespace Kitchen.Main
{
    class Program
    {
        static void KitchenMain(string[] args)
        {           
            using (var game = new Game2())
                game.Run();
            Console.Read();

        }
    }
}
