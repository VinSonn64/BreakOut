using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BreakOutMidterm
{
    //Note************************
    //THIS IS THE SCOREMANAGER//////////////
    //**************************************************
    class Collision : Microsoft.Xna.Framework.DrawableGameComponent
    {

        int Score;
        int lives;
        SpriteBatch spritebatch;
        Player player;
        Ball ball;
        BlockManager bm;
        Rectangle ballbounds;
        Rectangle playerbounds;
        Rectangle[] blockBounds;
        SpriteFont myFont;

        public Collision(Game game, BlockManager bm, Player player, Ball ball)
            : base(game)
        {
            this.bm = bm;
            this.player = player;
            this.ball = ball;
        }

        protected override void LoadContent()
        {
            Score = 0;
            lives = 3;
            myFont = this.Game.Content.Load<SpriteFont>("myfont");
            blockBounds = new Rectangle[20];
            spritebatch = new SpriteBatch(GraphicsDevice);
            for (int i = 0; i < bm.blockLocs.Count(); i++)
            {
                blockBounds[i] = new Rectangle((int)bm.blockLocs[i].X, (int)bm.blockLocs[i].Y, (int)bm.blockTexture.Width, (int)bm.blockTexture.Height);
            }
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            playerbounds = new Rectangle((int)player.playerLoc.X, (int)player.playerLoc.Y, (int)player.playerTexture.Width, (int)player.playerTexture.Height);
            ballbounds = new Rectangle((int)ball.ballLoc.X, (int)ball.ballLoc.Y, (int)ball.ballTexture.Width, (int)ball.ballTexture.Height);
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (ball.ballLoc.Y > Game.GraphicsDevice.Viewport.Height - (ball.ballTexture.Height / 2))
            {
                lives--;
                ball.ballLoc.Y = Game.GraphicsDevice.Viewport.Height / 2;
            }

            if(ballbounds.Intersects(playerbounds))
            {
                ball.ballDir.Y = -ball.ballDir.Y;
                 //Influence ball with Paddle
            }
            for (int i = 0; i < bm.blockLocs.Count(); i++)
            {
                if (ballbounds.Intersects(blockBounds[i]))
                {
                    bm.blockLocs[i].Y = -100;
                    blockBounds[i].Y = -100;
                    ball.ballDir.Y = -ball.ballDir.Y;
                    Score++;

                }
            }

            switch (lives)
            {
                case 2: player.playerlife1.Y = -100;

                    break;
                case 1: player.playerlife2.Y = -100;

                    break;
                case 0: player.playerlife3.Y = -100;
                    ball.ballLoc.Y = 100;
                    break;
            }
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

            if (itemLoc.Y > Game.GraphicsDevice.Viewport.Height - (itemTexture.Height / 2))
                itemLoc.Y = Game.GraphicsDevice.Viewport.Height/2;

            if (itemLoc.Y < (itemTexture.Height / 2))
                itemDir.Y = -itemDir.Y;
            //////////////////////////////////////
            return itemDir;
        }


        public override void Draw(GameTime gameTime)
        {
            spritebatch.Begin();
            spritebatch.Draw(player.playerTexture, player.playerLoc, Color.White);
            spritebatch.Draw(player.lifeTexture, player.playerlife1, Color.White);
            spritebatch.Draw(player.lifeTexture, player.playerlife2, Color.White);
            spritebatch.Draw(player.lifeTexture, player.playerlife3, Color.White);
            spritebatch.Draw(ball.ballTexture, ball.ballLoc, Color.White);

            for (int i = 0; i < bm.blockLocs.Count(); i++)
            {
                spritebatch.Draw(bm.blockTexture, bm.blockLocs[i], Color.White);
            }
            spritebatch.DrawString(myFont, "Score: " + Score.ToString(), new Vector2(200, 400), Color.White);
                if(Score==20)
                {
                    spritebatch.DrawString(myFont, "No more Blocks Winner ", new Vector2(200, 430), Color.White);
                    ball.ballLoc.Y = 100;
                }
            if(lives==0)
            {
                spritebatch.DrawString(myFont, "No more lives Loser ", new Vector2(200, 430), Color.White);
            }
            
                spritebatch.End();
        }  
    }
}
