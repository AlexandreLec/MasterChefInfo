using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCI_Common.Recipes;
using MCI_Common.Timer;
using Room.Model.Client;
using Room.Model.Staff;

namespace Room.Model.Behaviour
{
    class OrderTwoStep : OrderBehaviour
    {
        public const string method = "two";
        public string Method()
        {
            return method;
        }

        public void OrderDessert(Client.Client clt)
        {
            clt.Order[2] = RankChief.Counter.Menu[2][Randomizer.Instance.R.Next(0, RankChief.Counter.Menu[2].Count)];
        }

        public void OrderMain(Client.Client clt)
        {
            clt.Order[1] = RankChief.Counter.Menu[1][Randomizer.Instance.R.Next(0, RankChief.Counter.Menu[1].Count)];
        }


        public void OrderStarter(Client.Client clt)
        {
            clt.Order[0] = RankChief.Counter.Menu[0][Randomizer.Instance.R.Next(0, RankChief.Counter.Menu[0].Count)];

        }

        public void OrderWine(Client.Client clt)
        {

        }

        public void OrderMeal(Client.Client clt)
        {
            OrderStarter(clt);
            OrderMain(clt);
        }

        
    }
}
