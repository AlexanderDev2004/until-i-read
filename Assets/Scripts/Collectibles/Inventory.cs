using UnityEngine;

namespace Assets.Scripts.Collectibles
{
    public abstract class Inventory : MonoBehaviour
    {
        /// <summary>
        /// Total slot quick inventory (default = 4).
        /// </summary>
        [SerializeField] protected int fullQuickSlot = 4;

        /// <summary>
        /// Array untuk menyimpan item di quick slot.
        /// Null = slot kosong.
        /// </summary>
        protected GameObject[] quickSlots;

        protected virtual void Awake()
        {
            quickSlots = new GameObject[fullQuickSlot];
        }

        /// <summary>
        /// Menambah item ke slot. 
        /// Kalau slot penuh, return false (bisa diarahkan ke main inventory).
        /// </summary>
        public abstract bool AddItem(GameObject item);

        /// <summary>
        /// Menghapus item dari slot index tertentu.
        /// </summary>
        public abstract void RemoveItem(int index);

        /// <summary>
        /// Mengecek apakah quick slot penuh.
        /// </summary>
        public bool IsQuickSlotFull()
        {
            foreach (var slot in quickSlots)
            {
                if (slot == null)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Mengambil item pada slot tertentu.
        /// </summary>
        public GameObject GetItem(int index)
        {
            if (index < 0 || index >= fullQuickSlot)
            {
                return null;
            }

            return quickSlots[index];
        }
    }
}