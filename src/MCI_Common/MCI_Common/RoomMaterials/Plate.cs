using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.RoomMaterials
{
    public class Plate : RoomMaterial 
    {
        /// <summary>
        /// Type of plate
        /// </summary>
        public PlateType Type { get; set; }
    }
}
