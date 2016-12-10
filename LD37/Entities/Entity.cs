using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LD37.Entities
{
    public class Entity
    {
        public String name;
        public Vector2 position;
        public Texture2D sprite;

        public String spriteName;

        public virtual Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    sprite.Width,
                    sprite.Height);
            }
        }

        public virtual void Initialize() { }

        //Loads the sprite
        public virtual void LoadContent(ContentManager content)
        {

        }

        public virtual void Update(GameTime gameTime) { }

        //Draws the sprite at its position
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position);
            spriteBatch.End();
        }
    }
}