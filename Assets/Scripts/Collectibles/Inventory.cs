using Assets.Scripts.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Collectibles
{
    public abstract class Inventory : MonoBehaviour
    {
        /// <summary>
        /// Total slot quick inventory (default = 4).
        /// </summary>
        [SerializeField] protected int fullQuickSlot = 4;

        /// <summary>
        /// Menampilkan gambar item yang nantinya akan ditampilkan
        /// di quick slot.
        /// </summary>
        [SerializeField] protected Image[] slotImages;

        /// <summary>
        /// Array untuk menyimpan item di quick slot.
        /// Null = slot kosong.
        /// </summary>
        protected ItemData[] quickSlots;

        protected virtual void Awake()
        {
            quickSlots = new ItemData[fullQuickSlot];
        }

        /// <summary>
        /// Menambah item ke slot. 
        /// Kalau slot penuh, return false (bisa diarahkan ke main inventory).
        /// </summary>
        public abstract bool AddItem(ItemData item);

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
        public ItemData GetItem(int index)
        {
            if (index < 0 || index >= fullQuickSlot)
            {
                return null;
            }

            return quickSlots[index];
        }
    }
}