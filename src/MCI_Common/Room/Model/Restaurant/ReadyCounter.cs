using MCI_Common.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Restaurant
{
    public class ReadyCounter
    {
        public List<Recipe>[] Menu;

        public ReadyCounter()
        {
            Menu = new List<Recipe>[3];

            Menu[0] = new List<Recipe>();
            Menu[1] = new List<Recipe>();
            Menu[2] = new List<Recipe>();
        }

        public void UpdateMenu(List<Recipe>[] plats)
        {
            for (int i=0; i < 3; i++)
                Menu[i] = plats[i];
        }

    }
}
