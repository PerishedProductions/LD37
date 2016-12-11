using LD37.Entities.Resources;
using LD37.Managers;
using Microsoft.Xna.Framework;
using static LD37.Managers.ConstructionManager;

namespace LD37.Entities.Machines
{
    public class TransportBelt : Machine
    {
        public float BeltSpeed { get; set; } = 0.1f;
        public BuildingDirection BeltDirection { get; set; }

        public override void Update(GameTime gameTime)
        {

        }

        public override void HandleCollision(Entity otherEntity)
        {
            if (otherEntity is Resource)
            {
                switch (BeltDirection)
                {
                    case ConstructionManager.BuildingDirection.UP:
                        otherEntity.position -= new Vector2(0, BeltSpeed);
                        break;
                    case ConstructionManager.BuildingDirection.LEFT:
                        otherEntity.position -= new Vector2(BeltSpeed, 0);
                        break;
                    case ConstructionManager.BuildingDirection.RIGHT:
                        otherEntity.position += new Vector2(BeltSpeed, 0);
                        break;
                    case ConstructionManager.BuildingDirection.DOWN:
                        otherEntity.position += new Vector2(0, BeltSpeed);
                        break;
                    default:
                        break;
                }
            }
            else
            {

            }

        }
    }
}
