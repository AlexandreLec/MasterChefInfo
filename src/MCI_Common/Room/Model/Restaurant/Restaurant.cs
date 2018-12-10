using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCI_Common.RoomMaterials;
using Room.Model.Factory;
using Room.Model.Client;
using Room.Model.Staff;

namespace Room.Model.Restaurant
{
    class Restaurant
    {
        public List<Square> Squares { get; set; }

        


        public Restaurant()
        {
            this.Squares = new SquareProcess().GetAll();

            CreateStaff();
            Console.WriteLine("Staff created");

            CreateClients();
            Console.WriteLine("Clients created");
            
        }

        void CreateStaff()
        {
            FactoryStaff factory = FactoryStaff.GetFactory();
            Staff.Staff staff = factory.Create();
            staff.WhoAmI();


        }

        void CreateClients()
        {
            ClientPool cltPool = new ClientPool();

        }

        /*void ApplyConfig(IController Config)
        {
            
        }
        */
    }
}
