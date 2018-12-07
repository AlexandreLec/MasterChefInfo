using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCI_Common.Recipes;

namespace Room.Model.Behaviour
{
    interface OrderBehaviour
    {
        List<Recipe> OrderMeal();
    }
}
