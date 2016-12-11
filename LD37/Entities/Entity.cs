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

        public bool Active { get; set; } = true;
        public float RotationInDegrees { get; set; }
        public Color SpriteColor { get; set; } = Color.White;
        protected Vector2 _origin;

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

        public virtual bool CheckCollision(Entity otherEntity)
        {
            return this.BoundingBox.Intersects(otherEntity.BoundingBox);
        }

        public virtual void HandleCollision(Entity otherEntity) { }

        public virtual void Initialize() { }

        //Loads the sprite
        public virtual void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
            _origin = new Vector2(sprite.Width / 2, sprite.Height / 2);

        }

        public virtual void Update(GameTime gameTime) { }

        //Draws the sprite at its position
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            float rotationInRadians = MathHelper.ToRadians(RotationInDegrees);

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height), null, SpriteColor, rotationInRadians, new Vector2(0, 0), SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}