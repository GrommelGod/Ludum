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
        public int _knives = 1;
        public bool _powerUp = false;

        public void Refresh()
        {
            _instance = new GameStats();
        }
    }
}
