using LD37.Entities;
using LD37.Entities.Machines;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace LD37.Managers
{
    public class ConstructionManager
    {
        public static ConstructionManager Instance { get; set; } = new ConstructionManager();

        public List<Tile> Tiles { get; set; }

        public BuildingMode BuildMode { get; set; } = BuildingMode.None;
        public BuildingDirection BuildDirection { get; set; } = BuildingDirection.RIGHT;

        public enum BuildingDirection
        {
            UP,
            LEFT,
            RIGHT,
            DOWN
        }

        public enum BuildingMode
        {
            None,
            Sell,
            TransportBelt,
            AirPump,
            Assembler,
            SortingMachine
        }

        private ConstructionManager()
        {

        }

        public void Update(Matrix viewmatrix)
        {
            if (InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                var mousePos = Vector2.Transform(InputManager.Instance.getMousePos(), Matrix.Invert(viewmatrix));

                Rectangle rect = new Rectangle((int)mousePos.X, (int)mousePos.Y, 1, 1);

                foreach (var item in Tiles)
                {
                    if (item.BoundingBox.Intersects(rect))
                    {
                        Debug.WriteLine($"item intersected: {item.position.X} {item.position.Y}");
                        Vector2 pos = new Vector2(item.position.X, item.position.Y);

                        switch (BuildMode)
                        {
                            case BuildingMode.None:
                                break;
                            case BuildingMode.Sell:
                                if (item.Building != null)
                                {
                                    Debug.WriteLine($"Sold building");
                                    item.Building.Active = false;
                                    item.Building = null;
                                }
                                break;
                            case BuildingMode.TransportBelt:
                                if (item.Building == null)
                                {
                                    Debug.WriteLine($"Build transportbelt");
                                    item.Building = MachineFactory.Instace.CreateTransportBelt(pos, BuildDirection);
                                }
                                break;
                            case BuildingMode.AirPump:
                                if (item.Building == null)
                                {
                                    Debug.WriteLine($"Build AirPump");
                                    item.Building = MachineFactory.Instace.CreateAirPump(pos);
                                }

                                break;
                            case BuildingMode.Assembler:
                                if (item.Building == null)
                                {
                                    Debug.WriteLine($"Build Assembler");
                                    item.Building = MachineFactory.Instace.CreateAssembler(pos);
                                }
                                break;

                            case BuildingMode.SortingMachine:
                                {
                                    if (item.Building == null)
                                    {
                                        Debug.WriteLine($"Build SortingMachine");
                                        item.Building = MachineFactory.Instace.CreateSortingMachine(pos);
                                    }
                                    break;
                                }
                            default:
                                break;
                        }

                        break;
                    }
                }
            }
        }
    }
}
