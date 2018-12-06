using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room.Model.Factory;

namespace Room.Model.Restaurant
{
    class Restaurant
    {
        Restaurant()
        {

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
