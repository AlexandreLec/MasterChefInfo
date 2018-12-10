using MCI_Common.Recipes;
using MCI_Common.Time;
using Room.Model.Client;
using Room.Model.Factory;
using Room.Model.Staff;
using Room.Model.Restaurant;
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
            FactoryStaff factory = FactoryStaff.GetFactory();
            Staff staff = factory.Create();
            staff.WhoAmI();

           /* Restaurant resto = new Restaurant();


            ClientPool clients = new ClientPool(); */

            Console.Read();
        }
    }
}
