﻿
using LD37.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LD37.GameLevels
{
    public class MenuLevel : GameLevel
    {

        SpriteFont font;
        Vector2 titlePosition;

        int menuIndex = 0;
        string[] menuItems = new string[3];

        public override void Initialize()
        {
            titlePosition = new Vector2(200, 100);
            menuItems[0] = "Play";
            menuItems[1] = "Bullet Enviorment";
            menuItems[2] = "Map Editor";
        }

        public override void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("FontMedium");
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
                        //LevelManager.Instance.ChangeLevel(new MainLevel());
                        break;
                    case 1:
                        //LevelManager.Instance.ChangeLevel(new BulletTestingEnvironment());
                        break;
                    case 2:
                        break;

                }
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font, "Santa's Workshop", titlePosition, Color.White);

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (menuIndex == i)
                {
                    spriteBatch.DrawString(font, "- " + menuItems[i], titlePosition + new Vector2(titlePosition.X, titlePosition.Y + i * 50), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(font, menuItems[i], titlePosition + new Vector2(titlePosition.X, titlePosition.Y + i * 50), Color.White);
                }
            }

            spriteBatch.End();
        }
    }
}
