using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD37.Entities.Resources
{
    public class Resource : Entity
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void HandleCollision(Entity otherEntity)
        {
            base.HandleCollision(otherEntity);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height), null, SpriteColor, RotationInDegrees, new Vector2(0, 0), SpriteEffects.None, 0);
        }
    }
}
