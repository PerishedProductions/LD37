using LD37.Entities.Resources;
using LD37.Entities.Resources.Toys;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LD37.Entities.Machines
{
    public class Assembler : Machine
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
                    FabricateToyRobot();
                    CurrentConstructionTime = 0;
                }
            }
        }

        private void FabricateToyRobot()
        {
            Plastic plastic = ResourceList.OfType<Plastic>().FirstOrDefault();
            Battery battery = ResourceList.OfType<Battery>().FirstOrDefault();

            if (plastic != null)
            {
                toyFactory.CreateToyRobot(this.position + new Vector2(this.sprite.Width, 0));
                ResourceList.Remove(plastic);
                ResourceList.Remove(battery);
            }
        }

        private bool HasRequiredResource()
        {
            Plastic plastic = ResourceList.OfType<Plastic>().FirstOrDefault();
            Battery battery = ResourceList.OfType<Battery>().FirstOrDefault();

            return plastic != null && battery != null;
        }

        public override void HandleCollision(Entity otherEntity)
        {
            if (otherEntity is Plastic)
            {
                ResourceList.Add((Resource)otherEntity);
                otherEntity.Active = false;
            }
            else if (otherEntity is Battery)
            {
                ResourceList.Add((Resource)otherEntity);
                otherEntity.Active = false;
            }
            else
            {
                FabricateScrap();
                otherEntity.Active = false;
            }

        }


        private void FabricateScrap()
        {
            ResourceFactory.Instance.CreateScrap(this.position + new Vector2(this.sprite.Width, 0));
        }
    }
}
