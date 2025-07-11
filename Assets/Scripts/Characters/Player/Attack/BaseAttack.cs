using UnityEngine;

namespace Assets.Scripts.Characters.Player.Attack
{
    public abstract class BaseAttack : MonoBehaviour
    {
        public float speed;
        public float range;
        public float damage;
        public abstract void Attack();
    }
}