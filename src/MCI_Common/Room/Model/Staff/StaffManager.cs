﻿using Room.Model.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Staff
{
    class StaffManager
    {
        /// <summary>
        /// List of rank chiefs
        /// </summary>
        private RankChief[] Rankchiefs;

        /// <summary>
        /// The room master
        /// </summary>
        private RoomMaster Master;

        /// <summary>
        /// List of servers
        /// </summary>
        private Server[] Servers;

        /// <summary>
        /// Assign a rank chief to take the order
        /// </summary>
        /// <param name="clients"></param>
        public void ReadyToOrder(ClientGroup clients)
        {
            
        }

        /// <summary>
        /// Assign a server to clear and serve the meal
        /// </summary>
        /// <param name="clients"></param>
        public void DishTerminated(ClientGroup clients)
        {
            
        }

        /// <summary>
        /// Assign a room master to make payment
        /// </summary>
        /// <param name="clients"></param>
        public void Payment(ClientGroup clients)
        {
            
        }
    }
}