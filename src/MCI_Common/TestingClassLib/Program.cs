using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCI_Common;
using MCI_Common.Devices;

namespace TestingClassLib
{
    class Program
    {
        static void Main(string[] args)
        {
            DeviceProcess deviceManagement = new DeviceProcess();

            Console.WriteLine(deviceManagement.GetOneDevice("Four").Capacity);
            
            Console.Read();
        }
    }
}
