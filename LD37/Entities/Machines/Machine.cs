using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD37.Entities.Machines
{
    public class Machine : Entity
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
            spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height), null, SpriteColor, RotationInDegrees, _origin, SpriteEffects.None, 0);
        }
    }
}
