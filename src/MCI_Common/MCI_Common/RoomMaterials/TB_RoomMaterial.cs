using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.RoomMaterials
{
    abstract class TB_RoomMaterial
    {
        /// <summary>
        /// RoomMaterial to use
        /// </summary>
        public RoomMaterial CurrentRoomMaterial { get; set; }

        /// <summary>
        /// Name of the table in database
        /// </summary>
        private static string DataTable;

        /// <summary>
        /// Get all rows in table
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetAll()
        {
            return "SELECT * FROM " + DataTable + ";";
        }
    }
}
