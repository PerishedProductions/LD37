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

namespace LD37.GameLevels
{
    public class MainLevel : GameLevel
    {

        UICanvas canvas;
        UIText mouseText;

        Camera cam;
        Map map;
        ReadJson jsonLoader;

        private ConstructionManager constructionManager = ConstructionManager.Instance;
        public ContentManager Content { get; set; }
        public List<Resource> ResourceList { get; set; } = new List<Resource>();
        public List<Machine> MachineList { get; set; } = new List<Machine>();

        public override void Initialize()
        {
            jsonLoader = new ReadJson();
            map = new Map(jsonLoader.ReadData("Data/Map.json"));
            map.Initialize();

            canvas = new UICanvas();
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
            MachineFactory.Instace.LevelInstance = this;

            Content = content;
            canvas.LoadContent(content);
            mouseText = (UIText)canvas.CreateUIElement(new UIText(Vector2.Zero, "Mouse Pos"));

            Resource resource = new Leather();
            resource.spriteName = "Window";
            resource.LoadContent(content);
            resource.RotationInDegrees = 0;
            resource.position = new Vector2(100, 100);
            resource.SpriteColor = Color.Brown;
            ResourceList.Add(resource);

            resource = new Battery();
            resource.spriteName = "Window";
            resource.LoadContent(content);
            resource.RotationInDegrees = 0;
            resource.position = new Vector2(200, 200);
            resource.SpriteColor = Color.Green;
            ResourceList.Add(resource);

            resource = new Plastic();
            resource.spriteName = "Window";
            resource.LoadContent(content);
            resource.RotationInDegrees = 0;
            resource.position = new Vector2(100, 200);
            resource.SpriteColor = Color.LightGray;
            ResourceList.Add(resource);


            map.LoadContent(content);

            constructionManager.Tiles = map.tiles;
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            mouseText.position = InputManager.Instance.getMousePos();
            mouseText.text = "Mouse Pos: " + InputManager.Instance.getMousePos();

            constructionManager.Update();

            if (InputManager.Instance.isDown(Keys.F))
            {
                constructionManager.BuildMode = ConstructionManager.BuildingMode.AirPump;
            }

            if (InputManager.Instance.isDown(Keys.G))
            {
                constructionManager.BuildMode = ConstructionManager.BuildingMode.Assembler;
            }

            if (InputManager.Instance.isDown(Keys.H))
            {
                constructionManager.BuildMode = ConstructionManager.BuildingMode.Sell;
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
                ResourceList[i].position += new Vector2(0.1f, 0);
                foreach (var Machine in MachineList)
                {
                    if (Machine.CheckCollision(ResourceList[i]))
                    {
                        Machine.HandleCollision(ResourceList[i]);
                    }
                }

                if (!ResourceList[i].Active)
                {
                    ResourceList.Remove(ResourceList[i]);
                }
            }

            map.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, cam.GetViewMatrix());
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
