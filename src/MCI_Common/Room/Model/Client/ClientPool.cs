using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Client
{
    class ClientPool
    {

        public 

        public List<Client> GenerateClients(int nb)
        {
            List<Client> cltList = new List<Client>();

            for (int i = 0; i < nb; i++)
                cltList.Add(new Client());

            return cltList;

        }

    }
}
