using UnityEngine;

namespace Assets.Scripts.Characters.Player.KaraSarjito.Health
{
    [CreateAssetMenu(fileName = "Medkit", menuName = "Items/Healing/Medkit")]
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