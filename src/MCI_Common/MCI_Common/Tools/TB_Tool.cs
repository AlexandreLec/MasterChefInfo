using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Tools
{
    class TB_Tool
    {
        /// <summary>
        /// Tool to use
        /// </summary>
        public Tool CurrentTool { get; set; }

        /// <summary>
        /// Name of the table in database
        /// </summary>
        private static string DataTable = "Ustensile";

        /// <summary>
        /// Get all rows in table
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetAll()
        {
            return "SELECT * FROM " + DataTable + ";";
        }

        /// <summary>
        /// Get a device by Id
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetById()
        {
            return "SELECT * FROM " + DataTable + " WHERE Id = " + CurrentTool.Id + ";";
        }

        /// <summary>
        /// Get a device by Name
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetByName()
        {
            return "SELECT * FROM " + DataTable + " WHERE Nom = '" + CurrentTool.Name + "';";
        }
    }
}
