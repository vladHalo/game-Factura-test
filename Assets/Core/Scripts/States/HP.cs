using System;
using Core.Scripts.Views;

namespace Core.Scripts.States
{
    [Serializable]
    public class HP
    {
        public int hp;
        public HealthBar healthBar;

        public void SetDamage(int index)
        {
            hp -= index;
            healthBar.SetHealth(hp);
        }
    }
}