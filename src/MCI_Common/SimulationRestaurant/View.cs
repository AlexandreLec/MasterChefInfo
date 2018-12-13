using ProjectGameRestaurantNew;
using SimulationRestaurant.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationRestaurant
{
    class View
    {
        public static IModel Model { get; set; }

        public View(IModel model)
        {
            Model = model;
            View.Launch();
        }

        [STAThread]
        public static void Launch()
        {
            using (var game = new Game1(View.Model))
                game.Run();
        }
    }
}
