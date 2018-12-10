using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Room.Model.Staff;
using MCI_Common.Time;
using MCI_Common.Communication;

namespace Room.Model.Client
{
    public class ClientPool
    {
        
        /// <summary>
        /// Number of clients since start
        /// </summary>
        private int nbCltSinceStart = 0;

        /// <summary>
        /// Number of client groups
        /// </summary>
        private int nbCltGp = 0;

        public ClientPool()
        {

            //Creates client groups
            while(nbCltSinceStart < Global_Settings.nbCltPerShift)
            {
                AddGroup();

                //Wait 5 Sim min
                Thread.Sleep(5*Clock.Instance.Period);
            }

        }

        /// <summary>
        /// Adds a client group to the thread pool
        /// </summary>
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

            // Randomizer
            Random number = new Random();

            // Random number used for deciding group size
            int rdNb = number.Next(1, 11);

            // Increment number of clients since start
            nbCltSinceStart += rdNb;

            //Increment group number
            nbCltGp++;

            // Generates between 1 and 10 clients 
            cltList = GenerateClients(rdNb);

            // ClientGroup created
            ClientGroup group = new ClientGroup(nbCltGp);

            // Group's list of clients filled with generated clients
            group.ClientList = cltList;

            // Add event subsriptions
            

        }

        /// <summary>
        /// Generates the clients
        /// </summary>
        /// <param name="nb"></param>
        /// <returns></returns>
        private List<Client> GenerateClients(int nb)
        {
            List<Client> cltList = new List<Client>();
            Client clt;

            Console.WriteLine("New client group, nb : {0}", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < nb; i++)
            {
                clt = new Client();
                cltList.Add(clt);
                
                

            }

            return cltList;

        }

    }
}
