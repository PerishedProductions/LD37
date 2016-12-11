using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace LD37.Entities
{
    public class ExportTile : Tile
    {

        public override void LoadContent(ContentManager content)
        {
            spriteName = "Window";
            base.LoadContent(content);
        }

    }
}
