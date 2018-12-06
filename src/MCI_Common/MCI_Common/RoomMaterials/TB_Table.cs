using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.RoomMaterials
{
    public class TB_Table
    {
        /// <summary>
        /// Table use to interact with database (get and set)
        /// </summary>
        public Table CurrentTable { get; set; }

        /// <summary>
        /// Name of the table in database
        /// </summary>
        private static string DataTable = "TablesView";

        /// <summary>
        /// Get all table in a square
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetAll(int square)
        {
            return "SELECT * FROM " + DataTable + " WHERE Carresid = "+square+";";
        }
    }
}
