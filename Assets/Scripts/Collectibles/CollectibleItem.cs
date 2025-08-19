using UnityEngine;
using Assets.Scripts.Interaction;

namespace Assets.Scripts.Collectibles
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class CollectibleItem : Base
    {
        [Header("Collectible Data")]
        public string itemName;
        public Sprite icon;
        public GameObject itemData;

        protected Pickup playerInventory;

        private new void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && other.TryGetComponent<Pickup>(out var inventory))
            {
                playerInventory = inventory;
            }

            base.OnTriggerEnter2D(other); // biar prompt E tetap jalan
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
                OnPickup(playerInventory);
                Destroy(gameObject);
            }
        }

        public abstract void OnPickup(Pickup inventory);
    }
}