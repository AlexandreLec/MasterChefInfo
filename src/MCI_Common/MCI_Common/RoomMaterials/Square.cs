using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.RoomMaterials
{
    public class Square
    {
        /// <summary>
        /// Id of the table
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tables containing in this square
        /// </summary>
        public List<Table> Tables { get; set; }
    }
}
