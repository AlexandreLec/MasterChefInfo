using MCI_Common.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Dishes
{
    public class Dish
    {
        /// <summary>
        /// Unique idnetifier of a dish
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Recipe of the dish ordered
        /// </summary>
        public Recipe Recipe { get; set; }

        /// <summary>
        /// State of the dish
        /// </summary>
        public bool Ready { get; set; }

        public Order CurrentOrder { get; private set; }

        /// <summary>
        /// Instantiate a new dish
        /// </summary>
        public Dish(Order order)
        {
            this.CurrentOrder = order;
            this.Ready = false;
        }
    }
}
