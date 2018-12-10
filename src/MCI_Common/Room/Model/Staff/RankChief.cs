using MCI_Common.RoomMaterials;
using MCI_Common.Dishes;
using Room.Model.Client;
using Room.Model.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Staff
{
    public class RankChief : Staff
    {
        /// <summary>
        /// Square in the room
        /// </summary>
        //private Square mySquare;

        /// <summary>
        /// Sprite of the rank chief
        /// </summary>
        private string Sprite;

        public static ReadyCounter Counter { get; internal set; }



        /// <summary>
        /// Prepare a table
        /// </summary>
        /// <param name="Table"></param>
        public void PrepareTable(Table tableToPrep)
        {
            
        }
        

        /// <summary>
        /// Clean a table
        /// </summary>
        /// <param name="Table"></param>
        public void ClearTable(Table tableToClr)
        {
            
        }
        
        

        /// <summary>
        /// Sets position of clients around the table according to avalaible spots
        /// </summary>
        /// <param name="cltGr"></param>
        public void SeatClients(ClientGroup cltGr)
        {
            int i = 0;

            foreach (Client.Client clt in cltGr.ClientList)
            {
                clt.position.SetPosition(cltGr.TableSit.posAroundTable[i]);
            }
        }

        /// <summary>
        /// Take the client's order
        /// </summary>
        /// <param name="clients"></param>
        public void TakeOrderTable(ClientGroup clients)
        {
            foreach (Client.Client clt in clients.ClientList)
            {
                for(int i=0; i < 3; i++)
                {
                    Dish dish = new Dish(clients.tableOrder);
                    dish.Recipe = clt.Order[i];
                    clients.tableOrder.Dishes.Add(dish);
                }
            }
        }

        public override void WhoAmI()
        {
            Console.WriteLine("I'm a RankChief");
        }
    }
}
