using UnityEngine;

namespace Assets.Scripts.Characters.Player.Health
{
    public class Medkit : HealingItem
    {
        public override void Use(Point target)
        {
            if (target.healthType == Type.PHYSICAL)
            {
                target.Heal(amount);
            }
        }
    }
}