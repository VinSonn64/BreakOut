using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BreakOutMidterm
{
    public class Player : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Texture2D playerTexture;
        public Texture2D lifeTexture;
        public Vector2 playerLoc;
        public Vector2 playerDir;
        float playerSpeed;

        public Vector2 playerlife1;
        public Vector2 playerlife2;
        public Vector2 playerlife3;

        public Player(Game game) : base(game)
        {

        }

        protected override void LoadContent()
        {
            playerTexture = this.Game.Content.Load<Texture2D>("paddleBiger");

            lifeTexture = this.Game.Content.Load<Texture2D>("paddleSmall");
            playerLoc = new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 50, 400);
            playerlife1 = new Vector2(0, 450);
            playerlife2 = new Vector2(100, 450);
            playerlife3 = new Vector2(200, 450);
            playerDir = new Vector2(0, 0);
            playerSpeed = 20;
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            //moving object
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            
            playerLoc = playerLoc + ((playerDir * playerSpeed) * (time / 1000));

            HandleInput();
            base.Update(gameTime);
        }


        private void HandleInput()
        
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
               
                playerDir += new Vector2(-1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
             
                playerDir += new Vector2(1, 0);
            }

            if (Keyboard.GetState().GetPressedKeys().Length == 0)
            {
                playerDir = playerDir - playerDir;
            }

            if (playerLoc.X < 0)
            {
                playerLoc.X = 0;
            }
            else if (playerLoc.X > this.Game.GraphicsDevice.Viewport.Width - playerTexture.Width)
            {
                playerLoc.X = this.Game.GraphicsDevice.Viewport.Width - playerTexture.Width;
            }
        }
        
    }
}
