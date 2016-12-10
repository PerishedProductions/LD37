using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LD37.Managers;
using LD37.Entities;
using CoreGame.Utilities;
using Microsoft.Xna.Framework.Input;

namespace LD37.GameLevels
{
    public class MainLevel : GameLevel
    {

        Camera cam;
        Map map;
        ReadJson jsonLoader;

        public override void Initialize()
        {
            jsonLoader = new ReadJson();
            map = new Map(jsonLoader.ReadData("Data/Map.json"));
            map.Initialize();
            base.Initialize();
        }

        public override void InitializeCam(Viewport viewport)
        {
            cam = new Camera(viewport);
            base.InitializeCam(viewport);
        }

        public override void LoadContent(ContentManager content)
        {
            map.LoadContent(content);
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {

            if (InputManager.Instance.isDown(Keys.W))
            {
                cam.position += new Vector2(0, -1);
            }

            if (InputManager.Instance.isDown(Keys.S))
            {
                cam.position += new Vector2(0, 1);
            }

            if (InputManager.Instance.isDown(Keys.D))
            {
                cam.position += new Vector2(1, 0);
            }

            if (InputManager.Instance.isDown(Keys.A))
            {
                cam.position += new Vector2(-1, 0);
            }

            map.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, cam.GetViewMatrix());
            map.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(spriteBatch);
        }
    }
}
