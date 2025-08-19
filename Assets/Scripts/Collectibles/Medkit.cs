using UnityEngine;

namespace Assets.Scripts.Collectibles
{
    public class Medkit : CollectibleItem
    {
        public override void OnPickup(Pickup inventory)
        {
            bool added = inventory.AddItem(itemData); // masukkan data, bukan gameObject

            if (!added)
            {
                Debug.Log("Quick slot penuh, medkit tidak bisa diambil.");
            }
        }
    }
}