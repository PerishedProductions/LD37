﻿using Microsoft.Xna.Framework;

namespace LD37.Entities.Resources
{
    public class Plastic : Resource
    {
        public const int PlasticPrice = 100;

        public override int Price
        {
            get
            {
                return PlasticPrice;
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
