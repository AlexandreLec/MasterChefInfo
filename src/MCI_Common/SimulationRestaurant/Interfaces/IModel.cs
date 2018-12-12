using MCI_Common.RoomMaterials;
using Room.Model.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationRestaurant.Interfaces
{
    public interface IModel
    {
        List<Table> ListTables { get; }

        List<ClientGroup> Clients { get;  }
    }
}
