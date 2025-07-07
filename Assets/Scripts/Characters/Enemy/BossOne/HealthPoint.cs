using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Characters.Enemy.BossOne
{
    public interface IDamageable
    {
        void GetAttackByWeapon(float damage);
    }

    public class HealthPoint : MonoBehaviour, IDamageable
    {
        [Header("Health Settings")]
        public float maxHealth = 200f;
        public float currentHealth;

        [Header("UI Settings")]
        [SerializeField] private GameObject healthBarCanvas;
        [SerializeField] private Image healthBarFill;

        void Start()
        {
            currentHealth = maxHealth;
            SetHealthBar();
        }

        void Update()
        {
            GetAttackByWeapon(10f);
        }

        public void GetAttackByWeapon(float damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            UpdateHealthBar();

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void SetHealthBar()
        {
            if (healthBarCanvas != null)
            {
                healthBarCanvas.SetActive(true);
            }

            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            if (healthBarFill != null)
            {
                healthBarFill.fillAmount = currentHealth / maxHealth;
            }
        }

        private void Die()
        {
            Debug.Log("The boss is died.");

        }
    }
}