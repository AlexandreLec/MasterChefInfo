using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Room.Model.Staff;
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
            Console.WriteLine("Client Pool created");

            //Creates client groups
            /*   UNCOMMENT FOR PRODUCTION   */
            AddGroup();
            //while(nbCltSinceStart < Global_Settings.nbCltPerShift)
            //{
            //    AddGroup();

            //    //Wait 5 Sim min
            //    Thread.Sleep(5* MCI_Common.Timer.Clock.Instance.Period);
            //}

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
            Console.WriteLine("New client group ({1} pax), thread ID : {0}", Thread.CurrentThread.ManagedThreadId, rdNb);
            ClientGroup group = new ClientGroup(nbCltGp, cltList);

            


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

            for (int i = 0; i < nb; i++)
            {
                clt = new Client();
                cltList.Add(clt);
                
                

            }

            return cltList;

        }

    }
}
