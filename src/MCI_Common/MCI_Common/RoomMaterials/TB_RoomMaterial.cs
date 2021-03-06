﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.RoomMaterials
{
    public abstract class TB_RoomMaterial
    {
        /// <summary>
        /// RoomMaterial to use
        /// </summary>
        public RoomMaterial CurrentRoomMaterial { get; set; }

        /// <summary>
        /// Name of the table in database
        /// </summary>
        public string DataTable { get; set; }

        /// <summary>
        /// Get all rows in table
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetAll()
        {
            return "SELECT * FROM " + DataTable + ";";
        }

        /// <summary>
        /// Get materials by type
        /// </summary>
        /// <returns>SQL request</returns>
        abstract public string GetByType(int idType);
    }
}
