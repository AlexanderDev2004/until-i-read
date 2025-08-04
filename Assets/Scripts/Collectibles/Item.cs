using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public bool isUsable;

    public virtual void Use()
    {
        Debug.Log("Using item: " + itemName);
    }
}
