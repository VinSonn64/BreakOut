using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace BreakOutMidterm
{
    class Ball : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Texture2D ballTexture;
        public Vector2 ballLoc;
        public Vector2 ballDir;
        float ballSpeed;

        

         public Ball(Game game) : base(game)
        {

        }

        protected override void LoadContent()
        {
            ballTexture = this.Game.Content.Load<Texture2D>("ballSmall");
            ballLoc = new Vector2(Game.GraphicsDevice.Viewport.Width / 2, Game.GraphicsDevice.Viewport.Height / 2);
            ballDir = new Vector2(1,1);
            ballSpeed = 200;
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            //moving object
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            ballLoc = ballLoc + ((ballDir * ballSpeed) * (time / 1000));
            ballDir = WallBouce(ballTexture,ballLoc,ballDir);
            
            base.Update(gameTime);
        }

        Vector2 WallBouce(Texture2D itemTexture, Vector2 itemLoc, Vector2 itemDir)
        {
            ////Keep item on Screen
            if (itemLoc.X > Game.GraphicsDevice.Viewport.Width - (itemTexture.Width / 2))
            {
                itemDir.X = -itemDir.X;
            }
            if (itemLoc.X < (itemTexture.Width / 2))
                itemDir.X = -itemDir.X;

            //if (itemLoc.Y > Game.GraphicsDevice.Viewport.Height - (itemTexture.Height / 2))
            //    itemDir.Y = -itemDir.Y;
             
            if (itemLoc.Y < (itemTexture.Height / 2))
                itemDir.Y = -itemDir.Y;
            //////////////////////////////////////
            return itemDir;
        }


    }
}
