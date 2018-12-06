using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.RoomMaterials
{
    public class TB_Plate : TB_RoomMaterial
    {
        /// <summary>
        /// Create the map table for plates
        /// </summary>
        public TB_Plate()
        {
            this.DataTable = "AssiettesView";
        }

        /// <summary>
        /// SQL requets to get plate by type
        /// </summary>
        /// <param name="idType">type id of the plate to get</param>
        /// <returns>SQL request</returns>
        public override string GetByType(int idType)
        {
            return "SELECT * FROM "+this.DataTable+" WHERE TypeAssietteid = "+idType+";";
        }
    }
}
