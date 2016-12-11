using CoreGame.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LD37.Entities.Resources.Toys
{
    public class SoccerBall : Toy
    {
        public const int SoccerBallPrice = 250;

        public override int Price
        {
            get
            {
                return SoccerBallPrice;
            }
        }


        Animation anim;

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            anim = new Animation(sprite, 64, 64, 5, 100, true);
        }

        public override void Update(GameTime gameTime)
        {
            anim.Update(gameTime, position);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            anim.Draw(spriteBatch);
        }

        public override void HandleCollision(Entity otherEntity)
        {

        }
    }
}
