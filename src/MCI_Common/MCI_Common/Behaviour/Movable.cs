using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Behaviour
{
    public abstract class Movable
    {
        public Position Position { get; set; }

        public event EventHandler MoveEvent;

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
                this.Position.posX = x;
                this.Position.posY = y;
            }
            this.OnMoveEvent(EventArgs.Empty);

        }

        /*public void MoveTo(Position position)
        {
            // check if map coordinates are in range
            while (position.posX != )
            {
                position.posX += +1;
                position.posX -= -1;
            }        
                            
            while(position.posY != position.posY)
            {
                position.posY += +1;
                position.posY -= -1;
            }          
         this.OnMoveEvent(EventArgs.Empty);

        } */


        /// <summary>
        /// Move sprite according to vector along X and Y axis
        /// (can be negative or positive)
        /// </summary>
        /// <param name="vectorX"></param>
        /// <param name="vectorY"></param>
        public void Move(int vectorX, int vectorY)
        {
            this.Position.posX += vectorX;
            this.Position.posY += vectorY;
        }

        protected virtual void OnMoveEvent(EventArgs e)
        {
            MoveEvent?.Invoke(this, e);
        }
    }
}
