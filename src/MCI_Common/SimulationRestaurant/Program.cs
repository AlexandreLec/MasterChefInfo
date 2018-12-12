using ProjectGameRestaurantNew;
using Room.Model.Restaurant;
using SimulationRestaurant.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationRestaurant
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        [STAThread]
        public static void Launch()
        {
            IModel model = new Restaurant();
            using (var game = new Game1(model))
                game.Run();
        }

        public static void Stop()
        {
           
        }
    }
}
