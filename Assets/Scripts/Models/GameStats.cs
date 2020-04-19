using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class GameStats
    {
        private static GameStats _instance;
        public static GameStats Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameStats();
                }
                return _instance;
            }
        }

        public float points;
        public int lives = 3;
    }
}
