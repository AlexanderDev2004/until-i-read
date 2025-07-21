using UnityEngine;

namespace Assets.Scripts.Characters.Enemy.BusBrokers
{
    public class HealthPoint : MonoBehaviour
    {
        public float maxHealth = 100f;
        public float currentHealth;
        public float setDamage = 2f;

        private GameObject healthBar;

        void Start()
        {
            currentHealth = maxHealth;
        }

        void Update()
        {
            Attack();
            GetDamage();
        }

        private void Attack()
        {

        }

        private void GetDamage()
        {
            
        }
    }
}