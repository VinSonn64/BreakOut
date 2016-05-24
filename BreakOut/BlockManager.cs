using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BreakOutMidterm
{
    class BlockManager : Microsoft.Xna.Framework.DrawableGameComponent
    {

        public Texture2D blockTexture;
        public Vector2 blockLoc;

        public Vector2[] blockLocs;
        float newLoc;
          public BlockManager(Game game) : base(game)
        {
            
        }


        protected override void LoadContent()
        {
            blockLoc = new Vector2(20,20);
            blockTexture = this.Game.Content.Load<Texture2D>("block_yellow");
            blockLocs = new Vector2[20];
            newLoc = blockTexture.Width;
           for (int i = 0; i < blockLocs.Count(); i++, newLoc+=blockTexture.Width)
            {
                blockLocs[i] = new Vector2(50+ newLoc, 50);
            }
            base.LoadContent();
        }

     
        public override void Update(GameTime gameTime)
        {
            

            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            base.Update(gameTime);
        }



    }
}
