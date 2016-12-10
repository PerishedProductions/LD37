using System;
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
        string textureName;

        public bool mouseOver;

        public UIButton(String text, Rectangle size)
        {
            this.size = size;
            this.text = new UIText(new Vector2(size.X, size.Y), text);
        }

        public override void Initialize()
        {
            textureName = "Window";
            base.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(textureName);
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
