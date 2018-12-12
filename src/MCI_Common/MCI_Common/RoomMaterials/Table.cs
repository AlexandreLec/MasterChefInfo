using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCI_Common.Behaviour;

namespace MCI_Common.RoomMaterials
{
    public class Table
    {
        /// <summary>
        /// Id of the table
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Numero to identify the table
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Number of person that can eat at this table
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Table available or not
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Client group assigned to a table
        /// </summary>
        public int ClientGroupIdAssigned { get; set; }
  
        /// <summary>
        /// Number of breadbasket
        /// </summary>
        public int BreadBasket { get; set; }

        /// <summary>
        /// Water bottle on the table
        /// </summary>
        public int Water { get; set; }

        /// <summary>
        /// Location of the table in the room
        /// </summary>
        public Position TableLocation { get; set; }

        public Table()
        {
            
        }
        
    }
}
