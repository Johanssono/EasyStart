using EasyMonoGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyStart
{
    internal class Lizard : Actor
    {
        private float speed = 500;
        private Random random = new Random();
        private int score = 0;

        private bool isDead = false;

        private void Showscore()
        {
            this.World.ShowText(
                "Score: " + score, 100, 910);
        }


        public bool IsDead
        {
            get
            {
                return isDead;
            }
        }


        public override void Update(GameTime gameTime)
        {
            Showscore();
            Move((float)gameTime.ElapsedGameTime.TotalSeconds * speed);
            if (isDead) return;

            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W) && Y >= 0)
            {
                Rotation = 270f;
            }
            else if (keyboardState.IsKeyDown(Keys.S) && Y <= 1250)
            {
                Rotation = 90f;
            }
            else if (keyboardState.IsKeyDown(Keys.A) && X >= 0)
            {

                Rotation = 180f;
            }
            else if (keyboardState.IsKeyDown(Keys.D) && X <= 1250)
            {
                Rotation = 0f;
            }





            Actor pumpkin = GetOneIntersectingActor(typeof(Pumpkin));
            Actor heart = GetOneIntersectingActor(typeof(Heart));
            if (IsTouching(typeof(Pumpkin)))
            {
                //RemoveTouching(typeof(Pumpkin));

                pumpkin.Position = new Vector2(30, 30);
                if (pumpkin.IsTouching(typeof(Heart)))
                {
                    pumpkin.Position = new Vector2(random.Next(1200), random.Next(900));
                    score += 1;
                    Showscore();
                }

            }

            Actor snake = GetOneIntersectingActor(typeof(Snake));
            if (IsTouching(typeof(Snake)))
            {

                snake.Position = new Vector2(random.Next(1250, 2000), random.Next(950, 2000));

                // ta bort ett hjärta
                List<Actor> hearts = World.GetActors(typeof(Heart));
      
                if (hearts != null)
                {
                    Actor lastHeart = hearts[hearts.Count - 1];
                    World.RemoveActor(lastHeart);
                }
                
                else
                {
                    World.ShowText("Game Over", 1250 / 2, 950 / 2);
                    isDead = true;
                }
                
            }

        }
    }
}


// ett spel där det hela tiden finns 15 pumpor på skärmen
//efter att spelaren tagit 15 pumpor spawnar en fiende
//fienden studsar randomly mot väggarna
//varge gång spelaren tagit ett nytt "sätt" av 15 pumpor, spawnar yterligare en fiende
//om spelaren koliderar med en fiende ska spelaren förlora 1 av 3 liv och fienden försvinner
//varge pumpa ska ge poäng
//eventuellt göra så att spelaren kan warpa som i pacman



//fixa så att det är en 5 sekunder delay mellan att man dör och spelet börjar om
//fixa en counter
//fixa så att ormen spwanar på en random possition utanför skärmen men rimligt nära
//fixa så att ormen spawnar om vid 15 pumpor men att antalet ormar ökar med 1 och blir snabbare
