using Microsoft.Xna.Framework;

namespace LD37.Entities.Resources.Toys
{
    public class ToyRobot : Toy
    {
        public const int ToyRobotPrice = 500;

        public override int Price
        {
            get
            {
                return ToyRobotPrice;
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
