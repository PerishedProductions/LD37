using CoreGame.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LD37.Entities
{
    public class Tile : Entity
    {

        Animation belt;

        public override void Initialize()
        {
            spriteName = "TransportBelt";
            base.Initialize();
        }

        //Loads the sprite
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
            belt = new Animation(sprite, 64, 64, 3, 100, true);
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            belt.Update(gameTime, position);
            base.Update(gameTime);
        }

        //Draws the sprite at its position
        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(sprite, position);
            belt.Draw(spriteBatch);
        }

    }
}
