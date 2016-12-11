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

        public enum BuildingMode
        {
            None,
            Sell,
            Conveyor,
            AirPump,
            Assembler
        }

        private ConstructionManager()
        {

        }

        public void Update(Matrix viewmatrix)
        {
            if (InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                var mousePos = InputManager.Instance.getMouseWorldPos(viewmatrix);

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
                                    item.Building.Active = false;
                                    item.Building = null;
                                }
                                break;
                            case BuildingMode.Conveyor:
                                break;
                            case BuildingMode.AirPump:
                                if (item.Building == null)
                                {
                                    item.Building = MachineFactory.Instace.CreateAirPump(pos);
                                }

                                break;
                            case BuildingMode.Assembler:
                                if (item.Building == null)
                                {
                                    MachineFactory.Instace.CreateAssembler(pos);
                                }
                                break;
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
