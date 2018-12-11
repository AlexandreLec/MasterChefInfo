using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Behaviour
{
    public  class Movable
    {
        public Position position = new Position(0, 0);


        /// <summary>
        /// Moves to fixed position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveTo(int x, int y)
        {
            // check if map coordinates are in range
            if (x >= 0 && y >= 0)
            {
                position.posX = x;
                position.posY = y;
            }

        }

        /// <summary>
        /// Move sprite according to vector along X and Y axis
        /// (can be negative or positive)
        /// </summary>
        /// <param name="vectorX"></param>
        /// <param name="vectorY"></param>
        public void Move(int vectorX, int vectorY)
        {
            position.posX += vectorX;
            position.posY += vectorY;
        }
    }
}
