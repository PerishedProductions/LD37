﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LD37.Managers;

namespace LD37.UI
{
    class UIButton : UIElement
    {

        UIText text;
        Rectangle size;
        Texture2D sprite;
        public string textureName;

        public WindowTheme windowTheme = WindowTheme.Dark;

        public bool mouseOver;

        public UIButton(String text, Rectangle size, Vector2 textPos)
        {
            this.size = size;
            this.text = new UIText(new Vector2(size.X + textPos.X, size.Y + textPos.Y), text);
        }

        public UIButton(String text, Rectangle size, Vector2 textPos, WindowTheme theme)
        {
            this.size = size;
            this.text = new UIText(new Vector2(size.X + textPos.X, size.Y + textPos.Y), text);
            this.windowTheme = theme;
        }

        public override void Initialize()
        {
            switch (windowTheme)
            {
                case WindowTheme.Dark:
                    textureName = "Window";
                    break;
                case WindowTheme.Light:
                    textureName = "LightWindow";
                    break;
            }
            base.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(textureName);
            text.LoadContent(content);
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            mouseOver = size.Contains(InputManager.Instance.getMousePos());
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, size, Color.White);
            text.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }

    }
}
