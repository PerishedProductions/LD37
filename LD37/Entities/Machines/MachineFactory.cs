using LD37.GameLevels;
using Microsoft.Xna.Framework;
using static LD37.Managers.ConstructionManager;

namespace LD37.Entities.Machines
{
    public class MachineFactory
    {
        public static MachineFactory Instance { get; set; } = new MachineFactory();
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

        public Machine CreateTransportBelt(Vector2 position, BuildingDirection direction)
        {
            TransportBelt transportBelt = new TransportBelt();

            transportBelt.spriteName = "Window";
            transportBelt.BeltDirection = direction;
            transportBelt.position = position;
            transportBelt.SpriteColor = Color.White;
            transportBelt.LoadContent(LevelInstance.Content);

            LevelInstance.MachineList.Add(transportBelt);


            return transportBelt;
        }

        public Machine CreateSortingMachine(Vector2 position)
        {
            SortingMachine sortingMachine = new SortingMachine();

            sortingMachine.spriteName = "Window";
            sortingMachine.position = position;
            sortingMachine.SpriteColor = Color.Red;
            sortingMachine.LoadContent(LevelInstance.Content);

            LevelInstance.MachineList.Add(sortingMachine);

            return sortingMachine;
        }
    }
}
