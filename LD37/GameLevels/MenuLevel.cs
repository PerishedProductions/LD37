
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
        UIButton button;
        UIText mouseText;

        Texture2D title;

        Camera cam;

        Song bgMsucic;

        public override void Initialize()
        {
            canvas = new UICanvas();
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
            button = (UIButton)canvas.CreateUIElement(new UIButton("Play Game", new Rectangle(100, 100, 400, 200)));
            mouseText = (UIText)canvas.CreateUIElement(new UIText(Vector2.Zero, "Mouse Pos"));
            title = content.Load<Texture2D>("Title");
            bgMsucic = content.Load<Song>("TestyTest");
            MediaPlayer.Volume = .05f;
            MediaPlayer.Play(bgMsucic);
        }

        public override void Update(GameTime gameTime)
        {
            mouseText.position = InputManager.Instance.getMousePos();
            mouseText.text = "Mouse Pos: " + InputManager.Instance.getMousePos();
            canvas.Update(gameTime);

            if (button.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                Debug.WriteLine("Button Is Pressed");
                LevelManager.Instance.ChangeLevel(new MainLevel());
            }

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
