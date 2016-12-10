using LD37.GameLevels;
using Microsoft.Xna.Framework;

namespace LD37.Entities.Resources
{
    public class ResourceFactory
    {
        public static ResourceFactory Instance { get; set; } = new ResourceFactory();
        public MainLevel LevelInstance { get; set; }

        private ResourceFactory()
        {

        }

        public Resource CreatePlastic(Vector2 position)
        {
            Plastic plastic = new Plastic();

            plastic.spriteName = "Window";
            plastic.RotationInDegrees = 0;
            plastic.position = position;
            plastic.SpriteColor = Color.LightGray;
            plastic.LoadContent(LevelInstance.Content);

            LevelInstance.ResourceList.Add(plastic);

            return plastic;
        }

        public Resource CreateLeather(Vector2 position)
        {
            Leather leather = new Leather();

            leather.spriteName = "Window";
            leather.RotationInDegrees = 0;
            leather.position = position;
            leather.SpriteColor = Color.Brown;
            leather.LoadContent(LevelInstance.Content);

            LevelInstance.ResourceList.Add(leather);

            return leather;
        }

        public Resource CreateBattery(Vector2 position)
        {
            Battery battery = new Battery();

            battery.spriteName = "Window";
            battery.RotationInDegrees = 0;
            battery.position = position;
            battery.SpriteColor = Color.Orange;
            battery.LoadContent(LevelInstance.Content);

            LevelInstance.ResourceList.Add(battery);

            return battery;
        }
    }
}
