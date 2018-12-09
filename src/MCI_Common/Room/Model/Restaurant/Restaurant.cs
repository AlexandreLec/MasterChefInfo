using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCI_Common.RoomMaterials;
using Room.Model.Factory;

namespace Room.Model.Restaurant
{
    class Restaurant
    {
        public List<Square> Squares { get; set; }

        Restaurant()
        {
            this.Squares = new SquareProcess().GetAll();
            
        }

        void CreateStaff()
        {
            FactoryStaff factory = FactoryStaff.GetFactory();
            Staff.Staff staff = factory.Create();
            staff.WhoAmI();
        }

        void CreateClients()
        {

        }

        /*void ApplyConfig(IController Config)
        {
            
        }
        */
    }
}
