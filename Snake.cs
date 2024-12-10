using EasyMonoGame;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStart
{
    internal class Snake : Actor
    {
        private Lizard lizard;
        
        public Snake(Lizard lizard)
        {
            this.lizard = lizard;
        }

        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            TurnTowards(lizard.X, lizard.Y);
            Move(250 *  deltaTime);
        }
    }
}
