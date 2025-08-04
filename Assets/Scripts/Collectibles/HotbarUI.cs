using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    public Inventory inventory;
    public Image[] slotImages;
    private int selectedIndex = 0;

    void Start()
    {
        UpdateHotbarUI();
    }

    void Update()
    {
        // Input: Tekan 1–5 untuk memilih item
        for (int i = 0; i < 5; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                SelectSlot(i);
                UseSelectedItem();
            }
        }
    }

    void SelectSlot(int index)
    {
        selectedIndex = index;
        Debug.Log("Slot selected: " + index);
    }

    void UseSelectedItem()
    {
        Item selectedItem = inventory.items[selectedIndex];
        if (selectedItem != null && selectedItem.isUsable)
        {
            selectedItem.Use();
        }
    }

    void UpdateHotbarUI()
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (inventory.items[i] != null)
            {
                slotImages[i].sprite = inventory.items[i].icon;
                slotImages[i].enabled = true;
            }
            else
            {
                slotImages[i].enabled = false;
            }
        }
    }
}
