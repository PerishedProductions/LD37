using LD37.GameLevels;
using LD37.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

namespace LD37.UI
{
    class MainMenuCanvas : UICanvas
    {

        UIButton play;
        UIButton settings;
        UIButton exit;

        UIText credits;

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            play = (UIButton)CreateUIElement(new UIButton("Play Game", new Rectangle(1280 / 2 - 190 / 2, 350, 190, 50), new Vector2(20, 3)));
            settings = (UIButton)CreateUIElement(new UIButton("Settings", new Rectangle(1280 / 2 - 190 / 2, 430, 190, 50), new Vector2(30, 3)));
            exit = (UIButton)CreateUIElement(new UIButton("Exit Game", new Rectangle(1280 / 2 - 190 / 2, 510, 190, 50), new Vector2(20, 3)));
            credits = (UIText)CreateUIElement(new UIText(new Vector2(1280 / 2 - 695 / 2, 680), "Created in 72 hours by Perished Productions"));
        }

        public override void Update(GameTime gameTime)
        {
            if (play.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                LevelManager.Instance.ChangeLevel(new MainLevel());
            }

            if (exit.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                LevelManager.Instance.Exit();
            }

            base.Update(gameTime);
        }

    }
}
