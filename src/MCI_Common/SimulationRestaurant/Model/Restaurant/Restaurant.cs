using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCI_Common.RoomMaterials;
using Room.Model.Factory;
using Room.Model.Client;
using Room.Model.Staff;
using Room.Interfaces;
using SimulationRestaurant.Interfaces;

namespace Room.Model.Restaurant
{
    public class Restaurant : IModel
    {
        /// <summary>
        /// List of the tables in the room
        /// </summary>
        public List<Table> ListTables { get; private set; }

        /// <summary>
        /// Staff manager instance
        /// </summary>
        public StaffManager Staff { get; set; }

        /// <summary>
        /// Clients group list
        /// </summary>
        public List<ClientGroup> Clients { get; set; }

        /// <summary>
        /// Instantiate a restaurant
        /// </summary>
        public Restaurant()
        {
            //this.Squares = new SquareProcess().GetAll();
            Staff = StaffManager.Instance;
            Console.WriteLine("Staff created");

            CreateClientPool();
            Console.WriteLine("Clients created");
            this.ListTables = new List<Table>();
            this.GenerateTable();
        }

        /// <summary>
        /// Generate the client ppol
        /// </summary>
        void CreateClientPool()
        {
            while (this.Staff.Counter.ready == false) { }
            Console.WriteLine("Create client pool");
            ClientPool CltPool = new ClientPool();
        }

        /// <summary>
        /// Generate the table
        /// </summary>
        public void GenerateTable()
        {
            // List all the tables
            foreach (var square in new SquareProcess().GetAll())
            {
                foreach (var table in square.Tables)
                {
                    ListTables.Add(table);
                }
            }
            int i = 0;
            int y = 0;
            foreach (var table in ListTables)
            {
                table.TableLocation.posX = 48+i;
                table.TableLocation.posY = 64+y;
                i += 64;
                if (i == 384)
                {
                    y = 32;
                    i = 0;
                }
            }
        }

        /// <summary>
        /// Apply user configuration
        /// </summary>
        /// <param name="Config"></param>
        void ApplyConfig(IController Config)
        {
            
        }
        
    }
}
