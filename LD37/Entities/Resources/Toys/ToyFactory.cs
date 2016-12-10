using LD37.GameLevels;
using Microsoft.Xna.Framework;

namespace LD37.Entities.Resources.Toys
{
    public class ToyFactory
    {
        public static ToyFactory Instance { get; set; } = new ToyFactory();
        public MainLevel LevelInstance { get; set; }

        private ToyFactory()
        {

        }

        public Toy CreateSoccerBall(Vector2 position)
        {
            SoccerBall newSoccerBall = new SoccerBall();

            newSoccerBall.position = position;
            newSoccerBall.RotationInDegrees = 0;
            newSoccerBall.SpriteColor = Color.Black;
            newSoccerBall.spriteName = "Window";
            newSoccerBall.LoadContent(LevelInstance.Content);

            LevelInstance.ResourceList.Add(newSoccerBall);

            return newSoccerBall;
        }

        public Toy CreateToyRobot(Vector2 position)
        {
            ToyRobot newToyRobot = new ToyRobot();

            newToyRobot.position = position;
            newToyRobot.RotationInDegrees = 0;
            newToyRobot.SpriteColor = Color.Yellow;
            newToyRobot.spriteName = "Window";
            newToyRobot.LoadContent(LevelInstance.Content);

            LevelInstance.ResourceList.Add(newToyRobot);

            return newToyRobot;
        }
    }
}
