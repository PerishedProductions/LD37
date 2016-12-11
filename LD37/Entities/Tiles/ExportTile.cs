using LD37.Entities.Resources;
using LD37.Managers;
using Microsoft.Xna.Framework.Content;

namespace LD37.Entities
{
    public class ExportTile : Tile
    {

        public ExportTile()
        {
            ExportManager.Instance.ExportTile = this;
        }

        public override void LoadContent(ContentManager content)
        {
            spriteName = "Window";
            base.LoadContent(content);
        }

        public override void HandleCollision(Entity otherEntity)
        {
            if (otherEntity is Resource)
            {
                ExportManager.Instance.ExportQueue.Enqueue((Resource)otherEntity);
                otherEntity.Active = false;
            }

        }

    }
}
