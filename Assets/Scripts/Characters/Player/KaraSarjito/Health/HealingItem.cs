using UnityEngine;

namespace Assets.Scripts.Characters.Player.KaraSarjito.Health
{
    public abstract class HealingItem : MonoBehaviour
    {
        public Type healType;
        public float amount;
        public abstract void Use(Point target);
    }
}