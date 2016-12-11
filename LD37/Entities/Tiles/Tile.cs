using CoreGame.Graphics;
using LD37.Entities.Machines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LD37.Entities
{
    public class Tile : Entity
    {
        public Machine Building { get; set; }

        public override void Initialize()
        {
            spriteName = "Tile";
            base.Initialize();
        }

        //Loads the sprite
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        //Draws the sprite at its position
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position);
        }

    }
}
