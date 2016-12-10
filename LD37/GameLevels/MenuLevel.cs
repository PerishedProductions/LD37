
using LD37.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace LD37.GameLevels
{
    public class MenuLevel : GameLevel
    {

        SpriteFont fontBig;
        SpriteFont fontSmall;
        Vector2 titlePosition;

        int menuIndex = 0;
        string[] menuItems = new string[3];

        public override void Initialize()
        {
            titlePosition = new Vector2(200, 100);
            menuItems[0] = "Play";
            menuItems[1] = "Credits";
            menuItems[2] = "Map Editor";
        }

        public override void LoadContent(ContentManager content)
        {
            fontBig = content.Load<SpriteFont>("FontMedium");
            fontSmall = content.Load<SpriteFont>("FontSmall");
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.Instance.isPressed(Keys.Up))
            {
                if (menuIndex == 0)
                {
                    menuIndex = 2;
                }
                else
                {
                    menuIndex -= 1;
                }
            }

            if (InputManager.Instance.isPressed(Keys.Down))
            {
                if (menuIndex == 2)
                {
                    menuIndex = 0;
                }
                else
                {
                    menuIndex += 1;
                }
            }

            if (InputManager.Instance.isPressed(Keys.Enter))
            {
                switch (menuIndex)
                {
                    case 0:
                        LevelManager.Instance.ChangeLevel(new MainLevel());
                        break;
                    case 1:
                        //LevelManager.Instance.ChangeLevel(new BulletTestingEnvironment());
                        break;
                    case 2:
                        break;

                }
            }

            if (InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                Debug.WriteLine("Left mouse button pressed");
            }

            if (InputManager.Instance.mouseIsPressed(MouseButton.Right))
            {
                Debug.WriteLine("Right mouse button pressed");
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(fontBig, "Santa's Workshop", titlePosition, Color.White);

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (menuIndex == i)
                {
                    spriteBatch.DrawString(fontBig, "- " + menuItems[i], titlePosition + new Vector2(titlePosition.X, titlePosition.Y + i * 50), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(fontBig, menuItems[i], titlePosition + new Vector2(titlePosition.X, titlePosition.Y + i * 50), Color.White);
                }
            }


            spriteBatch.DrawString(fontSmall, "Mouse Position: " + InputManager.Instance.getMousePos().ToString(), InputManager.Instance.getMousePos(), Color.White);

            spriteBatch.End();
        }
    }
}
