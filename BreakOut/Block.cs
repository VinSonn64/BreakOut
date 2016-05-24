using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BreakOutMidterm
{
    class Block : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Texture2D blockTexture;
        public Vector2 blockLoc;

           public Block(Game game) : base(game)
        {

        }


        protected override void LoadContent()
        {
            blockLoc = new Vector2(0, 20);
            blockTexture = this.Game.Content.Load<Texture2D>("block_yellow");
            base.LoadContent();
        }
    }
}
