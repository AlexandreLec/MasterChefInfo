using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room.Model.Behaviour
{
    public class Position
    {
        public int posX { get; set; }

        public int posY { get; set; }


        public Position(int x, int y)
        {
            posX = x;
            posY = y;
        }
    }
}
