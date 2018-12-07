using Kitchen.Model;
using MCI_Common.Ingredients;
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
            Console.WriteLine(new SocketCom("10.162.128.230", 11000).Send(new IngredientProcess().GetOne(1)));

            Console.Read();
        }
    }
}
