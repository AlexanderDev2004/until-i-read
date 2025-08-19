using UnityEngine;

namespace Assets.Scripts.Items
{
    [CreateAssetMenu(fileName = "PuzzleItem", menuName = "Items/Puzzle/Generic")]
    public class PuzzleItem : ItemData
    {
        public string puzzleId;

        public override void Use(GameObject user)
        {
            Debug.Log($"Puzzle item {itemName} digunakan untuk puzzle {puzzleId}.");
        }
    }
}