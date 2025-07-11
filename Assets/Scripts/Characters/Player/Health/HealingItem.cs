using UnityEngine;

namespace Assets.Scripts.Characters.Player.Health
{
    public abstract class HealingItem : MonoBehaviour
    {
        public Type healType;
        public float amount;
        public abstract void Use(Point target);
    }
}