using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class GameEvents
    {
        public static event EventHandler OnGameOver;
        public static void TriggerGameOver()
        {
            OnGameOver?.Invoke(null, null);
        }
    }
}
