using UnityEngine;

namespace Assets.Scripts.PlayerProperties
{
    public class Point : MonoBehaviour
    {
        public float maxHealth = 100f;
        public float currentHealth;

        public Type healthType = Type.PHYSICAL;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void Heal(float amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        }

        public void TakeDamage(float amount)
        {
            currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        }

        public bool IsDead()
        {
            return currentHealth <= 0;
        }

        public float GetNormalized()
        {
            return currentHealth / maxHealth;
        }
    }
}