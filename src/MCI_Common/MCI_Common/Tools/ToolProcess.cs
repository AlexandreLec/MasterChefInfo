using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Tools
{
    class ToolProcess
    {
        /// <summary>
        /// Table mapped for build request SQL
        /// </summary>
        public TB_Tool MapTable { get; private set; }

        /// <summary>
        /// BDD connection object
        /// </summary>
        public DAO Bdd { get; private set; }

        /// <summary>
        /// SQL request
        /// </summary>
        public string Request { get; private set; }

        /// <summary>
        /// DataSet to get request results
        /// </summary>
        public DataSet Datas { get; private set; }

        /// <summary>
        /// Create a device process class
        /// </summary>
        public ToolProcess()
        {
            this.MapTable = new TB_Tool();
            this.Datas = new DataSet();
            this.Bdd = DAO.getInstance();
        }

        /// <summary>
        /// List all tools available in database
        /// </summary>
        /// <returns>A list of all tools</returns>
        public List<Tool> ListAllTools()
        {
            this.Datas.Clear();
            this.Request = this.MapTable.GetAll();
            this.Datas = this.Bdd.getRows(this.Request, "Tools");

            List<Tool> results = new List<Tool>();

            foreach (DataRow item in this.Datas.Tables["Tools"].Rows)
            {
                Tool device = new Tool();
                device.Name = item["Nom"].ToString();
                device.Quantity = int.Parse(item["Quantite"].ToString());
                device.Id = int.Parse(item["Id"].ToString());
                device.WashingTime = int.Parse(item["TempsNettoyage"].ToString());

                results.Add(device);
            }

            return results;
        }

        /// <summary>
        /// Get a specific tool
        /// </summary>
        /// <param name="id">id of the tool to get</param>
        /// <returns>A specific tool</returns>
        public Tool GetOneTool(int id)
        {
            this.Datas.Clear();
            this.MapTable.CurrentTool = new Tool();
            this.MapTable.CurrentTool.Id = id;
            this.Request = this.MapTable.GetById();
            this.Datas = this.Bdd.getRows(this.Request, "Devices");

            Tool result = new Tool();

            foreach (DataRow item in this.Datas.Tables["Devices"].Rows)
            {
                result.Name = item["Nom"].ToString();
                result.Quantity = int.Parse(item["Quantite"].ToString());
                result.Id = int.Parse(item["Id"].ToString());
                result.WashingTime = int.Parse(item["TempsNettoyage"].ToString());
            }

            return result;
        }

        /// <summary>
        /// Get a specific tool
        /// </summary>
        /// <param name="name">Name of the device to get</param>
        /// <returns>A specific device</returns>
        public Device GetOneDevice(string name)
        {
            this.Datas.Clear();
            this.MapTable.CurrentDevice = new Device();
            this.MapTable.CurrentDevice.Name = name;
            this.Request = this.MapTable.GetByName();
            this.Datas = this.Bdd.getRows(this.Request, "Devices");

            Device result = new Device();

            foreach (DataRow item in this.Datas.Tables["Devices"].Rows)
            {
                result.Name = item["Nom"].ToString();
                result.Quantity = int.Parse(item["Quantite"].ToString());
                result.Id = int.Parse(item["Id"].ToString());
                result.Capacity = int.Parse(item["Capacite"].ToString());
            }

            return result;
        }
    }
}
