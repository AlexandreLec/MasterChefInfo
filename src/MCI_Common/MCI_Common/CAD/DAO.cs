using System;
using System.Data;
using System.Data.SqlClient;

namespace MCI_Common
{
    public class DAO
    {
        /// <summary>
        /// DAO Instance
        /// </summary>
        private static DAO daoObj;

        /// <summary>
        /// Connection string to database
        /// </summary>
        private string cnx;
        
        /// <summary>
        /// SQL Instructions
        /// </summary>
        private string sqlRequest;

        /// <summary>
        /// Data adapter
        /// </summary>
        private SqlDataAdapter adapter;

        /// <summary>
        /// Connection object
        /// </summary>
        private SqlConnection bddConnexion;

        /// <summary>
        /// Sql command object
        /// </summary>
        private SqlCommand cmd;

        /// <summary>
        /// Dataset object to store request's results
        /// </summary>
        private DataSet data;

        /// <summary>
        /// Instantiate the DAO database connection object
        /// </summary>
        private DAO()
        {
            this.cnx = @"Data Source=lecomte-net.synology.me;Initial Catalog=masterchef;User ID=masterchef;Password=exia";
            this.bddConnexion = new SqlConnection(this.cnx);
            this.adapter = new SqlDataAdapter();
            this.cmd = new SqlCommand();
            this.data = new DataSet();
        }

        /// <summary>
        /// Get the instance of the DAO (databse connection)
        /// </summary>
        /// <returns>The instance of DAO</returns>
        public static DAO getInstance()
        {
            if (daoObj == null)
            {
                daoObj = new DAO();
            }
            return daoObj;
        }

        /// <summary>
        /// Send actions requests to Database. Modify database.
        /// </summary>
        /// <param name="request"></param>
        public void actionRows(string request)
        {
            this.cmd.CommandText = request;
            int lines = 0;
            try
            {
                this.bddConnexion.Open();
                lines = this.cmd.ExecuteNonQuery();
                Console.WriteLine("{0} lines updated", lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Query insert/update/delete not executed, stack trace\n" + ex.Message);
            }
            finally
            {
                this.bddConnexion.Close();
            }
        }

        /// <summary>
        /// Obtains rows, results of the SQL requets send
        /// </summary>
        /// <param name="request"></param>
        /// <param name="dataTableName">Name of the data table to fill in dataset</param>
        /// <returns>Dataset with results</returns>
        public DataSet getRows(string request, string dataTableName)
        {
            this.cmd.CommandText = request;
            adapter.SelectCommand = this.cmd;
            adapter.SelectCommand.Connection = this.bddConnexion;

            try
            {
                adapter.Fill(this.data, dataTableName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Query select not executed, stack trace\n" + ex.Message);
            }
            return this.data;
        }

    }
}
