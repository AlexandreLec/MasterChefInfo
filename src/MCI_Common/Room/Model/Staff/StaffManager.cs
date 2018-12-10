using Room.Model.Client;
using Room.Model.Factory;
using MCI_Common.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Staff
{
    public class StaffManager
    {
        /// <summary>
        /// List of rank chiefs
        /// </summary>
        private List<RankChief> Rankchiefs;

        /// <summary>
        /// The room master
        /// </summary>
        private RoomMaster Master;

        /// <summary>
        /// List of servers
        /// </summary>
        private List<Server> Servers;

        /// <summary>
        /// Staff Manager thread safe Single instance
        /// </summary>
        private static StaffManager instance = null;
        private static readonly object padlock = new object();

        public StaffManager()
        {
            for (int i = 0; i < Global_Settings.nbRankChief; i++)
                Rankchiefs.Add(new RankChief());
            for (int i = 0; i < Global_Settings.nbServers; i++)
                Servers.Add(new Server());


        }

        /// <summary>
        /// Method for Singelton Management
        /// </summary>
        public static StaffManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new StaffManager();
                    }
                    return instance;
                }
            }
        }


        /// <summary>
        /// Assign a rank chief to take the order
        /// </summary>
        /// <param name="clients"></param>
        public void OnReadyToOrder(object source, OrderEventArgs Id)
        {
            Console.WriteLine("Le client {0} est prêt à commander", Id.Id);
        }

        /// <summary>
        /// Assign a server to clear and serve the meal when event raised
        /// </summary>
        /// <param name="source"></param>
        /// <param name="Id"></param>
        public void OnDishFinished(object source, OrderEventArgs Id)
        {
            Console.WriteLine("Le client {0} a fini", Id.Id);
        }

        /// <summary>
        /// Assign a room master to make payment
        /// </summary>
        /// <param name="clients"></param>
        public void OnReadyToPay (object source, OrderEventArgs Id)
        {
            Console.WriteLine("Le client {0} est prêt à payer", Id.Id);
            //Prepare payment
        }
    }
}
