using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Staff
{
    public class Staff
    {
        /// <summary>
        /// Name of the staff
        /// </summary>
        private string Name { get; set; }

        /// <summary>
        /// ID of the staff
        /// </summary>
        private int Id { get; set; }

        /// <summary>
        /// Position of the staff
        /// </summary>
        //private Position Pos { get; set; }

        /// <summary>
        /// Movement of the staff
        /// </summary>
        private IMovable MoveBehaviour;

        /// <summary>
        /// Availability of the staff
        /// </summary>
        private bool Available { get; set; }

        /// <summary>
        /// Type of staff
        /// </summary>
        //private StaffType Type { get; set; }

        /// <summary>
        /// Move to a position
        /// </summary>
        /// <param name="pos"></param>
        /* public void MoveTo(Position pos)
        {
            
        }
        */
    }
}
