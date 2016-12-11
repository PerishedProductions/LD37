using CoreGame.Graphics;
using LD37.Entities.Resources;
using LD37.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static LD37.Managers.ConstructionManager;

namespace LD37.Entities.Machines
{
    public class TransportBelt : Machine
    {
        public float BeltSpeed { get; set; } = 0.5f;
        public BuildingDirection BeltDirection { get; set; }

        Animation up;
        Animation down;
        Animation left;
        Animation right;

        Animation currentAnim;

        Texture2D spriteUp;
        Texture2D spriteDown;
        Texture2D spriteLeft;
        Texture2D spriteRight;

        public override void LoadContent(ContentManager content)
        {
            spriteUp = content.Load<Texture2D>("TransportBelt");
            spriteDown = content.Load<Texture2D>("TransportBeltDown");
            spriteLeft = content.Load<Texture2D>("TransportBeltLeft");
            spriteRight = content.Load<Texture2D>("TransportBeltRight");

            base.LoadContent(content);
            up = new Animation(spriteUp, 64, 64, 3, 100, true);
            down = new Animation(spriteDown, 64, 64, 3, 100, true);
            left = new Animation(spriteLeft, 64, 64, 3, 100, true);
            right = new Animation(spriteRight, 64, 64, 3, 100, true);

            currentAnim = right;
        }

        public override void Update(GameTime gameTime)
        {
            currentAnim.Update(gameTime, position);
            switch (BeltDirection)
            {
                case ConstructionManager.BuildingDirection.UP:
                    currentAnim = up;
                    break;
                case ConstructionManager.BuildingDirection.LEFT:
                    currentAnim = left;
                    break;
                case ConstructionManager.BuildingDirection.RIGHT:
                    currentAnim = right;
                    break;
                case ConstructionManager.BuildingDirection.DOWN:
                    currentAnim = down;
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            currentAnim.Draw(spriteBatch);
        }

        public override bool CheckCollision(Entity otherEntity)
        {
            bool collision = false;
            switch (BeltDirection)
            {
                case BuildingDirection.UP:
                case BuildingDirection.DOWN:
                    {
                        collision = this.BoundingBox.Center.X == otherEntity.BoundingBox.Center.X;
                        break;
                    }


                case BuildingDirection.RIGHT:
                case BuildingDirection.LEFT:
                    {
                        collision = this.BoundingBox.Center.Y == otherEntity.BoundingBox.Center.Y;
                        break;
                    }

                default:
                    {
                        collision = false;
                        break;
                    }

            }

            return collision && this.BoundingBox.Intersects(otherEntity.BoundingBox);
        }

        public override void HandleCollision(Entity otherEntity)
        {
            if (otherEntity is Resource)
            {
                switch (BeltDirection)
                {
                    case ConstructionManager.BuildingDirection.UP:
                        otherEntity.position -= new Vector2(0, BeltSpeed);
                        break;
                    case ConstructionManager.BuildingDirection.LEFT:
                        otherEntity.position -= new Vector2(BeltSpeed, 0);
                        break;
                    case ConstructionManager.BuildingDirection.RIGHT:
                        otherEntity.position += new Vector2(BeltSpeed, 0);
                        break;
                    case ConstructionManager.BuildingDirection.DOWN:
                        otherEntity.position += new Vector2(0, BeltSpeed);
                        break;
                }
            }

        }
    }
}
