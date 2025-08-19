using UnityEngine;

namespace Assets.Scripts.Collectibles
{
    public class Pickup : Inventory
    {
        public override bool AddItem(GameObject item)
        {
            for (int i = 0; i < fullQuickSlot; i++)
            {
                if (quickSlots[i] == null) // Slot kosong
                {
                    quickSlots[i] = item;
                    return true; // sukses masuk ke quick slot
                }
            }

            return false; // penuh, bisa diarahkan ke main inventory nanti
        }

        public override void RemoveItem(int index)
        {
            if (index < 0 || index >= fullQuickSlot)
            {
                return;
            }

            quickSlots[index] = null; // hapus item
        }
    }
}