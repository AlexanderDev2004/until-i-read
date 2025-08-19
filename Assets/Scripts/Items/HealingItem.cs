using Assets.Scripts.PlayerProperties;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class HealingItem : ItemData
    {
        public float amount;
        public Type healType;

        public override void Use(GameObject user)
        {
            var point = user.GetComponent<Point>();
            if (point != null && point.healthType == healType)
            {
                point.Heal(amount);
                Debug.Log($"{itemName} digunakan, heal {amount}.");
            }
        }
    }
}