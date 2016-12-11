using LD37.Managers;
using LD37.UI;
using LD37.UI.CustomCanvas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LD37.GameLevels
{
    public class ScoreBoardLevel : GameLevel
    {
        private int _score;

        Camera cam;
        UICanvas canvas;
        Texture2D title;


        public ScoreBoardLevel(int Score)
        {
            _score = Score;
        }

        public override void Initialize()
        {
            canvas = new ScoreBoardCanvas(_score);
            canvas.Initialize();
        }

        public override void InitializeCam(Viewport viewport)
        {
            cam = new Camera(viewport);
            cam.position = new Vector2(-150, -15);
            cam.zoom = 2.5f;
            base.InitializeCam(viewport);
        }

        public override void LoadContent(ContentManager content)
        {
            title = content.Load<Texture2D>("Title");
            canvas.LoadContent(content);

        }

        public override void Update(GameTime gameTime)
        {
            canvas.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, cam.GetViewMatrix());
            spriteBatch.Draw(title, Vector2.Zero);
            spriteBatch.End();

            spriteBatch.Begin();
            canvas.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
