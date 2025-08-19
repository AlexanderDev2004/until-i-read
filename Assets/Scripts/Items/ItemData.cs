using UnityEngine;

namespace Assets.Scripts.Items
{
    public abstract class ItemData : ScriptableObject
    {
        public string itemName;
        public Sprite icon;

        public abstract void Use(GameObject user);
    }
}