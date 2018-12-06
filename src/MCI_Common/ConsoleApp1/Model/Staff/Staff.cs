using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Staff
{
    class Staff
    {
        /// <summary>
        /// Name of the staff
        /// </summary>
        private string Name;

        /// <summary>
        /// ID of the staff
        /// </summary>
        private int Id;

        /// <summary>
        /// Position of the staff
        /// </summary>
        //private Position Pos;

        /// <summary>
        /// Movement of the staff
        /// </summary>
        private IMovable MoveBehaviour;

        /// <summary>
        /// Availability of the staff
        /// </summary>
        private Boolean Available;

        /// <summary>
        /// Type of staff
        /// </summary>
        //private StaffType Type;

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
