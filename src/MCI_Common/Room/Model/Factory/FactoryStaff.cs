using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Factory
{
    abstract class FactoryStaff
    {
        public static FactoryStaff GetFactory()
        {
            int RankChiefNumber = 1;
            int RoomMasterNumber = 1;
            int ServerNumber = 1;

            while (RankChiefNumber != 0)
            {
                RankChiefNumber--;
                return (new FactoryRankChief());
            }

            while (RoomMasterNumber != 0)
            {
                RoomMasterNumber--;
                return (new FactoryRoomMaster());
            }

            while (ServerNumber != 0)
            {
                ServerNumber--;
                return (new FactoryServer());
            }
            return GetFactory();
        }

        public abstract Staff.Staff Create();
    }
}
