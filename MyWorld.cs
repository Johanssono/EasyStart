using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;
using Microsoft.Xna.Framework;

namespace EasyStart
{
    internal class MyWorld : World
    {
        private Random random = new Random();
        private Lizard my_lizard;


        public MyWorld() : base(1250, 950)
        {
            GameArt.Add("bluerock");
            GameArt.Add("lizard2");
            GameArt.Add("pumpkin");
            GameArt.Add("herz");

            BackgroundTileName = "bluerock";

            my_lizard = new Lizard();
            Add(my_lizard, "lizard2", 1250 / 2, 950 / 2);
            //måste fixa så ormen kan spwna på random ställen utanför fönstret


            for (int i = 0; i < 3; i++)
            {
                Add(new Heart(), "herz", 40 + (i * 60), 40);

            }

            for (int i = 0; i < 1; i++)
            {
                Add(new Snake(my_lizard), "snake", random.Next(1250, 2000), random.Next(950, 2000));
            }

            for (int i = 0; i < 1; i++)
            {
                Add(new Pumpkin(), "pumpkin", random.Next(1200), random.Next(900));

            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (my_lizard.IsDead)
            {
                MyWorld world = new MyWorld();
                EasyGame.Instance.ActiveWorld = world;
            }
        }

    }
}

