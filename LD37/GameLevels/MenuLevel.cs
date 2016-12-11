
using LD37.Managers;
using LD37.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace LD37.GameLevels
{
    public class MenuLevel : GameLevel
    {

        UICanvas canvas;
        UIText mouseText;

        Texture2D title;

        Camera cam;

        Song bgMsucic;

        public override void Initialize()
        {
            canvas = new MainMenuCanvas();
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
            canvas.LoadContent(content);
            mouseText = (UIText)canvas.CreateUIElement(new UIText(Vector2.Zero, "Mouse Pos"));
            title = content.Load<Texture2D>("Title");
            bgMsucic = content.Load<Song>("Song");
            MediaPlayer.Volume = .05f;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(bgMsucic);
        }

        public override void Update(GameTime gameTime)
        {
            mouseText.position = InputManager.Instance.getMousePos();
            mouseText.text = "Mouse Pos: " + InputManager.Instance.getMousePos();
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
