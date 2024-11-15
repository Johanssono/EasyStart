using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;

namespace EasyStart
{
    internal class MyWorld : World
    {
        private Random random = new Random();
        public MyWorld() : base(600, 800)
        {
            GameArt.Add("bluerock");
            GameArt.Add("lizard2");
            GameArt.Add("pumpkin");

            BackgroundTileName = "bluerock";

            Add(new Lizard(), "lizard2", 300, 400);

            for (int i = 0; i < 15; i++)
            {
                Add(new Pumpkin(), "pumpkin", random.Next(800), random.Next(600));
            }
        }  
    }
}
