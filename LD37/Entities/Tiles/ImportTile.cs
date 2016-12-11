using LD37.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LD37.Entities
{
    public class ImportTile : Tile
    {


        float BeltSpeed = 0.1f;

        public ImportTile()
        {
            ImportManager.Instance.ImportTile = this;
        }

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
