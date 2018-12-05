using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Devices
{
    public class TB_Device
    {
        /// <summary>
        /// Device to use
        /// </summary>
        public Device CurrentDevice { get; set; }

        /// <summary>
        /// Name of the table in database
        /// </summary>
        private static string DataTable = "Appareil";

        /// <summary>
        /// Get all rows in table
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetAll()
        {
            return "SELECT * FROM "+DataTable+";";
        }

        /// <summary>
        /// Get a device by Id
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetById()
        {
            return "SELECT * FROM "+DataTable+" WHERE Id = "+CurrentDevice.Id+";";
        }

        /// <summary>
        /// Get a device by Name
        /// </summary>
        /// <returns>SQL request</returns>
        public string GetByName()
        {
            return "SELECT * FROM " + DataTable + " WHERE Nom = '" + CurrentDevice.Name + "';";
        }

    }
}
