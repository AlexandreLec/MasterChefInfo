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
            var serverCreation = FactoryStaff.CreateServer();
            var roomMasterCreation = FactoryStaff.CreateRoomMaster();
            var rankChiefCreation = FactoryStaff.CreateRankChief();

            serverCreation.CreateServer();
            roomMasterCreation.CreateRoomMaster();
            rankChiefCreation.CreateRankChief();
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
