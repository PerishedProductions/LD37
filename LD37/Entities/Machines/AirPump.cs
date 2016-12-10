using LD37.Entities.Resources;
using LD37.Entities.Resources.Toys;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LD37.Entities.Machines
{
    public class AirPump : Machine
    {
        private ToyFactory toyFactory = ToyFactory.Instance;
        public List<Resource> ResourceList { get; set; } = new List<Resource>();
        public int ConstructionTime { get; set; } = 5000;
        protected int CurrentConstructionTime = 0;

        public override void Update(GameTime gameTime)
        {
            if (HasRequiredResource())
            {
                CurrentConstructionTime += gameTime.ElapsedGameTime.Milliseconds;

                if (CurrentConstructionTime >= ConstructionTime)
                {
                    FabricateSoccerBall();
                    CurrentConstructionTime = 0;
                }
            }
        }

        private void FabricateSoccerBall()
        {
            Leather leather = ResourceList.OfType<Leather>().FirstOrDefault();

            if (leather != null)
            {
                toyFactory.CreateSoccerBall(this.position + new Vector2(this.sprite.Width, 0));
                ResourceList.Remove(leather);
            }
        }

        private bool HasRequiredResource()
        {
            Leather leather = ResourceList.OfType<Leather>().FirstOrDefault();

            return leather != null;
        }

        public override void HandleCollision(Entity otherEntity)
        {
            if (otherEntity is Leather)
            {
                ResourceList.Add((Resource)otherEntity);
                otherEntity.Active = false;
            }
            else
            {
                base.HandleCollision(otherEntity);
            }

        }
    }
}
