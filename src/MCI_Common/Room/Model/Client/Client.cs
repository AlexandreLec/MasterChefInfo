using MCI_Common.Recipes;
using Room.Model.Behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Client
{
    class Client
    {

        /// <summary>
        /// If the client received its dish, false when
        /// the waiter clears the table
        /// </summary>
        private Boolean Served;

        /// <summary>
        /// List of the dishes ordered by the client
        /// </summary>
        public Recipe[] Order = new Recipe[3];

        /// <summary>
        /// The client orders in one or two times
        /// </summary>
        private OrderBehaviour OrderMethod;

        private void Test()
        {
            OrderMethod.OrderMeal(this);
        }
        
        

       
    }
}

