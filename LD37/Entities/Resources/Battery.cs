using Microsoft.Xna.Framework;

namespace LD37.Entities.Resources
{
    public class Battery : Resource
    {
        public const int BatteryPrice = 200;

        public override int Price
        {
            get
            {
                return BatteryPrice;
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
