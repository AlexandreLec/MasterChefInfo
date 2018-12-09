using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Room.Model.Client
{
    public class ClientPool
    {

        public void AddGroup()
        {
            ThreadPool.QueueUserWorkItem(GenerateGroup);
        }

        /// <summary>
        /// Genereates the client group from created clients
        /// </summary>
        /// <param name="cltList"></param>
        private void GenerateGroup(object data)
        {
            // List for storing generated clients
            List<Client> cltList = new List<Client>();

            // Random number used for deciding group size
            Random number = new Random();

            // Generates between 1 and 10 clients 
            cltList = GenerateClients(number.Next(1, 11));

            // ClientGroup created
            ClientGroup group = new ClientGroup();

            // Group's list of clients filled with generated clients
            group.ClientList = cltList;
        }

        /// <summary>
        /// Generates the clients
        /// </summary>
        /// <param name="nb"></param>
        /// <returns></returns>
        private List<Client> GenerateClients(int nb)
        {
            List<Client> cltList = new List<Client>();

            for (int i = 0; i < nb; i++)
            {
                cltList.Add(new Client());
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            }

            return cltList;

        }

    }
}
