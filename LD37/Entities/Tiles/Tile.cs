﻿using CoreGame.Graphics;
using LD37.Entities.Machines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LD37.Entities
{
    public class Tile : Entity
    {
        public Machine Building { get; set; }
        Animation belt;

        public override void Initialize()
        {
            spriteName = "TransportBelt";
            base.Initialize();
        }

        //Loads the sprite
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            belt = new Animation(sprite, 64, 64, 3, 100, true);
        }

        public override void Update(GameTime gameTime)
        {
            belt.Update(gameTime, position);
            base.Update(gameTime);
        }

        //Draws the sprite at its position
        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(sprite, position);
            belt.Draw(spriteBatch);
        }

    }
}
