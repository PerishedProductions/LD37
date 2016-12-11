using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD37.Managers
{
    public class StatManager
    {

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

        int money = 1000;

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

    }
}
