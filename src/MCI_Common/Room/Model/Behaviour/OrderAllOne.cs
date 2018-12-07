using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCI_Common.Recipes;
using Room.Model.Client;
using Room.Model.Staff;

namespace Room.Model.Behaviour
{
    class OrderAllOne : OrderBehaviour
    {
        /// <summary>
        /// Order meal according to client's order method
        /// </summary>
        /// <param name="clt"></param>
        public void OrderMeal(Client.Client clt)
        {

            Random choice = new Random();

            clt.Order[0] = RankChief.Counter.Menu[choice.Next(0, 6)];
            clt.Order[1] = RankChief.Counter.Menu[choice.Next(6, 12)];
            clt.Order[2] = RankChief.Counter.Menu[choice.Next(12, 18)];
        }
    }
}
