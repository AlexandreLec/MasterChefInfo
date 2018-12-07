using Room.Model.Client;
using Room.Model.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Staff
{
    public class RankChief : Factory.IFactoryRankChief
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
        /*public void PrepareTable(Table TableToPrep)
        {
            
        }
        */

        /// <summary>
        /// Clean a table
        /// </summary>
        /// <param name="Table"></param>
        /* public void ClearTable(Table TableToPrep)
        {
            
        }
        */

        /// <summary>
        /// Take the client's order
        /// </summary>
        /// <param name="clients"></param>
        public void TakeOrder(ClientGroup clients)
        {
            
        }

        public void CreateRankChief()
        {
            
        }
    }
}
