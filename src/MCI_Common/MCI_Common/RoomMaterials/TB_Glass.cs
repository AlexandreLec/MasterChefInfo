using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.RoomMaterials
{
    public class TB_Glass : TB_RoomMaterial
    {
        /// <summary>
        /// Create the map table for glass
        /// </summary>
        public TB_Glass()
        {
            this.DataTable = "GlassView";
        }

        /// <summary>
        /// SQL requets to get silverware by type
        /// </summary>
        /// <param name="idType">type id of the silverware to get</param>
        /// <returns>SQL request</returns>
        public override string GetByType(int idType)
        {
            return "SELECT * FROM " + this.DataTable + " WHERE TypeVerreid = " + idType + ";";
        }
    }
}
