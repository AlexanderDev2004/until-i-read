using Assets.Scripts.Collectibles;
using Assets.Scripts.Interaction;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class CollectibleItem : Base
    {
        [Header("Collectible Data")]
        public ItemData itemData;

        protected Pickup playerInventory;

        private new void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && other.TryGetComponent<Pickup>(out var inventory))
            {
                playerInventory = inventory;
            }

            base.OnTriggerEnter2D(other);
        }

        private new void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerInventory = null;
            }

            base.OnTriggerExit2D(other);
        }

        public override void Interact()
        {
            if (playerInventory != null)
            {
                bool added = playerInventory.AddItem(itemData);
                if (added)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Quick slot penuh, item tidak bisa diambil.");
                }
            }
        }
    }
}