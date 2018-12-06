using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Factory
{
    public class FactoryStaff
    {
        public static IFactoryServer CreateServer()
        {
            return new Staff.Server();
        }

        public static IFactoryRoomMaster CreateRoomMaster()
        {
            return new Staff.RoomMaster();
        }

        public static IFactoryRankChief CreateRankChief()
        {
            return new Staff.RankChief();
        }
    }
}
