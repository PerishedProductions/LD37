namespace LD37.Managers
{
    public class StatManager
    {
        private const int StartingMoney = 1000;

        private static StatManager instance;

        private StatManager() { }

        public static StatManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StatManager();
                }
                return instance;
            }
        }

        int money = StartingMoney;

        public int GetMoney
        {
            get
            {
                return money;
            }
            private set
            {
                money = value;
            }
        }

        public void AddMoney(int amount)
        {
            money += amount;
        }

        public void RemoveMoney(int amount)
        {
            money -= amount;
        }

        public void Reset()
        {
            money = StartingMoney;
        }
    }
}
