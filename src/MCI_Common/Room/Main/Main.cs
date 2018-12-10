using MCI_Common.Recipes;
using ProjectGameRestaurantNew;
using Room.Model.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Room.Main
{
    class Program
    {
        static void Main(string[] args)
        {

            /*ClientPool clients = new ClientPool();

            

            for (int i=0; i < 10; i++)
            {
                clients.AddGroup();
                Thread.Sleep(Clock.Instance.Period);
                Console.WriteLine(" ");
            }*/

            using (var game = new Game1())
                game.Run();
            Console.Read();

        }
    }
}
