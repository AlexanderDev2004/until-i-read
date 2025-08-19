using UnityEngine;

namespace Assets.Scripts.PlayerProperties
{
    public abstract class HealingItem : ScriptableObject
    {
        public Type healType;
        public float amount;
        public abstract void Use(Point target);
    }
}