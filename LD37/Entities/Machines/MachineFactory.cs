using LD37.GameLevels;
using Microsoft.Xna.Framework;

namespace LD37.Entities.Machines
{
    public class MachineFactory
    {
        public static MachineFactory Instace { get; set; } = new MachineFactory();
        public MainLevel LevelInstance { get; set; }


        private MachineFactory()
        {

        }

        public Machine CreateAirPump(Vector2 position)
        {
            AirPump machine = new AirPump();

            machine.spriteName = "Window";
            machine.RotationInDegrees = 0;
            machine.position = position;
            machine.SpriteColor = Color.Blue;
            machine.LoadContent(LevelInstance.Content);

            LevelInstance.MachineList.Add(machine);

            return machine;
        }

        public Machine CreateAssembler(Vector2 position)
        {
            Assembler machine = new Assembler();

            machine.spriteName = "Window";
            machine.RotationInDegrees = 0;
            machine.position = position;
            machine.SpriteColor = Color.Gray;
            machine.LoadContent(LevelInstance.Content);

            LevelInstance.MachineList.Add(machine);

            return machine;
        }

    }
}
