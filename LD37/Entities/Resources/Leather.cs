using Microsoft.Xna.Framework;

namespace LD37.Entities.Resources
{
    public class Leather : Resource
    {
        public const int LeatherPrice = 150;

        public override int Price
        {
            get
            {
                return LeatherPrice;
            }
        }


        public override void Update(GameTime gameTime)
        {

        }

        public override void HandleCollision(Entity otherEntity)
        {

        }
    }
}
