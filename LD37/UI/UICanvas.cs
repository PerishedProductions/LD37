﻿using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace LD37.UI
{
    public class UICanvas
    {

        public List<UIElement> uiElements = new List<UIElement>();

        ContentManager content;

        public virtual void Initialize()
        {
            for (int i = 0; i < uiElements.Count; i++)
            {
                uiElements[i].Initialize();
            }
        }

        public virtual void LoadContent(ContentManager content)
        {
            this.content = content;
            for (int i = 0; i < uiElements.Count; i++)
            {
                uiElements[i].LoadContent(content);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            for (int i = 0; i < uiElements.Count; i++)
            {
                uiElements[i].Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < uiElements.Count; i++)
            {
                uiElements[i].Draw(spriteBatch);
            }
        }

        public UIElement CreateUIElement(UIElement element)
        {
            uiElements.Add(element);
            element.Initialize();
            element.LoadContent(content);
            return element;
        }

    }
}
