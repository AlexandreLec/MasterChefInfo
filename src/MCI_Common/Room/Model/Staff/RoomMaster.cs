using Room.Model.Client;
using MCI_Common.RoomMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Staff
{
    class RoomMaster : Factory.IFactoryRoomMaster
    {
        /// <summary>
        /// Sprite of the room master
        /// </summary>
        private string Sprite;

        /// <summary>
        /// Check the reservation of a group of clients
        /// </summary>
        /// <param name="groupClient"></param>
        public void CheckReservation(ClientGroup groupClient)
        {
            
        }

        /// <summary>
        /// Assign a table to a group of clients
        /// </summary>
        /// <param name="groupClient"></param>
        public void AssignTable(ClientGroup groupClient)
        {
            // 
            int WaitingClients = groupClient.ClientList.Count();


        }

        public void CreateRoomMaster()
        {

        }
    }
}
