using MCI_Common.Recipes;
using MCI_Common.Time;
using System;
using System.Collections;
using System.Collections.Generic;
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


            Console.WriteLine("Waiting 5 minutes in simulation, {0} seconds in real life (speed = 1, scale = 10)", Clock.Instance.Period * 5 / 1000);
            Thread.Sleep(Clock.Instance.Period * 5);

            Clock.Instance.Speed = 2;
            Console.WriteLine("Waiting 5 minutes in simulation, {0} seconds in real life (speed = 2, scale = 10)", ((float)Clock.Instance.Period * 5 / 1000) );
            Thread.Sleep(Clock.Instance.Period * 5);

        }
    }
}
