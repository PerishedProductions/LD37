using CoreGame.Utilities;
using LD37.Entities;
using LD37.Entities.Machines;
using LD37.Entities.Resources;
using LD37.Entities.Resources.Toys;
using LD37.Managers;
using LD37.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace LD37.GameLevels
{
    public class MainLevel : GameLevel
    {

        UICanvas canvas;

        Camera cam;
        Map map;
        ReadJson jsonLoader;
        Texture2D background;

        public ContentManager Content { get; set; }
        public List<Resource> ResourceList { get; set; } = new List<Resource>();
        public List<Machine> MachineList { get; set; } = new List<Machine>();

        public override void Initialize()
        {
            jsonLoader = new ReadJson();
            map = new Map(jsonLoader.ReadData("Data/Map.json"));
            map.Initialize();

            canvas = new MainGameCanvas();
            canvas.Initialize();

            base.Initialize();
        }

        public override void InitializeCam(Viewport viewport)
        {
            cam = new Camera(viewport);
            base.InitializeCam(viewport);
        }

        public override void LoadContent(ContentManager content)
        {
            ToyFactory.Instance.LevelInstance = this;
            MachineFactory.Instance.LevelInstance = this;
            ResourceFactory.Instance.LevelInstance = this;

            Content = content;

            background = content.Load<Texture2D>("BG");

            MainGameCanvas tempCanvas = (MainGameCanvas)canvas;
            tempCanvas.constructionManager = ConstructionManager.Instance;
            canvas.LoadContent(content);

            map.LoadContent(content);

            ConstructionManager.Instance.Tiles = map.tiles;
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            ConstructionManager.Instance.Update(cam.GetViewMatrix());
            ImportManager.Instance.Update(gameTime);
            ExportManager.Instance.Update(gameTime);
            GameManager.Instance.Update(gameTime);

            if (InputManager.Instance.isPressed(Keys.R))
            {
                switch (ConstructionManager.Instance.BuildDirection)
                {
                    case ConstructionManager.BuildingDirection.UP:
                        ConstructionManager.Instance.BuildDirection = ConstructionManager.BuildingDirection.RIGHT;
                        break;
                    case ConstructionManager.BuildingDirection.LEFT:
                        ConstructionManager.Instance.BuildDirection = ConstructionManager.BuildingDirection.UP;
                        break;
                    case ConstructionManager.BuildingDirection.RIGHT:
                        ConstructionManager.Instance.BuildDirection = ConstructionManager.BuildingDirection.DOWN;
                        break;
                    case ConstructionManager.BuildingDirection.DOWN:
                        ConstructionManager.Instance.BuildDirection = ConstructionManager.BuildingDirection.LEFT;
                        break;
                    default:
                        break;
                }
                Debug.WriteLine("Build Direction: " + ConstructionManager.Instance.BuildDirection);
            }

            if (InputManager.Instance.isDown(Keys.W))
            {
                cam.position += new Vector2(0, -3);
            }

            if (InputManager.Instance.isDown(Keys.S))
            {
                cam.position += new Vector2(0, 3);
            }

            if (InputManager.Instance.isDown(Keys.D))
            {
                cam.position += new Vector2(3, 0);
            }

            if (InputManager.Instance.isDown(Keys.A))
            {
                cam.position += new Vector2(-3, 0);
            }

            if (InputManager.Instance.getMouseWheelState() > InputManager.Instance.getOldMouseWheelState())
            {
                cam.zoom += 0.1f;
            }

            if (InputManager.Instance.getMouseWheelState() < InputManager.Instance.getOldMouseWheelState())
            {
                cam.zoom -= 0.1f;
            }

            for (int i = MachineList.Count - 1; i >= 0; i--)
            {
                MachineList[i].Update(gameTime);

                if (!MachineList[i].Active)
                {
                    MachineList.Remove(MachineList[i]);
                }
            }

            for (int i = ResourceList.Count - 1; i >= 0; i--)
            {
                ResourceList[i].Update(gameTime);

                foreach (var Machine in MachineList)
                {
                    if (Machine.CheckCollision(ResourceList[i]))
                    {
                        Machine.HandleCollision(ResourceList[i]);

                        if (!(Machine is TransportBelt))
                        {
                            break;
                        }

                    }
                }

                if (ImportManager.Instance.ImportTile.CheckCollision(ResourceList[i]))
                {
                    ImportManager.Instance.ImportTile.HandleCollision(ResourceList[i]);
                }

                if (ExportManager.Instance.ExportTile.CheckCollision(ResourceList[i]))
                {
                    ExportManager.Instance.ExportTile.HandleCollision(ResourceList[i]);
                }

                if (!ResourceList[i].Active)
                {
                    ResourceList.Remove(ResourceList[i]);
                }
            }

            map.Update(gameTime);
            canvas.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, cam.GetViewMatrix());

            spriteBatch.Draw(background, new Vector2(-100, -100));
            map.Draw(spriteBatch);

            foreach (var item in MachineList)
            {
                item.Draw(spriteBatch);
            }

            foreach (var item in ResourceList)
            {
                item.Draw(spriteBatch);
            }

            spriteBatch.End();


            spriteBatch.Begin();
            canvas.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(spriteBatch);
        }
    }
}
