using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{
    public Item[] items = new Item[5]; // Hotbar dengan 5 slot
}