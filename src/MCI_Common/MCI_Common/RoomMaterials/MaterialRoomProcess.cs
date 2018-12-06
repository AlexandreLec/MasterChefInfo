using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.RoomMaterials
{
    public abstract class MaterialRoomProcess
    {
        /// <summary>
        /// Table mapped for build request SQL
        /// </summary>
        protected TB_RoomMaterial MapTable { get; set; }

        /// <summary>
        /// BDD connection object
        /// </summary>
        protected DAO Bdd { get; set; }

        /// <summary>
        /// SQL request
        /// </summary>
        protected string Request { get; set; }

        /// <summary>
        /// DataSet to get request results
        /// </summary>
        protected DataSet Datas { get; set; }

        public abstract List<RoomMaterial> GetAll();
    }
}
