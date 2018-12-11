using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Tools
{
    public class ToolProcess
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
        /// Build a tool from datarow
        /// </summary>
        /// <param name="row">DataRow from dataset</param>
        /// <returns>a tool</returns>
        private Tool CreateTool(DataRow row)
        {
            Tool tool = new Tool();
            tool.Name = row["Nom"].ToString();
            tool.Quantity = int.Parse(row["Quantite"].ToString());
            tool.Id = int.Parse(row["Id"].ToString());
            tool.WashingTime = float.Parse(row["TempsNettoyage"].ToString());

            return tool;
        }

        /// <summary>
        /// List all tools available in database
        /// </summary>
        /// <returns>A list of all tools</returns>
        public List<Tool> ListAll()
        {
            this.Datas.Clear();
            this.Request = this.MapTable.GetAll();
            this.Datas = this.Bdd.getRows(this.Request, "Tools").Copy();

            List<Tool> results = new List<Tool>();

            foreach (DataRow item in this.Datas.Tables["Tools"].Rows)
            {
                Tool tool = this.CreateTool(item);
                results.Add(tool);
                
            }
            Console.WriteLine(results);
            return results;
        }

        /// <summary>
        /// Get a specific tools list for a step
        /// </summary>
        /// <param name="id">id of the step</param>
        /// <returns>A specific tool list</returns>
        public List<Tool> ListAllByStep(int id)
        {
            this.Datas.Clear();
            this.Request = this.MapTable.GetAllByStep(id);
            this.Datas = this.Bdd.getRows(this.Request, "Tools");

            List<Tool> results = new List<Tool>();

            foreach (DataRow item in this.Datas.Tables["Tools"].Rows)
            {
                Tool tool = this.CreateTool(item);
                results.Add(tool);
            }

            return results;
        }

        /// <summary>
        /// Get a specific tool
        /// </summary>
        /// <param name="name">Name of the tool to get</param>
        /// <returns>A specific tool</returns>
        public Tool GetOne(string name)
        {
            this.Datas.Clear();
            this.MapTable.CurrentTool = new Tool();
            this.MapTable.CurrentTool.Name = name;
            this.Request = this.MapTable.GetByName();
            this.Datas = this.Bdd.getRows(this.Request, "Tools");

            Tool result = this.CreateTool(this.Datas.Tables["Tools"].Rows[0]);

            return result;
        }
    }
}
