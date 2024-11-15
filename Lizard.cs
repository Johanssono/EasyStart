using EasyMonoGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStart
{
    internal class Lizard : Actor
    {
        private float speed;


        public Lizard(float speed = 500f)
        {
            this.speed = speed;


        }
        public override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W) && Y >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.A) && X >= 0)
                {
                    Y -= (speed) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    X -= (speed / 2) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Rotation = 180 + 45f;
                }
                else if (keyboardState.IsKeyDown(Keys.D) && X <= 800)
                {
                    Y -= (speed) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    X += (speed) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Rotation = 270 + 45f;
                }
                else
                {
                    Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Rotation = 270f;
                }
            }
            else if (keyboardState.IsKeyDown(Keys.S) && Y <= 480)
            {
                if (keyboardState.IsKeyDown(Keys.A) && X >= 0)
                {
                    Y += (speed) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    X -= (speed) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Rotation = 90 + 45f;
                }
                else if (keyboardState.IsKeyDown(Keys.D) && X <= 800)
                {
                    Y += (speed) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    X += (speed) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Rotation = 90 / 2f;
                }
                else
                {
                    Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Rotation = 90f;
                }
            }
            else if (keyboardState.IsKeyDown(Keys.A) && X >= 0)
            {
                X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Rotation = 180f;
            }
            else if (keyboardState.IsKeyDown(Keys.D) && X <= 800)
            {
                X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Rotation = 0f;
            }
            Actor pumpkin = GetOneIntersectingActor(typeof(Pumpkin));
            if (pumpkin != null) 
            {
                //hantera kollision

            }
        }
    }
    }

