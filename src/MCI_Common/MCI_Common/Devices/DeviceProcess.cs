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
        /// Build a device from datarow
        /// </summary>
        /// <param name="row">DataRow from dataset</param>
        /// <returns>a device</returns>
        private Device CreateDevice(DataRow row)
        {
            Device device = new Device();
            device.Name = row["Nom"].ToString();
            device.Quantity = int.Parse(row["Quantite"].ToString());
            device.Id = int.Parse(row["Id"].ToString());
            device.Capacity = int.Parse(row["Capacite"].ToString());
            return device;
        }

        /// <summary>
        /// List all devices available in database
        /// </summary>
        /// <returns>A list of all devices</returns>
        public List<Device> ListAll()
        {
            this.Datas.Clear();
            this.Request = this.MapTable.GetAll();
            this.Datas = this.Bdd.getRows(this.Request, "Devices");

            List<Device> results = new List<Device>();

            foreach (DataRow item in this.Datas.Tables["Devices"].Rows)
            {
                Device device = this.CreateDevice(item);

                results.Add(device);
            }

            return results;
        }

        /// <summary>
        /// Get a specific devices list for a step
        /// </summary>
        /// <param name="id">id of the step</param>
        /// <returns>A specific devices list</returns>
        public List<Device> ListAllByStep(int id)
        {
            this.Datas.Clear();
            this.Request = this.MapTable.GetAllByStep(id);
            this.Datas = this.Bdd.getRows(this.Request, "Device");

            List<Device> results = new List<Device>();

            foreach (DataRow item in this.Datas.Tables["Device"].Rows)
            {
                Device device = this.CreateDevice(item);
                results.Add(device);
            }

            return results;
        }

        /// <summary>
        /// Get a specific device
        /// </summary>
        /// <param name="id">id of the device to get</param>
        /// <returns>A specific device</returns>
        public Device GetOne(int id)
        {
            this.Datas.Clear();
            this.MapTable.CurrentDevice = new Device();
            this.MapTable.CurrentDevice.Id = id;
            this.Request = this.MapTable.GetById();
            this.Datas = this.Bdd.getRows(this.Request, "Devices");

            Device result = this.CreateDevice(this.Datas.Tables["Devices"].Rows[0]);

            return result;
        }

        /// <summary>
        /// Get a specific device
        /// </summary>
        /// <param name="name">Name of the device to get</param>
        /// <returns>A specific device</returns>
        public Device GetOne(string name)
        {
            this.Datas.Clear();
            this.MapTable.CurrentDevice = new Device();
            this.MapTable.CurrentDevice.Name = name;
            this.Request = this.MapTable.GetByName();
            this.Datas = this.Bdd.getRows(this.Request, "Devices");

            Device result = this.CreateDevice(this.Datas.Tables["Devices"].Rows[0]);

            return result;
        }
    }
}
