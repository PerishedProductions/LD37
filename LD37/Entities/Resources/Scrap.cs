using Microsoft.Xna.Framework;

namespace LD37.Entities.Resources
{
    public class Scrap : Resource
    {
        public const int ScrapPrice = 50;

        public override int Price
        {
            get
            {
                return ScrapPrice;
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
