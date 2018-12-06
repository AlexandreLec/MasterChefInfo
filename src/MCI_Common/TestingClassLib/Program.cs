using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCI_Common;
using MCI_Common.Devices;
using MCI_Common.Recipes;
using MCI_Common.RoomMaterials;

namespace TestingClassLib
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareProcess PlateManagement = new SquareProcess();

            Console.WriteLine(PlateManagement.GetAll()[0].Tables[0].Capacity);
            
            Console.Read();
        }
    }
}