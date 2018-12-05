using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Devices
{
    public class DeviceProcess
    {
        /// <summary>
        /// Table mapped for build request SQL
        /// </summary>
        public TB_Device MapTable { get; private set; }

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
        public DeviceProcess()
        {
            this.MapTable = new TB_Device();
            this.Datas = new DataSet();
            this.Bdd = DAO.getInstance();
        }

        /// <summary>
        /// List all devices available in database
        /// </summary>
        /// <returns>A list of all devices</returns>
        public List<Device> ListAllDevices()
        {
            this.Datas.Clear();
            this.Request = this.MapTable.GetAll();
            this.Datas = this.Bdd.getRows(this.Request, "Devices");

            List<Device> results = new List<Device>();

            foreach (DataRow item in this.Datas.Tables["Devices"].Rows)
            {
                Device device = new Device();
                device.Name = item["Nom"].ToString();
                device.Quantity = int.Parse(item["Quantite"].ToString());
                device.Id = int.Parse(item["Id"].ToString());
                device.Capacity = int.Parse(item["Capacite"].ToString());

                results.Add(device);
            }

            return results;
        }

        /// <summary>
        /// Get a specific device
        /// </summary>
        /// <param name="id">id of the device to get</param>
        /// <returns>A specific device</returns>
        public Device GetOneDevice(int id)
        {
            this.Datas.Clear();
            this.MapTable.CurrentDevice = new Device();
            this.MapTable.CurrentDevice.Id = id;
            this.Request = this.MapTable.GetById();
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

        /// <summary>
        /// Get a specific device
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
