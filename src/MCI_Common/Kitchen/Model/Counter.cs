using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    class Counter
    {
        private static Counter Instance = null;

        private SocketCom RoomCommunication;

        private Counter()
        {
            this.RoomCommunication = new SocketCom("10.162.128.230", 11000);
        }

        public static Counter GetInstance()
        {
            if(Counter.Instance == null)
            {
                Counter.Instance = new Counter();
            }
            return Counter.Instance;
        }
    }
}
