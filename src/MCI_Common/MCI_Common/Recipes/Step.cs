using MCI_Common.Devices;
using MCI_Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Recipes
{
    class Step
    {
        /// <summary>
        /// ID of the step
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order in the recipe
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Time to finish the step
        /// </summary>
        public float Time { get; set; }

        /// <summary>
        /// Explanation of the step
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Tool(s) use by this step
        /// </summary>
        public List<Tool> Tools { get; set; }

        /// <summary>
        /// Device(s) use by this step
        /// </summary>
        public List<Device> Devices { get; set; }
    }
}
