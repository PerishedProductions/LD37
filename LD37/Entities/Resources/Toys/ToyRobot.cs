using Microsoft.Xna.Framework;

namespace LD37.Entities.Resources.Toys
{
    public class ToyRobot : Toy
    {
        private int _price = 500;

        public override int Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
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
