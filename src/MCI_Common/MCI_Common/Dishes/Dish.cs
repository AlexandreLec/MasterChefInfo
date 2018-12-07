using MCI_Common.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Dishes
{
    class Dish
    {
        /// <summary>
        /// Unique idnetifier of a dish
        /// </summary>
        public int Id { get; set; }

        public Recipe recipe { get; set; }

        public bool Ready { get; set; }
    }
}
