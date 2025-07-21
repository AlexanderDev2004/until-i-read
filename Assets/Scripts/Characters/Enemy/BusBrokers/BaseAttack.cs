using UnityEngine;

namespace Assets.Scripts.Characters.Enemy.BusBrokers
{
    public abstract class BaseAttack : MonoBehaviour
    {
        public float damage;

        public abstract void Attack();
    }
}