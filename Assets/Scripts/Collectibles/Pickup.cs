using Assets.Scripts.Items;
using UnityEngine;

namespace Assets.Scripts.Collectibles
{
    public class Pickup : Inventory
    {
        public override bool AddItem(ItemData item)
        {
            for (int i = 0; i < fullQuickSlot; i++)
            {
                if (quickSlots[i] == null) // Slot kosong
                {
                    quickSlots[i] = item;

                    if (slotImages != null && i < slotImages.Length)
                    {
                        slotImages[i].sprite = item.icon;
                        slotImages[i].enabled = true; // pastikan gambar aktif
                    }

                    Debug.Log($"Item {item.itemName} ditambahkan ke slot {i}");
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

            // Reset UI slot jadi kosong
            if (slotImages != null && index < slotImages.Length)
            {
                slotImages[index].sprite = null;
                slotImages[index].enabled = false;
            }
        }
    }
}