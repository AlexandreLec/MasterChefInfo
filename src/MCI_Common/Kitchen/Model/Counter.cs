using MCI_Common.Dishes;
using MCI_Common.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    class Counter
    {
        /// <summary>
        /// Instance of the counter
        /// </summary>
        private static Counter Instance = null;

        /// <summary>
        /// Socket client to connect to room
        /// </summary>
        private SocketCom RoomCommunication;

        /// <summary>
        /// List of the recipe available in menu
        /// </summary>
        public List<Recipe> Menu { get; set; }

        /// <summary>
        /// List of clients's orders
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Instantiate the counter
        /// </summary>
        private Counter()
        {
            this.RoomCommunication = new SocketCom("10.162.128.230", 11000);
        }

        public static Counter GetInstance()
        {
            if(Counter.Instance == null)
            {
                Counter.Instance = new Counter();
            }
            return Counter.Instance;
        }
    }
}
