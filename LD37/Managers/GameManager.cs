using LD37.GameLevels;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace LD37.Managers
{
    public class GameManager
    {
        public static GameManager Instance { get; set; } = new GameManager();
        private const int TotalGameLength = 1 * 60 * 1000;

        public int GameLength { get; set; } = TotalGameLength;

        private GameManager()
        {

        }

        public void Update(GameTime gameTime)
        {
            GameLength -= gameTime.ElapsedGameTime.Milliseconds;

            if (GameLength <= 0)
            {
                GameLength = TotalGameLength;
                FinishGame();
            }
        }

        private void FinishGame()
        {
            int score = StatManager.Instance.GetMoney;
            Debug.WriteLine($"GAME OVER: Final score: {score}");
            StatManager.Instance.Reset();
            LevelManager.Instance.ChangeLevel(new ScoreBoardLevel(score));
        }
    }
}
