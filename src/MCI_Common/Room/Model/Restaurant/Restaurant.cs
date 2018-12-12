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

namespace Room.Model.Restaurant
{
    class Restaurant
    {
        /// <summary>
        /// List of the squares in the room
        /// </summary>
        public List<Square> Squares { get; set; }

        /// <summary>
        /// Staff manager instance
        /// </summary>
        public StaffManager Staff { get; set; }

        /// <summary>
        /// Instantiate a restaurant
        /// </summary>
        public Restaurant()
        {
            //this.Squares = new SquareProcess().GetAll();

            Staff = new StaffManager();
            Console.WriteLine("Staff created");

            CreateClientPool();
            Console.WriteLine("Clients created");
            
        }

        /// <summary>
        /// Generate the client ppol
        /// </summary>
        void CreateClientPool()
        {
            while (this.Staff.Counter.ready == false) { }
            this.CltPool = new ClientPool();
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
