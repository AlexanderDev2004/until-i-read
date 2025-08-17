using UnityEngine;

namespace Assets.Scripts.Collectibles
{
    public class Pickup : MonoBehaviour
    {
        private Inventory inventory;
        public GameObject itemPrefab; // Prefab item yang akan diambil

        private void Start()
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                for (int i = 0; i < inventory.slot.Length; i++)
                {
                    if (inventory.isfull[i] == false)
                    {
                        inventory.isfull[i] = true;
                        Instantiate(itemPrefab, inventory.slot[i].transform, false);
                        Destroy(gameObject); // Hapus item setelah diambil
                        break;
                    }
                }
            }
        }
    }
}