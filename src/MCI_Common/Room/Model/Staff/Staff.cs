using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Staff
{
    abstract class Staff
    {
        /// <summary>
        /// Name of the staff
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID of the staff
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Position of the staff
        /// </summary>
        //private Behaviour.Position Pos { get; set; }

        /// <summary>
        /// Movement of the staff
        /// </summary>
        private IMovable MoveBehaviour;

        /// <summary>
        /// Availability of the staff
        /// </summary>
        public bool Available { get; set; }

        /* /// <summary>
        /// Move to a position
        /// </summary>
        /// <param name="pos"></param>
        public void MoveTo(Position pos)
        {
            
        } */

        public abstract void WhoAmI();
    }
}
