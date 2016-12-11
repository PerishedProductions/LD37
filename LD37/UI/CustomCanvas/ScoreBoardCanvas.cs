using LD37.GameLevels;
using LD37.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LD37.UI.CustomCanvas
{
    public class ScoreBoardCanvas : UICanvas
    {
        private int _finalScore;
        private UIText score;
        private UIButton mainMenuButton;

        public ScoreBoardCanvas(int finalScore)
        {
            _finalScore = finalScore;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            score = (UIText)CreateUIElement(new UIText(new Vector2(10, 80), "Score: 0 "));

            mainMenuButton = (UIButton)CreateUIElement(new UIButton("Main Menu", new Rectangle(10, 10, 200, 50), new Vector2(10, 5)));
        }

        public override void Update(GameTime gameTime)
        {
            score.text = $"Score: {_finalScore}";

            score.Update(gameTime);
            mainMenuButton.Update(gameTime);

            base.Update(gameTime);

            if (mainMenuButton.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                LevelManager.Instance.ChangeLevel(new MenuLevel());
            }
        }
    }
}
