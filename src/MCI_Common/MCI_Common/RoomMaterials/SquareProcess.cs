using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.RoomMaterials
{
    public class SquareProcess
    {
        /// <summary>
        /// Table mapped for build request SQL
        /// </summary>
        public TB_Square MapTableSquare { get; set; }

        /// <summary>
        /// Table mapped for build request SQL
        /// </summary>
        public TB_Table MapTableTable { get; set; }

        /// <summary>
        /// BDD connection object
        /// </summary>
        public DAO Bdd { get; set; }

        /// <summary>
        /// SQL request
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// DataSet to get request results
        /// </summary>
        public DataSet DatasTable { get; set; }

        /// <summary>
        /// DataSet to get request results
        /// </summary>
        public DataSet DatasSquare { get; set; }

        /// <summary>
        /// Create squareProcess table
        /// </summary>
        public SquareProcess()
        {
            this.MapTableSquare = new TB_Square();
            this.MapTableTable = new TB_Table();
            this.DatasSquare = new DataSet();
            this.DatasTable = new DataSet();
            this.Bdd = DAO.getInstance();
        }

        private Table CreateTable(DataRow row)
        {
            Table table = new Table();
            table.Id = int.Parse(row["id"].ToString());
            table.Numero = int.Parse(row["Numero"].ToString());
            table.Capacity = int.Parse(row["Capacite"].ToString());
            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Square CreateSquare(DataRow row)
        {
            Square square = new Square();
            square.Id = int.Parse(row["id"].ToString());
            square.Tables = this.GetTables(square.Id);
            return square;
        }

        /// <summary>
        /// Get all the square of the room
        /// </summary>
        /// <returns></returns>
        public List<Square> GetAll()
        {
            this.DatasSquare.Clear();
            this.Request = this.MapTableSquare.GetAll();
            this.DatasSquare = this.Bdd.getRows(this.Request, "Square");

            List<Square> results = new List<Square>();

            foreach (DataRow item in this.DatasSquare.Tables["Square"].Rows)
            {
                Square square = this.CreateSquare(item);
                results.Add(square);
            }

            return results;
        }

        /// <summary>
        /// Get all the table of a square
        /// </summary>
        /// <returns></returns>
        private List<Table> GetTables(int idSquare)
        {
            this.DatasTable = new DataSet();
            this.Request = this.MapTableTable.GetAll(idSquare);
            this.DatasTable = this.Bdd.getRows(this.Request, "Tables");

            List<Table> results = new List<Table>();

            foreach (DataRow item in this.DatasTable.Tables["Tables"].Rows)
            {
                Table table = this.CreateTable(item);
                results.Add(table);
            }

            return results;
        }

    }
}
