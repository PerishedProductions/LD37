using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LD37.Managers;
using LD37.Entities;
using CoreGame.Utilities;

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
