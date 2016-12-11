using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using LD37.Entities.Machines;
using Microsoft.Xna.Framework;

namespace LD37.Entities
{
    public class ImportTile : Tile
    {

        float BeltSpeed = 0.1f;

        public override void LoadContent(ContentManager content)
        {
            spriteName = "Window";
            base.LoadContent(content);
        }

        public override void HandleCollision(Entity otherEntity)
        {
            otherEntity.position += new Vector2(BeltSpeed, 0);
        }

    }
}
