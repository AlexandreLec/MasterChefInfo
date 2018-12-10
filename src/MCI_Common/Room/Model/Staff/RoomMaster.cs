using Room.Model.Client;
using MCI_Common.RoomMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Staff
{
    public class RoomMaster : Staff
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
            // Count of the number of clients in the group
            int WaitingClients = groupClient.ClientList.Count();

            // Initiate a new list of tables
            List<Table> ListTables = new List<Table>();
            List<Table> AvailableTables = new List<Table>();


            // List all the tables
            foreach (var square in new SquareProcess().GetAll())
            {
                foreach (var table in square.Tables)
                {
                    ListTables.Add(table);
                }
            }

            foreach (var AvailableTable in ListTables.Where(t => t.Capacity >= WaitingClients))
            {
                AvailableTables.Add(AvailableTable);
            }

            Table AssignedTable = AvailableTables[0];
            AssignedTable.ClientGroupIdAssigned = groupClient.Id;
            AssignedTable.IsAvailable = false;
        }


        public override void WhoAmI()
        {
            Console.WriteLine("I'm a RoomMaster");
        }
    }
}
