using LD37.Entities;
using LD37.Entities.Machines;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LD37.Managers
{
    public class ConstructionManager
    {
        public static ConstructionManager Instance { get; set; } = new ConstructionManager();

        public List<Tile> Tiles { get; set; }

        private ConstructionManager()
        {

        }

        public void Update()
        {
            if (InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                var mousePos = InputManager.Instance.getMousePos();

                Rectangle rect = new Rectangle((int)mousePos.X, (int)mousePos.Y, 1, 1);

                foreach (var item in Tiles)
                {
                    if (item.BoundingBox.Intersects(rect))
                    {
                        MachineFactory.Instace.CreateAirPump(item.position);
                    }
                }
            }
        }
    }
}
