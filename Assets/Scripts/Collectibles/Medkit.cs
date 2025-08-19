using Assets.Scripts.Items;
using Assets.Scripts.PlayerProperties;
using UnityEngine;

namespace Assets.Scripts.Collectibles
{
    [CreateAssetMenu(fileName = "Medkit", menuName = "Items/Healing/Medkit")]
    public class Medkit : ItemData
    {
        public float healAmount;

        public override void Use(GameObject user)
        {
            if (user.TryGetComponent<Point>(out var hp))
            {
                hp.Heal(healAmount);
                Debug.Log($"{itemName} digunakan, heal {healAmount}.");
            }
        }
    }
}