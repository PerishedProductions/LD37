using LD37.Entities.Resources;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static LD37.Managers.ConstructionManager;

namespace LD37.Entities.Machines
{
    public class SortingMachine : Machine
    {
        Dictionary<Type, BuildingDirection> SortDirection = new Dictionary<Type, BuildingDirection>();

        public SortingMachine()
        {
            SortDirection.Add(typeof(Leather), BuildingDirection.UP);
            SortDirection.Add(typeof(Plastic), BuildingDirection.DOWN);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void HandleCollision(Entity otherEntity)
        {
            if (SortDirection.ContainsKey(otherEntity.GetType()))
            {
                switch (SortDirection[otherEntity.GetType()])
                {
                    case BuildingDirection.DOWN:
                        {
                            otherEntity.position = this.position + new Vector2(0, this.sprite.Height);
                            break;
                        }

                    case BuildingDirection.LEFT:
                        {
                            otherEntity.position = this.position - new Vector2(this.sprite.Width, 0);
                            break;
                        }

                    case BuildingDirection.RIGHT:
                        {
                            otherEntity.position = this.position + new Vector2(this.sprite.Width, 0);
                            break;
                        }

                    case BuildingDirection.UP:
                        {
                            otherEntity.position = this.position - new Vector2(0, this.sprite.Height);
                            break;
                        }

                    default:
                        {
                            otherEntity.position = this.position + new Vector2(this.sprite.Width, 0);
                            break;
                        }
                }
            }
            else
            {
                otherEntity.position = this.position + new Vector2(this.sprite.Width, 0);
            }
        }
    }
}
