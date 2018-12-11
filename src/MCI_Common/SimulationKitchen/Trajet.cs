using MCI_Common.Behaviour;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationKitchen
{
    class Trajet
    {
        public void Deplacer()
        {
            while (Movable.Position.posX != posX)
            {
                Position.posX += 1;
                base.Update(GameTime);
            }
        else 
        {
                Position.posX -= -1;
                base.Update(gameTime);
            }
            while (Position.posY != posY)
            {
                Position.posY += 1;
                base.Update(gameTime);
            }
        else
        {
                Position.posY -= -1;
                base.Update(gameTime);
            }
        }
        
}
    