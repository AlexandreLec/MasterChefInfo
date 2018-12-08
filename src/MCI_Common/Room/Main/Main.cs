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
            Clock.Instance.Speed = 2;
            Clock.Instance.Period = 6000;

            Console.WriteLine("Waiting {0} seconds (speed = 2)", Clock.Instance.Period);
            Thread.Sleep(Clock.Instance.Period);

            Clock.Instance.Speed = 1;
            Console.WriteLine("Waiting {0} seconds (speed = 1)", Clock.Instance.Period);
            Thread.Sleep(Clock.Instance.Period);

        }
    }
}
